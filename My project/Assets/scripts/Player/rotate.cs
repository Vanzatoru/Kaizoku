using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float rotationSpeed = 100;

    private float initalRot;


    private void Start()
    {
        initalRot = rotationSpeed;
    }

    void Update()
    {
        Rotate();

        Shift();
        
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime, Space.Self);
        }

    }

    private void Shift()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && rotationSpeed == initalRot)
        {
            rotationSpeed = rotationSpeed / 2;

        }

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            rotationSpeed = initalRot;

        }
    }


}
