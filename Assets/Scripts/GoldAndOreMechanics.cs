using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GoldAndOreMechanics : MonoBehaviour, IDataPersistence
{
    public TextMeshProUGUI goldText_MineScreen, goldBarText_mainMenu;
    public TextMeshProUGUI copperText_MineScreen, copperBarText_mainMenu;
    public TextMeshProUGUI ironText_MineScreen, ironBarText_mainMenu;
    public TextMeshProUGUI cobaltText_MineScreen, cobaltBarText_mainMenu;
    public TextMeshProUGUI uraniumText_MineScreen, uraniumBarText_mainMenu;
    public TextMeshProUGUI ismiumText_MineScreen, ismiumBarText_mainMenu;
    public TextMeshProUGUI iridiumText_MineScreen,  iridiumBarText_mainMenu;
    public TextMeshProUGUI painiteText_MineScreen, painiteBarText_mainMenu;

    public static double totalGoldore, totalGoldBars;
    public static double totalCopperOre, totalCopperBars;
    public static double totalIronOre, totalIronBars;
    public static double totalCobaltOre, totalCobaltBars;
    public static double totalUraniumOre, totalUraniumBars;
    public static double totalIsmiumOre, totalIsmiumBar;
    public static double totalIridiumOre, totalIridiumBars;
    public static double totalPainiteOre, totalPainiteBars;

    int goldSackIncrement;

    private void Start()
    {
        totalGoldore = 0;

        StartCoroutine(Wait());
    }

    bool checkUpdate;

    IEnumerator Wait()
    {
        checkUpdate = false;
        yield return new WaitForSeconds(0.1f);

        //totalGoldBars = 10000;

        SetTotalResourcesText();

        yield return new WaitForSeconds(1f);

        //totalGoldBars = 1000000000;
        //totalGoldBars = 93;
        //totalIronBars = 1000000000;
        //totalCopperBars = 1000000000;
        // totalCobaltBars = 1000000000;
        // totalUraniumBars = 1000000000;
        // totalIsmiumBar = 1000000000;
        // totalIridiumBars = 1000000000;
        // totalPainiteBars = 1000000000;

        //totalGoldBars += 0.494f;

        checkUpdate = true;
    }

    private void Update()
    {
        if(checkUpdate == true)
        {
            if (totalGoldBars < 0) { totalGoldBars = 0; }
            if (totalCopperBars < 0) { totalCopperBars = 0; }
            if (totalIronBars < 0) { totalIronBars = 0; }
            if (totalCobaltBars < 0) { totalCobaltBars = 0; }
            if (totalUraniumBars < 0) { totalUraniumBars = 0; }
            if (totalIsmiumBar < 0) { totalIsmiumBar = 0; }
            if (totalIridiumBars < 0) { totalIridiumBars = 0; }
            if (totalPainiteBars < 0) { totalPainiteBars = 0; }
        }
    }

    public void GiveMaterialOre(int materialType, int materialAmount)
    {
        bool doubledMaterial = false;

        if (LevelMechanics.itsHammerTime_chosen)
        {
            if(LevelMechanics.rocksMinedByHammer > 0)
            {
                materialAmount *= 2; AllStats.doubleOreGained += 1;
                LevelMechanics.rocksMinedByHammer -= 1;
                doubledMaterial = true;
            }
        }

        if (Artifacts.goldStack_found)
        {
            int goldToGive = 25;

            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                goldToGive = 22;
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { goldToGive = 23; }
                if (Artifacts.rune_found) { goldToGive = 24; }
            }

            //Debug.Log(goldToGive);

            goldSackIncrement += 1;
            if(goldSackIncrement >= goldToGive)
            {
                goldSackIncrement = 0;
                materialAmount *= 2;
                AllStats.doubleOreGained += 1;
                doubledMaterial = true;
            }
        }

        float random2XXP = Random.Range(0, 100);
        if (random2XXP < (SkillTree.doubleXpAndGoldChance + SetRockScreen.potionDoubleChance_increase))
        {
            if(doubledMaterial == false)
            {
                materialAmount *= 2; AllStats.doubleOreGained += 1;
            }
        }

        float totalIncrease = SkillTree.materialsTotalWorth + SetRockScreen.potionMaterialWorthMore_increase;

        switch (materialType)
        {
            case 1: // Gold
                totalGoldore += materialAmount * totalIncrease;
                goldText_MineScreen.text = FormatNumbers.FormatPoints(totalGoldore);
                break;

            case 2: // Copper
                totalCopperOre += materialAmount * totalIncrease;
                copperText_MineScreen.text = FormatNumbers.FormatPoints(totalCopperOre);
                break;

            case 3: // Silver
                totalIronOre += materialAmount * totalIncrease;
                ironText_MineScreen.text = FormatNumbers.FormatPoints(totalIronOre);
                break;

            case 4: // Cobalt
                totalCobaltOre += materialAmount * totalIncrease;
                cobaltText_MineScreen.text = FormatNumbers.FormatPoints(totalCobaltOre);
                break;

            case 5: // Uranium
                totalUraniumOre += materialAmount * totalIncrease;
                uraniumText_MineScreen.text = FormatNumbers.FormatPoints(totalUraniumOre);
                break;

            case 6: // Ismium
                totalIsmiumOre += materialAmount * totalIncrease;
                ismiumText_MineScreen.text = FormatNumbers.FormatPoints(totalIsmiumOre);
                break;

            case 7: // Iridium
                totalIridiumOre += materialAmount * totalIncrease;
                iridiumText_MineScreen.text = FormatNumbers.FormatPoints(totalIridiumOre);
                break;

            case 8: // Painite
                totalPainiteOre += materialAmount * totalIncrease;
                painiteText_MineScreen.text = FormatNumbers.FormatPoints(totalPainiteOre);
                break;
        }

        AllStats.oresMined += materialAmount * totalIncrease;
    }

    public void GiveGoldBar(int materialAmount, int materialType)
    {
        float totalIncrease = SkillTree.materialsTotalWorth + SetRockScreen.potionMaterialWorthMore_increase;

        switch (materialType)
        {
            case 1: // Gold
                totalGoldBars += materialAmount * totalIncrease; 
                ScaleTotalGoldText(goldBarText_mainMenu);
                break;

            case 2: // Copper
                totalCopperBars += materialAmount * totalIncrease;
                ScaleTotalGoldText(copperBarText_mainMenu);
                break;

            case 3: // Silver
                totalIronBars += materialAmount * totalIncrease;
                ScaleTotalGoldText(ironBarText_mainMenu);
                break;

            case 4: // Cobalt
                totalCobaltBars += materialAmount * totalIncrease;
                ScaleTotalGoldText(cobaltBarText_mainMenu);
                break;

            case 5: // Uranium
                totalUraniumBars += materialAmount * totalIncrease;
                ScaleTotalGoldText(uraniumBarText_mainMenu);
                break;

            case 6: // Ismium
                totalIsmiumBar += materialAmount * totalIncrease;
                ScaleTotalGoldText(ismiumBarText_mainMenu);
                break;

            case 7: // Iridium
                totalIridiumBars += materialAmount * totalIncrease;
                ScaleTotalGoldText(iridiumBarText_mainMenu);
                break;

            case 8: // Painite
                totalPainiteBars += materialAmount * totalIncrease;
                ScaleTotalGoldText(painiteBarText_mainMenu);
                break;
        }

        AllStats.bardMinedTHEMINE += materialAmount * totalIncrease;

        SetTotalResourcesText();
    }

    public void ScaleTotalGoldText(TextMeshProUGUI text)
    {
        scaleGoldTextCoroutine = StartCoroutine(ScaleGoldTextAnim(text, 1f));
    }

    public void SetTotalResourcesText()
    {
        goldBarText_mainMenu.text = FormatNumbers.FormatPoints(totalGoldBars);
        copperBarText_mainMenu.text = FormatNumbers.FormatPoints(totalCopperBars);
        ironBarText_mainMenu.text = FormatNumbers.FormatPoints(totalIronBars);
        cobaltBarText_mainMenu.text = FormatNumbers.FormatPoints(totalCobaltBars);
        uraniumBarText_mainMenu.text = FormatNumbers.FormatPoints(totalUraniumBars);
        ismiumBarText_mainMenu.text = FormatNumbers.FormatPoints(totalIsmiumBar);
        iridiumBarText_mainMenu.text = FormatNumbers.FormatPoints(totalIridiumBars);
        painiteBarText_mainMenu.text = FormatNumbers.FormatPoints(totalPainiteBars);
    }

    #region Scale gold text an anim
    public Coroutine scaleGoldTextCoroutine;

    public void ScaleGoldAnim(int materialType)
    {
        TextMeshProUGUI targetText = null;

        switch (materialType)
        {
            case 1: 
                targetText = goldText_MineScreen;
                break;
            case 2:
                targetText = copperText_MineScreen;
                break;
            case 3: 
                targetText = ironText_MineScreen;
                break;
            case 4: 
                targetText = cobaltText_MineScreen;
                break;
            case 5: 
                targetText = uraniumText_MineScreen;
                break;
            case 6:
                targetText = ismiumText_MineScreen;
                break;
            case 7:
                targetText = iridiumText_MineScreen;
                break;
            case 8: 
                targetText = painiteText_MineScreen;
                break;
        }

        scaleGoldTextCoroutine = StartCoroutine(ScaleGoldTextAnim(targetText, 1.4f));
    }

    IEnumerator ScaleGoldTextAnim(TextMeshProUGUI textToScale, float startScale)
    {
        Vector2 originalScale = new Vector2(startScale, startScale);
        textToScale.transform.localScale = originalScale;

        // Pick random target scale and random duration
        float randomScaleFactor = Random.Range(startScale * 1.1f, startScale * 1.4f);
        Vector2 targetScale = new Vector2(randomScaleFactor, randomScaleFactor);
        float scaleDuration = Random.Range(0.06f, 0.12f);

        float elapsedTime = 0f;

        while (elapsedTime < scaleDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / scaleDuration;
            textToScale.transform.localScale = Vector2.Lerp(originalScale, targetScale, t);
            yield return null;
        }

        textToScale.transform.localScale = targetScale;

        float scaleDownDuration = Random.Range(0.06f, 0.12f);
        elapsedTime = 0f;
        while (elapsedTime < scaleDownDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / scaleDownDuration;
            textToScale.transform.localScale = Vector2.Lerp(targetScale, originalScale, t);
            yield return null;
        }

        textToScale.transform.localScale = originalScale;

        scaleGoldTextCoroutine = null;
    }
    #endregion

    #region Reset stuff
    public void ResetStuff()
    {
        totalGoldore = 0;
        totalCopperOre = 0;
        totalIronOre = 0;
        totalCobaltOre = 0;
        totalUraniumOre = 0;
        totalIsmiumOre = 0;
        totalIridiumOre = 0;
        totalPainiteOre = 0;
        goldText_MineScreen.text = totalGoldore.ToString("F0");
        copperText_MineScreen.text = totalCopperOre.ToString("F0");
        ironText_MineScreen.text = totalIronOre.ToString("F0");
        cobaltText_MineScreen.text = totalCobaltOre.ToString("F0");
        uraniumText_MineScreen.text = totalUraniumOre.ToString("F0");
        ismiumText_MineScreen.text = totalIsmiumOre.ToString("F0");
        iridiumText_MineScreen.text = totalIridiumOre.ToString("F0");
        painiteText_MineScreen.text = totalPainiteOre.ToString("F0");
    }
    #endregion

    #region Load Data
    public void LoadData(GameData data)
    {
        totalGoldBars = data.totalGoldBars;
        totalCopperBars = data.totalCopperBars;
        totalIronBars = data.totalIronBars;
        totalCobaltBars = data.totalCobaltBars;
        totalUraniumBars = data.totalUraniumBars;
        totalIsmiumBar = data.totalIsmiumBar;
        totalIridiumBars = data.totalIridiumBars;
        totalPainiteBars = data.totalPainiteBars;
    }
    #endregion

    #region Save Data
    public void SaveData(ref GameData data)
    {
        data.totalGoldBars = totalGoldBars;
        data.totalCopperBars = totalCopperBars;
        data.totalIronBars = totalIronBars;
        data.totalCobaltBars = totalCobaltBars;
        data.totalUraniumBars = totalUraniumBars;
        data.totalIsmiumBar = totalIsmiumBar;
        data.totalIridiumBars = totalIridiumBars;
        data.totalPainiteBars = totalPainiteBars;
    }
    #endregion

    public void ResetBars()
    {
        totalGoldBars = 0.494f;
        totalCopperBars = 0.494f;
        totalIronBars = 0.494f;
        totalCobaltBars = 0.494f;
        totalUraniumBars = 0.494f;
        totalIsmiumBar = 0.494f;
        totalIridiumBars = 0.494f;
        totalPainiteBars = 0.494f;

        SetTotalResourcesText();
    }

    public void TestingButtons(int buttonType)
    {
        if(buttonType == 1)
        {
            totalGoldBars += 2000;
        }
        else if (buttonType == 2)
        {
            totalGoldBars += 100000;
        }
        else if (buttonType == 3)
        {
            totalGoldBars += 1000;
            totalIronBars += 1000;
            totalCopperBars += 1000;
            totalCobaltBars += 1000;
            totalUraniumBars += 1000;
            totalIsmiumBar += 1000;
            totalIridiumBars += 1000;
            totalPainiteBars += 1000;
        }
        else if (buttonType == 4)
        {
            totalGoldBars += 100000;
            totalIronBars += 100000;
            totalCopperBars += 100000;
            totalCobaltBars += 100000;
            totalUraniumBars += 100000;
            totalIsmiumBar += 100000;
            totalIridiumBars += 100000;
            totalPainiteBars += 100000;
        }
        else if (buttonType == 5)
        {
            totalGoldBars += 1000000;
            totalIronBars += 1000000;
            totalCopperBars += 1000000;
            totalCobaltBars += 1000000;
            totalUraniumBars += 1000000;
            totalIsmiumBar += 1000000;
            totalIridiumBars += 1000000;
            totalPainiteBars += 1000000;
        }
        else if (buttonType == 6)
        {
            LevelMechanics.totalTalentPoints += 10;
        }
        else
        {
            totalGoldBars = 0;
            totalIronBars = 0;
            totalCopperBars = 0;
            totalCobaltBars = 0;
            totalUraniumBars = 0;
            totalIsmiumBar = 0;
            totalIridiumBars = 0;
            totalPainiteBars = 0;
        }
    }
}
