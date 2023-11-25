using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialEnd : MonoBehaviour
{
    public float fadeTime = 1f; // Fade 시간 설정
    public GameObject fadeOutImage;

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("player collision");
        StartCoroutine(FadeInEffect());

    }

    IEnumerator FadeInEffect()
    {
        CanvasGroup canvasGroup = fadeOutImage.GetComponent<CanvasGroup>();

        // Fade in 효과 시작
        for (float t = 0.01f; t < fadeTime; t += Time.deltaTime)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, t / fadeTime);
            yield return null;
        }
        canvasGroup.alpha = 1; // 완전히 불투명하게 설정
        SceneManager.LoadScene("StartScene");
    }
}
