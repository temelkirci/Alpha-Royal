using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : Photon.MonoBehaviour
{
    public GameObject playerInventory;
    private bool openInventory;

    // Use this for initialization
    void Start ()
    {
        playerInventory = GameObject.Find("Inventory");
        openInventory = false;
        playerInventory.SetActive(openInventory);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (photonView.isMine)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //photonView.RPC("InventoryMessage", PhotonTargets.All, PhotonNetwork.playerName, "and jup!");
                openInventory = !openInventory;

                playerInventory.SetActive(openInventory);
            }
        }
    }

    [PunRPC]
    public void InventoryMessage(string a, string b)
    {
        Debug.Log("InventoryMessage " + a + " " + b);
    }
}
