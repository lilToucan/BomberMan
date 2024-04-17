using UnityEngine;

public class Mover
{
	private readonly Iinput input;
	private readonly MovementData moveData;
	private readonly Transform transformToMove;

	public Mover(Iinput input, MovementData moveData, Transform transformToMove)
	{
		this.input = input;
		this.moveData = moveData;
		this.transformToMove = transformToMove;
	}

	public void Tick()
	{
		Vector2 pos = Vector2.zero;
		if (input.moveX != 0)
		{
			if (!Physics.Raycast(transformToMove.position, Vector2.right * input.moveX, 1, moveData.wallsLayer))
			{
				pos = Vector2.right * input.moveX;
				transformToMove.position = pos;
			}
		}
		else if (input.moveY != 0)
		{
			if (!Physics.Raycast(transformToMove.position, Vector2.up * input.moveY, 1, moveData.wallsLayer))
			{
				pos = Vector2.right * input.moveX;
				transformToMove.position = pos;
			}
		}
	}

}

public interface Iinput
{
	public int moveX { get; set; }
	public int moveY { get; set; }
	public bool dropBomb { get; set; }


	public void MoveInput();
	public void BombInput();
}

public class AiInput : Iinput
{
	public int moveX { get; set; }
	public int moveY { get; set; }
	public float bombChance;
	public bool dropBomb { get; set; }

	public void BombInput()
	{
		float rand = Random.Range(0, 1);
		if (rand <= bombChance)
		{
			dropBomb = true;
		}
		else
		{
			dropBomb = false;
		}
	}

	public void MoveInput()
	{
		moveX = Random.Range(-1, 2);
		moveY = Random.Range(-1, 2);
	}
}

public class PlayerInput : Iinput
{
	public int moveX { get; set; }
	public int moveY { get; set; }
	public bool dropBomb { get; set; }

	public void BombInput()
	{
		if (Input.GetButtonDown("Space"))
		{
			dropBomb = true;
		}
		else
		{
			dropBomb = false;
		}
	}

	public void MoveInput()
	{
		moveX = (int)Input.GetAxisRaw("Horizontal");
		moveY = (int)Input.GetAxisRaw("Vertical");
	}
}