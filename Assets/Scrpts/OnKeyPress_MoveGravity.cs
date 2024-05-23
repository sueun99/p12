using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyPress_MoveGravity : MonoBehaviour
{

    public float speed = 3; // �ӵ���Inspector�� ����
    public float jumppower = 8;  // �����£�Inspector�� ����

    float vx = 0;
    bool leftFlag = false; // ���� �������� 
    bool pushFlag = false; // �����̽� Ű�� ���� �������� 
    bool jumpFlag = false; // ���� �������� 
    bool groundFlag = false; // ���� ���𰡿� ��Ҵ��� 
    Rigidbody2D rbody;

    void Start()// ó���� �����Ѵ�
    {
        // �浹 �ÿ� ȸ����Ű�� �ʴ´� 
        rbody = GetComponent<Rigidbody2D>();
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update() // ��� �����Ѵ� 
    {
        vx = 0;
        if (Input.GetKey("right")) // ���� ������ Ű�� ������
        {
            vx = speed; // ���������� �����ϴ� �̵����� �ִ´�
            leftFlag = false;
        }
        if (Input.GetKey("left")) // ���� ���� Ű�� ������
        { // 
            vx = -speed; // �������� �����ϴ� �̵����� �ִ´� 
            leftFlag = true;
        }
        // ���� �����̽�Ű�� ������ �� ���� ���𰡿� ��Ҵٸ� 
        if (Input.GetKey("space") && groundFlag)
        {
            if (pushFlag == false)// ��� ������ ������ ������
            {
                jumpFlag = true; // ���� �غ� 
                pushFlag = true; // ��� ���� ���� 
            }
        }
        else
        {
            pushFlag = false; // ��� ���� ���� ���� 
        }
    }
    void FixedUpdate() // ��� �����Ѵ�(���� �ð�����)
    {
        // �̵��Ѵ�(�߷��� �� ä)
        rbody.velocity = new Vector2(vx, rbody.velocity.y);
        // ���� ���������� ������ �ٲ۴� 
        this.GetComponent<SpriteRenderer>().flipX = leftFlag;
        // ���� ������ �� 
        if (jumpFlag)
        {
            jumpFlag = false;
            rbody.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    { // ���� ���𰡿� ������ 
        groundFlag = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    { // �߿� �ƹ� �͵� ���� ������ 
        groundFlag = false;
    }
}
