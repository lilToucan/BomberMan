
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public MovementData moveData;
	public BombData bombData;
	public Iinput input;
	public Mover mover;
	public Bomber bomber;



	private void Start()
	{
		input = moveData.isAi ? new AiInput() : new PlayerInput();
		mover = new Mover(input, moveData, transform);
		bomber = new Bomber(input);
	}

	private void Update()
	{
		input.MoveInput();
		input.BombInput();

		mover.Tick();
		bomber.Tick();
	}

	void OnBomb()
	{
		Instantiate(bombData.bomb, transform.position, quaternion.identity);
		StartCoroutine(BombCooldown());
	}


	IEnumerator BombCooldown()
	{
		bomber.canBomb = false;
		yield return new WaitForSeconds(bombData.cooldown);
		bomber.canBomb = true;
	}

}