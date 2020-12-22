using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        this.GetComponent<TerrainCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
