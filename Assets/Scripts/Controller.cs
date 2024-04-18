using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Controller : MonoBehaviour
{
	public MovementData moveData;
	public BombData bombData;
	public IInput input;
	public Mover mover;
	public Bomber bomber;

	public string MoveAnim;
	public SpriteRenderer myRenderer;
	public Animator myAnim;

	private void Awake()
	{
		input = moveData.isAi ? new AiInput(bombData.chance, moveData) : new PlayerInput();
		mover = new Mover(input, moveData, transform, MoveAnim, myRenderer, myAnim);
		bomber = new Bomber(input);
	}

	private void OnEnable()
	{
		bomber.onDroppingBomb += OnBomb;
	}
	private void OnDisable()
	{
		bomber.onDroppingBomb -= OnBomb;
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