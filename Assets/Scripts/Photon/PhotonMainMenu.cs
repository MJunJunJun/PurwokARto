using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectPlayer()
    {
        int cekUrutanMonster = int.Parse(PlayerPrefs.GetString("urutanmonster"));
        ExitGames.Client.Photon.Hashtable playerSelectionProp = new ExitGames.Client.Photon.Hashtable { { MultiplayerPurwokartoTopGame.PLAYER_SELECTION_NUMBER, cekUrutanMonster-1 } };
        PhotonNetwork.LocalPlayer.SetCustomProperties(playerSelectionProp);
    }
}
