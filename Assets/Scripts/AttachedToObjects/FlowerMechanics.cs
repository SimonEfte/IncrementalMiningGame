using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FlowerMechanics : MonoBehaviour
{
    public Transform flower1, flower2, flower3, flower4;

    private void Awake()
    {
        flower1 = transform.Find("flower1");
        flower2 = transform.Find("flower2");
        flower3 = transform.Find("flower3");
        flower4 = transform.Find("flower4");
    }

    private void OnEnable()
    {
        flower1.gameObject.SetActive(false);
        flower2.gameObject.SetActive(false);
        flower3.gameObject.SetActive(false);
        flower4.gameObject.SetActive(false);

        int random = Random.Range(0,4);
        if(random == 0) { flower1.gameObject.SetActive(true); }
        if(random == 1) { flower2.gameObject.SetActive(true); }
        if(random == 2) { flower3.gameObject.SetActive(true); }
        if(random == 3) { flower4.gameObject.SetActive(true); }
    }
}
