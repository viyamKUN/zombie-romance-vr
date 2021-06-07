using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    //how fast the bullet would move
    public float speed = 60;
    public GameObject bullet;
    public Transform bulletHole;
    private AudioSource audioSource;
    public AudioClip audioClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Fire()
    {
        if(GameManager.GM.Bullet > 0){
            //creating the bullet
            GameObject spawnedBullet = Instantiate(bullet, bulletHole.position, bulletHole.rotation);

            //moving the bullet
            spawnedBullet.GetComponent<Rigidbody>().velocity = speed * bulletHole.forward;

            //play sound
            audioSource.PlayOneShot(audioClip);

            //kill the bullet after 2 seconds
            Destroy(spawnedBullet, 2);
            GameManager.GM.Bullet -= 1;
        }
    }

}
