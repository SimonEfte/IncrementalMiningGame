using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMechanics : MonoBehaviour
{
    public Transform grassParent;

    private void Awake()
    {
        grassParent = transform.Find("FullGrass");

        SetRockScreen.grassLayer += 1;

        SetRockScreen.startTileZPos -= 0.1f;
        float posZ = gameObject.transform.localPosition.z;
        float posX = gameObject.transform.localPosition.x;
        float posY = gameObject.transform.localPosition.y;

        gameObject.transform.localPosition = new Vector3(posX, posY, posZ);

        gameObject.GetComponent<SpriteRenderer>().sortingOrder = SetRockScreen.grassLayer;

        //Debug.Log(gameObject.name);
    }
}
