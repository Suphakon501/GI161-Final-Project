using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float moveSpeed = 5f;
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public float shootTime;
    private float shootCounter;
    private int jump;
    private float x, sx;
    
    void Start()
    {
        // เริ่มต้นค่า
        shootCounter = shootTime;
        jump = 0;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sx = transform.localScale.x;
    }

    void Update()
    {
        Move();      // การเคลื่อนที่
        Shooting();  // การยิง
    }
    public override void Move()
    {
        x = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(x)); // ใช้ค่าสัมบูรณ์ของความเร็ว

        if (Input.GetButtonDown("Jump") && jump < 4)
        {
            jump++;
            anim.SetBool("jump", true);
            rb.velocity = new Vector2(rb.velocity.x, 5f);
        }

        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);

        // การกลับด้านตัวละครเมื่อเคลื่อนที่
        if (x > 0)
        {
            transform.localScale = new Vector3(sx, transform.localScale.y, transform.localScale.z);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(-sx, transform.localScale.y, transform.localScale.z);
        }
    }
    private void Shooting()
    {
        if (Input.GetButtonDown("Fire1") && shootCounter <= 0)
        {
            KunaiBullet kunai = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity).GetComponent<KunaiBullet>();
            kunai.SetShooter(this.transform);
            kunai.SetTargetTag();
            shootCounter = shootTime;
        }
        shootCounter -= Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        anim.SetBool("jump", false);
        jump = 0;
    }
    public void ApplyPotion(float speedMultiplier, float duration)
    {
        StartCoroutine(SpeedBoost(speedMultiplier, duration));
    }

    private IEnumerator SpeedBoost(float speedMultiplier, float duration)
    {
        moveSpeed *= speedMultiplier; 
        yield return new WaitForSeconds(duration); 
        moveSpeed /= speedMultiplier; 
    }
}
