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
    GameObject weaponLocation;
    GameObject weapons;
    public bool isArmed;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anm = GetComponent<Animator>();
        weaponLocation = GameObject.Find("Armament");
        weapons =GameObject.Find("firstBow");

    }
    private void Update()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        armament();
    }
   
    private void FixedUpdate()
    {
        moveCharacter();
        if (input == Vector3.zero)
        {
            anm.SetBool("isHeMoving", false);
        }
    }  
    private void moveCharacter()
    {
        Vector3 inputt = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        Vector3 velocity = speed * direction;

        if (velocity != Vector3.zero)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                runSpeed = Mathf.MoveTowards(speed, runSpeed, 0.05f);
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
        Vector3 moveAmount = velocity * Time.deltaTime;
        transform.Translate(velocity);
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
