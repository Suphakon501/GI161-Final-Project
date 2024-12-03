using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    int jump; 
    public float speed;
    float x, sx;
    Animator am;
    Rigidbody2D rb;

    // Start ��Ϳѧ��ѹ������¡���͹����Ѿവ�����á
    void Start()
    {
        jump = 0;
        am = GetComponent<Animator>(); // �������кػ���������๹��
        rb = GetComponent<Rigidbody2D>(); // �������кػ���������๹��
        sx = transform.localScale.x;
    }

    // Update ��Ϳѧ��ѹ������¡��㹷ء���
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        am.SetFloat("speed", Mathf.Abs(x)); // �� Mathf.Abs ����Ѻ��������ó�
        if(Input.GetButtonDown("Jump") && jump <4)

        if (Input.GetButtonDown("Jump"))
        {
                jump++;
            am.SetBool("jump", true);
            rb.velocity = new Vector2(rb.velocity.x, 5f);
        }

        rb.velocity = new Vector2(x * speed, rb.velocity.y);

        if (x > 0) // ��䢡�����º��º���١��ͧ
        {
            transform.localScale = new Vector3(sx, transform.localScale.y, transform.localScale.z);
        }
        else if (x < 0) // �������� else if
        {
            transform.localScale = new Vector3(-sx, transform.localScale.y, transform.localScale.z);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        am.SetBool("jump", false);
        jump= 0;
    }

    float Abs(float x)
    {
        return x >= 0f ? x : -x; // ��䢡�����º��º���١��ͧ
    }
}
