using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armamentController : MonoBehaviour
{


    public Transform player;
    public GameObject weapon;
    GameObject scaleWeapon;
    public Transform hand;
    bool isArmed;
    public Animator anm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isArmed) equipBow();
            else disarm();
            
        }
    }

    public void armament()
    {
        scaleWeapon =Instantiate(weapon, player);
        scaleWeapon.transform.localPosition = new Vector3(-0.14f, 0, -0.22f);
        scaleWeapon.transform.localRotation = new Quaternion(0, -73.28f, 0,500);
        scaleWeapon.transform.GetChild(1).localScale = new Vector3(0.4f,0.9f,0.75f);
        Debug.Log("Çalışıyor");
            
    }

    void equipBow()
    {
        anm.SetBool("isArmed", true);
        scaleWeapon.transform.SetParent(hand);
        isArmed = true;
        Invoke("setAnm", 0.75f);
        scaleWeapon.transform.localPosition = new Vector3(-0.01f, 0.17f, 0.06f);
        scaleWeapon.transform.rotation = new Quaternion(-52.39f, 151.47f, -56.86f, 0);
       

      
    }
    void disarm()
    {
        scaleWeapon.transform.localPosition = new Vector3(-0.14f, 0, -0.22f);
        scaleWeapon.transform.rotation = new Quaternion(0, -73.28f, 0, 0);
        scaleWeapon.transform.GetChild(1).localScale = new Vector3(0.4f, 0.9f, 0.75f);
        isArmed = false;
    }
    void setAnm()
    {

        anm.SetBool("isEquip", true);
    }
}
