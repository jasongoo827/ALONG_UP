using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float upwardForce = 10.0f; // 플레이어를 위로 밀어올리는 힘
    public float maxDistance = 5.0f;    // 플레이어를 영향을 주는 최대 거리

    void Update()
    {
        ApplyUpwardForce();
    }

    void ApplyUpwardForce()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, maxDistance);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                
                Vector3 direction = collider.transform.position - transform.position;

                
                collider.GetComponent<Rigidbody>().AddForce(direction.normalized * upwardForce, ForceMode.Acceleration);
            }
        }
    }
}