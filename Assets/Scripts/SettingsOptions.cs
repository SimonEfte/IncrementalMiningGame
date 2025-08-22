using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsOptions : MonoBehaviour
{
    private List<Resolution> resolutions = new List<Resolution>();
    public TMP_Dropdown resolutionDropdown;
    public AudioManager audioManager;

    private void Awake()
    {
        #region resolutions and fullscreen
        triggerResolution = true;

        if (!PlayerPrefs.HasKey("saveIndex"))
        {
            FindResolutionIndex();
        }
        else
        {
            resolutionIndexSave = PlayerPrefs.GetInt("saveIndex");
        }

        if (!PlayerPrefs.HasKey("SaveFullScreen"))
        {
            saveFullsScreen = 0;
        }
        else
        {
            saveFullsScreen = PlayerPrefs.GetInt("SaveFullScreen");
        }
        
        if(MobileAndTesting.isMobile == false)
        {
            if (saveFullsScreen == 1)
            {
                fullScreenCheckMark.SetActive(false);
                Screen.fullScreenMode = FullScreenMode.Windowed;
            }
            else
            {
                fullScreenCheckMark.SetActive(true);
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            }

            if (!PlayerPrefs.HasKey("ScreenWidth"))
            {
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            }
            else
            {
                saveWidth = PlayerPrefs.GetInt("ScreenWidth");
                saveHeight = PlayerPrefs.GetInt("ScreenHeight");
                Screen.SetResolution(saveWidth, saveHeight, Screen.fullScreenMode);
            }
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }

       
        #endregion

        StartCoroutine(Wait());
    }

    public GameObject fullscreenBtn, flags, mainMenuBTN, settingsFrame;

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);

        if(MobileAndTesting.isMobile == true)
        {
            settingsFrame.transform.localScale = new Vector2(1.43f, 1.43f);

            flags.transform.localPosition = new Vector2(0, -33);
            flags.transform.localScale = new Vector2(1.6f, 1.6f);

            mainMenuBTN.transform.localPosition = new Vector2(0, -233);
            mainMenuBTN.transform.localScale = new Vector2(0.8f, 0.8f);

            resolutionDropdown.gameObject.SetActive(false);
            fullscreenBtn.gameObject.SetActive(false);
        }

        triggerResolution = false;
    }

    private void Start()
    {
        #region Resolution
        // Define a list of supported resolutions
        resolutions = new List<Resolution>
        {
            new Resolution { width = 800, height = 600 },
            new Resolution { width = 1024, height = 768 },
            new Resolution { width = 1280, height = 720 },
            new Resolution { width = 1280, height = 800 },
            new Resolution { width = 1280, height = 1024 },
            new Resolution { width = 1366, height = 768 },
            new Resolution { width = 1600, height = 900 },
            new Resolution { width = 1920, height = 1080 },
            new Resolution { width = 1920, height = 1200 },
            new Resolution { width = 2560, height = 1440 },
            new Resolution { width = 2560, height = 1600 },
            new Resolution { width = 2560, height = 1080 },
            new Resolution { width = 3440, height = 1440 },
            new Resolution { width = 3840, height = 1440 },
            new Resolution { width = 3840, height = 2160 },
            new Resolution { width = 3840, height = 2400 }
            // Add any other resolutions you want to support here
        };

        // Add the supported resolutions to the dropdown
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Count; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        resolutionDropdown.value = resolutionIndexSave;
        #endregion
    }

    #region resolution 
    public int resolutionIndexSave;
    public bool triggerResolution;
    public int saveHeight, saveWidth;
    public static int saveFullsScreen;

    public void SetResolution(int resolutionIndex)
    {
        if (triggerResolution == false)
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

            saveWidth = resolution.width;
            saveHeight = resolution.height;

            PlayerPrefs.SetInt("ScreenWidth", saveWidth);
            PlayerPrefs.SetInt("ScreenHeight", saveHeight);

            resolutionIndexSave = resolutionIndex;
            PlayerPrefs.SetInt("saveIndex", resolutionIndexSave);
        }
    }

    public TextMeshProUGUI fullscreenText;
    public GameObject fullScreenCheckMark;

    public void SetFullSCreen()
    {
        audioManager.Play("UI_Click1");

        if (saveFullsScreen == 0)
        {
            fullScreenCheckMark.SetActive(false);
            Screen.fullScreenMode = FullScreenMode.Windowed;

            saveFullsScreen = 1;
            PlayerPrefs.SetInt("SaveFullScreen", saveFullsScreen);

        }
        else
        {
            fullScreenCheckMark.SetActive(true);
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;

            #region Check index and stuff

            int width = 0;
            int height = 0;

            int originalWidth = 0;
            int originalHeight = 0;

            if (resolutionIndexSave == 0)
            {
                width = 1024; height = 768; // index 1
                Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
                originalWidth = 600; originalHeight = 800; // index 0
            }
            if (resolutionIndexSave == 1)
            {
                width = 600; height = 800; // index 0
                Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
                originalWidth = 1024; originalHeight = 768; // index 1
            }
            if (resolutionIndexSave == 2)
            {
                width = 1024; height = 768;
                Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
                originalWidth = 1280; originalHeight = 720;
            }
            if (resolutionIndexSave == 3)
            {
                width = 1280; height = 720;
                Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
                originalWidth = 1280; originalHeight = 800;
            }
            if (resolutionIndexSave == 4)
            {
                width = 1280; height = 800;
                Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
                originalWidth = 1280; originalHeight = 1024;
            }
            if (resolutionIndexSave == 5)
            {
                width = 1280; height = 1024;
                Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
                originalWidth = 1366; originalHeight = 768;
            }
            if (resolutionIndexSave == 6)
            {
                width = 1366; height = 768;
                Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
                originalWidth = 1600; originalHeight = 900;
            }
            if (resolutionIndexSave == 7)
            {
                width = 1600; height = 900;
                Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
                originalWidth = 1920; originalHeight = 1080;
            }
            if (resolutionIndexSave == 8)
            {
                width = 1920; height = 1080;
                Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
                originalWidth = 1920; originalHeight = 1200;
            }
            if (resolutionIndexSave == 9)
            {
                width = 1920; height = 1200;
                Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
                originalWidth = 2560; originalHeight = 1440;
            }
            if (resolutionIndexSave == 10)
            {
                width = 2560; height = 1440;
                Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
                originalWidth = 2560; originalHeight = 1600;
            }
            if (resolutionIndexSave == 11)
            {
                width = 2560; height = 1600;
                Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
                originalWidth = 2560; originalHeight = 1080;
            }
            if (resolutionIndexSave == 12)
            {
                width = 2560; height = 1080;
                Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
                originalWidth = 3440; originalHeight = 1440;
            }
            if (resolutionIndexSave == 13)
            {
                width = 3440; height = 1440;
                Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
                originalWidth = 3840; originalHeight = 1440;
            }
            if (resolutionIndexSave == 14)
            {
                width = 3840; height = 1440;
                Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
                originalWidth = 3840; originalHeight = 2160;
            }
            if (resolutionIndexSave == 15)
            {
                width = 3840; height = 2160;
                Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
                originalWidth = 3840; originalHeight = 2400;
            }

            Screen.SetResolution(originalWidth, originalHeight, FullScreenMode.FullScreenWindow);
            #endregion

            saveFullsScreen = 0;
            PlayerPrefs.SetInt("SaveFullScreen", saveFullsScreen);
        }
    }

    public void FindResolutionIndex()
    {
        if (Screen.width == 600 && Screen.height == 800) { resolutionIndexSave = 0; }
        if (Screen.width == 1024 && Screen.height == 768) { resolutionIndexSave = 1; }
        if (Screen.width == 1280 && Screen.height == 720) { resolutionIndexSave = 2; }
        if (Screen.width == 1280 && Screen.height == 800) { resolutionIndexSave = 3; }
        if (Screen.width == 1280 && Screen.height == 1024) { resolutionIndexSave = 4; }
        if (Screen.width == 1366 && Screen.height == 768) { resolutionIndexSave = 5; }
        if (Screen.width == 1600 && Screen.height == 900) { resolutionIndexSave = 6; }
        if (Screen.width == 1920 && Screen.height == 1080) { resolutionIndexSave = 7; }
        if (Screen.width == 1920 && Screen.height == 1200) { resolutionIndexSave = 8; }
        if (Screen.width == 2560 && Screen.height == 1440) { resolutionIndexSave = 9; }
        if (Screen.width == 2560 && Screen.height == 1600) { resolutionIndexSave = 10; }
        if (Screen.width == 2560 && Screen.height == 1080) { resolutionIndexSave = 11; }
        if (Screen.width == 3440 && Screen.height == 1440) { resolutionIndexSave = 12; }
        if (Screen.width == 3840 && Screen.height == 1440) { resolutionIndexSave = 13; }
        if (Screen.width == 3840 && Screen.height == 2160) { resolutionIndexSave = 14; }
        if (Screen.width == 3840 && Screen.height == 2400) { resolutionIndexSave = 15; }
    }
    #endregion

    public void OpenYoutube()
    {
        Application.OpenURL("https://www.youtube.com/@EagleEyeGames");
    }

    public void OpenDiscord()
    {
        Application.OpenURL("https://discord.gg/qrBGyWkCgJ");
    }

    public void OpenSteam()
    {
        Application.OpenURL("https://store.steampowered.com/curator/43674917");
    }
}
