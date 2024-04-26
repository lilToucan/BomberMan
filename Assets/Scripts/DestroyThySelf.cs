using UnityEngine;

public class DestroyThySelf : MonoBehaviour, IHp
{
	[SerializeField] ActionBool PlayerDeath;
	public void Death()
	{
		gameObject.SetActive(false);
	}

	public void TakeDmg()
	{
		if (PlayerDeath)
		{

			PlayerDeath.onActivation?.Invoke(true);
		}

		Death();
	}
}
