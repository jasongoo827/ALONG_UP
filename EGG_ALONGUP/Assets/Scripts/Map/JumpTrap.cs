using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrap : MonoBehaviour
{
    public float jumpForce = 10f; // 튕기는 힘

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 jumpDirection = transform.forward; // 튕기는 방향 
                rb.AddForce(jumpDirection * jumpForce, ForceMode.Impulse); // 튕기는 힘을 적용
            }
        }
    }
}