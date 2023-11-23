using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Button : MonoBehaviour
{
    public Door connectedDoor; // 연결된 문
    private bool isPressed = false; // 버튼이 눌렸는지 여부
    private Vector3 initialPosition;
    private Vector3 pressedPosition;
    private Vector3 currentVelocity = Vector3.zero;
    public float pressDepth = 0.1f; // 버튼이 눌렸을 때 이동 거리
    public float smoothTime = 0.3f; // 부드러운 이동에 사용되는 시간
    private void Start()
    {
        initialPosition = transform.position;
        pressedPosition = initialPosition - new Vector3(0, pressDepth, 0);
    }
    private void OnTriggerEnter(Collider other)
    {

        isPressed = true;
        connectedDoor.Open();

    }
    private void OnTriggerExit(Collider other)
    {

        isPressed = false;
        connectedDoor.Close();

    }
    private void Update()
    {
        Vector3 targetPosition = isPressed ? pressedPosition : initialPosition;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
    }
}