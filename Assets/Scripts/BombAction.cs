using Action = System.Action;
using UnityEngine;

[CreateAssetMenu(fileName = "BombAction", menuName = "scriptables/Bomb/BombAction")]
public class BombAction : ScriptableObject
{
	public GameObject Bomb;
	public Action onGet;
}