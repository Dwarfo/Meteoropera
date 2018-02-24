using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour {

    public GameObject Meteor;
    public GameObject Player;
    public GameObject gameOverMenu;
    public GameObject playerCamera;
    public GameObject meteorCountText;

    void Start ()
    {
        spawnPlayer();

        //Random.seed = 1; obsolete in this version

        optimize();

        Random.InitState(1);

        for (int i = 0; i < 128; i++)
        {
            for (int j = 0; j < 128; j++)
            {
                if (i == 64 && j == 64)
                {
                    continue;
                }
                Instantiate(Meteor, new Vector2(i, j) * 5, Quaternion.AngleAxis(Random.Range(0, 360), new Vector3(0, 0, 1)));
            }
        }
        Instantiate(Meteor, new Vector2(128, 129) * 5, Quaternion.AngleAxis(Random.Range(0, 360), new Vector3(0, 0, 1))); // so they are exactly 16 384
    }

    private void spawnPlayer()
    {
        Player = Instantiate(Player, gameObject.transform.position, gameObject.transform.rotation);
        gameObject.transform.SetParent(Player.transform);
        Player.GetComponent<PlayerController>().gameOverMenu = gameOverMenu;
        Player.GetComponent<CameraControlls>().playerCamera = playerCamera;
        Player.GetComponent<FireProjectile>().meteorCountText = meteorCountText;
    }

    private void optimize()
    {
        int[] layernums = new int[] {0,1,2,4,5,8,9};
        Physics2D.velocityIterations = 6;
        Physics2D.positionIterations = 2;

        foreach (int number in layernums)
        {
            foreach (int number2 in layernums)
                Physics2D.IgnoreLayerCollision(number, number2, true);
        }
        Physics2D.IgnoreLayerCollision(0, 0, false);

        Time.fixedDeltaTime = 0.05f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        gameOverMenu.SetActive(true);
        Destroy(Player);
    }

  


    

}
