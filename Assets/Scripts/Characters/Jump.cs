using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Jump : MonoBehaviourPun
{
    Rigidbody2D rigid;
    [SerializeField] float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }
    }
}
