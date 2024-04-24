using UnityEngine;
using System;

[CreateAssetMenu(fileName = "MovementData", menuName = "scriptables/Movement/MovementData")]
public class MovementData : ScriptableObject
{
	[Header("All:")]
	public LayerMask wallsLayer;

	[Header("AI:")]
	public bool isAi;
	public float cooldown = 0;
}


// this is for other scriptable
public class ActionData<T> : ScriptableObject
{
	public Action<T> onActivation;
}