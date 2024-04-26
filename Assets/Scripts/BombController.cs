using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BombController : MonoBehaviour
{
	public BombData bombData;
	public string explosionAnim;
	public Animator myAnim;
	public GameObject whereToAnimate;
	float timer;
	[SerializeField] float frequency, scale;
	float newScale;
	List<Collider2D> colliders = new();
	Vector2 pos = Vector2.zero;


	private void Start()
	{
		StartCoroutine(Explosion());
	}

	IEnumerator Explosion()
	{
		timer = 0;
		while (timer < bombData.bombTimer)
		{
			newScale = scale * timer / bombData.bombTimer;
			transform.localScale = new Vector3(Mathf.Sin(Time.deltaTime * frequency) * newScale / 2 + newScale / 2, Mathf.Sin(Time.deltaTime * frequency) * newScale / 2 + newScale / 2);
			timer += Time.deltaTime;
			yield return null;
		}
		myAnim.CrossFade(explosionAnim, 0.2f);
		Collider2D[] colX = Physics2D.OverlapBoxAll(transform.position, new Vector2((bombData.rangeX + 0.5f) * 2, 0.5f), 0f, ~bombData.doNotHit);
		Collider2D[] colY = Physics2D.OverlapBoxAll(transform.position, new Vector2(0.5f, (bombData.rangeY + 0.5f) * 2), 0f, ~bombData.doNotHit);
		colliders.AddRange(colX);
		colliders.AddRange(colY);
		pos = transform.position;
		for (int i = 1; i <= bombData.rangeX; i++)
		{
			Instantiater(Vector2.right, i);
		}

		for (int i = 1; i <= bombData.rangeY; i++)
		{
			Instantiater(Vector2.up, i);
		}

		foreach (Collider2D coll in colliders)
		{
			if (coll.TryGetComponent(out IHp hp))
			{
				hp.TakeDmg();
			}
		}
		Destroy(gameObject);

		void Instantiater(Vector2 dir, int i)
		{
			Instantiate(whereToAnimate, pos + dir * i, quaternion.identity);
			Instantiate(whereToAnimate, pos + dir * -i, quaternion.identity);
		}
	}
#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(transform.position, new Vector2((bombData.rangeX + 0.5f) * 2, 0.5f));
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(transform.position, new Vector2(0.5f, (bombData.rangeY + 0.5f) * 2));
	}
#endif
}
