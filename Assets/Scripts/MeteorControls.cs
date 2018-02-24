using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorControls : MonoBehaviour {

    Vector3 randomSpeed;

    void Start ()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * (transform.rotation.z/4 + 40));
        //randomSpeed = (transform.up * (transform.rotation.z / 4 + 40)) / 180;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
