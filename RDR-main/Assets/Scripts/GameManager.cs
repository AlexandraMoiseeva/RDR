using System;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    [SerializeField] Text textLastMessage;
    [SerializeField] private InputField textMessageField;
    private PhotonView PhotonView;

    private void Start()
    {
        PhotonView = GetComponent<PhotonView>();
    }

    public void SendButton()
    {
        PhotonView.RPC("Send_Data", RpcTarget.AllBuffered, PhotonNetwork.NickName,  textMessageField.text);
    }
    
    [PunRPC]
    private void Send_Data(string nick, string message)
    {
        textLastMessage.text = nick + ":" + message;
    }
}