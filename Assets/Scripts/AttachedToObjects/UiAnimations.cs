using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnimations : MonoBehaviour
{
    public float moveDistance = 0.5f;    
    public float moveDuration = 1.0f;   

    private Vector3 startPosition;
    private void Awake()
    {
        moveDistance = 0.5f;
        moveDuration = 1.0f;
    }

    private void OnEnable()
    {
        startPosition = transform.position;
        StartCoroutine(FloatLoop());
    }

    IEnumerator FloatLoop()
    {
        while (true)
        {
            // Move down
            yield return MoveToPosition(startPosition - Vector3.up * moveDistance, moveDuration);
            // Move up past the starting point
            yield return MoveToPosition(startPosition + Vector3.up * moveDistance, moveDuration);
            // Return to center
            yield return MoveToPosition(startPosition, moveDuration);
        }
    }

    IEnumerator MoveToPosition(Vector3 target, float duration)
    {
        Vector3 initialPosition = transform.position;
        float time = 0f;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(initialPosition, target, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }
}
