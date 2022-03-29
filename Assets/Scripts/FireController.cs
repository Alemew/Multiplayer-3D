using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class FireController : MonoBehaviourPunCallbacks
{

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 6;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position+ (Vector3.up/10), transform.TransformDirection(Vector3.forward), out hit,
                    Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                    Color.yellow);
                Debug.Log("Tocado " + hit.transform.name);
                PhotonNetwork.Destroy(hit.transform.gameObject);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
                Debug.Log("Fallaste");
            }
        }
    }
}
