using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Photon.Pun;
using UnityEngine;

public class CameraSetup : MonoBehaviourPun // Photon View ������Ʈ ��� ����
{
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine) 
        {
            CinemachineVirtualCamera followCam = FindObjectOfType<CinemachineVirtualCamera>();
            // ���� ī�޶� ���� ����� �ڽ� Ʈ���������� ����
            followCam.Follow = transform; // ���� ���
            followCam.LookAt = transform; // �ֽ� ���
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}