using UnityEngine;

public class Boss : MonoBehaviour, IDamageable
{
    public int hp = 5;
    public Door doorToOpen;

    public void TakeDamage(int d)
    {
        hp -= d;
        if (hp <= 0)
        {
            if (doorToOpen) doorToOpen.Open();
            Destroy(gameObject);
        }
    }
}
