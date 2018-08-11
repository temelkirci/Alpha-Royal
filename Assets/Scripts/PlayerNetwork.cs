using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerNetwork : Photon.MonoBehaviour {

    [SerializeField] private Transform playerCamera;
    [SerializeField] private MonoBehaviour[] playerControlScripts;
    //private PhotonView photonView;
    public int playerHealth = 100;
    private Text playerMessage;
    private string gameMessage;  

    private Vector3 targetPosition;
    private Quaternion targetRotation;

    // Use this for initialization
    public void Start ()
    {
        //photonView = GetComponent<PhotonView>();
   
        playerMessage = GameObject.Find("PlayerHealth").GetComponent<Text>();

        PhotonNetwork.sendRate = 60;
        PhotonNetwork.sendRateOnSerialize = 30;

        Initialize();
    }

    void Initialize()
    {
        if(photonView.isMine)
        {
            
        }
        else
        {
            playerCamera.gameObject.SetActive(false);

            foreach(MonoBehaviour m in playerControlScripts)
            {
                m.enabled = false;
            }
        }
    }

    void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("MenuScene");
    }

    private void OnPhotonViewSerialize(PhotonStream stream, PhotonMessageInfo info)
    {
        // send data
        if(stream.isWriting)
        {
            stream.SendNext(playerHealth);

            stream.SendNext(targetPosition);
            stream.SendNext(targetRotation);
        }
        // receive data
        else if(stream.isReading)
        {
            playerHealth = (int)stream.ReceiveNext();

            targetPosition = (Vector3)stream.ReceiveNext();
            targetRotation = (Quaternion)stream.ReceiveNext();
        }
    }

    public void Update()
    {
        if(!photonView.isMine)
        {
            //SyncedMovement();
            
        }

        else if (photonView.isMine)
        {
            //InputMovement();

            if (Input.GetKeyDown(KeyCode.F))
            {
                playerHealth += 5;
                if (playerHealth > 100)
                {
                    playerHealth = 100;
                    // health full
                }
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                playerHealth -= 5;
                if (playerHealth <= 0)
                {
                    playerHealth = 0;
                    // die
                    SceneManager.LoadScene("MenuScene");
                }
              
            }

            playerMessage.text = playerHealth.ToString();
        }
     
    }
}
