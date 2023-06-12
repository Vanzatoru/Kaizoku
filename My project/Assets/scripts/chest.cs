using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public Transform orientation;
    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.position = orientation.position;
    }
}
