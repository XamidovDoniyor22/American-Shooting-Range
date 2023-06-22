using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private  float speed;
    [SerializeField] private float distance;
    [SerializeField] private GameObject bulletLeave;

    private AudioSource audioSource;
    [SerializeField] private  AudioClip audioWood;
    [SerializeField] private AudioClip audioConcrete;
    [SerializeField] private AudioClip audioSteel;
    [SerializeField] private AudioClip audioTree;

    [SerializeField] private GameObject sound;

    private void Start()
    {
        sound = GameObject.FindGameObjectWithTag("Sound");
        audioSource = sound.GetComponent<AudioSource>();
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distance); 
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wood")
        {
            Instantiate(bulletLeave, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(audioWood);
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Steel")
        {
            Instantiate(bulletLeave, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(audioSteel);
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Concrete")
        {
            Instantiate(bulletLeave, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(audioConcrete);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Tree")
        {
            audioSource.PlayOneShot(audioTree);
            Destroy(gameObject);
        }
    }
}
