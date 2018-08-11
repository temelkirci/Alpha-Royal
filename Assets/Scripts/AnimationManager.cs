using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : Photon.MonoBehaviour {

    public Animator anim;
  
    void Start ()
    {
        anim = GetComponent<Animator>();

        Debug.Log("Animator has began");
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //We own this player: send the others our data
            stream.SendNext(anim.GetBool("isJumping"));
            stream.SendNext(anim.GetBool("isRunning"));
            //stream.SendNext(anim.GetBool("JumpingIdle"));
            //stream.SendNext(anim.GetBool("Running"));
            //stream.SendNext(anim.GetBool("JumpingWalking"));
            //stream.SendNext(anim.GetBool("JumpingRunning"));

        }
        else
        {
            anim.SetBool("isJumping", (bool)stream.ReceiveNext());
            anim.SetBool("isRunning", (bool)stream.ReceiveNext());
            //anim.SetBool("Running", (bool)stream.ReceiveNext());
            //anim.SetBool("Idle", (bool)stream.ReceiveNext());
            //anim.SetBool("JumpingWalking", (bool)stream.ReceiveNext());
            //anim.SetBool("JumpingRunning", (bool)stream.ReceiveNext());
        }
    }

    // Update is called once per frame
    public void Update ()
    {
        
        if (photonView.isMine)
        {
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetTrigger("isJumping");
                Debug.Log("Jump");
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                anim.SetTrigger("isRunning");
                Debug.Log("Run");
            }
       
        }
        else
        {

        }
    }
}
