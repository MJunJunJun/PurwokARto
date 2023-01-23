using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVibrate : MonoBehaviour
{
    public void Vibrate()
    {
        Handheld.Vibrate();
        //Vibrator.Vibrate(500);
    }
}
