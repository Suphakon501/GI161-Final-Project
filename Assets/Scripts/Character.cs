using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private int health;  // เลือดเริ่มต้น
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
            Destroy(gameObject);  // เมื่อเลือดหมดจะทำลายตัวละคร
            return true;
        }
        return false;
    }
    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        //Debug.Log(gameObject.name + " took " + damage + " damage! Remaining Health: " + Health);
        if (Health <= 0)
        {
            IsDead();  // ถ้าเลือดลดลงจนหมดให้ทำการตรวจสอบการตาย
        }
    }
    public virtual void Move()
    {
        //Debug.Log("Character is moving.");
    }
}