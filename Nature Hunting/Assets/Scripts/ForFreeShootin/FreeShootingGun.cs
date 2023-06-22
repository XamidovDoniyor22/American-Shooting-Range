using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FreeShootingGun : MonoBehaviour
{
    [SerializeField] private float startTimeForReloding;
    private float timeForReloding;
    [SerializeField] private Transform point;
    [SerializeField] private GameObject bullet;
    private int bulletNumber = 30;

    [Header("Effects")]
    [SerializeField] private ParticleSystem smoke;
    [SerializeField] private CameraShaker cameraShaker;

    [Header("Sounds")]
    private AudioSource audioSource;
    [SerializeField] private AudioClip audio;
    [SerializeField] private AudioClip audioForReloding;

    [Header("UI")]
    [SerializeField] private Text bulletText;
    [SerializeField] private Text bottleNumberText;

    public int bottleNumber;
    public int bottleMaxNumber;
    public Text bottleMaxNumText;

    private void Start()
    {
        bullet = GameObject.FindGameObjectWithTag("Bullet");
        audioSource = GameObject.Find("Gun").GetComponent<AudioSource>();
        cameraShaker = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShaker>();
        bottleMaxNumber = PlayerPrefs.GetInt("bottleMaxNumber");
    }
    public void FreeShooting()
    {
       
              
                audioSource.PlayOneShot(audio);
                Instantiate(bullet, point.position, transform.rotation);
                Instantiate(smoke, point.position, transform.rotation);
                cameraShaker.ShakeRotateCamera(Vector2.down, 10f, 100f);
                Camera.main.gameObject.AddComponent<ShakeCamera>();
                timeForReloding = startTimeForReloding;
                if(bulletNumber > 1) bulletNumber--;
                else if(bulletNumber == 1) StartCoroutine(Reload());
         
    }
    private void Update()
    {
        
        bulletText.text = bulletNumber.ToString();
        bottleNumberText.text = bottleNumber.ToString();
        bottleMaxNumText.text = "Record:" + bottleMaxNumber.ToString();
        Checks();
    }
    private IEnumerator Reload()
    {
        if(bulletNumber == 1)
        {
            timeForReloding = 1f;
            yield return new WaitForSeconds(1f);
            bulletNumber = 30;
            audioSource.PlayOneShot(audioForReloding);         
        }
    }

    private void Checks()
    {
        if(bottleMaxNumber < bottleNumber)
        {
            bottleMaxNumber = bottleNumber;
            PlayerPrefs.SetInt("bottleMaxNumber", bottleMaxNumber);
            PlayerPrefs.Save();
        }
    }
}
