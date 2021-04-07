using System.Collections;
using System.Collections.Generic;
using pEventBus;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


public class PunConnect : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("pun connected");
        PhotonNetwork.JoinOrCreateRoom("0", new RoomOptions(){MaxPlayers = 20}, default);
        EventBus.Raise(new ConnectionToMaster());
    }

    [PunRPC]
    void c()
    {
        photonView.RPC("ChatMessage", RpcTarget.All, "jup", "and jup.");
    }
}
