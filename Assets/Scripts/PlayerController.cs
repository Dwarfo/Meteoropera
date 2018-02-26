using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D Player;
    public GameObject explosion;
    public float Acceleration = 80f;


    // Use this for initialization
    void Start ()
    {
        Player = gameObject.GetComponent<Rigidbody2D>();
	}
	

    public void moveForward()
    {
        Player.AddForce(transform.up * Acceleration);
        //Debug.Log(transform.up);
    }

    public void rotSide(int side)
    {
        transform.Rotate(0, 0, side, Space.World);
    }

  
}
