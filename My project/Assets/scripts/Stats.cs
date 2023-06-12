using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float hp=1000;
    public float armor = 30;
    public ParticleSystem explosion;

    private void Awake()
    {
       // explosion.Pause();
    }
    void Update()
    {

        if (hp <= 0)
        {
           // explosion.Play();
           //  Destroy(gameObject);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CannonBall"))
        {
            hp =hp-(100 - armor);
        }
    }
}
