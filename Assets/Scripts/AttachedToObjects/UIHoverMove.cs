using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIHoverMove : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalPosition;
    public float moveAmount = 10f; // how much to move up
    public float moveDuration = 0.2f; // how fast to move

    private Coroutine moveCoroutine;

    public static bool isHoveringBtn, isHoveringSkillTreeBtn;
    public bool doTheAnim;
    public bool isSkillTreeBtn;
    public bool isMenuButtons;

    public bool isKeepOnMiningBtn;

    private void Awake()
    {
        moveAmount = 8;
        moveDuration = 0.1f;
    }

    private void OnEnable()
    {
        originalPosition = transform.localPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(isMenuButtons == true)
        {
            if(isKeepOnMiningBtn == false)
            {
                originalPosition = transform.localPosition;
                originalPosition.y = 0;
            }
         
            isHoveringBtn = true; 
        }

        if(isSkillTreeBtn == true) { isHoveringSkillTreeBtn = true; }

        if(doTheAnim == true) { StartMove(originalPosition + Vector3.up * moveAmount); }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHoveringBtn = false;

        if (isSkillTreeBtn == true) { isHoveringSkillTreeBtn = false; }

        if (doTheAnim == true) { StartMove(originalPosition); }
    }

    private void StartMove(Vector3 targetPosition)
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        moveCoroutine = StartCoroutine(MoveToPosition(targetPosition));
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        Vector3 startPos = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.unscaledDeltaTime; // use unscaled if it's UI
            transform.localPosition = Vector3.Lerp(startPos, targetPosition, elapsed / moveDuration);
            yield return null;
        }

        transform.localPosition = targetPosition;
    }
}
