using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Controller : MonoBehaviour
{
	public MovementData moveData;
	public BombData bombData;
	public IInput input;
	public Mover mover;

	public string MoveAnim;
	public SpriteRenderer myRenderer;
	public Animator myAnim;

	private void Awake()
	{
		input = moveData.isAi ? new AiInput(bombData.chance) : new PlayerInput();
		input.canBomb = true;
		mover = new Mover(input, moveData, transform, MoveAnim, myRenderer, myAnim);
	}


	private void Update()
	{
		input.MoveInput();
		input.BombInput(this);

		mover.Tick();
	}

	public void OnBomb()
	{
		if (input.canBomb)
		{
			Instantiate(bombData.bomb, transform.position, quaternion.identity);
			StartCoroutine(BombCooldown());
		}
	}

	IEnumerator BombCooldown()
	{
		input.canBomb = false;
		yield return new WaitForSeconds(bombData.cooldown);
		input.canBomb = true;
	}

}