using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armamentController : MonoBehaviour
{
    public GameObject weapon;
    GameObject scaleWeapon;

    public Transform Target;
    public Transform player;
    public Transform hand;
  
    public Animator anm;
    bool isArmed;

    void Start()
    {
        anm.SetBool("isUnEquip", true);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) SwitchEquipmentState();
        if (isArmed && scaleWeapon !=null)
        {
            scaleWeapon.transform.position = hand.position;
            scaleWeapon.transform.rotation = hand.rotation;    
        }
        else if(scaleWeapon !=null)
        {
            scaleWeapon.transform.position = player.position;
            scaleWeapon.transform.rotation = player.rotation;
        }
   
    }

    private void Equip()
    {
        anm.SetBool("isArmed", true);
        isArmed = true;
        armedWalk();
    }

    void unEquip()
    {
        
        isArmed = false;
        unArmed();
    }
    void isArmedFix()
    {
        anm.SetBool("isArmed", false);
    }
    void SwitchEquipmentState()
    {
        anm.SetBool("isEquip",!anm.GetBool("isEquip"));
        anm.SetBool("isUnEquip", !anm.GetBool("isUnEquip"));
        
           
    }
    public void armament()
    {
        scaleWeapon =Instantiate(weapon, player);
        scaleWeapon.transform.GetChild(1).localScale = new Vector3(0.4f,0.9f,0.75f);          
    }
    public void armedWalk()
    {
        FindObjectOfType<cameraController>().armedRotation = 60;
        FindObjectOfType<playerMovement>().isArmed = true;
    }
    public void unArmed()
    {
        FindObjectOfType<cameraController>().armedRotation = 0;
        FindObjectOfType<playerMovement>().isArmed = false;
    }
    void fixDraw()
    {
       anm.SetBool("fixDraw", false);
        anm.SetBool("fire", false);
    }

}
