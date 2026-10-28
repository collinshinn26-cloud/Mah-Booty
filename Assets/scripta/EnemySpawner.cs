using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject[] enemyPrefabs; // Array to hold different enemy types
    [SerializeField] private float spawnRate = 2.0f;     // Time (in seconds) between spawns
    [SerializeField] private bool canSpawn = true;       // Toggle to easily turn off spawning

    private void Start()
    {
        // Start the repeated spawning routine
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        // Cache the wait time for slight performance optimization
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait; // Wait for the specified interval

            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0) return;

        // Pick a random enemy from our prefab array
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyToSpawn = enemyPrefabs[randomIndex];

        // Instantiate the enemy at the spawner's exact position and rotation
        Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
    }
}
