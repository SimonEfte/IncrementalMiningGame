using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AllStats : MonoBehaviour, IDataPersistence
{
    public static int potionsDrank, chestsOpened, goldenChestsOpened, theMine2XTriggers, theMineDoubleTriggers, inflateBurstTriggers, hammersSpawned, midasTouchSessions, zeusTriggers, energiDrinksDrank, flowersSpawned, campfiresSpawned, d100Rolls;

    public static int miningSessions, timeSpentMining, totalRocksSpawned, totalRockMined, pickaxesSpawned, pickaxeHits, totalLevelUps, doubleXPGained, doubleOreGained, doublePickaxePowerHits, instaMinePickaxeHits, lightningStrikes, dynamiteExplosions, plazmaBallsSpawned;

    public static double oresMined, barsCrafted, bardMinedTHEMINE;
    public static float experienceGained;

    public static int goldChunkMined, fullGoldMined, copperChunkMined, fullCopperMined, ironChunkMined, fullIronMined, cobaltChunkMined, fullCobaltMined, uraniumChunkMined, fullUraniumMined, ismiumChunkMined, fullIsmiumMined, iridiumChunkMined, fullIridiumMined, painiteChunkMined, fullPainiteMined;

    public static bool isInStats;

    #region Text variables
    [Header("General Stats")]
    public TextMeshProUGUI potionsDrankTMP;
    public TextMeshProUGUI chestsOpenedTMP;
    public TextMeshProUGUI goldenChestsOpenedTMP;
    public TextMeshProUGUI theMine2XTriggeredTMP;
    public TextMeshProUGUI theMineDoubleTriggeredTMP;
    public TextMeshProUGUI inflateBurstTriggeredTMP;
    public TextMeshProUGUI hammersSpawnedTMP;
    public TextMeshProUGUI midasTouchSessionsTMP;
    public TextMeshProUGUI zeusTriggersTMP;
    public TextMeshProUGUI energiDrinksDrankTMP;
    public TextMeshProUGUI flowersSpawnedTMP;
    public TextMeshProUGUI campfiresSpawnedTMP;
    public TextMeshProUGUI d100RollsTMP;

    [Header("Mining Stats")]
    public TextMeshProUGUI miningSessionsTMP;
    public TextMeshProUGUI timeSpentMiningTMP;
    public TextMeshProUGUI totalRocksSpawnedTMP;
    public TextMeshProUGUI totalRockMinedTMP;
    public TextMeshProUGUI pickaxesSpawnedTMP;
    public TextMeshProUGUI pickaxeHitsTMP;
    public TextMeshProUGUI totalLevelUpsTMP;
    public TextMeshProUGUI doubleXPGainedTMP;
    public TextMeshProUGUI doubleOreGainedTMP;
    public TextMeshProUGUI doublePickaxePowerHitsTMP;
    public TextMeshProUGUI instaMinePickaxeHitsTMP;
    public TextMeshProUGUI lightningStrikesTMP;
    public TextMeshProUGUI dynamiteExplosionsTMP;
    public TextMeshProUGUI plazmaBallsSpawnedTMP;

    [Header("Resources Stats")]
    public TextMeshProUGUI oresMinedTMP;
    public TextMeshProUGUI barsCraftedTMP;
    public TextMeshProUGUI bardMinedTHEMINETMP;
    public TextMeshProUGUI experienceGainedTMP;

    [Header("Ore Breakdown")]
    public TextMeshProUGUI goldChunkMinedTMP;
    public TextMeshProUGUI fullGoldMinedTMP;
    public TextMeshProUGUI copperChunkMinedTMP;
    public TextMeshProUGUI fullCopperMinedTMP;
    public TextMeshProUGUI ironChunkMinedTMP;
    public TextMeshProUGUI fullIronMinedTMP;
    public TextMeshProUGUI cobaltChunkMinedTMP;
    public TextMeshProUGUI fullCobaltMinedTMP;
    public TextMeshProUGUI uraniumChunkMinedTMP;
    public TextMeshProUGUI fullUraniumMinedTMP;
    public TextMeshProUGUI ismiumChunkMinedTMP;
    public TextMeshProUGUI fullIsmiumMinedTMP;
    public TextMeshProUGUI iridiumChunkMinedTMP;
    public TextMeshProUGUI fullIridiumMinedTMP;
    public TextMeshProUGUI painiteChunkMinedTMP;
    public TextMeshProUGUI fullPainiteMinedTMP;
    #endregion

    #region questionmark texts
    [Header("General Stats - Questionmarks")]
    public TextMeshProUGUI potionsDrank_questionmark;
    public TextMeshProUGUI chestsOpened_questionmark;
    public TextMeshProUGUI goldenChestsOpened_questionmark;
    public TextMeshProUGUI theMine2XTriggered_questionmark;
    public TextMeshProUGUI theMineDoubleTriggered_questionmark;
    public TextMeshProUGUI inflateBurstTriggered_questionmark;
    public TextMeshProUGUI hammersSpawned_questionmark;
    public TextMeshProUGUI midasTouchSessions_questionmark;
    public TextMeshProUGUI zeusTriggers_questionmark;
    public TextMeshProUGUI energiDrinksDrank_questionmark;
    public TextMeshProUGUI flowersSpawned_questionmark;
    public TextMeshProUGUI campfiresSpawned_questionmark;
    public TextMeshProUGUI d100Rolls_questionmark;

    [Header("Mining Stats - Questionmarks")]
    public TextMeshProUGUI lightningStrikes_questionmark;
    public TextMeshProUGUI dynamiteExplosions_questionmark;
    public TextMeshProUGUI plazmaBallsSpawned_questionmark;

    [Header("Ore Breakdown - Questionmarks (except Gold)")]
    public TextMeshProUGUI copperChunkMined_questionmark;
    public TextMeshProUGUI fullCopperMined_questionmark;
    public TextMeshProUGUI ironChunkMined_questionmark;
    public TextMeshProUGUI fullIronMined_questionmark;
    public TextMeshProUGUI cobaltChunkMined_questionmark;
    public TextMeshProUGUI fullCobaltMined_questionmark;
    public TextMeshProUGUI uraniumChunkMined_questionmark;
    public TextMeshProUGUI fullUraniumMined_questionmark;
    public TextMeshProUGUI ismiumChunkMined_questionmark;
    public TextMeshProUGUI fullIsmiumMined_questionmark;
    public TextMeshProUGUI iridiumChunkMined_questionmark;
    public TextMeshProUGUI fullIridiumMined_questionmark;
    public TextMeshProUGUI painiteChunkMined_questionmark;
    public TextMeshProUGUI fullPainiteMined_questionmark;
    #endregion

    #region left texts
    [Header("General Stats - Left Text")]
    public TextMeshProUGUI potionsDrank_leftText;
    public TextMeshProUGUI chestsOpened_leftText;
    public TextMeshProUGUI goldenChestsOpened_leftText;
    public TextMeshProUGUI theMine2XTriggered_leftText;
    public TextMeshProUGUI theMineDoubleTriggered_leftText;
    public TextMeshProUGUI inflateBurstTriggered_leftText;
    public TextMeshProUGUI hammersSpawned_leftText;
    public TextMeshProUGUI midasTouchSessions_leftText;
    public TextMeshProUGUI zeusTriggers_leftText;
    public TextMeshProUGUI energiDrinksDrank_leftText;
    public TextMeshProUGUI flowersSpawned_leftText;
    public TextMeshProUGUI campfiresSpawned_leftText;
    public TextMeshProUGUI d100Rolls_leftText;

    [Header("Mining Stats - Left Text")]
    public TextMeshProUGUI lightningStrikes_leftText;
    public TextMeshProUGUI dynamiteExplosions_leftText;
    public TextMeshProUGUI plazmaBallsSpawned_leftText;

    [Header("Ore Breakdown - Left Text (except Gold)")]
    public TextMeshProUGUI copperChunkMined_leftText;
    public TextMeshProUGUI fullCopperMined_leftText;
    public TextMeshProUGUI ironChunkMined_leftText;
    public TextMeshProUGUI fullIronMined_leftText;
    public TextMeshProUGUI cobaltChunkMined_leftText;
    public TextMeshProUGUI fullCobaltMined_leftText;
    public TextMeshProUGUI uraniumChunkMined_leftText;
    public TextMeshProUGUI fullUraniumMined_leftText;
    public TextMeshProUGUI ismiumChunkMined_leftText;
    public TextMeshProUGUI fullIsmiumMined_leftText;
    public TextMeshProUGUI iridiumChunkMined_leftText;
    public TextMeshProUGUI fullIridiumMined_leftText;
    public TextMeshProUGUI painiteChunkMined_leftText;
    public TextMeshProUGUI fullPainiteMined_leftText;
    #endregion

    #region Check question marks
    public void CheckQuestionMarkText()
    {
        // Talent cards
        if (LevelMechanics.potionDrinker_chosen)
        {
            potionsDrank_leftText.gameObject.SetActive(true);
            potionsDrank_questionmark.gameObject.SetActive(false);
        }
        else
        {
            potionsDrank_leftText.gameObject.SetActive(false);
            potionsDrank_questionmark.gameObject.SetActive(true);
        }

        if (LevelMechanics.chests_chosen)
        {
            chestsOpened_leftText.gameObject.SetActive(true);
            chestsOpened_questionmark.gameObject.SetActive(false);
        }
        else
        {
            chestsOpened_leftText.gameObject.SetActive(false);
            chestsOpened_questionmark.gameObject.SetActive(true);
        }

        if (LevelMechanics.goldenChests_chosen)
        {
            goldenChestsOpened_leftText.gameObject.SetActive(true);
            goldenChestsOpened_questionmark.gameObject.SetActive(false);
        }
        else
        {
            goldenChestsOpened_leftText.gameObject.SetActive(false);
            goldenChestsOpened_questionmark.gameObject.SetActive(true);
        }

        if (LevelMechanics.skilledMiners_chosen)
        {
            theMine2XTriggered_leftText.gameObject.SetActive(true);
            theMine2XTriggered_questionmark.gameObject.SetActive(false);

            theMineDoubleTriggered_leftText.gameObject.SetActive(true);
            theMineDoubleTriggered_questionmark.gameObject.SetActive(false);
        }
        else
        {
            theMine2XTriggered_leftText.gameObject.SetActive(false);
            theMine2XTriggered_questionmark.gameObject.SetActive(true);

            theMineDoubleTriggered_leftText.gameObject.SetActive(false);
            theMineDoubleTriggered_questionmark.gameObject.SetActive(true);
        }

        if (LevelMechanics.bigMiningArea_chosen)
        {
            inflateBurstTriggered_leftText.gameObject.SetActive(true);
            inflateBurstTriggered_questionmark.gameObject.SetActive(false);
        }
        else
        {
            inflateBurstTriggered_leftText.gameObject.SetActive(false);
            inflateBurstTriggered_questionmark.gameObject.SetActive(true);
        }

        if (LevelMechanics.itsHammerTime_chosen)
        {
            hammersSpawned_leftText.gameObject.SetActive(true);
            hammersSpawned_questionmark.gameObject.SetActive(false);
        }
        else
        {
            hammersSpawned_leftText.gameObject.SetActive(false);
            hammersSpawned_questionmark.gameObject.SetActive(true);
        }

        if (LevelMechanics.goldenTouch_chosen)
        {
            midasTouchSessions_leftText.gameObject.SetActive(true);
            midasTouchSessions_questionmark.gameObject.SetActive(false);
        }
        else
        {
            midasTouchSessions_leftText.gameObject.SetActive(false);
            midasTouchSessions_questionmark.gameObject.SetActive(true);
        }

        if (LevelMechanics.zeus_chosen)
        {
            zeusTriggers_leftText.gameObject.SetActive(true);
            zeusTriggers_questionmark.gameObject.SetActive(false);
        }
        else
        {
            zeusTriggers_leftText.gameObject.SetActive(false);
            zeusTriggers_questionmark.gameObject.SetActive(true);
        }

        if (LevelMechanics.energiDrinker_chosen)
        {
            energiDrinksDrank_leftText.gameObject.SetActive(true);
            energiDrinksDrank_questionmark.gameObject.SetActive(false);
        }
        else
        {
            energiDrinksDrank_leftText.gameObject.SetActive(false);
            energiDrinksDrank_questionmark.gameObject.SetActive(true);
        }

        if (LevelMechanics.springSeason_chosen)
        {
            flowersSpawned_leftText.gameObject.SetActive(true);
            flowersSpawned_questionmark.gameObject.SetActive(false);
        }
        else
        {
            flowersSpawned_leftText.gameObject.SetActive(false);
            flowersSpawned_questionmark.gameObject.SetActive(true);
        }

        if (LevelMechanics.camper_chosen)
        {
            campfiresSpawned_leftText.gameObject.SetActive(true);
            campfiresSpawned_questionmark.gameObject.SetActive(false);
        }
        else
        {
            campfiresSpawned_leftText.gameObject.SetActive(false);
            campfiresSpawned_questionmark.gameObject.SetActive(true);
        }

        if (LevelMechanics.d100_chosen)
        {
            d100Rolls_leftText.gameObject.SetActive(true);
            d100Rolls_questionmark.gameObject.SetActive(false);
        }
        else
        {
            d100Rolls_leftText.gameObject.SetActive(false);
            d100Rolls_questionmark.gameObject.SetActive(true);
        }

        // Lightning, dynamite and plazma balls
        if (SkillTree.lightningBeamChancePH_1_purchased == false && SkillTree.lightningBeamChanceS_1_purchased == false)
        {
            lightningStrikes_leftText.gameObject.SetActive(false);
            lightningStrikes_questionmark.gameObject.SetActive(true);
        }
        else
        {
            lightningStrikes_leftText.gameObject.SetActive(true);
            lightningStrikes_questionmark.gameObject.SetActive(false);
        }

        if (SkillTree.dynamiteChance_1_purchased == true)
        {
            dynamiteExplosions_leftText.gameObject.SetActive(true);
            dynamiteExplosions_questionmark.gameObject.SetActive(false);
        }
        else
        {
            dynamiteExplosions_leftText.gameObject.SetActive(false);
            dynamiteExplosions_questionmark.gameObject.SetActive(true);
        }

        if (SkillTree.plazmaBallSpawn_1_purchased == true)
        {
            plazmaBallsSpawned_leftText.gameObject.SetActive(true);
            plazmaBallsSpawned_questionmark.gameObject.SetActive(false);
        }
        else
        {
            plazmaBallsSpawned_leftText.gameObject.SetActive(false);
            plazmaBallsSpawned_questionmark.gameObject.SetActive(true);
        }

        // Materials mined
        if (SkillTree.spawnCopper_purchased)
        {
            copperChunkMined_leftText.gameObject.SetActive(true);
            copperChunkMined_questionmark.gameObject.SetActive(false);
            fullCopperMined_leftText.gameObject.SetActive(true);
            fullCopperMined_questionmark.gameObject.SetActive(false);
        }
        else
        {
            copperChunkMined_leftText.gameObject.SetActive(false);
            copperChunkMined_questionmark.gameObject.SetActive(true);
            fullCopperMined_leftText.gameObject.SetActive(false);
            fullCopperMined_questionmark.gameObject.SetActive(true);
        }

        if (SkillTree.spawnIron_purchased)
        {
            ironChunkMined_leftText.gameObject.SetActive(true);
            ironChunkMined_questionmark.gameObject.SetActive(false);
            fullIronMined_leftText.gameObject.SetActive(true);
            fullIronMined_questionmark.gameObject.SetActive(false);
        }
        else
        {
            ironChunkMined_leftText.gameObject.SetActive(false);
            ironChunkMined_questionmark.gameObject.SetActive(true);
            fullIronMined_leftText.gameObject.SetActive(false);
            fullIronMined_questionmark.gameObject.SetActive(true);
        }

        if (SkillTree.cobaltSpawn_purchased)
        {
            cobaltChunkMined_leftText.gameObject.SetActive(true);
            cobaltChunkMined_questionmark.gameObject.SetActive(false);
            fullCobaltMined_leftText.gameObject.SetActive(true);
            fullCobaltMined_questionmark.gameObject.SetActive(false);
        }
        else
        {
            cobaltChunkMined_leftText.gameObject.SetActive(false);
            cobaltChunkMined_questionmark.gameObject.SetActive(true);
            fullCobaltMined_leftText.gameObject.SetActive(false);
            fullCobaltMined_questionmark.gameObject.SetActive(true);
        }

        if (SkillTree.uraniumSpawn_purchased)
        {
            uraniumChunkMined_leftText.gameObject.SetActive(true);
            uraniumChunkMined_questionmark.gameObject.SetActive(false);
            fullUraniumMined_leftText.gameObject.SetActive(true);
            fullUraniumMined_questionmark.gameObject.SetActive(false);
        }
        else
        {
            uraniumChunkMined_leftText.gameObject.SetActive(false);
            uraniumChunkMined_questionmark.gameObject.SetActive(true);
            fullUraniumMined_leftText.gameObject.SetActive(false);
            fullUraniumMined_questionmark.gameObject.SetActive(true);
        }

        if (SkillTree.ismiumSpawn_purchased)
        {
            ismiumChunkMined_leftText.gameObject.SetActive(true);
            ismiumChunkMined_questionmark.gameObject.SetActive(false);
            fullIsmiumMined_leftText.gameObject.SetActive(true);
            fullIsmiumMined_questionmark.gameObject.SetActive(false);
        }
        else
        {
            ismiumChunkMined_leftText.gameObject.SetActive(false);
            ismiumChunkMined_questionmark.gameObject.SetActive(true);
            fullIsmiumMined_leftText.gameObject.SetActive(false);
            fullIsmiumMined_questionmark.gameObject.SetActive(true);
        }

        if (SkillTree.iridiumSpawn_purchased)
        {
            iridiumChunkMined_leftText.gameObject.SetActive(true);
            iridiumChunkMined_questionmark.gameObject.SetActive(false);
            fullIridiumMined_leftText.gameObject.SetActive(true);
            fullIridiumMined_questionmark.gameObject.SetActive(false);
        }
        else
        {
            iridiumChunkMined_leftText.gameObject.SetActive(false);
            iridiumChunkMined_questionmark.gameObject.SetActive(true);
            fullIridiumMined_leftText.gameObject.SetActive(false);
            fullIridiumMined_questionmark.gameObject.SetActive(true);
        }

        if (SkillTree.painiteSpawn_purchased)
        {
            painiteChunkMined_leftText.gameObject.SetActive(true);
            painiteChunkMined_questionmark.gameObject.SetActive(false);
            fullPainiteMined_leftText.gameObject.SetActive(true);
            fullPainiteMined_questionmark.gameObject.SetActive(false);
        }
        else
        {
            painiteChunkMined_leftText.gameObject.SetActive(false);
            painiteChunkMined_questionmark.gameObject.SetActive(true);
            fullPainiteMined_leftText.gameObject.SetActive(false);
            fullPainiteMined_questionmark.gameObject.SetActive(true);
        }
    }
    #endregion

    private void Update()
    {
        if (isInStats)
        {
            potionsDrankTMP.text = potionsDrank.ToString();
            chestsOpenedTMP.text = chestsOpened.ToString();
            goldenChestsOpenedTMP.text = goldenChestsOpened.ToString();
            theMine2XTriggeredTMP.text = theMine2XTriggers.ToString();
            theMineDoubleTriggeredTMP.text = theMineDoubleTriggers.ToString();
            inflateBurstTriggeredTMP.text = inflateBurstTriggers.ToString();
            hammersSpawnedTMP.text = hammersSpawned.ToString();
            midasTouchSessionsTMP.text = midasTouchSessions.ToString();
            zeusTriggersTMP.text = zeusTriggers.ToString();
            energiDrinksDrankTMP.text = energiDrinksDrank.ToString();
            flowersSpawnedTMP.text = flowersSpawned.ToString();
            campfiresSpawnedTMP.text = campfiresSpawned.ToString();
            d100RollsTMP.text = d100Rolls.ToString();

            miningSessionsTMP.text = miningSessions.ToString();
            timeSpentMiningTMP.text = timeSpentMining.ToString();
            totalRocksSpawnedTMP.text = totalRocksSpawned.ToString();
            totalRockMinedTMP.text = totalRockMined.ToString();
            pickaxesSpawnedTMP.text = pickaxesSpawned.ToString();
            pickaxeHitsTMP.text = pickaxeHits.ToString();
            totalLevelUpsTMP.text = totalLevelUps.ToString();
            doubleXPGainedTMP.text = doubleXPGained.ToString();
            doubleOreGainedTMP.text = doubleOreGained.ToString();
            doublePickaxePowerHitsTMP.text = doublePickaxePowerHits.ToString();
            instaMinePickaxeHitsTMP.text = instaMinePickaxeHits.ToString();
            lightningStrikesTMP.text = lightningStrikes.ToString();
            dynamiteExplosionsTMP.text = dynamiteExplosions.ToString();
            plazmaBallsSpawnedTMP.text = plazmaBallsSpawned.ToString();

            oresMinedTMP.text = FormatNumbers.FormatPoints(oresMined);
            barsCraftedTMP.text = FormatNumbers.FormatPoints(barsCrafted);
            bardMinedTHEMINETMP.text = FormatNumbers.FormatPoints(bardMinedTHEMINE);
            experienceGainedTMP.text = FormatNumbers.FormatPoints(experienceGained * 100);

            goldChunkMinedTMP.text = goldChunkMined.ToString();
            fullGoldMinedTMP.text = fullGoldMined.ToString();
            copperChunkMinedTMP.text = copperChunkMined.ToString();
            fullCopperMinedTMP.text = fullCopperMined.ToString();
            ironChunkMinedTMP.text = ironChunkMined.ToString();
            fullIronMinedTMP.text = fullIronMined.ToString();
            cobaltChunkMinedTMP.text = cobaltChunkMined.ToString();
            fullCobaltMinedTMP.text = fullCobaltMined.ToString();
            uraniumChunkMinedTMP.text = uraniumChunkMined.ToString();
            fullUraniumMinedTMP.text = fullUraniumMined.ToString();
            ismiumChunkMinedTMP.text = ismiumChunkMined.ToString();
            fullIsmiumMinedTMP.text = fullIsmiumMined.ToString();
            iridiumChunkMinedTMP.text = iridiumChunkMined.ToString();
            fullIridiumMinedTMP.text = fullIridiumMined.ToString();
            painiteChunkMinedTMP.text = painiteChunkMined.ToString();
            fullPainiteMinedTMP.text = fullPainiteMined.ToString();
        }
    }

    #region Load Data
    public void LoadData(GameData data)
    {
        potionsDrank = data.potionsDrank;
        chestsOpened = data.chestsOpened;
        goldenChestsOpened = data.goldenChestsOpened;
        theMine2XTriggers = data.theMine2XTriggers;
        theMineDoubleTriggers = data.theMineDoubleTriggers;
        inflateBurstTriggers = data.inflateBurstTriggers;
        hammersSpawned = data.hammersSpawned;
        midasTouchSessions = data.midasTouchSessions;
        zeusTriggers = data.zeusTriggers;
        energiDrinksDrank = data.energiDrinksDrank;
        flowersSpawned = data.flowersSpawned;
        campfiresSpawned = data.campfiresSpawned;
        d100Rolls = data.d100Rolls;

        miningSessions = data.miningSessions;
        timeSpentMining = data.timeSpentMining;
        totalRocksSpawned = data.totalRocksSpawned;
        totalRockMined = data.totalRockMined;
        pickaxesSpawned = data.pickaxesSpawned;
        pickaxeHits = data.pickaxeHits;
        totalLevelUps = data.totalLevelUps;
        doubleXPGained = data.doubleXPGained;
        doubleOreGained = data.doubleOreGained;
        doublePickaxePowerHits = data.doublePickaxePowerHits;
        instaMinePickaxeHits = data.instaMinePickaxeHits;
        lightningStrikes = data.lightningStrikes;
        dynamiteExplosions = data.dynamiteExplosions;
        plazmaBallsSpawned = data.plazmaBallsSpawned;

        oresMined = data.oresMined;
        barsCrafted = data.barsCrafted;
        bardMinedTHEMINE = data.bardMinedTHEMINE;

        experienceGained = data.experienceGained;

        goldChunkMined = data.goldChunkMined;
        fullGoldMined = data.fullGoldMined;
        copperChunkMined = data.copperChunkMined;
        fullCopperMined = data.fullCopperMined;
        ironChunkMined = data.ironChunkMined;
        fullIronMined = data.fullIronMined;
        cobaltChunkMined = data.cobaltChunkMined;
        fullCobaltMined = data.fullCobaltMined;
        uraniumChunkMined = data.uraniumChunkMined;
        fullUraniumMined = data.fullUraniumMined;
        ismiumChunkMined = data.ismiumChunkMined;
        fullIsmiumMined = data.fullIsmiumMined;
        iridiumChunkMined = data.iridiumChunkMined;
        fullIridiumMined = data.fullIridiumMined;
        painiteChunkMined = data.painiteChunkMined;
        fullPainiteMined = data.fullPainiteMined;
    }
    #endregion

    #region Save Data
    public void SaveData(ref GameData data)
    {
        data.potionsDrank = potionsDrank;
        data.chestsOpened = chestsOpened;
        data.goldenChestsOpened = goldenChestsOpened;
        data.theMine2XTriggers = theMine2XTriggers;
        data.theMineDoubleTriggers = theMineDoubleTriggers;
        data.inflateBurstTriggers = inflateBurstTriggers;
        data.hammersSpawned = hammersSpawned;
        data.midasTouchSessions = midasTouchSessions;
        data.zeusTriggers = zeusTriggers;
        data.energiDrinksDrank = energiDrinksDrank;
        data.flowersSpawned = flowersSpawned;
        data.campfiresSpawned = campfiresSpawned;
        data.d100Rolls = d100Rolls;

        data.miningSessions = miningSessions;
        data.timeSpentMining = timeSpentMining;
        data.totalRocksSpawned = totalRocksSpawned;
        data.totalRockMined = totalRockMined;
        data.pickaxesSpawned = pickaxesSpawned;
        data.pickaxeHits = pickaxeHits;
        data.totalLevelUps = totalLevelUps;
        data.doubleXPGained = doubleXPGained;
        data.doubleOreGained = doubleOreGained;
        data.doublePickaxePowerHits = doublePickaxePowerHits;
        data.instaMinePickaxeHits = instaMinePickaxeHits;
        data.lightningStrikes = lightningStrikes;
        data.dynamiteExplosions = dynamiteExplosions;
        data.plazmaBallsSpawned = plazmaBallsSpawned;

        data.oresMined = oresMined;
        data.barsCrafted = barsCrafted;
        data.bardMinedTHEMINE = bardMinedTHEMINE;

        data.experienceGained = experienceGained;

        data.goldChunkMined = goldChunkMined;
        data.fullGoldMined = fullGoldMined;
        data.copperChunkMined = copperChunkMined;
        data.fullCopperMined = fullCopperMined;
        data.ironChunkMined = ironChunkMined;
        data.fullIronMined = fullIronMined;
        data.cobaltChunkMined = cobaltChunkMined;
        data.fullCobaltMined = fullCobaltMined;
        data.uraniumChunkMined = uraniumChunkMined;
        data.fullUraniumMined = fullUraniumMined;
        data.ismiumChunkMined = ismiumChunkMined;
        data.fullIsmiumMined = fullIsmiumMined;
        data.iridiumChunkMined = iridiumChunkMined;
        data.fullIridiumMined = fullIridiumMined;
        data.painiteChunkMined = painiteChunkMined;
        data.fullPainiteMined = fullPainiteMined;
    }
    #endregion

    public void ResetStats()
    {
        potionsDrank = 0;
        chestsOpened = 0;
        goldenChestsOpened = 0;
        theMine2XTriggers = 0;
        theMineDoubleTriggers = 0;
        inflateBurstTriggers = 0;
        hammersSpawned = 0;
        midasTouchSessions = 0;
        zeusTriggers = 0;
        energiDrinksDrank = 0;
        flowersSpawned = 0;
        campfiresSpawned = 0;
        d100Rolls = 0;

        miningSessions = 0;
        timeSpentMining = 0;
        totalRocksSpawned = 0;
        totalRockMined = 0;
        pickaxesSpawned = 0;
        pickaxeHits = 0;
        totalLevelUps = 0;
        doubleXPGained = 0;
        doubleOreGained = 0;
        doublePickaxePowerHits = 0;
        instaMinePickaxeHits = 0;
        lightningStrikes = 0;
        dynamiteExplosions = 0;
        plazmaBallsSpawned = 0;

        oresMined = 0.0;
        barsCrafted = 0.0;
        bardMinedTHEMINE = 0.0;

        experienceGained = 0f;

        goldChunkMined = 0;
        fullGoldMined = 0;
        copperChunkMined = 0;
        fullCopperMined = 0;
        ironChunkMined = 0;
        fullIronMined = 0;
        cobaltChunkMined = 0;
        fullCobaltMined = 0;
        uraniumChunkMined = 0;
        fullUraniumMined = 0;
        ismiumChunkMined = 0;
        fullIsmiumMined = 0;
        iridiumChunkMined = 0;
        fullIridiumMined = 0;
        painiteChunkMined = 0;
        fullPainiteMined = 0;
    }
}
