using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject UI;
    public GameObject UI2;
    void Start()
    {
        Time.timeScale = 0f;
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1f;
            UI.SetActive(true);
            UI2.SetActive(false);
        }
    }
}
