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
        if(MobileAndTesting.isMobile == true) { return; }

        Cursor.visible = true;

        if(MobileAndTesting.isMobile == false)
        {
            if (isEndSessionBtn == true)
            {
                goldHand.SetActive(false);
                normalHand.SetActive(false);
            }
        }

        Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (MobileAndTesting.isMobile == true) { return; }

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
            if (MobileAndTesting.isMobile == false)
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

        if(SetRockScreen.isInEnding == true)
        {
            Cursor.visible = true;
        }
    }
}
