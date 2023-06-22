using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottlesForFreeShooting : MonoBehaviour
{ 
    [SerializeField] private ParticleSystem brokenGlass;
    [SerializeField] private AudioClip audio;
    private AudioSource audioSource;
    [SerializeField] private FreeShootingGun numBottle;

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
        numBottle = GameObject.FindGameObjectWithTag("Gun").GetComponent<FreeShootingGun>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            audioSource.PlayOneShot(audio);
            Instantiate(brokenGlass, this.transform.position, transform.rotation);
            Destroy(gameObject);
            numBottle.bottleNumber++;
        }
    }
}
