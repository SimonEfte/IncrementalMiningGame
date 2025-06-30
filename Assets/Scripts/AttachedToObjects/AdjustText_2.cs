using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdjustText_2 : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float padding = 10f; // Extra space if needed

    void Update()
    {
        // Optional: only update when the text changes to save performance
        AdjustWidthToText();
    }

    void AdjustWidthToText()
    {
        float preferredWidth = textMeshPro.preferredWidth;
        RectTransform rectTransform = textMeshPro.GetComponent<RectTransform>();
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, preferredWidth + padding);
    }
}
