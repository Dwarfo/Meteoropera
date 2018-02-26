using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour {

    public GameObject Meteor;
    public GameObject Player;
    public GameObject gameOverMenu;
    public GameObject playerCamera;
    public GameObject meteorCountText;
    public AndroidControls androidControls;
    
    private void Awake()
    {
        #if UNITY_ANDROID
            //androidControls.pC = Player.GetComponent<PlayerController>();
        #endif
        #if UNITY_STANDALONE_WIN
            Destroy(androidControls.gameObject);
        #endif
    }

    void Start ()
    {
        spawnPlayer();
        androidControls.pC = Player.GetComponent<PlayerController>();
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
        Instantiate(Meteor, new Vector2(128, 129) * 5, Quaternion.AngleAxis(Random.Range(0, 360), new Vector3(0, 0, 1))); //and one more so they are exactly 16 384
    }

    private void spawnPlayer()
    {
        Player = Instantiate(Player, gameObject.transform.position, gameObject.transform.rotation);
        gameObject.transform.SetParent(Player.transform);
        Player.GetComponent<CameraControlls>().playerCamera = playerCamera;
        Player.GetComponent<FireProjectile>().meteorCountText = meteorCountText;
    }

    private void optimize()
    {
        int[] layernums = new int[] {0,1,2,4,5,8,9};
        Physics2D.velocityIterations = 2;
        Physics2D.positionIterations = 1;

        foreach (int number in layernums)
        {
            foreach (int number2 in layernums)
                Physics2D.IgnoreLayerCollision(number, number2, true);// make all layered collisions ignored
        }
        Physics2D.IgnoreLayerCollision(0, 0, false);// except one that matters

        Time.fixedDeltaTime = 0.04f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {     
        gameOverMenu.SetActive(true);
        Destroy(Player);
    }

  


    

}
