using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D Player;
    public GameObject explosion;
    public GameObject gameOverMenu;
    public float Acceleration = 200f;


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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        gameOverMenu.SetActive(true);
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
