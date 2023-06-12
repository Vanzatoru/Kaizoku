using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public int limit;
    public int count;

    public GameObject objectPrefab;
    public Transform[] spawnPoints;
    public float spawnDelay = 3f; // Delay between spawns
    private bool startrefill;

    private void Start()
    {
        limit = 5;
        count = 0;
        startrefill = false;
        StartCoroutine(SpawnObjectsWithDelay());
    }

    private IEnumerator SpawnObjectsWithDelay()
    {
        while (count < limit)
        {
            SpawnObject();

            yield return new WaitForSeconds(spawnDelay);

            count++;
        }
    }

    private void Update()
    {
        if(count==5)
            startrefill = true;
        while (count < limit && startrefill)
        {
            SpawnObject();
            count++;
        }
    }
    private void SpawnObject()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        GameObject newObject = Instantiate(objectPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }
}
