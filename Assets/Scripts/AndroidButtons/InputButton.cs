using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class InputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool pressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

    public bool isPressed()
    {
        return pressed;
    }

}
