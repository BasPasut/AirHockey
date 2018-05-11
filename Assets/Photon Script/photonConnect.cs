﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photonConnect : MonoBehaviour
{

    public string versionName = "0.1";
    public GameObject sectionView1, sectionView2, sectionView3;

    public void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);
        Debug.Log("Connecting to photon...");
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);

        Debug.Log("We are connected to master");
    }
    private void OnJoinedLobby()
    {
        sectionView1.SetActive(false);
        sectionView2.SetActive(true);
        //sectionView3.SetActive(false);
        Debug.Log("On Join Lobby");
    }


    private void OnDisconnectedFromPhoton()
    {
        if (sectionView1.active)
        {

            sectionView1.SetActive(false);
        }
        if (sectionView2.active)
        {
            sectionView2.SetActive(false);
        }
        sectionView3.SetActive(true);

        Debug.Log("Dis from photon");
    }

    
}
