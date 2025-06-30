using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour, IDataPersistence
{
    public TheAnvil theAnvilScript;
    public TheMine theMineScript;
    public GoldAndOreMechanics goldAndOreScript;
    public Tutorial tutorialScript;

    public GameObject copperBarFrame, ironBarFrame, cobaltBarFrame, uraniumiumBarFrame, ismiumBarFrame, iridiumBarFRame, painiteBarFrame;

    public GameObject[] lines;
    public GameObject finaLine;

    public static int rocksMinedBeforeSpawn;

    public AudioManager audioManager;

    public GameObject endingButton;

    //All upgrades. GameObject variable
    #region ALL GAMEOBJECT VARIBALES

    #region XP (11)
    public GameObject moreXP_1, moreXP_2, moreXP_3, moreXP_4, moreXP_5, moreXP_6, moreXP_7, moreXP_8, talentPointsPerXlevel_1, talentPointsPerXlevel_2, talentPointsPerXlevel_3;
    #endregion

    #region lightning, dynamite and plazmaBalls (27)
    public GameObject lightningBeamChanceS_1, lightningBeamChanceS_2, lightningBeamChancePH_1, lightningBeamChancePH_2, lightningBeamSpawnAnotherOneChance, lightningBeamDamage, lightningBeamSize, lightningSplashes, lightningBeamSpawnRock, lightningBeamExplosion, lightningBeamAddTime;

    public GameObject dynamiteChance_1, dynamiteChance_2, dynamiteSpawn2SmallChance, dynamiteExplosionSize, dynamiteDamage, dynamiteExplosionSpawnRock, dynamiteExplosionAddTimeChance, dynamiteExplosionSpawnLightning;

    public GameObject plazmaBallSpawn_1, plazmaBallSpawn_2, plazmaBallTime, plazmaBallSize, plazmaBallExplosionChance, plazmaBallSpawnSmallChance, plazmaBallDamage, plazmaBallSpawnPickaxeChance;
    #endregion

    #region Rocks and materials (57)
    public GameObject spawnMoreRocks_1, spawnMoreRocks_2, spawnMoreRocks_3, spawnMoreRocks_4, spawnMoreRocks_5, spawnMoreRocks_6, spawnMoreRocks_7, spawnMoreRocks_8, spawnMoreRocks_9;

    public GameObject moreMeterialsFromRock_1, moreMeterialsFromRock_2, moreMeterialsFromRock_3, moreMeterialsFromRock_4, moreMeterialsFromRock_5;

    public GameObject marterialsWorthMore_1, marterialsWorthMore_2, marterialsWorthMore_3, marterialsWorthMore_4, marterialsWorthMore_5, marterialsWorthMore_6, marterialsWorthMore_7, marterialsWorthMore_8;
    
    public GameObject goldChunk_1, goldChunk_2, goldChunk_3, goldChunk_4, goldChunk_5_, fullGold_1, fullGold_2, fullGold_3;
    public GameObject spawnCopper, copperChunk_1, copperChunk_2, copperChunk_3, fullCopper_1, fullCopper_2, fullCopper_3;
    public GameObject spawnIron, ironChunk_1, ironChunk_2, fullIron_1, fullIron_2;
    public GameObject cobaltSpawn, cobaltChunk_1, fullCobalt_1;
    public GameObject uraniumSpawn, uraniumChunk_1, fullUranium_1;
    public GameObject ismiumSpawn, ismiumChunk_1, fullIsmium_1;
    public GameObject iridiumSpawn, iridiumChunk_1, fullIridium_1;
    public GameObject painiteSpawn, painiteChunk_1, fullPainite_1;
    #endregion

    #region better pickaxe and mining erea (12)
    public GameObject improvedPickaxe_1, improvedPickaxe_2, improvedPickaxe_3, improvedPickaxe_4, improvedPickaxe_5, improvedPickaxe_6;
    public GameObject biggerMiningErea_1, biggerMiningErea_2, biggerMiningErea_3, biggerMiningErea_4, shootCircleChance, increaseAndDecreaseMinignErea;
    #endregion

    #region Chance to spawn rock and spawn rock X times (12)
    public GameObject spawnRockEveryXrock_1, spawnRockEveryXrock_2, spawnRockEveryXrock_3, spawnXRockEveryXSecond_1, spawnXRockEveryXSecond_2, spawnXRockEveryXSecond_3, chanceToSpawnRockWhenMined_1, chanceToSpawnRockWhenMined_2, chanceToSpawnRockWhenMined_3, chanceToSpawnRockWhenMined_4, chanceToSpawnRockWhenMined_5, chanceToSpawnRockWhenMined_6;
    #endregion

    #region Spawn pickaxes (7)
    public GameObject chanceToMineRandomRock_1, chanceToMineRandomRock_2, chanceToMineRandomRock_3, chanceToMineRandomRock_4, spawnPickaxeEverySecond_1, spawnPickaxeEverySecond_2, spawnPickaxeEverySecond_3;
    #endregion

    #region More time (6)
    public GameObject moreTime_1, moreTime_2, moreTime_3, moreTime_4, chanceToAdd1SecondEverySecond, chanceAdd1SecondEveryRockMined;
    #endregion

    #region chance for double xp and gold (5)
    public GameObject doubleXpGoldChance_1, doubleXpGoldChance_2, doubleXpGoldChance_3, doubleXpGoldChance_4, doubleXpGoldChance_5;
    #endregion

    #region Misc
    public GameObject allProjectileDoubleDamageChance, allProjectileTriggerChance;
    public GameObject pickaxeDoubleDamageChance_1, pickaxeDoubleDamageChance_2;
    public GameObject intaMineChance_1, intaMineChance_2;
    public GameObject increaseSpawnChanceAllRocks;
    public GameObject craft2Material;
    public GameObject finalUpgrade;
    #endregion

    #endregion

    //All locked frames. GameObject variable
    #region ALL LOCKED FRAMES

    #region XP
    public GameObject moreXP_1_LOCKED, moreXP_2_LOCKED, moreXP_3_LOCKED, moreXP_4_LOCKED, moreXP_5_LOCKED, moreXP_6_LOCKED, moreXP_7_LOCKED, moreXP_8_LOCKED;
    public GameObject talentPointsPerXlevel_1_LOCKED, talentPointsPerXlevel_2_LOCKED, talentPointsPerXlevel_3_LOCKED;
    #endregion

    #region Rocks and Materials
    public GameObject spawnMoreRocks_1_LOCKED, spawnMoreRocks_2_LOCKED, spawnMoreRocks_3_LOCKED, spawnMoreRocks_4_LOCKED, spawnMoreRocks_5_LOCKED, spawnMoreRocks_6_LOCKED, spawnMoreRocks_7_LOCKED, spawnMoreRocks_8_LOCKED, spawnMoreRocks_9_LOCKED;

    public GameObject moreMeterialsFromRock_1_LOCKED, moreMeterialsFromRock_2_LOCKED, moreMeterialsFromRock_3_LOCKED, moreMeterialsFromRock_4_LOCKED, moreMeterialsFromRock_5_LOCKED;

    public GameObject marterialsWorthMore_1_LOCKED, marterialsWorthMore_2_LOCKED, marterialsWorthMore_3_LOCKED, marterialsWorthMore_4_LOCKED, marterialsWorthMore_5_LOCKED, marterialsWorthMore_6_LOCKED, marterialsWorthMore_7_LOCKED, marterialsWorthMore_8_LOCKED;

    public GameObject goldChunk_1_LOCKED, goldChunk_2_LOCKED, goldChunk_3_LOCKED, goldChunk_4_LOCKED, goldChunk_5_LOCKED, fullGold_1_LOCKED, fullGold_2_LOCKED, fullGold_3_LOCKED;

    public GameObject spawnCopper_LOCKED, copperChunk_1_LOCKED, copperChunk_2_LOCKED, copperChunk_3_LOCKED, fullCopper_1_LOCKED, fullCopper_2_LOCKED, fullCopper_3_LOCKED;

    public GameObject spawnIron_LOCKED, ironChunk_1_LOCKED, ironChunk_2_LOCKED, fullIron_1_LOCKED, fullIron_2_LOCKED;

    public GameObject cobaltSpawn_LOCKED, cobaltChunk_1_LOCKED, fullCobalt_1_LOCKED;

    public GameObject uraniumSpawn_LOCKED, uraniumChunk_1_LOCKED, fullUranium_1_LOCKED;

    public GameObject ismiumSpawn_LOCKED, ismiumChunk_1_LOCKED, fullIsmium_1_LOCKED;

    public GameObject iridiumSpawn_LOCKED, iridiumChunk_1_LOCKED, fullIridium_1_LOCKED;

    public GameObject painiteSpawn_LOCKED, painiteChunk_1_LOCKED, fullPainite_1_LOCKED;
    #endregion

    #region Better Pickaxe and Mining Erea
    public GameObject improvedPickaxe_1_LOCKED, improvedPickaxe_2_LOCKED, improvedPickaxe_3_LOCKED, improvedPickaxe_4_LOCKED, improvedPickaxe_5_LOCKED, improvedPickaxe_6_LOCKED;
    public GameObject biggerMiningErea_1_LOCKED, biggerMiningErea_2_LOCKED, biggerMiningErea_3_LOCKED, biggerMiningErea_4_LOCKED, shootCircleChance_LOCKED, increaseAndDecreaseMinignErea_LOCKED;
    #endregion

    #region Chance to Spawn Rock and Spawn Rock X Times
    public GameObject spawnRockEveryXrock_1_LOCKED, spawnRockEveryXrock_2_LOCKED, spawnRockEveryXrock_3_LOCKED;
    public GameObject spawnXRockEveryXSecond_1_LOCKED, spawnXRockEveryXSecond_2_LOCKED, spawnXRockEveryXSecond_3_LOCKED;
    public GameObject chanceToSpawnRockWhenMined_1_LOCKED, chanceToSpawnRockWhenMined_2_LOCKED, chanceToSpawnRockWhenMined_3_LOCKED, chanceToSpawnRockWhenMined_4_LOCKED, chanceToSpawnRockWhenMined_5_LOCKED, chanceToSpawnRockWhenMined_6_LOCKED;
    #endregion

    #region Spawn Pickaxes
    public GameObject chanceToMineRandomRock_1_LOCKED, chanceToMineRandomRock_2_LOCKED, chanceToMineRandomRock_3_LOCKED, chanceToMineRandomRock_4_LOCKED;
    public GameObject spawnPickaxeEverySecond_1_LOCKED, spawnPickaxeEverySecond_2_LOCKED, spawnPickaxeEverySecond_3_LOCKED;
    #endregion

    #region More Time
    public GameObject moreTime_1_LOCKED, moreTime_2_LOCKED, moreTime_3_LOCKED, moreTime_4_LOCKED, chanceToAdd1SecondEverySecond_LOCKED, chanceAdd1SecondEveryRockMined_LOCKED;
    #endregion

    #region Chance for Double XP and Gold
    public GameObject doubleXpGoldChance_1_LOCKED, doubleXpGoldChance_2_LOCKED, doubleXpGoldChance_3_LOCKED, doubleXpGoldChance_4_LOCKED, doubleXpGoldChance_5_LOCKED;
    #endregion

    #region Lightning, Dynamite, and PlazmaBalls
    public GameObject lightningBeamChanceS_1_LOCKED, lightningBeamChanceS_2_LOCKED, lightningBeamChancePH_1_LOCKED, lightningBeamChancePH_2_LOCKED;
    public GameObject lightningBeamSpawnAnotherOneChance_LOCKED, lightningBeamDamage_LOCKED, lightningBeamSize_LOCKED, lightningSplashes_LOCKED, lightningBeamSpawnRock_LOCKED, lightningBeamExplosion_LOCKED, lightningBeamAddTime_LOCKED;

    public GameObject dynamiteChance_1_LOCKED, dynamiteChance_2_LOCKED, dynamiteSpawn2SmallChance_LOCKED, dynamiteExplosionSize_LOCKED, dynamiteDamage_LOCKED, dynamiteExplosionSpawnRock_LOCKED, dynamiteExplosionAddTimeChance_LOCKED, dynamiteExplosionSpawnLightning_LOCKED;

    public GameObject plazmaBallSpawn_1_LOCKED, plazmaBallSpawn_2_LOCKED, plazmaBallTime_LOCKED, plazmaBallSize_LOCKED, plazmaBallExplosionChance_LOCKED, plazmaBallSpawnSmallChance_LOCKED, plazmaBallDamage_LOCKED, plazmaBallSpawnPickaxeChance_LOCKED;
    #endregion

    #region Misc
    public GameObject allProjectileDoubleDamageChance_LOCKED, allProjectileTriggerChance_LOCKED;
    public GameObject pickaxeDoubleDamageChance_1_LOCKED, pickaxeDoubleDamageChance_2_LOCKED;
    public GameObject intaMineChance_1_LOCKED, intaMineChance_2_LOCKED;
    public GameObject increaseSpawnChanceAllRocks_LOCKED;
    public GameObject craft2Material_LOCKED;
    public GameObject finalUpgrade_LOCKED;
    #endregion

    #endregion

    //All prices. Double varible
    #region ALL PRICES

    #region XP Prices (11)
    public static double moreXP_1_price, moreXP_2_price, moreXP_3_price, moreXP_4_price, moreXP_5_price, moreXP_6_price, moreXP_7_price, moreXP_8_price;
    public static double talentPointsPerXlevel_1_price, talentPointsPerXlevel_2_price, talentPointsPerXlevel_3_price;
    #endregion

    #region Lightning, Dynamite, and Plasma Balls Prices (27)
    public static double lightningBeamChanceS_1_price, lightningBeamChanceS_2_price, lightningBeamChancePH_1_price, lightningBeamChancePH_2_price, lightningBeamSpawnAnotherOneChance_price, lightningBeamDamage_price, lightningBeamSize_price, lightningSplashes_price, lightningBeamSpawnRock_price, lightningBeamExplosion_price, lightningBeamAddTime_price;

    public static double dynamiteChance_1_price, dynamiteChance_2_price, dynamiteSpawn2SmallChance_price, dynamiteExplosionSize_price, dynamiteDamage_price, dynamiteExplosionSpawnRock_price, dynamiteExplosionAddTimeChance_price, dynamiteExplosionSpawnLightning_price;

    public static double plazmaBallSpawn_1_price, plazmaBallSpawn_2_price, plazmaBallTime_price, plazmaBallSize_price, plazmaBallExplosionChance_price, plazmaBallSpawnSmallChance_price, plazmaBallDamage_price, plazmaBallSpawnPickaxeChance_price;
    #endregion

    #region Rocks and materials Prices (57)
    public static double spawnMoreRocks_1_price, spawnMoreRocks_2_price, spawnMoreRocks_3_price, spawnMoreRocks_4_price, spawnMoreRocks_5_price, spawnMoreRocks_6_price, spawnMoreRocks_7_price, spawnMoreRocks_8_price, spawnMoreRocks_9_price;

    public static double moreMeterialsFromRock_1_price, moreMeterialsFromRock_2_price, moreMeterialsFromRock_3_price, moreMeterialsFromRock_4_price, moreMeterialsFromRock_5_price;

    public static double marterialsWorthMore_1_price, marterialsWorthMore_2_price, marterialsWorthMore_3_price, marterialsWorthMore_4_price, marterialsWorthMore_5_price, marterialsWorthMore_6_price, marterialsWorthMore_7_price, marterialsWorthMore_8_price;

    public static double goldChunk_1_price, goldChunk_2_price, goldChunk_3_price, goldChunk_4_price, goldChunk_5__price, fullGold_1_price, fullGold_2_price, fullGold_3_price;

    public static double spawnCopper_price, copperChunk_1_price, copperChunk_2_price, copperChunk_3_price, fullCopper_1_price, fullCopper_2_price, fullCopper_3_price;

    public static double spawnIron_price, ironChunk_1_price, ironChunk_2_price, fullIron_1_price, fullIron_2_price;

    public static double cobaltSpawn_price, cobaltChunk_1_price, fullCobalt_1_price;

    public static double uraniumSpawn_price, uraniumChunk_1_price, fullUranium_1_price;

    public static double ismiumSpawn_price, ismiumChunk_1_price, fullIsmium_1_price;

    public static double iridiumSpawn_price, iridiumChunk_1_price, fullIridium_1_price;

    public static double painiteSpawn_price, painiteChunk_1_price, fullPainite_1_price;
    #endregion

    #region Better Pickaxe and Mining Erea Prices (12)
    public static double improvedPickaxe_1_price, improvedPickaxe_2_price, improvedPickaxe_3_price, improvedPickaxe_4_price, improvedPickaxe_5_price, improvedPickaxe_6_price;
    public static double biggerMiningErea_1_price, biggerMiningErea_2_price, biggerMiningErea_3_price, biggerMiningErea_4_price, shootCircleChance_price, increaseAndDecreaseMinignErea_price;
    #endregion

    #region Chance to Spawn Rock and Spawn Rock X Times Prices (12)
    public static double spawnRockEveryXrock_1_price, spawnRockEveryXrock_2_price, spawnRockEveryXrock_3_price;
    public static double spawnXRockEveryXSecond_1_price, spawnXRockEveryXSecond_2_price, spawnXRockEveryXSecond_3_price;
    public static double chanceToSpawnRockWhenMined_1_price, chanceToSpawnRockWhenMined_2_price, chanceToSpawnRockWhenMined_3_price, chanceToSpawnRockWhenMined_4_price, chanceToSpawnRockWhenMined_5_price, chanceToSpawnRockWhenMined_6_price;
    #endregion

    #region Spawn Pickaxes Prices (7)
    public static double chanceToMineRandomRock_1_price, chanceToMineRandomRock_2_price, chanceToMineRandomRock_3_price, chanceToMineRandomRock_4_price;
    public static double spawnPickaxeEverySecond_1_price, spawnPickaxeEverySecond_2_price, spawnPickaxeEverySecond_3_price;
    #endregion

    #region More Time Prices (6)
    public static double moreTime_1_price, moreTime_2_price, moreTime_3_price, moreTime_4_price;
    public static double chanceToAdd1SecondEverySecond_price, chanceAdd1SecondEveryRockMined_price;
    #endregion

    #region Chance for Double XP and Gold Prices (5)
    public static double doubleXpGoldChance_1_price, doubleXpGoldChance_2_price, doubleXpGoldChance_3_price, doubleXpGoldChance_4_price, doubleXpGoldChance_5_price;
    #endregion

    #region Misc Prices
    public static double allProjectileDoubleDamageChance_price, allProjectileTriggerChance_price;
    public static double pickaxeDoubleDamageChance_1_price, pickaxeDoubleDamageChance_2_price;
    public static double intaMineChance_1_price, intaMineChance_2_price;
    public static double increaseSpawnChanceAllRocks_price;
    public static double craft2Material_price;
    public static double finalUpgrade_price;
    #endregion

    #endregion

    //All booleans
    #region ALL PURCHASED BOOLEANS

    #region XP (11)
    public static bool moreXP_1_purchased, moreXP_2_purchased, moreXP_3_purchased, moreXP_4_purchased, moreXP_5_purchased, moreXP_6_purchased, moreXP_7_purchased, moreXP_8_purchased, talentPointsPerXlevel_1_purchased, talentPointsPerXlevel_2_purchased, talentPointsPerXlevel_3_purchased;
    #endregion

    #region Rocks and Materials (57)
    public static bool spawnMoreRocks_1_purchased, spawnMoreRocks_2_purchased, spawnMoreRocks_3_purchased, spawnMoreRocks_4_purchased, spawnMoreRocks_5_purchased, spawnMoreRocks_6_purchased, spawnMoreRocks_7_purchased, spawnMoreRocks_8_purchased, spawnMoreRocks_9_purchased;
    public static bool moreMeterialsFromRock_1_purchased, moreMeterialsFromRock_2_purchased, moreMeterialsFromRock_3_purchased, moreMeterialsFromRock_4_purchased, moreMeterialsFromRock_5_purchased;
    public static bool marterialsWorthMore_1_purchased, marterialsWorthMore_2_purchased, marterialsWorthMore_3_purchased, marterialsWorthMore_4_purchased, marterialsWorthMore_5_purchased, marterialsWorthMore_6_purchased, marterialsWorthMore_7_purchased, marterialsWorthMore_8_purchased;
    public static bool goldChunk_1_purchased, goldChunk_2_purchased, goldChunk_3_purchased, goldChunk_4_purchased, goldChunk_5_purchased, fullGold_1_purchased, fullGold_2_purchased, fullGold_3_purchased;
    public static bool spawnCopper_purchased, copperChunk_1_purchased, copperChunk_2_purchased, copperChunk_3_purchased, fullCopper_1_purchased, fullCopper_2_purchased, fullCopper_3_purchased;
    public static bool spawnIron_purchased, ironChunk_1_purchased, ironChunk_2_purchased, fullIron_1_purchased, fullIron_2_purchased;
    public static bool cobaltSpawn_purchased, cobaltChunk_1_purchased, fullCobalt_1_purchased;
    public static bool uraniumSpawn_purchased, uraniumChunk_1_purchased, fullUranium_1_purchased;
    public static bool ismiumSpawn_purchased, ismiumChunk_1_purchased, fullIsmium_1_purchased;
    public static bool iridiumSpawn_purchased, iridiumChunk_1_purchased, fullIridium_1_purchased;
    public static bool painiteSpawn_purchased, painiteChunk_1_purchased, fullPainite_1_purchased;
    #endregion

    #region Better Pickaxe and Mining Erea (12)
    public static bool improvedPickaxe_1_purchased, improvedPickaxe_2_purchased, improvedPickaxe_3_purchased, improvedPickaxe_4_purchased, improvedPickaxe_5_purchased, improvedPickaxe_6_purchased;
    public static bool biggerMiningErea_1_purchased, biggerMiningErea_2_purchased, biggerMiningErea_3_purchased, biggerMiningErea_4_purchased, shootCircleChance_purchased, increaseAndDecreaseMinignErea_purchased;
    #endregion

    #region Chance to Spawn Rock and Spawn Rock X Times (12)
    public static bool spawnRockEveryXrock_1_purchased, spawnRockEveryXrock_2_purchased, spawnRockEveryXrock_3_purchased;
    public static bool spawnXRockEveryXSecond_1_purchased, spawnXRockEveryXSecond_2_purchased, spawnXRockEveryXSecond_3_purchased;
    public static bool chanceToSpawnRockWhenMined_1_purchased, chanceToSpawnRockWhenMined_2_purchased, chanceToSpawnRockWhenMined_3_purchased, chanceToSpawnRockWhenMined_4_purchased, chanceToSpawnRockWhenMined_5_purchased, chanceToSpawnRockWhenMined_6_purchased;
    #endregion

    #region Spawn Pickaxes (7)
    public static bool chanceToMineRandomRock_1_purchased, chanceToMineRandomRock_2_purchased, chanceToMineRandomRock_3_purchased, chanceToMineRandomRock_4_purchased;
    public static bool spawnPickaxeEverySecond_1_purchased, spawnPickaxeEverySecond_2_purchased, spawnPickaxeEverySecond_3_purchased;
    #endregion

    #region More Time (6)
    public static bool moreTime_1_purchased, moreTime_2_purchased, moreTime_3_purchased, moreTime_4_purchased;
    public static bool chanceToAdd1SecondEverySecond_purchased, chanceAdd1SecondEveryRockMined_purchased;
    #endregion

    #region Chance for Double XP and Gold (5)
    public static bool doubleXpGoldChance_1_purchased, doubleXpGoldChance_2_purchased, doubleXpGoldChance_3_purchased, doubleXpGoldChance_4_purchased, doubleXpGoldChance_5_purchased;
    #endregion

    #region Lightning, Dynamite, and Plasma Balls (27)
    public static bool lightningBeamChanceS_1_purchased, lightningBeamChanceS_2_purchased, lightningBeamChancePH_1_purchased, lightningBeamChancePH_2_purchased, lightningBeamSpawnAnotherOneChance_purchased, lightningBeamDamage_purchased, lightningBeamSize_purchased, lightningSplashes_purchased, lightningBeamSpawnRock_purchased, lightningBeamExplosion_purchased, lightningBeamAddTime_purchased;
    public static bool dynamiteChance_1_purchased, dynamiteChance_2_purchased, dynamiteSpawn2SmallChance_purchased, dynamiteExplosionSize_purchased, dynamiteDamage_purchased, dynamiteExplosionSpawnRock_purchased, dynamiteExplosionAddTimeChance_purchased, dynamiteExplosionSpawnLightning_purchased;
    public static bool plazmaBallSpawn_1_purchased, plazmaBallSpawn_2_purchased, plazmaBallTime_purchased, plazmaBallSize_purchased, plazmaBallExplosionChance_purchased, plazmaBallSpawnSmallChance_purchased, plazmaBallDamage_purchased, plazmaBallSpawnPickaxeChance_purchased;
    #endregion

    #region Misc (9)
    public static bool allProjectileDoubleDamageChance_purchased, allProjectileTriggerChance_purchased;
    public static bool pickaxeDoubleDamageChance_1_purchased, pickaxeDoubleDamageChance_2_purchased;
    public static bool intaMineChance_1_purchased, intaMineChance_2_purchased;
    public static bool increaseSpawnChanceAllRocks_purchased;
    public static bool craft2Material_purchased;
    public static bool finalUpgrade_purchased;
    #endregion

    #endregion

    //All purchase count integer variables
    #region ALL PURCHASE COUNT INTEGERS

    #region XP (11)
    public static int moreXP_1_purchaseCount, moreXP_2_purchaseCount, moreXP_3_purchaseCount, moreXP_4_purchaseCount, moreXP_5_purchaseCount, moreXP_6_purchaseCount, moreXP_7_purchaseCount, moreXP_8_purchaseCount;
    public static int talentPointsPerXlevel_1_purchaseCount, talentPointsPerXlevel_2_purchaseCount, talentPointsPerXlevel_3_purchaseCount;
    #endregion

    #region Rocks and Materials (57)
    public static int spawnMoreRocks_1_purchaseCount, spawnMoreRocks_2_purchaseCount, spawnMoreRocks_3_purchaseCount, spawnMoreRocks_4_purchaseCount, spawnMoreRocks_5_purchaseCount, spawnMoreRocks_6_purchaseCount, spawnMoreRocks_7_purchaseCount, spawnMoreRocks_8_purchaseCount, spawnMoreRocks_9_purchaseCount;

    public static int moreMeterialsFromRock_1_purchaseCount, moreMeterialsFromRock_2_purchaseCount, moreMeterialsFromRock_3_purchaseCount, moreMeterialsFromRock_4_purchaseCount, moreMeterialsFromRock_5_purchaseCount;

    public static int marterialsWorthMore_1_purchaseCount, marterialsWorthMore_2_purchaseCount, marterialsWorthMore_3_purchaseCount, marterialsWorthMore_4_purchaseCount, marterialsWorthMore_5_purchaseCount, marterialsWorthMore_6_purchaseCount, marterialsWorthMore_7_purchaseCount, marterialsWorthMore_8_purchaseCount;

    public static int goldChunk_1_purchaseCount, goldChunk_2_purchaseCount, goldChunk_3_purchaseCount, goldChunk_4_purchaseCount, goldChunk_5_purchaseCount, fullGold_1_purchaseCount, fullGold_2_purchaseCount, fullGold_3_purchaseCount;

    public static int spawnCopper_purchaseCount, copperChunk_1_purchaseCount, copperChunk_2_purchaseCount, copperChunk_3_purchaseCount, fullCopper_1_purchaseCount, fullCopper_2_purchaseCount, fullCopper_3_purchaseCount;

    public static int spawnIron_purchaseCount, ironChunk_1_purchaseCount, ironChunk_2_purchaseCount, fullIron_1_purchaseCount, fullIron_2_purchaseCount;

    public static int cobaltSpawn_purchaseCount, cobaltChunk_1_purchaseCount, fullCobalt_1_purchaseCount;

    public static int uraniumSpawn_purchaseCount, uraniumChunk_1_purchaseCount, fullUranium_1_purchaseCount;

    public static int ismiumSpawn_purchaseCount, ismiumChunk_1_purchaseCount, fullIsmium_1_purchaseCount;

    public static int iridiumSpawn_purchaseCount, iridiumChunk_1_purchaseCount, fullIridium_1_purchaseCount;

    public static int painiteSpawn_purchaseCount, painiteChunk_1_purchaseCount, fullPainite_1_purchaseCount;
    #endregion

    #region Better Pickaxe and Mining Erea (12)
    public static int improvedPickaxe_1_purchaseCount, improvedPickaxe_2_purchaseCount, improvedPickaxe_3_purchaseCount, improvedPickaxe_4_purchaseCount, improvedPickaxe_5_purchaseCount, improvedPickaxe_6_purchaseCount;
    public static int biggerMiningErea_1_purchaseCount, biggerMiningErea_2_purchaseCount, biggerMiningErea_3_purchaseCount, biggerMiningErea_4_purchaseCount, shootCircleChance_purchaseCount, increaseAndDecreaseMinignErea_purchaseCount;
    #endregion

    #region Chance to Spawn Rock and Spawn Rock X Times (12)
    public static int spawnRockEveryXrock_1_purchaseCount, spawnRockEveryXrock_2_purchaseCount, spawnRockEveryXrock_3_purchaseCount;
    public static int spawnXRockEveryXSecond_1_purchaseCount, spawnXRockEveryXSecond_2_purchaseCount, spawnXRockEveryXSecond_3_purchaseCount;
    public static int chanceToSpawnRockWhenMined_1_purchaseCount, chanceToSpawnRockWhenMined_2_purchaseCount, chanceToSpawnRockWhenMined_3_purchaseCount, chanceToSpawnRockWhenMined_4_purchaseCount, chanceToSpawnRockWhenMined_5_purchaseCount, chanceToSpawnRockWhenMined_6_purchaseCount;
    #endregion

    #region Spawn Pickaxes (7)
    public static int chanceToMineRandomRock_1_purchaseCount, chanceToMineRandomRock_2_purchaseCount, chanceToMineRandomRock_3_purchaseCount, chanceToMineRandomRock_4_purchaseCount;
    public static int spawnPickaxeEverySecond_1_purchaseCount, spawnPickaxeEverySecond_2_purchaseCount, spawnPickaxeEverySecond_3_purchaseCount;
    #endregion

    #region More Time (6)
    public static int moreTime_1_purchaseCount, moreTime_2_purchaseCount, moreTime_3_purchaseCount, moreTime_4_purchaseCount, chanceToAdd1SecondEverySecond_purchaseCount, chanceAdd1SecondEveryRockMined_purchaseCount;
    #endregion

    #region Chance for Double XP and Gold (5)
    public static int doubleXpGoldChance_1_purchaseCount, doubleXpGoldChance_2_purchaseCount, doubleXpGoldChance_3_purchaseCount, doubleXpGoldChance_4_purchaseCount, doubleXpGoldChance_5_purchaseCount;
    #endregion

    #region Lightning, Dynamite, and PlazmaBalls (27)
    public static int lightningBeamChanceS_1_purchaseCount, lightningBeamChanceS_2_purchaseCount, lightningBeamChancePH_1_purchaseCount, lightningBeamChancePH_2_purchaseCount, lightningBeamSpawnAnotherOneChance_purchaseCount, lightningBeamDamage_purchaseCount, lightningBeamSize_purchaseCount, lightningSplashes_purchaseCount, lightningBeamSpawnRock_purchaseCount, lightningBeamExplosion_purchaseCount, lightningBeamAddTime_purchaseCount;

    public static int dynamiteChance_1_purchaseCount, dynamiteChance_2_purchaseCount, dynamiteSpawn2SmallChance_purchaseCount, dynamiteExplosionSize_purchaseCount, dynamiteDamage_purchaseCount, dynamiteExplosionSpawnRock_purchaseCount, dynamiteExplosionAddTimeChance_purchaseCount, dynamiteExplosionSpawnLightning_purchaseCount;

    public static int plazmaBallSpawn_1_purchaseCount, plazmaBallSpawn_2_purchaseCount, plazmaBallTime_purchaseCount, plazmaBallSize_purchaseCount, plazmaBallExplosionChance_purchaseCount, plazmaBallSpawnSmallChance_purchaseCount, plazmaBallDamage_purchaseCount, plazmaBallSpawnPickaxeChance_purchaseCount;
    #endregion

    #region Misc (9)
    public static int allProjectileDoubleDamageChance_purchaseCount, allProjectileTriggerChance_purchaseCount;
    public static int pickaxeDoubleDamageChance_1_purchaseCount, pickaxeDoubleDamageChance_2_purchaseCount;
    public static int intaMineChance_1_purchaseCount, intaMineChance_2_purchaseCount;
    public static int increaseSpawnChanceAllRocks_purchaseCount;
    public static int craft2Material_purchaseCount;
    public static int finalUpgrade_purchaseCount;
    #endregion

    #endregion


    //146 total upgrades

    public static int totalMaterialRocksSpawning;

    private void Start()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].SetActive(false);
            finaLine.SetActive(false);
        }

        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);

        SkillTreePrices();
        CheckUpgrades();

        circleShootChance = 25f;
        chanceToAdd1SecEverySec = 9f;
        chanceToAdd1SecEveryRockMined = 0.4f;

        triggerAnotherLighntingChance = 12;
        lightningSplashChance = 17;
        lightningSparkDamage = 15;
        lightningSpawnRockChance = 5;
        lightningSpawnExplosionChance = 20;
        lightningAddTimeChance = 1;

        spawn2DynamiteChance = 10;
        chanceToSpawnRockFromExplosion = 5;
        explosionAdd1SecondChance = 1;
        explosionChanceToSpawnLightning = 10;

        plazmaballExplosionChance = 17;
        plazmaBallSpawnSmallBallChance = 13;
        plazmaBallChanceToSpawnPickaxe = 4;

        allProjectileDoubleDamageIncrease = 5;
        allProjcetileTriggerChance = 15;
        allRockSpawnChanceIncrease = 5;

        if (TheAnvil.pickaxe14_crafted)
        {
           // endingButton.SetActive(false);
        }
    }

    public static float circleShootChance;
    public static float chanceToAdd1SecEverySec;
    public static float chanceToAdd1SecEveryRockMined;

    public static float triggerAnotherLighntingChance;
    public static float lightningSplashChance, lightningSparkDamage;
    public static float lightningSpawnRockChance;
    public static float lightningSpawnExplosionChance;
    public static float lightningAddTimeChance;

    public static float spawn2DynamiteChance;
    public static float chanceToSpawnRockFromExplosion;
    public static float explosionAdd1SecondChance;
    public static float explosionChanceToSpawnLightning;
    public static float plazmaballExplosionChance;
    public static float plazmaBallSpawnSmallBallChance;
    public static float plazmaBallChanceToSpawnPickaxe;
    public static float allRockSpawnChanceIncrease;
    public static float allProjectileDoubleDamageIncrease;
    public static float allProjcetileTriggerChance;


    //Save this
    public static int totalSkillTreeUpgradesPurchased;
    public static int totalUpgradesFullyPurchased;

    public static int mineSessionTime;

    public static int totalRocksToSpawn;
    public static int extraTalentPointPerLevel;

    //Rock chances
    public static float goldRockChance;
    public static float fullGoldRockChance;

    public static float copperRockChance;
    public static float fullCopperRockChance;

    public static float ironRockChance;
    public static float fullIronRockChance;

    public static float cobaltRockChance;
    public static float fullCobaltRockChance;

    public static float uraniumRockChance;
    public static float fullUraniumRockChance;

    public static float ismiumRockChance;
    public static float fullIsmiumRockChance;

    public static float iridiumRockChance;
    public static float fullIridiumRockChance;

    public static float painiteRockChance;
    public static float fullPainiteRockChance;

    //Pickaxe
    public static float improvedPickaxeStrength;
    public static float reducePickaxeMineTime;

    //Mining Area
    public static float miningAreaSize;

    //Spawn rocks
    public static float spawnRockEveryXRock;
    public static float spawnXRockEveryXSecond;
    public static float chanceToSpawnRockWhenMined;

    //Materials dropped from rocks
    public static int materialsFromChunkRocks;
    public static int materialsFromFullRocks;

    //Materials worth more
    public static float materialsTotalWorth;

    //Chance to spawn pickaxe
    public static float chanceToMineRandomRock;
    public static float spawnPickaxeEverySecond;

    public static float doubleXpAndGoldChance;

    //Lightning
    public static float lightningTriggerChanceS, lightningTriggerChancePH;
    public static float lightningDamage;
    public static float lightningSize;

    //Dynamite
    public static float dynamiteStickChance;
    public static float explosionSize;
    public static float explosionDamagage;

    //Plazmba balls
    public static float plazmaBallChance;
    public static float plazmaBallTimer;
    public static float plazmaBallTotalSize;
    public static float plazmaBallTotalDamage;

    //Misc
    public static float doubleDamageChance;
    public static float instaMineChance;
    

    #region Set all prices
    public void SkillTreePrices()
    {
        #region XP Prices Initialization
        moreXP_1_price = 10 * LevelMechanics.steamSaleDiscount;
        moreXP_2_price = 12 * LevelMechanics.steamSaleDiscount;
        moreXP_3_price = 14 * LevelMechanics.steamSaleDiscount;
        moreXP_4_price = 23 * LevelMechanics.steamSaleDiscount;
        moreXP_5_price = 32 * LevelMechanics.steamSaleDiscount;
        moreXP_6_price = 23 * LevelMechanics.steamSaleDiscount;
        moreXP_7_price = 34 * LevelMechanics.steamSaleDiscount;
        moreXP_8_price = 45 * LevelMechanics.steamSaleDiscount;

        talentPointsPerXlevel_1_price = 12 * LevelMechanics.steamSaleDiscount;
        talentPointsPerXlevel_2_price = 23 * LevelMechanics.steamSaleDiscount;
        talentPointsPerXlevel_3_price = 54 * LevelMechanics.steamSaleDiscount;
        #endregion

        #region Lightning, Dynamite, and Plasma Balls Prices Initialization
        lightningBeamChanceS_1_price = 20 * LevelMechanics.steamSaleDiscount;
        lightningBeamChanceS_2_price = 22 * LevelMechanics.steamSaleDiscount;
        lightningBeamChancePH_1_price = 34 * LevelMechanics.steamSaleDiscount;
        lightningBeamChancePH_2_price = 34 * LevelMechanics.steamSaleDiscount;
        lightningBeamSpawnAnotherOneChance_price = 46 * LevelMechanics.steamSaleDiscount;
        lightningBeamDamage_price = 45 * LevelMechanics.steamSaleDiscount;
        lightningBeamSize_price = 65 * LevelMechanics.steamSaleDiscount;
        lightningSplashes_price = 65 * LevelMechanics.steamSaleDiscount;
        lightningBeamSpawnRock_price = 43 * LevelMechanics.steamSaleDiscount;
        lightningBeamExplosion_price = 53 * LevelMechanics.steamSaleDiscount;
        lightningBeamAddTime_price = 43 * LevelMechanics.steamSaleDiscount;

        dynamiteChance_1_price = 64 * LevelMechanics.steamSaleDiscount;
        dynamiteChance_2_price = 23 * LevelMechanics.steamSaleDiscount;
        dynamiteSpawn2SmallChance_price = 32 * LevelMechanics.steamSaleDiscount;
        dynamiteExplosionSize_price = 23 * LevelMechanics.steamSaleDiscount;
        dynamiteDamage_price = 34 * LevelMechanics.steamSaleDiscount;
        dynamiteExplosionSpawnRock_price = 54 * LevelMechanics.steamSaleDiscount;
        dynamiteExplosionAddTimeChance_price = 52 * LevelMechanics.steamSaleDiscount;
        dynamiteExplosionSpawnLightning_price = 34 * LevelMechanics.steamSaleDiscount;

        plazmaBallSpawn_1_price = 12 * LevelMechanics.steamSaleDiscount;
        plazmaBallSpawn_2_price = 34 * LevelMechanics.steamSaleDiscount;
        plazmaBallTime_price = 12 * LevelMechanics.steamSaleDiscount;
        plazmaBallSize_price = 35 * LevelMechanics.steamSaleDiscount;
        plazmaBallExplosionChance_price = 40 * LevelMechanics.steamSaleDiscount;
        plazmaBallSpawnSmallChance_price = 23 * LevelMechanics.steamSaleDiscount;
        plazmaBallDamage_price = 21 * LevelMechanics.steamSaleDiscount;
        plazmaBallSpawnPickaxeChance_price = 32 * LevelMechanics.steamSaleDiscount;
        #endregion

        #region Spawn more rocks
        spawnMoreRocks_1_price = 5 * LevelMechanics.steamSaleDiscount;
        spawnMoreRocks_2_price = 10 * LevelMechanics.steamSaleDiscount;
        spawnMoreRocks_3_price = 30 * LevelMechanics.steamSaleDiscount;
        spawnMoreRocks_4_price = 200 * LevelMechanics.steamSaleDiscount;
        spawnMoreRocks_5_price = 500 * LevelMechanics.steamSaleDiscount;
        spawnMoreRocks_6_price = 3000 * LevelMechanics.steamSaleDiscount;
        spawnMoreRocks_7_price = 15000 * LevelMechanics.steamSaleDiscount;
        spawnMoreRocks_8_price = 500000 * LevelMechanics.steamSaleDiscount;
        spawnMoreRocks_9_price = 1500000 * LevelMechanics.steamSaleDiscount;
        #endregion

        #region More matertials from rocks
        moreMeterialsFromRock_1_price = 250 * LevelMechanics.steamSaleDiscount;
        moreMeterialsFromRock_2_price = 2000 * LevelMechanics.steamSaleDiscount;
        moreMeterialsFromRock_3_price = 4500 * LevelMechanics.steamSaleDiscount;
        moreMeterialsFromRock_4_price = 52 * LevelMechanics.steamSaleDiscount;
        moreMeterialsFromRock_5_price = 74 * LevelMechanics.steamSaleDiscount;
        #endregion

        #region Material worth more
        marterialsWorthMore_1_price = 100 * LevelMechanics.steamSaleDiscount;
        marterialsWorthMore_2_price = 7500 * LevelMechanics.steamSaleDiscount;
        marterialsWorthMore_3_price = 65000 * LevelMechanics.steamSaleDiscount;
        marterialsWorthMore_5_price = 220000 * LevelMechanics.steamSaleDiscount;
        marterialsWorthMore_4_price = 4800000 * LevelMechanics.steamSaleDiscount;
        marterialsWorthMore_6_price = 900000000 * LevelMechanics.steamSaleDiscount;
        marterialsWorthMore_7_price = 11400000000 * LevelMechanics.steamSaleDiscount;
        marterialsWorthMore_8_price = 5000000000000 * LevelMechanics.steamSaleDiscount;
        #endregion

        #region Gold rock spawn
        goldChunk_1_price = 7 * LevelMechanics.steamSaleDiscount;
        goldChunk_2_price = 23 * LevelMechanics.steamSaleDiscount;
        goldChunk_3_price = 43 * LevelMechanics.steamSaleDiscount;
        goldChunk_4_price = 65 * LevelMechanics.steamSaleDiscount;
        goldChunk_5__price = 67 * LevelMechanics.steamSaleDiscount;
        fullGold_1_price = 78 * LevelMechanics.steamSaleDiscount;
        fullGold_2_price = 87 * LevelMechanics.steamSaleDiscount;
        fullGold_3_price = 99 * LevelMechanics.steamSaleDiscount;
        #endregion

        #region Copper rock spawn
        spawnCopper_price = 300 * LevelMechanics.steamSaleDiscount;
        copperChunk_1_price = 32 * LevelMechanics.steamSaleDiscount;
        copperChunk_2_price = 34 * LevelMechanics.steamSaleDiscount;
        copperChunk_3_price = 54 * LevelMechanics.steamSaleDiscount;
        fullCopper_1_price = 57 * LevelMechanics.steamSaleDiscount;
        fullCopper_2_price = 76 * LevelMechanics.steamSaleDiscount;
        fullCopper_3_price = 90 * LevelMechanics.steamSaleDiscount;
        #endregion

        #region Iron rock spawn
        spawnIron_price = 12 * LevelMechanics.steamSaleDiscount;
        ironChunk_1_price = 14 * LevelMechanics.steamSaleDiscount;
        ironChunk_2_price = 23 * LevelMechanics.steamSaleDiscount;
        fullIron_1_price = 42 * LevelMechanics.steamSaleDiscount;
        fullIron_2_price = 43 * LevelMechanics.steamSaleDiscount;
        #endregion

        #region Cobalt rock spawn
        cobaltSpawn_price = 32 * LevelMechanics.steamSaleDiscount;
        cobaltChunk_1_price = 34 * LevelMechanics.steamSaleDiscount;
        fullCobalt_1_price = 56 * LevelMechanics.steamSaleDiscount;
        #endregion

        #region Uranium rock spawn
        uraniumSpawn_price = 24 * LevelMechanics.steamSaleDiscount;
        uraniumChunk_1_price = 56 * LevelMechanics.steamSaleDiscount;
        fullUranium_1_price = 64 * LevelMechanics.steamSaleDiscount;
        #endregion

        #region Ismium rock spawn
        ismiumSpawn_price = 21 * LevelMechanics.steamSaleDiscount;
        ismiumChunk_1_price = 22 * LevelMechanics.steamSaleDiscount;
        fullIsmium_1_price = 34 * LevelMechanics.steamSaleDiscount;
        #endregion

        #region Iridium rock spawn
        iridiumSpawn_price = 45 * LevelMechanics.steamSaleDiscount;
        iridiumChunk_1_price = 46 * LevelMechanics.steamSaleDiscount;
        fullIridium_1_price = 76 * LevelMechanics.steamSaleDiscount;
        #endregion

        #region Painite rock spawn
        painiteSpawn_price = 34 * LevelMechanics.steamSaleDiscount;
        painiteChunk_1_price = 54 * LevelMechanics.steamSaleDiscount;
        fullPainite_1_price = 67 * LevelMechanics.steamSaleDiscount;
        #endregion

        #region Better Pickaxe and Mining Erea Prices Initialization
        improvedPickaxe_1_price = 15 * LevelMechanics.steamSaleDiscount;
        improvedPickaxe_2_price = 300 * LevelMechanics.steamSaleDiscount;
        improvedPickaxe_3_price = 6000 * LevelMechanics.steamSaleDiscount;
        improvedPickaxe_4_price = 15000 * LevelMechanics.steamSaleDiscount;
        improvedPickaxe_5_price = 500000 * LevelMechanics.steamSaleDiscount;
        improvedPickaxe_6_price = 1000000 * LevelMechanics.steamSaleDiscount;

        biggerMiningErea_1_price = 10 * LevelMechanics.steamSaleDiscount;
        biggerMiningErea_2_price = 1000 * LevelMechanics.steamSaleDiscount;
        biggerMiningErea_3_price = 300 * LevelMechanics.steamSaleDiscount;
        biggerMiningErea_4_price = 54 * LevelMechanics.steamSaleDiscount;
        shootCircleChance_price = 21 * LevelMechanics.steamSaleDiscount;
        increaseAndDecreaseMinignErea_price = 34 * LevelMechanics.steamSaleDiscount;
        #endregion

        #region Chance to Spawn Rock and Spawn Rock X Times Prices Initialization
        spawnRockEveryXrock_1_price = 21 * LevelMechanics.steamSaleDiscount;
        spawnRockEveryXrock_2_price = 23 * LevelMechanics.steamSaleDiscount;
        spawnRockEveryXrock_3_price = 45 * LevelMechanics.steamSaleDiscount;

        spawnXRockEveryXSecond_1_price = 34 * LevelMechanics.steamSaleDiscount;
        spawnXRockEveryXSecond_2_price = 54 * LevelMechanics.steamSaleDiscount;
        spawnXRockEveryXSecond_3_price = 76 * LevelMechanics.steamSaleDiscount;

        chanceToSpawnRockWhenMined_1_price = 21 * LevelMechanics.steamSaleDiscount;
        chanceToSpawnRockWhenMined_2_price = 24 * LevelMechanics.steamSaleDiscount;
        chanceToSpawnRockWhenMined_3_price = 54 * LevelMechanics.steamSaleDiscount;
        chanceToSpawnRockWhenMined_4_price = 56 * LevelMechanics.steamSaleDiscount;
        chanceToSpawnRockWhenMined_5_price = 74 * LevelMechanics.steamSaleDiscount;
        chanceToSpawnRockWhenMined_6_price = 87 * LevelMechanics.steamSaleDiscount;
        #endregion

        #region Spawn Pickaxes Prices Initialization
        chanceToMineRandomRock_1_price = 12 * LevelMechanics.steamSaleDiscount;
        chanceToMineRandomRock_2_price = 22 * LevelMechanics.steamSaleDiscount;
        chanceToMineRandomRock_3_price = 34 * LevelMechanics.steamSaleDiscount;
        chanceToMineRandomRock_4_price = 56 * LevelMechanics.steamSaleDiscount;

        spawnPickaxeEverySecond_1_price = 23 * LevelMechanics.steamSaleDiscount;
        spawnPickaxeEverySecond_2_price = 45 * LevelMechanics.steamSaleDiscount;
        spawnPickaxeEverySecond_3_price = 67 * LevelMechanics.steamSaleDiscount;
        #endregion

        #region More Time Prices Initialization
        moreTime_1_price = 21 * LevelMechanics.steamSaleDiscount;
        moreTime_2_price = 23 * LevelMechanics.steamSaleDiscount;
        moreTime_3_price = 43 * LevelMechanics.steamSaleDiscount;
        moreTime_4_price = 56 * LevelMechanics.steamSaleDiscount;

        chanceToAdd1SecondEverySecond_price = 23 * LevelMechanics.steamSaleDiscount;
        chanceAdd1SecondEveryRockMined_price = 34 * LevelMechanics.steamSaleDiscount;
        #endregion

        #region Chance for Double XP and Gold Prices Initialization
        doubleXpGoldChance_1_price = 21 * LevelMechanics.steamSaleDiscount;
        doubleXpGoldChance_2_price = 34 * LevelMechanics.steamSaleDiscount;
        doubleXpGoldChance_3_price = 35 * LevelMechanics.steamSaleDiscount;
        doubleXpGoldChance_4_price = 45 * LevelMechanics.steamSaleDiscount;
        doubleXpGoldChance_5_price = 65 * LevelMechanics.steamSaleDiscount;
        #endregion

        #region Misc Prices Initialization
        allProjectileDoubleDamageChance_price = 21 * LevelMechanics.steamSaleDiscount;
        allProjectileTriggerChance_price = 34 * LevelMechanics.steamSaleDiscount;

        pickaxeDoubleDamageChance_1_price = 56 * LevelMechanics.steamSaleDiscount;
        pickaxeDoubleDamageChance_2_price = 76 * LevelMechanics.steamSaleDiscount;

        intaMineChance_1_price = 54 * LevelMechanics.steamSaleDiscount;
        intaMineChance_2_price = 34 * LevelMechanics.steamSaleDiscount;

        increaseSpawnChanceAllRocks_price = 54 * LevelMechanics.steamSaleDiscount;

        craft2Material_price = 34 * LevelMechanics.steamSaleDiscount;

        finalUpgrade_price = 23 * LevelMechanics.steamSaleDiscount;
        #endregion
    }
    #endregion

    #region Update
    public TextMeshProUGUI skillTreePrice_text;

    private void Update()
    {
        if (MainMenu.isInUpgrades)
        {
            string colorName = "yo";

            if (Tooltip.goldPriceST)
            {
                if (GoldAndOreMechanics.totalGoldBars >= LocalizationScript.currentSkillTreePrice)
                {
                    colorName = "<color=green>";
                }
                else
                {
                    colorName = "<color=red>";
                }
            }
            if (Tooltip.copperPriceST)
            {
                if (GoldAndOreMechanics.totalCopperBars >= LocalizationScript.currentSkillTreePrice)
                {
                    colorName = "<color=green>";
                }
                else
                {
                    colorName = "<color=red>";
                }
            }
            if (Tooltip.ironPriceST)
            {
                if (GoldAndOreMechanics.totalIronBars >= LocalizationScript.currentSkillTreePrice)
                {
                    colorName = "<color=green>";
                }
                else
                {
                    colorName = "<color=red>";
                }
            }
            if (Tooltip.cobaltPriceST)
            {
                if (GoldAndOreMechanics.totalCobaltBars >= LocalizationScript.currentSkillTreePrice)
                {
                    colorName = "<color=green>";
                }
                else
                {
                    colorName = "<color=red>";
                }
            }
            if (Tooltip.uraniumPriceST)
            {
                if (GoldAndOreMechanics.totalUraniumBars >= LocalizationScript.currentSkillTreePrice)
                {
                    colorName = "<color=green>";
                }
                else
                {
                    colorName = "<color=red>";
                }
            }
            if (Tooltip.ismiumPriceST)
            {
                if (GoldAndOreMechanics.totalIsmiumBar >= LocalizationScript.currentSkillTreePrice)
                {
                    colorName = "<color=green>";
                }
                else
                {
                    colorName = "<color=red>";
                }
            }
            if (Tooltip.iridiumPriceST)
            {
                if (GoldAndOreMechanics.totalIridiumBars >= LocalizationScript.currentSkillTreePrice)
                {
                    colorName = "<color=green>";
                }
                else
                {
                    colorName = "<color=red>";
                }
            }
            if (Tooltip.painitePriceST)
            {
                if (GoldAndOreMechanics.totalPainiteBars >= LocalizationScript.currentSkillTreePrice)
                {
                    colorName = "<color=green>";
                }
                else
                {
                    colorName = "<color=red>";
                }
            }

            skillTreePrice_text.text = $"Price: {colorName}{LocalizationScript.currentSkillTreePrice.ToString("F0")}";
        }
    }
    #endregion

    public void ReduceBars()
    {
        if (Tooltip.goldPriceST) { GoldAndOreMechanics.totalGoldBars -= LocalizationScript.currentHoverPrice; }
        if (Tooltip.copperPriceST) { GoldAndOreMechanics.totalCopperBars -= LocalizationScript.currentHoverPrice; }
        if (Tooltip.ironPriceST) { GoldAndOreMechanics.totalIronBars -= LocalizationScript.currentHoverPrice; }
        if (Tooltip.cobaltPriceST) { GoldAndOreMechanics.totalCobaltBars -= LocalizationScript.currentHoverPrice; }
        if (Tooltip.uraniumPriceST) { GoldAndOreMechanics.totalUraniumBars -= LocalizationScript.currentHoverPrice; }
        if (Tooltip.ismiumPriceST) { GoldAndOreMechanics.totalIsmiumBar -= LocalizationScript.currentHoverPrice; }
        if (Tooltip.iridiumPriceST) { GoldAndOreMechanics.totalIridiumBars -= LocalizationScript.currentHoverPrice; }
        if (Tooltip.painitePriceST) { GoldAndOreMechanics.totalPainiteBars -= LocalizationScript.currentHoverPrice; }

    }

    public void PurchaseUpgrade(string upgradeName)
    {
        audioManager.Play("Click_1");

        //More rocks
        #region All spawn more Rocks

        #region spawnMoreRocks_1
        if (upgradeName == "MoreRocks1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnMoreRocks_1_price)
            {
                totalRocksToSpawn += LocalizationScript.rockSpawnIncrease;

                spawnMoreRocks_1_purchased = true;
                spawnMoreRocks_1_purchaseCount += 1;
                LocalizationScript.currentPurchaseCount = spawnMoreRocks_1_purchaseCount;

                ReduceBars();
            }
            else
            {
                PlayErrorSound();
                return;
            }
        }

        #endregion

        #region spawnMoreRocks_2
        else if (upgradeName == "MoreRocks2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnMoreRocks_2_price)
            {
                totalRocksToSpawn += LocalizationScript.rockSpawnIncrease;

                spawnMoreRocks_2_purchased = true;
                spawnMoreRocks_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnMoreRocks_2_purchaseCount;

                ReduceBars();
            }
        }
        #endregion

        #region spawnMoreRocks_3
        else if (upgradeName == "MoreRocks3")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnMoreRocks_3_price)
            {
                if (Tutorial.pressedOkAnvil == false) { tutorialScript.SetTutorial(3); }

                totalRocksToSpawn += LocalizationScript.rockSpawnIncrease;

                ReduceBars();

                spawnMoreRocks_3_purchased = true;
                spawnMoreRocks_3_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnMoreRocks_3_purchaseCount;
            }
        }
        #endregion

        #region spawnMoreRocks_4
        else if (upgradeName == "MoreRocks4")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnMoreRocks_4_price)
            {
                totalRocksToSpawn += LocalizationScript.rockSpawnIncrease;

                ReduceBars();
                spawnMoreRocks_4_purchased = true;
                spawnMoreRocks_4_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnMoreRocks_4_purchaseCount;
            }
        }
        #endregion

        #region spawnMoreRocks_5
        else if (upgradeName == "MoreRocks5")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnMoreRocks_5_price)
            {
                totalRocksToSpawn += LocalizationScript.rockSpawnIncrease;

                ReduceBars();
                spawnMoreRocks_5_purchased = true;
                spawnMoreRocks_5_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnMoreRocks_5_purchaseCount;
            }
        }
        #endregion

        #region spawnMoreRocks_6
        else if (upgradeName == "MoreRocks6")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnMoreRocks_6_price)
            {
                totalRocksToSpawn += LocalizationScript.rockSpawnIncrease;

                ReduceBars();
                spawnMoreRocks_6_purchased = true;
                spawnMoreRocks_6_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnMoreRocks_6_purchaseCount;
            }
        }
        #endregion

        #region spawnMoreRocks_7
        else if (upgradeName == "MoreRocks7")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnMoreRocks_7_price)
            {
                totalRocksToSpawn += LocalizationScript.rockSpawnIncrease;

                ReduceBars();
                spawnMoreRocks_7_purchased = true;
                spawnMoreRocks_7_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnMoreRocks_7_purchaseCount;
            }
        }
        #endregion

        #region spawnMoreRocks_8
        else if (upgradeName == "MoreRocks8")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnMoreRocks_8_price)
            {
                totalRocksToSpawn += LocalizationScript.rockSpawnIncrease;

                ReduceBars();
                spawnMoreRocks_8_purchased = true;
                spawnMoreRocks_8_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnMoreRocks_8_purchaseCount;
            }
        }
        #endregion

        #region spawnMoreRocks_9
        else if (upgradeName == "MoreRocks9")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnMoreRocks_9_price)
            {
                totalRocksToSpawn += LocalizationScript.rockSpawnIncrease;

                ReduceBars();
                spawnMoreRocks_9_purchased = true;
                spawnMoreRocks_9_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnMoreRocks_9_purchaseCount;
            }
        }
        #endregion

        #endregion

        //More materials from rocks
        #region All more materials from rocks

        #region moreMeterialsFromRock_1
        else if (upgradeName == "moreMeterialsFromRock_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= moreMeterialsFromRock_1_price)
            {
                materialsFromChunkRocks += LocalizationScript.materialsFromChunkRocksIncrease;
                materialsFromFullRocks += LocalizationScript.materialsFromFullRocksIncrease;

                ReduceBars();
                moreMeterialsFromRock_1_purchased = true;
                moreMeterialsFromRock_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = moreMeterialsFromRock_1_purchaseCount;
            }
        }
        #endregion

        #region moreMeterialsFromRock_2
        else if (upgradeName == "moreMeterialsFromRock_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= moreMeterialsFromRock_2_price)
            {
                materialsFromChunkRocks += LocalizationScript.materialsFromChunkRocksIncrease;
                materialsFromFullRocks += LocalizationScript.materialsFromFullRocksIncrease;

                ReduceBars();
                moreMeterialsFromRock_2_purchased = true;
                moreMeterialsFromRock_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = moreMeterialsFromRock_2_purchaseCount;
            }
        }
        #endregion

        #region moreMeterialsFromRock_3
        else if (upgradeName == "moreMeterialsFromRock_3")
        {
            if (GoldAndOreMechanics.totalGoldBars >= moreMeterialsFromRock_3_price)
            {
                materialsFromChunkRocks += LocalizationScript.materialsFromChunkRocksIncrease;
                materialsFromFullRocks += LocalizationScript.materialsFromFullRocksIncrease;

                ReduceBars();
                moreMeterialsFromRock_3_purchased = true;
                moreMeterialsFromRock_3_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = moreMeterialsFromRock_3_purchaseCount;
            }
        }
        #endregion

        #region moreMeterialsFromRock_4
        else if (upgradeName == "moreMeterialsFromRock_4")
        {
            if (GoldAndOreMechanics.totalGoldBars >= moreMeterialsFromRock_4_price)
            {
                materialsFromChunkRocks += LocalizationScript.materialsFromChunkRocksIncrease;
                materialsFromFullRocks += LocalizationScript.materialsFromFullRocksIncrease;

                ReduceBars();
                moreMeterialsFromRock_4_purchased = true;
                moreMeterialsFromRock_4_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = moreMeterialsFromRock_4_purchaseCount;
            }
        }
        #endregion

        #region moreMeterialsFromRock_5
        else if (upgradeName == "moreMeterialsFromRock_5")
        {
            if (GoldAndOreMechanics.totalGoldBars >= moreMeterialsFromRock_5_price)
            {
                materialsFromChunkRocks += LocalizationScript.materialsFromChunkRocksIncrease;
                materialsFromFullRocks += LocalizationScript.materialsFromFullRocksIncrease;

                ReduceBars();
                moreMeterialsFromRock_5_purchased = true;
                moreMeterialsFromRock_5_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = moreMeterialsFromRock_5_purchaseCount;
            }
        }
        #endregion

        #endregion

        //Materials worth more
        #region All materials with more

        #region marterialsWorthMore_1
        else if (upgradeName == "marterialsWorthMore_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= marterialsWorthMore_1_price)
            {
                materialsTotalWorth += LocalizationScript.materialsWorthIncrease;

                ReduceBars();
                marterialsWorthMore_1_purchased = true;
                marterialsWorthMore_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = marterialsWorthMore_1_purchaseCount;
            }
        }
        #endregion

        #region marterialsWorthMore_2
        else if (upgradeName == "marterialsWorthMore_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= marterialsWorthMore_2_price)
            {
                materialsTotalWorth += LocalizationScript.materialsWorthIncrease;

                ReduceBars();
                marterialsWorthMore_2_purchased = true;
                marterialsWorthMore_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = marterialsWorthMore_2_purchaseCount;
            }
        }
        #endregion

        #region marterialsWorthMore_3
        else if (upgradeName == "marterialsWorthMore_3")
        {
            if (GoldAndOreMechanics.totalGoldBars >= marterialsWorthMore_3_price)
            {
                materialsTotalWorth += LocalizationScript.materialsWorthIncrease;

                ReduceBars();
                marterialsWorthMore_3_purchased = true;
                marterialsWorthMore_3_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = marterialsWorthMore_3_purchaseCount;
            }
        }
        #endregion

        #region marterialsWorthMore_4
        else if (upgradeName == "marterialsWorthMore_4")
        {
            if (GoldAndOreMechanics.totalGoldBars >= marterialsWorthMore_4_price)
            {
                materialsTotalWorth += LocalizationScript.materialsWorthIncrease;

                ReduceBars();
                marterialsWorthMore_4_purchased = true;
                marterialsWorthMore_4_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = marterialsWorthMore_4_purchaseCount;
            }
        }
        #endregion

        #region marterialsWorthMore_5
        else if (upgradeName == "marterialsWorthMore_5")
        {
            if (GoldAndOreMechanics.totalGoldBars >= marterialsWorthMore_5_price)
            {
                materialsTotalWorth += LocalizationScript.materialsWorthIncrease;

                ReduceBars();
                marterialsWorthMore_5_purchased = true;
                marterialsWorthMore_5_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = marterialsWorthMore_5_purchaseCount;
            }
        }
        #endregion

        #region marterialsWorthMore_6
        else if (upgradeName == "marterialsWorthMore_6")
        {
            if (GoldAndOreMechanics.totalGoldBars >= marterialsWorthMore_6_price)
            {
                materialsTotalWorth += LocalizationScript.materialsWorthIncrease;

                ReduceBars();
                marterialsWorthMore_6_purchased = true;
                marterialsWorthMore_6_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = marterialsWorthMore_6_purchaseCount;
            }
        }
        #endregion

        #region marterialsWorthMore_7
        else if (upgradeName == "marterialsWorthMore_7")
        {
            if (GoldAndOreMechanics.totalGoldBars >= marterialsWorthMore_7_price)
            {
                materialsTotalWorth += LocalizationScript.materialsWorthIncrease;

                ReduceBars();
                marterialsWorthMore_7_purchased = true;
                marterialsWorthMore_7_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = marterialsWorthMore_7_purchaseCount;
            }
        }
        #endregion

        #region marterialsWorthMore_8
        else if (upgradeName == "marterialsWorthMore_8")
        {
            if (GoldAndOreMechanics.totalGoldBars >= marterialsWorthMore_8_price)
            {
                materialsTotalWorth += LocalizationScript.materialsWorthIncrease;

                ReduceBars();
                marterialsWorthMore_8_purchased = true;
                marterialsWorthMore_8_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = marterialsWorthMore_8_purchaseCount;
            }
        }
        #endregion

        #endregion

        //Gold rocks
        #region All gold rocks

        #region goldChunk_1
        else if (upgradeName == "goldChunk_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= goldChunk_1_price)
            {
                goldRockChance += LocalizationScript.goldRockChanceIncrease;

                ReduceBars();
                goldChunk_1_purchased = true;
                goldChunk_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = goldChunk_1_purchaseCount;
            }
        }
        #endregion

        #region goldChunk_2
        else if (upgradeName == "goldChunk_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= goldChunk_2_price)
            {
                goldRockChance += LocalizationScript.goldRockChanceIncrease;

                ReduceBars();
                goldChunk_2_purchased = true;
                goldChunk_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = goldChunk_2_purchaseCount;
            }
        }
        #endregion

        #region goldChunk_3
        else if (upgradeName == "goldChunk_3")
        {
            if (GoldAndOreMechanics.totalGoldBars >= goldChunk_3_price)
            {
                goldRockChance += LocalizationScript.goldRockChanceIncrease;

                ReduceBars();
                goldChunk_3_purchased = true;
                goldChunk_3_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = goldChunk_3_purchaseCount;
            }
        }
        #endregion

        #region goldChunk_4
        else if (upgradeName == "goldChunk_4")
        {
            if (GoldAndOreMechanics.totalGoldBars >= goldChunk_4_price)
            {
                goldRockChance += LocalizationScript.goldRockChanceIncrease;

                ReduceBars();
                goldChunk_4_purchased = true;
                goldChunk_4_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = goldChunk_4_purchaseCount;
            }
        }
        #endregion

        #region goldChunk_5
        else if (upgradeName == "goldChunk_5_")
        {
            if (GoldAndOreMechanics.totalGoldBars >= goldChunk_5__price)
            {
                goldRockChance += LocalizationScript.goldRockChanceIncrease;

                ReduceBars();
                goldChunk_5_purchased = true;
                goldChunk_5_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = goldChunk_5_purchaseCount;
            }
        }
        #endregion

        #region fullGold_1
        else if (upgradeName == "fullGold_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= fullGold_1_price)
            {
                if (Tutorial.pressedOkAnvil == false) { tutorialScript.SetTutorial(3); }

                fullGoldRockChance += LocalizationScript.fullGoldRockChanceIncrease;

                ReduceBars();
                fullGold_1_purchased = true;
                fullGold_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = fullGold_1_purchaseCount;
            }
        }
        #endregion

        #region fullGold_2
        else if (upgradeName == "fullGold_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= fullGold_2_price)
            {
                fullGoldRockChance += LocalizationScript.fullGoldRockChanceIncrease;

                ReduceBars();
                fullGold_2_purchased = true;
                fullGold_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = fullGold_2_purchaseCount;
            }
        }
        #endregion

        #region fullGold_3
        else if (upgradeName == "fullGold_3")
        {
            if (GoldAndOreMechanics.totalGoldBars >= fullGold_3_price)
            {
                fullGoldRockChance += LocalizationScript.fullGoldRockChanceIncrease;

                ReduceBars();
                fullGold_3_purchased = true;
                fullGold_3_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = fullGold_3_purchaseCount;
            }
        }
        #endregion

        #endregion

        //Copper rocks
        #region All Copper rocks

        #region spawnCopper
        else if (upgradeName == "spawnCopper")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnCopper_price)
            {
                if (Tutorial.pressedOkMine == false) { tutorialScript.SetTutorial(4); }

                ReduceBars();
                spawnCopper_purchased = true;
                spawnCopper_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnCopper_purchaseCount;
                totalMaterialRocksSpawning += 1;
            }
        }
        #endregion

        #region copperChunk_1
        else if (upgradeName == "copperChunk_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= copperChunk_1_price)
            {
                copperRockChance += LocalizationScript.copperRockChanceIncrease;

                ReduceBars();
                copperChunk_1_purchased = true;
                copperChunk_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = copperChunk_1_purchaseCount;
            }
        }
        #endregion

        #region copperChunk_2
        else if (upgradeName == "copperChunk_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= copperChunk_2_price)
            {
                copperRockChance += LocalizationScript.copperRockChanceIncrease;

                ReduceBars();
                copperChunk_2_purchased = true;
                copperChunk_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = copperChunk_2_purchaseCount;
            }
        }
        #endregion

        #region copperChunk_3
        else if (upgradeName == "copperChunk_3")
        {
            if (GoldAndOreMechanics.totalGoldBars >= copperChunk_3_price)
            {
                copperRockChance += LocalizationScript.copperRockChanceIncrease;

                ReduceBars();
                copperChunk_3_purchased = true;
                copperChunk_3_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = copperChunk_3_purchaseCount;
            }
        }
        #endregion

        #region fullCopper_1
        else if (upgradeName == "fullCopper_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= fullCopper_1_price)
            {
                fullCopperRockChance += LocalizationScript.fullCopperRockChanceIncrease;

                ReduceBars();
                fullCopper_1_purchased = true;
                fullCopper_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = fullCopper_1_purchaseCount;
            }
        }
        #endregion

        #region fullCopper_2
        else if (upgradeName == "fullCopper_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= fullCopper_2_price)
            {
                fullCopperRockChance += LocalizationScript.fullCopperRockChanceIncrease;

                ReduceBars();
                fullCopper_2_purchased = true;
                fullCopper_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = fullCopper_2_purchaseCount;
            }
        }
        #endregion

        #region fullCopper_3
        else if (upgradeName == "fullCopper_3")
        {
            if (GoldAndOreMechanics.totalGoldBars >= fullCopper_3_price)
            {
                fullCopperRockChance += LocalizationScript.fullCopperRockChanceIncrease;

                ReduceBars();
                fullCopper_3_purchased = true;
                fullCopper_3_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = fullCopper_3_purchaseCount;
            }
        }
        #endregion

        #endregion

        //Iron rocks
        #region All Iron rocks

        #region spawnIron
        else if (upgradeName == "spawnIron")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnIron_price)
            {
                ReduceBars();
                spawnIron_purchased = true;
                spawnIron_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnIron_purchaseCount;
                totalMaterialRocksSpawning += 1;
            }
        }
        #endregion

        #region ironChunk_1
        else if (upgradeName == "ironChunk_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= ironChunk_1_price)
            {
                ironRockChance += LocalizationScript.ironRockChanceIncrease;

                ReduceBars();
                ironChunk_1_purchased = true;
                ironChunk_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = ironChunk_1_purchaseCount;
            }
        }
        #endregion

        #region ironChunk_2
        else if (upgradeName == "ironChunk_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= ironChunk_2_price)
            {
                ironRockChance += LocalizationScript.ironRockChanceIncrease;

                ReduceBars();
                ironChunk_2_purchased = true;
                ironChunk_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = ironChunk_2_purchaseCount;
            }
        }
        #endregion

        #region fullIron_1
        else if (upgradeName == "fullIron_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= fullIron_1_price)
            {
                fullIronRockChance += LocalizationScript.fullIronRockChanceIncrease;

                ReduceBars();
                fullIron_1_purchased = true;
                fullIron_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = fullIron_1_purchaseCount;
            }
        }
        #endregion

        #region fullIron_2
        else if (upgradeName == "fullIron_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= fullIron_2_price)
            {
                fullIronRockChance += LocalizationScript.fullIronRockChanceIncrease;

                ReduceBars();
                fullIron_2_purchased = true;
                fullIron_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = fullIron_2_purchaseCount;
            }
        }
        #endregion

        #endregion

        //All cobalt
        #region All Cobalt rocks

        #region cobaltSpawn
        else if (upgradeName == "cobaltSpawn")
        {
            if (GoldAndOreMechanics.totalGoldBars >= cobaltSpawn_price)
            {
                ReduceBars();
                cobaltSpawn_purchased = true;
                cobaltSpawn_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = cobaltSpawn_purchaseCount;

                totalMaterialRocksSpawning += 1;
            }
        }
        #endregion

        #region cobaltChunk_1
        else if (upgradeName == "cobaltChunk_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= cobaltChunk_1_price)
            {
                cobaltRockChance += LocalizationScript.cobaltRockChanceIncrease;

                ReduceBars();
                cobaltChunk_1_purchased = true;
                cobaltChunk_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = cobaltChunk_1_purchaseCount;
            }
        }
        #endregion

        #region fullCobalt_1
        else if (upgradeName == "fullCobalt_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= fullCobalt_1_price)
            {
                fullCobaltRockChance += LocalizationScript.fullCobaltRockChanceIncrease;

                ReduceBars();
                fullCobalt_1_purchased = true;
                fullCobalt_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = fullCobalt_1_purchaseCount;
            }
        }
        #endregion

        #endregion

        //All Uranium
        #region All Uranium rocks

        #region uraniumSpawn
        else if (upgradeName == "uraniumSpawn")
        {
            if (GoldAndOreMechanics.totalGoldBars >= uraniumSpawn_price)
            {
                ReduceBars();
                uraniumSpawn_purchased = true;
                uraniumSpawn_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = uraniumSpawn_purchaseCount;

                totalMaterialRocksSpawning += 1;
            }
        }
        #endregion

        #region uraniumChunk_1
        else if (upgradeName == "uraniumChunk_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= uraniumChunk_1_price)
            {
                uraniumRockChance += LocalizationScript.uraniumRockChanceIncrease;

                ReduceBars();
                uraniumChunk_1_purchased = true;
                uraniumChunk_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = uraniumChunk_1_purchaseCount;
            }
        }
        #endregion

        #region fullUranium_1
        else if (upgradeName == "fullUranium_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= fullUranium_1_price)
            {
                fullUraniumRockChance += LocalizationScript.fullUraniumRockChanceIncrease;

                ReduceBars();
                fullUranium_1_purchased = true;
                fullUranium_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = fullUranium_1_purchaseCount;
            }
        }
        #endregion

        #endregion

        //All Ismium
        #region All Ismium rocks

        #region ismiumSpawn
        else if (upgradeName == "ismiumSpawn")
        {
            if (GoldAndOreMechanics.totalGoldBars >= ismiumSpawn_price)
            {
                ReduceBars();
                ismiumSpawn_purchased = true;
                ismiumSpawn_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = ismiumSpawn_purchaseCount;

                totalMaterialRocksSpawning += 1;
            }
        }
        #endregion

        #region ismiumChunk_1
        else if (upgradeName == "ismiumChunk_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= ismiumChunk_1_price)
            {
                ismiumRockChance += LocalizationScript.ismiumRockChanceIncrease;

                ReduceBars();
                ismiumChunk_1_purchased = true;
                ismiumChunk_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = ismiumChunk_1_purchaseCount;
            }
        }
        #endregion

        #region fullIsmium_1
        else if (upgradeName == "fullIsmium_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= fullIsmium_1_price)
            {
                fullIsmiumRockChance += LocalizationScript.fullIsmiumRockChanceIncrease;

                ReduceBars();
                fullIsmium_1_purchased = true;
                fullIsmium_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = fullIsmium_1_purchaseCount;
            }
        }
        #endregion

        #endregion

        //All Iridium
        #region All Iridium rocks

        #region iridiumSpawn
        else if (upgradeName == "iridiumSpawn")
        {
            if (GoldAndOreMechanics.totalGoldBars >= iridiumSpawn_price)
            {
                ReduceBars();
                iridiumSpawn_purchased = true;
                iridiumSpawn_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = iridiumSpawn_purchaseCount;

                totalMaterialRocksSpawning += 1;
            }
        }
        #endregion

        #region iridiumChunk_1
        else if (upgradeName == "iridiumChunk_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= iridiumChunk_1_price)
            {
                iridiumRockChance += LocalizationScript.iridiumRockChanceIncrease;

                ReduceBars();
                iridiumChunk_1_purchased = true;
                iridiumChunk_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = iridiumChunk_1_purchaseCount;
            }
        }
        #endregion

        #region fullIridium_1
        else if (upgradeName == "fullIridium_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= fullIridium_1_price)
            {
                fullIridiumRockChance += LocalizationScript.fullIridiumRockChanceIncrease;

                ReduceBars();
                fullIridium_1_purchased = true;
                fullIridium_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = fullIridium_1_purchaseCount;
            }
        }
        #endregion

        #endregion

        //All Painite
        #region All Painite rocks

        #region painiteSpawn
        else if (upgradeName == "painiteSpawn")
        {
            if (GoldAndOreMechanics.totalGoldBars >= painiteSpawn_price)
            {
                ReduceBars();
                painiteSpawn_purchased = true;
                painiteSpawn_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = painiteSpawn_purchaseCount;

                totalMaterialRocksSpawning += 1;
            }
        }
        #endregion

        #region painiteChunk_1
        else if (upgradeName == "painiteChunk_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= painiteChunk_1_price)
            {
                painiteRockChance += LocalizationScript.painiteRockChanceIncrease;

                ReduceBars();
                painiteChunk_1_purchased = true;
                painiteChunk_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = painiteChunk_1_purchaseCount;
            }
        }
        #endregion

        #region fullPainite_1
        else if (upgradeName == "fullPainite_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= fullPainite_1_price)
            {
                fullPainiteRockChance += LocalizationScript.fullPainiteRockChanceIncrease;

                ReduceBars();
                fullPainite_1_purchased = true;
                fullPainite_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = fullPainite_1_purchaseCount;
            }
        }
        #endregion

        #endregion

        //XP
        #region All XP

        #region moreXP_1
        else if (upgradeName == "MoreXP1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= moreXP_1_price)
            {
                LevelMechanics.xpFromRock += LocalizationScript.xpIncrease;

                ReduceBars();
                moreXP_1_purchased = true;
                moreXP_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = moreXP_1_purchaseCount;
            }
        }
        #endregion

        #region moreXP_2
        else if (upgradeName == "MoreXP2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= moreXP_2_price)
            {
                LevelMechanics.xpFromRock += LocalizationScript.xpIncrease;

                ReduceBars();
                moreXP_2_purchased = true;
                moreXP_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = moreXP_2_purchaseCount;
            }
        }
        #endregion

        #region moreXP_3
        else if (upgradeName == "MoreXP3")
        {
            if (GoldAndOreMechanics.totalGoldBars >= moreXP_3_price)
            {
                LevelMechanics.xpFromRock += LocalizationScript.xpIncrease;

                ReduceBars();
                moreXP_3_purchased = true;
                moreXP_3_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = moreXP_3_purchaseCount;
            }
        }
        #endregion

        #region moreXP_4
        else if (upgradeName == "MoreXP4")
        {
            if (GoldAndOreMechanics.totalGoldBars >= moreXP_4_price)
            {
                LevelMechanics.xpFromRock += LocalizationScript.xpIncrease;

                ReduceBars();
                moreXP_4_purchased = true;
                moreXP_4_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = moreXP_4_purchaseCount;
            }
        }
        #endregion

        #region moreXP_5
        else if (upgradeName == "MoreXP5")
        {
            if (GoldAndOreMechanics.totalGoldBars >= moreXP_5_price)
            {
                LevelMechanics.xpFromRock += LocalizationScript.xpIncrease;

                ReduceBars();
                moreXP_5_purchased = true;
                moreXP_5_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = moreXP_5_purchaseCount;
            }
        }
        #endregion

        #region moreXP_6
        else if (upgradeName == "MoreXP6")
        {
            if (GoldAndOreMechanics.totalGoldBars >= moreXP_6_price)
            {
                LevelMechanics.xpFromRock += LocalizationScript.xpIncrease;

                ReduceBars();
                moreXP_6_purchased = true;
                moreXP_6_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = moreXP_6_purchaseCount;
            }
        }
        #endregion

        #region moreXP_7
        else if (upgradeName == "MoreXP7")
        {
            if (GoldAndOreMechanics.totalGoldBars >= moreXP_7_price)
            {
                LevelMechanics.xpFromRock += LocalizationScript.xpIncrease;

                ReduceBars();
                moreXP_7_purchased = true;
                moreXP_7_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = moreXP_7_purchaseCount;
            }
        }
        #endregion

        #region moreXP_8
        else if (upgradeName == "MoreXP8")
        {
            if (GoldAndOreMechanics.totalGoldBars >= moreXP_8_price)
            {
                LevelMechanics.xpFromRock += LocalizationScript.xpIncrease;

                ReduceBars();
                moreXP_8_purchased = true;
                moreXP_8_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = moreXP_8_purchaseCount;
            }
        }
        #endregion

        #region talentPointsPerXlevel_1
        else if (upgradeName == "TalentPointsPerXLevel1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= talentPointsPerXlevel_1_price)
            {
                extraTalentPointPerLevel -= LocalizationScript.moreTalentPointsReduce;

                ReduceBars();
                talentPointsPerXlevel_1_purchased = true;
                talentPointsPerXlevel_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = talentPointsPerXlevel_1_purchaseCount;
            }
        }
        #endregion

        #region talentPointsPerXlevel_2
        else if (upgradeName == "TalentPointsPerXLevel2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= talentPointsPerXlevel_2_price)
            {
                extraTalentPointPerLevel -= LocalizationScript.moreTalentPointsReduce;

                ReduceBars();
                talentPointsPerXlevel_2_purchased = true;
                talentPointsPerXlevel_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = talentPointsPerXlevel_2_purchaseCount;
            }
        }
        #endregion

        #region talentPointsPerXlevel_3
        else if (upgradeName == "TalentPointsPerXLevel3")
        {
            if (GoldAndOreMechanics.totalGoldBars >= talentPointsPerXlevel_3_price)
            {
                extraTalentPointPerLevel -= LocalizationScript.moreTalentPointsReduce;

                ReduceBars();
                talentPointsPerXlevel_3_purchased = true;
                talentPointsPerXlevel_3_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = talentPointsPerXlevel_3_purchaseCount;
            }
        }
        #endregion

        #endregion

        //Improved pickaxes
        #region All improved pickaxe

        #region improvedPickaxe_1
        else if (upgradeName == "improvedPickaxe_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= improvedPickaxe_1_price)
            {
                if (Tutorial.pressedOkAnvil == false) { tutorialScript.SetTutorial(3); }

                improvedPickaxeStrength += LocalizationScript.improvedPickaxeIncrease;
                reducePickaxeMineTime += LocalizationScript.improvedPickaxeIncrease;

                ReduceBars();
                improvedPickaxe_1_purchased = true;
                improvedPickaxe_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = improvedPickaxe_1_purchaseCount;
            }
        }
        #endregion

        #region improvedPickaxe_2
        else if (upgradeName == "improvedPickaxe_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= improvedPickaxe_2_price)
            {
                improvedPickaxeStrength += LocalizationScript.improvedPickaxeIncrease;
                reducePickaxeMineTime += LocalizationScript.improvedPickaxeIncrease;

                ReduceBars();
                improvedPickaxe_2_purchased = true;
                improvedPickaxe_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = improvedPickaxe_2_purchaseCount;
            }
        }
        #endregion

        #region improvedPickaxe_3
        else if (upgradeName == "improvedPickaxe_3")
        {
            if (GoldAndOreMechanics.totalGoldBars >= improvedPickaxe_3_price)
            {
                improvedPickaxeStrength += LocalizationScript.improvedPickaxeIncrease;
                reducePickaxeMineTime += LocalizationScript.improvedPickaxeIncrease;

                ReduceBars();
                improvedPickaxe_3_purchased = true;
                improvedPickaxe_3_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = improvedPickaxe_3_purchaseCount;
            }
        }
        #endregion

        #region improvedPickaxe_4
        else if (upgradeName == "improvedPickaxe_4")
        {
            if (GoldAndOreMechanics.totalGoldBars >= improvedPickaxe_4_price)
            {
                improvedPickaxeStrength += LocalizationScript.improvedPickaxeIncrease;
                reducePickaxeMineTime += LocalizationScript.improvedPickaxeIncrease;

                ReduceBars();
                improvedPickaxe_4_purchased = true;
                improvedPickaxe_4_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = improvedPickaxe_4_purchaseCount;
            }
        }
        #endregion

        #region improvedPickaxe_5
        else if (upgradeName == "improvedPickaxe_5")
        {
            if (GoldAndOreMechanics.totalGoldBars >= improvedPickaxe_5_price)
            {
                improvedPickaxeStrength += LocalizationScript.improvedPickaxeIncrease;
                reducePickaxeMineTime += LocalizationScript.improvedPickaxeIncrease;

                ReduceBars();
                improvedPickaxe_5_purchased = true;
                improvedPickaxe_5_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = improvedPickaxe_5_purchaseCount;
            }
        }
        #endregion

        #region improvedPickaxe_6
        else if (upgradeName == "improvedPickaxe_6")
        {
            if (GoldAndOreMechanics.totalGoldBars >= improvedPickaxe_6_price)
            {
                improvedPickaxeStrength += LocalizationScript.improvedPickaxeIncrease;
                reducePickaxeMineTime += LocalizationScript.improvedPickaxeIncrease;

                ReduceBars();
                improvedPickaxe_6_purchased = true;
                improvedPickaxe_6_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = improvedPickaxe_6_purchaseCount;
            }
        }
        #endregion

        #endregion

        //Bigger mining erea
        #region All bigger mining erea

        #region biggerMiningErea_1
        else if (upgradeName == "biggerMiningErea_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= biggerMiningErea_1_price)
            {
                miningAreaSize += LocalizationScript.miningAreaIncrease;

                ReduceBars();
                biggerMiningErea_1_purchased = true;
                biggerMiningErea_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = biggerMiningErea_1_purchaseCount;
            }
        }
        #endregion

        #region biggerMiningErea_2
        else if (upgradeName == "biggerMiningErea_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= biggerMiningErea_2_price)
            {
                miningAreaSize += LocalizationScript.miningAreaIncrease;

                ReduceBars();
                biggerMiningErea_2_purchased = true;
                biggerMiningErea_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = biggerMiningErea_2_purchaseCount;
            }
        }
        #endregion

        #region biggerMiningErea_3
        else if (upgradeName == "biggerMiningErea_3")
        {
            if (GoldAndOreMechanics.totalGoldBars >= biggerMiningErea_3_price)
            {
                miningAreaSize += LocalizationScript.miningAreaIncrease;

                ReduceBars();
                biggerMiningErea_3_purchased = true;
                biggerMiningErea_3_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = biggerMiningErea_3_purchaseCount;
            }
        }
        #endregion

        #region biggerMiningErea_4
        else if (upgradeName == "biggerMiningErea_4")
        {
            if (GoldAndOreMechanics.totalGoldBars >= biggerMiningErea_4_price)
            {
                miningAreaSize += LocalizationScript.miningAreaIncrease;

                ReduceBars();
                biggerMiningErea_4_purchased = true;
                biggerMiningErea_4_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = biggerMiningErea_4_purchaseCount;
            }
        }
        #endregion

        #region shootCircleChance
        else if (upgradeName == "shootCircleChance")
        {
            if (GoldAndOreMechanics.totalGoldBars >= shootCircleChance_price)
            {
                ReduceBars();
                shootCircleChance_purchased = true;
                shootCircleChance_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = shootCircleChance_purchaseCount;
            }
        }
        #endregion

        #region increaseAndDecreaseMinignErea
        else if (upgradeName == "increaseAndDecreaseMinignErea")
        {
            if (GoldAndOreMechanics.totalGoldBars >= increaseAndDecreaseMinignErea_price)
            {
                ReduceBars();
                increaseAndDecreaseMinignErea_purchased = true;
                increaseAndDecreaseMinignErea_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = increaseAndDecreaseMinignErea_purchaseCount;
            }
        }
        #endregion

        #endregion

        //Spawn X rock every X
        #region All spawn X rock every X 

        #region spawnRockEveryXrock_1
        else if (upgradeName == "spawnRockEveryXrock_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnRockEveryXrock_1_price)
            {
                spawnRockEveryXRock -= LocalizationScript.spawnEveryRockIncrease;

                ReduceBars();
                spawnRockEveryXrock_1_purchased = true;
                spawnRockEveryXrock_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnRockEveryXrock_1_purchaseCount;
            }
        }
        #endregion

        #region spawnRockEveryXrock_2
        else if (upgradeName == "spawnRockEveryXrock_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnRockEveryXrock_2_price)
            {
                spawnRockEveryXRock -= LocalizationScript.spawnEveryRockIncrease;

                ReduceBars();
                spawnRockEveryXrock_2_purchased = true;
                spawnRockEveryXrock_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnRockEveryXrock_2_purchaseCount;
            }
        }
        #endregion

        #region spawnRockEveryXrock_3
        else if (upgradeName == "spawnRockEveryXrock_3")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnRockEveryXrock_3_price)
            {
                spawnRockEveryXRock -= LocalizationScript.spawnEveryRockIncrease;

                ReduceBars();
                spawnRockEveryXrock_3_purchased = true;
                spawnRockEveryXrock_3_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnRockEveryXrock_3_purchaseCount;
            }
        }
        #endregion

        #region spawnXRockEveryXSecond_1
        else if (upgradeName == "spawnXRockEveryXSecond_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnXRockEveryXSecond_1_price)
            {
                spawnXRockEveryXSecond -= LocalizationScript.spawnEverySecondIncrease;

                ReduceBars();
                spawnXRockEveryXSecond_1_purchased = true;
                spawnXRockEveryXSecond_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnXRockEveryXSecond_1_purchaseCount;
            }
        }
        #endregion

        #region spawnXRockEveryXSecond_2
        else if (upgradeName == "spawnXRockEveryXSecond_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnXRockEveryXSecond_2_price)
            {
                spawnXRockEveryXSecond -= LocalizationScript.spawnEverySecondIncrease;

                ReduceBars();
                spawnXRockEveryXSecond_2_purchased = true;
                spawnXRockEveryXSecond_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnXRockEveryXSecond_2_purchaseCount;
            }
        }
        #endregion

        #region spawnXRockEveryXSecond_3
        else if (upgradeName == "spawnXRockEveryXSecond_3")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnXRockEveryXSecond_3_price)
            {
                spawnXRockEveryXSecond -= LocalizationScript.spawnEverySecondIncrease;

                ReduceBars();
                spawnXRockEveryXSecond_3_purchased = true;
                spawnXRockEveryXSecond_3_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnXRockEveryXSecond_3_purchaseCount;
            }
        }
        #endregion

        #region chanceToSpawnRockWhenMined_1
        else if (upgradeName == "chanceToSpawnRockWhenMined_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= chanceToSpawnRockWhenMined_1_price)
            {
                chanceToSpawnRockWhenMined += LocalizationScript.spawnWhenMinedIncrease;

                ReduceBars();
                chanceToSpawnRockWhenMined_1_purchased = true;
                chanceToSpawnRockWhenMined_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = chanceToSpawnRockWhenMined_1_purchaseCount;
            }
        }
        #endregion

        #region chanceToSpawnRockWhenMined_2
        else if (upgradeName == "chanceToSpawnRockWhenMined_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= chanceToSpawnRockWhenMined_2_price)
            {
                chanceToSpawnRockWhenMined += LocalizationScript.spawnWhenMinedIncrease;

                ReduceBars();
                chanceToSpawnRockWhenMined_2_purchased = true;
                chanceToSpawnRockWhenMined_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = chanceToSpawnRockWhenMined_2_purchaseCount;
            }
        }
        #endregion

        #region chanceToSpawnRockWhenMined_3
        else if (upgradeName == "chanceToSpawnRockWhenMined_3")
        {
            if (GoldAndOreMechanics.totalGoldBars >= chanceToSpawnRockWhenMined_3_price)
            {
                chanceToSpawnRockWhenMined += LocalizationScript.spawnWhenMinedIncrease;

                ReduceBars();
                chanceToSpawnRockWhenMined_3_purchased = true;
                chanceToSpawnRockWhenMined_3_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = chanceToSpawnRockWhenMined_3_purchaseCount;
            }
        }
        #endregion

        #region chanceToSpawnRockWhenMined_4
        else if (upgradeName == "chanceToSpawnRockWhenMined_4")
        {
            if (GoldAndOreMechanics.totalGoldBars >= chanceToSpawnRockWhenMined_4_price)
            {
                chanceToSpawnRockWhenMined += LocalizationScript.spawnWhenMinedIncrease;

                ReduceBars();
                chanceToSpawnRockWhenMined_4_purchased = true;
                chanceToSpawnRockWhenMined_4_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = chanceToSpawnRockWhenMined_4_purchaseCount;
            }
        }
        #endregion

        #region chanceToSpawnRockWhenMined_5
        else if (upgradeName == "chanceToSpawnRockWhenMined_5")
        {
            if (GoldAndOreMechanics.totalGoldBars >= chanceToSpawnRockWhenMined_5_price)
            {
                chanceToSpawnRockWhenMined += LocalizationScript.spawnWhenMinedIncrease;

                ReduceBars();
                chanceToSpawnRockWhenMined_5_purchased = true;
                chanceToSpawnRockWhenMined_5_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = chanceToSpawnRockWhenMined_5_purchaseCount;
            }
        }
        #endregion

        #region chanceToSpawnRockWhenMined_6
        else if (upgradeName == "chanceToSpawnRockWhenMined_6")
        {
            if (GoldAndOreMechanics.totalGoldBars >= chanceToSpawnRockWhenMined_6_price)
            {
                chanceToSpawnRockWhenMined += LocalizationScript.spawnWhenMinedIncrease;

                ReduceBars();
                chanceToSpawnRockWhenMined_6_purchased = true;
                chanceToSpawnRockWhenMined_6_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = chanceToSpawnRockWhenMined_6_purchaseCount;
            }
        }
        #endregion

        #endregion

        //Spawn pickaxes
        #region All spawn pickaxes

        #region chanceToMineRandomRock_1
        else if (upgradeName == "chanceToMineRandomRock_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= chanceToMineRandomRock_1_price)
            {
                chanceToMineRandomRock += LocalizationScript.chanceToMineRandomRockIncrease;

                ReduceBars();
                chanceToMineRandomRock_1_purchased = true;
                chanceToMineRandomRock_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = chanceToMineRandomRock_1_purchaseCount;
            }
        }
        #endregion

        #region chanceToMineRandomRock_2
        else if (upgradeName == "chanceToMineRandomRock_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= chanceToMineRandomRock_2_price)
            {
                chanceToMineRandomRock += LocalizationScript.chanceToMineRandomRockIncrease;

                ReduceBars();
                chanceToMineRandomRock_2_purchased = true;
                chanceToMineRandomRock_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = chanceToMineRandomRock_2_purchaseCount;
            }
        }
        #endregion

        #region chanceToMineRandomRock_3
        else if (upgradeName == "chanceToMineRandomRock_3")
        {
            if (GoldAndOreMechanics.totalGoldBars >= chanceToMineRandomRock_3_price)
            {
                chanceToMineRandomRock += LocalizationScript.chanceToMineRandomRockIncrease;

                ReduceBars();
                chanceToMineRandomRock_3_purchased = true;
                chanceToMineRandomRock_3_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = chanceToMineRandomRock_3_purchaseCount;
            }
        }
        #endregion

        #region chanceToMineRandomRock_4
        else if (upgradeName == "chanceToMineRandomRock_4")
        {
            if (GoldAndOreMechanics.totalGoldBars >= chanceToMineRandomRock_4_price)
            {
                chanceToMineRandomRock += LocalizationScript.chanceToMineRandomRockIncrease;

                ReduceBars();
                chanceToMineRandomRock_4_purchased = true;
                chanceToMineRandomRock_4_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = chanceToMineRandomRock_4_purchaseCount;
            }
        }
        #endregion

        #region spawnPickaxeEverySecond_1
        else if (upgradeName == "spawnPickaxeEverySecond_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnPickaxeEverySecond_1_price)
            {
                spawnPickaxeEverySecond -= LocalizationScript.spawnPickaxeEverySecondIncrease;

                ReduceBars();
                spawnPickaxeEverySecond_1_purchased = true;
                spawnPickaxeEverySecond_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnPickaxeEverySecond_1_purchaseCount;
            }
        }
        #endregion

        #region spawnPickaxeEverySecond_2
        else if (upgradeName == "spawnPickaxeEverySecond_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnPickaxeEverySecond_2_price)
            {
                spawnPickaxeEverySecond -= LocalizationScript.spawnPickaxeEverySecondIncrease;

                ReduceBars();
                spawnPickaxeEverySecond_2_purchased = true;
                spawnPickaxeEverySecond_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnPickaxeEverySecond_2_purchaseCount;
            }
        }
        #endregion

        #region spawnPickaxeEverySecond_3
        else if (upgradeName == "spawnPickaxeEverySecond_3")
        {
            if (GoldAndOreMechanics.totalGoldBars >= spawnPickaxeEverySecond_3_price)
            {
                spawnPickaxeEverySecond -= LocalizationScript.spawnPickaxeEverySecondIncrease;

                ReduceBars();
                spawnPickaxeEverySecond_3_purchased = true;
                spawnPickaxeEverySecond_3_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = spawnPickaxeEverySecond_3_purchaseCount;
            }
        }
        #endregion

        #endregion

        //More time
        #region All more time

        #region moreTime_1
        else if (upgradeName == "moreTime_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= moreTime_1_price)
            {
                mineSessionTime += LocalizationScript.moreTimeIncrease;

                ReduceBars();
                moreTime_1_purchased = true;
                moreTime_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = moreTime_1_purchaseCount;
            }
        }
        #endregion

        #region moreTime_2
        else if (upgradeName == "moreTime_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= moreTime_2_price)
            {
                mineSessionTime += LocalizationScript.moreTimeIncrease;

                ReduceBars();
                moreTime_2_purchased = true;
                moreTime_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = moreTime_2_purchaseCount;
            }
        }
        #endregion

        #region moreTime_3
        else if (upgradeName == "moreTime_3")
        {
            if (GoldAndOreMechanics.totalGoldBars >= moreTime_3_price)
            {
                mineSessionTime += LocalizationScript.moreTimeIncrease;

                ReduceBars();
                moreTime_3_purchased = true;
                moreTime_3_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = moreTime_3_purchaseCount;
            }
        }
        #endregion

        #region moreTime_4
        else if (upgradeName == "moreTime_4")
        {
            if (GoldAndOreMechanics.totalGoldBars >= moreTime_4_price)
            {
                mineSessionTime += LocalizationScript.moreTimeIncrease;

                ReduceBars();
                moreTime_4_purchased = true;
                moreTime_4_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = moreTime_4_purchaseCount;
            }
        }
        #endregion

        #region chanceToAdd1SecondEverySecond
        else if (upgradeName == "chanceToAdd1SecondEverySecond")
        {
            if (GoldAndOreMechanics.totalGoldBars >= chanceToAdd1SecondEverySecond_price)
            {
                ReduceBars();
                chanceToAdd1SecondEverySecond_purchased = true;
                chanceToAdd1SecondEverySecond_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = chanceToAdd1SecondEverySecond_purchaseCount;
            }
        }
        #endregion

        #region chanceAdd1SecondEveryRockMined
        else if (upgradeName == "chanceAdd1SecondEveryRockMined")
        {
            if (GoldAndOreMechanics.totalGoldBars >= chanceAdd1SecondEveryRockMined_price)
            {
                ReduceBars();
                chanceAdd1SecondEveryRockMined_purchased = true;
                chanceAdd1SecondEveryRockMined_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = chanceAdd1SecondEveryRockMined_purchaseCount;
            }
        }
        #endregion

        #endregion

        //Double XP and material chance
        #region All double XP and material chance

        #region doubleXpGoldChance_1
        else if (upgradeName == "doubleXpGoldChance_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= doubleXpGoldChance_1_price)
            {
                doubleXpAndGoldChance += LocalizationScript.doubleXpAndGoldChanceIncrease;

                ReduceBars();
                doubleXpGoldChance_1_purchased = true;
                doubleXpGoldChance_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = doubleXpGoldChance_1_purchaseCount;
            }
        }
        #endregion

        #region doubleXpGoldChance_2
        else if (upgradeName == "doubleXpGoldChance_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= doubleXpGoldChance_2_price)
            {
                doubleXpAndGoldChance += LocalizationScript.doubleXpAndGoldChanceIncrease;

                ReduceBars();
                doubleXpGoldChance_2_purchased = true;
                doubleXpGoldChance_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = doubleXpGoldChance_2_purchaseCount;
            }
        }
        #endregion

        #region doubleXpGoldChance_3
        else if (upgradeName == "doubleXpGoldChance_3")
        {
            if (GoldAndOreMechanics.totalGoldBars >= doubleXpGoldChance_3_price)
            {
                doubleXpAndGoldChance += LocalizationScript.doubleXpAndGoldChanceIncrease;

                ReduceBars();
                doubleXpGoldChance_3_purchased = true;
                doubleXpGoldChance_3_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = doubleXpGoldChance_3_purchaseCount;
            }
        }
        #endregion

        #region doubleXpGoldChance_4
        else if (upgradeName == "doubleXpGoldChance_4")
        {
            if (GoldAndOreMechanics.totalGoldBars >= doubleXpGoldChance_4_price)
            {
                doubleXpAndGoldChance += LocalizationScript.doubleXpAndGoldChanceIncrease;

                ReduceBars();
                doubleXpGoldChance_4_purchased = true;
                doubleXpGoldChance_4_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = doubleXpGoldChance_4_purchaseCount;
            }
        }
        #endregion

        #region doubleXpGoldChance_5
        else if (upgradeName == "doubleXpGoldChance_5")
        {
            if (GoldAndOreMechanics.totalGoldBars >= doubleXpGoldChance_5_price)
            {
                doubleXpAndGoldChance += LocalizationScript.doubleXpAndGoldChanceIncrease;

                ReduceBars();
                doubleXpGoldChance_5_purchased = true;
                doubleXpGoldChance_5_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = doubleXpGoldChance_5_purchaseCount;
            }
        }
        #endregion

        #endregion

        //Lightning beam
        #region All lightning beam

        #region lightningBeamChanceS_1
        else if (upgradeName == "lightningBeamChanceS_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= lightningBeamChanceS_1_price)
            {
                lightningTriggerChanceS += LocalizationScript.lightningTriggerChanceS_Increase;

                ReduceBars();
                lightningBeamChanceS_1_purchased = true;
                lightningBeamChanceS_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = lightningBeamChanceS_1_purchaseCount;
            }
        }
        #endregion

        #region lightningBeamChanceS_2
        else if (upgradeName == "lightningBeamChanceS_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= lightningBeamChanceS_2_price)
            {
                lightningTriggerChanceS += LocalizationScript.lightningTriggerChanceS_Increase;

                ReduceBars();
                lightningBeamChanceS_2_purchased = true;
                lightningBeamChanceS_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = lightningBeamChanceS_2_purchaseCount;
            }
        }
        #endregion

        #region lightningBeamChancePH_1
        else if (upgradeName == "lightningBeamChancePH_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= lightningBeamChancePH_1_price)
            {
                lightningTriggerChancePH += LocalizationScript.lightningTriggerChancePH_Increase;

                ReduceBars();
                lightningBeamChancePH_1_purchased = true;
                lightningBeamChancePH_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = lightningBeamChancePH_1_purchaseCount;
            }
        }
        #endregion

        #region lightningBeamChancePH_2
        else if (upgradeName == "lightningBeamChancePH_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= lightningBeamChancePH_2_price)
            {
                lightningTriggerChancePH += LocalizationScript.lightningTriggerChancePH_Increase;

                ReduceBars();
                lightningBeamChancePH_2_purchased = true;
                lightningBeamChancePH_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = lightningBeamChancePH_2_purchaseCount;
            }
        }
        #endregion

        #region lightningBeamSpawnAnotherOneChance
        else if (upgradeName == "lightningBeamSpawnAnotherOneChance")
        {
            if (GoldAndOreMechanics.totalGoldBars >= lightningBeamSpawnAnotherOneChance_price)
            {
                ReduceBars();
                lightningBeamSpawnAnotherOneChance_purchased = true;
                lightningBeamSpawnAnotherOneChance_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = lightningBeamSpawnAnotherOneChance_purchaseCount;
            }
        }
        #endregion

        #region lightningBeamDamage
        else if (upgradeName == "lightningBeamDamage")
        {
            if (GoldAndOreMechanics.totalGoldBars >= lightningBeamDamage_price)
            {
                lightningDamage += LocalizationScript.lightningDamageIncrease;

                ReduceBars();
                lightningBeamDamage_purchased = true;
                lightningBeamDamage_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = lightningBeamDamage_purchaseCount;
            }
        }
        #endregion

        #region lightningBeamSize
        else if (upgradeName == "lightningBeamSize")
        {
            if (GoldAndOreMechanics.totalGoldBars >= lightningBeamSize_price)
            {
                lightningSize += LocalizationScript.lightningSizeIncrease;

                ReduceBars();
                lightningBeamSize_purchased = true;
                lightningBeamSize_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = lightningBeamSize_purchaseCount;
            }
        }
        #endregion

        #region lightningSplashes
        else if (upgradeName == "lightningSplashes")
        {
            if (GoldAndOreMechanics.totalGoldBars >= lightningSplashes_price)
            {
                ReduceBars();
                lightningSplashes_purchased = true;
                lightningSplashes_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = lightningSplashes_purchaseCount;
            }
        }
        #endregion

        #region lightningBeamSpawnRock
        else if (upgradeName == "lightningBeamSpawnRock")
        {
            if (GoldAndOreMechanics.totalGoldBars >= lightningBeamSpawnRock_price)
            {
                ReduceBars();
                lightningBeamSpawnRock_purchased = true;
                lightningBeamSpawnRock_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = lightningBeamSpawnRock_purchaseCount;
            }
        }
        #endregion

        #region lightningBeamExplosion
        else if (upgradeName == "lightningBeamExplosion")
        {
            if (GoldAndOreMechanics.totalGoldBars >= lightningBeamExplosion_price)
            {
                ReduceBars();
                lightningBeamExplosion_purchased = true;
                lightningBeamExplosion_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = lightningBeamExplosion_purchaseCount;
            }
        }
        #endregion

        #region lightningBeamAddTime
        else if (upgradeName == "lightningBeamAddTime")
        {
            if (GoldAndOreMechanics.totalGoldBars >= lightningBeamAddTime_price)
            {
                ReduceBars();
                lightningBeamAddTime_purchased = true;
                lightningBeamAddTime_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = lightningBeamAddTime_purchaseCount;
            }
        }
        #endregion

        #endregion

        //Dynamite
        #region All dynamite

        #region dynamiteChance_1
        else if (upgradeName == "dynamiteChance_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= dynamiteChance_1_price)
            {
                dynamiteStickChance += LocalizationScript.dynamiteStickChanceIncrease;

                ReduceBars();
                dynamiteChance_1_purchased = true;
                dynamiteChance_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = dynamiteChance_1_purchaseCount;
            }
        }
        #endregion

        #region dynamiteChance_2
        else if (upgradeName == "dynamiteChance_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= dynamiteChance_2_price)
            {
                dynamiteStickChance += LocalizationScript.dynamiteStickChanceIncrease;

                ReduceBars();
                dynamiteChance_2_purchased = true;
                dynamiteChance_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = dynamiteChance_2_purchaseCount;
            }
        }
        #endregion

        #region dynamiteSpawn2SmallChance
        else if (upgradeName == "dynamiteSpawn2SmallChance")
        {
            if (GoldAndOreMechanics.totalGoldBars >= dynamiteSpawn2SmallChance_price)
            {
                ReduceBars();
                dynamiteSpawn2SmallChance_purchased = true;
                dynamiteSpawn2SmallChance_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = dynamiteSpawn2SmallChance_purchaseCount;
            }
        }
        #endregion

        #region dynamiteExplosionSize
        else if (upgradeName == "dynamiteExplosionSize")
        {
            if (GoldAndOreMechanics.totalGoldBars >= dynamiteExplosionSize_price)
            {
                explosionSize += LocalizationScript.explosionSizeIncrease;

                ReduceBars();
                dynamiteExplosionSize_purchased = true;
                dynamiteExplosionSize_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = dynamiteExplosionSize_purchaseCount;
            }
        }
        #endregion

        #region dynamiteDamage
        else if (upgradeName == "dynamiteDamage")
        {
            if (GoldAndOreMechanics.totalGoldBars >= dynamiteDamage_price)
            {
                explosionDamagage += LocalizationScript.explosionDamagageIncrease;

                ReduceBars();
                dynamiteDamage_purchased = true;
                dynamiteDamage_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = dynamiteDamage_purchaseCount;
            }
        }
        #endregion

        #region dynamiteExplosionSpawnRock
        else if (upgradeName == "dynamiteExplosionSpawnRock")
        {
            if (GoldAndOreMechanics.totalGoldBars >= dynamiteExplosionSpawnRock_price)
            {
                ReduceBars();
                dynamiteExplosionSpawnRock_purchased = true;
                dynamiteExplosionSpawnRock_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = dynamiteExplosionSpawnRock_purchaseCount;
            }
        }
        #endregion

        #region dynamiteExplosionAddTimeChance
        else if (upgradeName == "dynamiteExplosionAddTimeChance")
        {
            if (GoldAndOreMechanics.totalGoldBars >= dynamiteExplosionAddTimeChance_price)
            {
                ReduceBars();
                dynamiteExplosionAddTimeChance_purchased = true;
                dynamiteExplosionAddTimeChance_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = dynamiteExplosionAddTimeChance_purchaseCount;
            }
        }
        #endregion

        #region dynamiteExplosionSpawnLightning
        else if (upgradeName == "dynamiteExplosionSpawnLightning")
        {
            if (GoldAndOreMechanics.totalGoldBars >= dynamiteExplosionSpawnLightning_price)
            {
                ReduceBars();
                dynamiteExplosionSpawnLightning_purchased = true;
                dynamiteExplosionSpawnLightning_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = dynamiteExplosionSpawnLightning_purchaseCount;
            }
        }
        #endregion

        #endregion

        //Plazma balls
        #region All plazma balls

        #region plazmaBallSpawn_1
        else if (upgradeName == "plazmaBallSpawn_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= plazmaBallSpawn_1_price)
            {
                plazmaBallChance += LocalizationScript.plazmaBallChanceIncrease;

                ReduceBars();
                plazmaBallSpawn_1_purchased = true;
                plazmaBallSpawn_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = plazmaBallSpawn_1_purchaseCount;
            }
        }
        #endregion

        #region plazmaBallSpawn_2
        else if (upgradeName == "plazmaBallSpawn_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= plazmaBallSpawn_2_price)
            {
                plazmaBallChance += LocalizationScript.plazmaBallChanceIncrease;

                ReduceBars();
                plazmaBallSpawn_2_purchased = true;
                plazmaBallSpawn_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = plazmaBallSpawn_2_purchaseCount;
            }
        }
        #endregion

        #region plazmaBallTime
        else if (upgradeName == "plazmaBallTime")
        {
            if (GoldAndOreMechanics.totalGoldBars >= plazmaBallTime_price)
            {
                plazmaBallTimer += LocalizationScript.plazmaBallTimerIncrease;

                ReduceBars();
                plazmaBallTime_purchased = true;
                plazmaBallTime_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = plazmaBallTime_purchaseCount;
            }
        }
        #endregion

        #region plazmaBallSize
        else if (upgradeName == "plazmaBallSize")
        {
            if (GoldAndOreMechanics.totalGoldBars >= plazmaBallSize_price)
            {
                plazmaBallTotalSize += LocalizationScript.plazmaBallTotalSizeIncrease;

                ReduceBars();
                plazmaBallSize_purchased = true;
                plazmaBallSize_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = plazmaBallSize_purchaseCount;
            }
        }
        #endregion

        #region plazmaBallExplosionChance
        else if (upgradeName == "plazmaBallExplosionChance")
        {
            if (GoldAndOreMechanics.totalGoldBars >= plazmaBallExplosionChance_price)
            {
                ReduceBars();
                plazmaBallExplosionChance_purchased = true;
                plazmaBallExplosionChance_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = plazmaBallExplosionChance_purchaseCount;
            }
        }
        #endregion

        #region plazmaBallSpawnSmallChance
        else if (upgradeName == "plazmaBallSpawnSmallChance")
        {
            if (GoldAndOreMechanics.totalGoldBars >= plazmaBallSpawnSmallChance_price)
            {
                ReduceBars();
                plazmaBallSpawnSmallChance_purchased = true;
                plazmaBallSpawnSmallChance_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = plazmaBallSpawnSmallChance_purchaseCount;
            }
        }
        #endregion

        #region plazmaBallDamage
        else if (upgradeName == "plazmaBallDamage")
        {
            if (GoldAndOreMechanics.totalGoldBars >= plazmaBallDamage_price)
            {
                plazmaBallTotalDamage += LocalizationScript.plazmaBallTotalDamageIncrease;

                ReduceBars();
                plazmaBallDamage_purchased = true;
                plazmaBallDamage_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = plazmaBallDamage_purchaseCount;
            }
        }
        #endregion

        #region plazmaBallSpawnPickaxeChance
        else if (upgradeName == "plazmaBallSpawnPickaxeChance")
        {
            if (GoldAndOreMechanics.totalGoldBars >= plazmaBallSpawnPickaxeChance_price)
            {
                ReduceBars();
                plazmaBallSpawnPickaxeChance_purchased = true;
                plazmaBallSpawnPickaxeChance_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = plazmaBallSpawnPickaxeChance_purchaseCount;
            }
        }
        #endregion

        #endregion

        //Misc
        #region All misc

        #region allProjectileDoubleDamageChance
        else if (upgradeName == "allProjectileDoubleDamageChance")
        {
            if (GoldAndOreMechanics.totalGoldBars >= allProjectileDoubleDamageChance_price)
            {
                ReduceBars();
                allProjectileDoubleDamageChance_purchased = true;
                allProjectileDoubleDamageChance_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = allProjectileDoubleDamageChance_purchaseCount;
            }
        }
        #endregion

        #region allProjectileTriggerChance
        else if (upgradeName == "allProjectileTriggerChance")
        {
            if (GoldAndOreMechanics.totalGoldBars >= allProjectileTriggerChance_price)
            {
                ReduceBars();
                allProjectileTriggerChance_purchased = true;
                allProjectileTriggerChance_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = allProjectileTriggerChance_purchaseCount;
            }
        }
        #endregion

        #region pickaxeDoubleDamageChance_1
        else if (upgradeName == "pickaxeDoubleDamageChance_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= pickaxeDoubleDamageChance_1_price)
            {
                doubleDamageChance += LocalizationScript.doubleDamageChanceIncrease;

                ReduceBars();
                pickaxeDoubleDamageChance_1_purchased = true;
                pickaxeDoubleDamageChance_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = pickaxeDoubleDamageChance_1_purchaseCount;
            }
        }
        #endregion

        #region pickaxeDoubleDamageChance_2
        else if (upgradeName == "pickaxeDoubleDamageChance_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= pickaxeDoubleDamageChance_2_price)
            {
                doubleDamageChance += LocalizationScript.doubleDamageChanceIncrease;

                ReduceBars();
                pickaxeDoubleDamageChance_2_purchased = true;
                pickaxeDoubleDamageChance_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = pickaxeDoubleDamageChance_2_purchaseCount;
            }
        }
        #endregion

        #region intaMineChance_1
        else if (upgradeName == "intaMineChance_1")
        {
            if (GoldAndOreMechanics.totalGoldBars >= intaMineChance_1_price)
            {
                instaMineChance += LocalizationScript.instaMineChanceIncrease;

                ReduceBars();
                intaMineChance_1_purchased = true;
                intaMineChance_1_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = intaMineChance_1_purchaseCount;
            }
        }
        #endregion

        #region intaMineChance_2
        else if (upgradeName == "intaMineChance_2")
        {
            if (GoldAndOreMechanics.totalGoldBars >= intaMineChance_2_price)
            {
                instaMineChance += LocalizationScript.instaMineChanceIncrease;

                ReduceBars();
                intaMineChance_2_purchased = true;
                intaMineChance_2_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = intaMineChance_2_purchaseCount;
            }
        }
        #endregion

        #region increaseSpawnChanceAllRocks
        else if (upgradeName == "increaseSpawnChanceAllRocks")
        {
            if (GoldAndOreMechanics.totalGoldBars >= increaseSpawnChanceAllRocks_price)
            {
                ReduceBars();

                float chanceIncrease = 1 + (allRockSpawnChanceIncrease / 100);

                goldRockChance = goldRockChance * chanceIncrease;
                fullGoldRockChance = fullGoldRockChance * chanceIncrease;

                copperRockChance = copperRockChance * chanceIncrease;
                fullCopperRockChance = fullCopperRockChance * chanceIncrease;

                ironRockChance = ironRockChance * chanceIncrease;
                fullIronRockChance = fullIronRockChance * chanceIncrease;

                cobaltRockChance = cobaltRockChance * chanceIncrease;
                fullCobaltRockChance = fullCobaltRockChance * chanceIncrease;

                uraniumRockChance = uraniumRockChance * chanceIncrease;
                fullUraniumRockChance = fullUraniumRockChance * chanceIncrease;

                ismiumRockChance = ismiumRockChance * chanceIncrease;
                fullIsmiumRockChance = fullIsmiumRockChance * chanceIncrease;

                iridiumRockChance = iridiumRockChance * chanceIncrease;
                fullIridiumRockChance = fullIridiumRockChance * chanceIncrease;

                painiteRockChance = painiteRockChance * chanceIncrease;
                fullPainiteRockChance = fullPainiteRockChance * chanceIncrease;

                increaseSpawnChanceAllRocks_purchased = true;
                increaseSpawnChanceAllRocks_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = increaseSpawnChanceAllRocks_purchaseCount;
            }
        }
        #endregion

        #region craft2Material
        else if (upgradeName == "craft2Material")
        {
            if (GoldAndOreMechanics.totalGoldBars >= craft2Material_price)
            {
                ReduceBars();
                craft2Material_purchased = true;
                craft2Material_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = craft2Material_purchaseCount;
            }
        }
        #endregion

        #region finalUpgrade
        else if (upgradeName == "finalUpgrade")
        {
            if (GoldAndOreMechanics.totalGoldBars >= finalUpgrade_price)
            {
                ReduceBars();
                finalUpgrade_purchased = true;
                finalUpgrade_purchaseCount += 1;

                LocalizationScript.currentPurchaseCount = finalUpgrade_purchaseCount;
            }
        }
        #endregion

        #endregion

        theAnvilScript.DisplayEquippedAndSetStats(TheAnvil.equippedMineTime, TheAnvil.equippedMinePower, TheAnvil.equipped2XChance, TheAnvil.equippedMiningArea);
        CheckUpgrades();
        UpdateTooltipText();
        theMineScript.UpdateChances();

        goldAndOreScript.SetTotalResourcesText();

        totalSkillTreeUpgradesPurchased += 1;
        //Debug.Log(totalSkillTreeUpgradesPurchased);
    }

    public LocalizationScript locScript;

    public void UpdateTooltipText()
    {
        locScript.SetSkillTreeTexts(Tooltip.upgradeName, Tooltip.upgradeType, LocalizationScript.currentHoverPrice, LocalizationScript.currentPurchaseCount, LocalizationScript.currentTotalPurchaseCount);
    }

    public void CheckUpgrades()
    {
        //More rocks
        #region All more rocks

        #region spawnMoreRocks_1
        if (spawnMoreRocks_1_purchased == true)
        {
            lines[0].SetActive(true);
            lines[1].SetActive(true);
            lines[2].SetActive(true);
            lines[3].SetActive(true);

            spawnMoreRocks_2.SetActive(true);
            improvedPickaxe_1.SetActive(true);
            goldChunk_1.SetActive(true);
            biggerMiningErea_1.SetActive(true);

            if (spawnMoreRocks_1_purchaseCount >= 5)
            {
                spawnMoreRocks_1_LOCKED.SetActive(false);
                spawnMoreRocks_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region spawnMoreRocks_2
        if (spawnMoreRocks_2_purchased)
        {
            lines[10].SetActive(true);
            lines[11].SetActive(true);
            lines[15].SetActive(true);
            lines[2].SetActive(true);

            lines[5].SetActive(true);
            lines[6].SetActive(true);

            spawnMoreRocks_3.SetActive(true);
            moreXP_1.SetActive(true);
            chanceToSpawnRockWhenMined_1.SetActive(true);

            if (spawnMoreRocks_2_purchaseCount >= 4)
            {
                spawnMoreRocks_2_LOCKED.SetActive(false);
                spawnMoreRocks_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region spawnMoreRocks_3
        if (spawnMoreRocks_3_purchased)
        {
            lines[12].SetActive(true);
            lines[13].SetActive(true);
            lines[15].SetActive(true);
            lines[18].SetActive(true);

            if (marterialsWorthMore_2_purchased) { lines[37].SetActive(true); }
            if (spawnMoreRocks_2_purchased) { lines[14].SetActive(true); lines[16].SetActive(true); }
            if (moreXP_2_purchased) { lines[23].SetActive(true); }
            if (goldChunk_1_purchased) { lines[14].SetActive(true); }

            spawnMoreRocks_4.SetActive(true);
            spawnMoreRocks_2.SetActive(true);
            moreXP_2.SetActive(true);
            doubleXpGoldChance_1.SetActive(true);

            if (spawnMoreRocks_3_purchaseCount >= 4)
            {
                spawnMoreRocks_3_LOCKED.SetActive(false);
                spawnMoreRocks_3.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region spawnMoreRocks_4
        if (spawnMoreRocks_4_purchased)
        {
            lines[13].SetActive(true);
            lines[14].SetActive(true);
            lines[19].SetActive(true);
            lines[37].SetActive(true);

            if (moreXP_1_purchased) { lines[12].SetActive(true); }
            if (spawnMoreRocks_3_purchased) { lines[24].SetActive(true); }
            if (chanceToSpawnRockWhenMined_1_purchased) { lines[15].SetActive(true); lines[39].SetActive(true); }

            spawnMoreRocks_3.SetActive(true);
            chanceToSpawnRockWhenMined_1.SetActive(true);
            spawnCopper.SetActive(true);
            spawnXRockEveryXSecond_1.SetActive(true);

            if (spawnMoreRocks_4_purchaseCount >= 5)
            {
                spawnMoreRocks_4_LOCKED.SetActive(false);
                spawnMoreRocks_4.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region spawnMoreRocks_5
        if (spawnMoreRocks_5_purchased)
        {
            lines[132].SetActive(true);
            lines[131].SetActive(true);
            lines[128].SetActive(true);

            if (spawnXRockEveryXSecond_2_purchased) { lines[139].SetActive(true); }

            marterialsWorthMore_6.SetActive(true);
            spawnRockEveryXrock_1.SetActive(true);
            spawnXRockEveryXSecond_2.SetActive(true);

            if (spawnMoreRocks_5_purchaseCount >= 5)
            {
                spawnMoreRocks_5_LOCKED.SetActive(false);
                spawnMoreRocks_5.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region spawnMoreRocks_6
        if (spawnMoreRocks_6_purchased)
        {
            lines[150].SetActive(true);
            lines[146].SetActive(true);
            lines[145].SetActive(true);

            if (fullIron_1_purchased) { lines[151].SetActive(true); }
            if (moreXP_5_purchased) { lines[144].SetActive(true); }

            moreXP_5.SetActive(true);
            fullIron_1.SetActive(true);
            cobaltSpawn.SetActive(true);

            if (spawnMoreRocks_6_purchaseCount >= 3)
            {
                spawnMoreRocks_6_LOCKED.SetActive(false);
                spawnMoreRocks_6.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region spawnMoreRocks_7
        if (spawnMoreRocks_7_purchased)
        {
            lines[165].SetActive(true);
            lines[159].SetActive(true);

            if (fullIron_1_purchased) { lines[160].SetActive(true); lines[155].SetActive(true); }
            if (cobaltSpawn_purchased) { lines[155].SetActive(true); }
            if (chanceAdd1SecondEveryRockMined_purchased) { lines[148].SetActive(true); }
            
            uraniumSpawn.SetActive(true);
            copperChunk_2.SetActive(true);

            if (spawnMoreRocks_7_purchaseCount >= 3)
            {
                spawnMoreRocks_7_LOCKED.SetActive(false);
                spawnMoreRocks_7.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region spawnMoreRocks_8
        if (spawnMoreRocks_8_purchased)
        {
            lines[182].SetActive(true);
            lines[180].SetActive(true);

            painiteSpawn.SetActive(true);
            ismiumSpawn.SetActive(true);

            if (spawnMoreRocks_8_purchaseCount >= 3)
            {
                spawnMoreRocks_8_LOCKED.SetActive(false);
                spawnMoreRocks_8.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region spawnMoreRocks_9
        if (spawnMoreRocks_9_purchased)
        {
            lines[183].SetActive(true);
            lines[178].SetActive(true);
            lines[179].SetActive(true);

            painiteSpawn.SetActive(true);
            iridiumSpawn.SetActive(true);

            if (spawnMoreRocks_9_purchaseCount >= 3)
            {
                spawnMoreRocks_9_LOCKED.SetActive(false);
                spawnMoreRocks_9.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //More materials from rocks
        #region All more materials from rocks

        #region moreMeterialsFromRock_1
        if (moreMeterialsFromRock_1_purchased)
        {
            lines[42].SetActive(true);
            lines[46].SetActive(true);

            if (marterialsWorthMore_1_purchased) { lines[48].SetActive(true); }

            marterialsWorthMore_1.SetActive(true);
            doubleXpGoldChance_3.SetActive(true);

            if (moreMeterialsFromRock_1_purchaseCount >= 2)
            {
                moreMeterialsFromRock_1_LOCKED.SetActive(false);
                moreMeterialsFromRock_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region moreMeterialsFromRock_2
        if (moreMeterialsFromRock_2_purchased)
        {
            lines[29].SetActive(true);
            lines[33].SetActive(true);

            if (moreTime_4_purchased) { lines[28].SetActive(true); lines[25].SetActive(true); }
            if (intaMineChance_2_purchased) { lines[31].SetActive(true); }
            if (doubleXpGoldChance_1_purchased) { lines[20].SetActive(true); lines[25].SetActive(true); }

            intaMineChance_2.SetActive(true);
            chanceToSpawnRockWhenMined_2.SetActive(true);

            if (moreMeterialsFromRock_2_purchaseCount >= 2)
            {
                moreMeterialsFromRock_2_LOCKED.SetActive(false);
                moreMeterialsFromRock_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region moreMeterialsFromRock_3
        if (moreMeterialsFromRock_3_purchased)
        {
            lines[65].SetActive(true);
            lines[72].SetActive(true);

            if (increaseAndDecreaseMinignErea_purchased) { lines[66].SetActive(true); }
            if (moreXP_3_purchased) { lines[66].SetActive(true); }

            moreXP_3.SetActive(true);
            chanceToSpawnRockWhenMined_3.SetActive(true);

            if (moreMeterialsFromRock_3_purchaseCount >= 2)
            {
                moreMeterialsFromRock_3_LOCKED.SetActive(false);
                moreMeterialsFromRock_3.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region moreMeterialsFromRock_4
        if (moreMeterialsFromRock_4_purchased)
        {
            lines[164].SetActive(true);
            lines[162].SetActive(true);
            lines[161].SetActive(true);

            if (fullIron_1_purchased) { lines[160].SetActive(true); }
            if (cobaltSpawn_purchased) { lines[160].SetActive(true); }

            cobaltSpawn.SetActive(true);
            chanceToSpawnRockWhenMined_6.SetActive(true);
            copperChunk_2.SetActive(true);

            if (moreMeterialsFromRock_4_purchaseCount >= 2)
            {
                moreMeterialsFromRock_4_LOCKED.SetActive(false);
                moreMeterialsFromRock_4.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region moreMeterialsFromRock_5
        if (moreMeterialsFromRock_5_purchased)
        {
            lines[189].SetActive(true);
            lines[187].SetActive(true);
            lines[190].SetActive(true);

            goldChunk_5_.SetActive(true);

            if (moreMeterialsFromRock_5_purchaseCount >= 2)
            {
                moreMeterialsFromRock_5_LOCKED.SetActive(false);
                moreMeterialsFromRock_5.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //Materials worth more
        #region All materials worth more

        #region marterialsWorthMore_1
        if (marterialsWorthMore_1_purchased)
        {
            lines[46].SetActive(true);
            lines[45].SetActive(true);
            lines[41].SetActive(true);
            lines[40].SetActive(true);

            if (goldChunk_1_purchased) { lines[44].SetActive(true); lines[47].SetActive(true); }

            marterialsWorthMore_2.SetActive(true);
            marterialsWorthMore_3.SetActive(true);
            moreMeterialsFromRock_1.SetActive(true);
            goldChunk_1.SetActive(true);

            if (marterialsWorthMore_1_purchaseCount >= 5)
            {
                marterialsWorthMore_1_LOCKED.SetActive(false);
                marterialsWorthMore_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region marterialsWorthMore_2
        if (marterialsWorthMore_2_purchased)
        {
            lines[44].SetActive(true);
            lines[40].SetActive(true);
            lines[39].SetActive(true);
            lines[45].SetActive(true);

            spawnCopper.SetActive(true);
            marterialsWorthMore_1.SetActive(true);
            chanceToSpawnRockWhenMined_1.SetActive(true);

            if (marterialsWorthMore_2_purchaseCount >= 5)
            {
                marterialsWorthMore_2_LOCKED.SetActive(false);
                marterialsWorthMore_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region marterialsWorthMore_3
        if (marterialsWorthMore_3_purchased)
        {
            lines[48].SetActive(true);
            lines[47].SetActive(true);
            lines[41].SetActive(true);

            if (spawnRockEveryXrock_1_purchased) { lines[40].SetActive(true); }
            if (spawnMoreRocks_1_purchased) { lines[45].SetActive(true); }
            if (goldChunk_1_purchased) { lines[45].SetActive(true); }
            if (marterialsWorthMore_1_purchased) { lines[42].SetActive(true); }

            fullGold_1.SetActive(true);
            marterialsWorthMore_1.SetActive(true);
            doubleXpGoldChance_3.SetActive(true);

            if (marterialsWorthMore_3_purchaseCount >= 5)
            {
                marterialsWorthMore_3_LOCKED.SetActive(false);
                marterialsWorthMore_3.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region marterialsWorthMore_4
        if (marterialsWorthMore_4_purchased)
        {
            lines[28].SetActive(true);
            lines[32].SetActive(true);

            if (intaMineChance_2_purchased) { lines[27].SetActive(true); }
            if (moreTime_4_purchased) { lines[29].SetActive(true); lines[31].SetActive(true); }


            moreTime_4.SetActive(true);
            chanceToSpawnRockWhenMined_2.SetActive(true);

            if (marterialsWorthMore_4_purchaseCount >= 5)
            {
                marterialsWorthMore_4_LOCKED.SetActive(false);
                marterialsWorthMore_4.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region marterialsWorthMore_5
        if (marterialsWorthMore_5_purchased)
        {
            lines[71].SetActive(true);
            lines[64].SetActive(true);

            doubleXpGoldChance_2.SetActive(true);
            chanceToSpawnRockWhenMined_3.SetActive(true);

            if (increaseAndDecreaseMinignErea_purchased) { lines[66].SetActive(true); }
            if (doubleXpGoldChance_2_purchased) { lines[66].SetActive(true); }

            if (marterialsWorthMore_5_purchaseCount >= 5)
            {
                marterialsWorthMore_5_LOCKED.SetActive(false);
                marterialsWorthMore_5.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region marterialsWorthMore_6
        if (marterialsWorthMore_6_purchased)
        {
            lines[131].SetActive(true);
            lines[128].SetActive(true);
            spawnMoreRocks_5.SetActive(true);

            if (marterialsWorthMore_6_purchaseCount >= 5)
            {
                marterialsWorthMore_6_LOCKED.SetActive(false);
                marterialsWorthMore_6.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region marterialsWorthMore_7
        if (marterialsWorthMore_7_purchased)
        {
            lines[148].SetActive(true);
            lines[143].SetActive(true);
            lines[149].SetActive(true);

            if (cobaltSpawn_purchased) { lines[155].SetActive(true); }
            if (fullIron_1_purchased) { lines[155].SetActive(true); }

            fullIron_1.SetActive(true);
            uraniumSpawn.SetActive(true);
            chanceAdd1SecondEveryRockMined.SetActive(true);

            if (marterialsWorthMore_7_purchaseCount >= 5)
            {
                marterialsWorthMore_7_LOCKED.SetActive(false);
                marterialsWorthMore_7.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region marterialsWorthMore_8
        if (marterialsWorthMore_8_purchased)
        {
            lines[188].SetActive(true);
            lines[191].SetActive(true);

            copperChunk_3.SetActive(true);

            if (marterialsWorthMore_8_purchaseCount >= 5)
            {
                marterialsWorthMore_8_LOCKED.SetActive(false);
                marterialsWorthMore_8.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //Gold rocks
        #region All gold rocks

        #region goldChunk_1
        if (goldChunk_1_purchased)
        {
            lines[0].SetActive(true);
            lines[7].SetActive(true);
            lines[6].SetActive(true);
            lines[45].SetActive(true);

            lines[10].SetActive(true);
            lines[8].SetActive(true);

            if (chanceToSpawnRockWhenMined_1_purchased) { lines[40].SetActive(true); }
            if (fullGold_1_purchased) { lines[41].SetActive(true); }

            marterialsWorthMore_1.SetActive(true);
            chanceToSpawnRockWhenMined_1.SetActive(true);
            fullGold_1.SetActive(true);

            if (goldChunk_1_purchaseCount >= 5)
            {
                goldChunk_1_LOCKED.SetActive(false);
                goldChunk_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region goldChunk_2
        if (goldChunk_2_purchased)
        {
            lines[43].SetActive(true);
            lines[49].SetActive(true);
            lines[50].SetActive(true);

            chanceToMineRandomRock_4.SetActive(true);
            improvedPickaxe_4.SetActive(true);

            if (goldChunk_2_purchaseCount >= 5)
            {
                goldChunk_2_LOCKED.SetActive(false);
                goldChunk_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region goldChunk_3
        if (goldChunk_3_purchased)
        {
            lines[130].SetActive(true);
            lines[129].SetActive(true);

       
            if (goldChunk_3_purchaseCount >= 5)
            {
                goldChunk_3_LOCKED.SetActive(false);
                goldChunk_3.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region goldChunk_4
        if (goldChunk_4_purchased)
        {
            lines[170].SetActive(true);
            lines[168].SetActive(true);
            lines[167].SetActive(true);

            spawnRockEveryXrock_3.SetActive(true);
            increaseSpawnChanceAllRocks.SetActive(true);

            if (goldChunk_4_purchaseCount >= 5)
            {
                goldChunk_4_LOCKED.SetActive(false);
                goldChunk_4.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region goldChunk_5
        if (goldChunk_5_purchased)
        {
            lines[187].SetActive(true);
            lines[188].SetActive(true);
            lines[190].SetActive(true);

            marterialsWorthMore_8.SetActive(true);

            if (goldChunk_5_purchaseCount >= 5)
            {
                goldChunk_5_LOCKED.SetActive(false);
                goldChunk_5_.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region fullGold_1
        if (fullGold_1_purchased)
        {
            lines[7].SetActive(true);
            lines[8].SetActive(true);
            lines[47].SetActive(true);
            lines[57].SetActive(true);


            marterialsWorthMore_3.SetActive(true);
            chanceToMineRandomRock_3.SetActive(true);

            if (fullGold_1_purchaseCount >= 3)
            {
                fullGold_1_LOCKED.SetActive(false);
                fullGold_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region fullGold_2
        if (fullGold_2_purchased)
        {
            lines[160].SetActive(true);
            lines[155].SetActive(true);
            lines[151].SetActive(true);
            lines[147].SetActive(true);

            if (fullIron_1_purchased) { lines[148].SetActive(true); lines[146].SetActive(true); }
            if (copperChunk_2_purchased) { lines[159].SetActive(true); }

            copperChunk_2.SetActive(true);
            cobaltSpawn.SetActive(true);
            uraniumSpawn.SetActive(true);

            if (fullGold_2_purchaseCount >= 3)
            {
                fullGold_2_LOCKED.SetActive(false);
                fullGold_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region fullGold_3
        if (fullGold_3_purchased)
        {
            lines[177].SetActive(true);
            lines[176].SetActive(true);

            talentPointsPerXlevel_3.SetActive(true);

            if (fullGold_3_purchaseCount >= 3)
            {
                fullGold_3_LOCKED.SetActive(false);
                fullGold_3.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //Copper rocks
        #region All Copper rocks

        #region spawnCopper
        if (spawnCopper_purchased)
        {
            copperBarFrame.SetActive(true);

            lines[37].SetActive(true);
            lines[38].SetActive(true);
            lines[39].SetActive(true);
            lines[123].SetActive(true);

            if (doubleXpGoldChance_1_purchased) { lines[35].SetActive(true); }
            if (spawnMoreRocks_4_purchased) { lines[35].SetActive(true); lines[44].SetActive(true); }
            if (spawnMoreRocks_2_purchased) { lines[13].SetActive(true); lines[14].SetActive(true); }
            if (moreXP_2_purchased) { lines[13].SetActive(true); }
            if (goldChunk_1_purchased) { lines[14].SetActive(true); }

            marterialsWorthMore_2.SetActive(true);
            spawnMoreRocks_4.SetActive(true);
            copperChunk_1.SetActive(true);
            biggerMiningErea_3.SetActive(true);

            if (spawnCopper_purchaseCount >= 1)
            {
                spawnCopper_LOCKED.SetActive(false);
                spawnCopper.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region copperChunk_1
        if (copperChunk_1_purchased)
        {
            lines[124].SetActive(true);

            fullCopper_1.SetActive(true);

            if (copperChunk_1_purchaseCount >= 3)
            {
                copperChunk_1_LOCKED.SetActive(false);
                copperChunk_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region copperChunk_2
        if (copperChunk_2_purchased)
        {
            lines[163].SetActive(true);
            lines[160].SetActive(true);
            lines[164].SetActive(true);
            lines[165].SetActive(true);


            if (spawnMoreRocks_6_purchased) { lines[161].SetActive(true); }
            if (moreMeterialsFromRock_4_purchased) { lines[166].SetActive(true); }
            if (fullGold_2_purchased) { lines[159].SetActive(true); lines[161].SetActive(true); }
            if (marterialsWorthMore_7_purchased) { lines[159].SetActive(true); }

            fullCopper_2.SetActive(true);
            spawnMoreRocks_7.SetActive(true);
            moreMeterialsFromRock_4.SetActive(true);

            if (copperChunk_2_purchaseCount >= 3)
            {
                copperChunk_2_LOCKED.SetActive(false);
                copperChunk_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region copperChunk_3
        if (copperChunk_3_purchased)
        {
            lines[186].SetActive(true);
            lines[191].SetActive(true);

            if (fullIsmium_1_purchased) { lines[188].SetActive(true); }

            marterialsWorthMore_8.SetActive(true);

            if (copperChunk_3_purchaseCount >= 3)
            {
                copperChunk_3_LOCKED.SetActive(false);
                copperChunk_3.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region fullCopper_1
        if (fullCopper_1_purchased)
        {
            lines[127].SetActive(true);
            lines[126].SetActive(true);
            lines[125].SetActive(true);
            lines[124].SetActive(true);

            marterialsWorthMore_6.SetActive(true);
            moreXP_4.SetActive(true);
            spawnXRockEveryXSecond_2.SetActive(true);

            if (fullCopper_1_purchaseCount >= 2)
            {
                fullCopper_1_LOCKED.SetActive(false);
                fullCopper_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region fullCopper_2
        if (fullCopper_2_purchased)
        {
            lines[167].SetActive(true);
            lines[166].SetActive(true);
            lines[163].SetActive(true);

            if (cobaltSpawn_purchased) { lines[162].SetActive(true); }
            if (copperChunk_2_purchased) { lines[162].SetActive(true); }

            goldChunk_4.SetActive(true);
            chanceToSpawnRockWhenMined_6.SetActive(true);

            if (fullCopper_2_purchaseCount >= 2)
            {
                fullCopper_2_LOCKED.SetActive(false);
                fullCopper_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region fullCopper_3
        if (fullCopper_3_purchased)
        {
            if (fullCopper_3_purchaseCount >= 2)
            {
                fullCopper_3_LOCKED.SetActive(false);
                fullCopper_3.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //Iron rocks
        #region All Iron rocks

        #region spawnIron
        if (spawnIron_purchased)
        {
            ironBarFrame.SetActive(true);

            lines[133].SetActive(true);
            lines[134].SetActive(true);
            lines[139].SetActive(true);
            lines[132].SetActive(true);

            if (marterialsWorthMore_6_purchased) { lines[132].SetActive(true); }

            ironChunk_1.SetActive(true);
            spawnRockEveryXrock_1.SetActive(true);

            if (spawnIron_purchaseCount >= 1)
            {
                spawnIron_LOCKED.SetActive(false);
                spawnIron.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region ironChunk_1
        if (ironChunk_1_purchased)
        {
            lines[144].SetActive(true);
            lines[141].SetActive(true);
            lines[140].SetActive(true);
            lines[134].SetActive(true);

            if (spawnIron_purchased) { lines[135].SetActive(true); }
            if (moreXP_5_purchased) { lines[135].SetActive(true); lines[150].SetActive(true); }
            if (spawnMoreRocks_5_purchased) { lines[135].SetActive(true); }

            fullIron_1.SetActive(true);
            moreXP_5.SetActive(true);
            chanceAdd1SecondEveryRockMined.SetActive(true);

            if (ironChunk_1_purchaseCount >= 3)
            {
                ironChunk_1_LOCKED.SetActive(false);
                ironChunk_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region ironChunk_2
        if (ironChunk_2_purchased)
        {
            lines[192].SetActive(true);
            lines[193].SetActive(true);

            moreXP_8.SetActive(true);

            if (ironChunk_2_purchaseCount >= 3)
            {
                ironChunk_2_LOCKED.SetActive(false);
                ironChunk_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region fullIron_1
        if (fullIron_1_purchased)
        {
            lines[149].SetActive(true);
            lines[147].SetActive(true);
            lines[144].SetActive(true);
            lines[150].SetActive(true);

            if (ironChunk_1_purchased) { lines[143].SetActive(true); lines[145].SetActive(true); }

            fullGold_2.SetActive(true);
            spawnMoreRocks_6.SetActive(true);
            marterialsWorthMore_7.SetActive(true);

            if (fullIron_1_purchaseCount >= 2)
            {
                fullIron_1_LOCKED.SetActive(false);
                fullIron_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region fullIron_2
        if (fullIron_2_purchased)
        {
            if (fullIron_2_purchaseCount >= 2)
            {
                fullIron_2_LOCKED.SetActive(false);
                fullIron_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //All cobalt
        #region All Cobalt rocks

        #region cobaltSpawn
        if (cobaltSpawn_purchased)
        {
            cobaltBarFrame.SetActive(true);

            lines[161].SetActive(true);
            lines[152].SetActive(true);
            lines[151].SetActive(true);
            lines[146].SetActive(true);

            if (spawnMoreRocks_6_purchased) { lines[147].SetActive(true); }
            if (fullGold_2_purchased) { lines[164].SetActive(true); }

            spawnMoreRocks_6.SetActive(true);
            cobaltChunk_1.SetActive(true);
            moreMeterialsFromRock_4.SetActive(true);
            fullGold_2.SetActive(true);

            if (cobaltSpawn_purchaseCount >= 1)
            {
                cobaltSpawn_LOCKED.SetActive(false);
                cobaltSpawn.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region cobaltChunk_1
        if (cobaltChunk_1_purchased)
        {
            lines[152].SetActive(true);
            lines[153].SetActive(true);

            fullCobalt_1.SetActive(true);

            if (cobaltChunk_1_purchaseCount >= 3)
            {
                cobaltChunk_1_LOCKED.SetActive(false);
                cobaltChunk_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region fullCobalt_1
        if (fullCobalt_1_purchased)
        {
            lines[154].SetActive(true);

            moreXP_6.SetActive(true);

            if (fullCobalt_1_purchaseCount >= 2)
            {
                fullCobalt_1_LOCKED.SetActive(false);
                fullCobalt_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //All Uranium
        #region All Uranium rocks

        #region uraniumSpawn
        if (uraniumSpawn_purchased)
        {
            uraniumiumBarFrame.SetActive(true);

            lines[159].SetActive(true);
            lines[156].SetActive(true);
            lines[155].SetActive(true);
            lines[148].SetActive(true);

            if (fullGold_2_purchased) { lines[165].SetActive(true); }
            if (ironChunk_1_purchased) { lines[143].SetActive(true); lines[149].SetActive(true); }

            uraniumChunk_1.SetActive(true);
            spawnMoreRocks_7.SetActive(true);
            fullGold_2.SetActive(true);
            marterialsWorthMore_7.SetActive(true);

            if (uraniumSpawn_purchaseCount >= 1)
            {
                uraniumSpawn_LOCKED.SetActive(false);
                uraniumSpawn.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region uraniumChunk_1
        if (uraniumChunk_1_purchased)
        {
            lines[156].SetActive(true);
            lines[157].SetActive(true);

            fullUranium_1.SetActive(true);
   
            if (uraniumChunk_1_purchaseCount >= 3)
            {
                uraniumChunk_1_LOCKED.SetActive(false);
                uraniumChunk_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region fullUranium_1
        if (fullUranium_1_purchased)
        {
            lines[158].SetActive(true);

            moreXP_7.SetActive(true);

            if (fullUranium_1_purchaseCount >= 2)
            {
                fullUranium_1_LOCKED.SetActive(false);
                fullUranium_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //All Ismium
        #region All Ismium rocks

        #region ismiumSpawn
        if (ismiumSpawn_purchased)
        {
            ismiumBarFrame.SetActive(true);

            lines[184].SetActive(true);
            lines[181].SetActive(true);
            lines[180].SetActive(true);

            if (spawnMoreRocks_9_purchased) { lines[182].SetActive(true); }
            if (increaseSpawnChanceAllRocks_purchased) { lines[182].SetActive(true); }

            ismiumChunk_1.SetActive(true);
            spawnMoreRocks_8.SetActive(true);

            if (ismiumSpawn_purchaseCount >= 1)
            {
                ismiumSpawn_LOCKED.SetActive(false);
                ismiumSpawn.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region ismiumChunk_1
        if (ismiumChunk_1_purchased)
        {
            lines[189].SetActive(true);
            lines[185].SetActive(true);
            lines[184].SetActive(true);

            fullIsmium_1.SetActive(true);
            moreMeterialsFromRock_5.SetActive(true);

            if (ismiumChunk_1_purchaseCount >= 3)
            {
                ismiumChunk_1_LOCKED.SetActive(false);
                ismiumChunk_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region fullIsmium_1
        if (fullIsmium_1_purchased)
        {
            lines[185].SetActive(true);
            lines[186].SetActive(true);
            lines[190].SetActive(true);
            lines[192].SetActive(true);
            lines[187].SetActive(true);

            if (goldChunk_5_purchased) { lines[191].SetActive(true); }

            goldChunk_5_.SetActive(true);
            copperChunk_3.SetActive(true);
            ironChunk_2.SetActive(true);

            if (fullIsmium_1_purchaseCount >= 2)
            {
                fullIsmium_1_LOCKED.SetActive(false);
                fullIsmium_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //All Iridium
        #region All Iridium rocks

        #region iridiumSpawn
        if (iridiumSpawn_purchased)
        {
            iridiumBarFRame.SetActive(true);

            lines[178].SetActive(true);
            lines[172].SetActive(true);
            lines[171].SetActive(true);
            lines[169].SetActive(true);

            if (increaseSpawnChanceAllRocks_purchased) { lines[183].SetActive(true); }

            iridiumChunk_1.SetActive(true);
            spawnMoreRocks_9.SetActive(true);
            spawnRockEveryXrock_3.SetActive(true);

            if (iridiumSpawn_purchaseCount >= 1)
            {
                iridiumSpawn_LOCKED.SetActive(false);
                iridiumSpawn.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region iridiumChunk_1
        if (iridiumChunk_1_purchased)
        {
            lines[173].SetActive(true);

            fullIridium_1.SetActive(true);

            if (iridiumChunk_1_purchaseCount >= 3)
            {
                iridiumChunk_1_LOCKED.SetActive(false);
                iridiumChunk_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region fullIridium_1
        if (fullIridium_1_purchased)
        {
            lines[176].SetActive(true);
            lines[175].SetActive(true);
            lines[174].SetActive(true);
            lines[173].SetActive(true);

            fullGold_3.SetActive(true);
            fullIron_2.SetActive(true);
            fullCopper_3.SetActive(true);

            if (fullIridium_1_purchaseCount >= 2)
            {
                fullIridium_1_LOCKED.SetActive(false);
                fullIridium_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //All Painite
        #region All Painite rocks

        #region painiteSpawn
        if (painiteSpawn_purchased)
        {
            painiteBarFrame.SetActive(true);

            lines[194].SetActive(true);
            lines[183].SetActive(true);
            lines[182].SetActive(true);
            lines[179].SetActive(true);

            if (iridiumSpawn_purchased) { lines[181].SetActive(true); }
            if (goldChunk_4_purchased) { lines[181].SetActive(true); }
            if (increaseSpawnChanceAllRocks_purchased) { lines[178].SetActive(true); lines[180].SetActive(true); }

            painiteChunk_1.SetActive(true);
            spawnMoreRocks_8.SetActive(true);
            spawnMoreRocks_9.SetActive(true);

            if (painiteSpawn_purchaseCount >= 1)
            {
                painiteSpawn_LOCKED.SetActive(false);
                painiteSpawn.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region painiteChunk_1
        if (painiteChunk_1_purchased)
        {
            lines[194].SetActive(true);
            lines[195].SetActive(true);

            fullPainite_1.SetActive(true);

            if (painiteChunk_1_purchaseCount >= 3)
            {
                painiteChunk_1_LOCKED.SetActive(false);
                painiteChunk_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region fullPainite_1
        if (fullPainite_1_purchased)
        {
            lines[196].SetActive(true);
            lines[197].SetActive(true);
            finaLine.SetActive(true);

            craft2Material.SetActive(true);
            spawnXRockEveryXSecond_3.SetActive(true);
            finalUpgrade.SetActive(true);

            if (fullPainite_1_purchaseCount >= 2)
            {
                fullPainite_1_LOCKED.SetActive(false);
                fullPainite_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //Improved pickaxes
        #region All improved pickaxe

        #region improvedPickaxe_1
        if (improvedPickaxe_1_purchased)
        {
            lines[1].SetActive(true);
            lines[4].SetActive(true);
            lines[5].SetActive(true);
            lines[73].SetActive(true);

            lines[9].SetActive(true);
            lines[11].SetActive(true);

            //if (chanceToSpawnRockWhenMined_1_purchased) { lines[75].SetActive(true); }

            moreXP_1.SetActive(true);
            pickaxeDoubleDamageChance_1.SetActive(true);
            chanceToMineRandomRock_1.SetActive(true);

            if (improvedPickaxe_1_purchaseCount >= 3)
            {
                improvedPickaxe_1_LOCKED.SetActive(false);
                improvedPickaxe_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region improvedPickaxe_2
        if (improvedPickaxe_2_purchased)
        {
            lines[77].SetActive(true);
            lines[78].SetActive(true);
            lines[80].SetActive(true);
            lines[83].SetActive(true);

            if (moreTime_2_purchased) { lines[81].SetActive(true); }
            if (chanceToMineRandomRock_1_purchased) { lines[75].SetActive(true); }

            moreTime_2.SetActive(true);
            lightningBeamChanceS_1.SetActive(true);
            lightningBeamChancePH_1.SetActive(true);

            if (improvedPickaxe_2_purchaseCount >= 3)
            {
                improvedPickaxe_2_LOCKED.SetActive(false);
                improvedPickaxe_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region improvedPickaxe_3
        if (improvedPickaxe_3_purchased)
        {
            lines[98].SetActive(true);
            lines[85].SetActive(true);
            lines[81].SetActive(true);
            lines[76].SetActive(true);

            if (moreTime_2_purchased) { lines[78].SetActive(true); }

            moreTime_2.SetActive(true);
            lightningBeamChanceS_1.SetActive(true);
            spawnPickaxeEverySecond_1.SetActive(true);
            chanceToSpawnRockWhenMined_4.SetActive(true);

            if (moreTime_2_purchased) { lines[88].SetActive(true); }

            if (improvedPickaxe_3_purchaseCount >= 3)
            {
                improvedPickaxe_3_LOCKED.SetActive(false);
                improvedPickaxe_3.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region improvedPickaxe_4
        if (improvedPickaxe_4_purchased)
        {
            if (improvedPickaxe_4_purchaseCount >= 3)
            {
                improvedPickaxe_4_LOCKED.SetActive(false);
                improvedPickaxe_4.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region improvedPickaxe_5
        if (improvedPickaxe_5_purchased)
        {
            if (improvedPickaxe_5_purchaseCount >= 3)
            {
                improvedPickaxe_5_LOCKED.SetActive(false);
                improvedPickaxe_5.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region improvedPickaxe_6
        if (improvedPickaxe_6_purchased)
        {
            lines[34].SetActive(true);
            lines[26].SetActive(true);

            if (spawnMoreRocks_4_purchased) { lines[20].SetActive(true); }
            if (biggerMiningErea_3_purchased) { lines[20].SetActive(true); }
            if (moreTime_4_purchased) { lines[25].SetActive(true); }

            biggerMiningErea_3.SetActive(true);
            intaMineChance_2.SetActive(true);

            if (improvedPickaxe_6_purchaseCount >= 3)
            {
                improvedPickaxe_6_LOCKED.SetActive(false);
                improvedPickaxe_6.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //XP
        #region All XP

        #region moreXP_1
        if (moreXP_1_purchased)
        {
            lines[5].SetActive(true);
            lines[11].SetActive(true);
            lines[16].SetActive(true);
            lines[74].SetActive(true);

            if (spawnMoreRocks_2_purchased) { lines[12].SetActive(true); }
            if (improvedPickaxe_1_purchased) { lines[79].SetActive(true); }

            moreXP_2.SetActive(true);
            moreTime_1.SetActive(true);
            improvedPickaxe_1.SetActive(true);

            if (moreXP_1_purchaseCount >= 5)
            {
                moreXP_1_LOCKED.SetActive(false);
                moreXP_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region moreXP_2
        if (moreXP_2_purchased)
        {
            lines[16].SetActive(true);
            lines[17].SetActive(true);
            lines[12].SetActive(true);

            if (spawnPickaxeEverySecond_3_purchased) { lines[22].SetActive(true); }
            if (moreXP_1_purchased) { lines[15].SetActive(true); }
            if (spawnRockEveryXrock_1_purchased) { lines[23].SetActive(true); }
            if (chanceToSpawnRockWhenMined_1_purchased) { lines[13].SetActive(true); }

            spawnMoreRocks_3.SetActive(true);
            moreXP_1.SetActive(true);
            talentPointsPerXlevel_1.SetActive(true);

            if (moreXP_2_purchaseCount >= 5)
            {
                moreXP_2_LOCKED.SetActive(false);
                moreXP_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region moreXP_3
        if (moreXP_3_purchased)
        {
            lines[61].SetActive(true);
            lines[65].SetActive(true);
            lines[68].SetActive(true);
            lines[69].SetActive(true);

            if (spawnPickaxeEverySecond_2_purchased) { lines[62].SetActive(true); lines[70].SetActive(true); }
            if (shootCircleChance_purchased) { lines[62].SetActive(true); }
            if (biggerMiningErea_2_purchased) { lines[72].SetActive(true); }
            if (marterialsWorthMore_5_purchased) { lines[72].SetActive(true); }

            moreTime_3.SetActive(true);
            biggerMiningErea_2.SetActive(true);
            improvedPickaxe_5.SetActive(true);
            moreMeterialsFromRock_3.SetActive(true);

            if (moreXP_3_purchaseCount >= 3)
            {
                moreXP_3_LOCKED.SetActive(false);
                moreXP_3.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region moreXP_4
        if (moreXP_4_purchased)
        {
            lines[130].SetActive(true);
            lines[126].SetActive(true);
            lines[129].SetActive(true);

            if (spawnXRockEveryXSecond_2_purchased) { lines[129].SetActive(true); }

            fullCopper_1.SetActive(true);
            goldChunk_3.SetActive(true);

            if (moreXP_4_purchaseCount >= 3)
            {
                moreXP_4_LOCKED.SetActive(false);
                moreXP_4.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region moreXP_5
        if (moreXP_5_purchased)
        {
            lines[145].SetActive(true);
            lines[140].SetActive(true);
            lines[138].SetActive(true);
            lines[135].SetActive(true);

            if (spawnRockEveryXrock_1_purchased) { lines[136].SetActive(true); lines[134].SetActive(true); }

            ironChunk_1.SetActive(true);
            talentPointsPerXlevel_2.SetActive(true);
            spawnMoreRocks_6.SetActive(true);
            spawnRockEveryXrock_1.SetActive(true);

            if (moreXP_5_purchaseCount >= 4)
            {
                moreXP_5_LOCKED.SetActive(false);
                moreXP_5.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region moreXP_6
        if (moreXP_6_purchased)
        {
            if (moreXP_6_purchaseCount >= 3)
            {
                moreXP_6_LOCKED.SetActive(false);
                moreXP_6.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region moreXP_7
        if (moreXP_7_purchased)
        {
            if (moreXP_7_purchaseCount >= 3)
            {
                moreXP_7_LOCKED.SetActive(false);
                moreXP_7.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region moreXP_8
        if (moreXP_8_purchased)
        {
            if (moreXP_8_purchaseCount >= 2)
            {
                moreXP_8_LOCKED.SetActive(false);
                moreXP_8.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region talentPointsPerXlevel_1
        if (talentPointsPerXlevel_1_purchased)
        {
            lines[17].SetActive(true);
            lines[22].SetActive(true);
            lines[23].SetActive(true);
            lines[36].SetActive(true);

            if (spawnMoreRocks_4_purchased) { lines[24].SetActive(true); }
            if (moreXP_2_purchased) { lines[18].SetActive(true); }
            if (doubleXpGoldChance_1_purchased) { lines[27].SetActive(true); }

            moreXP_2.SetActive(true);
            chanceToMineRandomRock_2.SetActive(true);
            moreTime_4.SetActive(true);
            doubleXpGoldChance_1.SetActive(true);

            if (talentPointsPerXlevel_1_purchaseCount >= 1)
            {
                talentPointsPerXlevel_1_LOCKED.SetActive(false);
                talentPointsPerXlevel_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region talentPointsPerXlevel_2
        if (talentPointsPerXlevel_2_purchased)
        {
            lines[138].SetActive(true);
            lines[136].SetActive(true);

            moreXP_5.SetActive(true);
            chanceToSpawnRockWhenMined_5.SetActive(true);

            if (talentPointsPerXlevel_2_purchaseCount >= 1)
            {
                talentPointsPerXlevel_2_LOCKED.SetActive(false);
                talentPointsPerXlevel_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region talentPointsPerXlevel_3
        if (talentPointsPerXlevel_3_purchased)
        {
            if (talentPointsPerXlevel_3_purchaseCount >= 1)
            {
                talentPointsPerXlevel_3_LOCKED.SetActive(false);
                talentPointsPerXlevel_3.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //Bigger mining erea
        #region All bigger mining erea

        #region biggerMiningErea_1
        if (biggerMiningErea_1_purchased)
        {
            lines[3].SetActive(true);
            lines[8].SetActive(true);
            lines[9].SetActive(true);
            lines[55].SetActive(true);

            lines[4].SetActive(true);
            lines[7].SetActive(true);

            if (fullGold_1_purchased) { lines[52].SetActive(true); }

            fullGold_1.SetActive(true);
            shootCircleChance.SetActive(true);
            pickaxeDoubleDamageChance_1.SetActive(true);

            if (biggerMiningErea_1_purchaseCount >= 5)
            {
                biggerMiningErea_1_LOCKED.SetActive(false);
                biggerMiningErea_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region biggerMiningErea_2
        if (biggerMiningErea_2_purchased)
        {
            lines[62].SetActive(true);
            lines[66].SetActive(true);
            lines[68].SetActive(true);
            lines[70].SetActive(true);

            if (chanceToSpawnRockWhenMined_3_purchased) { lines[64].SetActive(true); }
            if (doubleXpGoldChance_2_purchased) { lines[71].SetActive(true); }
            if (increaseAndDecreaseMinignErea_purchased) { lines[61].SetActive(true); lines[63].SetActive(true); }

            increaseAndDecreaseMinignErea.SetActive(true);
            doubleXpGoldChance_2.SetActive(true);
            moreXP_3.SetActive(true);
            chanceToSpawnRockWhenMined_3.SetActive(true);

            if (biggerMiningErea_2_purchaseCount >= 5)
            {
                biggerMiningErea_2_LOCKED.SetActive(false);
                biggerMiningErea_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region biggerMiningErea_3
        if (biggerMiningErea_3_purchased)
        {
            lines[34].SetActive(true);
            lines[35].SetActive(true);
            lines[38].SetActive(true);

            if (spawnMoreRocks_3_purchased) { lines[24].SetActive(true); lines[19].SetActive(true); }
            if (marterialsWorthMore_2_purchased) { lines[39].SetActive(true); }
            if (spawnMoreRocks_3_purchased) { lines[37].SetActive(true); }
            if (spawnPickaxeEverySecond_3_purchased) { lines[26].SetActive(true); }
            if (spawnXRockEveryXSecond_1_purchased) { lines[26].SetActive(true); }

            spawnCopper.SetActive(true);
            improvedPickaxe_6.SetActive(true);
            spawnXRockEveryXSecond_1.SetActive(true);

            if (biggerMiningErea_3_purchaseCount >= 5)
            {
                biggerMiningErea_3_LOCKED.SetActive(false);
                biggerMiningErea_3.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region biggerMiningErea_4
        if (biggerMiningErea_4_purchased)
        {
            lines[86].SetActive(true);
            lines[87].SetActive(true);

            pickaxeDoubleDamageChance_2.SetActive(true);

            if (biggerMiningErea_4_purchaseCount >= 5)
            {
                biggerMiningErea_4_LOCKED.SetActive(false);
                biggerMiningErea_4.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region shootCircleChance
        if (shootCircleChance_purchased)
        {
            lines[51].SetActive(true);
            lines[52].SetActive(true);
            lines[55].SetActive(true);
            lines[59].SetActive(true);

            if (improvedPickaxe_1_purchased) { lines[56].SetActive(true); }
            if (goldChunk_1_purchased) { lines[57].SetActive(true); }
            if (biggerMiningErea_1_purchased) { lines[56].SetActive(true); lines[57].SetActive(true); }

            increaseAndDecreaseMinignErea.SetActive(true);
            intaMineChance_1.SetActive(true);
            chanceToMineRandomRock_3.SetActive(true);

            if (shootCircleChance_purchaseCount >= 1)
            {
                shootCircleChance_LOCKED.SetActive(false);
                shootCircleChance.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region increaseAndDecreaseMinignErea
        if (increaseAndDecreaseMinignErea_purchased)
        {
            lines[62].SetActive(true);
            lines[59].SetActive(true);
            lines[54].SetActive(true);
            lines[53].SetActive(true);

            if (shootCircleChance_purchased) { lines[58].SetActive(true); lines[60].SetActive(true); }

            shootCircleChance.SetActive(true);
            moreTime_3.SetActive(true);
            biggerMiningErea_2.SetActive(true);
            spawnPickaxeEverySecond_2.SetActive(true);

            if (increaseAndDecreaseMinignErea_purchaseCount >= 1)
            {
                increaseAndDecreaseMinignErea_LOCKED.SetActive(false);
                increaseAndDecreaseMinignErea.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //Spawn X rock every X
        #region All spawn X rock every X 

        #region spawnRockEveryXrock_1
        if (spawnRockEveryXrock_1_purchased)
        {
            lines[132].SetActive(true);
            lines[135].SetActive(true);
            lines[137].SetActive(true);
            lines[139].SetActive(true);

            if (spawnIron_purchased) { lines[140].SetActive(true); }
            if (fullCopper_1_purchased) { lines[133].SetActive(true); }

            moreXP_5.SetActive(true);
            spawnIron.SetActive(true);
            spawnMoreRocks_5.SetActive(true);
            chanceToSpawnRockWhenMined_5.SetActive(true);

            if (spawnRockEveryXrock_1_purchaseCount >= 1)
            {
                spawnRockEveryXrock_1_LOCKED.SetActive(false);
                spawnRockEveryXrock_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region spawnRockEveryXrock_2
        if (spawnRockEveryXrock_2_purchased)
        {
            if (spawnRockEveryXrock_2_purchaseCount >= 1)
            {
                spawnRockEveryXrock_2_LOCKED.SetActive(false);
                spawnRockEveryXrock_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region spawnRockEveryXrock_3
        if (spawnRockEveryXrock_3_purchased)
        {
            lines[170].SetActive(true);
            lines[169].SetActive(true);
            lines[171].SetActive(true);

            iridiumSpawn.SetActive(true);

            if (spawnRockEveryXrock_3_purchaseCount >= 1)
            {
                spawnRockEveryXrock_3_LOCKED.SetActive(false);
                spawnRockEveryXrock_3.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region spawnXRockEveryXSecond_1
        if (spawnXRockEveryXSecond_1_purchased)
        {
            lines[19].SetActive(true);
            lines[20].SetActive(true);
            lines[24].SetActive(true);
            lines[35].SetActive(true);

            if (chanceToSpawnRockWhenMined_2_purchased) { lines[33].SetActive(true); }
            if (doubleXpGoldChance_1_purchased) { lines[25].SetActive(true); }
            if (spawnMoreRocks_3_purchased) { lines[18].SetActive(true); }
            if (spawnMoreRocks_4_purchased) { lines[38].SetActive(true); lines[18].SetActive(true); }

            intaMineChance_2.SetActive(true);
            doubleXpGoldChance_1.SetActive(true);
            spawnMoreRocks_4.SetActive(true);
            biggerMiningErea_3.SetActive(true);

            if (spawnXRockEveryXSecond_1_purchaseCount >= 1)
            {
                spawnXRockEveryXSecond_1_LOCKED.SetActive(false);
                spawnXRockEveryXSecond_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region spawnXRockEveryXSecond_2
        if (spawnXRockEveryXSecond_2_purchased)
        {
            lines[133].SetActive(true);
            lines[129].SetActive(true);
            lines[128].SetActive(true);
            lines[125].SetActive(true);
            lines[131].SetActive(true);
            lines[130].SetActive(true);

            spawnIron.SetActive(true);
            spawnMoreRocks_5.SetActive(true);
            goldChunk_3.SetActive(true);

            if (spawnXRockEveryXSecond_2_purchaseCount >= 1)
            {
                spawnXRockEveryXSecond_2_LOCKED.SetActive(false);
                spawnXRockEveryXSecond_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region spawnXRockEveryXSecond_3
        if (spawnXRockEveryXSecond_3_purchased)
        {
            if (spawnXRockEveryXSecond_3_purchaseCount >= 1)
            {
                spawnXRockEveryXSecond_3_LOCKED.SetActive(false);
                spawnXRockEveryXSecond_3.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region chanceToSpawnRockWhenMined_1
        if (chanceToSpawnRockWhenMined_1_purchased)
        {
            lines[6].SetActive(true);
            lines[10].SetActive(true);
            lines[14].SetActive(true);
            lines[44].SetActive(true);

            if (spawnMoreRocks_2_purchased) { lines[13].SetActive(true); }
            if (marterialsWorthMore_2_purchased) { lines[37].SetActive(true); }

            spawnMoreRocks_4.SetActive(true);
            marterialsWorthMore_2.SetActive(true);

            if (chanceToSpawnRockWhenMined_1_purchaseCount >= 3)
            {
                chanceToSpawnRockWhenMined_1_LOCKED.SetActive(false);
                chanceToSpawnRockWhenMined_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region chanceToSpawnRockWhenMined_2
        if (chanceToSpawnRockWhenMined_2_purchased)
        {
            lines[31].SetActive(true);
            lines[30].SetActive(true);
            lines[29].SetActive(true);
            lines[28].SetActive(true);

            if (spawnPickaxeEverySecond_3_purchased) { lines[32].SetActive(true); lines[33].SetActive(true); }

            doubleXpGoldChance_5.SetActive(true);
            marterialsWorthMore_4.SetActive(true);
            moreMeterialsFromRock_2.SetActive(true);

            if (chanceToSpawnRockWhenMined_2_purchaseCount >= 3)
            {
                chanceToSpawnRockWhenMined_2_LOCKED.SetActive(false);
                chanceToSpawnRockWhenMined_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region chanceToSpawnRockWhenMined_3
        if (chanceToSpawnRockWhenMined_3_purchased)
        {
            lines[67].SetActive(true);
            lines[71].SetActive(true);
            lines[72].SetActive(true);

            if (biggerMiningErea_2_purchased) { lines[65].SetActive(true); lines[67].SetActive(true); }
            if (spawnPickaxeEverySecond_2_purchased) { lines[64].SetActive(true); }
            if (increaseAndDecreaseMinignErea_purchased) { lines[66].SetActive(true); }

            doubleXpGoldChance_4.SetActive(true);
            marterialsWorthMore_5.SetActive(true);
            moreMeterialsFromRock_3.SetActive(true);

            if (chanceToSpawnRockWhenMined_3_purchaseCount >= 3)
            {
                chanceToSpawnRockWhenMined_3_LOCKED.SetActive(false);
                chanceToSpawnRockWhenMined_3.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region chanceToSpawnRockWhenMined_4
        if (chanceToSpawnRockWhenMined_4_purchased)
        {
            lines[99].SetActive(true);

            dynamiteChance_1.SetActive(true);
         
            if (chanceToSpawnRockWhenMined_4_purchaseCount >= 3)
            {
                chanceToSpawnRockWhenMined_4_LOCKED.SetActive(false);
                chanceToSpawnRockWhenMined_4.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region chanceToSpawnRockWhenMined_5
        if (chanceToSpawnRockWhenMined_5_purchased)
        {
            lines[137].SetActive(true);
            lines[136].SetActive(true);

            if (spawnRockEveryXrock_1_purchased) { lines[138].SetActive(true); }

            talentPointsPerXlevel_2.SetActive(true);

            if (chanceToSpawnRockWhenMined_5_purchaseCount >= 3)
            {
                chanceToSpawnRockWhenMined_5_LOCKED.SetActive(false);
                chanceToSpawnRockWhenMined_5.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region chanceToSpawnRockWhenMined_6
        if (chanceToSpawnRockWhenMined_6_purchased)
        {
            lines[166].SetActive(true);
            lines[162].SetActive(true);

            if (moreMeterialsFromRock_4_purchased) { lines[163].SetActive(true); }

            fullCopper_2.SetActive(true);

            if (chanceToSpawnRockWhenMined_6_purchaseCount >= 3)
            {
                chanceToSpawnRockWhenMined_6_LOCKED.SetActive(false);
                chanceToSpawnRockWhenMined_6.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //Spawn pickaxes
        #region All spawn pickaxes

        #region chanceToMineRandomRock_1
        if (chanceToMineRandomRock_1_purchased)
        {
            lines[73].SetActive(true);
            lines[77].SetActive(true);
            lines[79].SetActive(true);

            if (spawnMoreRocks_2_purchased) { lines[74].SetActive(true); }
            if (improvedPickaxe_1_purchased) { lines[74].SetActive(true); }

            improvedPickaxe_1.SetActive(true);
            improvedPickaxe_2.SetActive(true);
            moreTime_1.SetActive(true);

            if (chanceToMineRandomRock_1_purchaseCount >= 3)
            {
                chanceToMineRandomRock_1_LOCKED.SetActive(false);
                chanceToMineRandomRock_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region chanceToMineRandomRock_2
        if (chanceToMineRandomRock_2_purchased)
        {
            if (chanceToMineRandomRock_2_purchaseCount >= 3)
            {
                chanceToMineRandomRock_2_LOCKED.SetActive(false);
                chanceToMineRandomRock_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region chanceToMineRandomRock_3
        if (chanceToMineRandomRock_3_purchased)
        {
            lines[52].SetActive(true);
            lines[57].SetActive(true);
            lines[58].SetActive(true);

            if (shootCircleChance_purchased) { lines[53].SetActive(true); }
            if (fullGold_1_purchased) { lines[55].SetActive(true); }
            if (moreTime_3_purchased) { lines[53].SetActive(true); }

            fullGold_1.SetActive(true);
            shootCircleChance.SetActive(true);
            spawnPickaxeEverySecond_2.SetActive(true);

            if (chanceToMineRandomRock_3_purchaseCount >= 3)
            {
                chanceToMineRandomRock_3_LOCKED.SetActive(false);
                chanceToMineRandomRock_3.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region chanceToMineRandomRock_4
        if (chanceToMineRandomRock_4_purchased)
        {
            if (chanceToMineRandomRock_4_purchaseCount >= 3)
            {
                chanceToMineRandomRock_4_LOCKED.SetActive(false);
                chanceToMineRandomRock_4.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region spawnPickaxeEverySecond_1
        if (spawnPickaxeEverySecond_1_purchased)
        {
            lines[88].SetActive(true);
            lines[86].SetActive(true);
            lines[85].SetActive(true);


            biggerMiningErea_4.SetActive(true);
            chanceToAdd1SecondEverySecond.SetActive(true);

            if (spawnPickaxeEverySecond_1_purchaseCount >= 1)
            {
                spawnPickaxeEverySecond_1_LOCKED.SetActive(false);
                spawnPickaxeEverySecond_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region spawnPickaxeEverySecond_2
        if (spawnPickaxeEverySecond_2_purchased)
        {
            lines[63].SetActive(true);
            lines[58].SetActive(true);
            lines[53].SetActive(true);

            if (goldChunk_1_purchased) { lines[57].SetActive(true); }
            if (intaMineChance_1_purchased) { lines[52].SetActive(true); }

            if (chanceToMineRandomRock_3_purchased) { lines[59].SetActive(true); }
            if (increaseAndDecreaseMinignErea_purchased) { lines[70].SetActive(true); }

            increaseAndDecreaseMinignErea.SetActive(true);
            doubleXpGoldChance_2.SetActive(true);
            chanceToMineRandomRock_3.SetActive(true);

            if (spawnPickaxeEverySecond_2_purchaseCount >= 1)
            {
                spawnPickaxeEverySecond_2_LOCKED.SetActive(false);
                spawnPickaxeEverySecond_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region spawnPickaxeEverySecond_3
        if (spawnPickaxeEverySecond_3_purchased)
        {
            lines[31].SetActive(true);
            lines[27].SetActive(true);
            lines[25].SetActive(true);
            lines[21].SetActive(true);

            if (spawnMoreRocks_4_purchased) { lines[20].SetActive(true); }
            if (doubleXpGoldChance_1_purchased) { lines[20].SetActive(true); lines[22].SetActive(true); }
            if (moreTime_4_purchased) { lines[28].SetActive(true); }

            moreTime_4.SetActive(true);
            doubleXpGoldChance_1.SetActive(true);
            intaMineChance_2.SetActive(true);
            chanceToSpawnRockWhenMined_2.SetActive(true);

            if (spawnPickaxeEverySecond_3_purchaseCount >= 1)
            {
                spawnPickaxeEverySecond_3_LOCKED.SetActive(false);
                spawnPickaxeEverySecond_3.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //More time
        #region All more time

        #region moreTime_1
        if (moreTime_1_purchased)
        {
            lines[74].SetActive(true);
            lines[75].SetActive(true);
            lines[79].SetActive(true);

            if (moreXP_1_purchased) { lines[73].SetActive(true); }
            if (chanceToMineRandomRock_1_purchased) { lines[80].SetActive(true); }

            moreTime_2.SetActive(true);
            moreXP_1.SetActive(true);
            chanceToMineRandomRock_1.SetActive(true);

            if (moreTime_1_purchaseCount >= 5)
            {
                moreTime_1_LOCKED.SetActive(false);
                moreTime_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region moreTime_2
        if (moreTime_2_purchased)
        {
            lines[80].SetActive(true);
            lines[82].SetActive(true);
            lines[75].SetActive(true);
            lines[76].SetActive(true);

            if (moreTime_1_purchased) { lines[77].SetActive(true); }
            if (improvedPickaxe_1_purchased) { lines[77].SetActive(true); }

            moreTime_1.SetActive(true);
            improvedPickaxe_2.SetActive(true);
            improvedPickaxe_3.SetActive(true);
            chanceToAdd1SecondEverySecond.SetActive(true);

            if (moreTime_2_purchaseCount >= 5)
            {
                moreTime_2_LOCKED.SetActive(false);
                moreTime_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region moreTime_3
        if (moreTime_3_purchased)
        {
            lines[61].SetActive(true);
            lines[60].SetActive(true);
            lines[54].SetActive(true);

            if (chanceToSpawnRockWhenMined_3_purchased) { lines[65].SetActive(true); }
            if (intaMineChance_1_purchased) { lines[59].SetActive(true); }
            if (increaseAndDecreaseMinignErea_purchased) { lines[68].SetActive(true); }

            intaMineChance_1.SetActive(true);
            increaseAndDecreaseMinignErea.SetActive(true);
            moreXP_3.SetActive(true);

            if (moreTime_3_purchaseCount >= 5)
            {
                moreTime_3_LOCKED.SetActive(false);
                moreTime_3.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region moreTime_4
        if (moreTime_4_purchased)
        {
            lines[32].SetActive(true);
            lines[27].SetActive(true);
            lines[22].SetActive(true);

            if (spawnXRockEveryXSecond_1_purchased) { lines[25].SetActive(true); }
            if (talentPointsPerXlevel_1_purchased) { lines[21].SetActive(true); }

            marterialsWorthMore_4.SetActive(true);
            spawnPickaxeEverySecond_3.SetActive(true);
            talentPointsPerXlevel_1.SetActive(true);

            if (moreTime_4_purchaseCount >= 5)
            {
                moreTime_4_LOCKED.SetActive(false);
                moreTime_4.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region chanceToAdd1SecondEverySecond
        if (chanceToAdd1SecondEverySecond_purchased)
        {
            lines[88].SetActive(true);
            lines[82].SetActive(true);

            if (moreTime_2_purchased) { lines[85].SetActive(true); }
            spawnPickaxeEverySecond_1.SetActive(true);

            if (chanceToAdd1SecondEverySecond_purchaseCount >= 1)
            {
                chanceToAdd1SecondEverySecond_LOCKED.SetActive(false);
                chanceToAdd1SecondEverySecond.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region chanceAdd1SecondEveryRockMined
        if (chanceAdd1SecondEveryRockMined_purchased)
        {
            lines[143].SetActive(true);
            lines[142].SetActive(true);

            if (ironChunk_1_purchased) { lines[149].SetActive(true); }

            marterialsWorthMore_7.SetActive(true);
            spawnRockEveryXrock_2.SetActive(true);

            if (chanceAdd1SecondEveryRockMined_purchaseCount >= 1)
            {
                chanceAdd1SecondEveryRockMined_LOCKED.SetActive(false);
                chanceAdd1SecondEveryRockMined.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //Double XP and material chance
        #region All double XP and material chance

        #region doubleXpGoldChance_1
        if (doubleXpGoldChance_1_purchased)
        {
            lines[24].SetActive(true);
            lines[23].SetActive(true);
            lines[21].SetActive(true);
            lines[18].SetActive(true);

            if (spawnMoreRocks_3_purchased) { lines[17].SetActive(true); lines[19].SetActive(true); }
            if (spawnXRockEveryXSecond_1_purchased) { lines[25].SetActive(true); }
            if (moreTime_4_purchased) { lines[27].SetActive(true); }

            talentPointsPerXlevel_1.SetActive(true);
            spawnMoreRocks_3.SetActive(true);
            spawnXRockEveryXSecond_1.SetActive(true);
            spawnPickaxeEverySecond_3.SetActive(true);

            if (doubleXpGoldChance_1_purchaseCount >= 3)
            {
                doubleXpGoldChance_1_LOCKED.SetActive(false);
                doubleXpGoldChance_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region doubleXpGoldChance_2
        if (doubleXpGoldChance_2_purchased)
        {
            lines[70].SetActive(true);
            lines[64].SetActive(true);
            lines[63].SetActive(true);

            if (moreTime_3_purchased) { lines[62].SetActive(true); lines[68].SetActive(true); }
            if (spawnPickaxeEverySecond_2_purchased) { lines[62].SetActive(true); }
            if (increaseAndDecreaseMinignErea_purchased) { lines[71].SetActive(true); }

            biggerMiningErea_2.SetActive(true);
            marterialsWorthMore_5.SetActive(true);
            spawnPickaxeEverySecond_2.SetActive(true);

            if (doubleXpGoldChance_2_purchaseCount >= 3)
            {
                doubleXpGoldChance_2_LOCKED.SetActive(false);
                doubleXpGoldChance_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region doubleXpGoldChance_3
        if (doubleXpGoldChance_3_purchased)
        {
            lines[49].SetActive(true);
            lines[48].SetActive(true);
            lines[42].SetActive(true);

            if (marterialsWorthMore_1_purchased) { lines[46].SetActive(true); }
            if (goldChunk_1_purchased) { lines[46].SetActive(true); }

            goldChunk_2.SetActive(true);
            marterialsWorthMore_3.SetActive(true);
            moreMeterialsFromRock_1.SetActive(true);

            if (doubleXpGoldChance_3_purchaseCount >= 3)
            {
                doubleXpGoldChance_3_LOCKED.SetActive(false);
                doubleXpGoldChance_3.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region doubleXpGoldChance_4
        if (doubleXpGoldChance_4_purchased)
        {
            if (doubleXpGoldChance_4_purchaseCount >= 3)
            {
                doubleXpGoldChance_4_LOCKED.SetActive(false);
                doubleXpGoldChance_4.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region doubleXpGoldChance_5
        if (doubleXpGoldChance_5_purchased)
        {
            if (doubleXpGoldChance_5_purchaseCount >= 3)
            {
                doubleXpGoldChance_5_LOCKED.SetActive(false);
                doubleXpGoldChance_5.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //Lightning beam
        #region All lightning beam

        #region lightningBeamChanceS_1
        if (lightningBeamChanceS_1_purchased)
        {
            lines[84].SetActive(true);
            lines[81].SetActive(true);
            lines[78].SetActive(true);

            if (moreTime_1_purchased) { lines[76].SetActive(true); }
            if (improvedPickaxe_2_purchased) { lines[89].SetActive(true); lines[76].SetActive(true); }

            improvedPickaxe_2.SetActive(true);
            improvedPickaxe_3.SetActive(true);
            lightningBeamDamage.SetActive(true);

            if (lightningBeamChanceS_1_purchaseCount >= 5)
            {
                lightningBeamChanceS_1_LOCKED.SetActive(false);
                lightningBeamChanceS_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region lightningBeamChanceS_2
        if (lightningBeamChanceS_2_purchased)
        {
            lines[95].SetActive(true);
            lines[92].SetActive(true);
            lines[91].SetActive(true);

            lightningBeamChancePH_2.SetActive(true);
            lightningSplashes.SetActive(true);

            if (lightningBeamChanceS_2_purchaseCount >= 5)
            {
                lightningBeamChanceS_2_LOCKED.SetActive(false);
                lightningBeamChanceS_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region lightningBeamChancePH_1
        if (lightningBeamChancePH_1_purchased)
        {
            lines[89].SetActive(true);
            lines[83].SetActive(true);

            if (improvedPickaxe_2_purchased) { lines[84].SetActive(true); }

            lightningBeamDamage.SetActive(true);

            if (lightningBeamChancePH_1_purchaseCount >= 3)
            {
                lightningBeamChancePH_1_LOCKED.SetActive(false);
                lightningBeamChancePH_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region lightningBeamChancePH_2
        if (lightningBeamChancePH_2_purchased)
        {
            lines[96].SetActive(true);

            lightningBeamAddTime.SetActive(true);

            if (lightningBeamChancePH_2_purchaseCount >= 3)
            {
                lightningBeamChancePH_2_LOCKED.SetActive(false);
                lightningBeamChancePH_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region lightningBeamSpawnAnotherOneChance
        if (lightningBeamSpawnAnotherOneChance_purchased)
        {
            if (lightningBeamSpawnAnotherOneChance_purchaseCount >= 1)
            {
                lightningBeamSpawnAnotherOneChance_LOCKED.SetActive(false);
                lightningBeamSpawnAnotherOneChance.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region lightningBeamDamage
        if (lightningBeamDamage_purchased)
        {
            lines[90].SetActive(true);
            lines[89].SetActive(true);
            lines[84].SetActive(true);

            if (moreTime_2_purchased) { lines[83].SetActive(true); }
            if (lightningBeamChanceS_1_purchased) { lines[83].SetActive(true); }

            lightningBeamSize.SetActive(true);
            lightningBeamChancePH_1.SetActive(true);

            if (lightningBeamDamage_purchaseCount >= 3)
            {
                lightningBeamDamage_LOCKED.SetActive(false);
                lightningBeamDamage.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region lightningBeamSize
        if (lightningBeamSize_purchased)
        {
            lines[91].SetActive(true);

            lightningBeamChanceS_2.SetActive(true);

            if (lightningBeamSize_purchaseCount >= 3)
            {
                lightningBeamSize_LOCKED.SetActive(false);
                lightningBeamSize.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region lightningSplashes
        if (lightningSplashes_purchased)
        {
            lines[92].SetActive(true);
            lines[93].SetActive(true);
            lines[94].SetActive(true);

            lightningBeamSpawnRock.SetActive(true);
            lightningBeamSpawnAnotherOneChance.SetActive(true);

            if (lightningSplashes_purchaseCount >= 1)
            {
                lightningSplashes_LOCKED.SetActive(false);
                lightningSplashes.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region lightningBeamSpawnRock
        if (lightningBeamSpawnRock_purchased)
        {
            if (lightningBeamSpawnRock_purchaseCount >= 1)
            {
                lightningBeamSpawnRock_LOCKED.SetActive(false);
                lightningBeamSpawnRock.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region lightningBeamExplosion
        if (lightningBeamExplosion_purchased)
        {
            if (lightningBeamExplosion_purchaseCount >= 1)
            {
                lightningBeamExplosion_LOCKED.SetActive(false);
                lightningBeamExplosion.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region lightningBeamAddTime
        if (lightningBeamAddTime_purchased)
        {
            lines[97].SetActive(true);

            lightningBeamExplosion.SetActive(true);

            if (lightningBeamAddTime_purchaseCount >= 1)
            {
                lightningBeamAddTime_LOCKED.SetActive(false);
                lightningBeamAddTime.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //Dynamite
        #region All dynamite

        #region dynamiteChance_1
        if (dynamiteChance_1_purchased)
        {
            lines[99].SetActive(true);
            lines[100].SetActive(true);
            lines[101].SetActive(true);
            lines[102].SetActive(true);

            dynamiteExplosionSize.SetActive(true);
            dynamiteSpawn2SmallChance.SetActive(true);
            dynamiteDamage.SetActive(true);

            if (dynamiteChance_1_purchaseCount >= 3)
            {
                dynamiteChance_1_LOCKED.SetActive(false);
                dynamiteChance_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region dynamiteChance_2
        if (dynamiteChance_2_purchased)
        {
            lines[103].SetActive(true);
            lines[104].SetActive(true);
            lines[113].SetActive(true);

            if (dynamiteSpawn2SmallChance_purchased) { lines[107].SetActive(true); }

            dynamiteExplosionAddTimeChance.SetActive(true);
            plazmaBallSpawn_1.SetActive(true);

            if (dynamiteChance_2_purchaseCount >= 3)
            {
                dynamiteChance_2_LOCKED.SetActive(false);
                dynamiteChance_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region dynamiteSpawn2SmallChance
        if (dynamiteSpawn2SmallChance_purchased)
        {
            lines[102].SetActive(true);
            lines[103].SetActive(true);
            lines[112].SetActive(true);

            lines[106].SetActive(true);

            dynamiteChance_2.SetActive(true);
            dynamiteExplosionSpawnRock.SetActive(true);

            if (dynamiteSpawn2SmallChance_purchaseCount >= 1)
            {
                dynamiteSpawn2SmallChance_LOCKED.SetActive(false);
                dynamiteSpawn2SmallChance.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region dynamiteExplosionSize
        if (dynamiteExplosionSize_purchased)
        {
            if (dynamiteExplosionSize_purchaseCount >= 3)
            {
                dynamiteExplosionSize_LOCKED.SetActive(false);
                dynamiteExplosionSize.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region dynamiteDamage
        if (dynamiteDamage_purchased)
        {
            lines[101].SetActive(true);
            lines[106].SetActive(true);
            lines[112].SetActive(true);

            dynamiteExplosionSpawnRock.SetActive(true);

            if (dynamiteDamage_purchaseCount >= 3)
            {
                dynamiteDamage_LOCKED.SetActive(false);
                dynamiteDamage.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region dynamiteExplosionSpawnRock
        if (dynamiteExplosionSpawnRock_purchased)
        {
            lines[106].SetActive(true);
            lines[107].SetActive(true);
            lines[112].SetActive(true);

            if (dynamiteSpawn2SmallChance_purchased) { lines[113].SetActive(true); }

            dynamiteExplosionAddTimeChance.SetActive(true);

            if (dynamiteExplosionSpawnRock_purchaseCount >= 1)
            {
                dynamiteExplosionSpawnRock_LOCKED.SetActive(false);
                dynamiteExplosionSpawnRock.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region dynamiteExplosionAddTimeChance
        if (dynamiteExplosionAddTimeChance_purchased)
        {
            lines[107].SetActive(true);
            lines[113].SetActive(true);
            lines[120].SetActive(true);
            lines[103].SetActive(true);

            dynamiteExplosionSpawnLightning.SetActive(true);
            dynamiteChance_2.SetActive(true);

            if (dynamiteExplosionAddTimeChance_purchaseCount >= 1)
            {
                dynamiteExplosionAddTimeChance_LOCKED.SetActive(false);
                dynamiteExplosionAddTimeChance.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region dynamiteExplosionSpawnLightning
        if (dynamiteExplosionSpawnLightning_purchased)
        {
            lines[119].SetActive(true);
            lines[120].SetActive(true);

            allProjectileDoubleDamageChance.SetActive(true);

            if (dynamiteExplosionSpawnLightning_purchaseCount >= 1)
            {
                dynamiteExplosionSpawnLightning_LOCKED.SetActive(false);
                dynamiteExplosionSpawnLightning.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //Plazma balls
        #region All plazma balls

        #region plazmaBallSpawn_1
        if (plazmaBallSpawn_1_purchased)
        {
            lines[104].SetActive(true);
            lines[105].SetActive(true);
            lines[116].SetActive(true);

            plazmaBallSize.SetActive(true);
            plazmaBallTime.SetActive(true);

            if (plazmaBallSpawn_1_purchaseCount >= 3)
            {
                plazmaBallSpawn_1_LOCKED.SetActive(false);
                plazmaBallSpawn_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region plazmaBallSpawn_2
        if (plazmaBallSpawn_2_purchased)
        {
            lines[110].SetActive(true);

            plazmaBallExplosionChance.SetActive(true);

            if (plazmaBallSpawn_2_purchaseCount >= 3)
            {
                plazmaBallSpawn_2_LOCKED.SetActive(false);
                plazmaBallSpawn_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region plazmaBallTime
        if (plazmaBallTime_purchased)
        {
            lines[114].SetActive(true);
            lines[116].SetActive(true);
            lines[118].SetActive(true);

            if (plazmaBallSpawn_1_purchased) { lines[117].SetActive(true); }

            plazmaBallDamage.SetActive(true);
            plazmaBallSpawnSmallChance.SetActive(true);

            if (plazmaBallTime_purchaseCount >= 3)
            {
                plazmaBallTime_LOCKED.SetActive(false);
                plazmaBallTime.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region plazmaBallSize
        if (plazmaBallSize_purchased)
        {
            lines[117].SetActive(true);
            lines[115].SetActive(true);
            lines[105].SetActive(true);

            if (plazmaBallSpawn_1_purchased) { lines[118].SetActive(true); }

            plazmaBallSpawnSmallChance.SetActive(true);
            plazmaBallSpawn_2.SetActive(true);

            if (plazmaBallSize_purchaseCount >= 3)
            {
                plazmaBallSize_LOCKED.SetActive(false);
                plazmaBallSize.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region plazmaBallExplosionChance
        if (plazmaBallExplosionChance_purchased)
        {
            lines[111].SetActive(true);

            plazmaBallSpawnPickaxeChance.SetActive(true);

            if (plazmaBallExplosionChance_purchaseCount >= 1)
            {
                plazmaBallExplosionChance_LOCKED.SetActive(false);
                plazmaBallExplosionChance.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region plazmaBallSpawnSmallChance
        if (plazmaBallSpawnSmallChance_purchased)
        {
            lines[117].SetActive(true);
            lines[118].SetActive(true);

            plazmaBallTime.SetActive(true);
            plazmaBallSize.SetActive(true);

            if (plazmaBallSpawnSmallChance_purchaseCount >= 1)
            {
                plazmaBallSpawnSmallChance_LOCKED.SetActive(false);
                plazmaBallSpawnSmallChance.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region plazmaBallDamage
        if (plazmaBallDamage_purchased)
        {
            if (plazmaBallDamage_purchaseCount >= 5)
            {
                plazmaBallDamage_LOCKED.SetActive(false);
                plazmaBallDamage.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region plazmaBallSpawnPickaxeChance
        if (plazmaBallSpawnPickaxeChance_purchased)
        {
            if (plazmaBallSpawnPickaxeChance_purchaseCount >= 1)
            {
                plazmaBallSpawnPickaxeChance_LOCKED.SetActive(false);
                plazmaBallSpawnPickaxeChance.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #endregion

        //Misc
        #region All misc

        #region allProjectileDoubleDamageChance
        if (allProjectileDoubleDamageChance_purchased)
        {
            lines[122].SetActive(true);
          

            allProjectileTriggerChance.SetActive(true);

            if (allProjectileDoubleDamageChance_purchaseCount >= 1)
            {
                allProjectileDoubleDamageChance_LOCKED.SetActive(false);
                allProjectileDoubleDamageChance.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region allProjectileTriggerChance
        if (allProjectileTriggerChance_purchased)
        {

            if (allProjectileTriggerChance_purchaseCount >= 1)
            {
                allProjectileTriggerChance_LOCKED.SetActive(false);
                allProjectileTriggerChance.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region pickaxeDoubleDamageChance_1
        if (pickaxeDoubleDamageChance_1_purchased)
        {
            lines[4].SetActive(true);
            lines[9].SetActive(true);
            lines[56].SetActive(true);

            if (biggerMiningErea_1_purchased) { lines[51].SetActive(true); }
            if (chanceToMineRandomRock_3_purchased) { lines[51].SetActive(true); }

            improvedPickaxe_1.SetActive(true);
            biggerMiningErea_1.SetActive(true);
            intaMineChance_1.SetActive(true);

            if (pickaxeDoubleDamageChance_1_purchaseCount >= 3)
            {
                pickaxeDoubleDamageChance_1_LOCKED.SetActive(false);
                pickaxeDoubleDamageChance_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region pickaxeDoubleDamageChance_2
        if (pickaxeDoubleDamageChance_2_purchased)
        {
            if (pickaxeDoubleDamageChance_2_purchaseCount >= 3)
            {

                pickaxeDoubleDamageChance_2_LOCKED.SetActive(false);
                pickaxeDoubleDamageChance_2.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region intaMineChance_1
        if (intaMineChance_1_purchased)
        {
            lines[51].SetActive(true);
            lines[56].SetActive(true);
            lines[60].SetActive(true);
            lines[55].SetActive(true);

            if (biggerMiningErea_2_purchased) { lines[54].SetActive(true); lines[61].SetActive(true); }
            if (spawnPickaxeEverySecond_2_purchased) { lines[54].SetActive(true); }
            if (fullGold_1_purchased) { lines[52].SetActive(true); }
            if (shootCircleChance_purchased) { lines[54].SetActive(true); }

            pickaxeDoubleDamageChance_1.SetActive(true);
            shootCircleChance.SetActive(true);
            moreTime_3.SetActive(true);

            if (intaMineChance_1_purchaseCount >= 3)
            {
                intaMineChance_1_LOCKED.SetActive(false);
                intaMineChance_1.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region intaMineChance_2
        if (intaMineChance_2_purchased)
        {
            lines[20].SetActive(true);
            lines[25].SetActive(true);
            lines[26].SetActive(true);
            lines[33].SetActive(true);

            if (spawnXRockEveryXSecond_1_purchased) { lines[34].SetActive(true); }
            if (spawnPickaxeEverySecond_3_purchased) { lines[29].SetActive(true); }
            if (spawnMoreRocks_3_purchased) { lines[21].SetActive(true); }
            if (talentPointsPerXlevel_1_purchased) { lines[27].SetActive(true); }

            moreMeterialsFromRock_2.SetActive(true);
            improvedPickaxe_6.SetActive(true);
            spawnXRockEveryXSecond_1.SetActive(true);
            spawnPickaxeEverySecond_3.SetActive(true);

            if (intaMineChance_2_purchaseCount >= 3)
            {
                intaMineChance_2_LOCKED.SetActive(false);
                intaMineChance_2.GetComponent<Button>().enabled = false; //140
            }
        }
        #endregion

        #region increaseSpawnChanceAllRocks
        if (increaseSpawnChanceAllRocks_purchased)
        {
            lines[168].SetActive(true);
            lines[171].SetActive(true);
            lines[179].SetActive(true);
            lines[181].SetActive(true);
            lines[169].SetActive(true);

            ismiumSpawn.SetActive(true);
            iridiumSpawn.SetActive(true);
            painiteSpawn.SetActive(true);

            if (increaseSpawnChanceAllRocks_purchaseCount >= 1)
            {
                increaseSpawnChanceAllRocks_LOCKED.SetActive(false);
                increaseSpawnChanceAllRocks.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region craft2Material
        if (craft2Material_purchased)
        {
            if (craft2Material_purchaseCount >= 1)
            {
                craft2Material_LOCKED.SetActive(false);
                craft2Material.GetComponent<Button>().enabled = false;
            }
        }
        #endregion

        #region finalUpgrade
        if (finalUpgrade_purchased)
        {
            if (finalUpgrade_purchaseCount >= 1)
            {
                finalUpgrade_LOCKED.SetActive(false);
                finalUpgrade.GetComponent<Button>().enabled = false;

                endingButton.SetActive(true);
            }
        }
        #endregion

        #endregion
    }

    public void PlayErrorSound()
    {
        //Cannot purchase
    }

    #region Load Data
    public void LoadData(GameData data)
    {
        moreTime_1_purchased = data.moreTime_1_purchased;
        moreTime_2_purchased = data.moreTime_2_purchased;
        moreTime_3_purchased = data.moreTime_3_purchased;
        moreTime_4_purchased = data.moreTime_4_purchased;
        chanceToAdd1SecondEverySecond_purchased = data.chanceToAdd1SecondEverySecond_purchased;
        chanceAdd1SecondEveryRockMined_purchased = data.chanceAdd1SecondEveryRockMined_purchased;

        totalMaterialRocksSpawning = data.totalMaterialRocksSpawning;

        moreXP_1_purchased = data.moreXP_1_purchased;
        moreXP_2_purchased = data.moreXP_2_purchased;
        moreXP_3_purchased = data.moreXP_3_purchased;
        moreXP_4_purchased = data.moreXP_4_purchased;
        moreXP_5_purchased = data.moreXP_5_purchased;
        moreXP_6_purchased = data.moreXP_6_purchased;
        moreXP_7_purchased = data.moreXP_7_purchased;
        moreXP_8_purchased = data.moreXP_8_purchased; //8

        talentPointsPerXlevel_1_purchased = data.talentPointsPerXlevel_1_purchased;
        talentPointsPerXlevel_2_purchased = data.talentPointsPerXlevel_2_purchased;
        talentPointsPerXlevel_3_purchased = data.talentPointsPerXlevel_3_purchased; //3

        spawnMoreRocks_1_purchased = data.spawnMoreRocks_1_purchased;
        spawnMoreRocks_2_purchased = data.spawnMoreRocks_2_purchased;
        spawnMoreRocks_3_purchased = data.spawnMoreRocks_3_purchased;
        spawnMoreRocks_4_purchased = data.spawnMoreRocks_4_purchased;
        spawnMoreRocks_5_purchased = data.spawnMoreRocks_5_purchased;
        spawnMoreRocks_6_purchased = data.spawnMoreRocks_6_purchased;
        spawnMoreRocks_7_purchased = data.spawnMoreRocks_7_purchased;
        spawnMoreRocks_8_purchased = data.spawnMoreRocks_8_purchased;
        spawnMoreRocks_9_purchased = data.spawnMoreRocks_9_purchased; //9

        moreMeterialsFromRock_1_purchased = data.moreMeterialsFromRock_1_purchased;
        moreMeterialsFromRock_2_purchased = data.moreMeterialsFromRock_2_purchased;
        moreMeterialsFromRock_3_purchased = data.moreMeterialsFromRock_3_purchased;
        moreMeterialsFromRock_4_purchased = data.moreMeterialsFromRock_4_purchased;
        moreMeterialsFromRock_5_purchased = data.moreMeterialsFromRock_5_purchased; //5

        marterialsWorthMore_1_purchased = data.marterialsWorthMore_1_purchased;
        marterialsWorthMore_2_purchased = data.marterialsWorthMore_2_purchased;
        marterialsWorthMore_3_purchased = data.marterialsWorthMore_3_purchased;
        marterialsWorthMore_4_purchased = data.marterialsWorthMore_4_purchased;
        marterialsWorthMore_5_purchased = data.marterialsWorthMore_5_purchased;
        marterialsWorthMore_6_purchased = data.marterialsWorthMore_6_purchased;
        marterialsWorthMore_7_purchased = data.marterialsWorthMore_7_purchased;
        marterialsWorthMore_8_purchased = data.marterialsWorthMore_8_purchased; //8

        goldChunk_1_purchased = data.goldChunk_1_purchased;
        goldChunk_2_purchased = data.goldChunk_2_purchased;
        goldChunk_3_purchased = data.goldChunk_3_purchased;
        goldChunk_4_purchased = data.goldChunk_4_purchased;
        goldChunk_5_purchased = data.goldChunk_5_purchased;
        fullGold_1_purchased = data.fullGold_1_purchased;
        fullGold_2_purchased = data.fullGold_2_purchased;
        fullGold_3_purchased = data.fullGold_3_purchased; //8

        spawnCopper_purchased = data.spawnCopper_purchased;
        copperChunk_1_purchased = data.copperChunk_1_purchased;
        copperChunk_2_purchased = data.copperChunk_2_purchased;
        copperChunk_3_purchased = data.copperChunk_3_purchased;
        fullCopper_1_purchased = data.fullCopper_1_purchased;
        fullCopper_2_purchased = data.fullCopper_2_purchased;
        fullCopper_3_purchased = data.fullCopper_3_purchased; //7

        spawnIron_purchased = data.spawnIron_purchased;
        ironChunk_1_purchased = data.ironChunk_1_purchased;
        ironChunk_2_purchased = data.ironChunk_2_purchased;
        fullIron_1_purchased = data.fullIron_1_purchased;
        fullIron_2_purchased = data.fullIron_2_purchased; //5

        cobaltSpawn_purchased = data.cobaltSpawn_purchased;
        cobaltChunk_1_purchased = data.cobaltChunk_1_purchased;
        fullCobalt_1_purchased = data.fullCobalt_1_purchased; //3

        uraniumSpawn_purchased = data.uraniumSpawn_purchased;
        uraniumChunk_1_purchased = data.uraniumChunk_1_purchased;
        fullUranium_1_purchased = data.fullUranium_1_purchased; //3

        ismiumSpawn_purchased = data.ismiumSpawn_purchased;
        ismiumChunk_1_purchased = data.ismiumChunk_1_purchased;
        fullIsmium_1_purchased = data.fullIsmium_1_purchased; //3

        iridiumSpawn_purchased = data.iridiumSpawn_purchased;
        iridiumChunk_1_purchased = data.iridiumChunk_1_purchased;
        fullIridium_1_purchased = data.fullIridium_1_purchased; //3

        painiteSpawn_purchased = data.painiteSpawn_purchased;
        painiteChunk_1_purchased = data.painiteChunk_1_purchased;
        fullPainite_1_purchased = data.fullPainite_1_purchased; //3

        improvedPickaxe_1_purchased = data.improvedPickaxe_1_purchased;
        improvedPickaxe_2_purchased = data.improvedPickaxe_2_purchased;
        improvedPickaxe_3_purchased = data.improvedPickaxe_3_purchased;
        improvedPickaxe_4_purchased = data.improvedPickaxe_4_purchased;
        improvedPickaxe_5_purchased = data.improvedPickaxe_5_purchased;
        improvedPickaxe_6_purchased = data.improvedPickaxe_6_purchased; //6

        biggerMiningErea_1_purchased = data.biggerMiningErea_1_purchased;
        biggerMiningErea_2_purchased = data.biggerMiningErea_2_purchased;
        biggerMiningErea_3_purchased = data.biggerMiningErea_3_purchased;
        biggerMiningErea_4_purchased = data.biggerMiningErea_4_purchased;
        shootCircleChance_purchased = data.shootCircleChance_purchased;
        increaseAndDecreaseMinignErea_purchased = data.increaseAndDecreaseMinignErea_purchased; //6

        spawnRockEveryXrock_1_purchased = data.spawnRockEveryXrock_1_purchased;
        spawnRockEveryXrock_2_purchased = data.spawnRockEveryXrock_2_purchased;
        spawnRockEveryXrock_3_purchased = data.spawnRockEveryXrock_3_purchased; //3

        spawnXRockEveryXSecond_1_purchased = data.spawnXRockEveryXSecond_1_purchased;
        spawnXRockEveryXSecond_2_purchased = data.spawnXRockEveryXSecond_2_purchased;
        spawnXRockEveryXSecond_3_purchased = data.spawnXRockEveryXSecond_3_purchased; //3

        chanceToSpawnRockWhenMined_1_purchased = data.chanceToSpawnRockWhenMined_1_purchased;
        chanceToSpawnRockWhenMined_2_purchased = data.chanceToSpawnRockWhenMined_2_purchased;
        chanceToSpawnRockWhenMined_3_purchased = data.chanceToSpawnRockWhenMined_3_purchased;
        chanceToSpawnRockWhenMined_4_purchased = data.chanceToSpawnRockWhenMined_4_purchased;
        chanceToSpawnRockWhenMined_5_purchased = data.chanceToSpawnRockWhenMined_5_purchased;
        chanceToSpawnRockWhenMined_6_purchased = data.chanceToSpawnRockWhenMined_6_purchased; //6

        chanceToMineRandomRock_1_purchased = data.chanceToMineRandomRock_1_purchased;
        chanceToMineRandomRock_2_purchased = data.chanceToMineRandomRock_2_purchased;
        chanceToMineRandomRock_3_purchased = data.chanceToMineRandomRock_3_purchased;
        chanceToMineRandomRock_4_purchased = data.chanceToMineRandomRock_4_purchased; //4

        spawnPickaxeEverySecond_1_purchased = data.spawnPickaxeEverySecond_1_purchased;
        spawnPickaxeEverySecond_2_purchased = data.spawnPickaxeEverySecond_2_purchased;
        spawnPickaxeEverySecond_3_purchased = data.spawnPickaxeEverySecond_3_purchased; //3

        doubleXpGoldChance_1_purchased = data.doubleXpGoldChance_1_purchased;
        doubleXpGoldChance_2_purchased = data.doubleXpGoldChance_2_purchased;
        doubleXpGoldChance_3_purchased = data.doubleXpGoldChance_3_purchased;
        doubleXpGoldChance_4_purchased = data.doubleXpGoldChance_4_purchased;
        doubleXpGoldChance_5_purchased = data.doubleXpGoldChance_5_purchased; //5

        lightningBeamChanceS_1_purchased = data.lightningBeamChanceS_1_purchased;
        lightningBeamChanceS_2_purchased = data.lightningBeamChanceS_2_purchased;
        lightningBeamChancePH_1_purchased = data.lightningBeamChancePH_1_purchased;
        lightningBeamChancePH_2_purchased = data.lightningBeamChancePH_2_purchased;
        lightningBeamSpawnAnotherOneChance_purchased = data.lightningBeamSpawnAnotherOneChance_purchased;
        lightningBeamDamage_purchased = data.lightningBeamDamage_purchased;
        lightningBeamSize_purchased = data.lightningBeamSize_purchased;
        lightningSplashes_purchased = data.lightningSplashes_purchased;
        lightningBeamSpawnRock_purchased = data.lightningBeamSpawnRock_purchased;
        lightningBeamExplosion_purchased = data.lightningBeamExplosion_purchased;
        lightningBeamAddTime_purchased = data.lightningBeamAddTime_purchased; //11

        dynamiteChance_1_purchased = data.dynamiteChance_1_purchased;
        dynamiteChance_2_purchased = data.dynamiteChance_2_purchased;
        dynamiteSpawn2SmallChance_purchased = data.dynamiteSpawn2SmallChance_purchased;
        dynamiteExplosionSize_purchased = data.dynamiteExplosionSize_purchased;
        dynamiteDamage_purchased = data.dynamiteDamage_purchased;
        dynamiteExplosionSpawnRock_purchased = data.dynamiteExplosionSpawnRock_purchased;
        dynamiteExplosionAddTimeChance_purchased = data.dynamiteExplosionAddTimeChance_purchased;
        dynamiteExplosionSpawnLightning_purchased = data.dynamiteExplosionSpawnLightning_purchased; //8

        plazmaBallSpawn_1_purchased = data.plazmaBallSpawn_1_purchased;
        plazmaBallSpawn_2_purchased = data.plazmaBallSpawn_2_purchased;
        plazmaBallTime_purchased = data.plazmaBallTime_purchased;
        plazmaBallSize_purchased = data.plazmaBallSize_purchased;
        plazmaBallExplosionChance_purchased = data.plazmaBallExplosionChance_purchased;
        plazmaBallSpawnSmallChance_purchased = data.plazmaBallSpawnSmallChance_purchased;
        plazmaBallDamage_purchased = data.plazmaBallDamage_purchased;
        plazmaBallSpawnPickaxeChance_purchased = data.plazmaBallSpawnPickaxeChance_purchased; //8

        allProjectileDoubleDamageChance_purchased = data.allProjectileDoubleDamageChance_purchased;
        allProjectileTriggerChance_purchased = data.allProjectileTriggerChance_purchased;
        pickaxeDoubleDamageChance_1_purchased = data.pickaxeDoubleDamageChance_1_purchased;
        pickaxeDoubleDamageChance_2_purchased = data.pickaxeDoubleDamageChance_2_purchased;
        intaMineChance_1_purchased = data.intaMineChance_1_purchased;
        intaMineChance_2_purchased = data.intaMineChance_2_purchased;
        increaseSpawnChanceAllRocks_purchased = data.increaseSpawnChanceAllRocks_purchased;
        craft2Material_purchased = data.craft2Material_purchased;
        finalUpgrade_purchased = data.finalUpgrade_purchased; //9

        //Xp purchase count
        moreXP_1_purchaseCount = data.moreXP_1_purchaseCount;
        moreXP_2_purchaseCount = data.moreXP_2_purchaseCount;
        moreXP_3_purchaseCount = data.moreXP_3_purchaseCount;
        moreXP_4_purchaseCount = data.moreXP_4_purchaseCount;
        moreXP_5_purchaseCount = data.moreXP_5_purchaseCount;
        moreXP_6_purchaseCount = data.moreXP_6_purchaseCount;
        moreXP_7_purchaseCount = data.moreXP_7_purchaseCount;
        moreXP_8_purchaseCount = data.moreXP_8_purchaseCount;
        talentPointsPerXlevel_1_purchaseCount = data.talentPointsPerXlevel_1_purchaseCount;
        talentPointsPerXlevel_2_purchaseCount = data.talentPointsPerXlevel_2_purchaseCount;
        talentPointsPerXlevel_3_purchaseCount = data.talentPointsPerXlevel_3_purchaseCount;

        // Rocks and Materials (57)
        spawnMoreRocks_1_purchaseCount = data.spawnMoreRocks_1_purchaseCount;
        spawnMoreRocks_2_purchaseCount = data.spawnMoreRocks_2_purchaseCount;
        spawnMoreRocks_3_purchaseCount = data.spawnMoreRocks_3_purchaseCount;
        spawnMoreRocks_4_purchaseCount = data.spawnMoreRocks_4_purchaseCount;
        spawnMoreRocks_5_purchaseCount = data.spawnMoreRocks_5_purchaseCount;
        spawnMoreRocks_6_purchaseCount = data.spawnMoreRocks_6_purchaseCount;
        spawnMoreRocks_7_purchaseCount = data.spawnMoreRocks_7_purchaseCount;
        spawnMoreRocks_8_purchaseCount = data.spawnMoreRocks_8_purchaseCount;
        spawnMoreRocks_9_purchaseCount = data.spawnMoreRocks_9_purchaseCount;
        moreMeterialsFromRock_1_purchaseCount = data.moreMeterialsFromRock_1_purchaseCount;
        moreMeterialsFromRock_2_purchaseCount = data.moreMeterialsFromRock_2_purchaseCount;
        moreMeterialsFromRock_3_purchaseCount = data.moreMeterialsFromRock_3_purchaseCount;
        moreMeterialsFromRock_4_purchaseCount = data.moreMeterialsFromRock_4_purchaseCount;
        moreMeterialsFromRock_5_purchaseCount = data.moreMeterialsFromRock_5_purchaseCount;
        marterialsWorthMore_1_purchaseCount = data.marterialsWorthMore_1_purchaseCount;
        marterialsWorthMore_2_purchaseCount = data.marterialsWorthMore_2_purchaseCount;
        marterialsWorthMore_3_purchaseCount = data.marterialsWorthMore_3_purchaseCount;
        marterialsWorthMore_4_purchaseCount = data.marterialsWorthMore_4_purchaseCount;
        marterialsWorthMore_5_purchaseCount = data.marterialsWorthMore_5_purchaseCount;
        marterialsWorthMore_6_purchaseCount = data.marterialsWorthMore_6_purchaseCount;
        marterialsWorthMore_7_purchaseCount = data.marterialsWorthMore_7_purchaseCount;
        marterialsWorthMore_8_purchaseCount = data.marterialsWorthMore_8_purchaseCount;
        goldChunk_1_purchaseCount = data.goldChunk_1_purchaseCount;
        goldChunk_2_purchaseCount = data.goldChunk_2_purchaseCount;
        goldChunk_3_purchaseCount = data.goldChunk_3_purchaseCount;
        goldChunk_4_purchaseCount = data.goldChunk_4_purchaseCount;
        goldChunk_5_purchaseCount = data.goldChunk_5_purchaseCount;
        fullGold_1_purchaseCount = data.fullGold_1_purchaseCount;
        fullGold_2_purchaseCount = data.fullGold_2_purchaseCount;
        fullGold_3_purchaseCount = data.fullGold_3_purchaseCount;
        spawnCopper_purchaseCount = data.spawnCopper_purchaseCount;
        copperChunk_1_purchaseCount = data.copperChunk_1_purchaseCount;
        copperChunk_2_purchaseCount = data.copperChunk_2_purchaseCount;
        copperChunk_3_purchaseCount = data.copperChunk_3_purchaseCount;
        fullCopper_1_purchaseCount = data.fullCopper_1_purchaseCount;
        fullCopper_2_purchaseCount = data.fullCopper_2_purchaseCount;
        fullCopper_3_purchaseCount = data.fullCopper_3_purchaseCount;
        spawnIron_purchaseCount = data.spawnIron_purchaseCount;
        ironChunk_1_purchaseCount = data.ironChunk_1_purchaseCount;
        ironChunk_2_purchaseCount = data.ironChunk_2_purchaseCount;
        fullIron_1_purchaseCount = data.fullIron_1_purchaseCount;
        fullIron_2_purchaseCount = data.fullIron_2_purchaseCount;
        cobaltSpawn_purchaseCount = data.cobaltSpawn_purchaseCount;
        cobaltChunk_1_purchaseCount = data.cobaltChunk_1_purchaseCount;
        fullCobalt_1_purchaseCount = data.fullCobalt_1_purchaseCount;
        uraniumSpawn_purchaseCount = data.uraniumSpawn_purchaseCount;
        uraniumChunk_1_purchaseCount = data.uraniumChunk_1_purchaseCount;
        fullUranium_1_purchaseCount = data.fullUranium_1_purchaseCount;
        ismiumSpawn_purchaseCount = data.ismiumSpawn_purchaseCount;
        ismiumChunk_1_purchaseCount = data.ismiumChunk_1_purchaseCount;
        fullIsmium_1_purchaseCount = data.fullIsmium_1_purchaseCount;
        iridiumSpawn_purchaseCount = data.iridiumSpawn_purchaseCount;
        iridiumChunk_1_purchaseCount = data.iridiumChunk_1_purchaseCount;
        fullIridium_1_purchaseCount = data.fullIridium_1_purchaseCount;
        painiteSpawn_purchaseCount = data.painiteSpawn_purchaseCount;
        painiteChunk_1_purchaseCount = data.painiteChunk_1_purchaseCount;
        fullPainite_1_purchaseCount = data.fullPainite_1_purchaseCount;

        // Better Pickaxe and Mining Erea (12)
        improvedPickaxe_1_purchaseCount = data.improvedPickaxe_1_purchaseCount;
        improvedPickaxe_2_purchaseCount = data.improvedPickaxe_2_purchaseCount;
        improvedPickaxe_3_purchaseCount = data.improvedPickaxe_3_purchaseCount;
        improvedPickaxe_4_purchaseCount = data.improvedPickaxe_4_purchaseCount;
        improvedPickaxe_5_purchaseCount = data.improvedPickaxe_5_purchaseCount;
        improvedPickaxe_6_purchaseCount = data.improvedPickaxe_6_purchaseCount;
        biggerMiningErea_1_purchaseCount = data.biggerMiningErea_1_purchaseCount;
        biggerMiningErea_2_purchaseCount = data.biggerMiningErea_2_purchaseCount;
        biggerMiningErea_3_purchaseCount = data.biggerMiningErea_3_purchaseCount;
        biggerMiningErea_4_purchaseCount = data.biggerMiningErea_4_purchaseCount;
        shootCircleChance_purchaseCount = data.shootCircleChance_purchaseCount;
        increaseAndDecreaseMinignErea_purchaseCount = data.increaseAndDecreaseMinignErea_purchaseCount;

        // Chance to Spawn Rock and Spawn Rock X Times (12)
        spawnRockEveryXrock_1_purchaseCount = data.spawnRockEveryXrock_1_purchaseCount;
        spawnRockEveryXrock_2_purchaseCount = data.spawnRockEveryXrock_2_purchaseCount;
        spawnRockEveryXrock_3_purchaseCount = data.spawnRockEveryXrock_3_purchaseCount;
        spawnXRockEveryXSecond_1_purchaseCount = data.spawnXRockEveryXSecond_1_purchaseCount;
        spawnXRockEveryXSecond_2_purchaseCount = data.spawnXRockEveryXSecond_2_purchaseCount;
        spawnXRockEveryXSecond_3_purchaseCount = data.spawnXRockEveryXSecond_3_purchaseCount;
        chanceToSpawnRockWhenMined_1_purchaseCount = data.chanceToSpawnRockWhenMined_1_purchaseCount;
        chanceToSpawnRockWhenMined_2_purchaseCount = data.chanceToSpawnRockWhenMined_2_purchaseCount;
        chanceToSpawnRockWhenMined_3_purchaseCount = data.chanceToSpawnRockWhenMined_3_purchaseCount;
        chanceToSpawnRockWhenMined_4_purchaseCount = data.chanceToSpawnRockWhenMined_4_purchaseCount;
        chanceToSpawnRockWhenMined_5_purchaseCount = data.chanceToSpawnRockWhenMined_5_purchaseCount;
        chanceToSpawnRockWhenMined_6_purchaseCount = data.chanceToSpawnRockWhenMined_6_purchaseCount;

        // Spawn Pickaxes (7)
        chanceToMineRandomRock_1_purchaseCount = data.chanceToMineRandomRock_1_purchaseCount;
        chanceToMineRandomRock_2_purchaseCount = data.chanceToMineRandomRock_2_purchaseCount;
        chanceToMineRandomRock_3_purchaseCount = data.chanceToMineRandomRock_3_purchaseCount;
        chanceToMineRandomRock_4_purchaseCount = data.chanceToMineRandomRock_4_purchaseCount;
        spawnPickaxeEverySecond_1_purchaseCount = data.spawnPickaxeEverySecond_1_purchaseCount;
        spawnPickaxeEverySecond_2_purchaseCount = data.spawnPickaxeEverySecond_2_purchaseCount;
        spawnPickaxeEverySecond_3_purchaseCount = data.spawnPickaxeEverySecond_3_purchaseCount;

        // More Time (6)
        moreTime_1_purchaseCount = data.moreTime_1_purchaseCount;
        moreTime_2_purchaseCount = data.moreTime_2_purchaseCount;
        moreTime_3_purchaseCount = data.moreTime_3_purchaseCount;
        moreTime_4_purchaseCount = data.moreTime_4_purchaseCount;
        chanceToAdd1SecondEverySecond_purchaseCount = data.chanceToAdd1SecondEverySecond_purchaseCount;
        chanceAdd1SecondEveryRockMined_purchaseCount = data.chanceAdd1SecondEveryRockMined_purchaseCount;

        // Chance for Double XP and Gold (5)
        doubleXpGoldChance_1_purchaseCount = data.doubleXpGoldChance_1_purchaseCount;
        doubleXpGoldChance_2_purchaseCount = data.doubleXpGoldChance_2_purchaseCount;
        doubleXpGoldChance_3_purchaseCount = data.doubleXpGoldChance_3_purchaseCount;
        doubleXpGoldChance_4_purchaseCount = data.doubleXpGoldChance_4_purchaseCount;
        doubleXpGoldChance_5_purchaseCount = data.doubleXpGoldChance_5_purchaseCount;

        // Lightning, Dynamite, and PlazmaBalls (27)
        lightningBeamChanceS_1_purchaseCount = data.lightningBeamChanceS_1_purchaseCount;
        lightningBeamChanceS_2_purchaseCount = data.lightningBeamChanceS_2_purchaseCount;
        lightningBeamChancePH_1_purchaseCount = data.lightningBeamChancePH_1_purchaseCount;
        lightningBeamChancePH_2_purchaseCount = data.lightningBeamChancePH_2_purchaseCount;
        lightningBeamSpawnAnotherOneChance_purchaseCount = data.lightningBeamSpawnAnotherOneChance_purchaseCount;
        lightningBeamDamage_purchaseCount = data.lightningBeamDamage_purchaseCount;
        lightningBeamSize_purchaseCount = data.lightningBeamSize_purchaseCount;
        lightningSplashes_purchaseCount = data.lightningSplashes_purchaseCount;
        lightningBeamSpawnRock_purchaseCount = data.lightningBeamSpawnRock_purchaseCount;
        lightningBeamExplosion_purchaseCount = data.lightningBeamExplosion_purchaseCount;
        lightningBeamAddTime_purchaseCount = data.lightningBeamAddTime_purchaseCount;

        dynamiteChance_1_purchaseCount = data.dynamiteChance_1_purchaseCount;
        dynamiteChance_2_purchaseCount = data.dynamiteChance_2_purchaseCount;
        dynamiteSpawn2SmallChance_purchaseCount = data.dynamiteSpawn2SmallChance_purchaseCount;
        dynamiteExplosionSize_purchaseCount = data.dynamiteExplosionSize_purchaseCount;
        dynamiteDamage_purchaseCount = data.dynamiteDamage_purchaseCount;
        dynamiteExplosionSpawnRock_purchaseCount = data.dynamiteExplosionSpawnRock_purchaseCount;
        dynamiteExplosionAddTimeChance_purchaseCount = data.dynamiteExplosionAddTimeChance_purchaseCount;
        dynamiteExplosionSpawnLightning_purchaseCount = data.dynamiteExplosionSpawnLightning_purchaseCount;

        plazmaBallSpawn_1_purchaseCount = data.plazmaBallSpawn_1_purchaseCount;
        plazmaBallSpawn_2_purchaseCount = data.plazmaBallSpawn_2_purchaseCount;
        plazmaBallTime_purchaseCount = data.plazmaBallTime_purchaseCount;
        plazmaBallSize_purchaseCount = data.plazmaBallSize_purchaseCount;
        plazmaBallExplosionChance_purchaseCount = data.plazmaBallExplosionChance_purchaseCount;
        plazmaBallSpawnSmallChance_purchaseCount = data.plazmaBallSpawnSmallChance_purchaseCount;
        plazmaBallDamage_purchaseCount = data.plazmaBallDamage_purchaseCount;
        plazmaBallSpawnPickaxeChance_purchaseCount = data.plazmaBallSpawnPickaxeChance_purchaseCount;

        // Misc (9)
        allProjectileDoubleDamageChance_purchaseCount = data.allProjectileDoubleDamageChance_purchaseCount;
        allProjectileTriggerChance_purchaseCount = data.allProjectileTriggerChance_purchaseCount;
        pickaxeDoubleDamageChance_1_purchaseCount = data.pickaxeDoubleDamageChance_1_purchaseCount;
        pickaxeDoubleDamageChance_2_purchaseCount = data.pickaxeDoubleDamageChance_2_purchaseCount;
        intaMineChance_1_purchaseCount = data.intaMineChance_1_purchaseCount;
        intaMineChance_2_purchaseCount = data.intaMineChance_2_purchaseCount;
        increaseSpawnChanceAllRocks_purchaseCount = data.increaseSpawnChanceAllRocks_purchaseCount;
        craft2Material_purchaseCount = data.craft2Material_purchaseCount;
        finalUpgrade_purchaseCount = data.finalUpgrade_purchaseCount;

        totalSkillTreeUpgradesPurchased = data.totalSkillTreeUpgradesPurchased;
        totalUpgradesFullyPurchased = data.totalUpgradesFullyPurchased;
        mineSessionTime = data.mineSessionTime;
        totalRocksToSpawn = data.totalRocksToSpawn;
        extraTalentPointPerLevel = data.extraTalentPointPerLevel;

        // Rock chances
        goldRockChance = data.goldRockChance;
        fullGoldRockChance = data.fullGoldRockChance;
        copperRockChance = data.copperRockChance;
        fullCopperRockChance = data.fullCopperRockChance;
        ironRockChance = data.ironRockChance;
        fullIronRockChance = data.fullIronRockChance;
        cobaltRockChance = data.cobaltRockChance;
        fullCobaltRockChance = data.fullCobaltRockChance;
        uraniumRockChance = data.uraniumRockChance;
        fullUraniumRockChance = data.fullUraniumRockChance;
        ismiumRockChance = data.ismiumRockChance;
        fullIsmiumRockChance = data.fullIsmiumRockChance;
        iridiumRockChance = data.iridiumRockChance;
        fullIridiumRockChance = data.fullIridiumRockChance;
        painiteRockChance = data.painiteRockChance;
        fullPainiteRockChance = data.fullPainiteRockChance;

        // Pickaxe
        improvedPickaxeStrength = data.improvedPickaxeStrength;
        reducePickaxeMineTime = data.reducePickaxeMineTime;

        // Mining Area
        miningAreaSize = data.miningAreaSize;

        // Spawn rocks
        spawnRockEveryXRock = data.spawnRockEveryXRock;
        spawnXRockEveryXSecond = data.spawnXRockEveryXSecond;
        chanceToSpawnRockWhenMined = data.chanceToSpawnRockWhenMined;

        // Materials from rocks
        materialsFromChunkRocks = data.materialsFromChunkRocks;
        materialsFromFullRocks = data.materialsFromFullRocks;

        // Materials worth
        materialsTotalWorth = data.materialsTotalWorth;

        // Pickaxe spawn
        chanceToMineRandomRock = data.chanceToMineRandomRock;
        spawnPickaxeEverySecond = data.spawnPickaxeEverySecond;

        // Double XP & Gold
        doubleXpAndGoldChance = data.doubleXpAndGoldChance;

        // Lightning
        lightningTriggerChanceS = data.lightningTriggerChanceS;
        lightningTriggerChancePH = data.lightningTriggerChancePH;
        lightningDamage = data.lightningDamage;
        lightningSize = data.lightningSize;

        // Dynamite
        dynamiteStickChance = data.dynamiteStickChance;
        explosionSize = data.explosionSize;
        explosionDamagage = data.explosionDamagage;

        // Plazma balls
        plazmaBallChance = data.plazmaBallChance;
        plazmaBallTimer = data.plazmaBallTimer;
        plazmaBallTotalSize = data.plazmaBallTotalSize;
        plazmaBallTotalDamage = data.plazmaBallTotalDamage;

        // Misc
        doubleDamageChance = data.doubleDamageChance;
        instaMineChance = data.instaMineChance;
    }
    #endregion

    #region Save Data
    public void SaveData(ref GameData data)
    {
        data.moreTime_1_purchased = moreTime_1_purchased;
        data.moreTime_2_purchased = moreTime_2_purchased;
        data.moreTime_3_purchased = moreTime_3_purchased;
        data.moreTime_4_purchased = moreTime_4_purchased;
        data.chanceToAdd1SecondEverySecond_purchased = chanceToAdd1SecondEverySecond_purchased;
        data.chanceAdd1SecondEveryRockMined_purchased = chanceAdd1SecondEveryRockMined_purchased;

        data.totalMaterialRocksSpawning = totalMaterialRocksSpawning;

        data.moreXP_1_purchased = moreXP_1_purchased;
        data.moreXP_2_purchased = moreXP_2_purchased;
        data.moreXP_3_purchased = moreXP_3_purchased;
        data.moreXP_4_purchased = moreXP_4_purchased;
        data.moreXP_5_purchased = moreXP_5_purchased;
        data.moreXP_6_purchased = moreXP_6_purchased;
        data.moreXP_7_purchased = moreXP_7_purchased;
        data.moreXP_8_purchased = moreXP_8_purchased;

        data.talentPointsPerXlevel_1_purchased = talentPointsPerXlevel_1_purchased;
        data.talentPointsPerXlevel_2_purchased = talentPointsPerXlevel_2_purchased;
        data.talentPointsPerXlevel_3_purchased = talentPointsPerXlevel_3_purchased;

        data.spawnMoreRocks_1_purchased = spawnMoreRocks_1_purchased;
        data.spawnMoreRocks_2_purchased = spawnMoreRocks_2_purchased;
        data.spawnMoreRocks_3_purchased = spawnMoreRocks_3_purchased;
        data.spawnMoreRocks_4_purchased = spawnMoreRocks_4_purchased;
        data.spawnMoreRocks_5_purchased = spawnMoreRocks_5_purchased;
        data.spawnMoreRocks_6_purchased = spawnMoreRocks_6_purchased;
        data.spawnMoreRocks_7_purchased = spawnMoreRocks_7_purchased;
        data.spawnMoreRocks_8_purchased = spawnMoreRocks_8_purchased;
        data.spawnMoreRocks_9_purchased = spawnMoreRocks_9_purchased;

        data.moreMeterialsFromRock_1_purchased = moreMeterialsFromRock_1_purchased;
        data.moreMeterialsFromRock_2_purchased = moreMeterialsFromRock_2_purchased;
        data.moreMeterialsFromRock_3_purchased = moreMeterialsFromRock_3_purchased;
        data.moreMeterialsFromRock_4_purchased = moreMeterialsFromRock_4_purchased;
        data.moreMeterialsFromRock_5_purchased = moreMeterialsFromRock_5_purchased;

        data.marterialsWorthMore_1_purchased = marterialsWorthMore_1_purchased;
        data.marterialsWorthMore_2_purchased = marterialsWorthMore_2_purchased;
        data.marterialsWorthMore_3_purchased = marterialsWorthMore_3_purchased;
        data.marterialsWorthMore_4_purchased = marterialsWorthMore_4_purchased;
        data.marterialsWorthMore_5_purchased = marterialsWorthMore_5_purchased;
        data.marterialsWorthMore_6_purchased = marterialsWorthMore_6_purchased;
        data.marterialsWorthMore_7_purchased = marterialsWorthMore_7_purchased;
        data.marterialsWorthMore_8_purchased = marterialsWorthMore_8_purchased;

        data.goldChunk_1_purchased = goldChunk_1_purchased;
        data.goldChunk_2_purchased = goldChunk_2_purchased;
        data.goldChunk_3_purchased = goldChunk_3_purchased;
        data.goldChunk_4_purchased = goldChunk_4_purchased;
        data.goldChunk_5_purchased = goldChunk_5_purchased;
        data.fullGold_1_purchased = fullGold_1_purchased;
        data.fullGold_2_purchased = fullGold_2_purchased;
        data.fullGold_3_purchased = fullGold_3_purchased;

        data.spawnCopper_purchased = spawnCopper_purchased;
        data.copperChunk_1_purchased = copperChunk_1_purchased;
        data.copperChunk_2_purchased = copperChunk_2_purchased;
        data.copperChunk_3_purchased = copperChunk_3_purchased;
        data.fullCopper_1_purchased = fullCopper_1_purchased;
        data.fullCopper_2_purchased = fullCopper_2_purchased;
        data.fullCopper_3_purchased = fullCopper_3_purchased;

        data.spawnIron_purchased = spawnIron_purchased;
        data.ironChunk_1_purchased = ironChunk_1_purchased;
        data.ironChunk_2_purchased = ironChunk_2_purchased;
        data.fullIron_1_purchased = fullIron_1_purchased;
        data.fullIron_2_purchased = fullIron_2_purchased;

        data.cobaltSpawn_purchased = cobaltSpawn_purchased;
        data.cobaltChunk_1_purchased = cobaltChunk_1_purchased;
        data.fullCobalt_1_purchased = fullCobalt_1_purchased;

        data.uraniumSpawn_purchased = uraniumSpawn_purchased;
        data.uraniumChunk_1_purchased = uraniumChunk_1_purchased;
        data.fullUranium_1_purchased = fullUranium_1_purchased;

        data.ismiumSpawn_purchased = ismiumSpawn_purchased;
        data.ismiumChunk_1_purchased = ismiumChunk_1_purchased;
        data.fullIsmium_1_purchased = fullIsmium_1_purchased;

        data.iridiumSpawn_purchased = iridiumSpawn_purchased;
        data.iridiumChunk_1_purchased = iridiumChunk_1_purchased;
        data.fullIridium_1_purchased = fullIridium_1_purchased;

        data.painiteSpawn_purchased = painiteSpawn_purchased;
        data.painiteChunk_1_purchased = painiteChunk_1_purchased;
        data.fullPainite_1_purchased = fullPainite_1_purchased;

        data.improvedPickaxe_1_purchased = improvedPickaxe_1_purchased;
        data.improvedPickaxe_2_purchased = improvedPickaxe_2_purchased;
        data.improvedPickaxe_3_purchased = improvedPickaxe_3_purchased;
        data.improvedPickaxe_4_purchased = improvedPickaxe_4_purchased;
        data.improvedPickaxe_5_purchased = improvedPickaxe_5_purchased;
        data.improvedPickaxe_6_purchased = improvedPickaxe_6_purchased;

        data.biggerMiningErea_1_purchased = biggerMiningErea_1_purchased;
        data.biggerMiningErea_2_purchased = biggerMiningErea_2_purchased;
        data.biggerMiningErea_3_purchased = biggerMiningErea_3_purchased;
        data.biggerMiningErea_4_purchased = biggerMiningErea_4_purchased;
        data.shootCircleChance_purchased = shootCircleChance_purchased;
        data.increaseAndDecreaseMinignErea_purchased = increaseAndDecreaseMinignErea_purchased;

        data.spawnRockEveryXrock_1_purchased = spawnRockEveryXrock_1_purchased;
        data.spawnRockEveryXrock_2_purchased = spawnRockEveryXrock_2_purchased;
        data.spawnRockEveryXrock_3_purchased = spawnRockEveryXrock_3_purchased;

        data.spawnXRockEveryXSecond_1_purchased = spawnXRockEveryXSecond_1_purchased;
        data.spawnXRockEveryXSecond_2_purchased = spawnXRockEveryXSecond_2_purchased;
        data.spawnXRockEveryXSecond_3_purchased = spawnXRockEveryXSecond_3_purchased;

        data.chanceToSpawnRockWhenMined_1_purchased = chanceToSpawnRockWhenMined_1_purchased;
        data.chanceToSpawnRockWhenMined_2_purchased = chanceToSpawnRockWhenMined_2_purchased;
        data.chanceToSpawnRockWhenMined_3_purchased = chanceToSpawnRockWhenMined_3_purchased;
        data.chanceToSpawnRockWhenMined_4_purchased = chanceToSpawnRockWhenMined_4_purchased;
        data.chanceToSpawnRockWhenMined_5_purchased = chanceToSpawnRockWhenMined_5_purchased;
        data.chanceToSpawnRockWhenMined_6_purchased = chanceToSpawnRockWhenMined_6_purchased;

        data.chanceToMineRandomRock_1_purchased = chanceToMineRandomRock_1_purchased;
        data.chanceToMineRandomRock_2_purchased = chanceToMineRandomRock_2_purchased;
        data.chanceToMineRandomRock_3_purchased = chanceToMineRandomRock_3_purchased;
        data.chanceToMineRandomRock_4_purchased = chanceToMineRandomRock_4_purchased;

        data.spawnPickaxeEverySecond_1_purchased = spawnPickaxeEverySecond_1_purchased;
        data.spawnPickaxeEverySecond_2_purchased = spawnPickaxeEverySecond_2_purchased;
        data.spawnPickaxeEverySecond_3_purchased = spawnPickaxeEverySecond_3_purchased;

        data.doubleXpGoldChance_1_purchased = doubleXpGoldChance_1_purchased;
        data.doubleXpGoldChance_2_purchased = doubleXpGoldChance_2_purchased;
        data.doubleXpGoldChance_3_purchased = doubleXpGoldChance_3_purchased;
        data.doubleXpGoldChance_4_purchased = doubleXpGoldChance_4_purchased;
        data.doubleXpGoldChance_5_purchased = doubleXpGoldChance_5_purchased;

        data.lightningBeamChanceS_1_purchased = lightningBeamChanceS_1_purchased;
        data.lightningBeamChanceS_2_purchased = lightningBeamChanceS_2_purchased;
        data.lightningBeamChancePH_1_purchased = lightningBeamChancePH_1_purchased;
        data.lightningBeamChancePH_2_purchased = lightningBeamChancePH_2_purchased;
        data.lightningBeamSpawnAnotherOneChance_purchased = lightningBeamSpawnAnotherOneChance_purchased;
        data.lightningBeamDamage_purchased = lightningBeamDamage_purchased;
        data.lightningBeamSize_purchased = lightningBeamSize_purchased;
        data.lightningSplashes_purchased = lightningSplashes_purchased;
        data.lightningBeamSpawnRock_purchased = lightningBeamSpawnRock_purchased;
        data.lightningBeamExplosion_purchased = lightningBeamExplosion_purchased;
        data.lightningBeamAddTime_purchased = lightningBeamAddTime_purchased;

        data.dynamiteChance_1_purchased = dynamiteChance_1_purchased;
        data.dynamiteChance_2_purchased = dynamiteChance_2_purchased;
        data.dynamiteSpawn2SmallChance_purchased = dynamiteSpawn2SmallChance_purchased;
        data.dynamiteExplosionSize_purchased = dynamiteExplosionSize_purchased;
        data.dynamiteDamage_purchased = dynamiteDamage_purchased;
        data.dynamiteExplosionSpawnRock_purchased = dynamiteExplosionSpawnRock_purchased;
        data.dynamiteExplosionAddTimeChance_purchased = dynamiteExplosionAddTimeChance_purchased;
        data.dynamiteExplosionSpawnLightning_purchased = dynamiteExplosionSpawnLightning_purchased;

        data.plazmaBallSpawn_1_purchased = plazmaBallSpawn_1_purchased;
        data.plazmaBallSpawn_2_purchased = plazmaBallSpawn_2_purchased;
        data.plazmaBallTime_purchased = plazmaBallTime_purchased;
        data.plazmaBallSize_purchased = plazmaBallSize_purchased;
        data.plazmaBallExplosionChance_purchased = plazmaBallExplosionChance_purchased;
        data.plazmaBallSpawnSmallChance_purchased = plazmaBallSpawnSmallChance_purchased;
        data.plazmaBallDamage_purchased = plazmaBallDamage_purchased;
        data.plazmaBallSpawnPickaxeChance_purchased = plazmaBallSpawnPickaxeChance_purchased;

        data.allProjectileDoubleDamageChance_purchased = allProjectileDoubleDamageChance_purchased;
        data.allProjectileTriggerChance_purchased = allProjectileTriggerChance_purchased;
        data.pickaxeDoubleDamageChance_1_purchased = pickaxeDoubleDamageChance_1_purchased;
        data.pickaxeDoubleDamageChance_2_purchased = pickaxeDoubleDamageChance_2_purchased;
        data.intaMineChance_1_purchased = intaMineChance_1_purchased;
        data.intaMineChance_2_purchased = intaMineChance_2_purchased;
        data.increaseSpawnChanceAllRocks_purchased = increaseSpawnChanceAllRocks_purchased;
        data.craft2Material_purchased = craft2Material_purchased;
        data.finalUpgrade_purchased = finalUpgrade_purchased;

        data.moreXP_1_purchaseCount = moreXP_1_purchaseCount;
        data.moreXP_2_purchaseCount = moreXP_2_purchaseCount;
        data.moreXP_3_purchaseCount = moreXP_3_purchaseCount;
        data.moreXP_4_purchaseCount = moreXP_4_purchaseCount;
        data.moreXP_5_purchaseCount = moreXP_5_purchaseCount;
        data.moreXP_6_purchaseCount = moreXP_6_purchaseCount;
        data.moreXP_7_purchaseCount = moreXP_7_purchaseCount;
        data.moreXP_8_purchaseCount = moreXP_8_purchaseCount;
        data.talentPointsPerXlevel_1_purchaseCount = talentPointsPerXlevel_1_purchaseCount;
        data.talentPointsPerXlevel_2_purchaseCount = talentPointsPerXlevel_2_purchaseCount;
        data.talentPointsPerXlevel_3_purchaseCount = talentPointsPerXlevel_3_purchaseCount;

        // Rocks and Materials (57)
        data.spawnMoreRocks_1_purchaseCount = spawnMoreRocks_1_purchaseCount;
        data.spawnMoreRocks_2_purchaseCount = spawnMoreRocks_2_purchaseCount;
        data.spawnMoreRocks_3_purchaseCount = spawnMoreRocks_3_purchaseCount;
        data.spawnMoreRocks_4_purchaseCount = spawnMoreRocks_4_purchaseCount;
        data.spawnMoreRocks_5_purchaseCount = spawnMoreRocks_5_purchaseCount;
        data.spawnMoreRocks_6_purchaseCount = spawnMoreRocks_6_purchaseCount;
        data.spawnMoreRocks_7_purchaseCount = spawnMoreRocks_7_purchaseCount;
        data.spawnMoreRocks_8_purchaseCount = spawnMoreRocks_8_purchaseCount;
        data.spawnMoreRocks_9_purchaseCount = spawnMoreRocks_9_purchaseCount;
        data.moreMeterialsFromRock_1_purchaseCount = moreMeterialsFromRock_1_purchaseCount;
        data.moreMeterialsFromRock_2_purchaseCount = moreMeterialsFromRock_2_purchaseCount;
        data.moreMeterialsFromRock_3_purchaseCount = moreMeterialsFromRock_3_purchaseCount;
        data.moreMeterialsFromRock_4_purchaseCount = moreMeterialsFromRock_4_purchaseCount;
        data.moreMeterialsFromRock_5_purchaseCount = moreMeterialsFromRock_5_purchaseCount;
        data.marterialsWorthMore_1_purchaseCount = marterialsWorthMore_1_purchaseCount;
        data.marterialsWorthMore_2_purchaseCount = marterialsWorthMore_2_purchaseCount;
        data.marterialsWorthMore_3_purchaseCount = marterialsWorthMore_3_purchaseCount;
        data.marterialsWorthMore_4_purchaseCount = marterialsWorthMore_4_purchaseCount;
        data.marterialsWorthMore_5_purchaseCount = marterialsWorthMore_5_purchaseCount;
        data.marterialsWorthMore_6_purchaseCount = marterialsWorthMore_6_purchaseCount;
        data.marterialsWorthMore_7_purchaseCount = marterialsWorthMore_7_purchaseCount;
        data.marterialsWorthMore_8_purchaseCount = marterialsWorthMore_8_purchaseCount;
        data.goldChunk_1_purchaseCount = goldChunk_1_purchaseCount;
        data.goldChunk_2_purchaseCount = goldChunk_2_purchaseCount;
        data.goldChunk_3_purchaseCount = goldChunk_3_purchaseCount;
        data.goldChunk_4_purchaseCount = goldChunk_4_purchaseCount;
        data.goldChunk_5_purchaseCount = goldChunk_5_purchaseCount;
        data.fullGold_1_purchaseCount = fullGold_1_purchaseCount;
        data.fullGold_2_purchaseCount = fullGold_2_purchaseCount;
        data.fullGold_3_purchaseCount = fullGold_3_purchaseCount;
        data.spawnCopper_purchaseCount = spawnCopper_purchaseCount;
        data.copperChunk_1_purchaseCount = copperChunk_1_purchaseCount;
        data.copperChunk_2_purchaseCount = copperChunk_2_purchaseCount;
        data.copperChunk_3_purchaseCount = copperChunk_3_purchaseCount;
        data.fullCopper_1_purchaseCount = fullCopper_1_purchaseCount;
        data.fullCopper_2_purchaseCount = fullCopper_2_purchaseCount;
        data.fullCopper_3_purchaseCount = fullCopper_3_purchaseCount;
        data.spawnIron_purchaseCount = spawnIron_purchaseCount;
        data.ironChunk_1_purchaseCount = ironChunk_1_purchaseCount;
        data.ironChunk_2_purchaseCount = ironChunk_2_purchaseCount;
        data.fullIron_1_purchaseCount = fullIron_1_purchaseCount;
        data.fullIron_2_purchaseCount = fullIron_2_purchaseCount;
        data.cobaltSpawn_purchaseCount = cobaltSpawn_purchaseCount;
        data.cobaltChunk_1_purchaseCount = cobaltChunk_1_purchaseCount;
        data.fullCobalt_1_purchaseCount = fullCobalt_1_purchaseCount;
        data.uraniumSpawn_purchaseCount = uraniumSpawn_purchaseCount;
        data.uraniumChunk_1_purchaseCount = uraniumChunk_1_purchaseCount;
        data.fullUranium_1_purchaseCount = fullUranium_1_purchaseCount;
        data.ismiumSpawn_purchaseCount = ismiumSpawn_purchaseCount;
        data.ismiumChunk_1_purchaseCount = ismiumChunk_1_purchaseCount;
        data.fullIsmium_1_purchaseCount = fullIsmium_1_purchaseCount;
        data.iridiumSpawn_purchaseCount = iridiumSpawn_purchaseCount;
        data.iridiumChunk_1_purchaseCount = iridiumChunk_1_purchaseCount;
        data.fullIridium_1_purchaseCount = fullIridium_1_purchaseCount;
        data.painiteSpawn_purchaseCount = painiteSpawn_purchaseCount;
        data.painiteChunk_1_purchaseCount = painiteChunk_1_purchaseCount;
        data.fullPainite_1_purchaseCount = fullPainite_1_purchaseCount;

        // Better Pickaxe and Mining Erea (12)
        data.improvedPickaxe_1_purchaseCount = improvedPickaxe_1_purchaseCount;
        data.improvedPickaxe_2_purchaseCount = improvedPickaxe_2_purchaseCount;
        data.improvedPickaxe_3_purchaseCount = improvedPickaxe_3_purchaseCount;
        data.improvedPickaxe_4_purchaseCount = improvedPickaxe_4_purchaseCount;
        data.improvedPickaxe_5_purchaseCount = improvedPickaxe_5_purchaseCount;
        data.improvedPickaxe_6_purchaseCount = improvedPickaxe_6_purchaseCount;
        data.biggerMiningErea_1_purchaseCount = biggerMiningErea_1_purchaseCount;
        data.biggerMiningErea_2_purchaseCount = biggerMiningErea_2_purchaseCount;
        data.biggerMiningErea_3_purchaseCount = biggerMiningErea_3_purchaseCount;
        data.biggerMiningErea_4_purchaseCount = biggerMiningErea_4_purchaseCount;
        data.shootCircleChance_purchaseCount = shootCircleChance_purchaseCount;
        data.increaseAndDecreaseMinignErea_purchaseCount = increaseAndDecreaseMinignErea_purchaseCount;

        // Chance to Spawn Rock and Spawn Rock X Times (12)
        data.spawnRockEveryXrock_1_purchaseCount = spawnRockEveryXrock_1_purchaseCount;
        data.spawnRockEveryXrock_2_purchaseCount = spawnRockEveryXrock_2_purchaseCount;
        data.spawnRockEveryXrock_3_purchaseCount = spawnRockEveryXrock_3_purchaseCount;
        data.spawnXRockEveryXSecond_1_purchaseCount = spawnXRockEveryXSecond_1_purchaseCount;
        data.spawnXRockEveryXSecond_2_purchaseCount = spawnXRockEveryXSecond_2_purchaseCount;
        data.spawnXRockEveryXSecond_3_purchaseCount = spawnXRockEveryXSecond_3_purchaseCount;
        data.chanceToSpawnRockWhenMined_1_purchaseCount = chanceToSpawnRockWhenMined_1_purchaseCount;
        data.chanceToSpawnRockWhenMined_2_purchaseCount = chanceToSpawnRockWhenMined_2_purchaseCount;
        data.chanceToSpawnRockWhenMined_3_purchaseCount = chanceToSpawnRockWhenMined_3_purchaseCount;
        data.chanceToSpawnRockWhenMined_4_purchaseCount = chanceToSpawnRockWhenMined_4_purchaseCount;
        data.chanceToSpawnRockWhenMined_5_purchaseCount = chanceToSpawnRockWhenMined_5_purchaseCount;
        data.chanceToSpawnRockWhenMined_6_purchaseCount = chanceToSpawnRockWhenMined_6_purchaseCount;

        // Spawn Pickaxes (7)
        data.chanceToMineRandomRock_1_purchaseCount = chanceToMineRandomRock_1_purchaseCount;
        data.chanceToMineRandomRock_2_purchaseCount = chanceToMineRandomRock_2_purchaseCount;
        data.chanceToMineRandomRock_3_purchaseCount = chanceToMineRandomRock_3_purchaseCount;
        data.chanceToMineRandomRock_4_purchaseCount = chanceToMineRandomRock_4_purchaseCount;
        data.spawnPickaxeEverySecond_1_purchaseCount = spawnPickaxeEverySecond_1_purchaseCount;
        data.spawnPickaxeEverySecond_2_purchaseCount = spawnPickaxeEverySecond_2_purchaseCount;
        data.spawnPickaxeEverySecond_3_purchaseCount = spawnPickaxeEverySecond_3_purchaseCount;

        // More Time (6)
        data.moreTime_1_purchaseCount = moreTime_1_purchaseCount;
        data.moreTime_2_purchaseCount = moreTime_2_purchaseCount;
        data.moreTime_3_purchaseCount = moreTime_3_purchaseCount;
        data.moreTime_4_purchaseCount = moreTime_4_purchaseCount;
        data.chanceToAdd1SecondEverySecond_purchaseCount = chanceToAdd1SecondEverySecond_purchaseCount;
        data.chanceAdd1SecondEveryRockMined_purchaseCount = chanceAdd1SecondEveryRockMined_purchaseCount;

        // Chance for Double XP and Gold (5)
        data.doubleXpGoldChance_1_purchaseCount = doubleXpGoldChance_1_purchaseCount;
        data.doubleXpGoldChance_2_purchaseCount = doubleXpGoldChance_2_purchaseCount;
        data.doubleXpGoldChance_3_purchaseCount = doubleXpGoldChance_3_purchaseCount;
        data.doubleXpGoldChance_4_purchaseCount = doubleXpGoldChance_4_purchaseCount;
        data.doubleXpGoldChance_5_purchaseCount = doubleXpGoldChance_5_purchaseCount;

        // Lightning, Dynamite, and PlazmaBalls (27)
        data.lightningBeamChanceS_1_purchaseCount = lightningBeamChanceS_1_purchaseCount;
        data.lightningBeamChanceS_2_purchaseCount = lightningBeamChanceS_2_purchaseCount;
        data.lightningBeamChancePH_1_purchaseCount = lightningBeamChancePH_1_purchaseCount;
        data.lightningBeamChancePH_2_purchaseCount = lightningBeamChancePH_2_purchaseCount;
        data.lightningBeamSpawnAnotherOneChance_purchaseCount = lightningBeamSpawnAnotherOneChance_purchaseCount;
        data.lightningBeamDamage_purchaseCount = lightningBeamDamage_purchaseCount;
        data.lightningBeamSize_purchaseCount = lightningBeamSize_purchaseCount;
        data.lightningSplashes_purchaseCount = lightningSplashes_purchaseCount;
        data.lightningBeamSpawnRock_purchaseCount = lightningBeamSpawnRock_purchaseCount;
        data.lightningBeamExplosion_purchaseCount = lightningBeamExplosion_purchaseCount;
        data.lightningBeamAddTime_purchaseCount = lightningBeamAddTime_purchaseCount;

        data.dynamiteChance_1_purchaseCount = dynamiteChance_1_purchaseCount;
        data.dynamiteChance_2_purchaseCount = dynamiteChance_2_purchaseCount;
        data.dynamiteSpawn2SmallChance_purchaseCount = dynamiteSpawn2SmallChance_purchaseCount;
        data.dynamiteExplosionSize_purchaseCount = dynamiteExplosionSize_purchaseCount;
        data.dynamiteDamage_purchaseCount = dynamiteDamage_purchaseCount;
        data.dynamiteExplosionSpawnRock_purchaseCount = dynamiteExplosionSpawnRock_purchaseCount;
        data.dynamiteExplosionAddTimeChance_purchaseCount = dynamiteExplosionAddTimeChance_purchaseCount;
        data.dynamiteExplosionSpawnLightning_purchaseCount = dynamiteExplosionSpawnLightning_purchaseCount;

        data.plazmaBallSpawn_1_purchaseCount = plazmaBallSpawn_1_purchaseCount;
        data.plazmaBallSpawn_2_purchaseCount = plazmaBallSpawn_2_purchaseCount;
        data.plazmaBallTime_purchaseCount = plazmaBallTime_purchaseCount;
        data.plazmaBallSize_purchaseCount = plazmaBallSize_purchaseCount;
        data.plazmaBallExplosionChance_purchaseCount = plazmaBallExplosionChance_purchaseCount;
        data.plazmaBallSpawnSmallChance_purchaseCount = plazmaBallSpawnSmallChance_purchaseCount;
        data.plazmaBallDamage_purchaseCount = plazmaBallDamage_purchaseCount;
        data.plazmaBallSpawnPickaxeChance_purchaseCount = plazmaBallSpawnPickaxeChance_purchaseCount;

        // Misc (9)
        data.allProjectileDoubleDamageChance_purchaseCount = allProjectileDoubleDamageChance_purchaseCount;
        data.allProjectileTriggerChance_purchaseCount = allProjectileTriggerChance_purchaseCount;
        data.pickaxeDoubleDamageChance_1_purchaseCount = pickaxeDoubleDamageChance_1_purchaseCount;
        data.pickaxeDoubleDamageChance_2_purchaseCount = pickaxeDoubleDamageChance_2_purchaseCount;
        data.intaMineChance_1_purchaseCount = intaMineChance_1_purchaseCount;
        data.intaMineChance_2_purchaseCount = intaMineChance_2_purchaseCount;
        data.increaseSpawnChanceAllRocks_purchaseCount = increaseSpawnChanceAllRocks_purchaseCount;
        data.craft2Material_purchaseCount = craft2Material_purchaseCount;
        data.finalUpgrade_purchaseCount = finalUpgrade_purchaseCount;

        // Skill Tree and Upgrades
        data.totalSkillTreeUpgradesPurchased = totalSkillTreeUpgradesPurchased;
        data.totalUpgradesFullyPurchased = totalUpgradesFullyPurchased;
        data.mineSessionTime = mineSessionTime;
        data.totalRocksToSpawn = totalRocksToSpawn;
        data.extraTalentPointPerLevel = extraTalentPointPerLevel;

        // Rock chances
        data.goldRockChance = goldRockChance;
        data.fullGoldRockChance = fullGoldRockChance;
        data.copperRockChance = copperRockChance;
        data.fullCopperRockChance = fullCopperRockChance;
        data.ironRockChance = ironRockChance;
        data.fullIronRockChance = fullIronRockChance;
        data.cobaltRockChance = cobaltRockChance;
        data.fullCobaltRockChance = fullCobaltRockChance;
        data.uraniumRockChance = uraniumRockChance;
        data.fullUraniumRockChance = fullUraniumRockChance;
        data.ismiumRockChance = ismiumRockChance;
        data.fullIsmiumRockChance = fullIsmiumRockChance;
        data.iridiumRockChance = iridiumRockChance;
        data.fullIridiumRockChance = fullIridiumRockChance;
        data.painiteRockChance = painiteRockChance;
        data.fullPainiteRockChance = fullPainiteRockChance;

        // Pickaxe
        data.improvedPickaxeStrength = improvedPickaxeStrength;
        data.reducePickaxeMineTime = reducePickaxeMineTime;

        // Mining Area
        data.miningAreaSize = miningAreaSize;

        // Spawn rocks
        data.spawnRockEveryXRock = spawnRockEveryXRock;
        data.spawnXRockEveryXSecond = spawnXRockEveryXSecond;
        data.chanceToSpawnRockWhenMined = chanceToSpawnRockWhenMined;

        // Materials from rocks
        data.materialsFromChunkRocks = materialsFromChunkRocks;
        data.materialsFromFullRocks = materialsFromFullRocks;

        // Materials worth
        data.materialsTotalWorth = materialsTotalWorth;

        // Pickaxe spawn
        data.chanceToMineRandomRock = chanceToMineRandomRock;
        data.spawnPickaxeEverySecond = spawnPickaxeEverySecond;

        // Double XP & Gold
        data.doubleXpAndGoldChance = doubleXpAndGoldChance;

        // Lightning
        data.lightningTriggerChanceS = lightningTriggerChanceS;
        data.lightningTriggerChancePH = lightningTriggerChancePH;
        data.lightningDamage = lightningDamage;
        data.lightningSize = lightningSize;

        // Dynamite
        data.dynamiteStickChance = dynamiteStickChance;
        data.explosionSize = explosionSize;
        data.explosionDamagage = explosionDamagage;

        // Plazma balls
        data.plazmaBallChance = plazmaBallChance;
        data.plazmaBallTimer = plazmaBallTimer;
        data.plazmaBallTotalSize = plazmaBallTotalSize;
        data.plazmaBallTotalDamage = plazmaBallTotalDamage;

        // Misc
        data.doubleDamageChance = doubleDamageChance;
        data.instaMineChance = instaMineChance;
    }
    #endregion

    public void ResetSkillTree()
    {
        #region XP (11)
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
        #endregion

        #region Rocks and Materials (57)
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
        #endregion

        #region Better Pickaxe and Mining Erea (12)
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
        #endregion

        #region Chance to Spawn Rock and Spawn Rock X Times (12)
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
        #endregion

        #region Spawn Pickaxes (7)
        chanceToMineRandomRock_1_purchased = false;
        chanceToMineRandomRock_2_purchased = false;
        chanceToMineRandomRock_3_purchased = false;
        chanceToMineRandomRock_4_purchased = false;

        spawnPickaxeEverySecond_1_purchased = false;
        spawnPickaxeEverySecond_2_purchased = false;
        spawnPickaxeEverySecond_3_purchased = false;
        #endregion

        #region More Time (6)
        moreTime_1_purchased = false;
        moreTime_2_purchased = false;
        moreTime_3_purchased = false;
        moreTime_4_purchased = false;
        chanceToAdd1SecondEverySecond_purchased = false;
        chanceAdd1SecondEveryRockMined_purchased = false;
        #endregion

        #region Chance for Double XP and Gold (5)
        doubleXpGoldChance_1_purchased = false;
        doubleXpGoldChance_2_purchased = false;
        doubleXpGoldChance_3_purchased = false;
        doubleXpGoldChance_4_purchased = false;
        doubleXpGoldChance_5_purchased = false;
        #endregion

        #region Lightning, Dynamite, and Plasma Balls (27)
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
        #endregion

        #region Misc (9)
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

        //All Purchase count integers
        #region XP
        moreXP_1_purchaseCount = 0; moreXP_2_purchaseCount = 0; moreXP_3_purchaseCount = 0; moreXP_4_purchaseCount = 0;
        moreXP_5_purchaseCount = 0; moreXP_6_purchaseCount = 0; moreXP_7_purchaseCount = 0; moreXP_8_purchaseCount = 0;
        talentPointsPerXlevel_1_purchaseCount = 0; talentPointsPerXlevel_2_purchaseCount = 0; talentPointsPerXlevel_3_purchaseCount = 0;
        #endregion

        #region Rocks and Materials
        spawnMoreRocks_1_purchaseCount = 0; spawnMoreRocks_2_purchaseCount = 0; spawnMoreRocks_3_purchaseCount = 0;
        spawnMoreRocks_4_purchaseCount = 0; spawnMoreRocks_5_purchaseCount = 0; spawnMoreRocks_6_purchaseCount = 0;
        spawnMoreRocks_7_purchaseCount = 0; spawnMoreRocks_8_purchaseCount = 0; spawnMoreRocks_9_purchaseCount = 0;

        moreMeterialsFromRock_1_purchaseCount = 0; moreMeterialsFromRock_2_purchaseCount = 0; moreMeterialsFromRock_3_purchaseCount = 0;
        moreMeterialsFromRock_4_purchaseCount = 0; moreMeterialsFromRock_5_purchaseCount = 0;

        marterialsWorthMore_1_purchaseCount = 0; marterialsWorthMore_2_purchaseCount = 0; marterialsWorthMore_3_purchaseCount = 0;
        marterialsWorthMore_4_purchaseCount = 0; marterialsWorthMore_5_purchaseCount = 0; marterialsWorthMore_6_purchaseCount = 0;
        marterialsWorthMore_7_purchaseCount = 0; marterialsWorthMore_8_purchaseCount = 0;

        goldChunk_1_purchaseCount = 0; goldChunk_2_purchaseCount = 0; goldChunk_3_purchaseCount = 0;
        goldChunk_4_purchaseCount = 0; goldChunk_5_purchaseCount = 0; fullGold_1_purchaseCount = 0;
        fullGold_2_purchaseCount = 0; fullGold_3_purchaseCount = 0;

        spawnCopper_purchaseCount = 0; copperChunk_1_purchaseCount = 0; copperChunk_2_purchaseCount = 0;
        copperChunk_3_purchaseCount = 0; fullCopper_1_purchaseCount = 0; fullCopper_2_purchaseCount = 0;
        fullCopper_3_purchaseCount = 0;

        spawnIron_purchaseCount = 0; ironChunk_1_purchaseCount = 0; ironChunk_2_purchaseCount = 0;
        fullIron_1_purchaseCount = 0; fullIron_2_purchaseCount = 0;

        cobaltSpawn_purchaseCount = 0; cobaltChunk_1_purchaseCount = 0; fullCobalt_1_purchaseCount = 0;

        uraniumSpawn_purchaseCount = 0; uraniumChunk_1_purchaseCount = 0; fullUranium_1_purchaseCount = 0;

        ismiumSpawn_purchaseCount = 0; ismiumChunk_1_purchaseCount = 0; fullIsmium_1_purchaseCount = 0;

        iridiumSpawn_purchaseCount = 0; iridiumChunk_1_purchaseCount = 0; fullIridium_1_purchaseCount = 0;

        painiteSpawn_purchaseCount = 0; painiteChunk_1_purchaseCount = 0; fullPainite_1_purchaseCount = 0;
        #endregion

        #region Better Pickaxe and Mining Erea
        improvedPickaxe_1_purchaseCount = 0; improvedPickaxe_2_purchaseCount = 0; improvedPickaxe_3_purchaseCount = 0;
        improvedPickaxe_4_purchaseCount = 0; improvedPickaxe_5_purchaseCount = 0; improvedPickaxe_6_purchaseCount = 0;

        biggerMiningErea_1_purchaseCount = 0; biggerMiningErea_2_purchaseCount = 0; biggerMiningErea_3_purchaseCount = 0;
        biggerMiningErea_4_purchaseCount = 0; shootCircleChance_purchaseCount = 0; increaseAndDecreaseMinignErea_purchaseCount = 0;
        #endregion

        #region Chance to Spawn Rock and Spawn Rock X Times
        spawnRockEveryXrock_1_purchaseCount = 0; spawnRockEveryXrock_2_purchaseCount = 0; spawnRockEveryXrock_3_purchaseCount = 0;

        spawnXRockEveryXSecond_1_purchaseCount = 0; spawnXRockEveryXSecond_2_purchaseCount = 0; spawnXRockEveryXSecond_3_purchaseCount = 0;

        chanceToSpawnRockWhenMined_1_purchaseCount = 0; chanceToSpawnRockWhenMined_2_purchaseCount = 0;
        chanceToSpawnRockWhenMined_3_purchaseCount = 0; chanceToSpawnRockWhenMined_4_purchaseCount = 0;
        chanceToSpawnRockWhenMined_5_purchaseCount = 0; chanceToSpawnRockWhenMined_6_purchaseCount = 0;
        #endregion

        #region Spawn Pickaxes
        chanceToMineRandomRock_1_purchaseCount = 0; chanceToMineRandomRock_2_purchaseCount = 0;
        chanceToMineRandomRock_3_purchaseCount = 0; chanceToMineRandomRock_4_purchaseCount = 0;

        spawnPickaxeEverySecond_1_purchaseCount = 0; spawnPickaxeEverySecond_2_purchaseCount = 0;
        spawnPickaxeEverySecond_3_purchaseCount = 0;
        #endregion

        #region More Time
        moreTime_1_purchaseCount = 0; moreTime_2_purchaseCount = 0; moreTime_3_purchaseCount = 0;
        moreTime_4_purchaseCount = 0; chanceToAdd1SecondEverySecond_purchaseCount = 0; chanceAdd1SecondEveryRockMined_purchaseCount = 0;
        #endregion

        #region Chance for Double XP and Gold
        doubleXpGoldChance_1_purchaseCount = 0; doubleXpGoldChance_2_purchaseCount = 0;
        doubleXpGoldChance_3_purchaseCount = 0; doubleXpGoldChance_4_purchaseCount = 0; doubleXpGoldChance_5_purchaseCount = 0;
        #endregion

        #region Lightning, Dynamite, and PlazmaBalls
        lightningBeamChanceS_1_purchaseCount = 0; lightningBeamChanceS_2_purchaseCount = 0;
        lightningBeamChancePH_1_purchaseCount = 0; lightningBeamChancePH_2_purchaseCount = 0;
        lightningBeamSpawnAnotherOneChance_purchaseCount = 0; lightningBeamDamage_purchaseCount = 0;
        lightningBeamSize_purchaseCount = 0; lightningSplashes_purchaseCount = 0;
        lightningBeamSpawnRock_purchaseCount = 0; lightningBeamExplosion_purchaseCount = 0;
        lightningBeamAddTime_purchaseCount = 0;

        dynamiteChance_1_purchaseCount = 0; dynamiteChance_2_purchaseCount = 0;
        dynamiteSpawn2SmallChance_purchaseCount = 0; dynamiteExplosionSize_purchaseCount = 0;
        dynamiteDamage_purchaseCount = 0; dynamiteExplosionSpawnRock_purchaseCount = 0;
        dynamiteExplosionAddTimeChance_purchaseCount = 0; dynamiteExplosionSpawnLightning_purchaseCount = 0;

        plazmaBallSpawn_1_purchaseCount = 0; plazmaBallSpawn_2_purchaseCount = 0; plazmaBallTime_purchaseCount = 0;
        plazmaBallSize_purchaseCount = 0; plazmaBallExplosionChance_purchaseCount = 0;
        plazmaBallSpawnSmallChance_purchaseCount = 0; plazmaBallDamage_purchaseCount = 0;
        plazmaBallSpawnPickaxeChance_purchaseCount = 0;
        #endregion

        #region Misc
        allProjectileDoubleDamageChance_purchaseCount = 0; allProjectileTriggerChance_purchaseCount = 0;
        pickaxeDoubleDamageChance_1_purchaseCount = 0; pickaxeDoubleDamageChance_2_purchaseCount = 0;
        intaMineChance_1_purchaseCount = 0; intaMineChance_2_purchaseCount = 0;
        increaseSpawnChanceAllRocks_purchaseCount = 0;
        craft2Material_purchaseCount = 0;
        finalUpgrade_purchaseCount = 0;
        #endregion

        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].SetActive(false);
            finaLine.SetActive(false);
        }

        #region Set all upgrades inactive 
        moreXP_1.SetActive(false);
        moreXP_2.SetActive(false);
        moreXP_3.SetActive(false);
        moreXP_4.SetActive(false);
        moreXP_5.SetActive(false);
        moreXP_6.SetActive(false);
        moreXP_7.SetActive(false);
        moreXP_8.SetActive(false);

        talentPointsPerXlevel_1.SetActive(false);
        talentPointsPerXlevel_2.SetActive(false);
        talentPointsPerXlevel_3.SetActive(false);

        lightningBeamChanceS_1.SetActive(false);
        lightningBeamChanceS_2.SetActive(false);
        lightningBeamChancePH_1.SetActive(false);
        lightningBeamChancePH_2.SetActive(false);
        lightningBeamSpawnAnotherOneChance.SetActive(false);
        lightningBeamDamage.SetActive(false);
        lightningBeamSize.SetActive(false);
        lightningSplashes.SetActive(false);
        lightningBeamSpawnRock.SetActive(false);
        lightningBeamExplosion.SetActive(false);
        lightningBeamAddTime.SetActive(false);

        // Dynamite
        dynamiteChance_1.SetActive(false);
        dynamiteChance_2.SetActive(false);
        dynamiteSpawn2SmallChance.SetActive(false);
        dynamiteExplosionSize.SetActive(false);
        dynamiteDamage.SetActive(false);
        dynamiteExplosionSpawnRock.SetActive(false);
        dynamiteExplosionAddTimeChance.SetActive(false);
        dynamiteExplosionSpawnLightning.SetActive(false);

        // Plazma Ball
        plazmaBallSpawn_1.SetActive(false);
        plazmaBallSpawn_2.SetActive(false);
        plazmaBallTime.SetActive(false);
        plazmaBallSize.SetActive(false);
        plazmaBallExplosionChance.SetActive(false);
        plazmaBallSpawnSmallChance.SetActive(false);
        plazmaBallDamage.SetActive(false);
        plazmaBallSpawnPickaxeChance.SetActive(false);

        spawnMoreRocks_1.SetActive(true);
        spawnMoreRocks_2.SetActive(false);
        spawnMoreRocks_3.SetActive(false);
        spawnMoreRocks_4.SetActive(false);
        spawnMoreRocks_5.SetActive(false);
        spawnMoreRocks_6.SetActive(false);
        spawnMoreRocks_7.SetActive(false);
        spawnMoreRocks_8.SetActive(false);
        spawnMoreRocks_9.SetActive(false);

        moreMeterialsFromRock_1.SetActive(false);
        moreMeterialsFromRock_2.SetActive(false);
        moreMeterialsFromRock_3.SetActive(false);
        moreMeterialsFromRock_4.SetActive(false);
        moreMeterialsFromRock_5.SetActive(false);

        marterialsWorthMore_1.SetActive(false);
        marterialsWorthMore_2.SetActive(false);
        marterialsWorthMore_3.SetActive(false);
        marterialsWorthMore_4.SetActive(false);
        marterialsWorthMore_5.SetActive(false);
        marterialsWorthMore_6.SetActive(false);
        marterialsWorthMore_7.SetActive(false);
        marterialsWorthMore_8.SetActive(false);

        goldChunk_1.SetActive(false);
        goldChunk_2.SetActive(false);
        goldChunk_3.SetActive(false);
        goldChunk_4.SetActive(false);
        goldChunk_5_.SetActive(false);
        fullGold_1.SetActive(false);
        fullGold_2.SetActive(false);
        fullGold_3.SetActive(false);

        spawnCopper.SetActive(false);
        copperChunk_1.SetActive(false);
        copperChunk_2.SetActive(false);
        copperChunk_3.SetActive(false);
        fullCopper_1.SetActive(false);
        fullCopper_2.SetActive(false);
        fullCopper_3.SetActive(false);

        spawnIron.SetActive(false);
        ironChunk_1.SetActive(false);
        ironChunk_2.SetActive(false);
        fullIron_1.SetActive(false);
        fullIron_2.SetActive(false);

        cobaltSpawn.SetActive(false);
        cobaltChunk_1.SetActive(false);
        fullCobalt_1.SetActive(false);

        uraniumSpawn.SetActive(false);
        uraniumChunk_1.SetActive(false);
        fullUranium_1.SetActive(false);

        ismiumSpawn.SetActive(false);
        ismiumChunk_1.SetActive(false);
        fullIsmium_1.SetActive(false);

        iridiumSpawn.SetActive(false);
        iridiumChunk_1.SetActive(false);
        fullIridium_1.SetActive(false);

        painiteSpawn.SetActive(false);
        painiteChunk_1.SetActive(false);
        fullPainite_1.SetActive(false);

        improvedPickaxe_1.SetActive(false);
        improvedPickaxe_2.SetActive(false);
        improvedPickaxe_3.SetActive(false);
        improvedPickaxe_4.SetActive(false);
        improvedPickaxe_5.SetActive(false);
        improvedPickaxe_6.SetActive(false);

        biggerMiningErea_1.SetActive(false);
        biggerMiningErea_2.SetActive(false);
        biggerMiningErea_3.SetActive(false);
        biggerMiningErea_4.SetActive(false);
        shootCircleChance.SetActive(false);
        increaseAndDecreaseMinignErea.SetActive(false);

        spawnRockEveryXrock_1.SetActive(false);
        spawnRockEveryXrock_2.SetActive(false);
        spawnRockEveryXrock_3.SetActive(false);
        spawnXRockEveryXSecond_1.SetActive(false);
        spawnXRockEveryXSecond_2.SetActive(false);
        spawnXRockEveryXSecond_3.SetActive(false);
        chanceToSpawnRockWhenMined_1.SetActive(false);
        chanceToSpawnRockWhenMined_2.SetActive(false);
        chanceToSpawnRockWhenMined_3.SetActive(false);
        chanceToSpawnRockWhenMined_4.SetActive(false);
        chanceToSpawnRockWhenMined_5.SetActive(false);
        chanceToSpawnRockWhenMined_6.SetActive(false);

        chanceToMineRandomRock_1.SetActive(false);
        chanceToMineRandomRock_2.SetActive(false);
        chanceToMineRandomRock_3.SetActive(false);
        chanceToMineRandomRock_4.SetActive(false);
        spawnPickaxeEverySecond_1.SetActive(false);
        spawnPickaxeEverySecond_2.SetActive(false);
        spawnPickaxeEverySecond_3.SetActive(false);

        moreTime_1.SetActive(false);
        moreTime_2.SetActive(false);
        moreTime_3.SetActive(false);
        moreTime_4.SetActive(false);
        chanceToAdd1SecondEverySecond.SetActive(false);
        chanceAdd1SecondEveryRockMined.SetActive(false);

        doubleXpGoldChance_1.SetActive(false);
        doubleXpGoldChance_2.SetActive(false);
        doubleXpGoldChance_3.SetActive(false);
        doubleXpGoldChance_4.SetActive(false);
        doubleXpGoldChance_5.SetActive(false);

        allProjectileDoubleDamageChance.SetActive(false);
        allProjectileTriggerChance.SetActive(false);

        pickaxeDoubleDamageChance_1.SetActive(false);
        pickaxeDoubleDamageChance_2.SetActive(false);

        intaMineChance_1.SetActive(false);
        intaMineChance_2.SetActive(false);

        increaseSpawnChanceAllRocks.SetActive(false);

        craft2Material.SetActive(false);

        finalUpgrade.SetActive(false);

        #endregion

        #region Set all locked ACTIVE
        moreXP_1_LOCKED.SetActive(true);
        moreXP_2_LOCKED.SetActive(true);
        moreXP_3_LOCKED.SetActive(true);
        moreXP_4_LOCKED.SetActive(true);
        moreXP_5_LOCKED.SetActive(true);
        moreXP_6_LOCKED.SetActive(true);
        moreXP_7_LOCKED.SetActive(true);
        moreXP_8_LOCKED.SetActive(true);
        talentPointsPerXlevel_1_LOCKED.SetActive(true);
        talentPointsPerXlevel_2_LOCKED.SetActive(true);
        talentPointsPerXlevel_3_LOCKED.SetActive(true);

        spawnMoreRocks_1_LOCKED.SetActive(true);
        spawnMoreRocks_2_LOCKED.SetActive(true);
        spawnMoreRocks_3_LOCKED.SetActive(true);
        spawnMoreRocks_4_LOCKED.SetActive(true);
        spawnMoreRocks_5_LOCKED.SetActive(true);
        spawnMoreRocks_6_LOCKED.SetActive(true);
        spawnMoreRocks_7_LOCKED.SetActive(true);
        spawnMoreRocks_8_LOCKED.SetActive(true);
        spawnMoreRocks_9_LOCKED.SetActive(true);

        moreMeterialsFromRock_1_LOCKED.SetActive(true);
        moreMeterialsFromRock_2_LOCKED.SetActive(true);
        moreMeterialsFromRock_3_LOCKED.SetActive(true);
        moreMeterialsFromRock_4_LOCKED.SetActive(true);
        moreMeterialsFromRock_5_LOCKED.SetActive(true);

        marterialsWorthMore_1_LOCKED.SetActive(true);
        marterialsWorthMore_2_LOCKED.SetActive(true);
        marterialsWorthMore_3_LOCKED.SetActive(true);
        marterialsWorthMore_4_LOCKED.SetActive(true);
        marterialsWorthMore_5_LOCKED.SetActive(true);
        marterialsWorthMore_6_LOCKED.SetActive(true);
        marterialsWorthMore_7_LOCKED.SetActive(true);
        marterialsWorthMore_8_LOCKED.SetActive(true);

        goldChunk_1_LOCKED.SetActive(true);
        goldChunk_2_LOCKED.SetActive(true);
        goldChunk_3_LOCKED.SetActive(true);
        goldChunk_4_LOCKED.SetActive(true);
        goldChunk_5_LOCKED.SetActive(true);
        fullGold_1_LOCKED.SetActive(true);
        fullGold_2_LOCKED.SetActive(true);
        fullGold_3_LOCKED.SetActive(true);

        spawnCopper_LOCKED.SetActive(true);
        copperChunk_1_LOCKED.SetActive(true);
        copperChunk_2_LOCKED.SetActive(true);
        copperChunk_3_LOCKED.SetActive(true);
        fullCopper_1_LOCKED.SetActive(true);
        fullCopper_2_LOCKED.SetActive(true);
        fullCopper_3_LOCKED.SetActive(true);

        spawnIron_LOCKED.SetActive(true);
        ironChunk_1_LOCKED.SetActive(true);
        ironChunk_2_LOCKED.SetActive(true);
        fullIron_1_LOCKED.SetActive(true);
        fullIron_2_LOCKED.SetActive(true);

        cobaltSpawn_LOCKED.SetActive(true);
        cobaltChunk_1_LOCKED.SetActive(true);
        fullCobalt_1_LOCKED.SetActive(true);

        uraniumSpawn_LOCKED.SetActive(true);
        uraniumChunk_1_LOCKED.SetActive(true);
        fullUranium_1_LOCKED.SetActive(true);

        ismiumSpawn_LOCKED.SetActive(true);
        ismiumChunk_1_LOCKED.SetActive(true);
        fullIsmium_1_LOCKED.SetActive(true);

        iridiumSpawn_LOCKED.SetActive(true);
        iridiumChunk_1_LOCKED.SetActive(true);
        fullIridium_1_LOCKED.SetActive(true);

        painiteSpawn_LOCKED.SetActive(true);
        painiteChunk_1_LOCKED.SetActive(true);
        fullPainite_1_LOCKED.SetActive(true);

        improvedPickaxe_1_LOCKED.SetActive(true);
        improvedPickaxe_2_LOCKED.SetActive(true);
        improvedPickaxe_3_LOCKED.SetActive(true);
        improvedPickaxe_4_LOCKED.SetActive(true);
        improvedPickaxe_5_LOCKED.SetActive(true);
        improvedPickaxe_6_LOCKED.SetActive(true);

        biggerMiningErea_1_LOCKED.SetActive(true);
        biggerMiningErea_2_LOCKED.SetActive(true);
        biggerMiningErea_3_LOCKED.SetActive(true);
        biggerMiningErea_4_LOCKED.SetActive(true);
        shootCircleChance_LOCKED.SetActive(true);
        increaseAndDecreaseMinignErea_LOCKED.SetActive(true);

        spawnRockEveryXrock_1_LOCKED.SetActive(true);
        spawnRockEveryXrock_2_LOCKED.SetActive(true);
        spawnRockEveryXrock_3_LOCKED.SetActive(true);

        spawnXRockEveryXSecond_1_LOCKED.SetActive(true);
        spawnXRockEveryXSecond_2_LOCKED.SetActive(true);
        spawnXRockEveryXSecond_3_LOCKED.SetActive(true);

        chanceToSpawnRockWhenMined_1_LOCKED.SetActive(true);
        chanceToSpawnRockWhenMined_2_LOCKED.SetActive(true);
        chanceToSpawnRockWhenMined_3_LOCKED.SetActive(true);
        chanceToSpawnRockWhenMined_4_LOCKED.SetActive(true);
        chanceToSpawnRockWhenMined_5_LOCKED.SetActive(true);
        chanceToSpawnRockWhenMined_6_LOCKED.SetActive(true);

        chanceToMineRandomRock_1_LOCKED.SetActive(true);
        chanceToMineRandomRock_2_LOCKED.SetActive(true);
        chanceToMineRandomRock_3_LOCKED.SetActive(true);
        chanceToMineRandomRock_4_LOCKED.SetActive(true);

        spawnPickaxeEverySecond_1_LOCKED.SetActive(true);
        spawnPickaxeEverySecond_2_LOCKED.SetActive(true);
        spawnPickaxeEverySecond_3_LOCKED.SetActive(true);

        moreTime_1_LOCKED.SetActive(true);
        moreTime_2_LOCKED.SetActive(true);
        moreTime_3_LOCKED.SetActive(true);
        moreTime_4_LOCKED.SetActive(true);
        chanceToAdd1SecondEverySecond_LOCKED.SetActive(true);
        chanceAdd1SecondEveryRockMined_LOCKED.SetActive(true);

        doubleXpGoldChance_1_LOCKED.SetActive(true);
        doubleXpGoldChance_2_LOCKED.SetActive(true);
        doubleXpGoldChance_3_LOCKED.SetActive(true);
        doubleXpGoldChance_4_LOCKED.SetActive(true);
        doubleXpGoldChance_5_LOCKED.SetActive(true);

        lightningBeamChanceS_1_LOCKED.SetActive(true);
        lightningBeamChanceS_2_LOCKED.SetActive(true);
        lightningBeamChancePH_1_LOCKED.SetActive(true);
        lightningBeamChancePH_2_LOCKED.SetActive(true);
        lightningBeamSpawnAnotherOneChance_LOCKED.SetActive(true);
        lightningBeamDamage_LOCKED.SetActive(true);
        lightningBeamSize_LOCKED.SetActive(true);
        lightningSplashes_LOCKED.SetActive(true);
        lightningBeamSpawnRock_LOCKED.SetActive(true);
        lightningBeamExplosion_LOCKED.SetActive(true);
        lightningBeamAddTime_LOCKED.SetActive(true);

        dynamiteChance_1_LOCKED.SetActive(true);
        dynamiteChance_2_LOCKED.SetActive(true);
        dynamiteSpawn2SmallChance_LOCKED.SetActive(true);
        dynamiteExplosionSize_LOCKED.SetActive(true);
        dynamiteDamage_LOCKED.SetActive(true);
        dynamiteExplosionSpawnRock_LOCKED.SetActive(true);
        dynamiteExplosionAddTimeChance_LOCKED.SetActive(true);
        dynamiteExplosionSpawnLightning_LOCKED.SetActive(true);

        plazmaBallSpawn_1_LOCKED.SetActive(true);
        plazmaBallSpawn_2_LOCKED.SetActive(true);
        plazmaBallTime_LOCKED.SetActive(true);
        plazmaBallSize_LOCKED.SetActive(true);
        plazmaBallExplosionChance_LOCKED.SetActive(true);
        plazmaBallSpawnSmallChance_LOCKED.SetActive(true);
        plazmaBallDamage_LOCKED.SetActive(true);
        plazmaBallSpawnPickaxeChance_LOCKED.SetActive(true);

        allProjectileDoubleDamageChance_LOCKED.SetActive(true);
        allProjectileTriggerChance_LOCKED.SetActive(true);

        pickaxeDoubleDamageChance_1_LOCKED.SetActive(true);
        pickaxeDoubleDamageChance_2_LOCKED.SetActive(true);

        intaMineChance_1_LOCKED.SetActive(true);
        intaMineChance_2_LOCKED.SetActive(true);

        increaseSpawnChanceAllRocks_LOCKED.SetActive(true);
        craft2Material_LOCKED.SetActive(true);
        finalUpgrade_LOCKED.SetActive(true);



        #endregion

        //All non _purchased and _purchaseCount
        totalMaterialRocksSpawning = 1;

        totalSkillTreeUpgradesPurchased = 0;
        totalUpgradesFullyPurchased = 0;
        mineSessionTime = 12;
        totalRocksToSpawn = 25;
        extraTalentPointPerLevel = 7;

        // === Rock chances ===
        goldRockChance = 11f;
        fullGoldRockChance = 4;
        copperRockChance = 3.5f;
        fullCopperRockChance = 2.3f;
        ironRockChance = 2.5f;
        fullIronRockChance = 1.5f;
        cobaltRockChance = 1.5f;
        fullCobaltRockChance = 1.1f;
        uraniumRockChance = 1.2f;
        fullUraniumRockChance = 1;
        ismiumRockChance = 0.8f;
        fullIsmiumRockChance = 0.7f;
        iridiumRockChance = 0.6f;
        fullIridiumRockChance = 0.5f;
        painiteRockChance = 0.35f;
        fullPainiteRockChance = 0.25f;

        // === Pickaxe ===
        improvedPickaxeStrength = 1f;
        reducePickaxeMineTime = 0f;

        // === Mining Area ===
        miningAreaSize = 1f;

        // === Spawn rocks ===
        spawnRockEveryXRock = 5f;
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
}
