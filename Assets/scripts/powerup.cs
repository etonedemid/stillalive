using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class powerup : MonoBehaviour
{
    Image canvasGroup;
    public Color color;
    float targetAlpha = 0f;
    GameObject legs;
    Color color1;
    void Start()
    {
        canvasGroup = GetComponent<Image>();
        Color color1;
        color1 = color;
        color1.a = 0f;
        canvasGroup.color = color1;
    }
    public IEnumerator FadeOut(float duration)
    {
        float startAlpha = 0.5f;
        float targetAlpha = 0f;
        float startTime = Time.time;
        Color color1;
        
        while (Time.time - startTime < duration)
        {
            float elapsedTime = (Time.time - startTime) / duration;
            Mathf.Lerp(startAlpha, targetAlpha, elapsedTime);
            color1 = color;
            color1.a = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime);
            canvasGroup.color = color1;
            yield return new WaitForEndOfFrame();
        }

        color1 = color;
        color1.a = 0f;
        canvasGroup.color = color1;
    }
    public void powervignette()
    {
        Debug.Log("poweredup");
        StartCoroutine(FadeOut(1.0f));
    }
}
