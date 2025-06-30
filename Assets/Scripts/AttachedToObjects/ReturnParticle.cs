using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnParticle : MonoBehaviour
{
    public bool isRockParticle;

    private void OnDisable()
    {
        if (isRockParticle)
        {
            ObjectPool.instance.ReturnRockParticleToPool(gameObject);
        }
    }
}
