using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Photon.Pun;
using UnityEngine;

public class CameraSetup : MonoBehaviourPun // Photon View 컴포넌트 즉시 접근
{
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine) 
        {
            CinemachineVirtualCamera followCam = FindObjectOfType<CinemachineVirtualCamera>();
            // 가상 카메라 추적 대상을 자신 트랜스폼으로 변경
            followCam.Follow = transform; // 추적 대상
            followCam.LookAt = transform; // 주시 대상
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
