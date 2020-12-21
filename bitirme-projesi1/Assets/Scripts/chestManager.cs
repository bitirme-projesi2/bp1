using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestManager : MonoBehaviour
{
    bool isTrigger = false;
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        isTrigger = true;
        
    }
    private void OnTriggerExit(Collider other)
    {
        isTrigger = false;        
    }

    private void Update()
    {
        if (isTrigger) {
            if (Input.GetKeyDown(KeyCode.E) )
            {
                Debug.Log("Chess opening");
                transform.Rotate(new Vector3(-30,0,0));
            }
        }
    }
}
