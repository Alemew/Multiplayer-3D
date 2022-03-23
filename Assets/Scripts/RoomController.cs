using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
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

    public void ExitPanelRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.JoinLobby();
        _panelRoom.SetActive(false);
        _panelLobby.SetActive(true);
    }

}
