using UnityEngine;

public class FireBallBullet : Projectile
{
    public float acceleration = 2f;
    public float currentSpeed;
    protected override void Start()
    {
        base.Start();
        damage =  20; 
        currentSpeed = speed;
        //Debug.Log("is target null " + (targetTransform == null));
    }
    private void Update()
    {
        SetDirection();
    }
    protected override void SetDirection()
    {
        if (shooterTransform.localScale.x < 0)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(speed, 0); 
        }
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 direction = (targetTransform.position - transform.position).normalized;
        rb.velocity = direction * currentSpeed; 
    }


}
