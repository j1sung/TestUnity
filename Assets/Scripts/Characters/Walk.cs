using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Walk : MonoBehaviourPun
{
    Rigidbody2D rigid;
    [SerializeField] float speed;
    Vector3 originalScale;
    Animator animator;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        animator = GetComponent<Animator>();
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
            animator.SetBool("IsRunning", true);
            transform.localScale = new Vector3(-originalScale.x * h, originalScale.y, originalScale.z);
        }
        else 
        {
            animator.SetBool("IsRunning", false);
        }

    }
    private void FixedUpdate()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        float h = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(h * speed, rigid.velocity.y);
    }

}
