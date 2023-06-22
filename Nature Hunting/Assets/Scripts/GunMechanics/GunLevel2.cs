using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GunLevel2 : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _point;
    [SerializeField] private float _startTimeForReloding;
    public float _timeForReloding;

    [Header("UI")]
    [SerializeField] private UIButtons _buttons;


    [SerializeField] private GameObject _gun;

    [Header("Checkings")]
    [SerializeField] private int _bulletNum = 12;
    [SerializeField] private int _targetBottleNumber;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject[] _targetBottles;

    [Header("UI")]
    [SerializeField] private Text _bulletText;
    [SerializeField] private Text _bottleText;

    [Header("Sound")]
     private AudioSource audioSource;
    [SerializeField] private AudioClip audio;
    [SerializeField] private AudioClip goodJobSound;
    [SerializeField] private AudioClip loseSound;

    [Header("Shaker")]
    CameraShaker cameraShaker;
    [SerializeField] private ParticleSystem smoke;
   


    private void Start()
    {
        _winPanel.SetActive(false);
        _losePanel.SetActive(false);
        _bullet = GameObject.FindGameObjectWithTag("Bullet");
        _gun = GameObject.Find("Gun");
        audioSource = _gun.GetComponent<AudioSource>();
        cameraShaker = GetComponentInChildren<CameraShaker>();
        _targetBottles = new GameObject[_targetBottles.Length];
      _buttons = GameObject.Find("UISound").GetComponent<UIButtons>();
    }

    public void Gunshooting()
    {
       
            
                //if (EventSystem.current.IsPointerOverGameObject()) return;
                audioSource.PlayOneShot(audio);
                Instantiate(_bullet, _point.position, transform.rotation);
                Instantiate(smoke, _point.position, transform.rotation);
                cameraShaker.ShakeRotateCamera(Vector2.down, 10f, 100f);
                Camera.main.gameObject.AddComponent<ShakeCamera>();
              
                _timeForReloding = _startTimeForReloding;
                _bulletNum--;
            
           
        
    }
    private void Update()
    {
        //Gunshooting();
        PanelChecks();

        _bulletText.text = _bulletNum.ToString();
        _bottleText.text = _targetBottleNumber.ToString();
    }
    private void PanelChecks()
    {
        if(_bulletNum >= 0 && _targetBottleNumber == 8)
        {
           
            _buttons.pauseButton.enabled = false;
            _winPanel.SetActive(true);
            _losePanel.SetActive(false);
            audioSource.PlayOneShot(goodJobSound);
            Destroy(_bullet);
            
            Destroy(_bulletText);
            Pass();
            audioSource = null;
        }
        if(_bulletNum == 0 && _targetBottleNumber != 8)
        {
            
          
            _buttons.pauseButton.enabled = false;
            _losePanel.SetActive(true);
            _winPanel.SetActive(false);
            audioSource.PlayOneShot(loseSound);
            Destroy(_bullet);
           
            Destroy(_bulletText);
            audioSource = null;
        }
    }
    public void TargetNumChecker()
    {
        _targetBottleNumber++;
    }
    private void Pass()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("levelUnlocked"))
        {
            PlayerPrefs.SetInt("levelUnlocked", currentLevel);
        }
        Debug.Log("Leevel" + PlayerPrefs.GetInt("levelUnlocked") + "unlocked");
    }
}
