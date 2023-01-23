using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSpeech : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent OnButtonPressed;
    public UnityEvent OnButtonRealeased;
    public Text text;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnButtonPressed?.Invoke();
       // text.text = "mendengarkan";

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        OnButtonRealeased?.Invoke();
       // text.text = "oke siap";
    }

}
