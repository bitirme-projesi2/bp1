using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    bool isItWalk = true;
    bool flag = true;
    public float speed = 4f;
    public float turnSpeed = 10F;
    int turn = 180;
    Vector3 input;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        input = new Vector3(0, 0, 1);
    }
    
    private void FixedUpdate()
    {
        if (isItWalk) moveCharacter();
        else
        {
            anim.SetInteger("moving", 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, turn, 0), Time.deltaTime * turnSpeed);
            if (transform.rotation == Quaternion.Euler(transform.rotation.x, turn, transform.rotation.z)) {
                isItWalk = true;
                if (flag)
                {
                    turn = 0;
                    flag = !flag;
                }
                else
                {
                    turn = 180;
                    flag = !flag;
                }
                
            }
        }
    }
    private void moveCharacter()
    {
     
        anim.SetInteger("moving", 1);
        Vector3 direction = input.normalized;
        Vector3 velocity = speed * direction;
        Vector3 moveAmount = velocity * Time.deltaTime;
        transform.Translate(velocity*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water Well")
        {
            isItWalk = false;
         

        }
        if (other.tag == "Home")
        {
         
            isItWalk = false;
        
        }
    }
}

