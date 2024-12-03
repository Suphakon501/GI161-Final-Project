using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Character : MonoBehaviour
{
    [SerializeField] private int health;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    protected Animator anim;
    protected Rigidbody2D rb;
    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
            return true;
        }
        return false;
    }
    public virtual void TakeDamage(int damage)
    {
        Health = 0;
        IsDead();
    }
}
