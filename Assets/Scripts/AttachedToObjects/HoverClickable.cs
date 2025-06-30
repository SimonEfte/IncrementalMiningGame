using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverClickable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Texture2D hoverCursor;
    public bool isEndSessionBtn;
    public GameObject goldHand, normalHand;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.visible = true;

        if(isEndSessionBtn == true)
        {
            goldHand.SetActive(false);
            normalHand.SetActive(false);
        }

        Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        if (SetRockScreen.isInMiningSession)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }

        if (isEndSessionBtn == true)
        {
            if (SetRockScreen.isGoldenHand) 
            {
                goldHand.SetActive(true);
                normalHand.SetActive(false);
            }
            else
            {
                goldHand.SetActive(false);
                normalHand.SetActive(true);
            }
        }
    }
}
