using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public float speed = 8;
    public float sprint;

    public float jumpForce = 5;
    public float gravity = -10;
    public Transform groundCheck;
    public LayerMask groundLayer;




    private void Start()
    {
        
    }


    
    void Update()
    {
        //Sprint
        if (Input.GetKey("left shift"))
        {
            float hInput = Input.GetAxis("Horizontal");

            direction.x = hInput * (speed * sprint);

            direction.y += gravity * Time.deltaTime;
        }
        //Jog
        else
        {
            float hInput = Input.GetAxis("Horizontal");

            direction.x = hInput * speed;

            direction.y += gravity * Time.deltaTime;
        }

       
        

         bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f,groundLayer);
         if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpForce;
            }
        }
        
        controller.Move(direction * Time.deltaTime);
    }
}
