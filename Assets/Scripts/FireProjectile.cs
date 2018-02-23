using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour {

    public GameObject Projectile;
    public Transform firingPosition;
    public AudioClip[] shooting;

    private AudioSource audioSource;

    // Use this for initialization
    void Start ()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        InvokeRepeating("Fire", 0.5f, 0.5f);
    }
	

    public void Fire()
    {
            Instantiate(Projectile, firingPosition.position, firingPosition.rotation);
            int randomClip = Random.Range(0, 4);
            audioSource.PlayOneShot(shooting[randomClip]);
    }
}
