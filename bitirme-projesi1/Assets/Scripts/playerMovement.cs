using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Animator anm;
    public bool key = true;
    private Rigidbody rb;
    public float speed = 4f;
    public float runSpeed = 0.5f;
    Vector3 input;
    public bool isArmed=true;
    public GameObject bow;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anm = GetComponent<Animator>();
      
    }
    private void Update()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        // armament();
        bow.transform.localScale = new Vector3(0.4f, 0.9f, 0.75f);
    }
   
    private void FixedUpdate()
    {
        moveCharacter();
        isArmed = true;
        if (input == Vector3.zero)
        {
            anm.SetBool("isHeMoving", false);
            anm.SetBool("isHeRuning", false);
        }
    }  
    private void moveCharacter()
    { 
        Vector3 direction = input.normalized;
        Vector3 velocity = speed * direction;

        if (velocity != Vector3.zero)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
          
                velocity = runSpeed * direction;
                anm.SetBool("isHeMoving", false);
                anm.SetBool("isHeRuning", true);
            }
            else
            {
                anm.SetBool("isHeRuning", false);
                anm.SetBool("isHeMoving", true);
            }
        }
        transform.Translate(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.C)) Crouch();
     

       
    }

    void Crouch()
    {
        anm.SetBool("isHeMoving", false);
        anm.SetBool("isHeCrouch", !anm.GetBool("isHeCrouch"));
    }



    void armament()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anm.SetBool("takeweapon", true);
            anm.SetBool("isArmed", true);
            isArmed = anm.GetBool("isArmed");
            Invoke("disarm",1);
        }
    }
    void disarm()
    {
        anm.SetBool("takeweapon", false);
      
    }

   
}
