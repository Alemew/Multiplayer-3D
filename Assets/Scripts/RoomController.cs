using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomController : MonoBehaviourPunCallbacks
{
    public Text textRoomName;
    public Text textPlayerName;
    public GameObject buttonStartGame;
    [SerializeField] 
    private GameObject _panelLobby;
    [SerializeField] 
    private GameObject _panelRoom;
    
    public GameObject prefabPlayerInList;
    public Transform playersContainer;

    public void ExitPanelRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.JoinLobby();
        _panelRoom.SetActive(false);
        _panelLobby.SetActive(true);
    }

    public void FillPlayersList()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            GameObject tempListing = Instantiate(prefabPlayerInList, playersContainer);
            Text tempText = tempListing.transform.GetChild(0).GetComponent<Text>();
            tempText.text = player.NickName;
        }
    }

    public void DeleteAllPlayersInList()
    {
        for (int i = playersContainer.childCount-1; i >=0; i--)
        {
            Destroy(playersContainer.GetChild(i).gameObject);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        DeleteAllPlayersInList();
        FillPlayersList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        DeleteAllPlayersInList();
        FillPlayersList();
    }
}
