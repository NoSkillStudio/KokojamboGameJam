using Pathfinding;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private Transform[] spawnPoints;
	[SerializeField] private Transform[] targetPoints;
	[SerializeField] private float timeBetweenSpawns;
	private void Start()
	{
		Spawn();
	}

    private Transform GetRandomTransform(Transform[] transformPoints)
    {
        int index;
        index = Random.Range(0, transformPoints.Length);
        return transformPoints[index];
    }

	private void Spawn()
	{
        GameObject enemy = Instantiate(enemyPrefab, GetRandomTransform(spawnPoints).position, Quaternion.identity);
		enemy.GetComponentInParent<AIDestinationSetter>().SetPoints(GetRandomTransform(targetPoints));
		Invoke("Spawn", timeBetweenSpawns);
    }
}
