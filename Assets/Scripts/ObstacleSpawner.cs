using UnityEngine;

public class ObstacleSqawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnInterval = 2f;
    
    [SerializeField] private float minY = -5f;
    [SerializeField] private float maxY = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        // InvokeRepeating {methodName, delayBeforeStart, repeatRate}
        InvokeRepeating(nameof(SpawnObstacle), 0F, spawnInterval);
    }

    private void SpawnObstacle()
    {
        Vector3 spawnPosition = new Vector3(
            transform.position.x,
            Random.Range(minY, maxY),
            transform.position.z
        );
        
        Instantiate(obstaclePrefab, spawnPosition, transform.rotation, transform);
    }
}
