using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float life = 5f;
    public ParticleSystem explosion;
   


    private void Awake()
    {
      
        Destroy(gameObject, life);
        gameObject.tag = "CannonBall";
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crash"))
        {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            explosion.Play();
            Destroy(gameObject);
          
        }
        if (collision.gameObject.CompareTag("Ocean"))
        {
           
            gameObject.GetComponent<Collider>().enabled = false;
        }
        

        if (collision.gameObject.CompareTag("enemy"))
        {
            
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            explosion.Play();
            Destroy(gameObject);
            
            
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            explosion.Play();
            Destroy(gameObject);
            
        }
    }
}
