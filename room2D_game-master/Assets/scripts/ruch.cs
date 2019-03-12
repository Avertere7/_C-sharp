using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ruch : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public Animator animator;
    public Transform firePoint;


    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
      
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        animator.SetFloat("vel_hor", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("vel_ver", Input.GetAxisRaw("Vertical"));


        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

   

   


}