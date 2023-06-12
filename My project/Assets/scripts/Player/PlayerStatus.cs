using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public Slider slider;
    public int hp;
    public int score;


    private void Start()
    {
        slider.maxValue = hp;
        score= 0;
    }
    void Update()
    {
        slider.value = hp;

    }

}
