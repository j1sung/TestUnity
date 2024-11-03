using System.Collections;
using System.Collections.Generic;
using Photon.Pun; // ����Ƽ�� ���� ������Ʈ
using Photon.Realtime; // ���� ���� ���� ���̺귯��
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks // Photon.Pun ����, �ݹ�(�̺�Ʈ,�޽���) ���� ����
{
    private string gameVersion = "1"; // ���� ����

    [SerializeField] Text connectionInfoText;  // ��Ʈ��ũ ���� ǥ�� �ؽ�Ʈ
    [SerializeField] Button joinButton; // �� ���� ��ư
    
    void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        // ���� ������ ������ ���� ���� �õ�
        PhotonNetwork.ConnectUsingSettings();

        // �� ���� ��ư ��Ȱ��ȭ(���� �ȵ�)
        joinButton.interactable = false;
        // ���� �õ� �� �ؽ�Ʈ�� ǥ��
        connectionInfoText.text = "������ ������ ���� ��...";
    }

    
    void Update()
    {
        
    }

    // ������ ���� ���� ���� �� �ڵ� ����
    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        connectionInfoText.text = "�¶��� : ������ ������ �����!";
    }

    // ������ ���� ���� ���� �� �ڵ� ����
    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = "�������� : ������ ������ ������� ����\n���� ��õ� ��...";
        PhotonNetwork.ConnectUsingSettings();
    }

    // ���� �� ���� �õ�
    public void Connect()
    {
        joinButton.interactable = false;

        if (PhotonNetwork.IsConnected)
        {
            connectionInfoText.text = "�뿡 ����...";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            connectionInfoText.text = "�������� : ������ ������ ������� ����\n���� ��õ� ��...";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    // (�� ���� ����) ���� �� ������ ������ ��� �ڵ� ����
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // ���� ���� ǥ��
        connectionInfoText.text = "�� ���� ����, ���ο� �� ����...";
        // �ִ� 2���� ���� ������ �� �� ����
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
        // �� ���� ������ OnJoinedRoom()���� �̵�, ���� ������ �����ڰ� ȣ��Ʈ�� ��
    }

    // �뿡 ���� �Ϸ�� ��� �ڵ� ����
    public override void OnJoinedRoom()
    {
        connectionInfoText.text = "�� ���� ����";
        // ȣ��Ʈ�� Ŭ���̾�Ʈ ��� ���� ������ �Ѿ, �ڵ� ����ȭ
        PhotonNetwork.LoadLevel("Main");
    }

}
