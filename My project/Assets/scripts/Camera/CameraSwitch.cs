using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cam1;
    public GameObject cam2;

    private void Start()
    {
        cam2.SetActive(false);
        cam1.SetActive(true);
    }
    void Update()
    {
        if (Input.GetButtonDown("2key"))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            print(1);
        }
        if (Input.GetButtonDown("1key"))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            print(2);
        }
    }
}
