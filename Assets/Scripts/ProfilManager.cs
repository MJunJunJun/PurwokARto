using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ProfilManager : MonoBehaviour
{
    public TextMeshProUGUI namaLengkap, namaPanggilan, umur;
    // Start is called before the first frame update
    void Start()
    {
        namaLengkap.text = PlayerPrefs.GetString("namalengkap");
        namaPanggilan.text = PlayerPrefs.GetString("namapanggilan");
        umur.text = PlayerPrefs.GetString("umur");
    }


    public void deletAccount()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
