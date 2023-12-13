using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

// using Unity.UI;

public class Photon_Manager : MonoBehaviourPunCallbacks
{
    [SerializeField] private string region;
    private string NickName;
    [SerializeField]
    private TMPro.TMP_Dropdown roomListDD;
    [SerializeField] private TMP_InputField RoomName;
    public Transform[] SpawnPositions;
    
    //[SerializeField] private Transform content;
    //[SerializeField] GameObject player_pref;
    
    private List<RoomInfo> allRoomsInfo;
    private GameObject player;
    //TODO - connect spawn points instead of a
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        NickName = DataManager.displayName;
        Vector3 a = Vector3.zero;
        PlayerPrefs.DeleteAll();
        //PhotonNetwork.ConnectToBestCloudServer();
        //PhotonNetwork.ConnectToRegion(region);
        // if (SceneManager.GetActiveScene().name == "map_name")
        // {
        //     player = PhotonNetwork.Instantiate(player_pref.name, a, Quaternion.identity);
        // }
    }

    public void RoomListUpdate(List<RoomInfo> roomList)
    {

        for (int i = 0; i < roomList.Count; i++)
        {
            TMPro.TMP_Dropdown.OptionData option = new TMPro.TMP_Dropdown.OptionData();
            option.text = roomList[i].Name;
            roomListDD.options.Add(option);
        }
    }

    public void OnConnectedToMaster()
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
    
    public void OnDisconnected(DisconnectCause cause)
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
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 5 };
        //PhotonNetwork.JoinOrCreateRoom(RoomName.text, roomOptions, TypedLobby.Default);
        if (PhotonNetwork.CreateRoom(RoomName.text, roomOptions, TypedLobby.Default))
            print("Create room successfully");
        else
            print("Create room failed");
        RoomListUpdate(allRoomsInfo);
    }

    public void OnClick_CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4 };
        if (PhotonNetwork.CreateRoom(RoomName.text, roomOptions, TypedLobby.Default))
        {
            print("Create room successfully");
        }
        else
        {
            print("Create room failed");
        }
    }
    
    public void OnCreatedRoom()
    {
        Debug.Log("You have joined or created a room");
    }
    
    public void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Failed to create a room");
    }
    
    // TODO - A function for ListItem, put in a separate file
    public void JoinToListRoom(Text textName)
    {
        PhotonNetwork.JoinRoom(textName.text);
    }
    
    public void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("TestMap");
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

    public void OnLeftRoom()
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
