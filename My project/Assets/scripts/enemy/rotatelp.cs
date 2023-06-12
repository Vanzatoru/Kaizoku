using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatelp : MonoBehaviour
{
    public GameObject targetObject; // Reference to the target object to track

    private void Update()
    {
        if (targetObject != null)
        {
            // Get the direction from the empty object to the target object
            Vector3 targetDirection = targetObject.transform.position - transform.position;

            // Calculate the rotation needed to face the target direction
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

            // Rotate the empty object towards the target direction smoothly
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        }
    }
}
