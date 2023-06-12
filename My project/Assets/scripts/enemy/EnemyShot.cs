using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class EnemyShot : MonoBehaviour
{
    public Transform launchPoint;
    public Transform player;
    public GameObject projectile;
    public float attackspeed = 3f;
    public float launchVelocity = 10f;

    private bool canShoot = true;

    
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (canShoot && distance<100)
        {
            StartCoroutine(ShootProjectileAfterDelay());
        }

        IEnumerator ShootProjectileAfterDelay()
        {
            canShoot = false;
           
            var _projectile = Instantiate(projectile, launchPoint.position, launchPoint.rotation);
            Vector3 launchDirection = launchPoint.up + launchPoint.forward; // Combine up and right directions
            _projectile.GetComponent<Rigidbody>().velocity = launchDirection.normalized * launchVelocity;
          
            yield return new WaitForSeconds(attackspeed);
            canShoot = true;
        }
    }
}

*/
public class EnemyShot : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectile;
    public float attackspeed = 3f;
    public float launchVelocity = 10f;

    private bool canShoot = true;

    private void Update()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            Transform playerTransform = playerObject.transform;

            float distance = Vector3.Distance(playerTransform.position, transform.position);
            if (canShoot && distance < 100f)
            {
                StartCoroutine(ShootProjectileAfterDelay());
            }
        }
    }

    private System.Collections.IEnumerator ShootProjectileAfterDelay()
    {
        canShoot = false;

        var _projectile = Instantiate(projectile, launchPoint.position, launchPoint.rotation);
        Vector3 launchDirection = launchPoint.up + launchPoint.forward; // Combine up and forward directions
        _projectile.GetComponent<Rigidbody>().velocity = launchDirection.normalized * launchVelocity;

        yield return new WaitForSeconds(attackspeed);
        canShoot = true;
    }
}