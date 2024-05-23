using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour
{
    public string targetObjectName; // ��ǥ ������Ʈ �̸� : Inspector�� ����

    void OnCollisionEnter2D(Collision2D collision) // �浹���� ��
    {
        // ���� �ڽ��� �����Ѵ� 
        if (collision.gameObject.tag == targetObjectName)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
