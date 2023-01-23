using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    //public TMP_InputField namaLengkap, namaPanggilan, umur;
    [Header("Panel GameObject")]
    public GameObject pilihBahasa;
    public GameObject login;
    public GameObject register;
    public GameObject loading;

    [Header("Pilih Bahasa")]
    public Image _ind;
    public Image _eng;
    public GameObject btnNext;

    [Header("Loading")]
    public TextMeshProUGUI textNamaLengkap;
    public GameObject popupInfoAwal, popupLoading;
    public bool deletplayerprefebs;
    


    public void Start()
    {
        ChekKondisi();
        if (deletplayerprefebs)
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void Indonesia()
    {
        btnNext.SetActive(true);
        _ind.color = new Color32(77, 77, 77, 255);
        _eng.color = new Color32(255, 255, 255, 255);
        PlayerPrefs.SetInt("bahasa", 0);
    }
    public void Inggris()
    {
        btnNext.SetActive(true);
        _eng.color = new Color32(77, 77, 77, 255);
        _ind.color = new Color32(255, 255, 255, 255);
        PlayerPrefs.SetInt("bahasa", 1);
    }
    public void PilihBahasa()
    {
        loading.SetActive(false);
        login.SetActive(true);
        register.SetActive(false);
        pilihBahasa.SetActive(false);
        PlayerPrefs.SetInt("setupbahasa", 1);//0 indo, 1 inggris
    }

    public void ChekKondisi()
    {
       // PlayerPrefs.DeleteAll();
        //Debug.Log(PlayerPrefs.GetString("namalengkap"));
       // Debug.Log(PlayerPrefs.GetInt("bahasa"));
        string a = PlayerPrefs.GetString("namalengkap");
        int b = PlayerPrefs.GetInt("setupbahasa");



        if (b == 0 && a == "")
        {
            loading.SetActive(false);
            login.SetActive(false);
            register.SetActive(false);
            pilihBahasa.SetActive(true);
        }

        else if (a != "")
        {
            //LOADING
            //textNamaLengkap.text = "Selamat datang " + a;
            Debug.Log("Selamat datang " + a);
            loading.SetActive(true);
            login.SetActive(false);
            register.SetActive(false);
            pilihBahasa.SetActive(false);

            if (PlayerPrefs.GetInt("loading") == 0)
            {
                popupInfoAwal.SetActive(true);
                popupLoading.SetActive(false);
                //PlayerPrefs.SetInt("loading", 1);
            }
            else
            {
                popupInfoAwal.SetActive(false);
                popupLoading.SetActive(true);
            }
        }
        else
        {

            Debug.Log("isi");
            pilihBahasa.SetActive(false);

            loading.SetActive(false);
            login.SetActive(true);
            register.SetActive(false);

        }
    }

   
}
