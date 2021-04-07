using System;
using System.Collections;
using System.Collections.Generic;
using MyEvents;
using pEventBus;
using Photon.Pun;
using Photon.Realtime;
using Unity.UIWidgets.widgets;
using UnityEngine;


public class PunConnect : MonoBehaviourPunCallbacks, IEventReceiver<ChatMessage>,IEventReceiver<PunEvent>
{
    // Start is called before the first frame update
    void Start()
    {
        EventBus.Register(this);
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("pun connected");
        PhotonNetwork.JoinOrCreateRoom("0", new RoomOptions() {MaxPlayers = 20}, default);
        EventBus.Raise(new ConnectionToMaster());
    }

    [PunRPC]
    void Message(String msg)
    {
        Debug.Log("PunRpc : " + msg);
        EventBus.Raise(new UiMessage(msg));
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("joined room" + PhotonNetwork.CurrentRoom);
        photonView.RPC("Message", RpcTarget.AllBufferedViaServer, photonView.Owner + " joined room");
    }


    public void OnEvent(ChatMessage e)
    {
        Debug.Log("receive request " + e.msg);
        photonView.RPC("Message", RpcTarget.AllBufferedViaServer, e.msg);
    }

    private void OnDestroy()
    {
        EventBus.UnRegister(this);
    }

    public void OnEvent(PunEvent e)
    {
        
    }
}