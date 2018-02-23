﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour{

    public float projectileSpeed;
    public float destroingDelay = 3.0f;

    private MeteorDestruction deathNotificator;


    private void Start()
    {
        deathNotificator = gameObject.GetComponent<MeteorDestruction>();
        Destroy(gameObject, destroingDelay);
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        deathNotificator.OnDestruction(new OnDeathEventArgs());
        Destroy(gameObject);
    }

  

}
