using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTrajectory : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float scrollSpeed = 10f;
    void Update()
    {
        //print(transform.rotation.eulerAngles.z);
        if (transform.rotation.eulerAngles.z >=50 && transform.rotation.eulerAngles.z <= 110) {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            transform.Rotate(Vector3.forward * scroll * scrollSpeed * Time.deltaTime, Space.Self);
        }
        if (transform.rotation.eulerAngles.z < 50){
            Vector3 newRotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 50f);
            transform.rotation = Quaternion.Euler(newRotation);
        }
        if (transform.rotation.eulerAngles.z > 110){
            Vector3 newRotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 110f);
            transform.rotation = Quaternion.Euler(newRotation);
        }

    }
}
