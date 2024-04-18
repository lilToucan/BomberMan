using Action = System.Action;
using UnityEngine;
using System;

//* ALL MY SCRIPTABLE OBJECTS RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH

[CreateAssetMenu(fileName = "MovementData", menuName = "scriptables/Movement/MovementData")]
public class MovementData : ScriptableObject
{
	[Header("All:")]
	public LayerMask wallsLayer;

	[Header("AI:")]
	public bool isAi;
	public float cooldown = 0;
}



[CreateAssetMenu(fileName = "BombData", menuName = "scriptables/Bomb/BombData")]
public class BombData : ScriptableObject
{
	public float cooldown;
	public float bombTimer;
	public int rangeX;
	public int rangeY;
	public GameObject bomb { get; set; }
	public BombAction pullData;
	public LayerMask doNotHit;

	[Header("Ai:")]
	[Range(0, 1)] public float chance;
}

[CreateAssetMenu(fileName = "BombAction", menuName = "scriptables/Bomb/BombPullData")]
public class BombAction : ScriptableObject
{
	public GameObject Bomb;
	public Action onGet;


}


public class ActionData<T> : ScriptableObject
{
	public Action<T> onActivation;
}

[CreateAssetMenu(fileName = "BoolAction", menuName = "scriptables/Actions/Bool")]
public class ActionBool : ActionData<bool>
{

}

[CreateAssetMenu(fileName = "BoolAction", menuName = "scriptables/Actions/Bool")]
public class ActionInt : ActionData<int>
{

}


