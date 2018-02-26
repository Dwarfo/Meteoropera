using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour{

    public float projectileSpeed = 40f;
    public float destroingDelay = 3.0f;
    

    private MeteorDestruction deathNotificator;


    private void Start()
    {
        deathNotificator = gameObject.GetComponent<MeteorDestruction>();
        Destroy(gameObject, destroingDelay);
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed, ForceMode2D.Impulse);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        deathNotificator.OnDestruction(new OnDeathEventArgs());
        Destroy(gameObject);
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        deathNotificator.OnDestruction(new OnDeathEventArgs());
        Destroy(gameObject);
    }



}
