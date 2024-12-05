using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private int health;  // ���ʹ�������
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
            Destroy(gameObject);  // ��������ʹ����з���µ���Ф�
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
            IsDead();  // ������ʹŴŧ��������ӡ�õ�Ǩ�ͺ��õ��
        }
    }
    public virtual void Move()
    {
        //Debug.Log("Character is moving.");
    }
}