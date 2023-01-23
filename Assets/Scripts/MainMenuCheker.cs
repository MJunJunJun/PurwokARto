using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCheker : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        chek();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chek()
    {
        //Debug.Log(PlayerPrefs.GetInt("cekmonster"));
        if (PlayerPrefs.GetInt("cekmonster") ==1)
        {
            UIManagerMainMenu.instance.MainMenuScreen();
        }
        else
        {
            UIManagerMainMenu.instance.PilihMonsterScreen();
        }
        
        
    }
}
