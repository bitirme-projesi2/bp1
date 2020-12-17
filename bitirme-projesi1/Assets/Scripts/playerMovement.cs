using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 4f;
    Vector3 input;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        
    }
    private void FixedUpdate()
    {
        moveCharacter();
    }    
    private void moveCharacter()
    {
        Vector3 inputt = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        Vector3 velocity = speed * direction;
        Vector3 moveAmount = velocity * Time.deltaTime;
        // rb.MovePosition(transform.position + moveAmount);
        transform.Translate(velocity);
    }
}
