using System.Collections;
using System.Collections.Generic;
using Photon.Pun; // 유니티용 포톤 컴포넌트
using Photon.Realtime; // 포톤 서비스 관련 라이브러리
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks // Photon.Pun 제공, 콜백(이벤트,메시지) 감지 가능
{
    private string gameVersion = "1"; // 게임 버전

    [SerializeField] Text connectionInfoText;  // 네트워크 정보 표시 텍스트
    [SerializeField] Button joinButton; // 룸 접속 버튼
    
    void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        // 설정 정보로 마스터 서버 접속 시도
        PhotonNetwork.ConnectUsingSettings();

        // 룸 접속 버튼 비활성화(연결 안됨)
        joinButton.interactable = false;
        // 접속 시도 중 텍스트로 표시
        connectionInfoText.text = "마스터 서버에 접속 중...";
    }

    
    void Update()
    {
        
    }

    // 마스터 서버 접속 성공 시 자동 실행
    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        connectionInfoText.text = "온라인 : 마스터 서버와 연결됨!";
    }

    // 마스터 서버 접속 실패 시 자동 실행
    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = "오프라인 : 마스터 서버와 연결되지 않음\n접속 재시도 중...";
        PhotonNetwork.ConnectUsingSettings();
    }

    // 포톤 룸 접속 시도
    public void Connect()
    {
        joinButton.interactable = false;

        if (PhotonNetwork.IsConnected)
        {
            connectionInfoText.text = "룸에 접속...";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            connectionInfoText.text = "오프라인 : 마스터 서버와 연결되지 않음\n접속 재시도 중...";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    // (빈 방이 없어) 랜덤 룸 참가에 실패한 경우 자동 실행
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // 접속 상태 표시
        connectionInfoText.text = "빈 방이 없음, 새로운 방 생성...";
        // 최대 2명을 수용 가능한 빈 방 생성
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
        // 룸 생성 성공시 OnJoinedRoom()으로 이동, 리슨 서버로 생성자가 호스트가 됨
    }

    // 룸에 참가 완료된 경우 자동 실행
    public override void OnJoinedRoom()
    {
        connectionInfoText.text = "방 참가 성공";
        // 호스트와 클라이언트 모두 다음 씬으로 넘어감, 자동 동기화
        PhotonNetwork.LoadLevel("Main");
    }

}
