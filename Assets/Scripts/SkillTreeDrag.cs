using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeDrag : MonoBehaviour
{
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float minZoom = 0.5f;
    [SerializeField] private float maxZoom = 1.5f;
    [SerializeField] private float defaultZoom = 0.9f;
    public Vector3 targetScale;

    private bool isDragging = false;
    private Vector3 lastMousePosition;
    private RectTransform rectTransform;

    public GameObject skillTreeTooltip;

    public GameObject contentFrame;

    public static float scaleX;

    void Awake()
    {
        dragThreshold = 100f;
        rectTransform = GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        if(SkillTree.totalSkillTreeUpgradesPurchased < 10) { defaultZoom = 2.1f; }
        else if (SkillTree.totalSkillTreeUpgradesPurchased < 25) { defaultZoom = 2f; }
        else if(SkillTree.totalSkillTreeUpgradesPurchased < 50) { defaultZoom = 1.95f; }
        else if (SkillTree.totalSkillTreeUpgradesPurchased < 75) { defaultZoom = 1.9f; }
        else if (SkillTree.totalSkillTreeUpgradesPurchased < 100) { defaultZoom = 1.85f; }
        else if (SkillTree.totalSkillTreeUpgradesPurchased < 125) { defaultZoom = 1.8f; }
        else if (SkillTree.totalSkillTreeUpgradesPurchased < 150) { defaultZoom = 1.75f; }
        else if (SkillTree.totalSkillTreeUpgradesPurchased < 175) { defaultZoom = 1.7f; }
        else if (SkillTree.totalSkillTreeUpgradesPurchased < 200) { defaultZoom = 1.65f; }
        else
        {
            defaultZoom = 1.2f;
        }

        targetScale = Vector3.one * defaultZoom;
        transform.localScale = targetScale;
        transform.localPosition = new Vector2(0,-53);

        contentFrame.transform.localPosition = new Vector2(0,0);

        currentScale = defaultZoom;
    }

    public float divideDiff;
    public float currentScale;

    public float currentXscale = 0;

    public Transform skillTreeMoveTo;

    private Vector3 mouseDownPosition;
    private float dragThreshold = 10f;

    void Update()
    {
        if (MainMenu.isInUpgrades == true)
        {
            scaleX = gameObject.transform.localScale.x;

            if (UIHoverMove.isHoveringBtn == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    mouseDownPosition = Input.mousePosition;
                    isDragging = false; // reset here
                }

                if (Input.GetMouseButton(0))
                {
                    if (!isDragging && Vector3.Distance(Input.mousePosition, mouseDownPosition) > dragThreshold)
                    {
                        isDragging = true;
                    }

                    if (isDragging)
                    {
                        skillTreeTooltip.SetActive(false);
                    }
                }

                if (Input.GetMouseButtonUp(0))
                {
                    isDragging = false;
                }

                float scroll = Input.mouseScrollDelta.y;

                if (Mathf.Abs(scroll) > 0.01f)
                {
                    float scaleFactor = 1 + scroll * 0.1f; // Adjust scroll sensitivity here
                    targetScale *= scaleFactor;

                    float clampedX = Mathf.Clamp(targetScale.x, minZoom, maxZoom);
                    float clampedY = Mathf.Clamp(targetScale.y, minZoom, maxZoom);
                    targetScale = new Vector3(clampedX, clampedY, 1f);
                }

                transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * zoomSpeed);
            }
        }
    }

    //x and y > 0 = Both increse
    //x and y < 0 = Both decrease
}
