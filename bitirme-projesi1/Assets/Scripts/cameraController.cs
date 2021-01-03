using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float sensivity = 1;
    public float rotateX = 0;
    public float rotateY = 0;
    public Transform Target, Player;
    bool anm;
    public Vector3 offset;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //takeAim();
    }
    private void LateUpdate()
    {
        moveCamera();
    }
    void moveCamera()
    {
        rotateX += Input.GetAxis("Mouse X") * sensivity;
        rotateY -= Input.GetAxis("Mouse Y") * sensivity;
        rotateY = Mathf.Clamp(rotateY, -35, 60);
        transform.LookAt(Target);


        
        Target.rotation = Quaternion.Euler(rotateY, rotateX, 0);
        Player.rotation = Quaternion.Euler(0, rotateX, 0);
    }


    void takeAim()
    {
        anm = FindObjectOfType<playerMovement>().isArmed;
        if (anm && Input.GetKey(KeyCode.Mouse1))
        {
            Target.transform.localPosition = offset;
               
        }
        else
        {
            Target.transform.localPosition = new Vector3(0,4.04f,0);
        }
    }
}
