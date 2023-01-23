using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHide : MonoBehaviour
{
    public GameObject show, hide;
 public void SetActive()
    {
        show.SetActive(true);
        hide.SetActive(false);
    }
}
