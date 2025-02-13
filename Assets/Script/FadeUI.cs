using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeUI : MonoBehaviour
{
    public Image fadeimage;
    public float fadeDuration = 1.0f;   
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(FadeLoadScene());
    }

    public IEnumerator FadeLoadScene()
    {
        fadeimage.enabled = true;
        float elapsedTime = 0.0f;
        Color startColor = fadeimage.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeimage.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }
        fadeimage.color = endColor;       
        SceneManager.LoadScene("GameMain");
        yield return new WaitForSeconds(1);

        float elapsedTime2 = 0.0f;

        while (elapsedTime2 < fadeDuration)
        {
            elapsedTime2 += Time.deltaTime;
            float t2 = Mathf.Clamp01(elapsedTime2 / fadeDuration);
            fadeimage.color = Color.Lerp(endColor, startColor, t2);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
