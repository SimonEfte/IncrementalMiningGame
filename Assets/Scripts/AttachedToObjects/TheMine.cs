using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TheMine : MonoBehaviour, IDataPersistence
{
    public GoldAndOreMechanics goldScript;
    public LocalizationScript locScript;
    public AudioManager audioManager;

    public GameObject mineProgressBar, mineSpeedBtn, mineOreBtn, lockedMine, purchaseMineBtn;

    public TextMeshProUGUI goldChance_text, copperChance_text, ironChance_text, cobaltChance_text, uraniumChance_text, ismiumChance_text, iridiumChance_text, painiteChance_text;
    public static float goldChance, copperChance, ironChance, cobaltChance, uraniumChance, ismiumChance, iridiumChance, painiteChance;

    //Saves
    public static bool isTheMineUnlocked;
    public static double theMinePrice;
    public static float mineTimeDecrase;
    public static double mineTimePrice, mineMaterialsPrice;
    public static float miningTime;
    public static int barsMined;
    public static int bersMinedIncrease;

    private void Awake()
    {
        mineTimeDecrase = miningTime / 25;

        if (barsMined < 20) { bersMinedIncrease = 2; }
        else { bersMinedIncrease = 1; }

        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        
        UpdateChances();
        if (isTheMineUnlocked) { StartCoroutine(Mining()); }
    }

    public TextMeshProUGUI mineTimePriceText, mineMaterialPriceText;

    private void Update()
    {
        if (MainMenu.isInTheMine)
        {
            string colorName1 = "yo";
            string colorName2 = "yo";
            string colorName3 = "yo";

            if (GoldAndOreMechanics.totalGoldBars >= mineTimePrice)
            {
                colorName1 = "<color=green>";
            }
            else
            {
                colorName1 = "<color=red>";
            }

            if (GoldAndOreMechanics.totalGoldBars >= mineMaterialsPrice)
            {
                colorName2 = "<color=green>";
            }
            else
            {
                colorName2 = "<color=red>";
            }

            if (GoldAndOreMechanics.totalGoldBars >= theMinePrice)
            {
                colorName3 = "<color=green>";
            }
            else
            {
                colorName3 = "<color=red>";
            }

            mineTimePriceText.text = $"Price: {colorName1}{mineTimePrice.ToString("F0")}";
            mineMaterialPriceText.text = $"Price: {colorName2}{mineMaterialsPrice.ToString("F0")}";
            theMinePriceText.text = $"Price: {colorName3}{theMinePrice.ToString("F0")}";
        }
    }

    public void UpdateChances()
    {
        if(SkillTree.spawnCopper_purchased == false)
        {
            goldChance = 100f;
            goldChance_text.text = goldChance.ToString("F0") + "%";

            goldChance_text.gameObject.SetActive(false);
        }
        else
        {
            float totalGoldChance = 100f;

            if (SkillTree.spawnCopper_purchased)
            {
                copperChance = SkillTree.copperRockChance + SkillTree.fullCopperRockChance;
                copperChance_text.text = copperChance.ToString("F1") + "%";
                totalGoldChance -= copperChance;
            }

            if (SkillTree.spawnIron_purchased)
            {
                ironChance = SkillTree.ironRockChance + SkillTree.fullIronRockChance;
                ironChance_text.text = ironChance.ToString("F1") + "%";
                totalGoldChance -= ironChance;
            }

            if (SkillTree.cobaltSpawn_purchased)
            {
                cobaltChance = SkillTree.cobaltRockChance + SkillTree.fullCobaltRockChance;
                cobaltChance_text.text = cobaltChance.ToString("F1") + "%";
                totalGoldChance -= cobaltChance;
            }

            if (SkillTree.uraniumSpawn_purchased)
            {
                uraniumChance = SkillTree.uraniumRockChance + SkillTree.fullUraniumRockChance;
                uraniumChance_text.text = uraniumChance.ToString("F1") + "%";
                totalGoldChance -= uraniumChance;
            }

            if (SkillTree.ismiumSpawn_purchased)
            {
                ismiumChance = SkillTree.ismiumRockChance + SkillTree.fullIsmiumRockChance;
                ismiumChance_text.text = ismiumChance.ToString("F1") + "%";
                totalGoldChance -= ismiumChance;
            }

            if (SkillTree.iridiumSpawn_purchased)
            {
                iridiumChance = SkillTree.iridiumRockChance + SkillTree.fullIridiumRockChance;
                iridiumChance_text.text = iridiumChance.ToString("F1") + "%";
                totalGoldChance -= iridiumChance;
            }

            if (SkillTree.painiteSpawn_purchased)
            {
                painiteChance = SkillTree.painiteRockChance + SkillTree.fullPainiteRockChance;
                painiteChance_text.text = painiteChance.ToString("F1") + "%";
                totalGoldChance -= painiteChance;
            }

            goldChance = totalGoldChance;
            goldChance_text.text = goldChance.ToString("F1") + "%";

            if (MainMenu.isInTheMine)
            {
                goldChance_text.gameObject.SetActive(true);
                copperChance_text.gameObject.SetActive(true);
                ironChance_text.gameObject.SetActive(true);
                cobaltChance_text.gameObject.SetActive(true);
                uraniumChance_text.gameObject.SetActive(true);
                ismiumChance_text.gameObject.SetActive(true);
                iridiumChance_text.gameObject.SetActive(true);
                painiteChance_text.gameObject.SetActive(true);
            }
            else
            {
                goldChance_text.gameObject.SetActive(false);
                copperChance_text.gameObject.SetActive(false);
                ironChance_text.gameObject.SetActive(false);
                cobaltChance_text.gameObject.SetActive(false);
                uraniumChance_text.gameObject.SetActive(false);
                ismiumChance_text.gameObject.SetActive(false);
                iridiumChance_text.gameObject.SetActive(false);
                painiteChance_text.gameObject.SetActive(false);
            }
        }
    }

    //public static double mineGoldBarPrice;
   
    public TextMeshProUGUI theMinePriceText;

    public void PurchaseTheMine()
    {
        if(GoldAndOreMechanics.totalGoldBars >= theMinePrice)
        {
            GoldAndOreMechanics.totalGoldBars -= theMinePrice;
            goldScript.SetTotalResourcesText();

            audioManager.Play("Click_1");

            isTheMineUnlocked = true;

            mineProgressBar.SetActive(true);
            mineSpeedBtn.SetActive(true);
            mineOreBtn.SetActive(true);

            lockedMine.SetActive(false);
            purchaseMineBtn.SetActive(false);
            StartCoroutine(Mining());
        }
    }

    #region Mining
    public Slider mineSlider;

    IEnumerator Mining()
    {
        mineSlider.value = 0f;

        float totalMineTime = miningTime;

        float mineTimeReduction = 1;

        if (Artifacts.ancientDevice_found) 
        {
            float ancientDeviceStats = Artifacts.ancientDeviceTimeReduction;

            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                ancientDeviceStats *= (1 + LevelMechanics.archeologistIncrease + Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { ancientDeviceStats *= (1 + LevelMechanics.archeologistIncrease); }
                if (Artifacts.rune_found) { ancientDeviceStats *= (1 + Artifacts.runeImproveAll); }
            }

            mineTimeReduction = 1 - ancientDeviceStats;
        }

        if (LevelMechanics.isSignFasterMine)
        {
            mineTimeReduction -= LevelMechanics.signFasterMineAmount;
        }

        totalMineTime *= mineTimeReduction;

        bool minedFaster = false;

        if(LevelMechanics.skilledMiners_chosen == true)
        {
            float random = Random.Range(0f, 100f);
            if(random < LevelMechanics.skilledMinersFastChance)
            {
                AllStats.theMine2XTriggers += 1;

                totalMineTime = miningTime / 2;
                minedFaster = true;
            }
        }

        //Chance to mine 3X faster
        if (LevelMechanics.isSignChanceToMine3XFaster && minedFaster == false) 
        {
            float random = Random.Range(0f, 100f);
            if (random < LevelMechanics.signMine3XFasterChance)
            {
                totalMineTime = miningTime / 3;
            }
        }

        float currentTime = 0;

        while (currentTime < totalMineTime)
        {
            currentTime += Time.deltaTime;

            mineSlider.value = Mathf.Clamp01(currentTime / totalMineTime);

            yield return null;
        }

        mineSlider.value = 1f;
        MinedMaterials();
    }
    #endregion

    #region Mined materials
    public Animation mineMinedAnim;

    public void MinedMaterials()
    {
        bool doubleBars = false;

        if (LevelMechanics.skilledMiners_chosen == true)
        {
            float random = Random.Range(0f, 100f);
            if (random < LevelMechanics.skilledMinersDoubleChance)
            {
                AllStats.theMineDoubleTriggers += 1;
                doubleBars = true;
            }
        }

        int totalBarsCrafted = barsMined;
        if(doubleBars == true) { totalBarsCrafted *= 2; }

        if (LevelMechanics.isSignMineMoreMaterials)
        {
            totalBarsCrafted += LevelMechanics.signMoreMaterialsAmount;
        }
        if (LevelMechanics.isSignDoubleMaterialsChance)
        {
            float randomChance = Random.Range(0f, 100f);
            if(randomChance < LevelMechanics.signDoubleMaterialsChance)
            {
                if(doubleBars == false) { totalBarsCrafted *= 2; }
            }
        }

        mineMinedAnim.Play();

        bool spawnGold = false;
        bool spawnCopper = false;
        bool spawnIron = false;
        bool spawnCobalt = false;
        bool spawnUranium = false;
        bool spawnIsmium = false;
        bool spawnIridium = false;
        bool spawnPainite = false;

        float totalRandom = 100f;
        float randomBarChance = Random.Range(0f, totalRandom);
        bool choseBar = false;

        if (SkillTree.painiteSpawn_purchased == true)
        {
            randomBarChance = Random.Range(0f, totalRandom);

            if (randomBarChance < painiteChance && choseBar == false)
            {
                choseBar = true;
                spawnPainite = true;
            }

            totalRandom -= painiteChance;
        }

        if (SkillTree.iridiumSpawn_purchased == true)
        {
            randomBarChance = Random.Range(0f, totalRandom);

            if (randomBarChance < iridiumChance && choseBar == false)
            {
                choseBar = true;
                spawnIridium = true;
            }

            totalRandom -= iridiumChance;
        }

        if (SkillTree.ismiumSpawn_purchased == true)
        {
            randomBarChance = Random.Range(0f, totalRandom);

            if (randomBarChance < ismiumChance && choseBar == false)
            {
                choseBar = true;
                spawnIsmium = true;
            }

            totalRandom -= ismiumChance;
        }

        if (SkillTree.uraniumSpawn_purchased == true)
        {
            randomBarChance = Random.Range(0f, totalRandom);

            if (randomBarChance < uraniumChance && choseBar == false)
            {
                choseBar = true;
                spawnUranium = true;
            }

            totalRandom -= uraniumChance;
        }

        if (SkillTree.cobaltSpawn_purchased == true)
        {
            randomBarChance = Random.Range(0f, totalRandom);

            if (randomBarChance < cobaltChance && choseBar == false)
            {
                choseBar = true;
                spawnCobalt = true;
            }

            totalRandom -= cobaltChance;
        }

        if (SkillTree.spawnIron_purchased == true)
        {
            randomBarChance = Random.Range(0f, totalRandom);

            if (randomBarChance < ironChance && choseBar == false)
            {
                choseBar = true;
                spawnIron = true;
            }

            totalRandom -= ironChance;
        }

        if (SkillTree.spawnCopper_purchased == true)
        {
            randomBarChance = Random.Range(0f, totalRandom);

            if (randomBarChance < copperChance && choseBar == false)
            {
                choseBar = true;
                spawnCopper = true;
            }
        }

        if (choseBar == false)
        {
            spawnGold = true;
        }

        for (int i = 0; i < totalBarsCrafted; i++)
        {
            if (MainMenu.isInTheMine)
            {
                GameObject minedMaterial = ObjectPool.instance.GetTheMineMaterialFromPool();
                minedMaterial.transform.localPosition = new Vector2(Random.Range(-30, -120), Random.Range(-75, 60));

                if (spawnGold) { minedMaterial.gameObject.transform.localScale = new Vector2(0.25f, 0.25f); }
                else if (spawnCopper) { minedMaterial.gameObject.transform.localScale = new Vector2(0.35f, 0.35f); }
                else if (spawnIron) { minedMaterial.gameObject.transform.localScale = new Vector2(0.45f, 0.45f); }
                else if (spawnCobalt) { minedMaterial.gameObject.transform.localScale = new Vector2(0.55f, 0.55f); }
                else if (spawnUranium) { minedMaterial.gameObject.transform.localScale = new Vector2(0.65f, 0.65f); }
                else if (spawnIsmium) { minedMaterial.gameObject.transform.localScale = new Vector2(0.75f, 0.75f); }
                else if (spawnIridium) { minedMaterial.gameObject.transform.localScale = new Vector2(0.85f, 0.85f); }
                else if (spawnPainite) { minedMaterial.gameObject.transform.localScale = new Vector2(0.95f, 0.95f); }
                else
                {
                    minedMaterial.gameObject.transform.localScale = new Vector2(0.25f, 0.25f);
                }
            }
            else
            {
                if (spawnGold == true) { goldScript.GiveGoldBar(1, 1); }
                else if (spawnCopper == true) { goldScript.GiveGoldBar(1, 2); }
                else if (spawnIron == true) { goldScript.GiveGoldBar(1, 3); }
                else if (spawnCobalt == true) { goldScript.GiveGoldBar(1, 4); }
                else if (spawnUranium == true) { goldScript.GiveGoldBar(1, 5); }
                else if (spawnIsmium == true) { goldScript.GiveGoldBar(1, 6); }
                else if (spawnIridium == true) { goldScript.GiveGoldBar(1, 7); }
                else if (spawnPainite == true) { goldScript.GiveGoldBar(1, 8); }
            }
        }

        StartCoroutine(Mining());
    }
    #endregion

    public void UpgradeMineTime()
    {
        if(GoldAndOreMechanics.totalGoldBars >= mineTimePrice)
        {
            GoldAndOreMechanics.totalGoldBars -= mineTimePrice;
            goldScript.SetTotalResourcesText();

            mineTimePrice += 12;

            mineTimeDecrase = miningTime / 25;

            miningTime -= mineTimeDecrase;
            audioManager.Play("Click_1");

            locScript.TheMineTexts(true);
        }
    }

    public void UpgradeMinedMaterials()
    {
        if (GoldAndOreMechanics.totalGoldBars >= mineMaterialsPrice)
        {
            barsMined += bersMinedIncrease;

            GoldAndOreMechanics.totalGoldBars -= mineMaterialsPrice;
            goldScript.SetTotalResourcesText();

            mineMaterialsPrice += 12;

            if (barsMined < 20) { bersMinedIncrease = 2; }
            else { bersMinedIncrease = 1; }
            audioManager.Play("Click_1");

            locScript.TheMineTexts(false);
        }
    }

    #region Load Data
    public void LoadData(GameData data)
    {
        isTheMineUnlocked = data.isTheMineUnlocked;
        theMinePrice = data.theMinePrice;
        mineTimeDecrase = data.mineTimeDecrase;
        mineTimePrice = data.mineTimePrice;
        mineMaterialsPrice = data.mineMaterialsPrice;
        miningTime = data.miningTime;
        barsMined = data.barsMined;
        bersMinedIncrease = data.bersMinedIncrease;
    }
    #endregion

    #region Save Data
    public void SaveData(ref GameData data)
    {
        data.isTheMineUnlocked = isTheMineUnlocked;
        data.theMinePrice = theMinePrice;
        data.mineTimeDecrase = mineTimeDecrase;
        data.mineTimePrice = mineTimePrice;
        data.mineMaterialsPrice = mineMaterialsPrice;
        data.miningTime = miningTime;
        data.barsMined = barsMined;
        data.bersMinedIncrease = bersMinedIncrease;
    }
    #endregion

    public void ResetTheMine()
    {
        mineProgressBar.SetActive(false);
        mineSpeedBtn.SetActive(false);
        mineOreBtn.SetActive(false);
        purchaseMineBtn.SetActive(false);

        lockedMine.SetActive(true);

        isTheMineUnlocked = false;
        theMinePrice = 1000;

        miningTime = 30f;
        mineTimeDecrase = 1.2f;
        mineTimePrice = 500;

        mineMaterialsPrice = 750;
        barsMined = 4;
        bersMinedIncrease = 2;
        StopAllCoroutines();
    }
}
