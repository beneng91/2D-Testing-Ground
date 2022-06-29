using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public float speed = 8;
    public float sprintSpeed;

        
    public float jumpForce = 2.5f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public EnemyMovement enemyDamage;


    public Animator animator;

    public Transform model;

    public Transform targetTransform;
    private Camera mainCamera;
    public LayerMask mouseAimMask;
    public GameObject fireballPrefab;


    private void Start()
    {
        mainCamera = Camera.main;

    }



    void Update()
    {
        //Working on mouse aiming
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mouseAimMask))
        {
            targetTransform.position = hit.point;
        }

        /*if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            var fb = Instantiate(fireballPrefab);
            fb.transform.position = targetTransform.position;
            var shot = fb.GetComponent<FireBall>();
            
        }*/
        

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

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }






        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);
         if (isGrounded)
        {
            
            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded == true)
                {
                    Jump();
                }
                
            }

            if (isGrounded && direction.y < 0)
            {
                direction.y = -4f;
            }

            
        }

        
        //Attack motion stop
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))        
            return;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
            return;



            controller.Move(direction * Time.deltaTime);
    }

    


     void Jog()
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

     void Sprint()
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

     void Jump()
    {
        //direction.y = jumpForce;
        direction.y = Mathf.Sqrt(jumpForce * -2f * gravity);
    }


}
