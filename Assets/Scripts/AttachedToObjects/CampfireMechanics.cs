using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireMechanics : MonoBehaviour
{
    public Collider2D collider2d;

    public ParticleSystem fire;

    private void OnEnable()
    {
        fire.Play();
        StartCoroutine(BurnCollider());
    }

    IEnumerator BurnCollider()
    {
        while (true)
        {
            collider2d.enabled = false;

            yield return new WaitForSeconds(0.28f);

            collider2d.enabled = true;

            yield return new WaitForSeconds(0.06f);

            collider2d.enabled = false;
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
