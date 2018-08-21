using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera Camera;
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;
    public Animator animator;
    
       
    void Start()
    {


    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


       Vector3 movement = new Vector3(0f, 0f, vertical);
       Vector3 rotation = new Vector3(0f, horizontal, 0f);

       transform.Translate(movement * Time.deltaTime * moveSpeed);
       transform.Rotate(rotation * Time.deltaTime * rotationSpeed);
        animator.SetFloat("Forward", vertical);
        animator.SetFloat("Turn", horizontal);
        



        //  animator.SetFloat("Strafe", horizontal);     Neil come on ou .
    }
}

   
