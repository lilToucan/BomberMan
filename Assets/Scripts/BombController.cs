using Unity.Mathematics;
using UnityEngine;

public class BombController : MonoBehaviour
{
	public BombData bombData;
	public string explosionAnim;
	public Animator myAnim;
	public GameObject whereToAnimate;
	BombCross bombType;

	Vector2 pos = Vector2.zero;


	private void Start()
	{
		pos = transform.position;
		bombType = new BombCross(bombData, transform);
		for (int i = 0; i < bombData.rangeX; i++)
		{
			Instantiate(whereToAnimate, pos + Vector2.right * i, quaternion.identity);
			Instantiate(whereToAnimate, pos - Vector2.right * -i, quaternion.identity);
		}
		for (int i = 0; i < bombData.rangeY; i++)
		{
			Instantiate(whereToAnimate, pos + Vector2.up * i, quaternion.identity);
			Instantiate(whereToAnimate, pos - Vector2.up * -i, quaternion.identity);
		}
	}

	private void Update()
	{
		bombType.ExplodeTick(bombType);
	}

	public void Explode()
	{
		bombType.Explode();
	}
}
