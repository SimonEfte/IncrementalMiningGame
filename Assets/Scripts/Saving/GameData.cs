using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public GameData()
    {
        SetTutorialSaves();
        TalenSaves();
        StatsSaves();
        ArtifactSaves();
        GoldBarsSaves();
        PickaxeSaves();
        TheMineSaves();
        SkillTreeSaves();
        SetEndingSaves();
    }

    #region Tutorial saves
    public bool pressedOkMiningSession;
    public bool pressedOkCraftingTurotialFrame;
    public bool pressedOkTalent;
    public bool pressedOkAnvil;
    public bool pressedOkMine;
    public bool pressedOkArtifact;

    public void SetTutorialSaves()
    {
        pressedOkMiningSession = false;
        pressedOkCraftingTurotialFrame = false;
        pressedOkTalent = false;
        pressedOkAnvil = false;
        pressedOkMine = false;
        pressedOkArtifact = false;
    }
    #endregion

    #region End Saves
    public bool isEndingCompleted;

    public void SetEndingSaves()
    {
        isEndingCompleted = false;
    }
    #endregion

    #region Talent Saves
    public int level;
    public int totalTalentPoints;
    public int extraTalentPointPerLevelCOUNT;
    public int extraTalentPointBOOK;
    public int talentLevel;
    public int newTalentsPrice;

    // Floats
    public float xpFromRock;
    public float xpNeedForNextLvl;

    // Booleans
    public bool isInChoose1;
    public bool isBlockFrameActive;
    public bool potionDrinker_chosen;
    public bool potionChugger_chosen;
    public bool chests_chosen;
    public bool goldenChests_chosen;
    public bool skilledMiners_chosen;
    public bool efficientBlacksmith_chosen;
    public bool itsASign_chosen;
    public bool steamSale_chosen;
    public bool bigMiningArea_chosen;
    public bool itsHammerTime_chosen;
    public bool goldenTouch_chosen;
    public bool zeus_chosen;
    public bool shapeShifter_chosen;
    public bool xMarksTheSpor_chosen;
    public bool explorer_chosen;
    public bool archaeologist_chosen;
    public bool energiDrinker_chosen;
    public bool springSeason_chosen;
    public bool camper_chosen;
    public bool d100_chosen;
    public float currentXP;

    public int cardsLeft;

    public int talentCard1Picked, talentCard2Picked, talentCard3Picked;

    public void TalenSaves()
    {
        talentCard1Picked = 0;
        talentCard2Picked = 0;
        talentCard3Picked = 0;

        cardsLeft = 20;

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
    }
    #endregion

    #region Stats Saves
    public int potionsDrank, chestsOpened, goldenChestsOpened, theMine2XTriggers, theMineDoubleTriggers, inflateBurstTriggers, hammersSpawned, midasTouchSessions, zeusTriggers, energiDrinksDrank, flowersSpawned, campfiresSpawned, d100Rolls;

    public int miningSessions, timeSpentMining, totalRocksSpawned, totalRockMined, pickaxesSpawned, pickaxeHits, totalLevelUps, doubleXPGained, doubleOreGained, doublePickaxePowerHits, instaMinePickaxeHits, lightningStrikes, dynamiteExplosions, plazmaBallsSpawned;

    public int goldChunkMined, fullGoldMined, copperChunkMined, fullCopperMined, ironChunkMined, fullIronMined, cobaltChunkMined, fullCobaltMined, uraniumChunkMined, fullUraniumMined, ismiumChunkMined, fullIsmiumMined, iridiumChunkMined, fullIridiumMined, painiteChunkMined, fullPainiteMined;

    // Doubles
    public double oresMined, barsCrafted, bardMinedTHEMINE;

    // Floats
    public float experienceGained;

    public void StatsSaves()
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
    #endregion

    #region Artifact Saves
    public int artifactsFound;

    public bool horn_found, ancientDevice_found, bone_found, meteorieOre_found, book_found, goldStack_found, goldRing_found, purpleRing_found, ancientDice_found, cheese_found, wolfClaw_found, axe_found, rune_found, skull_found;

    public void ArtifactSaves()
    {
        artifactsFound = 0;

        horn_found = false;
        ancientDevice_found = false;
        bone_found = false;
        meteorieOre_found = false;
        book_found = false;
        goldStack_found = false;
        goldRing_found = false;
        purpleRing_found = false;
        ancientDice_found = false;
        cheese_found = false;
        wolfClaw_found = false;
        axe_found = false;
        rune_found = false;
        skull_found = false;
    }
    #endregion

    #region Gold Bars Saves
    public double totalGoldBars;
    public double totalCopperBars;
    public double totalIronBars;
    public double totalCobaltBars;
    public double totalUraniumBars;
    public double totalIsmiumBar; 
    public double totalIridiumBars;
    public double totalPainiteBars;

    public void GoldBarsSaves()
    {
        totalGoldBars = 0.494f;
        totalCopperBars = 0.494f;
        totalIronBars = 0.494f;
        totalCobaltBars = 0.494f;
        totalUraniumBars = 0.494f;
        totalIsmiumBar = 0.494f;
        totalIridiumBars = 0.494f;
        totalPainiteBars = 0.494f;
    }
    #endregion

    #region Pickaxes saves
    public bool pickaxe1_crafted, pickaxe2_crafted, pickaxe3_crafted, pickaxe4_crafted,
            pickaxe5_crafted, pickaxe6_crafted, pickaxe7_crafted, pickaxe8_crafted,
            pickaxe9_crafted, pickaxe10_crafted, pickaxe11_crafted, pickaxe12_crafted,
            pickaxe13_crafted, pickaxe14_crafted;

    public bool pickaxe1_equipped, pickaxe2_equipped, pickaxe3_equipped, pickaxe4_equipped,
                pickaxe5_equipped, pickaxe6_equipped, pickaxe7_equipped, pickaxe8_equipped,
                pickaxe9_equipped, pickaxe10_equipped, pickaxe11_equipped, pickaxe12_equipped,
                pickaxe13_equipped, pickaxe14_equipped;

    public bool isTheAnvilUnlocked;

    public int pickaxe1_skinsChosen;
    public int pickaxe2_skinsChosen;
    public int pickaxe3_skinsChosen;
    public int pickaxe4_skinsChosen;
    public int pickaxe5_skinsChosen;
    public int pickaxe6_skinsChosen;
    public int pickaxe7_skinsChosen;
    public int pickaxe8_skinsChosen;
    public int pickaxe9_skinsChosen;
    public int pickaxe10_skinsChosen;
    public int pickaxe11_skinsChosen;
    public int pickaxe12_skinsChosen;
    public int pickaxe13_skinsChosen;

    public int totalPickaxesCrafted;

    public void PickaxeSaves()
    {
        totalPickaxesCrafted = 0;

        isTheAnvilUnlocked = false;

        pickaxe1_crafted = true;
        pickaxe2_crafted = false;
        pickaxe3_crafted = false;
        pickaxe4_crafted = false;
        pickaxe5_crafted = false;
        pickaxe6_crafted = false;
        pickaxe7_crafted = false;
        pickaxe8_crafted = false;
        pickaxe9_crafted = false;
        pickaxe10_crafted = false;
        pickaxe11_crafted = false;
        pickaxe12_crafted = false;
        pickaxe13_crafted = false;
        pickaxe14_crafted = false;

        pickaxe1_equipped = true;
        pickaxe2_equipped = false;
        pickaxe3_equipped = false;
        pickaxe4_equipped = false;
        pickaxe5_equipped = false;
        pickaxe6_equipped = false;
        pickaxe7_equipped = false;
        pickaxe8_equipped = false;
        pickaxe9_equipped = false;
        pickaxe10_equipped = false;
        pickaxe11_equipped = false;
        pickaxe12_equipped = false;
        pickaxe13_equipped = false;
        pickaxe14_equipped = false;

        pickaxe1_skinsChosen = 0;
        pickaxe2_skinsChosen = 0;
        pickaxe3_skinsChosen = 0;
        pickaxe4_skinsChosen = 0;
        pickaxe5_skinsChosen = 0;
        pickaxe6_skinsChosen = 0;
        pickaxe7_skinsChosen = 0;
        pickaxe8_skinsChosen = 0;
        pickaxe9_skinsChosen = 0;
        pickaxe10_skinsChosen = 0;
        pickaxe11_skinsChosen = 0;
        pickaxe12_skinsChosen = 0;
        pickaxe13_skinsChosen = 0;
    }
    #endregion

    #region The Mine Saves
    public bool isTheMineUnlocked;
    public double theMinePrice;
    public float mineTimeDecrase;
    public double mineTimePrice, mineMaterialsPrice;
    public float miningTime;
    public int barsMined;
    public int bersMinedIncrease;

    public void TheMineSaves()
    {
        isTheMineUnlocked = false;
        theMinePrice = 500;

        miningTime = 15f;
        mineTimeDecrase = miningTime / 19;
        mineTimePrice = 300;

        mineMaterialsPrice = 750;
        barsMined = 2;
        bersMinedIncrease = 2;
    }
    #endregion

    #region Skill tree saves
    public bool moreXP_1_purchased, moreXP_2_purchased, moreXP_3_purchased, moreXP_4_purchased,
              moreXP_5_purchased, moreXP_6_purchased, moreXP_7_purchased, moreXP_8_purchased;

    public bool talentPointsPerXlevel_1_purchased, talentPointsPerXlevel_2_purchased, talentPointsPerXlevel_3_purchased;

    public bool spawnMoreRocks_1_purchased, spawnMoreRocks_2_purchased, spawnMoreRocks_3_purchased,
                spawnMoreRocks_4_purchased, spawnMoreRocks_5_purchased, spawnMoreRocks_6_purchased,
                spawnMoreRocks_7_purchased, spawnMoreRocks_8_purchased, spawnMoreRocks_9_purchased;

    // More materials from rock
    public bool moreMeterialsFromRock_1_purchased, moreMeterialsFromRock_2_purchased,
                moreMeterialsFromRock_3_purchased, moreMeterialsFromRock_4_purchased,
                moreMeterialsFromRock_5_purchased;

    // Materials worth more
    public bool marterialsWorthMore_1_purchased, marterialsWorthMore_2_purchased,
                marterialsWorthMore_3_purchased, marterialsWorthMore_4_purchased,
                marterialsWorthMore_5_purchased, marterialsWorthMore_6_purchased,
                marterialsWorthMore_7_purchased, marterialsWorthMore_8_purchased;

    // Gold upgrades
    public bool goldChunk_1_purchased, goldChunk_2_purchased, goldChunk_3_purchased, goldChunk_4_purchased, goldChunk_5_purchased;
    public bool fullGold_1_purchased, fullGold_2_purchased, fullGold_3_purchased;

    // Copper
    public bool spawnCopper_purchased, copperChunk_1_purchased, copperChunk_2_purchased, copperChunk_3_purchased;
    public bool fullCopper_1_purchased, fullCopper_2_purchased, fullCopper_3_purchased;

    // Iron
    public bool spawnIron_purchased, ironChunk_1_purchased, ironChunk_2_purchased;
    public bool fullIron_1_purchased, fullIron_2_purchased;

    // Cobalt
    public bool cobaltSpawn_purchased, cobaltChunk_1_purchased, fullCobalt_1_purchased;

    // Uranium
    public bool uraniumSpawn_purchased, uraniumChunk_1_purchased, fullUranium_1_purchased;

    // Ismium
    public bool ismiumSpawn_purchased, ismiumChunk_1_purchased, fullIsmium_1_purchased;

    // Iridium
    public bool iridiumSpawn_purchased, iridiumChunk_1_purchased, fullIridium_1_purchased;

    // Painite
    public bool painiteSpawn_purchased, painiteChunk_1_purchased, fullPainite_1_purchased;

    public bool improvedPickaxe_1_purchased, improvedPickaxe_2_purchased, improvedPickaxe_3_purchased,
              improvedPickaxe_4_purchased, improvedPickaxe_5_purchased, improvedPickaxe_6_purchased;

    // Mining Area Upgrades
    public bool biggerMiningErea_1_purchased, biggerMiningErea_2_purchased,
                biggerMiningErea_3_purchased, biggerMiningErea_4_purchased,
                shootCircleChance_purchased, increaseAndDecreaseMinignErea_purchased;

    public bool spawnRockEveryXrock_1_purchased, spawnRockEveryXrock_2_purchased, spawnRockEveryXrock_3_purchased;
    public bool spawnXRockEveryXSecond_1_purchased, spawnXRockEveryXSecond_2_purchased, spawnXRockEveryXSecond_3_purchased;
    public bool chanceToSpawnRockWhenMined_1_purchased, chanceToSpawnRockWhenMined_2_purchased,
                chanceToSpawnRockWhenMined_3_purchased, chanceToSpawnRockWhenMined_4_purchased,
                chanceToSpawnRockWhenMined_5_purchased, chanceToSpawnRockWhenMined_6_purchased;

    public bool chanceToMineRandomRock_1_purchased, chanceToMineRandomRock_2_purchased,
              chanceToMineRandomRock_3_purchased, chanceToMineRandomRock_4_purchased;

    // Spawn Pickaxe Every Second Upgrades
    public bool spawnPickaxeEverySecond_1_purchased, spawnPickaxeEverySecond_2_purchased, spawnPickaxeEverySecond_3_purchased;

    public bool doubleXpGoldChance_1_purchased, doubleXpGoldChance_2_purchased,
              doubleXpGoldChance_3_purchased, doubleXpGoldChance_4_purchased, doubleXpGoldChance_5_purchased;

    // Lightning Beam Upgrades
    public bool lightningBeamChanceS_1_purchased, lightningBeamChanceS_2_purchased;
    public bool lightningBeamChancePH_1_purchased, lightningBeamChancePH_2_purchased;
    public bool lightningBeamSpawnAnotherOneChance_purchased;
    public bool lightningBeamDamage_purchased, lightningBeamSize_purchased;
    public bool lightningSplashes_purchased, lightningBeamSpawnRock_purchased;
    public bool lightningBeamExplosion_purchased, lightningBeamAddTime_purchased;

    // Dynamite Upgrades
    public bool dynamiteChance_1_purchased, dynamiteChance_2_purchased;
    public bool dynamiteSpawn2SmallChance_purchased, dynamiteExplosionSize_purchased;
    public bool dynamiteDamage_purchased, dynamiteExplosionSpawnRock_purchased;
    public bool dynamiteExplosionAddTimeChance_purchased, dynamiteExplosionSpawnLightning_purchased;

    // Plazma Ball Upgrades
    public bool plazmaBallSpawn_1_purchased, plazmaBallSpawn_2_purchased;
    public bool plazmaBallTime_purchased, plazmaBallSize_purchased;
    public bool plazmaBallExplosionChance_purchased, plazmaBallSpawnSmallChance_purchased;
    public bool plazmaBallDamage_purchased, plazmaBallSpawnPickaxeChance_purchased;

    public bool allProjectileDoubleDamageChance_purchased, allProjectileTriggerChance_purchased;
    public bool pickaxeDoubleDamageChance_1_purchased, pickaxeDoubleDamageChance_2_purchased;
    public bool intaMineChance_1_purchased, intaMineChance_2_purchased;
    public bool increaseSpawnChanceAllRocks_purchased;
    public bool craft2Material_purchased;
    public bool finalUpgrade_purchased;

    public int moreXP_1_purchaseCount, moreXP_2_purchaseCount, moreXP_3_purchaseCount, moreXP_4_purchaseCount, moreXP_5_purchaseCount, moreXP_6_purchaseCount, moreXP_7_purchaseCount, moreXP_8_purchaseCount;
    public int talentPointsPerXlevel_1_purchaseCount, talentPointsPerXlevel_2_purchaseCount, talentPointsPerXlevel_3_purchaseCount;

    public int spawnMoreRocks_1_purchaseCount, spawnMoreRocks_2_purchaseCount, spawnMoreRocks_3_purchaseCount, spawnMoreRocks_4_purchaseCount, spawnMoreRocks_5_purchaseCount, spawnMoreRocks_6_purchaseCount, spawnMoreRocks_7_purchaseCount, spawnMoreRocks_8_purchaseCount, spawnMoreRocks_9_purchaseCount;
    public int moreMeterialsFromRock_1_purchaseCount, moreMeterialsFromRock_2_purchaseCount, moreMeterialsFromRock_3_purchaseCount, moreMeterialsFromRock_4_purchaseCount, moreMeterialsFromRock_5_purchaseCount;
    public int marterialsWorthMore_1_purchaseCount, marterialsWorthMore_2_purchaseCount, marterialsWorthMore_3_purchaseCount, marterialsWorthMore_4_purchaseCount, marterialsWorthMore_5_purchaseCount, marterialsWorthMore_6_purchaseCount, marterialsWorthMore_7_purchaseCount, marterialsWorthMore_8_purchaseCount;
    public int goldChunk_1_purchaseCount, goldChunk_2_purchaseCount, goldChunk_3_purchaseCount, goldChunk_4_purchaseCount, goldChunk_5_purchaseCount, fullGold_1_purchaseCount, fullGold_2_purchaseCount, fullGold_3_purchaseCount;
    public int spawnCopper_purchaseCount, copperChunk_1_purchaseCount, copperChunk_2_purchaseCount, copperChunk_3_purchaseCount, fullCopper_1_purchaseCount, fullCopper_2_purchaseCount, fullCopper_3_purchaseCount;
    public int spawnIron_purchaseCount, ironChunk_1_purchaseCount, ironChunk_2_purchaseCount, fullIron_1_purchaseCount, fullIron_2_purchaseCount;
    public int cobaltSpawn_purchaseCount, cobaltChunk_1_purchaseCount, fullCobalt_1_purchaseCount;
    public int uraniumSpawn_purchaseCount, uraniumChunk_1_purchaseCount, fullUranium_1_purchaseCount;
    public int ismiumSpawn_purchaseCount, ismiumChunk_1_purchaseCount, fullIsmium_1_purchaseCount;
    public int iridiumSpawn_purchaseCount, iridiumChunk_1_purchaseCount, fullIridium_1_purchaseCount;
    public int painiteSpawn_purchaseCount, painiteChunk_1_purchaseCount, fullPainite_1_purchaseCount;

    public int improvedPickaxe_1_purchaseCount, improvedPickaxe_2_purchaseCount, improvedPickaxe_3_purchaseCount, improvedPickaxe_4_purchaseCount, improvedPickaxe_5_purchaseCount, improvedPickaxe_6_purchaseCount;
    public int biggerMiningErea_1_purchaseCount, biggerMiningErea_2_purchaseCount, biggerMiningErea_3_purchaseCount, biggerMiningErea_4_purchaseCount, shootCircleChance_purchaseCount, increaseAndDecreaseMinignErea_purchaseCount;

    public int spawnRockEveryXrock_1_purchaseCount, spawnRockEveryXrock_2_purchaseCount, spawnRockEveryXrock_3_purchaseCount;
    public int spawnXRockEveryXSecond_1_purchaseCount, spawnXRockEveryXSecond_2_purchaseCount, spawnXRockEveryXSecond_3_purchaseCount;
    public int chanceToSpawnRockWhenMined_1_purchaseCount, chanceToSpawnRockWhenMined_2_purchaseCount, chanceToSpawnRockWhenMined_3_purchaseCount, chanceToSpawnRockWhenMined_4_purchaseCount, chanceToSpawnRockWhenMined_5_purchaseCount, chanceToSpawnRockWhenMined_6_purchaseCount;

    public int chanceToMineRandomRock_1_purchaseCount, chanceToMineRandomRock_2_purchaseCount, chanceToMineRandomRock_3_purchaseCount, chanceToMineRandomRock_4_purchaseCount;
    public int spawnPickaxeEverySecond_1_purchaseCount, spawnPickaxeEverySecond_2_purchaseCount, spawnPickaxeEverySecond_3_purchaseCount;

    public int moreTime_1_purchaseCount, moreTime_2_purchaseCount, moreTime_3_purchaseCount, moreTime_4_purchaseCount, chanceToAdd1SecondEverySecond_purchaseCount, chanceAdd1SecondEveryRockMined_purchaseCount;

    public int doubleXpGoldChance_1_purchaseCount, doubleXpGoldChance_2_purchaseCount, doubleXpGoldChance_3_purchaseCount, doubleXpGoldChance_4_purchaseCount, doubleXpGoldChance_5_purchaseCount;

    public int lightningBeamChanceS_1_purchaseCount, lightningBeamChanceS_2_purchaseCount, lightningBeamChancePH_1_purchaseCount, lightningBeamChancePH_2_purchaseCount, lightningBeamSpawnAnotherOneChance_purchaseCount, lightningBeamDamage_purchaseCount, lightningBeamSize_purchaseCount, lightningSplashes_purchaseCount, lightningBeamSpawnRock_purchaseCount, lightningBeamExplosion_purchaseCount, lightningBeamAddTime_purchaseCount;
    public int dynamiteChance_1_purchaseCount, dynamiteChance_2_purchaseCount, dynamiteSpawn2SmallChance_purchaseCount, dynamiteExplosionSize_purchaseCount, dynamiteDamage_purchaseCount, dynamiteExplosionSpawnRock_purchaseCount, dynamiteExplosionAddTimeChance_purchaseCount, dynamiteExplosionSpawnLightning_purchaseCount;
    public int plazmaBallSpawn_1_purchaseCount, plazmaBallSpawn_2_purchaseCount, plazmaBallTime_purchaseCount, plazmaBallSize_purchaseCount, plazmaBallExplosionChance_purchaseCount, plazmaBallSpawnSmallChance_purchaseCount, plazmaBallDamage_purchaseCount, plazmaBallSpawnPickaxeChance_purchaseCount;

    public int allProjectileDoubleDamageChance_purchaseCount, allProjectileTriggerChance_purchaseCount;
    public int pickaxeDoubleDamageChance_1_purchaseCount, pickaxeDoubleDamageChance_2_purchaseCount;
    public int intaMineChance_1_purchaseCount, intaMineChance_2_purchaseCount;
    public int increaseSpawnChanceAllRocks_purchaseCount;
    public int craft2Material_purchaseCount;
    public int finalUpgrade_purchaseCount;

    public int totalSkillTreeUpgradesPurchased;
    public int totalUpgradesFullyPurchased;

    public int mineSessionTime;

    public int totalRocksToSpawn;
    public int extraTalentPointPerLevel;

    // === Rock chances ===
    public float goldRockChance;
    public float fullGoldRockChance;

    public float copperRockChance;
    public float fullCopperRockChance;

    public float ironRockChance;
    public float fullIronRockChance;

    public float cobaltRockChance;
    public float fullCobaltRockChance;

    public float uraniumRockChance;
    public float fullUraniumRockChance;

    public float ismiumRockChance;
    public float fullIsmiumRockChance;

    public float iridiumRockChance;
    public float fullIridiumRockChance;

    public float painiteRockChance;
    public float fullPainiteRockChance;

    // === Pickaxe ===
    public float improvedPickaxeStrength;
    public float reducePickaxeMineTime;

    // === Mining Area ===
    public float miningAreaSize;

    // === Spawn rocks ===
    public float spawnRockEveryXRock;
    public float spawnXRockEveryXSecond;
    public float chanceToSpawnRockWhenMined;

    // === Materials from rocks ===
    public int materialsFromChunkRocks;
    public int materialsFromFullRocks;

    // === Materials worth ===
    public float materialsTotalWorth;

    // === Pickaxe spawn ===
    public float chanceToMineRandomRock;
    public float spawnPickaxeEverySecond;

    // === Double XP & Gold ===
    public float doubleXpAndGoldChance;

    // === Lightning ===
    public float lightningTriggerChanceS;
    public float lightningTriggerChancePH;
    public float lightningDamage;
    public float lightningSize;

    // === Dynamite ===
    public float dynamiteStickChance;
    public float explosionSize;
    public float explosionDamagage;

    // === Plazma balls ===
    public float plazmaBallChance;
    public float plazmaBallTimer;
    public float plazmaBallTotalSize;
    public float plazmaBallTotalDamage;

    // === Misc ===
    public float doubleDamageChance;
    public float instaMineChance;

    public int totalMaterialRocksSpawning;

    //More time
    public bool moreTime_1_purchased, moreTime_2_purchased, moreTime_3_purchased, moreTime_4_purchased;
    public bool chanceToAdd1SecondEverySecond_purchased, chanceAdd1SecondEveryRockMined_purchased;

    public double endlessGold_price, endlessCopper_price, endlessIron_price, endlessCobalt_price, endlessUranium_price, endlessIsmium_price, endlessIridium_price, endlessPainite_price;

    public int endlessGold_purchaseCount, endlessCopper_purchaseCount, endlessIron_purchaseCount, endlessCobalt_purchaseCount, endlessUranium_purchaseCount, endlessIsmium_purchaseCount, endlessIridium_purchaseCount, endlessPainite_purchaseCount;

    public bool hasPressedEndlessOK;

    public void SkillTreeSaves()
    {
        hasPressedEndlessOK = false;

        endlessGold_price = 6500000;
        endlessCopper_price = 3500000;
        endlessIron_price = 2500000;
        endlessCobalt_price = 1700000;
        endlessUranium_price = 1200000;
        endlessIsmium_price = 700000;
        endlessIridium_price = 500000;
        endlessPainite_price = 300000;

        endlessGold_purchaseCount = 0;
        endlessCopper_purchaseCount = 0;
        endlessIron_purchaseCount = 0;
        endlessCobalt_purchaseCount = 0;
        endlessUranium_purchaseCount = 0;
        endlessIsmium_purchaseCount = 0;
        endlessIridium_purchaseCount = 0;
        endlessPainite_purchaseCount = 0;

        #region Purchased
        moreTime_1_purchased = false;
        moreTime_2_purchased = false;
        moreTime_3_purchased = false;
        moreTime_4_purchased = false;
        chanceToAdd1SecondEverySecond_purchased = false;
        chanceAdd1SecondEveryRockMined_purchased = false;

        moreXP_1_purchased = false;
        moreXP_2_purchased = false;
        moreXP_3_purchased = false;
        moreXP_4_purchased = false;
        moreXP_5_purchased = false;
        moreXP_6_purchased = false;
        moreXP_7_purchased = false;
        moreXP_8_purchased = false;

        talentPointsPerXlevel_1_purchased = false;
        talentPointsPerXlevel_2_purchased = false;
        talentPointsPerXlevel_3_purchased = false;

        spawnMoreRocks_1_purchased = false;
        spawnMoreRocks_2_purchased = false;
        spawnMoreRocks_3_purchased = false;
        spawnMoreRocks_4_purchased = false;
        spawnMoreRocks_5_purchased = false;
        spawnMoreRocks_6_purchased = false;
        spawnMoreRocks_7_purchased = false;
        spawnMoreRocks_8_purchased = false;
        spawnMoreRocks_9_purchased = false;

        moreMeterialsFromRock_1_purchased = false;
        moreMeterialsFromRock_2_purchased = false;
        moreMeterialsFromRock_3_purchased = false;
        moreMeterialsFromRock_4_purchased = false;
        moreMeterialsFromRock_5_purchased = false;

        marterialsWorthMore_1_purchased = false;
        marterialsWorthMore_2_purchased = false;
        marterialsWorthMore_3_purchased = false;
        marterialsWorthMore_4_purchased = false;
        marterialsWorthMore_5_purchased = false;
        marterialsWorthMore_6_purchased = false;
        marterialsWorthMore_7_purchased = false;
        marterialsWorthMore_8_purchased = false;

        goldChunk_1_purchased = false;
        goldChunk_2_purchased = false;
        goldChunk_3_purchased = false;
        goldChunk_4_purchased = false;
        goldChunk_5_purchased = false;
        fullGold_1_purchased = false;
        fullGold_2_purchased = false;
        fullGold_3_purchased = false;

        spawnCopper_purchased = false;
        copperChunk_1_purchased = false;
        copperChunk_2_purchased = false;
        copperChunk_3_purchased = false;
        fullCopper_1_purchased = false;
        fullCopper_2_purchased = false;
        fullCopper_3_purchased = false;

        spawnIron_purchased = false;
        ironChunk_1_purchased = false;
        ironChunk_2_purchased = false;
        fullIron_1_purchased = false;
        fullIron_2_purchased = false;

        cobaltSpawn_purchased = false;
        cobaltChunk_1_purchased = false;
        fullCobalt_1_purchased = false;

        uraniumSpawn_purchased = false;
        uraniumChunk_1_purchased = false;
        fullUranium_1_purchased = false;

        ismiumSpawn_purchased = false;
        ismiumChunk_1_purchased = false;
        fullIsmium_1_purchased = false;

        iridiumSpawn_purchased = false;
        iridiumChunk_1_purchased = false;
        fullIridium_1_purchased = false;

        painiteSpawn_purchased = false;
        painiteChunk_1_purchased = false;
        fullPainite_1_purchased = false;

        improvedPickaxe_1_purchased = false;
        improvedPickaxe_2_purchased = false;
        improvedPickaxe_3_purchased = false;
        improvedPickaxe_4_purchased = false;
        improvedPickaxe_5_purchased = false;
        improvedPickaxe_6_purchased = false;

        biggerMiningErea_1_purchased = false;
        biggerMiningErea_2_purchased = false;
        biggerMiningErea_3_purchased = false;
        biggerMiningErea_4_purchased = false;
        shootCircleChance_purchased = false;
        increaseAndDecreaseMinignErea_purchased = false;

        spawnRockEveryXrock_1_purchased = false;
        spawnRockEveryXrock_2_purchased = false;
        spawnRockEveryXrock_3_purchased = false;

        spawnXRockEveryXSecond_1_purchased = false;
        spawnXRockEveryXSecond_2_purchased = false;
        spawnXRockEveryXSecond_3_purchased = false;

        chanceToSpawnRockWhenMined_1_purchased = false;
        chanceToSpawnRockWhenMined_2_purchased = false;
        chanceToSpawnRockWhenMined_3_purchased = false;
        chanceToSpawnRockWhenMined_4_purchased = false;
        chanceToSpawnRockWhenMined_5_purchased = false;
        chanceToSpawnRockWhenMined_6_purchased = false;

        chanceToMineRandomRock_1_purchased = false;
        chanceToMineRandomRock_2_purchased = false;
        chanceToMineRandomRock_3_purchased = false;
        chanceToMineRandomRock_4_purchased = false;

        spawnPickaxeEverySecond_1_purchased = false;
        spawnPickaxeEverySecond_2_purchased = false;
        spawnPickaxeEverySecond_3_purchased = false;

        doubleXpGoldChance_1_purchased = false;
        doubleXpGoldChance_2_purchased = false;
        doubleXpGoldChance_3_purchased = false;
        doubleXpGoldChance_4_purchased = false;
        doubleXpGoldChance_5_purchased = false;

        lightningBeamChanceS_1_purchased = false;
        lightningBeamChanceS_2_purchased = false;
        lightningBeamChancePH_1_purchased = false;
        lightningBeamChancePH_2_purchased = false;
        lightningBeamSpawnAnotherOneChance_purchased = false;
        lightningBeamDamage_purchased = false;
        lightningBeamSize_purchased = false;
        lightningSplashes_purchased = false;
        lightningBeamSpawnRock_purchased = false;
        lightningBeamExplosion_purchased = false;
        lightningBeamAddTime_purchased = false;

        dynamiteChance_1_purchased = false;
        dynamiteChance_2_purchased = false;
        dynamiteSpawn2SmallChance_purchased = false;
        dynamiteExplosionSize_purchased = false;
        dynamiteDamage_purchased = false;
        dynamiteExplosionSpawnRock_purchased = false;
        dynamiteExplosionAddTimeChance_purchased = false;
        dynamiteExplosionSpawnLightning_purchased = false;

        plazmaBallSpawn_1_purchased = false;
        plazmaBallSpawn_2_purchased = false;
        plazmaBallTime_purchased = false;
        plazmaBallSize_purchased = false;
        plazmaBallExplosionChance_purchased = false;
        plazmaBallSpawnSmallChance_purchased = false;
        plazmaBallDamage_purchased = false;
        plazmaBallSpawnPickaxeChance_purchased = false;

        allProjectileDoubleDamageChance_purchased = false;
        allProjectileTriggerChance_purchased = false;
        pickaxeDoubleDamageChance_1_purchased = false;
        pickaxeDoubleDamageChance_2_purchased = false;
        intaMineChance_1_purchased = false;
        intaMineChance_2_purchased = false;
        increaseSpawnChanceAllRocks_purchased = false;
        craft2Material_purchased = false;
        finalUpgrade_purchased = false;
        #endregion

        #region purchase count
        moreXP_1_purchaseCount = 0; moreXP_2_purchaseCount = 0; moreXP_3_purchaseCount = 0; moreXP_4_purchaseCount = 0; moreXP_5_purchaseCount = 0; moreXP_6_purchaseCount = 0; moreXP_7_purchaseCount = 0; moreXP_8_purchaseCount = 0;
        talentPointsPerXlevel_1_purchaseCount = 0; talentPointsPerXlevel_2_purchaseCount = 0; talentPointsPerXlevel_3_purchaseCount = 0;

        // Rocks and Materials
        spawnMoreRocks_1_purchaseCount = 0; spawnMoreRocks_2_purchaseCount = 0; spawnMoreRocks_3_purchaseCount = 0; spawnMoreRocks_4_purchaseCount = 0; spawnMoreRocks_5_purchaseCount = 0; spawnMoreRocks_6_purchaseCount = 0; spawnMoreRocks_7_purchaseCount = 0; spawnMoreRocks_8_purchaseCount = 0; spawnMoreRocks_9_purchaseCount = 0;
        moreMeterialsFromRock_1_purchaseCount = 0; moreMeterialsFromRock_2_purchaseCount = 0; moreMeterialsFromRock_3_purchaseCount = 0; moreMeterialsFromRock_4_purchaseCount = 0; moreMeterialsFromRock_5_purchaseCount = 0;
        marterialsWorthMore_1_purchaseCount = 0; marterialsWorthMore_2_purchaseCount = 0; marterialsWorthMore_3_purchaseCount = 0; marterialsWorthMore_4_purchaseCount = 0; marterialsWorthMore_5_purchaseCount = 0; marterialsWorthMore_6_purchaseCount = 0; marterialsWorthMore_7_purchaseCount = 0; marterialsWorthMore_8_purchaseCount = 0;
        goldChunk_1_purchaseCount = 0; goldChunk_2_purchaseCount = 0; goldChunk_3_purchaseCount = 0; goldChunk_4_purchaseCount = 0; goldChunk_5_purchaseCount = 0; fullGold_1_purchaseCount = 0; fullGold_2_purchaseCount = 0; fullGold_3_purchaseCount = 0;
        spawnCopper_purchaseCount = 0; copperChunk_1_purchaseCount = 0; copperChunk_2_purchaseCount = 0; copperChunk_3_purchaseCount = 0; fullCopper_1_purchaseCount = 0; fullCopper_2_purchaseCount = 0; fullCopper_3_purchaseCount = 0;
        spawnIron_purchaseCount = 0; ironChunk_1_purchaseCount = 0; ironChunk_2_purchaseCount = 0; fullIron_1_purchaseCount = 0; fullIron_2_purchaseCount = 0;
        cobaltSpawn_purchaseCount = 0; cobaltChunk_1_purchaseCount = 0; fullCobalt_1_purchaseCount = 0;
        uraniumSpawn_purchaseCount = 0; uraniumChunk_1_purchaseCount = 0; fullUranium_1_purchaseCount = 0;
        ismiumSpawn_purchaseCount = 0; ismiumChunk_1_purchaseCount = 0; fullIsmium_1_purchaseCount = 0;
        iridiumSpawn_purchaseCount = 0; iridiumChunk_1_purchaseCount = 0; fullIridium_1_purchaseCount = 0;
        painiteSpawn_purchaseCount = 0; painiteChunk_1_purchaseCount = 0; fullPainite_1_purchaseCount = 0;

        // Better Pickaxe and Mining Erea
        improvedPickaxe_1_purchaseCount = 0; improvedPickaxe_2_purchaseCount = 0; improvedPickaxe_3_purchaseCount = 0; improvedPickaxe_4_purchaseCount = 0; improvedPickaxe_5_purchaseCount = 0; improvedPickaxe_6_purchaseCount = 0;
        biggerMiningErea_1_purchaseCount = 0; biggerMiningErea_2_purchaseCount = 0; biggerMiningErea_3_purchaseCount = 0; biggerMiningErea_4_purchaseCount = 0; shootCircleChance_purchaseCount = 0; increaseAndDecreaseMinignErea_purchaseCount = 0;

        // Chance to Spawn Rock and Spawn Rock X Times
        spawnRockEveryXrock_1_purchaseCount = 0; spawnRockEveryXrock_2_purchaseCount = 0; spawnRockEveryXrock_3_purchaseCount = 0;
        spawnXRockEveryXSecond_1_purchaseCount = 0; spawnXRockEveryXSecond_2_purchaseCount = 0; spawnXRockEveryXSecond_3_purchaseCount = 0;
        chanceToSpawnRockWhenMined_1_purchaseCount = 0; chanceToSpawnRockWhenMined_2_purchaseCount = 0; chanceToSpawnRockWhenMined_3_purchaseCount = 0; chanceToSpawnRockWhenMined_4_purchaseCount = 0; chanceToSpawnRockWhenMined_5_purchaseCount = 0; chanceToSpawnRockWhenMined_6_purchaseCount = 0;

        // Spawn Pickaxes
        chanceToMineRandomRock_1_purchaseCount = 0; chanceToMineRandomRock_2_purchaseCount = 0; chanceToMineRandomRock_3_purchaseCount = 0; chanceToMineRandomRock_4_purchaseCount = 0;
        spawnPickaxeEverySecond_1_purchaseCount = 0; spawnPickaxeEverySecond_2_purchaseCount = 0; spawnPickaxeEverySecond_3_purchaseCount = 0;

        // More Time
        moreTime_1_purchaseCount = 0; moreTime_2_purchaseCount = 0; moreTime_3_purchaseCount = 0; moreTime_4_purchaseCount = 0; chanceToAdd1SecondEverySecond_purchaseCount = 0; chanceAdd1SecondEveryRockMined_purchaseCount = 0;

        // Chance for Double XP and Gold
        doubleXpGoldChance_1_purchaseCount = 0; doubleXpGoldChance_2_purchaseCount = 0; doubleXpGoldChance_3_purchaseCount = 0; doubleXpGoldChance_4_purchaseCount = 0; doubleXpGoldChance_5_purchaseCount = 0;

        // Lightning, Dynamite, and PlazmaBalls
        lightningBeamChanceS_1_purchaseCount = 0; lightningBeamChanceS_2_purchaseCount = 0; lightningBeamChancePH_1_purchaseCount = 0; lightningBeamChancePH_2_purchaseCount = 0; lightningBeamSpawnAnotherOneChance_purchaseCount = 0; lightningBeamDamage_purchaseCount = 0; lightningBeamSize_purchaseCount = 0; lightningSplashes_purchaseCount = 0; lightningBeamSpawnRock_purchaseCount = 0; lightningBeamExplosion_purchaseCount = 0; lightningBeamAddTime_purchaseCount = 0;
        dynamiteChance_1_purchaseCount = 0; dynamiteChance_2_purchaseCount = 0; dynamiteSpawn2SmallChance_purchaseCount = 0; dynamiteExplosionSize_purchaseCount = 0; dynamiteDamage_purchaseCount = 0; dynamiteExplosionSpawnRock_purchaseCount = 0; dynamiteExplosionAddTimeChance_purchaseCount = 0; dynamiteExplosionSpawnLightning_purchaseCount = 0;
        plazmaBallSpawn_1_purchaseCount = 0; plazmaBallSpawn_2_purchaseCount = 0; plazmaBallTime_purchaseCount = 0; plazmaBallSize_purchaseCount = 0; plazmaBallExplosionChance_purchaseCount = 0; plazmaBallSpawnSmallChance_purchaseCount = 0; plazmaBallDamage_purchaseCount = 0; plazmaBallSpawnPickaxeChance_purchaseCount = 0;

        // Misc
        allProjectileDoubleDamageChance_purchaseCount = 0; allProjectileTriggerChance_purchaseCount = 0;
        pickaxeDoubleDamageChance_1_purchaseCount = 0; pickaxeDoubleDamageChance_2_purchaseCount = 0;
        intaMineChance_1_purchaseCount = 0; intaMineChance_2_purchaseCount = 0;
        increaseSpawnChanceAllRocks_purchaseCount = 0;
        craft2Material_purchaseCount = 0;
        finalUpgrade_purchaseCount = 0;
        #endregion

        totalMaterialRocksSpawning = 1;

        totalSkillTreeUpgradesPurchased = 0;
        totalUpgradesFullyPurchased = 0;
        mineSessionTime = 15;
        totalRocksToSpawn = 25;
        extraTalentPointPerLevel = 7;

        // === Rock chances ===
        goldRockChance = 11f;
        fullGoldRockChance = 4.2f;
        copperRockChance = 3.1f;
        fullCopperRockChance = 2.2f;
        ironRockChance = 2.4f;
        fullIronRockChance = 1.7f;
        cobaltRockChance = 1.5f;
        fullCobaltRockChance = 1.3f;
        uraniumRockChance = 1.1f;
        fullUraniumRockChance = 1f;
        ismiumRockChance = 0.9f;
        fullIsmiumRockChance = 0.8f;
        iridiumRockChance = 0.7f;
        fullIridiumRockChance = 0.6f;
        painiteRockChance = 0.5f;
        fullPainiteRockChance = 0.4f;

        // === Pickaxe ===
        improvedPickaxeStrength = 1f;
        reducePickaxeMineTime = 0f;

        // === Mining Area ===
        miningAreaSize = 1f;

        // === Spawn rocks ===
        spawnRockEveryXRock = 6f;
        spawnXRockEveryXSecond = 2;
        chanceToSpawnRockWhenMined = 0f;

        // === Materials from rocks ===
        materialsFromChunkRocks = 3;
        materialsFromFullRocks = 7;

        // === Materials worth ===
        materialsTotalWorth = 1f;

        // === Pickaxe spawn ===
        chanceToMineRandomRock = 0f;
        spawnPickaxeEverySecond = 1.2f;

        // === Double XP & Gold ===
        doubleXpAndGoldChance = 0f;

        // === Lightning ===
        lightningTriggerChanceS = 0f;
        lightningTriggerChancePH = 0f;
        lightningDamage = 0f;
        lightningSize = 1f;

        // === Dynamite ===
        dynamiteStickChance = 0f;
        explosionSize = 1f;
        explosionDamagage = 0f;

        // === Plazma balls ===
        plazmaBallChance = 0f;
        plazmaBallTimer = 5f;
        plazmaBallTotalSize = 1;
        plazmaBallTotalDamage = 1;

        // === Misc ===
        doubleDamageChance = 0f;
        instaMineChance = 0f;
    }
    #endregion
}
