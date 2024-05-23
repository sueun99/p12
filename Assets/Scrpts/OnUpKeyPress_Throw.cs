using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUpKeyPress_Throw : MonoBehaviour
{

    public GameObject newPrefab; // 만드는 프리팹 ：Inspector에 지정
    public int maxCount = 20; // 빈도 ：Inspector에 지정

    public float throwX = 4;  // 던지는 힘 ：Inspector에 지정
    public float throwY = 8;  // 던지는 힘：Inspector에 지정
    public float offsetY = 1;
    public float cooltime = 1;

    bool pushFlag = false;
    bool leftFlag = false;
    bool cooling = false;

    void Update()
    {
        if (Input.GetKey("right"))// 만약 오른쪽 키가 눌리면
        {
            leftFlag = false;
        }
        if (Input.GetKey("left"))// 만약 왼쪽 키가 눌리면
        {
            leftFlag = true;
        }
        if (Input.GetKey("up"))// 만약 위 키가 눌리면
        {
            if (pushFlag == false && cooling == false)// 누르고 있지 않으면
            {
                pushFlag = true;
                cooling = true;

                Vector3 area = this.GetComponent<SpriteRenderer>().bounds.size;
                Vector3 newPos = this.transform.position;
                newPos.y += offsetY;
                // 프리팹을 만든다
                GameObject newGameObject = Instantiate(newPrefab) as GameObject;
                newPos.z = -5; // 앞에 표시한다
                newGameObject.transform.position = newPos;

                Rigidbody2D rbody = newGameObject.GetComponent<Rigidbody2D>();
                if (leftFlag)// 왼쪽 방향이면 반대 방향으로 던진다
                {
                    rbody.AddForce(new Vector2(-throwX, throwY), ForceMode2D.Impulse);
                }
                else// 오른쪽 방향이면 오른쪽 방향으로 던진다 
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