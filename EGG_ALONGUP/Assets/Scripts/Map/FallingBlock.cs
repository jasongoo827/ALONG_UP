using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public Transform respawnPoint;
    public float fallSpeed = 5.0f;
    public float respawnDelay = 2.0f;

    private bool isFalling = false;
    private Rigidbody rb;
    private Quaternion initialRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (!isFalling && Input.GetKeyDown(KeyCode.Space))
        {
            Fall();
        }
    }

    void Fall()
    {
        rb.isKinematic = false;
        isFalling = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (isFalling && other.CompareTag("GameController"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        rb.isKinematic = true;
        isFalling = false;
        transform.position = respawnPoint.position;
        transform.rotation = initialRotation;
        Invoke("ResetKinematic", respawnDelay);
    }

    void ResetKinematic()
    {
        rb.isKinematic = true;
    }
}