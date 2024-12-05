using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
public abstract class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float lifetime;
    protected Transform shooterTransform; 
    protected string targetTag;
    [SerializeField] protected int damage;
    protected Transform targetTransform;
    public virtual void SetShooter(Transform shooter)
    {
        shooterTransform = shooter;
        SetTargetTag();
    }
    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
    protected virtual void Start()
    {
        StartCoroutine(DestroyAfterTime());
        SetDirection();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            Character targetCharacter = other.gameObject.GetComponent<Character>();
            if (targetCharacter != null)
            {
                targetCharacter.TakeDamage(damage);
            }
        }
    }
    public void SetTargetTag()
    {
        if (shooterTransform.CompareTag("Player"))
        {
            targetTag = "Enemy";
        }
        else if (shooterTransform.CompareTag("Enemy"))
        {
            targetTag = "Player";
        }
    }
    protected abstract void SetDirection();
}
