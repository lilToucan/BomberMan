using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public ActionBool PlayerDeath; // really just to test if it could be done 
	public static Action EnemyDeath;
	public static Action EnemySpawn;


	[SerializeField] int LoseSceneNum;
	[SerializeField] int WinSceneNum;

	int EnemiesKilled = 0;
	public int EnemiesToKill = 0;

	private void OnEnable()
	{
		PlayerDeath.onActivation += Lose;
		EnemyDeath += EnemyKilled;
		EnemySpawn += OnEnemySpawn;
	}


	void Lose(bool x)
	{
		SceneManager.LoadScene(LoseSceneNum);
	}

	void OnEnemySpawn()
	{
		EnemiesToKill++;
	}

	void EnemyKilled()
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