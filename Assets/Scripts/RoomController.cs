using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class RoomController : MonoBehaviourPunCallbacks
{
    public Text textRoomName;
    public Text textPlayerName;

    [SerializeField] 
    private GameObject _panelLobby;
    [SerializeField] 
    private GameObject _panelRoom;
    
}
