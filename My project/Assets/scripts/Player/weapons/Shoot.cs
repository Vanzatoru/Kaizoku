using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class Shoot : MonoBehaviour
{
    public float ClipLenght = 1f;
    public GameObject AudioClip;

    public Transform launchPoint;
    public GameObject projectile;
    public float attackspeed=3f;
    public float launchVelocity = 10f;

    private bool canShoot = true;

    private void Start()
    {
        AudioClip.SetActive(false);
    }
    void Update()
    {
        if (canShoot && Input.GetButtonDown("Fire1"))
        {
           
            StartCoroutine(ShootProjectileAfterDelay());
           
        }

        IEnumerator ShootProjectileAfterDelay()
        {
            canShoot = false;
            AudioClip.SetActive(true);
            
            var _projectile = Instantiate(projectile, launchPoint.position, launchPoint.rotation);
            _projectile.GetComponent<Rigidbody>().velocity = launchPoint.up * launchVelocity;
            yield return new WaitForSeconds(attackspeed);
            canShoot = true;
            yield return new WaitForSeconds(ClipLenght);
            AudioClip.SetActive(false);
        }
    }
}
