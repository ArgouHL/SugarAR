using System.Collections;
using UnityEngine;

public class LightFader : MonoBehaviour
{
    private Light myLight;
    private float originalIntensity;

    // 渐变的时间（秒）
    public float fadeDuration = 2.0f;

    void Start()
    {
        myLight = GetComponent<Light>();

        if (myLight != null)
        {
            originalIntensity = myLight.intensity;
            myLight.intensity = 0f; // 将亮度设置为0
            StartCoroutine(FadeInLight());
        }
    }

    private IEnumerator FadeInLight()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            myLight.intensity = Mathf.Lerp(0f, originalIntensity, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        myLight.intensity = originalIntensity; // 确保最终亮度为原本的亮度
    }
}
