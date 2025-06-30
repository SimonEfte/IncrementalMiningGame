using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public GameObject background;
    public float shakeDuration;
    public float shakeMagnitude;
    private Vector3 originalPos;

    private void Awake()
    {
        shakeDuration = 0.1f;
        shakeMagnitude = 0.2f;
        originalPos = new Vector3(-254, 170, 0);
    }

    public void ShakeTheScreen()
    {
        return;
        //StopAllCoroutines(); 
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-2.5f, 2.5f) * shakeMagnitude;
            float y = Random.Range(-2.5f, 2.5f) * shakeMagnitude;

            background.transform.localPosition = originalPos + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        background.transform.localPosition = originalPos;
    }
}
