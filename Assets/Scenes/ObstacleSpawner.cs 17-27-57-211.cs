using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Array to store truck and car prefabs
    public float spawnInterval = 2f;     // Time between spawns
    public float spawnRangeX = 5f;       // Range along X-axis for obstacle spawn positions
    public float spawnZ = 50f;           // Z position where obstacles spawn

    private float timer;
    public Transform player;             // Reference to  player's transform
    public GameObject primaryGround;     

    void Update()
    {
        // Spawn an obstacle at regular intervals
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    
        // Loop through obstacles to check if they're out of view
        foreach (Transform obstacle in GameObject.FindObjectsOfType<Transform>())
        {
            if (obstacle.CompareTag("Obstacle") && obstacle.position.z < player.position.z - 10f)
            {
                Destroy(obstacle.gameObject);
            }
        }
    }

    void SpawnObstacle()
    {
        int index = Random.Range(0, obstaclePrefabs.Length);
        GameObject obstacle = obstaclePrefabs[index];

        // Set random X position and fixed Z position in front of the player
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(spawnPosX, 0.5f, Camera.main.transform.position.z + 15f); 

        // Instantiate and set obstacle as a child of the primary ground object
        GameObject newObstacle = Instantiate(obstacle, spawnPos, Quaternion.identity);
        newObstacle.transform.parent = primaryGround.transform; //set parent
    }
}
