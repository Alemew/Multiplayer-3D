using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRoom : MonoBehaviour
{
    [SerializeField] 
    private Text nameText;
    [SerializeField] 
    private Text sizeText;

    public void JoinRoomOnClick()
    {
        PhotonNetwork.JoinRoom(nameText.text);
    }

    public void SetRoom(string roomName, int roomCapacity, int playerCount)
    {
        nameText.text = roomName;
        sizeText.text = playerCount + "/" + roomCapacity;
    }
}
