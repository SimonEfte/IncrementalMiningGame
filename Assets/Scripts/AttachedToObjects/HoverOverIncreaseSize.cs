using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverOverIncreaseSize : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    public float scaleMultiplier = 1.2f; // how much to scale up
    public float scaleDuration = 0.2f;   // how fast to scale

    private Coroutine scaleCoroutine;

    public static float xPos;

    private void Awake()
    {
        scaleMultiplier = 1.08f;
        scaleDuration = 0.1f;

        coolBtn1Time = false;
    }

    bool coolBtn1Time;

    private void OnEnable()
    {
        if(gameObject.name == "coolBtn")
        {
            gameObject.transform.localScale = new Vector2(1,1);

            if(coolBtn1Time == false)
            {
                originalScale = transform.localScale;
                coolBtn1Time = true;
            }
        }
        else
        {
            originalScale = transform.localScale;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        xPos = gameObject.transform.localPosition.x;
        StartScale(originalScale * scaleMultiplier);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartScale(originalScale);
    }

    private void StartScale(Vector3 targetScale)
    {
        if (scaleCoroutine != null)
        {
            StopCoroutine(scaleCoroutine);
        }
        scaleCoroutine = StartCoroutine(ScaleToSize(targetScale));
    }

    private IEnumerator ScaleToSize(Vector3 targetScale)
    {
        Vector3 startScale = transform.localScale;
        float elapsed = 0f;

        while (elapsed < scaleDuration)
        {
            elapsed += Time.unscaledDeltaTime; // use unscaled if it's UI
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsed / scaleDuration);
            yield return null;
        }

        transform.localScale = targetScale;
    }
}
