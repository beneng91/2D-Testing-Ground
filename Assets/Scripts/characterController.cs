using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public float speed = 8;
    public float sprintSpeed;
    public int attackStrength;

    public float attackCombo = 1;
    public float attackReset;

    public float jumpForce = 5;
    public float gravity = -10;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public EnemyMovement enemyDamage;


    public Animator animator;

    public Transform model;


    private void Start()
    {
        enemyDamage = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMovement>();

    }



    void Update()
    {
        

        //Sprint

        if (Input.GetKey("left shift"))
        {
            Sprint();
        }
        
        //Jog

        else
        {
            Jog();
        }

       
        
        

         bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f,groundLayer);
        animator.SetBool("isGrounded", isGrounded);
         if (isGrounded)
        {
            
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }




        }

         //Attack motion stop
         if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        
            return;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))

            return;



            controller.Move(direction * Time.deltaTime);
    }

    


    private void Jog()
    {
        float hInput = Input.GetAxis("Horizontal");

        direction.x = hInput * speed;

        direction.y += gravity * Time.deltaTime;

        animator.SetFloat("speed", Mathf.Abs(hInput));

        if (hInput != 0)
        {
            Quaternion modelRotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
            model.rotation = modelRotation;
        }
    }

    private void Sprint()
    {
        float hInput = Input.GetAxis("Horizontal");

        direction.x = hInput * (speed * sprintSpeed);

        direction.y += gravity * Time.deltaTime;

        animator.SetFloat("speed", Mathf.Abs(hInput));

        if (hInput != 0)
        {
            Quaternion modelRotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
            model.rotation = modelRotation;
        }
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }


}
