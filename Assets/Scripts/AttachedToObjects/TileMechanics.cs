using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMechanics : MonoBehaviour
{
    private void Awake()
    {
        SetRockScreen.startTileZPos -= 0.1f;
        float posZ = gameObject.transform.localPosition.z;
        float posX = gameObject.transform.localPosition.x;
        float posY = gameObject.transform.localPosition.y;

        gameObject.transform.localPosition = new Vector3(posX, posY, posZ);
        //Debug.Log(gameObject.name);
    }

   
}
