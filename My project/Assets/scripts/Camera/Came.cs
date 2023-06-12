using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Came : MonoBehaviour
{

    public Transform cameraPosition1;
   
    private void Update()
    {
       
       transform.position = cameraPosition1.position;
        

    }
}
