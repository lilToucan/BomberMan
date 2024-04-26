using UnityEngine;
using System;

[CreateAssetMenu(fileName = "BombData", menuName = "scriptables/Bomb/BombData")]
public class BombData : ScriptableObject
{
	public float cooldown;
	public float bombTimer;
	public int rangeX;
	public int rangeY;
	public GameObject bomb;
	public BombAction bombAction;
	public LayerMask doNotHit;

	[Header("Ai:")]
	[Range(0, 1)] public float chance;
}