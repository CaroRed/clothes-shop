using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public float fadeDuration = 1.0f; // Duration in seconds

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
    }

    void Start()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float currentTime = 0f;
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            canvasGroup.alpha = 1 - Mathf.Clamp01(currentTime / fadeDuration);
            yield return null;
        }
    }

    public IEnumerator FadeInCanvas()
    {
        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(currentTime / fadeDuration);
            yield return null;
        }
    }
}
