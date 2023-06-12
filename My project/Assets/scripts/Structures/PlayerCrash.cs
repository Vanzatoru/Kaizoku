using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrash : MonoBehaviour
{
    GameObject player;
    //rotate rotate;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        //rotate=GameObject.FindWithTag("Player").GetComponent<rotate>();
    }

    
    private void OnCollisionEnter(Collision collision)
    {

        
        if (collision.collider.CompareTag("Player"))
        {
            player.GetComponent<Rigidbody>().isKinematic = true;
            player.GetComponent<rotate>().gameObject.SetActive(false);
            print("Crash");
        }
    }

}
