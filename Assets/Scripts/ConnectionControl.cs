using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ConnectionControl : MonoBehaviourPunCallbacks
{

    public GameObject panelUser;
    public GameObject panelLobby;
    public GameObject panelRoom;
    
    void Start()
    {
        panelLobby.SetActive(false);
        panelUser.SetActive(true);
        panelRoom.SetActive(false);
    }

    public void PhotonServerConnect()
    {
        if (PhotonNetwork.IsConnected == false)
        {
            PhotonNetwork.ConnectUsingSettings();
            panelLobby.SetActive(true);
            panelUser.SetActive(false);
        }
    }
    
    public override void OnConnected()
    {
        base.OnConnected();
        Debug.Log("Estamos conectados a internet");
        
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        Debug.Log("Nos hemos desconectado del servidor Photon");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Estamos conectados al servidor Photon");
        Debug.Log("Bienvenido "+ PhotonNetwork.NickName);
        panelLobby.SetActive(false);
        panelRoom.SetActive(true);
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        Debug.Log("No se puede unir a la sala. "+message);
        CreateRoomAndJoin();
    }

    private void CreateRoomAndJoin()
    {
        string nameUser = PhotonNetwork.NickName;
        Debug.Log("User name "+ nameUser);
    }
    
        
}
