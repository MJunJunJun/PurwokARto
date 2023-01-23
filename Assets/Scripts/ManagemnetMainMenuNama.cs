using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagemnetMainMenuNama : MonoBehaviour
{
    public TextMeshProUGUI nama, usia;
    // Start is called before the first frame update
    void Start()
    {
        nama.text = "Hai," + PlayerPrefs.GetString("namapanggilan");
        usia.text="Pemula | "+ PlayerPrefs.GetString("umur")+"+";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
