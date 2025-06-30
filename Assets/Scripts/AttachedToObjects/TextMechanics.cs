using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextMechanics : MonoBehaviour
{
    TextMeshProUGUI text;
    public GoldAndOreMechanics goldScript;

    public bool isMineMaterial;

    private void Awake()
    {
        GameObject goldObject = GameObject.Find("GoldAndOreMechanics");
        goldScript = goldObject.GetComponent<GoldAndOreMechanics>();

        text = gameObject.GetComponent<TextMeshProUGUI>();
        goldCountFrame = GameObject.Find("GoldAmountDisplay");
    }

    private void OnEnable()
    {
        gameObject.transform.localScale = new Vector2(0,0);
        StartCoroutine(PopUpText());
    }

    public GameObject goldCountFrame;

    IEnumerator PopUpText()
    {
        float randomWait1 = Random.Range(0.03f, 0.05f);
        yield return new WaitForSeconds(randomWait1);
        //text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(1f, 1f, 1f));

        //Transform childTransform = text.transform.Find("goldIcon");

        // Start scaling up
        float scaleStartTime = Time.time;
        float scaleEndTime = scaleStartTime + 0.25f;

        float randomTexTSize = Random.Range(0.18f, 0.25f);

        while (Time.time < scaleEndTime)
        {
            float t = (Time.time - scaleStartTime) / (scaleEndTime - scaleStartTime);
            text.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(randomTexTSize, randomTexTSize, randomTexTSize), t);
            //Color childColor = childTransform.GetComponent<Image>().color;
            //childTransform.GetComponent<Image>().color = new Color(childColor.r, childColor.g, childColor.b, Mathf.Lerp(0f, 1f, t));
            yield return null;
        }

        float randomWait2 = Random.Range(0.1f, 0.6f);
        yield return new WaitForSecondsRealtime(randomWait2);

        // Move towards goldCountFrame
        float moveDuration = Random.Range(0.3f, 0.4f);

        if (SetRockScreen.timeLeft < 1.5f) { moveDuration = Random.Range(0.09f, 0.15f); }

        Vector3 startPosition = text.transform.position;
        Vector3 endPosition = goldCountFrame.transform.position;
        float moveStartTime = Time.time;

        while (Time.time < moveStartTime + moveDuration)
        {
            float t = (Time.time - moveStartTime) / moveDuration;
            text.transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        // Ensure final position is exactly at the target
        text.transform.position = endPosition;
        //goldScript.GiveGoldOre(1);
        //goldScript.ScaleGoldAnim();
        ObjectPool.instance.ReturnTextFromPool(gameObject);
    }

    private void OnDisable()
    {
        gameObject.transform.localScale = new Vector2(0, 0);
        StopAllCoroutines();
    }

    public void KeepJustInCase()
    {
             /*
        float moveUpStartTime = Time.time;
        float randomWait3 = Random.Range(0.36f, 0.45f);
        float moveUpDuration = randomWait3; 
        Vector3 initialPosition = text.transform.position;
        Vector3 targetPosition = initialPosition + 8 * Vector3.up * (moveUpDuration - 0.2f); // Adjust the direction as needed

        while (Time.time - moveUpStartTime < moveUpDuration)
        {
            float t = (Time.time - moveUpStartTime) / moveUpDuration;
            text.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);

            if (Time.time - moveUpStartTime > 0.2f)
            {
                float fadeT = (Time.time - moveUpStartTime - 0.2f) / (moveUpDuration - 0.2f);
                text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(1f, 0f, fadeT));
                Color childColor = childTransform.GetComponent<Image>().color;
                childTransform.GetComponent<Image>().color = new Color(childColor.r, childColor.g, childColor.b, Mathf.Lerp(1f, 0f, fadeT));
            }

            yield return null;
        }
        */
    }
}
