using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent eventButton;

    public void OnPointerDown(PointerEventData eventData)
    {
        eventButton.Invoke();
    }

}


