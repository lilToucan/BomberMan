using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	static public ActionData<bool> PlayerDeath;
	static public ActionData<bool> EnemyDeath;
	static public ActionData<int> EnemySpawn;


	[SerializeField] int LoseSceneNum;
	[SerializeField] int WinSceneNum;

	int EnemiesKilled = 0;
	public int EnemiesToKill = 0;

	private void OnEnable()
	{
		PlayerDeath.onActivation += Lose;
		EnemyDeath.onActivation += EnemyKilled;
		EnemySpawn.onActivation?.Invoke(EnemiesToKill);
	}

	void Lose(bool x)
	{
		SceneManager.LoadScene(LoseSceneNum);
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