using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceForce = 5f; // 튕김 힘

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 bounceDirection = -collision.gameObject.transform.forward.normalized;
            collision.gameObject.GetComponent<Rigidbody>().velocity = bounceDirection * bounceForce;
        }
    }
}