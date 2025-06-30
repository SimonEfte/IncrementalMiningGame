using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelMechanics : MonoBehaviour, IDataPersistence
{
    public SkillTree skillTreeScript;
    public SpawnProjectiles spawnProjectilesScript;
    public Artifacts artifactScript;
    public AudioManager audioManager;
    public Tutorial tutorialScript;
    public LocalizationScript locScript;

    public Slider xpSlider;

    //These are being saved
    public static int level;
    public static int totalTalentPoints;
    public static int extraTalentPointPerLevelCOUNT;
    public static int extraTalentPointBOOK;
    public static int talentLevel;
    public static float xpFromRock;
    public float xpNeedForNextLvl;
    public float currentXP;
    public bool isInChoose1;
    public static bool isBlockFrameActive;
    public static int newTalentsPrice;
    public static bool potionDrinker_chosen, potionChugger_chosen, chests_chosen, goldenChests_chosen, skilledMiners_chosen, efficientBlacksmith_chosen, itsASign_chosen, steamSale_chosen, bigMiningArea_chosen, itsHammerTime_chosen, goldenTouch_chosen, zeus_chosen, shapeShifter_chosen, xMarksTheSpor_chosen, explorer_chosen, archaeologist_chosen, energiDrinker_chosen, springSeason_chosen, camper_chosen, d100_chosen;

    public static int talentLevelHpIncrease;

    public TextMeshProUGUI levelText;

    public Animation lockedTalent1, lockedTalent2, lockedTalent3;

    public TextMeshProUGUI needToReachText;

    public TextMeshProUGUI talentScreen_talentPoints;

    public static float steamSaleDiscount;

    public static int rocksMinedByHammer;

    public static float archeologistIncrease;

    public static float blacksmithDecrease;

    public static int totalChestMaterials, totalGoldenChestMaterials;

    public static float shapeShifterSizeIncrease;

    public static float rockSpawnChance;

    public static float skilledMinersFastChance, skilledMinersDoubleChance;
   
    public static float bigMiningAreaChance;

    public static float hammerChance;

    public static int midasTouchChance, midasTouchSpawnChance;

    public static int zeusChance, zeusLightningAmount;

    public static int energiDrinkChance, energiDrinkTime;

    public static float flowerIncrease;

    public GameObject sign;

    public GameObject blockFrame;

    public GameObject unlockParent, choose1Parent;
    public GameObject blockBtn;

    public static float inflationBurstIncrease;

    public static int cardsLeft;

    public GameObject card1Left, card2Left, cardAllChosen, allTalentCardsChosenBlockBtn;

    private void Awake()
    {
        SetOriginalStats();

        StartCoroutine(Wait());
    }

    public void SetOriginalStats()
    {
        talentLevelHpIncrease = 2;



        inflationBurstIncrease = 0.3f;

        totalGoldenChestMaterials = 40;
        totalChestMaterials = 25;

        archeologistIncrease = 0f;

        steamSaleDiscount = 1;

        blacksmithDecrease = 1f;

        shapeShifterSizeIncrease = 0;

        rockSpawnChance = 0.5f;

        skilledMinersFastChance = 7;
        skilledMinersDoubleChance = 4;

        bigMiningAreaChance = 6;

        hammerChance = 0.2f;

        midasTouchChance = 9;
        midasTouchSpawnChance = 15;

        zeusChance = 5;
        zeusLightningAmount = 15;

        energiDrinkChance = 6;
        energiDrinkTime = 2;

        flowerIncrease = 0.02f;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);

        if (potionDrinker_chosen) { potionDrinker_unlocked.SetActive(true); }
        if (potionChugger_chosen) { potionChugger_unlocked.SetActive(true); }
        if (chests_chosen) { chests_unlocked.SetActive(true); }
        if (goldenChests_chosen) { goldenChests_unlocked.SetActive(true); }
        if (skilledMiners_chosen) { skilledMiners_unlocked.SetActive(true); }
        if (efficientBlacksmith_chosen) { efficientBlacksmith_unlocked.SetActive(true); blacksmithDecrease = 0.90f; }
        if (itsASign_chosen) { itsASign_unlocked.SetActive(true); StartCoroutine(ChangeSignBuff()); sign.SetActive(true); }
        if (steamSale_chosen) { steamSale_unlocked.SetActive(true); steamSaleDiscount = 0.93f; }
        if (bigMiningArea_chosen) { bigMiningArea_unlocked.SetActive(true);StartCoroutine(ChanceToIncreaseMiningErea()); }
        if (itsHammerTime_chosen) { itsHammerTime_unlocked.SetActive(true); }
        if (goldenTouch_chosen) { goldenTouch_unlocked.SetActive(true); }
        if (zeus_chosen) { zeus_unlocked.SetActive(true); StartCoroutine(StartZeus()); }
        if (shapeShifter_chosen) { shapeShifter_unlocked.SetActive(true); shapeShifterSizeIncrease = 0.05f; }
        if (xMarksTheSpor_chosen) { xMarksTheSpor_unlocked.SetActive(true); }
        if (explorer_chosen) { explorer_unlocked.SetActive(true); }
        if (archaeologist_chosen) { archaeologist_unlocked.SetActive(true); }
        if (energiDrinker_chosen) { energiDrinker_unlocked.SetActive(true); StartCoroutine(ChanceToDrinkEnergiDRink()); }
        if (springSeason_chosen) { springSeason_unlocked.SetActive(true); }
        if (camper_chosen) { camper_unlocked.SetActive(true); }
        if (d100_chosen) { d100_unlocked.SetActive(true); }

        AddTalentCards();
        SetTalentTexts();
    }

    public TextMeshProUGUI revealTalentsPriceText;
 
    private void Update()
    {
        if (MainMenu.isInTalents)
        {
            string colorName = "yo";

            if (totalTalentPoints >= newTalentsPrice)
            {
                colorName = "<color=green>";
            }
            else
            {
                colorName = "<color=red>";
            }

            revealTalentsPriceText.text = $"Price: {colorName}{newTalentsPrice}";
        }
    }

    public TextMeshProUGUI rockDurabilityTooltipText;

    public void SetTalentTexts()
    {
        talentLevelText.text = "Talent level: " + talentLevel;

        int durability = 10 + (talentLevelHpIncrease * talentLevel);
        durability -= talentLevelHpIncrease;

        rockDurabilityTooltipText.text = $"= {durability} Durability";

        xpSlider.minValue = 0;
        xpSlider.maxValue = xpNeedForNextLvl;

        xpSlider.value = currentXP;

        float value = xpSlider.value;
        needToReachText.text = (value * 100).ToString("F0") + "/" + (xpSlider.maxValue * 100).ToString("F0") + "XP";

        levelText.text = level + "";
        talentScreen_talentPoints.text = totalTalentPoints.ToString("F0");
    }

    public static bool didLevelUp;
    public static int didLevelUpTotalTalentPoints;

    #region Give XP
    public static float xpThisRound;
    public Animation levelUpAnim;
    public void GiveXP()
    {
        float random2XXP = Random.Range(0,100);

        float xpGained = xpFromRock;

        if (random2XXP < (SkillTree.doubleXpAndGoldChance + SetRockScreen.potionDoubleChance_increase))
        {
            if (springSeason_chosen)
            {
                float totalFlowerIncrease = flowerIncrease * SetRockScreen.flowersOnScreen;
                totalFlowerIncrease += 1;
                if(SetRockScreen.isPotionXp == true) { totalFlowerIncrease += SetRockScreen.potionXp_increase; }
                xpGained *= totalFlowerIncrease;
            }
            else
            {
                if (SetRockScreen.isPotionXp == true) { xpGained *= 1 + SetRockScreen.potionXp_increase; }
            }

            xpSlider.value += xpGained * 2;
            xpThisRound += xpGained * 2;

            AllStats.doubleXPGained += 1;
        }
        else
        {
            if (springSeason_chosen)
            {
                float totalFlowerIncrease = flowerIncrease * SetRockScreen.flowersOnScreen;
                totalFlowerIncrease += 1;
                if (SetRockScreen.isPotionXp == true) { totalFlowerIncrease += SetRockScreen.potionXp_increase; }
                xpGained *= totalFlowerIncrease;
            }
            else
            {
                if (SetRockScreen.isPotionXp == true) { xpGained *= 1 + SetRockScreen.potionXp_increase; }
            }

            if (Artifacts.purpleRing_found)
            {
                float chanceIncrease = 1 + archeologistIncrease + Artifacts.runeImproveAll;

                float random = Random.Range(0f,100f);
                if(random < Artifacts.purpleRingChance * chanceIncrease) { xpGained *= 2; }
            }

            xpSlider.value += xpGained;
            xpThisRound += xpGained;
        }

        currentXP += xpGained;
        AllStats.experienceGained += xpGained;

        if (xpSlider.value >= xpNeedForNextLvl)
        {
            if (Tutorial.pressedOkTalent == false) { tutorialScript.SetTutorial(2); }

            audioManager.Play("LevelUp");

            AllStats.totalLevelUps += 1;

            currentXP = 0;
            xpSlider.value = 0;
            xpNeedForNextLvl *= 1.82f;
            level += 1;
            levelText.text = "" + level;

            xpSlider.minValue = 0;
            xpSlider.maxValue = xpNeedForNextLvl;

            int totalTalentPointsToAdd = 0;

            totalTalentPoints += 1;
            totalTalentPointsToAdd += 1;
            didLevelUp = true;

            if (SkillTree.talentPointsPerXlevel_1_purchased || SkillTree.talentPointsPerXlevel_2_purchased || SkillTree.talentPointsPerXlevel_3_purchased)
            {
                extraTalentPointPerLevelCOUNT += 1;
                if(extraTalentPointPerLevelCOUNT >= SkillTree.extraTalentPointPerLevel)
                {
                    extraTalentPointPerLevelCOUNT = 0;
                    totalTalentPoints += 1;
                    totalTalentPointsToAdd += 1;
                }
            }

            if (Artifacts.book_found)
            {
                extraTalentPointBOOK += 1;
                if(extraTalentPointBOOK == 5)
                {
                    totalTalentPoints += 1;
                    totalTalentPointsToAdd += 1;
                    extraTalentPointBOOK = 0;
                }
            }

            didLevelUpTotalTalentPoints = totalTalentPointsToAdd;

            levelUpAnim.GetComponent<TextMeshProUGUI>().text = "LEVEL UP! <color=purple>+" + totalTalentPointsToAdd;

            levelUpAnim.gameObject.SetActive(true);
            levelUpAnim.Play();
            StartCoroutine(SetLevelAnimOff());

            talentScreen_talentPoints.text = totalTalentPoints.ToString("F0");
        }

        float value = xpSlider.value;
        needToReachText.text = (value * 100).ToString("F0") + "/" + (xpSlider.maxValue * 100).ToString("F0") + "XP";
    }

    IEnumerator SetLevelAnimOff()
    {
        yield return new WaitForSeconds(2.08f);
        levelUpAnim.gameObject.SetActive(false);
    }
    #endregion

    #region Unlock talent cards
    public void UnlockTalents()
    {
        if(totalTalentPoints >= newTalentsPrice && isInChoose1 == false)
        {
            totalTalentPoints -= newTalentsPrice;
            talentScreen_talentPoints.text = totalTalentPoints.ToString("F0");

            newTalentsPrice += 1;

            blockBtn.SetActive(true);
            isBlockFrameActive = true;
            unlockParent.SetActive(false);
            choose1Parent.SetActive(true);

            isInChoose1 = true;
            blockFrame.SetActive(true);

            StartCoroutine(RemoveBlockedTalentCards());
        }
    }

    IEnumerator RemoveBlockedTalentCards()
    {
        audioManager.Play("FadeIn");
        lockedTalent1.Play("RemoveBlockedCard");
        yield return new WaitForSeconds(0.2f);
        audioManager.Play("FadeIn");
        lockedTalent2.Play("RemoveBlockedCard");
        yield return new WaitForSeconds(0.2f);
        audioManager.Play("FadeIn");
        lockedTalent3.Play("RemoveBlockedCard");

        yield return new WaitForSeconds(0.35f);

        blockFrame.SetActive(false);
    }
    #endregion

    #region Add talent cards
    public GameObject potionDrinker_card, potionChugger_Card, chests_card, goldenChests_card, skilledMiners_card, efficientBlacksmith_card, itsASign_card, steamSale_card, bigMiningArea_card, itsHammerTime_card, goldenTouch_card, zeus_card, shapeShifter_card, xMarksTheSpor_card, explorer_card, archaeologist_Card, energiDrinker_card, springSeason_card, camper_card, d100_card;

    public Transform moveCardHere;

    public GameObject[] storeCard;

    public int card1Number, card2Number, card3Number;

    public int cardsChosen;

    public void AddTalentCards()
    {
        if(cardsLeft < 3) { card1Left.SetActive(true); }
        if (cardsLeft < 2) { card2Left.SetActive(true); }
        if (cardsLeft < 1) 
        {
            cardAllChosen.SetActive(true);
            if (MainMenu.isInTalents) { allTalentCardsChosenBlockBtn.SetActive(true); }
        }

        locScript.TalentCardsLeftText();

        cardsChosen = 0;

        potionDrinker_card.SetActive(false);
        potionChugger_Card.SetActive(false);
        chests_card.SetActive(false);
        goldenChests_card.SetActive(false);
        skilledMiners_card.SetActive(false);
        efficientBlacksmith_card.SetActive(false);
        itsASign_card.SetActive(false);
        steamSale_card.SetActive(false);
        bigMiningArea_card.SetActive(false);
        itsHammerTime_card.SetActive(false);
        goldenTouch_card.SetActive(false);
        zeus_card.SetActive(false);
        shapeShifter_card.SetActive(false);
        xMarksTheSpor_card.SetActive(false);
        explorer_card.SetActive(false);
        archaeologist_Card.SetActive(false);
        energiDrinker_card.SetActive(false);
        springSeason_card.SetActive(false);
        camper_card.SetActive(false);
        d100_card.SetActive(false);

        SetCard();
    }

    public void SetCard()
    {
        if(cardsLeft == 0) { return; }

        //int randomCard = Random.Range(1, 21);
        int randomCard = Random.Range(1, 21);

        if (randomCard == 1 && potionDrinker_chosen == false)
        {
            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }
            storeCard[cardsChosen] = potionDrinker_card; storeCard[cardsChosen].SetActive(true);
        }
        else if (randomCard == 2 && potionChugger_chosen == false) 
        { 
            if(cardsLeft > 4)
            {
                if (potionDrinker_chosen == false) { SetCard(); return; }
            }

            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }
            storeCard[cardsChosen] = potionChugger_Card; storeCard[cardsChosen].SetActive(true);
        }
        else if(randomCard == 3 && chests_chosen == false)
        {
            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }
            storeCard[cardsChosen] = chests_card; storeCard[cardsChosen].SetActive(true);
        }
        else if (randomCard == 4 && goldenChests_chosen == false) 
        {
            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }
            storeCard[cardsChosen] = goldenChests_card; storeCard[cardsChosen].SetActive(true);
        }
        else if (randomCard == 5 && skilledMiners_chosen == false) 
        {
            if (cardsLeft > 6)
            {
                if (TheMine.isTheMineUnlocked == false) { SetCard(); return; }
            }

            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }
            storeCard[cardsChosen] = skilledMiners_card; storeCard[cardsChosen].SetActive(true);
        }
        else if (randomCard == 6 && efficientBlacksmith_chosen == false)
        {
            if (cardsLeft > 5)
            {
                if (TheAnvil.isTheAnvilUnlocked == false) { SetCard(); return; }
            }

            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }
            storeCard[cardsChosen] = efficientBlacksmith_card; storeCard[cardsChosen].SetActive(true);
        }
        else if (randomCard == 7 && itsASign_chosen == false) 
        {
            if (cardsLeft > 6)
            {
                if (TheMine.isTheMineUnlocked == false) { SetCard(); return; }
            }

            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }
            storeCard[cardsChosen] = itsASign_card; storeCard[cardsChosen].SetActive(true);
        }
        else if (randomCard == 8 && steamSale_chosen == false) 
        {
            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }
            storeCard[cardsChosen] = steamSale_card; storeCard[cardsChosen].SetActive(true);
        }
        else if (randomCard == 9 && bigMiningArea_chosen == false) 
        {
            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }
            storeCard[cardsChosen] = bigMiningArea_card; storeCard[cardsChosen].SetActive(true);
        }
        else if (randomCard == 10 && itsHammerTime_chosen == false) 
        {
            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }
            storeCard[cardsChosen] = itsHammerTime_card; storeCard[cardsChosen].SetActive(true);
        }
        else if (randomCard == 11 && goldenTouch_chosen == false) 
        {
            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }
            storeCard[cardsChosen] = goldenTouch_card; storeCard[cardsChosen].SetActive(true);
        }
        else if (randomCard == 12 && zeus_chosen == false)
        {
            if(SkillTree.lightningBeamChancePH_1_purchased == false && SkillTree.lightningBeamChanceS_1_purchased == false)
            {
                if (cardsLeft > 7)
                {
                    if (SkillTree.lightningBeamChancePH_1_purchased == false) { SetCard(); return; }
                    if (SkillTree.lightningBeamChanceS_1_purchased == false) { SetCard(); return; }
                }
            }
            else if (cardsLeft > 5)
            {
                if (SkillTree.lightningBeamChancePH_1_purchased == false) { SetCard(); return; }
                if (SkillTree.lightningBeamChanceS_1_purchased == false) { SetCard(); return; }
            }

            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }
            storeCard[cardsChosen] = zeus_card; storeCard[cardsChosen].SetActive(true);
        }
        else if (randomCard == 13 && shapeShifter_chosen == false)
        {
            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }
            storeCard[cardsChosen] = shapeShifter_card; storeCard[cardsChosen].SetActive(true);
        }
        else if (randomCard == 14 && xMarksTheSpor_chosen == false)
        {
            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }
         
            if (cardsLeft > 6)
            {
                if (Artifacts.artifactsFound == 0) { SetCard(); return; }
            }

            storeCard[cardsChosen] = xMarksTheSpor_card; storeCard[cardsChosen].SetActive(true);
        }
        else if (randomCard == 15 && explorer_chosen == false)
        {
            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }

            if (cardsLeft > 6)
            {
                if (xMarksTheSpor_chosen == false) { SetCard(); return; }
                if (Artifacts.artifactsFound == 0) { SetCard(); return; }
            }

            storeCard[cardsChosen] = explorer_card; storeCard[cardsChosen].SetActive(true);
        }
        else if (randomCard == 16 && archaeologist_chosen == false) 
        {
            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }

            if (cardsLeft > 6)
            {
                if (Artifacts.artifactsFound == 0) { SetCard(); return; }
            }

            storeCard[cardsChosen] = archaeologist_Card; storeCard[cardsChosen].SetActive(true);
        }
        else if (randomCard == 17 && energiDrinker_chosen == false)
        {
            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }
            storeCard[cardsChosen] = energiDrinker_card; storeCard[cardsChosen].SetActive(true);
        }
        else if (randomCard == 18 && springSeason_chosen == false) 
        {
            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }
            storeCard[cardsChosen] = springSeason_card; storeCard[cardsChosen].SetActive(true);
        }
        else if (randomCard == 19 && camper_chosen == false) 
        {
            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }
            storeCard[cardsChosen] = camper_card; storeCard[cardsChosen].SetActive(true);
        }
        else if (randomCard == 20 && d100_chosen == false)
        {
            if (card1Number == randomCard || card2Number == randomCard || card3Number == randomCard) { SetCard(); return; }
            storeCard[cardsChosen] = d100_card; storeCard[cardsChosen].SetActive(true);
        }
        else { SetCard(); return; }

        cardsChosen += 1;

        if (cardsChosen == 1) { card1Number = randomCard; }
        if (cardsChosen == 2) { card2Number = randomCard; }
        if (cardsChosen == 3) { card3Number = randomCard; }

        if(cardsLeft > 2)
        {
            if (cardsChosen == 1) { SetCard(); }
            if (cardsChosen == 2) { SetCard(); }

            if (cardsChosen == 3)
            {
                storeCard[0].SetActive(true);
                storeCard[1].SetActive(true);
                storeCard[2].SetActive(true);

                storeCard[0].transform.localPosition = new Vector2(-424, 14.6f);
                storeCard[1].transform.localPosition = new Vector2(0, 14.6f);
                storeCard[2].transform.localPosition = new Vector2(424, 14.6f);
            }
        }
        else if (cardsLeft == 2)
        {
            if (cardsChosen == 1) { SetCard(); }

            if (cardsChosen == 2)
            {
                storeCard[0].SetActive(true);
                storeCard[1].SetActive(true);

                storeCard[0].transform.localPosition = new Vector2(-424, 14.6f);
                storeCard[1].transform.localPosition = new Vector2(0, 14.6f);
            }
        }
        else if (cardsLeft == 1)
        {
            if (cardsChosen == 1)
            {
                storeCard[0].SetActive(true);

                storeCard[0].transform.localPosition = new Vector2(-424, 14.6f);
            }
        }
    }
    #endregion

    #region Choose talent card
    public int cardNumberToMove;

    public void ChooseTalent()
    {
        audioManager.Play("FadeIn");

        blockFrame.SetActive(true);

        if(HoverOverIncreaseSize.xPos < -423)
        {
            cardNumberToMove = 0;
        }
        if (HoverOverIncreaseSize.xPos < 1 && HoverOverIncreaseSize.xPos > -1)
        {
            cardNumberToMove = 1;
        }
        if (HoverOverIncreaseSize.xPos > 423)
        {
            cardNumberToMove = 2;
        }


        if (cardNumberToMove == 0)
        {
            storeCard[1].GetComponent<Animation>().Play("TalentCardDown");
            storeCard[2].GetComponent<Animation>().Play("TalentCardDown");
        }
        else if (cardNumberToMove == 1)
        {
            storeCard[0].GetComponent<Animation>().Play("TalentCardDown");
            storeCard[2].GetComponent<Animation>().Play("TalentCardDown");
        }
        else if (cardNumberToMove == 2)
        {
            storeCard[0].GetComponent<Animation>().Play("TalentCardDown");
            storeCard[1].GetComponent<Animation>().Play("TalentCardDown");
        }
    }
    #endregion

    #region Move card when chosen animation
    public GridLayoutGroup talentGrid;

    public void MoveCard(string name)
    {
        StartCoroutine(MoveCardToUnlockedTalents(storeCard[cardNumberToMove], name));
    }

    private IEnumerator MoveCardToUnlockedTalents(GameObject objectToMove, string name)
    {
        Vector3 startScale = objectToMove.transform.localScale;
        Vector3 maxScale = startScale * 1.15f;
        Vector3 startPos = objectToMove.transform.position;
        Vector3 liftedPos = startPos + Vector3.up * 0.5f;

        float prepDuration = 0.45f;
        float prepElapsed = 0f;

        // Step 1: Scale up and move slightly upwards
        while (prepElapsed < prepDuration)
        {
            prepElapsed += Time.deltaTime;
            float t = prepElapsed / prepDuration;

            objectToMove.transform.localScale = Vector3.Lerp(startScale, maxScale, t);
            objectToMove.transform.position = Vector3.Lerp(startPos, liftedPos, t);
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        audioManager.Play("CardWoosh");

        // Step 2: Move to target with curve + scale down + rotate
        float moveDuration = 0.5f;
        float moveElapsed = 0f;
        Vector3 curveStart = liftedPos;
        Vector3 curveEnd = moveCardHere.position;
        Vector3 midPoint = (curveStart + curveEnd) / 2 + Vector3.up * 1f;

        float startRotZ = objectToMove.transform.eulerAngles.z;
        float endRotZ = startRotZ + 360f;

        Vector3 endScale = Vector3.one * 0.2f;

        while (moveElapsed < moveDuration)
        {
            moveElapsed += Time.deltaTime;
            float t = moveElapsed / moveDuration;

            // Curved movement (Quadratic Bezier)
            Vector3 curvedPos = Mathf.Pow(1 - t, 2) * curveStart
                              + 2 * (1 - t) * t * midPoint
                              + Mathf.Pow(t, 2) * curveEnd;
            objectToMove.transform.position = curvedPos;

            // Scale down
            objectToMove.transform.localScale = Vector3.Lerp(maxScale, endScale, t);

            // Rotate on Z
            float zRot = Mathf.Lerp(startRotZ, endRotZ, t);
            objectToMove.transform.rotation = Quaternion.Euler(0, 0, zRot);

            yield return null;
        }

        // Final corrections
        objectToMove.transform.position = moveCardHere.position;
        objectToMove.transform.localScale = endScale;
        objectToMove.transform.rotation = Quaternion.Euler(0, 0, endRotZ);

        // Step 3: Deactivate
        objectToMove.SetActive(false);

        talentLevel += 1;

        talentLevelText.gameObject.GetComponent<Animation>().Play();

        audioManager.Play("CardPop");

        cardsLeft -= 1;

        SetTalentTexts(); 

        if (name == "potionDrinker")
        {
            potionDrinker_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            potionDrinker_unlocked.SetActive(true);
            potionDrinker_chosen = true;

        }
        if (name == "potionChugger")
        {
            potionChugger_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            potionChugger_unlocked.SetActive(true);

            potionChugger_chosen = true;
        }
        if (name == "chests")
        {
            chests_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            chests_unlocked.SetActive(true);
            chests_chosen = true;
        }
        if (name == "goldenChests")
        {
            goldenChests_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            goldenChests_unlocked.SetActive(true);
            goldenChests_chosen = true;
        }
        if (name == "skilledMiners")
        {
            skilledMiners_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            skilledMiners_unlocked.SetActive(true);
            skilledMiners_chosen = true;
        }
        if (name == "efficientBlacksmith")
        {
            efficientBlacksmith_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            efficientBlacksmith_unlocked.SetActive(true);
            efficientBlacksmith_chosen = true;

            blacksmithDecrease = 0.90f;
        }
        if (name == "itsASign")
        {
            itsASign_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            itsASign_unlocked.SetActive(true);
            itsASign_chosen = true;

            sign.SetActive(true);
            StartCoroutine(ChangeSignBuff());
        }
        if (name == "steamSale")
        {
            steamSale_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            steamSale_unlocked.SetActive(true);
            steamSale_chosen = true;

            steamSaleDiscount = 0.93f;
            skillTreeScript.SkillTreePrices();
        }
        if (name == "bigMiningArea")
        {
            bigMiningArea_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            bigMiningArea_unlocked.SetActive(true);
            bigMiningArea_chosen = true;

            StartCoroutine(ChanceToIncreaseMiningErea());
        }
        if (name == "itsHammerTime")
        {
            itsHammerTime_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            itsHammerTime_unlocked.SetActive(true);
            itsHammerTime_chosen = true;
        }
        if (name == "goldenTouch")
        {
            goldenTouch_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            goldenTouch_unlocked.SetActive(true);
            goldenTouch_chosen = true;
        }
        if (name == "zeus")
        {
            zeus_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            zeus_unlocked.SetActive(true);
            zeus_chosen = true;

            StartCoroutine(StartZeus());
        }
        if (name == "shapeShifter")
        {
            shapeShifter_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            shapeShifter_unlocked.SetActive(true);
            shapeShifter_chosen = true;

            shapeShifterSizeIncrease = 0.05f;
        }
        if (name == "xMarksTheSpor")
        {
            xMarksTheSpor_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            xMarksTheSpor_unlocked.SetActive(true);
            xMarksTheSpor_chosen = true;

            artifactScript.SetArtifactChances();
        }
        if (name == "explorer")
        {
            explorer_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            explorer_unlocked.SetActive(true);
            explorer_chosen = true;

            artifactScript.SetArtifactChances();
        }
        if (name == "archaeologist")
        {
            archaeologist_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            archaeologist_unlocked.SetActive(true);
            archaeologist_chosen = true;

            archeologistIncrease = 0.08f;

            SkillTree.improvedPickaxeStrength += 0.02f * archeologistIncrease;
            SkillTree.reducePickaxeMineTime -= 0.02f * archeologistIncrease;

            float spawnChanceIncrease = (1 + (0.03f * archeologistIncrease));

            SkillTree.fullGoldRockChance = SkillTree.fullGoldRockChance * spawnChanceIncrease;
            SkillTree.fullCopperRockChance = SkillTree.fullCopperRockChance * spawnChanceIncrease;
            SkillTree.fullIronRockChance = SkillTree.fullIronRockChance * spawnChanceIncrease;
            SkillTree.fullCobaltRockChance = SkillTree.fullCobaltRockChance * spawnChanceIncrease;
            SkillTree.fullUraniumRockChance = SkillTree.fullUraniumRockChance * spawnChanceIncrease;
            SkillTree.fullIsmiumRockChance = SkillTree.fullIsmiumRockChance * spawnChanceIncrease;
            SkillTree.fullIridiumRockChance = SkillTree.fullIridiumRockChance * spawnChanceIncrease;
            SkillTree.fullPainiteRockChance = SkillTree.fullPainiteRockChance * spawnChanceIncrease;
        }
        if (name == "energiDrinker")
        {
            energiDrinker_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            energiDrinker_unlocked.SetActive(true);
            energiDrinker_chosen = true;

            StartCoroutine(ChanceToDrinkEnergiDRink());
        }
        if (name == "springSeason")
        {
            springSeason_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            springSeason_unlocked.SetActive(true);
            springSeason_chosen = true;
        }
        if (name == "camper")
        {
            camper_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            camper_unlocked.SetActive(true);
            camper_chosen = true;
        }
        if (name == "d100")
        {
            d100_unlocked.transform.SetSiblingIndex(20);
            moveCardHere.SetSiblingIndex(20);

            d100_unlocked.SetActive(true);
            d100_chosen = true;
        }

        locScript.TalentCardsLeftText();

        if (cardsLeft < 3) { card1Left.SetActive(true); }
        if (cardsLeft < 2) { card2Left.SetActive(true); }
        if (cardsLeft < 1) { cardAllChosen.SetActive(true); }

        lockedTalent1.Play("BlockedCardDown");
        lockedTalent2.Play("BlockedCardDown");
        lockedTalent3.Play("BlockedCardDown");

        yield return new WaitForSeconds(0.45f);

        card1Number = 0;
        card2Number = 0;
        card3Number = 0;

        AddTalentCards();

        blockFrame.SetActive(false);

        unlockParent.SetActive(true);
        choose1Parent.SetActive(false);

        isInChoose1 = false;

        blockBtn.SetActive(false);
        isBlockFrameActive = false;
    }

    public TextMeshProUGUI talentLevelText;

    public GameObject potionDrinker_unlocked;
    public GameObject potionChugger_unlocked;
    public GameObject chests_unlocked;
    public GameObject goldenChests_unlocked;
    public GameObject skilledMiners_unlocked;
    public GameObject efficientBlacksmith_unlocked;
    public GameObject itsASign_unlocked;
    public GameObject steamSale_unlocked;
    public GameObject bigMiningArea_unlocked;
    public GameObject itsHammerTime_unlocked;
    public GameObject goldenTouch_unlocked;
    public GameObject zeus_unlocked;
    public GameObject shapeShifter_unlocked;
    public GameObject xMarksTheSpor_unlocked;
    public GameObject explorer_unlocked;
    public GameObject archaeologist_unlocked;
    public GameObject energiDrinker_unlocked;
    public GameObject springSeason_unlocked;
    public GameObject camper_unlocked;
    public GameObject d100_unlocked;
    #endregion

    #region Chance to increase the mining area
    public static bool isDoubleAreaSize;

    IEnumerator ChanceToIncreaseMiningErea()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            if(bigMiningArea_chosen == true && SetRockScreen.isInMiningSession == true)
            {
                float random = Random.Range(0,100);

                if(random < bigMiningAreaChance && isDoubleAreaSize == false)
                {
                    AllStats.inflateBurstTriggers += 1;

                    isDoubleAreaSize = true;
                    StartCoroutine(DoubleSizeCooldown());
                }
            }
        }
    }

    IEnumerator DoubleSizeCooldown()
    {
        yield return new WaitForSeconds(3);
        isDoubleAreaSize = false;
    }
    #endregion

    #region zeus
    public static bool isZeusActive;

    IEnumerator StartZeus()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            if(zeus_chosen && SetRockScreen.isInMiningSession)
            {
                float random = Random.Range(0,100);
                if(random < zeusChance && isZeusActive == false)
                {
                    AllStats.zeusTriggers += 1;

                    for (int i = 0; i < zeusLightningAmount; i++)
                    {
                        isZeusActive = true;

                        int randomBeam = Random.Range(0,2);
                        if(randomBeam == 0) { spawnProjectilesScript.SelectRandomActiveRock(2); }
                        if (randomBeam == 1) { spawnProjectilesScript.SelectRandomActiveRock(6); }

                        yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
                    }
                }
            }

            isZeusActive = false;
        }
    }
    #endregion

    #region Energi drinker
    public static bool isEnergiDrinkActive;
    public GameObject energiDrinkTopRight;

    IEnumerator ChanceToDrinkEnergiDRink()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            if (energiDrinker_chosen && SetRockScreen.isInMiningSession)
            {
                float random = Random.Range(0, 100);
                if (random < energiDrinkChance && isEnergiDrinkActive == false)
                {
                    AllStats.energiDrinksDrank += 1;

                    energiDrinkTopRight.SetActive(true);

                    isEnergiDrinkActive = true;

                    yield return new WaitForSeconds(energiDrinkTime);
                }
            }

            isEnergiDrinkActive = false;

            energiDrinkTopRight.SetActive(false); 
        }
    }
    #endregion

    #region Sign buffs
    public TextMeshProUGUI signBuffText;
    public static bool isSignFasterMine, isSignMineMoreMaterials, isSignDoubleMaterialsChance, isSignChanceToMine3XFaster;

    public static float signFasterMineAmount, signMine3XFasterChance;
    public static int signMoreMaterialsAmount, signDoubleMaterialsChance;

    int signBuff;

    IEnumerator ChangeSignBuff()
    {
        while (true)
        {
            isSignFasterMine = false; isSignMineMoreMaterials = false; isSignDoubleMaterialsChance = false; isSignChanceToMine3XFaster = false;
             signFasterMineAmount = 0; signDoubleMaterialsChance = 0;
            signMoreMaterialsAmount = 0; signMine3XFasterChance = 0;

            int randomBuff;

            do
            {
                randomBuff = Random.Range(1, 5);
            } while (signBuff == randomBuff);

            signBuff = randomBuff;

            if (randomBuff == 1) 
            {
                isSignFasterMine = true;
                signFasterMineAmount = Random.Range(0.02f, 0.04f);

                signBuffText.text = $"The Mine is {(signFasterMineAmount * 100).ToString("F1")}% faster";
            }
            if (randomBuff == 2)
            {
                isSignMineMoreMaterials = true;
                signMoreMaterialsAmount = Random.Range(3, 5);

                signBuffText.text = $"Mines {signMoreMaterialsAmount} more materials";
            }
            if (randomBuff == 3)
            {
                isSignDoubleMaterialsChance = true;
                signDoubleMaterialsChance = Random.Range(2, 4);

                signBuffText.text = $"{signDoubleMaterialsChance}% chance to double materials";
            }
            if (randomBuff == 4)
            {
                isSignChanceToMine3XFaster = true;
                signMine3XFasterChance = Random.Range(0.6f, 1f);

                signBuffText.text = $"{signMine3XFasterChance.ToString("F2")}% chance to mine 3X faster";
            }

            yield return new WaitForSeconds(300);
        }
    }
    #endregion


    #region Load Data
    public void LoadData(GameData data)
    {
        cardsLeft = data.cardsLeft;

        currentXP = data.currentXP;

        level = data.level;
        totalTalentPoints = data.totalTalentPoints;
        extraTalentPointPerLevelCOUNT = data.extraTalentPointPerLevelCOUNT;
        extraTalentPointBOOK = data.extraTalentPointBOOK;
        talentLevel = data.talentLevel;
        newTalentsPrice = data.newTalentsPrice;

        xpFromRock = data.xpFromRock;
        xpNeedForNextLvl = data.xpNeedForNextLvl;

        isInChoose1 = data.isInChoose1;
        isBlockFrameActive = data.isBlockFrameActive;

        potionDrinker_chosen = data.potionDrinker_chosen;
        potionChugger_chosen = data.potionChugger_chosen;
        chests_chosen = data.chests_chosen;
        goldenChests_chosen = data.goldenChests_chosen;
        skilledMiners_chosen = data.skilledMiners_chosen;
        efficientBlacksmith_chosen = data.efficientBlacksmith_chosen;
        itsASign_chosen = data.itsASign_chosen;
        steamSale_chosen = data.steamSale_chosen;
        bigMiningArea_chosen = data.bigMiningArea_chosen;
        itsHammerTime_chosen = data.itsHammerTime_chosen;
        goldenTouch_chosen = data.goldenTouch_chosen;
        zeus_chosen = data.zeus_chosen;
        shapeShifter_chosen = data.shapeShifter_chosen;
        xMarksTheSpor_chosen = data.xMarksTheSpor_chosen;
        explorer_chosen = data.explorer_chosen;
        archaeologist_chosen = data.archaeologist_chosen;
        energiDrinker_chosen = data.energiDrinker_chosen;
        springSeason_chosen = data.springSeason_chosen;
        camper_chosen = data.camper_chosen;
        d100_chosen = data.d100_chosen;
    }
    #endregion

    #region Save Data
    public void SaveData(ref GameData data)
    {
        data.cardsLeft = cardsLeft;

        data.currentXP = currentXP;

        data.level = level;
        data.totalTalentPoints = totalTalentPoints;
        data.extraTalentPointPerLevelCOUNT = extraTalentPointPerLevelCOUNT;
        data.extraTalentPointBOOK = extraTalentPointBOOK;
        data.talentLevel = talentLevel;
        data.newTalentsPrice = newTalentsPrice;

        data.xpFromRock = xpFromRock;
        data.xpNeedForNextLvl = xpNeedForNextLvl;

        data.isInChoose1 = isInChoose1;
        data.isBlockFrameActive = isBlockFrameActive;

        data.potionDrinker_chosen = potionDrinker_chosen;
        data.potionChugger_chosen = potionChugger_chosen;
        data.chests_chosen = chests_chosen;
        data.goldenChests_chosen = goldenChests_chosen;
        data.skilledMiners_chosen = skilledMiners_chosen;
        data.efficientBlacksmith_chosen = efficientBlacksmith_chosen;
        data.itsASign_chosen = itsASign_chosen;
        data.steamSale_chosen = steamSale_chosen;
        data.bigMiningArea_chosen = bigMiningArea_chosen;
        data.itsHammerTime_chosen = itsHammerTime_chosen;
        data.goldenTouch_chosen = goldenTouch_chosen;
        data.zeus_chosen = zeus_chosen;
        data.shapeShifter_chosen = shapeShifter_chosen;
        data.xMarksTheSpor_chosen = xMarksTheSpor_chosen;
        data.explorer_chosen = explorer_chosen;
        data.archaeologist_chosen = archaeologist_chosen;
        data.energiDrinker_chosen = energiDrinker_chosen;
        data.springSeason_chosen = springSeason_chosen;
        data.camper_chosen = camper_chosen;
        data.d100_chosen = d100_chosen;
    }
    #endregion

    public void ResetLevel()
    {
        sign.SetActive(false);

        SetOriginalStats();
        skillTreeScript.SkillTreePrices();

        potionDrinker_unlocked.SetActive(false);
        potionChugger_unlocked.SetActive(false);
        chests_unlocked.SetActive(false);
        goldenChests_unlocked.SetActive(false);
        skilledMiners_unlocked.SetActive(false);
        efficientBlacksmith_unlocked.SetActive(false);
        itsASign_unlocked.SetActive(false); 
        steamSale_unlocked.SetActive(false); 
        bigMiningArea_unlocked.SetActive(false);
        itsHammerTime_unlocked.SetActive(false);
        goldenTouch_unlocked.SetActive(false);
        zeus_unlocked.SetActive(false);
        shapeShifter_unlocked.SetActive(false);
        xMarksTheSpor_unlocked.SetActive(false);
        explorer_unlocked.SetActive(false);
        archaeologist_unlocked.SetActive(false);
        energiDrinker_unlocked.SetActive(false);
        springSeason_unlocked.SetActive(false);
        camper_unlocked.SetActive(false);
        d100_unlocked.SetActive(false);

        currentXP = 0;

        level = 1;
        totalTalentPoints = 0;
        extraTalentPointPerLevelCOUNT = 0;
        extraTalentPointBOOK = 0;
        talentLevel = 1;
        newTalentsPrice = 1;

        xpFromRock = 0.03f;
        xpNeedForNextLvl = 1f;

        isInChoose1 = false;
        isBlockFrameActive = false;

        potionDrinker_chosen = false;
        potionChugger_chosen = false;
        chests_chosen = false;
        goldenChests_chosen = false;
        skilledMiners_chosen = false;
        efficientBlacksmith_chosen = false;
        itsASign_chosen = false;
        steamSale_chosen = false;
        bigMiningArea_chosen = false;
        itsHammerTime_chosen = false;
        goldenTouch_chosen = false;
        zeus_chosen = false;
        shapeShifter_chosen = false;
        xMarksTheSpor_chosen = false;
        explorer_chosen = false;
        archaeologist_chosen = false;
        energiDrinker_chosen = false;
        springSeason_chosen = false;
        camper_chosen = false;
        d100_chosen = false;

        StopAllCoroutines();
        SetTalentTexts();

        card1Number = 0;
        card2Number = 0;
        card3Number = 0;

        AddTalentCards();

        potionDrinker_card.transform.localScale = new Vector2(1,1);
        potionChugger_Card.transform.localScale = new Vector2(1, 1);
        chests_card.transform.localScale = new Vector2(1, 1);
        goldenChests_card.transform.localScale = new Vector2(1, 1);
        skilledMiners_card.transform.localScale = new Vector2(1, 1);
        efficientBlacksmith_card.transform.localScale = new Vector2(1, 1);
        itsASign_card.transform.localScale = new Vector2(1, 1);
        steamSale_card.transform.localScale = new Vector2(1, 1);
        bigMiningArea_card.transform.localScale = new Vector2(1, 1);
        itsHammerTime_card.transform.localScale = new Vector2(1, 1);
        goldenTouch_card.transform.localScale = new Vector2(1, 1);
        zeus_card.transform.localScale = new Vector2(1, 1);
        shapeShifter_card.transform.localScale = new Vector2(1, 1);
        xMarksTheSpor_card.transform.localScale = new Vector2(1, 1);
        explorer_card.transform.localScale = new Vector2(1, 1);
        archaeologist_Card.transform.localScale = new Vector2(1, 1);
        energiDrinker_card.transform.localScale = new Vector2(1, 1);
        springSeason_card.transform.localScale = new Vector2(1, 1);
        camper_card.transform.localScale = new Vector2(1, 1);
        d100_card.transform.localScale = new Vector2(1, 1);

        cardsLeft = 20;

        card1Left.SetActive(true);
        card2Left.SetActive(true);
        cardAllChosen.SetActive(true);

        allTalentCardsChosenBlockBtn.SetActive(true);
    }
}
