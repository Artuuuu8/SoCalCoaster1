
using System.Collections;
using UnityEngine;

public class MultiplierSpawner : MonoBehaviour
{
    public GameObject multiplierPrefab; // Reference multiplier prefab
    public Transform player; // Reference player's transform
    public Transform ground; // Reference ground object

    private void Start()
    {
        // Find the player GameObject in the scene
        player = GameObject.FindWithTag("Player").transform; 

        // Start spawning multipliers
        InvokeRepeating("SpawnMultiplier", 2f, 5f); 
    }

    private void SpawnMultiplier()
{
    Vector3 spawnPosition;

    float yOffset = 0.5f; // Slight offset above ground or player height
    float zOffset = 5f;   // Position of z in front of player
    int attempts = 0;

    do
    {
        // Use the player's Y position as a base, add a small offset
        float randomY = player.position.y + yOffset; 

        // Position aligned horizontally with the player or centered
        float xPosition = player.position.x;
        float zPosition = player.position.z + zOffset;

        spawnPosition = new Vector3(xPosition, randomY, zPosition);
        attempts++;

        if (attempts > 10)
        {
            Debug.LogWarning("Could not find a safe spawn position for multiplier.");
            return;
        }
    }
    while (IsNearObstacle(spawnPosition));

    GameObject multiplier = Instantiate(multiplierPrefab, spawnPosition, Quaternion.identity);
    multiplier.transform.SetParent(ground); // Attach multiplier to ground
}

}
