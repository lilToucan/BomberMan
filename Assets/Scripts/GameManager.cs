using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public ActionBool PlayerDeath;
	public ActionBool EnemyDeath;
	public ActionBool EnemySpawn;


	[SerializeField] int LoseSceneNum;
	[SerializeField] int WinSceneNum;

	int EnemiesKilled = 0;
	public int EnemiesToKill = 0;

	private void OnEnable()
	{
		PlayerDeath.onActivation += Lose;
		EnemyDeath.onActivation += EnemyKilled;
		EnemySpawn.onActivation += OnEnemySpawn;
		EnemySpawn.onActivation?.Invoke(true);
	}


	void Lose(bool x)
	{
		SceneManager.LoadScene(LoseSceneNum);
	}

	void OnEnemySpawn(bool x)
	{
		EnemiesToKill++;
	}

	void EnemyKilled(bool x)
	{
		EnemiesKilled++;
		if (EnemiesKilled >= EnemiesToKill)
		{
			Win();
		}
	}

	void Win()
	{
		SceneManager.LoadScene(WinSceneNum);
	}
}