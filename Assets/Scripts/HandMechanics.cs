using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMechanics : MonoBehaviour
{
    public Collider2D mineCollider;
    public Collider2D triangleCollider, squareCollider, hexagonCollider;


    private void OnEnable()
    {
        //mineCollider.enabled = false;
        StartCoroutine(Mine());
    }

    IEnumerator Mine()
    {
        while (true)
        {
            if(LevelMechanics.isEnergiDrinkActive == true) { yield return new WaitForSeconds(TheAnvil.currentMineTime / 2); }
            else { yield return new WaitForSeconds(TheAnvil.currentMineTime); }

            mineCollider.enabled = true;

            if (LevelMechanics.shapeShifter_chosen)
            {
                triangleCollider.enabled = true; squareCollider.enabled = true; hexagonCollider.enabled = true;
            }

            yield return new WaitForSeconds(TheAnvil.collTime);
            mineCollider.enabled = false;

            if (LevelMechanics.shapeShifter_chosen)
            {
                triangleCollider.enabled = false; squareCollider.enabled = false; hexagonCollider.enabled = false;
            }

            yield return null;
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }


}
