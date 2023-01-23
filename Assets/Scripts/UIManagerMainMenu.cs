using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerMainMenu : MonoBehaviour
{
    public static UIManagerMainMenu instance;

    //Screen object variables
    public GameObject MainMenu;
    public GameObject Koleksi;
    public GameObject Leaderboard;
    public GameObject Profil;
    public GameObject PilihMonster;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    public void ClearScreen() //Turn off all screens
    {
        MainMenu.SetActive(false);
        Koleksi.SetActive(false);
        Leaderboard.SetActive(false);
        Profil.SetActive(false);
        PilihMonster.SetActive(false);
    }
    public void MainMenuScreen()
    {
        ClearScreen();
        MainMenu.SetActive(true);
    }
    public void KoleksiScreen()
    {
        ClearScreen();
        Koleksi.SetActive(true);
    }
    public void LeaderboardScreen()
    {
        ClearScreen();
        Leaderboard.SetActive(true);
    }
    public void profilScreen()
    {
        ClearScreen();
        Profil.SetActive(true);
    }
    public void PilihMonsterScreen()
    {
        ClearScreen();
        PilihMonster.SetActive(true);
    }
}
