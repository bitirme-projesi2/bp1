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
    Quaternion my_rotation;
    public Vector3 offset;
    public Vector3 targetOffset;
    public float armedRotation;
    Animator playerAnimator;



    public int attackRate=1;
    float nextAttackTime=0;

    void Start()
    {
        my_rotation = this.transform.rotation;
        armedRotation = 0;
        playerAnimator = FindObjectOfType<playerMovement>().GetComponent<Animator>();
        playerAnimator.SetBool("fixDraw",true);
    }

    // Update is called once per frame
    void Update()
    {
        takeAim();
 
    }
    private void LateUpdate()
    {
        this.transform.rotation = my_rotation;
        moveCamera();
    }
    void moveCamera()
    {
        rotateX += Input.GetAxis("Mouse X") * sensivity;
        rotateY -= Input.GetAxis("Mouse Y") * sensivity;
        rotateY = Mathf.Clamp(rotateY, -50, 40);
        transform.LookAt(Target);
        Target.position = Player.position + targetOffset;
        Target.rotation = Quaternion.Euler(rotateY, rotateX, 0);
        Player.rotation = Quaternion.Euler(0, rotateX+armedRotation, 0);
    }


    void takeAim()
    {
        anm = FindObjectOfType<playerMovement>().isArmed;
        if (anm & Input.GetKey(KeyCode.Mouse1))
        {
            targetOffset = new Vector3(2, 3, 0.5f);
            playerAnimator.SetBool("Draw", true);
            if (Time.time >= nextAttackTime)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                    playerAnimator.SetBool("fire", true);
                    nextAttackTime = Time.time + 1;
                    Debug.Log("atacktime " + nextAttackTime);
                    Debug.Log("time  " + Time.time);

                }

            }
        }
        else
        {
            targetOffset = new Vector3(0, 3, 0.5f);
            playerAnimator.SetBool("Draw", false);
            playerAnimator.SetBool("fixDraw", true);
        }
    }


   

}
