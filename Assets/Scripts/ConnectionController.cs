using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionController : MonoBehaviourPunCallbacks
{

    public GameObject panelUser;
    public GameObject panelConnect;
    public GameObject panelLobby;
    public GameObject panelRoom;
    
    void Start()
    {
        RandomName();
        panelLobby.SetActive(false);
        panelUser.SetActive(true);
        panelRoom.SetActive(false);
        panelConnect.SetActive(false);
    }
    
    void RandomName()
    {
        InputField inputFieldNickName = panelUser.GetComponentInChildren<InputField>();
        inputFieldNickName.text = "Player " + Random.Range(1, 100);
    }

    public void PhotonServerConnect()
    {
        if (PhotonNetwork.IsConnected == false && string.IsNullOrEmpty(PhotonNetwork.NickName) == false)
        {
            PhotonNetwork.ConnectUsingSettings();
            panelConnect.SetActive(true);
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
        panelLobby.SetActive(true);
        panelConnect.SetActive(false);
        GameObject textPlayerName = panelLobby.transform.Find("TextPlayerName").gameObject;
        textPlayerName.GetComponent<Text>().text = PhotonNetwork.NickName;
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log("No se puede unir a la sala. "+message);
    }

    
}
