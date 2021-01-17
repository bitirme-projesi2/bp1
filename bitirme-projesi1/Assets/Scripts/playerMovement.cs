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
    public bool isArmed;
    public GameObject bow;
    Vector3 fixInput;
    public GameObject arrow;
    GameObject arr;
    public Transform fireLocation;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anm = GetComponent<Animator>();
      
    }
    private void Update()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        fixInput= new Vector3(Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Basıldı");
            FireArrow();
        }
    }
    void FireArrow()
    {
        arr = Instantiate(arrow, fireLocation);

    }
    private void FixedUpdate()
    {
        moveCharacter();
        if (input == Vector3.zero)
        {
            anm.SetBool("isHeMoving", false);
            anm.SetBool("isHeRuning", false);
        }
    }  
    private void moveCharacter()
    {
        Vector3 direction;
        if (isArmed) direction = -fixInput.normalized;
        else direction = input.normalized;
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
}
