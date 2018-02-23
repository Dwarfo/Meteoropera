using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayAgain : MonoBehaviour {

    public Button restartButton;

	void Start ()
    {
       restartButton.onClick.AddListener(restartGame);
    }

    private void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
