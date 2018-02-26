using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class AndroidControls : MonoBehaviour
{
    public InputButton leftButton;
    public InputButton rightButton;
    public InputButton forwardButton;
    public PlayerController pC;

    private void Update()
    {
        if (forwardButton.isPressed())
        {
            pC.moveForward();
        }
        if (rightButton.isPressed())
        {
            pC.rotSide(-2);
        }
        if (leftButton.isPressed())
        {
            pC.rotSide(2);
        }
    }

}
