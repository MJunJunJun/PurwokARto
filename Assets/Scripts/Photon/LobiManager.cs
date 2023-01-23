using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class LobiManager : MonoBehaviourPunCallbacks
{
    //[Header("Login UI")]
    // public InputField playerNameInputField;
    [Header("COnnection Status")]
    public TMP_Text connectionStatus;
    public bool ShowConnectionStatus = false;
    #region UNITY METHOD

    // Start is called before the first frame update
    void Start()
    {
       // OnEnterGameButtonClicked();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShowConnectionStatus)
        {
            connectionStatus.text = "Connection Status: " + PhotonNetwork.NetworkClientState;
        }
        
    }
    #endregion

    #region UI CALL BACK METHODS
    public void OnEnterGameButtonClicked()
    {
        //string playerName = playerNameInputField.text;
        string playerName = PlayerPrefs.GetString("namalengkap");
        if (!string.IsNullOrEmpty(playerName))
        {
            if (!PhotonNetwork.IsConnected)
            {
                PhotonNetwork.LocalPlayer.NickName = playerName;
                PhotonNetwork.ConnectUsingSettings();
            }
            ShowConnectionStatus = true;
        }
        else
        {
            Debug.Log("Player name is invailid or empty");
        }



    }

    #endregion

    #region PHOTON CALLBACK METHODS
    public override void OnConnected()
    {
        Debug.Log("WE CONNECT TO INTERNET");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " is connect to photon server");
    }

    #endregion



}
