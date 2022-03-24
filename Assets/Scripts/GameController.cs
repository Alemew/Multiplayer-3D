using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class GameController : MonoBehaviourPunCallbacks
{
    [SerializeField] 
    private GameObject playerPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (playerPrefab != null)
            {
                int randomPosition = Random.Range(20, 29);
                Vector3 position = new Vector3(randomPosition, 0, randomPosition);
                PhotonNetwork.Instantiate(playerPrefab.name, position, Quaternion.identity);
            }
        }
    }

    public override void OnJoinedRoom()
    {
        
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        
    }
}
