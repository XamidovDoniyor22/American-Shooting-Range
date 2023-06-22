using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBottle : MonoBehaviour
{ 
    [SerializeField] private GameObject bullet;

    [SerializeField] private GunLevel2 targetCount;
    [SerializeField] private GameObject gun;

    public AudioClip audio;
    private AudioSource audioSource;

    [SerializeField] private ParticleSystem brokenGlass;

  

 
    private void Start()
    {
        bullet = GameObject.FindGameObjectWithTag("Bullet");
        gun = GameObject.FindGameObjectWithTag("Gun");
        targetCount = gun.GetComponent<GunLevel2>();
        audioSource = gun.GetComponent<AudioSource>();
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            targetCount.TargetNumChecker();
            audioSource.PlayOneShot(audio);
            Destroy(other.gameObject);

           
            Destroy(gameObject, 0.3f);
            Instantiate(brokenGlass, transform.position, transform.rotation);
        }
    }
}
