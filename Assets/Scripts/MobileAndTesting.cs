using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileAndTesting : MonoBehaviour
{
    public static bool isTesting;
    public static bool isMobile;

    private void Awake()
    {
        isMobile = true;
        isTesting = false;
    }

    private void Start()
    {
        if(isMobile == true)
        {
            Application.targetFrameRate = 60;
        }
    }
}
