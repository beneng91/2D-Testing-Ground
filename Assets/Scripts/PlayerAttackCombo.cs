using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCombo : MonoBehaviour
{
    public Animator animator;
    public Transform groundCheck;
    public LayerMask groundLayer;


    public bool firstButtonPressed;
    public float timeOfFirstButton;
    public bool reset;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f,groundLayer);
            animator.SetBool("isGrounded", isGrounded);

            if (isGrounded)
            {

                //Attack
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (!firstButtonPressed)
                    {
                        Debug.Log("First Attack");
                        animator.SetTrigger("swordAttack");
                        firstButtonPressed = true;
                        timeOfFirstButton = Time.time;
                    }
                    else if (firstButtonPressed)
                    {
                        if (Time.time - timeOfFirstButton < 1f)
                        {
                            animator.SetTrigger("swordAttack2");
                            Debug.Log("Second Attack");

                            timeOfFirstButton = 0;                       
                        }

                        else
                        {
                            animator.SetTrigger("swordAttack");
                            Debug.Log("Too late");
                        }

                        reset = true;

                    }

                    if (reset)
                    {
                        firstButtonPressed = false;
                        reset = false;
                    }


                }

            }

    }

}
