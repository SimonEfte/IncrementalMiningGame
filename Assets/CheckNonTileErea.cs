using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNonTileErea : MonoBehaviour
{
    public Collider2D collider2d;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            //StartCoroutine(SetCollider());
        }
    }

    IEnumerator SetCollider()
    {
        collider2d.enabled = false;
        yield return new WaitForSeconds(0.1f);
        collider2d.enabled = true;
    }
}
