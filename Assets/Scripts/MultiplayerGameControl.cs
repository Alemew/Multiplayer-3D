using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerGameControl : MonoBehaviourPunCallbacks
{
    [SerializeField] 
    private Text textUIPlayerName;
    // Start is called before the first frame update
    void Start()
    {
        SetTextUIPlayerName();
        if (photonView.IsMine)
        {
            transform.GetComponent<Invector.vCharacterController.vThirdPersonInput>().enabled = true;
        }
        else
        {
            transform.GetComponent<Invector.vCharacterController.vThirdPersonInput>().enabled = false;
        }
    }

    void SetTextUIPlayerName()
    {
        if (textUIPlayerName != null)
        {
            textUIPlayerName.text = photonView.Owner.NickName;
        }
    }
}
