using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour {

    public GameObject Meteor;
    public GameObject Player;
    public GameObject gameOverMenu;
    public GameObject playerCamera;
    public GameObject meteorCountText;
    [SerializeField]
    private int numberOfMeteors = 100;
    private int meteorsDestroyed = 0;

    void Start ()
    {
        spawnPlayer();
        Player.GetComponent<PlayerController>().gameOverMenu = gameOverMenu;
        Player.GetComponent<CameraControlls>().playerCamera = playerCamera;

        //Random.seed = 1; obsolete in this version
        Random.InitState(1);
        while (numberOfMeteors > 0)
        {
            populateSpace();
            numberOfMeteors--;
        }
    }

    private void populateSpace()
    {
        int randomX;
        int randomY;

        do
        {
            randomX = Random.Range(-500, 500);
            randomY = Random.Range(-500, 500);
        }
        while(IsWithin(randomX, 0, 32) && IsWithin(randomY, 0,32));

        Instantiate(Meteor, new Vector2(randomX, randomY), Quaternion.AngleAxis(randomX, new Vector3(0,0,1)));
        //newMeteor.transform.parent = gameObject.transform;
    }

    private void spawnPlayer()
    {
        Player = Instantiate(Player, gameObject.transform.position, gameObject.transform.rotation);
        gameObject.transform.SetParent(Player.transform);
    }

    public static bool IsWithin(float value, float minimum, float maximum)
    {
        return value >= minimum && value <= maximum;
    }

    public void show(object sender, OnDeathEventArgs e)
    {
        meteorsDestroyed++;
        meteorCountText.GetComponent<UnityEngine.UI.Text>().text = "Meteors Destroyed: " + meteorsDestroyed;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MeteorDestruction md = collision.GetComponent<MeteorDestruction>();
        if (md != null)
            md.meteorDestroyed += show;
    }
}
