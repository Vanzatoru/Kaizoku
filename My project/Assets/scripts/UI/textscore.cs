using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class textscore : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public PlayerStatus playerStatus;
    

    void Update()
    {
       
        Text.text = "Score: "+playerStatus.score ;
    }
}
