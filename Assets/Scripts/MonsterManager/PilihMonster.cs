using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PilihMonster : MonoBehaviour
{
    public FirebaseMainMenuManager manager;
    public Image[] monster;
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
        foreach(Image m in monster)
        {
            m.color = new Color32(255, 255, 255, 255);
        }
        monster[urut - 1].color = new Color32(77, 77, 77, 255);
        manager.urutanMonster = urut;
    }
}
