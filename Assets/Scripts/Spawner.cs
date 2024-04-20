using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
	public ActionBool enemiesSpawn;
	public Transform enemy;

	private void Awake()
	{
		enemiesSpawn.onActivation += SpawnForTimes;
	}

	private void SpawnForTimes(bool Times)
	{
		Instantiate(enemy, transform.position, Quaternion.identity);
	}
}
