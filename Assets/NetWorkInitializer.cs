using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;

public class NetWorkInitializer : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        // PhotonNetwork.ConnectUsingSettings("1.1");
    }

    private void Update()
    {
        // Debug.Log(photonView);
        Debug.Log(PhotonNetwork.MasterClient);
        Debug.Log(photonView.Controller);
        // if(photonView.Owner.Equals(PhotonNetwork.MasterClient))
        // Debug.Log(photonView);
    }
}