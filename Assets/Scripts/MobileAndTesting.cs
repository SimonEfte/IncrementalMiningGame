using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileAndTesting : MonoBehaviour
{
    public static bool isTesting;
    public static bool isMobile;
    public bool isThisIos, isThisAndroid;

    public GameObject moreGooglePlay, moreAppStore, youtube, discord, steam;

    private void Awake()
    {
        isMobile = false;
        isTesting = false;
        isThisIos = false;
        isThisAndroid = false;
    }

    private void Start()
    {
        if(isMobile == true)
        {
            Application.targetFrameRate = 60;

            if(isThisIos == true)
            {
                moreAppStore.SetActive(true);
            }
            if(isThisAndroid == true)
            {
                moreGooglePlay.SetActive(true);
            }

            steam.transform.localPosition = new Vector2(267, 395);
            discord.transform.localPosition = new Vector2(87, 395);
            youtube.transform.localPosition = new Vector2(-93, 395);
            moreAppStore.transform.localPosition = new Vector2(-263, 395);
            moreGooglePlay.transform.localPosition = new Vector2(-263, 395);
        }
        else
        {
            moreGooglePlay.SetActive(false);
            moreAppStore.SetActive(false);
        }
    }

    public void MoreAppStoreGames()
    {
        Application.OpenURL("https://apps.apple.com/us/developer/simon-eftest%C3%B8l/id1782530055");
    }
    public void MoreGooglePlayGames()
    {
        Application.OpenURL("https://play.google.com/store/apps/developer?id=EagleEye+Games+Norway");
    }
}
