using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armamentController : MonoBehaviour
{


    public Transform player;
    public GameObject weapon;
    GameObject scaleWeapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void armament()
    {
        scaleWeapon =Instantiate(weapon, player);
        scaleWeapon.transform.localPosition = new Vector3(-0.14f, 0, -0.22f);
        scaleWeapon.transform.rotation = new Quaternion(0, -73.28f, 0,0);
        scaleWeapon.transform.GetChild(1).localScale = new Vector3(0.4f,0.9f,0.75f);
            
    }
}
