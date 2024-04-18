using UnityEngine;

public class DestroyThySelf : MonoBehaviour, IHp
{
    public void Death()
    {
        gameObject.SetActive(false);
    }

    public void TakeDmg()
    {
        Death();
    }
}
