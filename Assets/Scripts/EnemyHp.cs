using UnityEngine;

public class EnemyHp : MonoBehaviour, IHp
{
	public void Death()
	{
		Destroy(gameObject);
	}

	public void TakeDmg()
	{
		GameManager.EnemyDeath?.Invoke();
		Death();
	}
}