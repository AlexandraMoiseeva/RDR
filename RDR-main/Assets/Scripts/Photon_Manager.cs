using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// using Unity.UI;

public class Photon_Manager : MonoBehaviourPunCallbacks
{
    [SerializeField] private string region;
    [SerializeField] private string NickName;
    [SerializeField] private InputField RoomName;
    public Transform[] SpawnPositions;
    
    [SerializeField] private Transform content;
    [SerializeField] GameObject player_pref;
    
    private List<RoomInfo> allRoomsInfo;
    private GameObject player;
    //TODO - connect spawn points instead of a
    void Start()
    {
        Vector3 a = Vector3.zero;
        PlayerPrefs.DeleteAll();
        PhotonNetwork.ConnectToBestCloudServer();
        PhotonNetwork.ConnectToRegion(region);
        // if (SceneManager.GetActiveScene().name == "map_name")
        // {
        //     player = PhotonNetwork.Instantiate(player_pref.name, a, Quaternion.identity);
        // }
    }
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to" + PhotonNetwork.CloudRegion);
        if (NickName == "")
        {
            PhotonNetwork.NickName = "User";
        }
        else
        {
            PhotonNetwork.NickName = NickName;
        }
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }
    
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("You was disconnected");
    }
    
    // TODO - Connect to the room creation button
    public void CreateRoomButton()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 5;
        PhotonNetwork.JoinOrCreateRoom(RoomName.text, roomOptions, TypedLobby.Default);
        
    }
    
    public override void OnCreatedRoom()
    {
        Debug.Log("You have joined or created a room");
    }
    
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Failed to create a room");
    }
    
    // TODO - A function for ListItem, put in a separate file
    public void JoinToListRoom(Text textName)
    {
        PhotonNetwork.JoinRoom(textName.text);
    }
    
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("game_scene");
    }
    
    // TODO - Connect to the random room selection button
    public void JoinRandRoomButton()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    
    // TODO - Connect to the button to connect to a specific room
    public void JoinButton()
    {
        PhotonNetwork.JoinRoom(RoomName.text);
    }
    // TODO - connect to the exit button
    public void LeaveButton()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.Destroy(player.gameObject);
        PhotonNetwork.LoadLevel("MainMenuScene");
    }
    
    // TODO - Connect when the ListView is written
    // public override void OnRoomListUpdate(List<RoomInfo> roomList)
    // {
    //     foreach (RoomInfo info in roomList)
    //     {
    //         for (int i = 0; i < allRoomsInfo.Count; ++i)
    //         {
    //             if (allRoomsInfo[i].masterClientId == info.masterClientId)
    //                 return;
    //         }
    //         ListItem listItem = Instantiate(itemPrefab, content);
    //         if (listItem != null)
    //         {
    //             listItem.SetInfo(info);
    //             allRoomsInfo.Add(info);
    //         }
    //     }
    // }
}
