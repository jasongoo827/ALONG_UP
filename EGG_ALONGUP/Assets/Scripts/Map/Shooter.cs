using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject obstaclePrefab; // 생성할 작은 오브젝트 프리팹
    public float spawnInterval = 2.0f; // 작은 오브젝트를 생성하는 간격
    public float obstacleSpeed = 5.0f; // 작은 오브젝트의 이동 속도

    private float spawnTimer = 0.0f;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnObstacle();
            spawnTimer = 0.0f;
        }
    }

    private void SpawnObstacle()
    {
        GameObject obstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        Rigidbody obstacleRigidbody = obstacle.GetComponent<Rigidbody>();
        if (obstacleRigidbody != null)
        {
            obstacleRigidbody.velocity = transform.up * obstacleSpeed; //투사체 방향
            obstacleRigidbody.useGravity = false; // 중력 영향 제거
        }
    }
}