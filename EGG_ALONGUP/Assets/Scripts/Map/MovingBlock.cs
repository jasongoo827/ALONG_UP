using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public GameObject startPos; // 발판의 시작 위치
    public GameObject endPos; // 발판의 끝 위치
    public float speed = 1.0f; // 이동 속도
    private bool movingToEnd = true; // 현재 이동 방향

    void Update()
    {
        // 현재 이동 방향에 따라 목표 위치 설정
        var targetPos = movingToEnd ? endPos.transform.position : startPos.transform.position;

        // 현재 위치에서 목표 위치까지 이동
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);

        if (transform.position == endPos.transform.position)
        {
            movingToEnd = false;
        }
        else if (transform.position == startPos.transform.position)
        {
            movingToEnd = true;
        }
    }
}