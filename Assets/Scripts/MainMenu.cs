using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public SetRockScreen rockScreenScript;
    public TheAnvil anvilScript;
    public TheMine theMineScript;
    public SkillTree skillTreeScript;
    public GoldAndOreMechanics goldAndOreScript;
    public Artifacts artifactScript;
    public LevelMechanics levelScript;
    public TheEnding endingScript;
    public SpawnProjectiles spawnProjcetilesScript;

    public AudioManager audioManager;

    public GameObject theMainMenu, mainManuBackgrounds;

    public Image upgradesBtn, talentsBtn, theAnvilBtn, theMineBtn, artifactsBtn;

    public Sprite selectedYellowBtn, notSelectedSprite;

    public GameObject skillTreeScreen, levelUpScreen, anvilScreen, mineScreen, artifactScreen;
    public static bool isInMainMenu, isInUpgrades, isInTalents, isInTheAnvil, isInTheMine, isInArtifacts;

    public GameObject unlockTalentsBtn, totalTalentPointsFrame, totalMaterialFramesParent, unlockedTalentsParet;

    public GameObject unlockTheMineBtn, theMineProgressBar, theMineMiningSpeedUpgrade, theMineOreUpgrade;

    public GameObject skillTreeBackground, talentBackground, theAnvilBackground, theMineBackground, artifactsBackground, dustParticleParent, backgroundDark;
    public GameObject skillTreeBackground_tImage, talentBackground_tImage, theAnvilBackground_tImage, theMineBackground_tImage, artifactsBackground_tImage;

    public static int currentScreen;
    public float fadeTime;

    public GameObject startScreenCanvas, startScreenBackground;

    public GameObject blockRevealTalent;

    public GameObject talentBtnExcl, anvilBtnExcl, mineBtnExcl, artifactBtnExcl;

    public GameObject backToMainMenuBtn, flags;

    public GameObject talentTurotialFrame, theAnvilTutorialFrame, theMineTutorialFrame, artifactTutorialFrame;
    public GameObject allTalentCardsChosenBlockBtn;

    public GameObject exitGameBtn, resetGameBtn, mainMenuBtn;

    public GameObject hexagonColl, squareColl;

    public GameObject totalFlowersObject;

    public GameObject theMineInfoHover;

    public static bool setTreeMiddle;

    public GameObject skillTreeDrag, skillTreeContent;

    public GameObject lockedTalent1, lockedTalent2, lockedTalent3;

    public GameObject theMineTooltip1, theMineTooltip2;

    public Slider zoomSliderMobile;

    private void Awake()
    {
        fadeTime = 0f;
    }

    #region Start screen - Press play
    public void PlayGame()
    {
        SetSkillTree();
        StartCoroutine(ScaleCircleCoroutine(true, true));
    }
    #endregion

    public void SetSkillTree()
    {
        if (SkillTree.totalSkillTreeUpgradesPurchased < 10) { SkillTreeDrag.defaultZoom = 2.1f; }
        else if (SkillTree.totalSkillTreeUpgradesPurchased < 25) { SkillTreeDrag.defaultZoom = 2.1f; }
        else if (SkillTree.totalSkillTreeUpgradesPurchased < 50) { SkillTreeDrag.defaultZoom = 2f; }
        else if (SkillTree.totalSkillTreeUpgradesPurchased < 75) { SkillTreeDrag.defaultZoom = 1.95f; }
        else if (SkillTree.totalSkillTreeUpgradesPurchased < 100) { SkillTreeDrag.defaultZoom = 1.9f; }
        else if (SkillTree.totalSkillTreeUpgradesPurchased < 125) { SkillTreeDrag.defaultZoom = 1.85f; }
        else if (SkillTree.totalSkillTreeUpgradesPurchased < 150) { SkillTreeDrag.defaultZoom = 1.8f; }
        else if (SkillTree.totalSkillTreeUpgradesPurchased < 175) { SkillTreeDrag.defaultZoom = 1.75f; }
        else if (SkillTree.totalSkillTreeUpgradesPurchased < 200) { SkillTreeDrag.defaultZoom = 1.7f; }
        else
        {
            SkillTreeDrag.defaultZoom = 1.2f;
        }

        if(MobileAndTesting.isMobile == true)
        {
            zoomSliderMobile.value = SkillTreeDrag.defaultZoom;
        }

        skillTreeDrag.transform.localPosition = new Vector2(0, -53);
        skillTreeContent.transform.localPosition = new Vector2(0, 0);

        SkillTreeDrag.targetScale = Vector3.one * SkillTreeDrag.defaultZoom;
        skillTreeDrag.transform.localScale = SkillTreeDrag.targetScale;
    }

    #region Back to main menu
    public void BackToTheMainMenu()
    {
        StartCoroutine(ScaleCircleCoroutine(true, false));
    }
    #endregion

    #region Select screen
    public void SelectScreen(string screenName)
    {
        if (screenName == "Upgrades")
        {
            if (currentScreen == 1) { return; }
        }
        else if (screenName == "TalentsBtn")
        {
            if (currentScreen == 2) { return; }
        }
        else if (screenName == "TheAnvilBtn")
        {
            if (currentScreen == 3) { return; }
        }
        else if (screenName == "TheMineBtn")
        {
            if (currentScreen == 4) { return; }
        }
        else if (screenName == "Artifacts_Btn")
        {
            if (currentScreen == 5) { return; }
        }

        theMineInfoHover.SetActive(false);

        UIClickSound();
        CheckMinePopUps();

        unlockTalentsBtn.SetActive(false);
        totalTalentPointsFrame.SetActive(false);
        totalMaterialFramesParent.SetActive(false);
        unlockedTalentsParet.SetActive(false);
        unlockTheMineBtn.SetActive(false);
        theMineProgressBar.SetActive(false);
        theMineMiningSpeedUpgrade.SetActive(false);
        theMineOreUpgrade.SetActive(false);
        allTalentCardsChosenBlockBtn.SetActive(false);

        isInMainMenu = true;
        skillTreeScreen.SetActive(false); isInUpgrades = false;
        levelUpScreen.SetActive(false); isInTalents = false;
        anvilScreen.SetActive(false); isInTheAnvil = false;
        mineScreen.SetActive(false); isInTheMine = false;
        artifactScreen.SetActive(false); isInArtifacts = false;

        upgradesBtn.sprite = notSelectedSprite;
        talentsBtn.sprite = notSelectedSprite;
        theAnvilBtn.sprite = notSelectedSprite;
        theMineBtn.sprite = notSelectedSprite;
        artifactsBtn.sprite = notSelectedSprite;

        zoomSliderMobile.gameObject.SetActive(false);

        if (MobileAndTesting.isMobile == true)
        {
            theMineTooltip1.SetActive(false);
            theMineTooltip2.SetActive(false);
        }

        if (screenName == "Upgrades")
        {
            if(MobileAndTesting.isMobile == true)
            {
                zoomSliderMobile.gameObject.SetActive(true);
            }

            MainMenu.setTreeMiddle = false;

            blockRevealTalent.SetActive(false);

            dustParticleParent.SetActive(true);
            skillTreeBackground_tImage.SetActive(true);

            if (currentScreen == 1) { return; }
            else { CheckBackgroundsToFade(1); }

            currentScreen = 1;

            totalMaterialFramesParent.SetActive(true);
            upgradesBtn.sprite = selectedYellowBtn;
            skillTreeScreen.SetActive(true); isInUpgrades = true;
        }
        else if (screenName == "TalentsBtn")
        {
          

            SetRockScreen.potionPickaxeStats_increase = 0;

            levelScript.SetTalentTexts();
            if (Tutorial.pressedOkTalent == false && LevelMechanics.level > 0) { talentTurotialFrame.SetActive(true); }

            talentBtnExcl.SetActive(false);

            if (LevelMechanics.isBlockFrameActive == true) { blockRevealTalent.SetActive(true); }
            else { blockRevealTalent.SetActive(false); }

            if(LevelMechanics.cardsLeft == 0)
            {
                allTalentCardsChosenBlockBtn.SetActive(true);
            }

            talentBackground_tImage.SetActive(true);

            if (currentScreen == 2) { return; }
            else { CheckBackgroundsToFade(2); }

            currentScreen = 2;

            unlockTalentsBtn.SetActive(true);
            totalTalentPointsFrame.SetActive(true);
            unlockedTalentsParet.SetActive(true);

            talentsBtn.sprite = selectedYellowBtn;
            levelUpScreen.SetActive(true); isInTalents = true;
            levelScript.SetTalentTexts();

         
        }
        else if (screenName == "TheAnvilBtn")
        {
            if (Tutorial.pressedOkAnvil == false && (SkillTree.improvedPickaxe_1_purchased == true || SkillTree.spawnMoreRocks_3_purchased == true)) 
            { 
                theAnvilTutorialFrame.SetActive(true); 
            }

            TheAnvil.isTheAnvilUnlocked = true;

            anvilBtnExcl.SetActive(false);

            blockRevealTalent.SetActive(false);

            anvilScript.DisplayEquippedAndSetStats(TheAnvil.equippedMineTime, TheAnvil.equippedMinePower, TheAnvil.equipped2XChance, TheAnvil.equippedMiningArea);

            SetRockScreen.potionPickaxeStats_increase = 0;
            anvilScript.CheckPickaxes();

            theAnvilBackground_tImage.SetActive(true);

            if (currentScreen == 3) { return; }
            else { CheckBackgroundsToFade(3); }

            currentScreen = 3;

            totalMaterialFramesParent.SetActive(true);
            theAnvilBtn.sprite = selectedYellowBtn;
            anvilScreen.SetActive(true); isInTheAnvil = true;
        }
        else if (screenName == "TheMineBtn")
        {
            if (Tutorial.pressedOkMine == false && SkillTree.spawnCopper_purchased == true)
            {
                theMineTutorialFrame.SetActive(true);
            }

            theMineInfoHover.SetActive(true);

            mineBtnExcl.SetActive(false);

            blockRevealTalent.SetActive(false);

            theMineBackground.SetActive(true);

            if (currentScreen == 4) { return; }
            else { CheckBackgroundsToFade(4); }

            currentScreen = 4;

            if (TheMine.isTheMineUnlocked == true)
            {
                if (MobileAndTesting.isMobile == true)
                {
                    theMineTooltip1.SetActive(true);
                    theMineTooltip2.SetActive(true);
                }

                unlockTheMineBtn.SetActive(false);
                theMineProgressBar.SetActive(true);
                theMineMiningSpeedUpgrade.SetActive(true);
                theMineOreUpgrade.SetActive(true);
            }
            else 
            { 
                unlockTheMineBtn.SetActive(true);
                theMineProgressBar.SetActive(false);
                theMineMiningSpeedUpgrade.SetActive(false);
                theMineOreUpgrade.SetActive(false);
            }
            totalMaterialFramesParent.SetActive(true);
            theMineBtn.sprite = selectedYellowBtn;
            mineScreen.SetActive(true); isInTheMine = true;
        }
        else if (screenName == "Artifacts_Btn")
        {
            if (Tutorial.pressedOkArtifact == false && Artifacts.artifactsFound > 0)
            {
                artifactTutorialFrame.SetActive(true);
            }

            artifactBtnExcl.SetActive(false);

            blockRevealTalent.SetActive(false);

            artifactsBackground_tImage.SetActive(true);

            if (currentScreen == 5) { return; }
            else { CheckBackgroundsToFade(5); }

            currentScreen = 5;

            artifactsBtn.sprite = selectedYellowBtn;
            artifactScreen.SetActive(true); isInArtifacts = true;
        }

        theMineScript.UpdateChances();

        if (LevelMechanics.isInChoose1 == false)
        {
            lockedTalent1.gameObject.SetActive(true);
            lockedTalent1.transform.localScale = new Vector3(1, 1, 1);
            lockedTalent1.transform.localPosition = new Vector3(0, 0, 0);
            lockedTalent2.gameObject.SetActive(true);
            lockedTalent2.transform.localScale = new Vector3(1, 1, 1);
            lockedTalent2.transform.localPosition = new Vector3(0, 0, 0);
            lockedTalent3.gameObject.SetActive(true);
            lockedTalent3.transform.localScale = new Vector3(1, 1, 1);
            lockedTalent3.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
    #endregion

    #region Check mine pop ups
    public void CheckMinePopUps()
    {
        GameObject[] MinePopUp = GameObject.FindGameObjectsWithTag("MinePopUp");
        foreach (GameObject popUp in MinePopUp)
        {
            if (popUp.activeSelf)
            {
                ObjectPool.instance.ReturnTheMineMaterialFromPool(popUp);
            }
        }
    }
    #endregion

    #region CheckBackgroundsToFade
    public void CheckBackgroundsToFade(int backgroundToFadeIn)
    {
        skillTreeBackground.SetActive(false);
        talentBackground.SetActive(false);
        theAnvilBackground.SetActive(false);
        theMineBackground.SetActive(false);
        artifactsBackground.SetActive(false);

        skillTreeBackground_tImage.SetActive(false);
        talentBackground_tImage.SetActive(false);
        theAnvilBackground_tImage.SetActive(false);
        theMineBackground_tImage.SetActive(false);
        artifactsBackground_tImage.SetActive(false);

        if (backgroundToFadeIn == 1)
        {
            skillTreeBackground.SetActive(true);
            skillTreeBackground_tImage.SetActive(true);
        }
        if (backgroundToFadeIn == 2)
        {
            talentBackground.SetActive(true);
            talentBackground_tImage.SetActive(true);
        }
        if (backgroundToFadeIn == 3)
        {
            theAnvilBackground.SetActive(true);
            theAnvilBackground_tImage.SetActive(true);
        }
        if (backgroundToFadeIn == 4)
        {
            theMineBackground.SetActive(true);
            theMineBackground_tImage.SetActive(true);
        }
        if (backgroundToFadeIn == 5)
        {
            artifactsBackground.SetActive(true);
            artifactsBackground_tImage.SetActive(true);
        }
    }
    #endregion

    #region Fade background and the children
    public IEnumerator SetBackgroundsAlpha(GameObject objectToFade, bool fadeIn)
    {
        if (fadeIn == true) { objectToFade.SetActive(true); }

        float duration = fadeTime;
        float elapsedTime = 0f;

        // Get all Image components in the object and its children
        Image[] images = objectToFade.GetComponentsInChildren<Image>(true); // true includes inactive children

        // Store original colors
        Color[] originalColors = new Color[images.Length];
        for (int i = 0; i < images.Length; i++)
            originalColors[i] = images[i].color;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            float alpha = fadeIn ? t : 1f - t;

            for (int i = 0; i < images.Length; i++)
            {
                Color c = originalColors[i];
                c.a = alpha;
                images[i].color = c;
            }

            elapsedTime += Time.unscaledDeltaTime; // use unscaled time if fading UI during pause
            yield return null;
        }

        // Finalize to exact value
        float finalAlpha = fadeIn ? 1f : 0f;
        for (int i = 0; i < images.Length; i++)
        {
            Color c = originalColors[i];
            c.a = finalAlpha;
            images[i].color = c;
        }

        if(fadeIn == false) { objectToFade.SetActive(false); }
    }
    #endregion

    #region Fade 1 image
    public IEnumerator FadeSingleImage(GameObject target, bool fadeIn, float targetAlpha)
    {
        if(fadeIn == true) { target.SetActive(true); }

        float duration = fadeTime;
        float elapsedTime = 0f;

        Image image = target.GetComponent<Image>();

        Color originalColor = image.color;
        float startAlpha = fadeIn ? 0f : targetAlpha;
        float endAlpha = fadeIn ? targetAlpha : 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, endAlpha, t);

            Color c = originalColor;
            c.a = currentAlpha;
            image.color = c;

            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        Color finalColor = originalColor;
        finalColor.a = endAlpha;
        image.color = finalColor;

        if (fadeIn == false) { target.SetActive(false); }
    }
    #endregion

    #region update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenSettings();
        }
    }
    #endregion

    #region Keep on mining button inside main menu
    public GameObject mainMenuScreen;
    public static bool isInTransition;
    public static bool pressedKeepOnMining;

    public void KeepOnMiningBtn()
    {
        pressedKeepOnMining = true;
        rockScreenScript.SetUiStuff();

        isInUpgrades = false;
        isInTalents = false;
        isInTheAnvil = false;
        isInTheMine = false;
        isInArtifacts = false;
    
        rockScreenScript.KeepOnMining_MainMenu();
        isInMainMenu = false;
    }
    #endregion

    #region open settings
    public GameObject settingsFrame;
    public void OpenSettings()
    {
        if (SetRockScreen.isInMiningSession) { return; }
        if (SetRockScreen.isInEnding) { return; }
        if (AllStats.isInStats == true) { return; }
        if (creditsFrame.activeInHierarchy) { return; }
        if (isInTransition) { return; }
        if (pressedKeepOnMining) { return; }
        if (SkillTree.isInEndlessPopUp) { return; }

        if(MobileAndTesting.isMobile == false)
        {
            flags.transform.localScale = new Vector2(0.84f, 0.84f);
            exitGameBtn.transform.localScale = new Vector2(1.55f, 1.55f);
            mainMenuBtn.transform.localScale = new Vector2(0.59f, 0.59f);
            resetGameBtn.transform.localScale = new Vector2(0.59f, 0.59f);
        }

        UIClickSound();
        if (settingsFrame.activeInHierarchy == true) { settingsFrame.SetActive(false); Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); }
        else { settingsFrame.SetActive(true); }
    }
    #endregion

    #region Scale circle
    public GameObject circleObject;
    public GameObject transitionBlock;

    private IEnumerator ScaleCircleCoroutine(bool scaleUp, bool startGame)
    {
        isInTransition = true;
        circleObject.SetActive(true);
        transitionBlock.SetActive(true);

        audioManager.Play("Transition");

        float scaleDuration = 0.4f;

        float startScale = scaleUp ? 0f : 26f;
        float endScale = scaleUp ? 26f : 0f;
        float elapsed = 0f;

        Vector3 initialScale = new Vector3(startScale, startScale, startScale);
        Vector3 targetScale = new Vector3(endScale, endScale, endScale);

        circleObject.transform.localScale = initialScale;

        while (elapsed < scaleDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / scaleDuration);
            circleObject.transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            yield return null;
        }

        if (SetRockScreen.isInEnding == false)
        {
            if (scaleUp == false)
            {
                endingScript.SoundVolumeSet("MainMenuMusic", true, TheEnding.gameMusicFullVolume - 0.3f, TheEnding.gameMusicFullVolume, 0.1f, false);
            }
            else
            {
                endingScript.SoundVolumeSet("MainMenuMusic", true, TheEnding.gameMusicFullVolume, TheEnding.gameMusicFullVolume - 0.3f, 0.1f, false);
            }
        }

        if (scaleUp == true && startGame == true)
        {
            if(MobileAndTesting.isMobile == false)
            {
                flags.transform.localPosition = new Vector2(-414, -339);
            }

            backToMainMenuBtn.SetActive(true);

            startScreenCanvas.SetActive(false);
            startScreenBackground.SetActive(false);

            yield return new WaitForSeconds(0.5f);

            if (Tutorial.pressedOkMiningSession == true)
            {
                mainManuBackgrounds.SetActive(true);
                theMainMenu.SetActive(true);
                dustParticleParent.SetActive(true);
                skillTreeBackground_tImage.SetActive(true);

                CheckBackgroundsToFade(1);

                currentScreen = 0;

                SelectScreen("Upgrades");

                totalMaterialFramesParent.SetActive(true);
                upgradesBtn.sprite = selectedYellowBtn;
                skillTreeScreen.SetActive(true); isInUpgrades = true;
            }

            StartCoroutine(ScaleCircleCoroutine(false, true));
        }

        if (scaleUp == true && startGame == false)
        {
            skillTreeScreen.SetActive(true); isInUpgrades = true;
            levelUpScreen.SetActive(false); isInTalents = false;
            anvilScreen.SetActive(false); isInTheAnvil = false;
            mineScreen.SetActive(false); isInTheMine = false;
            artifactScreen.SetActive(false); isInArtifacts = false;

            unlockTheMineBtn.SetActive(false);
            theMineProgressBar.SetActive(false);
            theMineMiningSpeedUpgrade.SetActive(false);
            theMineOreUpgrade.SetActive(false);

            unlockTalentsBtn.SetActive(false);
            totalTalentPointsFrame.SetActive(false);
            unlockedTalentsParet.SetActive(false);

            settingsFrame.SetActive(false);

            if (MobileAndTesting.isMobile == false)
            {
                flags.transform.localPosition = new Vector2(-426, -431);
            }

            backToMainMenuBtn.SetActive(false);

            startScreenCanvas.SetActive(true);
            startScreenBackground.SetActive(true);

            yield return new WaitForSeconds(0.5f);
            StartCoroutine(ScaleCircleCoroutine(false, true));
        }

        circleObject.transform.localScale = targetScale;

        if (scaleUp == false)
        {
            isInTransition = false;
            circleObject.SetActive(false);
            transitionBlock.SetActive(false);
        }
    }
    #endregion

    #region exit game
    public void ExitGame()
    {
        Application.Quit();
    }
    #endregion

    public GameObject statsFrame;
    public AllStats statsScript;

    public void OpenStats()
    {
        UIClickSound();
        if (statsFrame.activeInHierarchy == true) 
        { 
            statsFrame.SetActive(false); AllStats.isInStats = false;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        else { statsScript.CheckQuestionMarkText(); statsFrame.SetActive(true); AllStats.isInStats = true; }
    }

    public GameObject creditsFrame;
    public void OpenCredits()
    {
        UIClickSound();
        if (creditsFrame.activeInHierarchy == true) { creditsFrame.SetActive(false); Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); }
        else { creditsFrame.SetActive(true); }
    }

    public void UIClickSound()
    {
        if(isInTransition == false)
        {
            audioManager.Play("UI_Click1");
        }
    }

    public GameObject resetFrame;

    public GameObject resetYesBtn, resetNoBtn;

    public void ResetBtn(bool open)
    {
        UIClickSound();

        resetYesBtn.transform.localScale = new Vector2(1,1);
        resetNoBtn.transform.localScale = new Vector2(1, 1);

        if (open == true) 
        {
            resetFrame.SetActive(true);

        }
        else
        {
            resetFrame.SetActive(false);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    public void ResetTheEntireGame()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        UIClickSound();
        StartCoroutine(ResetTransition(true));
    }

    private IEnumerator ResetTransition(bool scaleUp)
    {
        circleObject.SetActive(true);
        transitionBlock.SetActive(true);

        audioManager.Play("Transition");

        float scaleDuration = 0.4f;

        float startScale = scaleUp ? 0f : 26f;
        float endScale = scaleUp ? 26f : 0f;
        float elapsed = 0f;

        Vector3 initialScale = new Vector3(startScale, startScale, startScale);
        Vector3 targetScale = new Vector3(endScale, endScale, endScale);

        circleObject.transform.localScale = initialScale;

        while (elapsed < scaleDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / scaleDuration);
            circleObject.transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            yield return null;
        }

        if(scaleUp == true)
        {
            resetFrame.SetActive(false);

            //Reset everything

            theMineInfoHover.SetActive(false);

            skillTreeScript.ResetSkillTree();
            statsScript.ResetStats();
            artifactScript.ResetArtifacts();
            goldAndOreScript.ResetBars();
            levelScript.ResetLevel();
            theMineScript.ResetTheMine();
            anvilScript.ResetAnvil();
            spawnProjcetilesScript.ResetSpanwProjeciles();
            skillTreeScript.SkillTreePrices();

            hexagonColl.SetActive(false);
            squareColl.SetActive(false);
            totalFlowersObject.gameObject.SetActive(false);

            TheEnding.isEndingCompleted = false;

            levelUpScreen.SetActive(false); isInTalents = false;
            anvilScreen.SetActive(false); isInTheAnvil = false;
            mineScreen.SetActive(false); isInTheMine = false;
            artifactScreen.SetActive(false); isInArtifacts = false;

            settingsFrame.SetActive(false);

            skillTreeScreen.SetActive(true);
            skillTreeBackground.SetActive(true);
            skillTreeBackground_tImage.SetActive(true);

            startScreenBackground.SetActive(true);
            startScreenCanvas.SetActive(true);

            isInUpgrades = false;
            isInTalents = false;
            isInTheAnvil = false;
            isInTheMine = false;
            isInArtifacts = false;

            yield return new WaitForSeconds(0.7f);

            StartCoroutine(ResetTransition(false));
        }

        circleObject.transform.localScale = targetScale;

        if (scaleUp == false)
        {
            circleObject.SetActive(false);
            transitionBlock.SetActive(false);
        }
    }
}
