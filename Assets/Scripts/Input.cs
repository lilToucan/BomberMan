using System;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public interface IHp
{
	public void TakeDmg();
	void Death();
}
public class Mover
{
	private readonly IInput input;
	private readonly MovementData moveData;
	private readonly Transform transformToMove;
	readonly string moveAnim;
	readonly SpriteRenderer renderer;
	readonly Animator anim;

	public Mover(IInput input, MovementData moveData, Transform transformToMove, string moveAnim, SpriteRenderer renderer, Animator anim)
	{
		this.input = input;
		this.moveData = moveData;
		this.transformToMove = transformToMove;
		this.moveAnim = moveAnim;
		this.renderer = renderer;
		this.anim = anim;
		input.timer = 0;
		input.moveData = moveData;

	}

	public void Tick()
	{
		Vector2 pos = Vector2.zero;
		if (input.moveX != 0)
		{
			renderer.flipX = input.moveX <= 0;
			anim.CrossFade(moveAnim, 0.2f);

			if (Physics2D.Raycast(transformToMove.position, Vector2.right * input.moveX, 1, moveData.wallsLayer) == false)
			{

				pos = Vector2.right * input.moveX;

			}
		}
		else if (input.moveY != 0)
		{
			anim.CrossFade(moveAnim, 0.2f);

			if (Physics2D.Raycast(transformToMove.position, Vector2.up * input.moveY, 1, moveData.wallsLayer) == false)
			{

				pos = Vector2.up * input.moveY;
			}

		}
		transformToMove.Translate(pos);
		// input.moveX = 0;
		// input.moveY = 0;
	}

}

public class Bomber
{
	public IInput input;
	public bool canBomb;

	public Bomber(IInput input)
	{
		this.input = input;
	}
}
public interface IInput
{
	public float moveX { get; set; }
	public float moveY { get; set; }
	public bool canBomb { get; set; }
	public float timer { get; set; }
	public MovementData moveData { get; set; }


	public void MoveInput();
	public void BombInput(Controller controller);
}

public class AiInput : IInput
{
	public float moveX { get; set; }
	public float moveY { get; set; }
	public float bombChance;
	public bool canBomb { get; set; }
	public float timer { get; set; }
	public MovementData moveData { get; set; }


	public AiInput(float bombChance)
	{
		this.bombChance = bombChance;
	}

	public void BombInput(Controller controller)
	{
		float rand = Random.Range(0, 1);
		if (rand <= bombChance)
		{
			controller.OnBomb();
		}
	}

	public void MoveInput()
	{
		if (timer < moveData.cooldown)
		{
			timer += Time.deltaTime;
			moveX = 0;
			moveY = 0;
		}
		else
		{
			timer = 0;
			moveX = Random.Range(-1, 2);
			moveY = Random.Range(-1, 2);
		}

	}
}

public class PlayerInput : IInput
{
	public float moveX { get; set; }
	public float moveY { get; set; }
	public bool canBomb { get; set; }
	public float timer { get; set; }
	public MovementData moveData { get; set; }

	public float inputTimer = 0, inputDur = 0.04f;


	public void BombInput(Controller controller)
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			controller.OnBomb();
		}
	}

	public void MoveInput()
	{
		if (timer < moveData.cooldown)
		{
			timer += Time.deltaTime;
			moveX = 0;
			moveY = 0;
		}
		else
		{
			timer = 0;
			moveX = Input.GetAxisRaw("Horizontal");
			moveY = Input.GetAxisRaw("Vertical");
		}
	}
}


//! not used
// public class Bomb
// {
// 	public BombData bombData;
// 	public Transform trans;
// 	protected List<Collider> collidersHit = new List<Collider>();
// 	protected float timer = 0;


// 	public Bomb(BombData bombData, Transform pos)
// 	{

// 		this.bombData = bombData;
// 		this.trans = pos;
// 		this.timer = 0;
// 	}

// 	public virtual void ExplodeTick(Bomb bomb)
// 	{
// 		if (timer < bombData.bombTimer)
// 		{
// 			timer += Time.deltaTime;
// 		}
// 		else
// 		{
// 			timer = 0;
// 			bomb.Explode();
// 		}
// 	}

// 	public virtual void Explode()
// 	{/*we do nothing*/}
// }

// public class BombCross : Bomb
// {
// 	public BombCross(BombData bombData, Transform pos) : base(bombData, pos)
// 	{
// 		this.bombData = bombData;
// 		this.trans = pos;
// 		this.timer = 0;
// 		this.collidersHit = new List<Collider>();
// 	}

// 	public override void ExplodeTick(Bomb bomb)
// 	{
// 		base.ExplodeTick(this);
// 	}

// 	public override void Explode()
// 	{

// 		Collider[] collidersX = Physics.OverlapBox(trans.position /*right here*/, Vector2.right * bombData.rangeX, quaternion.Euler(Vector3.zero), bombData.doNotHit);
// 		Collider[] collidersY = Physics.OverlapBox(trans.position /*right here2*/, Vector2.up * bombData.rangeY, quaternion.Euler(Vector3.zero), bombData.doNotHit);
// 		collidersHit.AddRange(collidersX);
// 		collidersHit.AddRange(collidersY);
// 		foreach (Collider collider in collidersHit)
// 		{
// 			if (collider.TryGetComponent(out IHp hp))
// 			{
// 				hp.TakeDmg();
// 			}
// 		}
// 	}
// }
