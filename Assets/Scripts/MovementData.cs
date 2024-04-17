using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementData", menuName = "scriptables/MovementData")]
public class MovementData : ScriptableObject
{
	[Header("All:")]
	public LayerMask wallsLayer;
	public bool canMove = true;

	[Header("AI:")]
	public bool isAi;
	public float chance;
	public float Colldown = 0;
}



[CreateAssetMenu(fileName = "BombData", menuName = "scriptables/BombData")]
public class BombData : ScriptableObject
{
	public float cooldown;
	public GameObject bomb { get; set; }

	[Header("Ai:")]
	[Range(0, 1)]
	public float chance;
}

