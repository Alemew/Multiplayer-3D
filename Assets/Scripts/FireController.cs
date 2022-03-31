using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class FireController : MonoBehaviourPunCallbacks
{

    public float fireDistance;
    public float pointsDamage;
    private Animator animator;
    private AudioSource damageSound;
    [SerializeField] private AudioClip clipDamage;
    
    
    void Update()
    {
        int layerMask = 1 << 6;
        if (Input.GetKey(KeyCode.Mouse0) && photonView.IsMine)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position+ (Vector3.up/10), transform.TransformDirection(Vector3.forward), out hit,
                    fireDistance, layerMask))
            {
                string objectTag = hit.collider.gameObject.tag;
                if (objectTag != "Player")
                {
                    Debug.Log("Has dado a una caja: " + hit.transform.name);
                    PhotonNetwork.Destroy(hit.transform.gameObject);
                }
                else
                {
                    hit.transform.gameObject.GetComponent<PhotonView>().RPC("Damage",RpcTarget.AllBufferedViaServer,pointsDamage);
                    Debug.Log("Has dado a un enemigo");
                    animator = hit.collider.gameObject.GetComponent<Animator>();
                    animator.SetTrigger("IsDamage");
                    animator.CrossFadeInFixedTime("Damage",0.3f);
                    damageSound = hit.collider.gameObject.GetComponent<AudioSource>();
                    damageSound.clip = clipDamage;
                    damageSound.loop = false;
                    damageSound.Play();
                }
            }
        }
    }
}
