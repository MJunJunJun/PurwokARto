using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PilihGasing : MonoBehaviour
{
    public Image[] gasing;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void KlikPilihMonster(int urut)
    {
        foreach (Image m in gasing)
        {
            m.color = new Color32(255, 255, 255, 255);
        }
        gasing[urut - 1].color = new Color32(77, 77, 77, 255);
        
    }
}
