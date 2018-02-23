using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorControls : MonoBehaviour {

    void Start ()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * (transform.rotation.z/4 + 40));
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
            Destroy(gameObject);
    }
}
