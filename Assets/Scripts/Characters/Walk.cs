using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Walk : MonoBehaviourPun
{
    Rigidbody2D rigid;
    [SerializeField] float speed;
    Vector3 originalScale;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (!photonView.IsMine) 
        {
            return;
        }
        float h = Input.GetAxisRaw("Horizontal");
        if (h != 0)
        {
            transform.localScale = new Vector3(-originalScale.x*h, originalScale.y, originalScale.z);
        }

    }
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(h * speed, rigid.velocity.y);
    }

}
