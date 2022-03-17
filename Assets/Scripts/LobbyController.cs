using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviourPunCallbacks
{

    public Text textRoomName;
    public Text textRoomCapacity;
    public Text textNamePlayer;
    private string _roomName;
    private int _roomCapacity;
    [SerializeField] 
    private GameObject _panelLobby;
    [SerializeField] 
    private GameObject _panelUser;
    [SerializeField] 
    private GameObject _panelRoom;
    
    // Start is called before the first frame update
    void Start()
    {
        textNamePlayer.text = PhotonNetwork.NickName;
        PhotonNetwork.JoinLobby();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
