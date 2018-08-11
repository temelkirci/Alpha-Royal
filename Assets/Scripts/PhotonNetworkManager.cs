using UnityEngine;
using UnityEngine.UI;

public class PhotonNetworkManager : Photon.MonoBehaviour
{
    [SerializeField] private Text connectText;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject lobbyCamera;

    [SerializeField] private Transform[] spawnPoints;
    const string VERSION = "v0.0.1";
    public string roomName = "Maze";
    public string playerPrefabName = "Player";
   
    private RoomInfo[] roomsList;

    // Use this for initialization
    void Start ()
    {
        PhotonNetwork.ConnectUsingSettings("v0.1");
        Debug.Log("Game Starting");
        
        DontDestroyOnLoad(gameObject);
    }

    public virtual void OnReceivedRoomListUpdate()
    {
        roomsList = PhotonNetwork.GetRoomList();
    }

    public static bool IsConnected
    {
        get
        {
            return PhotonNetwork.offlineMode == false && PhotonNetwork.connectionState == ConnectionState.Connected;
        }
    }

    public void Connect()
    {
        if (PhotonNetwork.connectionState != ConnectionState.Disconnected)
        {
            return;
        }

        try
        {
            PhotonNetwork.ConnectUsingSettings("1.0");
            PhotonNetwork.autoJoinLobby = true;
        }
        catch
        {
            Debug.LogWarning("Couldn't connect to server");
        }
    }

    public virtual void OnJoinedLobby()
    {
        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = true, MaxPlayers = 20
        };

        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
        Debug.Log("OnJoinedLobby");
    }

    public virtual void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
        PhotonNetwork.Instantiate(player.name, spawnPoint.position, spawnPoint.rotation, 0);

        lobbyCamera.SetActive(false);
        Debug.Log(PhotonNetwork.room);

        // Spawn all players
    }

    public virtual void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can't join random room!");
        PhotonNetwork.CreateRoom(null);
    }

    public virtual void OnJConnectedToMaster()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        if(IsConnected)
            connectText.text = PhotonNetwork.connectionStateDetailed.ToString();
	}
}
