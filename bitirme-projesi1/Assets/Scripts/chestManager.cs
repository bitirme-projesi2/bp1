using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestManager : MonoBehaviour
{
    public ParticleSystem prt,prtPrev;
    bool isTrigger = false;
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
                transform.Rotate(new Vector3(-30,0,0));
                prtPrev.Stop();
                prt.Play();
                FindObjectOfType<armamentController>().armament();

            }
        }
    }
}
