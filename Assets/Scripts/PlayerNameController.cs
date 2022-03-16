using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using WebSocketSharp;


public class PlayerNameController : MonoBehaviour
{
    public void setPlayerName(string playerName)
    {
        if (playerName.IsNullOrEmpty() == false)
        {
            PhotonNetwork.NickName = playerName;
        }
    }
}
