using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillTreeUpgradeClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    private Quaternion originalRotation;

    private Vector3 targetScale;
    private Quaternion targetRotation;

    private bool isMouseOver = false;

    public Animation clickAnim;
    public Button btn;

    void Awake()
    {
        btn = gameObject.GetComponent<Button>();
        clickAnim = gameObject.GetComponent<Animation>();

        originalScale = transform.localScale;
        originalRotation = transform.rotation;

        targetScale = originalScale * 0.85f;
        targetRotation = Quaternion.Euler(0f, 0f, -14f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (btn.enabled == true) 
        {
            if (clickAnim.isPlaying)
            {
                transform.localScale = originalScale;
                transform.rotation = originalRotation;

                clickAnim.Stop();
                clickAnim.Play();
            }
            else
            {
                clickAnim.Play();
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       
    }
}
