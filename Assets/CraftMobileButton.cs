using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftMobileButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool isPressing = false;

    private Vector3 originalScale;  
    private Vector3 pressedScale;

    private void Awake()
    {
        originalScale = transform.localScale;

        // Calculate the pressed scale (85% of original on X, Y, Z)
        pressedScale = originalScale * 0.85f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressing = true;
        transform.localScale = pressedScale;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressing = false;
        transform.localScale = originalScale;
    }

    private void Update()
    {
        if(gameObject.activeInHierarchy == false)
        {
            isPressing = false;
            transform.localScale = originalScale;
        }
    }

    private void OnDisable()
    {
        isPressing = false;
        transform.localScale = originalScale;
    }
}
