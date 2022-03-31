using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayersDamageController : MonoBehaviourPunCallbacks
{
    public float health;
    [SerializeField]
    private Text txtHealth;

    [PunRPC]
    public void Damage(float damage)
    {
        health = health - damage;
        txtHealth.text = health.ToString();
        Debug.Log("Vida: "+health);
        if (health < 0)
        { 
            health = 0;
            txtHealth.text = health.ToString();
            Debug.Log("Has muerto");
        }
    }
}
