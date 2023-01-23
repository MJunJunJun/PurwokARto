using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{

    public void PindahScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ExitApps()
    {
        Application.Quit();
    }
    public void PindahSceneWelcome(int index)
    {
        SceneManager.LoadScene(index);
        PlayerPrefs.SetInt("loading", 1);
        //Debug.Log(PlayerPrefs.GetInt("loading"));
    }
}
