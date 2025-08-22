using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeDrag : MonoBehaviour
{
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float minZoom = 0.5f;
    [SerializeField] private float maxZoom = 1.5f;
    [SerializeField] public static float defaultZoom = 0.9f;
    public static Vector3 targetScale;

    private bool isDragging = false;
    private Vector3 lastMousePosition;
    private RectTransform rectTransform;

    public GameObject skillTreeTooltip;

    public GameObject contentFrame;

    public static float scaleX;

    public Slider zoomSliderMobile;

    void Awake()
    {
        dragThreshold = 100f;
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
        if(MobileAndTesting.isMobile == true)
        {
            zoomSliderMobile.gameObject.SetActive(true);
        }
        else
        {
            zoomSliderMobile.gameObject.SetActive(false);
        }
    }

    void OnEnable()
    {
       
    }

    public float divideDiff;

    public float currentXscale = 0;

    public Transform skillTreeMoveTo;

    private Vector3 mouseDownPosition;
    private float dragThreshold = 10f;

    void Update()
    {
        if (MainMenu.isInUpgrades == true && SkillTree.isInEndlessPopUp == false)
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
                        if(MobileAndTesting.isMobile == false)
                        {
                            skillTreeTooltip.SetActive(false);
                        }
                    }
                }

                if (Input.GetMouseButtonUp(0))
                {
                    isDragging = false;
                }

                if(MobileAndTesting.isMobile == false)
                {
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
                else
                {
                    transform.localScale = new Vector3(zoomSliderMobile.value, zoomSliderMobile.value, zoomSliderMobile.value);
                }
            }
        }
    }

    //x and y > 0 = Both increse
    //x and y < 0 = Both decrease
}
