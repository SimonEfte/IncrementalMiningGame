using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour, IDataPersistence
{
    public SetRockScreen setRockScreenScript;
    public AudioManager audioManager;

    public GameObject talentButton, theAnvilButton, theMineButton, arifactButton;
    public GameObject talentExcl, anvilExcl, mineExcl, arifactExcl;

    public GameObject miningSessionTutorialFrame, oreAndCraftingTurotialFrame, talentTurotialFrame, theAnvilTutorialFrame, theMineTutorialFrame, artifactTutorialFrame;

    public static bool pressedOkMiningSession, pressedOkCraftingTurotialFrame, pressedOkTalent, pressedOkAnvil, pressedOkMine, pressedOkArtifact;

    public GameObject mainMenu, startScreen, startScreenBackground, mainMenuDark;

    private void Awake()
    {
        startScreen.SetActive(true); startScreenBackground.SetActive(true);
    }

    private void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        talentButton.SetActive(false); theAnvilButton.SetActive(false); theMineButton.SetActive(false); arifactButton.SetActive(false);

        if (MobileAndTesting.isTesting == false)
        {
            if (pressedOkMiningSession == false)
            { 
                miningSessionTutorialFrame.SetActive(true);
                mainMenu.SetActive(false);
                mainMenuDark.SetActive(false);
            }
            else 
            {
                miningSessionTutorialFrame.SetActive(false);
                mainMenu.SetActive(true);
                mainMenuDark.SetActive(true);
            }
        }
        else
        {
            talentButton.SetActive(true); theAnvilButton.SetActive(true); theMineButton.SetActive(true); arifactButton.SetActive(true);
        }

        if (pressedOkTalent) { talentButton.SetActive(true); }
        if (pressedOkAnvil) { theAnvilButton.SetActive(true); }
        if (pressedOkMine) { theMineButton.SetActive(true); }
        if (pressedOkArtifact) { arifactButton.SetActive(true); }
    }

    public void SetTutorial(int tutorialNumber)
    {
        if(MobileAndTesting.isTesting == true) { return; }

        if(tutorialNumber == 1)
        {
            oreAndCraftingTurotialFrame.SetActive(true);
        }
        if (tutorialNumber == 2)
        {
            talentExcl.SetActive(true);
            talentButton.SetActive(true);
        }
        if (tutorialNumber == 3)
        {
            anvilExcl.SetActive(true);
            theAnvilButton.SetActive(true);
        }
        if (tutorialNumber == 4)
        {
            mineExcl.SetActive(true);
            theMineButton.SetActive(true);
        }
        if (tutorialNumber == 5)
        {
            arifactExcl.SetActive(true);
            arifactButton.SetActive(true);
        }
    }

    public void TurotialOkBtn(int tutorialNumber)
    {
        audioManager.Play("UI_Click1");

        if(tutorialNumber == 0)
        {
            miningSessionTutorialFrame.SetActive(false);
            pressedOkMiningSession = true;
            setRockScreenScript.StartWaveTutorialBtn();
        }

        if (tutorialNumber == 1)
        {
            oreAndCraftingTurotialFrame.SetActive(false);
            pressedOkCraftingTurotialFrame = true;
        }

        if (tutorialNumber == 2)
        {
            talentTurotialFrame.SetActive(false);
            pressedOkTalent = true;
        }

        if (tutorialNumber == 3)
        {
            theAnvilTutorialFrame.SetActive(false);
            pressedOkAnvil = true;
        }

        if (tutorialNumber == 4)
        {
            theMineTutorialFrame.SetActive(false);
            pressedOkMine = true;
        }

        if (tutorialNumber == 5)
        {
            artifactTutorialFrame.SetActive(false);
            pressedOkArtifact = true;
        }
    }

    #region Load Data
    public void LoadData(GameData data)
    {
        pressedOkMiningSession = data.pressedOkMiningSession;
        pressedOkCraftingTurotialFrame = data.pressedOkCraftingTurotialFrame;
        pressedOkTalent = data.pressedOkTalent;
        pressedOkAnvil = data.pressedOkAnvil;
        pressedOkMine = data.pressedOkMine;
        pressedOkArtifact = data.pressedOkArtifact;
    }
    #endregion

    #region Save Data
    public void SaveData(ref GameData data)
    {
        data.pressedOkMiningSession = pressedOkMiningSession;
        data.pressedOkCraftingTurotialFrame = pressedOkCraftingTurotialFrame;
        data.pressedOkTalent = pressedOkTalent;
        data.pressedOkAnvil = pressedOkAnvil;
        data.pressedOkMine = pressedOkMine;
        data.pressedOkArtifact = pressedOkArtifact;
    }
    #endregion
}
