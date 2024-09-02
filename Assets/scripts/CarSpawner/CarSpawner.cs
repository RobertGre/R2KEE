using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject car;
    public Transform spawnPoint; // Reference to the spawn point GameObject

    public float timeToSpawn;
    private float currentTimeToSpawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimeToSpawn > 0)
        {
            currentTimeToSpawn -= Time.deltaTime;
        }
        else
        {
            SpawnObject();
            currentTimeToSpawn = timeToSpawn;
        }
    }

    public void SpawnObject()
    {
        // Instantiate the car at the specified spawn point position and rotation
        Instantiate(car, spawnPoint.position, spawnPoint.rotation);
    }
}


