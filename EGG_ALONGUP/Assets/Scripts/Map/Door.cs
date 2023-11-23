using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Door : MonoBehaviour
{
    private Vector3 initialPosition;
    public Vector3 openOffset; // 문이 열릴 때 이동할 위치
    private bool isOpen = false; // 문이 열렸는지 여부
    public float smoothTime = 0.3f; // 부드러운 이동에 사용되는 시간
    private Vector3 currentVelocity = Vector3.zero;
    private void Start()
    {
        initialPosition = transform.position;
    }
    public void Open()
    {
        if (!isOpen)
        {
            isOpen = true;
        }
    }
    public void Close()
    {
        if (isOpen)
        {
            isOpen = false;
        }
    }
    private void Update()
    {
        // 문을 부드럽게 이동
        Vector3 targetPosition = initialPosition + (isOpen ? openOffset : Vector3.zero);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
    }
}