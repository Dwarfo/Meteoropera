using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour {

    public GameObject Projectile;
    public Transform firingPosition;
    public GameObject meteorCountText;
    public AudioClip[] shooting;

    private int meteorsDestroyed = 0;
    private AudioSource audioSource;

    // Use this for initialization
    void Start ()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        InvokeRepeating("Fire", 0.5f, 0.5f);
    }

    public void show(object sender, OnDeathEventArgs e)
    {
        meteorsDestroyed++;
        meteorCountText.GetComponent<UnityEngine.UI.Text>().text = "Meteors Destroyed: " + meteorsDestroyed;

    }

    public void Fire()
    {
            GameObject laser = Instantiate(Projectile, firingPosition.position, firingPosition.rotation);
            laser.GetComponent<MeteorDestruction>().meteorDestroyed += show;
            int randomClip = Random.Range(0, 4);
            audioSource.PlayOneShot(shooting[randomClip]);
    }

}
