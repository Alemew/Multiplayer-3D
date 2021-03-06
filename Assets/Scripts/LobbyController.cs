using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;
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

    public Transform roomsContainer;
    public GameObject prefabRoomInList;
    
    
    private Dictionary<string, RoomInfo> cachedRoomList;

    private void Awake()
    {
        cachedRoomList = new Dictionary<string, RoomInfo>();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        DeleteScrollViewRooms();

        UpdateCachedRoomList(roomList);
        UpdateRoomListView();

    }
    
    private void UpdateCachedRoomList(List<RoomInfo> roomList)
    {
        foreach (RoomInfo room in roomList)
        {
            // Remove room from cached room list if it got closed, became invisible or was marked as removed
            if (!room.IsOpen || !room.IsVisible || room.RemovedFromList)
            {
                if (cachedRoomList.ContainsKey(room.Name))
                {
                    cachedRoomList.Remove(room.Name);
                }
            }
            else
            {
                // Update cached room info
                if (cachedRoomList.ContainsKey(room.Name))
                {
                    cachedRoomList[room.Name] = room;
                }
                // Add new room info to cache
                else
                {
                    cachedRoomList.Add(room.Name, room);
                }
            }
        }
    }

    private void UpdateRoomListView()
    {
        foreach (RoomInfo room in cachedRoomList.Values)
        {
            GameObject entry = Instantiate(prefabRoomInList,roomsContainer);
            entry.GetComponent<ButtonRoom>().SetRoom(room.Name, room.MaxPlayers, room.PlayerCount);
            
        }
    }

    void DeleteScrollViewRooms()
    {
        for (int i = roomsContainer.childCount-1; i >=0; i--)
        {
            Destroy(roomsContainer.GetChild(i).gameObject);
        }
    }
    public void SetRoomName()
    {
        _roomName = textRoomName.text;
    }
    
    public void SetRoomCapacity()
    {
        _roomCapacity = int.Parse(textRoomCapacity.text);
    }

    public void CreateRoom()
    {
        SetRoomName();
        SetRoomCapacity();
        Debug.Log("Creating a new room "+ _roomName+ " ......");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = (byte) _roomCapacity;
        roomOptions.IsOpen = true;
        if (string.IsNullOrEmpty(_roomName)== false && _roomCapacity !=0)
        {
            PhotonNetwork.CreateRoom(_roomName, roomOptions);
            Debug.Log("You have create a room: "+ _roomName);
        }
        
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("This room name already exist");
    }

    public void ExitPanelLobby()
    {
        _panelUser.SetActive(true);
        _panelLobby.SetActive(false);
        if (PhotonNetwork.InLobby)
        {
            PhotonNetwork.LeaveLobby();
        }
        PhotonNetwork.Disconnect();
        Debug.Log("Exit Lobby");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("You have joined the "+ _roomName+" room.");
        _panelLobby.SetActive(false);
        _panelRoom.SetActive(true);
        GameObject textPlayerName = _panelRoom.transform.Find("TextPlayerName").gameObject;
        textPlayerName.GetComponent<Text>().text = PhotonNetwork.NickName;
        GameObject textNameRoom = _panelRoom.transform.Find("TextNameRoom").gameObject;
        textNameRoom.GetComponent<Text>().text = PhotonNetwork.CurrentRoom.Name;

        if (PhotonNetwork.IsMasterClient)
        {
            _panelRoom.GetComponent<RoomController>().buttonStartGame.SetActive(true);
        }
        else
        {
            _panelRoom.GetComponent<RoomController>().buttonStartGame.SetActive(false);
        }
        _panelRoom.GetComponent<RoomController>().DeleteAllPlayersInList();
        _panelRoom.GetComponent<RoomController>().FillPlayersList();
    }
}
