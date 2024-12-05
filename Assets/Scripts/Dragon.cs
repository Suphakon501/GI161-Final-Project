using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Dragon : Character
{
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1;
    public float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        Move();
        ShootAtPlayer(distanceFromPlayer);
        FacePlayer();
    }
    public override void Move()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
    }
    private void ShootAtPlayer(float distanceFromPlayer)
    {
        if (distanceFromPlayer < shootingRange && nextFireTime < Time.time)
        {
            GameObject fireballInstance = Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            FireBallBullet fireball = fireballInstance.GetComponent<FireBallBullet>();
            fireball.SetShooter(this.transform);
            fireball.SetTargetTag();
            nextFireTime = Time.time + fireRate;
        }
    }
    private void FacePlayer()
    {
        if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1); // หันหน้าศัตรูไปทางซ้าย
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1); // หันหน้าศัตรูไปทางขวา
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}