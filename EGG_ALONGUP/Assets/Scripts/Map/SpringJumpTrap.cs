using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJumpTrap : MonoBehaviour
{
    public float compressionDistance = 0.5f; // 압축 거리
    public float jumpForce = 10f; // 튕기는 힘

    private Vector3 originalPosition;
    private bool isCompressed = false;
    private GameObject player; 

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isCompressed)
        {
            isCompressed = true;
            player = collision.gameObject; 
            Vector3 targetPosition = originalPosition - transform.up * compressionDistance;
            StartCoroutine(AnimateSpring(targetPosition));
        }
    }

    private IEnumerator AnimateSpring(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        float duration = 0.2f; // 스프링처럼 압축되는 시간
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f); // 튕김 시간
        Vector3 jumpDirection = transform.up; // 튕기는 방향은 트랩의 위 
        player.GetComponent<Rigidbody>().AddForce(jumpDirection * jumpForce, ForceMode.Impulse); // 플레이어 객체를 사용하여 튕김 힘을 적용합니다.
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(targetPosition, originalPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isCompressed = false;
    }
}
