using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckToolTipOffScreen : MonoBehaviour
{
    [SerializeField] private Camera uiCamera;

    private RectTransform rectTransform, parentRectTransform;

    public Transform tooltipAnimFrame;
    public Animation tooltipAnimFrameAnim;

    public RectTransform tooltipRectTransform;

    public TextMeshProUGUI upgradeDescText;

    void Awake()
    {
        parentRectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform = GetComponent<RectTransform>();

        tooltipAnimFrame = transform.Find("tooltipAnim");
        tooltipAnimFrameAnim = tooltipAnimFrame.GetComponent<Animation>();
        tooltipRectTransform = tooltipAnimFrame.GetComponent<RectTransform>();

        Transform upgradeDescTextObject = transform.Find("tooltipAnim/UpgradeDesc_text");
        upgradeDescText = upgradeDescTextObject.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        checkCorners = false;
        StartCoroutine(PlayToolTipAnimSkillTree());
        tooltipAnimFrame.gameObject.SetActive(false);
    }

    bool checkCorners;

    IEnumerator PlayToolTipAnimSkillTree()
    {
        yield return new WaitForSeconds(0.025f);
        checkCorners = true;
        yield return new WaitForSeconds(0.025f);
        tooltipAnimFrame.gameObject.SetActive(true);
    }

    float skillTreeWidth;

    void Update()
    {
        skillTreeWidth = tooltipRectTransform.sizeDelta.x;

        float preferredWidth = upgradeDescText.GetPreferredValues().x;
        upgradeDescText.rectTransform.sizeDelta = new Vector2(preferredWidth, 67);
        parentRectTransform.sizeDelta = new Vector2(preferredWidth + 100, 220);

        tooltipRectTransform.sizeDelta = new Vector2(preferredWidth - 320, 67);

        if (checkCorners == true)
        {
            CheckOffScreenEdges();
        }
    }

    private void CheckOffScreenEdges()
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        bool isOffTop = false;
        bool isOffLeft = false;
        bool isOffRight = false;

        foreach (Vector3 corner in corners)
        {
            Vector3 viewportPoint = uiCamera.WorldToViewportPoint(corner);

            if (viewportPoint.x < 0) isOffLeft = true;
            if (viewportPoint.x > 1) isOffRight = true;
            if (viewportPoint.y > 1) isOffTop = true;
        }

        float leftOrRightAdd = 0;
        if(skillTreeWidth < 0) { leftOrRightAdd = 3; }
        else if (skillTreeWidth > 450) { leftOrRightAdd = 5.7f; }
        else if (skillTreeWidth > 250) { leftOrRightAdd = 4.5f; }
        else if (skillTreeWidth > 150) { leftOrRightAdd = 4f; }
        else if (skillTreeWidth > 0) { leftOrRightAdd = 3.4f; }

        if (Tooltip.isFinalUpgradeHover)
        {
            if (skillTreeWidth > 0) { leftOrRightAdd *= 1.3f; }
        }

        if (isOffTop && isOffRight)
        {
            gameObject.transform.position = new Vector2(Tooltip.skillTreeToolTipPos.x - leftOrRightAdd, Tooltip.skillTreeToolTipPos.y - 1.65f);
        }
        else if (isOffTop && isOffLeft)
        {
            gameObject.transform.position = new Vector2(Tooltip.skillTreeToolTipPos.x + leftOrRightAdd, Tooltip.skillTreeToolTipPos.y - 1.65f);
        }
        // Debug for individual edges
        else if (isOffTop)
        {
            if (Tooltip.isFinalUpgradeHover)
            {
                gameObject.transform.position = new Vector2(Tooltip.skillTreeToolTipPos.x, Tooltip.skillTreeToolTipPos.y - 2.1f);
            }
            else
            {
                gameObject.transform.position = new Vector2(Tooltip.skillTreeToolTipPos.x, Tooltip.skillTreeToolTipPos.y - 1.65f);
            }
        }
        else if (isOffLeft)
        {
            gameObject.transform.position = new Vector2(Tooltip.skillTreeToolTipPos.x + leftOrRightAdd, Tooltip.skillTreeToolTipPos.y);
        }
        else if (isOffRight)
        {
            gameObject.transform.position = new Vector2(Tooltip.skillTreeToolTipPos.x - leftOrRightAdd, Tooltip.skillTreeToolTipPos.y);
        }
    }


    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
