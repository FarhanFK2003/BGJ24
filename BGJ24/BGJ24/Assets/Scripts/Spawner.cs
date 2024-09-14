using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;    // The object to spawn
    public float spawnInterval = 5f;    // Time between spawns in seconds
    public Vector3 spawnOffset;         // Offset from the spawner's position for the spawn

    private void Start()
    {
        // Start the spawn coroutine
        StartCoroutine(SpawnObjectCoroutine());
    }

    private IEnumerator SpawnObjectCoroutine()
    {
        while (true) // Infinite loop to keep spawning
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(spawnInterval);

            // Calculate the spawn position with the offset
            Vector3 spawnPosition = transform.position + spawnOffset + new Vector3(Random.Range(-10,10),0, Random.Range(-10, 10));

            // Instantiate the object at the calculated position
            if (objectToSpawn != null)
            {
                Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                Debug.Log(objectToSpawn.name + " spawned at position: " + spawnPosition);
            }
            else
            {
                Debug.LogWarning("Object to spawn is not assigned.");
            }
        }
    }
}
