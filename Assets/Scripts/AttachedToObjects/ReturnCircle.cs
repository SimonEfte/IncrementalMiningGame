using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnCircle : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        ObjectPool.instance.ReturnCircleColliderFromPool(gameObject);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
