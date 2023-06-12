using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent enemy;
    private Transform player;
    private PlayerStatus playerStatus;
    private EnemyShot enemyShot;
    private spawn Limit;
    private bool dead;

    private void Start()
    {
        dead = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        enemyShot = GetComponent<EnemyShot>();
        Limit = GameObject.FindGameObjectWithTag("Spawn").GetComponent<spawn>();
    }

    private void Update()
    {
        if (!dead)
        {
            enemy.SetDestination(player.position);
            float distance = Vector3.Distance(player.position, transform.position);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CannonBall"))
        {
            dead = true;
            enemyShot.enabled = false;
            playerStatus.score += 100;
            Debug.Log("+100");
            Limit.count=Limit.count-1;
            print(Limit.count);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Crash"))
        {
            dead = true;
            enemyShot.enabled = false;
            Debug.Log("crash");
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStatus.hp = 0;
        }
    }
}







