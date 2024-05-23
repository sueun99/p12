using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUpKeyPress_Throw : MonoBehaviour
{

    public GameObject newPrefab; // ����� ������ ��Inspector�� ����
    public int maxCount = 20; // �� ��Inspector�� ����

    public float throwX = 4;  // ������ �� ��Inspector�� ����
    public float throwY = 8;  // ������ ����Inspector�� ����
    public float offsetY = 1;
    public float cooltime = 1;

    bool pushFlag = false;
    bool leftFlag = false;
    bool cooling = false;

    void Update()
    {
        if (Input.GetKey("right"))// ���� ������ Ű�� ������
        {
            leftFlag = false;
        }
        if (Input.GetKey("left"))// ���� ���� Ű�� ������
        {
            leftFlag = true;
        }
        if (Input.GetKey("up"))// ���� �� Ű�� ������
        {
            if (pushFlag == false && cooling == false)// ������ ���� ������
            {
                pushFlag = true;
                cooling = true;

                Vector3 area = this.GetComponent<SpriteRenderer>().bounds.size;
                Vector3 newPos = this.transform.position;
                newPos.y += offsetY;
                // �������� �����
                GameObject newGameObject = Instantiate(newPrefab) as GameObject;
                newPos.z = -5; // �տ� ǥ���Ѵ�
                newGameObject.transform.position = newPos;

                Rigidbody2D rbody = newGameObject.GetComponent<Rigidbody2D>();
                if (leftFlag)// ���� �����̸� �ݴ� �������� ������
                {
                    rbody.AddForce(new Vector2(-throwX, throwY), ForceMode2D.Impulse);
                }
                else// ������ �����̸� ������ �������� ������ 
                {
                    rbody.AddForce(new Vector2(throwX, throwY), ForceMode2D.Impulse);
                }
                StartCoroutine(DelayAndDestroy());
            }
        }
        else
        {
            pushFlag = false;
        }
    }
    IEnumerator DelayAndDestroy()
    {
        yield return new WaitForSeconds(1f);
        cooling = false;
    }
}