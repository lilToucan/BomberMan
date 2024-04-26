using UnityEngine;
public class Spawner : MonoBehaviour
{
	public Transform enemy;

	private void Start()
	{
		Spawn();
	}

	private void Spawn()
	{
		GameManager.EnemySpawn?.Invoke();
		Instantiate(enemy, transform.position, Quaternion.identity);
	}
}
