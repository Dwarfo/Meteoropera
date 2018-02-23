using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlls : MonoBehaviour {

    public GameObject playerCamera;


    void Start ()
    {
 
	}

	
    void Update ()
    {
        playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -11);
    }
}
