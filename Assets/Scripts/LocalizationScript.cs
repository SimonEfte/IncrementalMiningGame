using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LocalizationScript : MonoBehaviour
{
    public static string languageName;

    public TextMeshProUGUI skillTreeName_text, skillTreeDesc_text, skillTreePrice_text, skillTreePurchased_text;

    private void Awake()
    {
        languageName = "English";
        NoChangeStrings();
    }

    public static double currentHoverPrice;
    public static int currentPurchaseCount, currentTotalPurchaseCount;

    public void SetSkillTreeTexts(string upgradeName, int upgradeType, double upgradePrice, int purchaseCount, int totalPurchaseCount)
    {
        currentHoverPrice = upgradePrice;
        currentPurchaseCount = purchaseCount;
        currentTotalPurchaseCount = totalPurchaseCount;

        if (languageName == "English") { SkillTreeTextENGLISH(upgradeName, upgradeType, upgradePrice, purchaseCount, totalPurchaseCount); }
    }

    #region Set no change strings - Pickaxe names
    public static string pickaxe1_name, pickaxe2_name, pickaxe3_name, pickaxe4_name,pickaxe5_name, pickaxe6_name, pickaxe7_name, pickaxe8_name,pickaxe9_name, pickaxe10_name, pickaxe11_name, pickaxe12_name, pickaxe13_name, pickaxe14_name;

    public void NoChangeStrings()
    {
        #region English
        if(languageName == "English")
        {
            pickaxe1_name = "Mr. Rusty";
            pickaxe2_name = "Sir. Goldy";
            pickaxe3_name = "Royale-Pick";
            pickaxe4_name = "Old Reliable";
            pickaxe5_name = "The Opulaxe";
            pickaxe6_name = "Stonesplitter";
            pickaxe7_name = "Dagger-Pick";
            pickaxe8_name = "Uranium Fever";
            pickaxe9_name = "Forgeborn ";
            pickaxe10_name = "Crimson Sovereign";
            pickaxe11_name = "The Gemcutter";
            pickaxe12_name = "Kings Companion";
            pickaxe13_name = "The Crusher";
            pickaxe14_name = "Diamond Pickaxe";
        }
        #endregion
    }
    #endregion

    #region All increse variables
    public static int rockSpawnIncrease;
    public static float xpIncrease;
    public static int moreTalentPointsReduce;

    //Rock chance increases
    public static float goldRockChanceIncrease;
    public static float fullGoldRockChanceIncrease;

    public static float copperRockChanceIncrease;
    public static float fullCopperRockChanceIncrease;

    public static float ironRockChanceIncrease;
    public static float fullIronRockChanceIncrease;

    public static float cobaltRockChanceIncrease;
    public static float fullCobaltRockChanceIncrease;

    public static float uraniumRockChanceIncrease;
    public static float fullUraniumRockChanceIncrease;

    public static float ismiumRockChanceIncrease;
    public static float fullIsmiumRockChanceIncrease;

    public static float iridiumRockChanceIncrease;
    public static float fullIridiumRockChanceIncrease;

    public static float painiteRockChanceIncrease;
    public static float fullPainiteRockChanceIncrease;

    public static float improvedPickaxeIncrease;

    public static float miningAreaIncrease;

    public static float spawnEveryRockIncrease;
    public static float spawnEverySecondIncrease;
    public static float spawnWhenMinedIncrease;

    //Materials dropped from rocks
    public static int materialsFromChunkRocksIncrease;
    public static int materialsFromFullRocksIncrease;

    //Materials worth more
    public static float materialsWorthIncrease;

    //Chance to spawn pickaxe
    public static float chanceToMineRandomRockIncrease;
    public static float spawnPickaxeEverySecondIncrease;

    //More time
    public static int moreTimeIncrease;

    public static float doubleXpAndGoldChanceIncrease;

    //Lightning
    public static float lightningTriggerChanceS_Increase, lightningTriggerChancePH_Increase;
    public static float lightningDamageIncrease;
    public static float lightningSizeIncrease;

    //Dynamite
    public static float dynamiteStickChanceIncrease;
    public static float explosionSizeIncrease;
    public static float explosionDamagageIncrease;

    //Plazma ball
    public static float plazmaBallChanceIncrease;
    public static float plazmaBallTimerIncrease;
    public static float plazmaBallTotalSizeIncrease;
    public static float plazmaBallTotalDamageIncrease;

    //Misc
    public static float doubleDamageChanceIncrease;
    public static float instaMineChanceIncrease;
    #endregion

    #region Skill tree texts
    public static double currentSkillTreePrice;

    public void SkillTreeTextENGLISH(string upgradeName, int upgradeType, double upgradePrice, int purchaseCount, int totalPurchaseCount)
    {
        bool isPurchasedMax;
        isPurchasedMax = false;

        if (purchaseCount >= totalPurchaseCount) { isPurchasedMax = true; }

        #region Spawn more rocks
        if (upgradeType == 1)
        {
            float nextTotalRocks = 0;

            skillTreeName_text.text = "More Rocks";

            if (upgradeName == "Rock1") //15
            {
                rockSpawnIncrease = 4;
            }
            else if (upgradeName == "Rock2") //16
            {
                rockSpawnIncrease = 5;
            }
            else if (upgradeName == "Rock3") //24
            {
                rockSpawnIncrease = 6;
            }
            else if (upgradeName == "Rock4") //30
            {
                rockSpawnIncrease = 7;
            }
            else if (upgradeName == "Rock5") //35
            {
                rockSpawnIncrease = 7;
            }
            else if (upgradeName == "Rock6") //36
            {
                rockSpawnIncrease = 10;
            }
            else if (upgradeName == "Rock7") //39
            {
                rockSpawnIncrease = 12;
            }
            else if (upgradeName == "Rock8") //42
            {
                rockSpawnIncrease = 15;
            }
            else if (upgradeName == "Rock9") //60
            {
                rockSpawnIncrease = 16;
            }

            nextTotalRocks = SkillTree.totalRocksToSpawn + rockSpawnIncrease;

            if (isPurchasedMax == true) { skillTreeDesc_text.text = $"Total rock spawn count:\n{SkillTree.totalRocksToSpawn}"; }
            else { skillTreeDesc_text.text = $"More rocks spawn in the beginning:\n{SkillTree.totalRocksToSpawn}->{nextTotalRocks}"; }
        }
        #endregion

        #region XP and talent Points
        else if (upgradeType == 2)
        {
            float nextXPIncrease = 0;

            if (upgradeName == "XP1")
            {
                xpIncrease = 0.02f;

            }
            else if (upgradeName == "XP2")
            {
                xpIncrease = 0.04f;
            }
            else if (upgradeName == "XP3")
            {
                xpIncrease = 0.08f;
            }
            else if (upgradeName == "XP4")
            {
                xpIncrease = 0.13f;
            }
            else if (upgradeName == "XP5")
            {
                xpIncrease = 0.2f;
            }
            else if (upgradeName == "XP6")
            {
                xpIncrease = 0.35f;
            }
            else if (upgradeName == "XP7")
            {
                xpIncrease = 0.55f;
            }
            else if (upgradeName == "XP8")
            {
                xpIncrease = 0.9f;
            }

            if (upgradeName == "Talent1")
            {
                moreTalentPointsReduce = 1;
                skillTreeName_text.text = "More Talent Points";
                if (SkillTree.talentPointsPerXlevel_1_purchaseCount >= 1) { isPurchasedMax = true; moreTalentPointsReduce = 0; }
               
                skillTreeDesc_text.text = $"Receive 1 extra talent point per {SkillTree.extraTalentPointPerLevel - moreTalentPointsReduce} levels";
            }
            else if (upgradeName == "Talent2")
            {
                moreTalentPointsReduce = 2;
                skillTreeName_text.text = "More Talent Points";
                if (SkillTree.talentPointsPerXlevel_2_purchaseCount >= 1) { isPurchasedMax = true; moreTalentPointsReduce = 0; }

                skillTreeDesc_text.text = $"Receive 1 extra talent point per {SkillTree.extraTalentPointPerLevel - moreTalentPointsReduce} levels";
            }
            else if (upgradeName == "Talent3")
            {
                moreTalentPointsReduce = 2;
                skillTreeName_text.text = "More Talent Points";
                if (SkillTree.talentPointsPerXlevel_3_purchaseCount >= 1) { isPurchasedMax = true; moreTalentPointsReduce = 0; }
           
                skillTreeDesc_text.text = $"Receive 1 extra talent point per {SkillTree.extraTalentPointPerLevel - moreTalentPointsReduce} levels";
            }
            else
            {
                skillTreeName_text.text = "More XP";
                nextXPIncrease = LevelMechanics.xpFromRock + xpIncrease;

                if (isPurchasedMax == true) { skillTreeDesc_text.text = $"Total XP from rocks:\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}"; }
                else { skillTreeDesc_text.text = $"Increase XP received from rocks:\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}->{(nextXPIncrease * 100).ToString("F0")}"; }
            }
           
            skillTreePrice_text.text = $"Price: {upgradePrice}";
        }
        #endregion

        #region Gold rocks spawn
        else if (upgradeType == 3)
        {
            float nextGoldRockChance = 0;
            float nextFULLGoldRockChance = 0;

            bool isChunk = false;

            if (upgradeName == "GoldChunk1")
            {
                isChunk = true;
                goldRockChanceIncrease = 0.3f;
            }
            else if (upgradeName == "GoldChunk2")
            {
                isChunk = true;
                goldRockChanceIncrease = 0.3f;
            }
            else if (upgradeName == "GoldChunk3")
            {
                isChunk = true;
                goldRockChanceIncrease = 0.4f;
            }
            else if (upgradeName == "GoldChunk4")
            {
                isChunk = true;
                goldRockChanceIncrease = 0.5f;
            }
            else if (upgradeName == "GoldChunk5")
            {
                isChunk = true;
                goldRockChanceIncrease = 0.6f;
            }
            else if (upgradeName == "FullGold1")
            {
                fullGoldRockChanceIncrease = 0.2f;
            }
            else if (upgradeName == "FullGold2")
            {
                fullGoldRockChanceIncrease = 0.2f;
            }
            else if (upgradeName == "FullGold3")
            {
                fullGoldRockChanceIncrease = 0.3f;
            }

            if (isChunk == true)
            {
                skillTreeName_text.text = "More Gold Rocks";
                nextGoldRockChance = SkillTree.goldRockChance + goldRockChanceIncrease;

                if (isPurchasedMax == true)
                {
                    skillTreeDesc_text.text = $"Total gold rock spawn chance:\n{SkillTree.goldRockChance.ToString("F2")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the gold rock spawn chance:\n{SkillTree.goldRockChance.ToString("F2")}%->{nextGoldRockChance.ToString("F2")}%";
                }
            }
            else
            {
                skillTreeName_text.text = "More Full Gold Rocks";
                nextFULLGoldRockChance = SkillTree.fullGoldRockChance + fullGoldRockChanceIncrease;

                if (isPurchasedMax == true)
                {
                    skillTreeDesc_text.text = $"Total full gold rock spawn chance:\n{SkillTree.fullGoldRockChance.ToString("F2")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the full gold rock spawn chance:\n{SkillTree.fullGoldRockChance.ToString("F2")}%->{nextFULLGoldRockChance.ToString("F2")}%";
                }
            }
        }
        #endregion

        #region Copper rocks spawn
        else if (upgradeType == 4)
        {
            float nextCopperRockChance = 0;
            float nextFullCopperRockChance = 0;

            bool isSpawn = false;
            bool isChunk = false;

            if (upgradeName == "CopperSpawn")
            {
                isSpawn = true;
            }
            else if (upgradeName == "CopperChunk1")
            {
                isChunk = true;
                copperRockChanceIncrease = 0.2f;
            }
            else if (upgradeName == "CopperChunk2")
            {
                isChunk = true;
                copperRockChanceIncrease = 0.2f;
            }
            else if (upgradeName == "CopperChunk3")
            {
                isChunk = true;
                copperRockChanceIncrease = 0.3f;
            }
            else if (upgradeName == "FullCopper1")
            {
                isChunk = false;
                fullCopperRockChanceIncrease = 0.1f;
            }
            else if (upgradeName == "FullCopper2")
            {
                isChunk = false;
                fullCopperRockChanceIncrease = 0.1f;
            }
            else if (upgradeName == "FullCopper3")
            {
                isChunk = false;
                fullCopperRockChanceIncrease = 0.2f;
            }

            if (isSpawn)
            {
                skillTreeName_text.text = "Spawn Copper Rocks";
                skillTreeDesc_text.text = "Copper rocks will now start spawning!";
            }
            else if (isChunk)
            {
                skillTreeName_text.text = "More Copper Rocks";
                nextCopperRockChance = SkillTree.copperRockChance + copperRockChanceIncrease;

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Total copper rock spawn chance:\n{SkillTree.copperRockChance.ToString("F2")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the copper rock spawn chance:\n{SkillTree.copperRockChance.ToString("F2")}% -> {nextCopperRockChance.ToString("F2")}%";
                }
            }
            else
            {
                skillTreeName_text.text = "More Full Copper Rocks";
                nextFullCopperRockChance = SkillTree.fullCopperRockChance + fullCopperRockChanceIncrease;

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Total full copper rock spawn chance:\n{SkillTree.fullCopperRockChance.ToString("F2")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the full copper rock spawn chance:\n{SkillTree.fullCopperRockChance.ToString("F2")}% -> {nextFullCopperRockChance.ToString("F2")}%";
                }
            }
        }
        #endregion

        #region Iron rocks spawn
        else if (upgradeType == 5)
        {
            float nextIronRockChance = 0;
            float nextFullIronRockChance = 0;

            bool isSpawn = false;
            bool isChunk = false;

            if (upgradeName == "IronSpawn")
            {
                isSpawn = true;
            }
            else if (upgradeName == "IronChunk1")
            {
                isChunk = true;
                ironRockChanceIncrease = 0.1f;
            }
            else if (upgradeName == "IronChunk2")
            {
                isChunk = true;
                ironRockChanceIncrease = 0.2f;
            }
            else if (upgradeName == "FullIron1")
            {
                isChunk = false;
                fullIronRockChanceIncrease = 0.1f;
            }
            else if (upgradeName == "FullIron2")
            {
                isChunk = false;
                fullIronRockChanceIncrease = 0.1f;
            }

            if (isSpawn)
            {
                skillTreeName_text.text = "Spawn Iron Rocks";
                skillTreeDesc_text.text = "Iron rocks will now start spawning!";
            }
            else if (isChunk)
            {
                skillTreeName_text.text = "More Iron Rocks";
                nextIronRockChance = SkillTree.ironRockChance + ironRockChanceIncrease;

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Total iron rock spawn chance:\n{SkillTree.ironRockChance.ToString("F2")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the iron rock spawn chance:\n{SkillTree.ironRockChance.ToString("F2")}% -> {nextIronRockChance.ToString("F2")}%";
                }
            }
            else
            {
                skillTreeName_text.text = "More Full Iron Rocks";
                nextFullIronRockChance = SkillTree.fullIronRockChance + fullIronRockChanceIncrease;

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Total full iron rock spawn chance:\n{SkillTree.fullIronRockChance.ToString("F2")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the full iron rock spawn chance:\n{SkillTree.fullIronRockChance.ToString("F2")}% -> {nextFullIronRockChance.ToString("F2")}%";
                }
            }

        }
        #endregion

        #region Cobalt rocks spawn
        else if (upgradeType == 6)
        {
            float nextCobaltRockChance = 0;
            float nextFullCobaltRockChance = 0;

            bool isSpawn = false;
            bool isChunk = false;

            if (upgradeName == "CobaltSpawn")
            {
                isSpawn = true;
            }
            else if (upgradeName == "CobaltChunk1")
            {
                isChunk = true;
                cobaltRockChanceIncrease = 0.12f;
            }
            else if (upgradeName == "CobaltFull1")
            {
                isChunk = false;
                fullCobaltRockChanceIncrease = 0.15f;
            }

            if (isSpawn)
            {
                skillTreeName_text.text = "Spawn Cobalt Rocks";
                skillTreeDesc_text.text = "Cobalt rocks will now start spawning!";
            }
            else if (isChunk)
            {
                skillTreeName_text.text = "More Cobalt Rocks";
                nextCobaltRockChance = SkillTree.cobaltRockChance + cobaltRockChanceIncrease;

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Total cobalt rock spawn chance:\n{SkillTree.cobaltRockChance.ToString("F2")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the cobalt rock spawn chance:\n{SkillTree.cobaltRockChance.ToString("F2")}% -> {nextCobaltRockChance.ToString("F2")}%";
                }
            }
            else
            {
                skillTreeName_text.text = "More Full Cobalt Rocks";
                nextFullCobaltRockChance = SkillTree.fullCobaltRockChance + fullCobaltRockChanceIncrease;

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Total full cobalt rock spawn chance:\n{SkillTree.fullCobaltRockChance.ToString("F2")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the full cobalt rock spawn chance:\n{SkillTree.fullCobaltRockChance.ToString("F2")}% -> {nextFullCobaltRockChance.ToString("F2")}%";
                }
            }
        }
        #endregion

        #region Uranium rocks spawn
        else if (upgradeType == 7)
        {
            float nextUraniumRockChance = 0;
            float nextFullUraniumRockChance = 0;

            bool isSpawn = false;
            bool isChunk = false;

            if (upgradeName == "UraniumSpawn")
            {
                isSpawn = true;
            }
            else if (upgradeName == "UraniumChunk1")
            {
                isChunk = true;
                uraniumRockChanceIncrease = 0.1f;
            }
            else if (upgradeName == "FullUranium1")
            {
                isChunk = false;
                fullUraniumRockChanceIncrease = 0.08f;
            }

            if (isSpawn)
            {
                skillTreeName_text.text = "Spawn Uranium Rocks";
                skillTreeDesc_text.text = "Uranium rocks will now start spawning!";
            }
            else if (isChunk)
            {
                skillTreeName_text.text = "More Uranium Rocks";
                nextUraniumRockChance = SkillTree.uraniumRockChance + uraniumRockChanceIncrease;

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Total uranium rock spawn chance:\n{SkillTree.uraniumRockChance.ToString("F2")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the uranium rock spawn chance:\n{SkillTree.uraniumRockChance.ToString("F2")}% -> {nextUraniumRockChance.ToString("F2")}%";
                }
            }
            else
            {
                skillTreeName_text.text = "More Full Uranium Rocks";
                nextFullUraniumRockChance = SkillTree.fullUraniumRockChance + fullUraniumRockChanceIncrease;

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Total full uranium rock spawn chance:\n{SkillTree.fullUraniumRockChance.ToString("F2")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the full uranium rock spawn chance:\n{SkillTree.fullUraniumRockChance.ToString("F2")}% -> {nextFullUraniumRockChance.ToString("F2")}%";
                }
            }
        }
        #endregion

        #region Ismium rocks spawn
        else if (upgradeType == 8)
        {
            float nextIsmiumRockChance = 0;
            float nextFullIsmiumRockChance = 0;

            bool isSpawn = false;
            bool isChunk = false;

            if (upgradeName == "IsmiumSpawn")
            {
                isSpawn = true;
            }
            else if (upgradeName == "IsmiumChunk1")
            {
                isChunk = true;
                ismiumRockChanceIncrease = 0.09f;
            }
            else if (upgradeName == "FullIsmium1")
            {
                isChunk = false;
                fullIsmiumRockChanceIncrease = 0.07f;
            }

            if (isSpawn)
            {
                skillTreeName_text.text = "Spawn Ismium Rocks";
                skillTreeDesc_text.text = "Ismium rocks will now start spawning!";
            }
            else if (isChunk)
            {
                skillTreeName_text.text = "More Ismium Rocks";
                nextIsmiumRockChance = SkillTree.ismiumRockChance + ismiumRockChanceIncrease;

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Total ismium rock spawn chance:\n{SkillTree.ismiumRockChance.ToString("F2")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the ismium rock spawn chance:\n{SkillTree.ismiumRockChance.ToString("F2")}% -> {nextIsmiumRockChance.ToString("F2")}%";
                }
            }
            else
            {
                skillTreeName_text.text = "More Full Ismium Rocks";
                nextFullIsmiumRockChance = SkillTree.fullIsmiumRockChance + fullIsmiumRockChanceIncrease;

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Total full ismium rock spawn chance:\n{SkillTree.fullIsmiumRockChance.ToString("F2")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the full ismium rock spawn chance:\n{SkillTree.fullIsmiumRockChance.ToString("F2")}% -> {nextFullIsmiumRockChance.ToString("F2")}%";
                }
            }
        }
        #endregion

        #region Iridium rocks spawn
        else if (upgradeType == 9)
        {
            float nextIridiumRockChance = 0;
            float nextFullIridiumRockChance = 0;

            bool isSpawn = false;
            bool isChunk = false;

            if (upgradeName == "IridiumSpawn")
            {
                isSpawn = true;
            }
            else if (upgradeName == "IridiumChunk1")
            {
                isChunk = true;
                iridiumRockChanceIncrease = 0.07f;
            }
            else if (upgradeName == "IridiumFull1")
            {
                isChunk = false;
                fullIridiumRockChanceIncrease = 0.05f;
            }

            if (isSpawn)
            {
                skillTreeName_text.text = "Spawn Iridium Rocks";
                skillTreeDesc_text.text = "Iridium rocks will now start spawning!";
            }
            else if (isChunk)
            {
                skillTreeName_text.text = "More Iridium Rocks";
                nextIridiumRockChance = SkillTree.iridiumRockChance + iridiumRockChanceIncrease;

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Total iridium rock spawn chance:\n{SkillTree.iridiumRockChance.ToString("F2")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the iridium rock spawn chance:\n{SkillTree.iridiumRockChance.ToString("F2")}% -> {nextIridiumRockChance.ToString("F2")}%";
                }
            }
            else
            {
                skillTreeName_text.text = "More Full Iridium Rocks";
                nextFullIridiumRockChance = SkillTree.fullIridiumRockChance + fullIridiumRockChanceIncrease;

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Total full iridium rock spawn chance:\n{SkillTree.fullIridiumRockChance.ToString("F2")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the full iridium rock spawn chance:\n{SkillTree.fullIridiumRockChance.ToString("F2")}% -> {nextFullIridiumRockChance.ToString("F2")}%";
                }
            }
        }
        #endregion

        #region Painite rocks spawn
        else if (upgradeType == 10)
        {
            float nextPainiteRockChance = 0;
            float nextFullPainiteRockChance = 0;

            bool isSpawn = false;
            bool isChunk = false;

            if (upgradeName == "PainiteSpawn")
            {
                isSpawn = true;
            }
            else if (upgradeName == "PainiteChunk1")
            {
                isChunk = true;
                painiteRockChanceIncrease = 0.04f;
            }
            else if (upgradeName == "FullPainite1")
            {
                isChunk = false;
                fullPainiteRockChanceIncrease = 0.02f;
            }

            if (isSpawn)
            {
                skillTreeName_text.text = "Spawn Painite Rocks";
                skillTreeDesc_text.text = "Painite rocks will now start spawning!";
            }
            else if (isChunk)
            {
                skillTreeName_text.text = "More Painite Rocks";
                nextPainiteRockChance = SkillTree.painiteRockChance + painiteRockChanceIncrease;

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Total painite rock spawn chance:\n{SkillTree.painiteRockChance.ToString("F2")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the painite rock spawn chance:\n{SkillTree.painiteRockChance.ToString("F2")}% -> {nextPainiteRockChance.ToString("F2")}%";
                }
            }
            else
            {
                skillTreeName_text.text = "More Full Painite Rocks";
                nextFullPainiteRockChance = SkillTree.fullPainiteRockChance + fullPainiteRockChanceIncrease;

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Total full painite rock spawn chance:\n{SkillTree.fullPainiteRockChance.ToString("F2")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the full painite rock spawn chance:\n{SkillTree.fullPainiteRockChance.ToString("F2")}% -> {nextFullPainiteRockChance.ToString("F2")}%";
                }
            }
        }
        #endregion

        #region Lightning Beam Upgrades
        else if (upgradeType == 11)
        {
            bool isLightningS = false;
            bool isLightningPH = false;

            if (upgradeName == "LightningChanceS1")
            {
                lightningTriggerChanceS_Increase = 10;
                isLightningS = true;
            }
            else if (upgradeName == "LightningChanceS2")
            {
                lightningTriggerChanceS_Increase = 10;
                isLightningS = true;
            }
            else if (upgradeName == "LightningChancePH1")
            {
                lightningTriggerChancePH_Increase = 0.1f;
                isLightningPH = true;
            }
            else if (upgradeName == "LightningChancePH2")
            {
                lightningTriggerChancePH_Increase = 0.2f;
                isLightningPH = true;
            }

            float nextLightningSChance = 0;
            nextLightningSChance = SkillTree.lightningTriggerChanceS + lightningTriggerChanceS_Increase;

            float nextLightningPHChance = 0;
            nextLightningPHChance = SkillTree.lightningTriggerChancePH + lightningTriggerChancePH_Increase;

            if (isLightningS == true)
            {
                skillTreeName_text.text = "Lightning Beam!";

                if (isPurchasedMax == true)
                {
                    skillTreeDesc_text.text = $"Total chance to trigger lightning beam every second:\n{SkillTree.lightningTriggerChanceS.ToString("F0")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Every second, chance to shoot a lightning beam at a random rock. \n{SkillTree.lightningTriggerChanceS.ToString("F0")}% -> {nextLightningSChance.ToString("F0")}% The beam deals 2X your pickaxe power";
                }
            }
            if (isLightningPH == true)
            {
                skillTreeName_text.text = "Pickaxe Lightning!";

                if (isPurchasedMax == true)
                {
                    skillTreeDesc_text.text = $"Total chance to trigger lightning beam every pickaxe hit:\n{SkillTree.lightningTriggerChancePH.ToString("F1")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Every pickaxe hit, chance to shoot a lightning beam at a close rock\n{SkillTree.lightningTriggerChancePH.ToString("F1")}% -> {nextLightningPHChance.ToString("F1")}% The beam deals 1.5X your pickaxe power";
                }
            }
            else
            {
                if (upgradeName == "LightningSpawnAnotherChance")
                {
                    skillTreeName_text.text = "Lightning = Lightning";

                    skillTreeDesc_text.text = $"{SkillTree.triggerAnotherLighntingChance.ToString("F0")}% chance to spawn another lightning beam after each lightning beam hit";
                }
                else if (upgradeName == "LightningSplash")
                {
                    skillTreeName_text.text = "Electricity Sparks";

                    skillTreeDesc_text.text = $"Every lightning beam has a {SkillTree.lightningSplashChance.ToString("F0")}% chance to spawn 3-5 electricity sparks.\nEach spark deals {SkillTree.lightningSparkDamage}% of the lightning beams power";
                }
                else if (upgradeName == "LightningSpawnRockChance")
                {
                    skillTreeName_text.text = "Electricity = Rocks";

                    skillTreeDesc_text.text = $"Every lightning beam hit has a {SkillTree.lightningSpawnRockChance.ToString("F0")}% chance to spawn a rock.";
                }
                else if (upgradeName == "LightningExplosionChance")
                {
                    skillTreeName_text.text = "Electricity Explosion";

                    skillTreeDesc_text.text = $"Every lightning beam hit has a {SkillTree.lightningSpawnExplosionChance.ToString("F0")}% chance to trigger a dynamite explosion";
                }
                else if (upgradeName == "LightningAddTimeChance")
                {
                    skillTreeName_text.text = "Electricity = Time";

                    skillTreeDesc_text.text = $"Every lightning beam hit has a {SkillTree.lightningAddTimeChance.ToString("F0")}% chance to add 1 second to the timer";
                }
                else if (upgradeName == "LightningDamage")
                {
                    skillTreeName_text.text = "Lightning Damage";

                    lightningDamageIncrease = 0.2f;

                    float nextLightningBeamDamage = SkillTree.lightningDamage + lightningDamageIncrease;

                    if (isPurchasedMax == true)
                    {
                        skillTreeDesc_text.text = $"Total lightning beam damage:\n{(SkillTree.lightningDamage * 100).ToString("F0")}%";
                    }
                    else
                    {
                        skillTreeDesc_text.text = $"Increase the lightning beam damage:\n{(SkillTree.lightningDamage * 100).ToString("F0")}% -> {(nextLightningBeamDamage * 100).ToString("F0")}%";
                    }
                }
                else if (upgradeName == "LightningSize")
                {
                    skillTreeName_text.text = "Lightning Size";

                    lightningSizeIncrease = 0.35f;

                    float nextLightningBeamSize = SkillTree.lightningSize + lightningSizeIncrease;

                    if (isPurchasedMax == true)
                    {
                        skillTreeDesc_text.text = $"Total lightning beam size:\n{(SkillTree.lightningSize * 100).ToString("F0")}%";
                    }
                    else
                    {
                        skillTreeDesc_text.text = $"Increase the lightning beam size:\n{(SkillTree.lightningSize * 100).ToString("F0")}% -> {(nextLightningBeamSize * 100).ToString("F0")}%";
                    }
                }
            }
        }
        #endregion

        #region Dynamite
        else if (upgradeType == 12)
        {
            bool isChanceToStick = false;


            if (upgradeName == "DynamiteStickChance1")
            {
                dynamiteStickChanceIncrease = 0.5f;
                isChanceToStick = true;
            }
            if (upgradeName == "DynamiteStickChance2")
            {
                isChanceToStick = true;
                dynamiteStickChanceIncrease = 0.5f;
            }

            float nextDynamiteStickChance = SkillTree.dynamiteStickChance + dynamiteStickChanceIncrease;

            if (isChanceToStick == true)
            {
                skillTreeName_text.text = "Sticky Dynamite";

                if (isPurchasedMax == true)
                {
                    skillTreeDesc_text.text = $"Total dynamite stick chance:\n{SkillTree.dynamiteStickChance.ToString("F1")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Every pickaxe hit has a chance to stick a dynamite.\n{SkillTree.dynamiteStickChance.ToString("F1")}% -> {nextDynamiteStickChance.ToString("F1")}%. The dynamite explosion deals 1.2X your pickaxe damage.";
                }
            }
            else
            {
                if(upgradeName == "DynamiteSpawn2SmallChance")
                {
                    skillTreeName_text.text = "Explosion = Explosion";

                    skillTreeDesc_text.text = $"Every dynamite explosion has a {SkillTree.spawn2DynamiteChance.ToString("F0")}% chance to spawn 2 small explosionms.\nThe small explosion deals 33% of your the big explosion power.";
                }
                else if (upgradeName == "DynamiteSpawnRockChance")
                {
                    skillTreeName_text.text = "Explosion = Rock";

                    skillTreeDesc_text.text = $"Every dynamite explosion has a {SkillTree.chanceToSpawnRockFromExplosion.ToString("F0")}% chance to spawn a rock";
                }
                else if (upgradeName == "DynamiteAddTimeChance")
                {
                    skillTreeName_text.text = "Explosion = Time";

                    skillTreeDesc_text.text = $"Every dynamite explosion has a {SkillTree.explosionAdd1SecondChance.ToString("F0")}% chance to add 1 second";
                }
                else if (upgradeName == "DynamiteSpawnLightningChance")
                {
                    skillTreeName_text.text = "Explosion = Lightning";

                    skillTreeDesc_text.text = $"Every dynamite explosion has a {SkillTree.explosionChanceToSpawnLightning.ToString("F0")}% chance to shoot a lightning beam";
                }
                else if (upgradeName == "DynamiteDamage")
                {
                    explosionDamagageIncrease = 0.25f;

                    float nextDynamiteDamage = SkillTree.explosionDamagage + explosionDamagageIncrease;

                    skillTreeName_text.text = "Dynamite Damage";

                    if (isPurchasedMax == true)
                    {
                        skillTreeDesc_text.text = $"Total dynamite damage:\n{(SkillTree.explosionDamagage * 100).ToString("F0")}%";
                    }
                    else
                    {
                        skillTreeDesc_text.text = $"Increase the dynamite damage\n{(SkillTree.explosionDamagage * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F1")}%";
                    }
                }
                else if (upgradeName == "DynamiteSize")
                {
                    explosionSizeIncrease = 0.2f;

                    float nextDynamiteDamage = SkillTree.explosionSize + explosionSizeIncrease;

                    skillTreeName_text.text = "DynamiteSize";

                    if (isPurchasedMax == true)
                    {
                        skillTreeDesc_text.text = $"Total dynamite size:\n{(SkillTree.explosionSize * 100).ToString("F0")}%";
                    }
                    else
                    {
                        skillTreeDesc_text.text = $"Increase the dynamite explosion size\n{(SkillTree.explosionSize * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F1")}%";
                    }
                }
            }
        }
        #endregion

        #region Plazma ball
        else if (upgradeType == 13)
        {
            bool isChanceToSpawnPlazma = false;

            if (upgradeName == "PlazmaBallChance1")
            {
                plazmaBallChanceIncrease = 7f;
                isChanceToSpawnPlazma = true;
            }
            else if (upgradeName == "PlazmaBallChance2")
            {
                plazmaBallChanceIncrease = 8f;
                isChanceToSpawnPlazma = true;
            }

            float nextPlazmaBallChance = SkillTree.plazmaBallChance + plazmaBallChanceIncrease;

            if (isChanceToSpawnPlazma == true)
            {
                skillTreeName_text.text = "Plazma Ball";

                if (isPurchasedMax == true)
                {
                    skillTreeDesc_text.text = $"Plazma ball spawn chance:\n{SkillTree.plazmaBallChance.ToString("F0")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Chance to spawn a plazma ball every second that moves across the screen.\n{SkillTree.plazmaBallChance.ToString("F0")}% -> {nextPlazmaBallChance.ToString("F0")}%. The ball lasts {SkillTree.plazmaBallTimer} seconds and deals 0.75X your pickaxe power";
                }
            }
            else if (upgradeName == "PlazmaBallTime")
            {
                plazmaBallTimerIncrease = 1;

                skillTreeName_text.text = "Plazma Ball Timer";

                float nextPlazmaballTime = SkillTree.plazmaBallTimer + plazmaBallTimerIncrease;

                if (isPurchasedMax == true)
                {
                    skillTreeDesc_text.text = $"Plazma ball on screen time:\n{SkillTree.plazmaBallTimer.ToString("F0")}s";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase how long the plazma ball is on screen\n{SkillTree.plazmaBallTimer.ToString("F0")}s -> {nextPlazmaballTime.ToString("F0")}s";
                }
            }
            else if (upgradeName == "PlazmaBallSize")
            {
                plazmaBallTotalSizeIncrease = 0.2f;

                skillTreeName_text.text = "Plazma Ball Size";

                float nextPlazmaBallSize = SkillTree.plazmaBallTotalSize + plazmaBallTotalSizeIncrease;

                if (isPurchasedMax == true)
                {
                    skillTreeDesc_text.text = $"Total plazma ball size increase:\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the size of the plazma ball:\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}% -> {(nextPlazmaBallSize * 100).ToString("F0")}%";
                }
            }
            else if (upgradeName == "PlazmaBallDamage")
            {
                plazmaBallTotalDamageIncrease = 0.2f;

                skillTreeName_text.text = "Plazma Ball Damage";

                float nextPlazmaBallDamage = SkillTree.plazmaBallTotalDamage + plazmaBallTotalDamageIncrease;

                if (isPurchasedMax == true)
                {
                    skillTreeDesc_text.text = $"Total plazma ball damage increase:\n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the plazma ball damage: \n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}% -> {(nextPlazmaBallDamage * 100).ToString("F0")}%";
                }
            }
            else if (upgradeName == "PlazmaBallExplosionChance")
            {
                skillTreeName_text.text = "Plazma Ball Explosion";

                skillTreeDesc_text.text = $"{(SkillTree.plazmaballExplosionChance).ToString("F0")}% chance to cause a dynamite explosion upon plazma ball despawn";
            }
            else if (upgradeName == "PlazmbaBallSpawnSmallChance")
            {
                skillTreeName_text.text = "Tiny Plazma Balls";

                skillTreeDesc_text.text = $"The plazma ball has a {(SkillTree.plazmaBallSpawnSmallBallChance).ToString("F0")}% chance to spawn a small ball\nevery second that is it on screen. It has the same stats as the big plazma ball.";
            }
            else if (upgradeName == "PlazmaBallChanceToSpawnPickaxe")
            {
                skillTreeName_text.text = "Tiny Plazma Pickaxe";

                skillTreeDesc_text.text = $"{(SkillTree.plazmaBallChanceToSpawnPickaxe).ToString("F0")}% chance to spawn a pickaxe every time the plazma ball hits a rock";
            }
        }
        #endregion

        #region More Materials Per Rock
        else if (upgradeType == 14)
        {
            int nextMoreMaterials = 0;

            if (upgradeName == "MaterialsPerRock1")
            {
                materialsFromChunkRocksIncrease = 1;
                materialsFromFullRocksIncrease = 1;
            }
            else if (upgradeName == "MaterialsPerRock2")
            {
                materialsFromChunkRocksIncrease = 1;
                materialsFromFullRocksIncrease = 1;
            }
            else if (upgradeName == "MaterialsPerRock3")
            {
                materialsFromChunkRocksIncrease = 1;
                materialsFromFullRocksIncrease = 1;
            }
            else if (upgradeName == "MaterialsPerRock4")
            {
                materialsFromChunkRocksIncrease = 1;
                materialsFromFullRocksIncrease = 2;
            }
            else if (upgradeName == "MaterialsPerRock5")
            {
                materialsFromChunkRocksIncrease = 1;
                materialsFromFullRocksIncrease = 2;
            }

            nextMoreMaterials = SkillTree.materialsFromChunkRocks + materialsFromChunkRocksIncrease;
            int nextMoreMaterialsFULL = SkillTree.materialsFromFullRocks + materialsFromFullRocksIncrease;

            skillTreeName_text.text = "More Materials From Rocks";

            if (isPurchasedMax)
            {
                skillTreeDesc_text.text = $"Materials dropped from material rocks: {SkillTree.materialsFromChunkRocks}\nMaterials dropped from full material rocks: {SkillTree.materialsFromFullRocks}";
            }
            else
            {
                skillTreeDesc_text.text = $"Materials dropped from material rocks: {SkillTree.materialsFromChunkRocks} -> {nextMoreMaterials}\nMaterials dropped from full material rocks: {SkillTree.materialsFromFullRocks} -> {nextMoreMaterialsFULL}";
            }

            skillTreePrice_text.text = $"Price: {upgradePrice}";
            skillTreePurchased_text.text = $"Purchased: {purchaseCount}/{totalPurchaseCount}";
        }
        #endregion

        #region Materials Worth More
        else if (upgradeType == 15)
        {
            float nextMaterialsWorthMore = 0f;

            if (upgradeName == "MaterialsWorthMore1")
            {
                materialsWorthIncrease = 1;
            }
            else if (upgradeName == "MaterialsWorthMore2")
            {
                materialsWorthIncrease = 2f;
            }
            else if (upgradeName == "MaterialsWorthMore3")
            {
                materialsWorthIncrease = 4f;
            }
            else if (upgradeName == "MaterialsWorthMore4")
            {
                materialsWorthIncrease = 8f;
            }
            else if (upgradeName == "MaterialsWorthMore5")
            {
                materialsWorthIncrease = 15f;
            }
            else if (upgradeName == "MaterialsWorthMore6")
            {
                materialsWorthIncrease = 35;
            }
            else if (upgradeName == "MaterialsWorthMore7")
            {
                materialsWorthIncrease = 50f;
            }
            else if (upgradeName == "MaterialsWorthMore8")
            {
                materialsWorthIncrease = 100f;
            }

            nextMaterialsWorthMore = SkillTree.materialsTotalWorth + materialsWorthIncrease;

            skillTreeName_text.text = "More Ores";

            if (isPurchasedMax)
            {
                skillTreeDesc_text.text = $"Total value of mined ores:\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}%";
            }
            else
            {
                skillTreeDesc_text.text = $"Increase the value of every mined ore:\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}% -> {(nextMaterialsWorthMore * 100).ToString("F0")}%";
            }
        }
        #endregion

        #region Improved Pickaxe
        else if (upgradeType == 16)
        {
            float nextPickaxeStrength = 0;

            if (upgradeName == "ImprovedPickaxe1")
            {
                improvedPickaxeIncrease = 0.02f;
            }
            else if (upgradeName == "ImprovedPickaxe2")
            {
                improvedPickaxeIncrease = 0.02f;
            }
            else if (upgradeName == "ImprovedPickaxe3")
            {
                improvedPickaxeIncrease = 0.04f;
            }
            else if (upgradeName == "ImprovedPickaxe4")
            {
                improvedPickaxeIncrease = 0.05f;
            }
            else if (upgradeName == "ImprovedPickaxe5")
            {
                improvedPickaxeIncrease = 0.06f;
            }
            else if (upgradeName == "ImprovedPickaxe6")
            {
                improvedPickaxeIncrease = 0.08f;
            }

            skillTreeName_text.text = "Improved Pickaxe";
            nextPickaxeStrength = SkillTree.improvedPickaxeStrength + improvedPickaxeIncrease;

            if (isPurchasedMax)
            {
                skillTreeDesc_text.text = $"Total pickaxe stat increase:\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F0")}%";
            }
            else
            {
                skillTreeDesc_text.text = $"Increase all pickaxe stats:\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F0")}% -> {(nextPickaxeStrength * 100).ToString("F0")}%";
            }
        }
        #endregion

        #region Bigger Mining Area
        else if (upgradeType == 17)
        {
            float nextMiningArea = 0;

            bool isFunctional = false;

            if (upgradeName == "BiggerMiningErea1")
            {
                miningAreaIncrease = 0.02f;
            }
            else if (upgradeName == "BiggerMiningErea2")
            {
                miningAreaIncrease = 0.02f;
            }
            else if (upgradeName == "BiggerMiningErea3")
            {
                miningAreaIncrease = 0.02f;
            }
            else if (upgradeName == "BiggerMiningErea4")
            {
                miningAreaIncrease = 0.03f;
            }
            else if (upgradeName == "ShootCircle")
            {
                isFunctional = true;
            }
            else if (upgradeName == "IncreaseAndDecreaseCircle")
            {
                isFunctional = true;
            }

            if (isFunctional)
            {
                if (upgradeName == "ShootCircle")
                {
                    skillTreeName_text.text = "Circle Shots";
                    skillTreeDesc_text.text = $"Every second, a small circle has a {SkillTree.circleShootChance}% chance to shoot in a random direction.\nRocks inside this circle will be mined.";
                }
                else if (upgradeName == "IncreaseAndDecreaseCircle")
                {
                    skillTreeName_text.text = "In and Out";
                    skillTreeDesc_text.text = "The mining erea will increase and decrease in size:\n120%-90%";
                }
            }
            else
            {
                skillTreeName_text.text = "Bigger Mining Area";
                nextMiningArea = SkillTree.miningAreaSize + miningAreaIncrease;

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Total mining erea size increase:\n{(SkillTree.miningAreaSize * 100).ToString("F0")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase mining area size:\n{(SkillTree.miningAreaSize *100 ).ToString("F0")}% -> {(nextMiningArea * 100).ToString("F0")}%";
                }
            }
        }
        #endregion

        #region Chance to spawn rock
        else if (upgradeType == 18)
        {
            float nextValue = 0;

            bool isEveryRock = false;
            bool isEverySecond = false;
            bool isWhenMined = false;

            if (upgradeName == "EveryXRockSpawnRock1")
            {
                isEveryRock = true;
                spawnEveryRockIncrease = 1f;
                if (purchaseCount >= totalPurchaseCount) { isPurchasedMax = true; spawnEveryRockIncrease = 0f; }
            }
            else if (upgradeName == "EveryXRockSpawnRock2")
            {
                isEveryRock = true;
                spawnEveryRockIncrease = 1f;
                if (purchaseCount >= totalPurchaseCount) { isPurchasedMax = true; spawnEveryRockIncrease = 0f; }
            }
            else if (upgradeName == "EveryXRockSpawnRock3")
            {
                isEveryRock = true;
                spawnEveryRockIncrease = 1f;
                if (purchaseCount >= totalPurchaseCount) { isPurchasedMax = true; spawnEveryRockIncrease = 0f; }
            }


            else if (upgradeName == "SpawnRockEveryXSecond1")
            {
                isEverySecond = true;
                spawnEverySecondIncrease = 0.5f;
                if (purchaseCount >= totalPurchaseCount) { isPurchasedMax = true; spawnEverySecondIncrease = 0; }
            }
            else if (upgradeName == "SpawnRockEveryXSecond2")
            {
                isEverySecond = true;
                spawnEverySecondIncrease = 0.6f;
                if (purchaseCount >= totalPurchaseCount) { isPurchasedMax = true; spawnEverySecondIncrease = 0; }
            }
            else if (upgradeName == "SpawnRockEveryXSecond3")
            {
                isEverySecond = true;
                spawnEverySecondIncrease = 0.4f;
                if (purchaseCount >= totalPurchaseCount) { isPurchasedMax = true; spawnEverySecondIncrease = 0; }
            }


            else if (upgradeName == "ChanceToSpawnRockWhenMined1")
            {
                isWhenMined = true;
                spawnWhenMinedIncrease = 2f; // * 5 = 10
            }
            else if (upgradeName == "ChanceToSpawnRockWhenMined2")
            {
                isWhenMined = true;
                spawnWhenMinedIncrease = 3f; // * 3 = 9
            }
            else if (upgradeName == "ChanceToSpawnRockWhenMined3")
            {
                isWhenMined = true;
                spawnWhenMinedIncrease = 3f; // * 3 = 9
            }
            else if (upgradeName == "ChanceToSpawnRockWhenMined4")
            {
                isWhenMined = true;
                spawnWhenMinedIncrease = 3f; // * 2 = 8
            }
            else if (upgradeName == "ChanceToSpawnRockWhenMined5")
            {
                isWhenMined = true;
                spawnWhenMinedIncrease = 3f; // * 2 = 8
            }
            else if (upgradeName == "ChanceToSpawnRockWhenMined6")
            {
                isWhenMined = true;
                spawnWhenMinedIncrease = 5f;  // * 1 = 5
            }

            if (isEveryRock)
            {
                skillTreeName_text.text = "Rocks Into More Rocks";
                nextValue = SkillTree.spawnRockEveryXRock - spawnEveryRockIncrease;

                skillTreeDesc_text.text = $"Spawn 1 rock for every {nextValue} rocks mined";
            }
            else if (isEverySecond)
            {
                skillTreeName_text.text = "Wait For More Rocks";
                nextValue = SkillTree.spawnXRockEveryXSecond - spawnEverySecondIncrease;

                skillTreeDesc_text.text = $"Spawn 1 rock every {nextValue.ToString("F1")} second";
            }
            else if (isWhenMined)
            {
                skillTreeName_text.text = "Rock Spawn Chance";
                nextValue = SkillTree.chanceToSpawnRockWhenMined + spawnWhenMinedIncrease;

                if (isPurchasedMax)
                    skillTreeDesc_text.text = $"Total spawn rock when rock mined chance:\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F2")}%";
                else
                    skillTreeDesc_text.text = $"Chance to spawn a rock when a rock is mined:\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F1")}% -> {nextValue.ToString("F1")}%";
            }
        }
        #endregion

        #region Chance to Spawn Pickaxe
        else if (upgradeType == 19)
        {
            float nextMineRandomChance = 0f;
            float nextPickaxeSpawnRate = 0f;

            bool isMineRandom = false;
            bool isSpawnPickaxe = false;

            if (upgradeName == "ChanceToMineRandomRock1")
            {
                isMineRandom = true;
                chanceToMineRandomRockIncrease = 1f;
            }
            else if (upgradeName == "ChanceToMineRandomRock2")
            {
                isMineRandom = true;
                chanceToMineRandomRockIncrease = 2f;
            }
            else if (upgradeName == "ChanceToMineRandomRock3")
            {
                isMineRandom = true;
                chanceToMineRandomRockIncrease = 3f;
            }
            else if (upgradeName == "ChanceToMineRandomRock4")
            {
                isMineRandom = true;
                chanceToMineRandomRockIncrease = 4f;
            }


            else if (upgradeName == "SpawnPickaxeEverySecond1")
            {
                isSpawnPickaxe = true;
                spawnPickaxeEverySecondIncrease = 0.2f;
            }
            else if (upgradeName == "SpawnPickaxeEverySecond2")
            {
                isSpawnPickaxe = true;
                spawnPickaxeEverySecondIncrease = 0.2f;
            }
            else if (upgradeName == "SpawnPickaxeEverySecond3")
            {
                isSpawnPickaxe = true;
                spawnPickaxeEverySecondIncrease = 0.3f;
            }

            if (isMineRandom)
            {
                skillTreeName_text.text = "Mine Random Rock";
                nextMineRandomChance = SkillTree.chanceToMineRandomRock + chanceToMineRandomRockIncrease;

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Total pickaxe spawn chance:\n{SkillTree.chanceToMineRandomRock.ToString("F2")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Every pickaxe hit has a chance to spawn a pickaxe and mine a random rock:\n{SkillTree.chanceToMineRandomRock.ToString("F2")}% -> {nextMineRandomChance.ToString("F2")}%";
                }
            }
            else if (isSpawnPickaxe)
            {
                skillTreeName_text.text = "Auto Mining";
                nextPickaxeSpawnRate = SkillTree.spawnPickaxeEverySecond - spawnPickaxeEverySecondIncrease;

                if (isPurchasedMax) { nextPickaxeSpawnRate = SkillTree.spawnPickaxeEverySecond; }
                skillTreeDesc_text.text = $"Mine a random rock every:\n{nextPickaxeSpawnRate.ToString("F2")}sec";
            }
        }
        #endregion

        #region More Time
        else if (upgradeType == 20)
        {
            float nextMoreTime = 0f;

            bool isAddTime = false;
            bool isChancePerSecond = false;
            bool isChanceWhenMined = false;

            if (upgradeName == "MoreTime1")
            {
                isAddTime = true;
                moreTimeIncrease = 1;
            }
            else if (upgradeName == "MoreTime2")
            {
                isAddTime = true;
                moreTimeIncrease = 1;
            }
            else if (upgradeName == "MoreTime3")
            {
                isAddTime = true;
                moreTimeIncrease = 1;
            }
            else if (upgradeName == "MoreTime4")
            {
                isAddTime = true;
                moreTimeIncrease = 1;
            }
            else if (upgradeName == "ChanceAdd1SecondEverySecond")
            {
                isChancePerSecond = true;
            }
            else if (upgradeName == "ChanceAdd1SecondEveryRockMined")
            {
                isChanceWhenMined = true;
            }

            if (isAddTime)
            {
                skillTreeName_text.text = "More Time";
                nextMoreTime = SkillTree.mineSessionTime + moreTimeIncrease;

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Total time each mining session:\n{SkillTree.mineSessionTime.ToString("F0")}s";
                }
                else
                {
                    skillTreeDesc_text.text = $"Increase the mining session time:\n{SkillTree.mineSessionTime.ToString("F0")}s -> {nextMoreTime.ToString("F0")}s";
                }
            }
            else if (isChancePerSecond)
            {
                skillTreeName_text.text = "1S=1S";

                skillTreeDesc_text.text = $"{SkillTree.chanceToAdd1SecEverySec.ToString("F0")}% chance to gain +1s to the mining session every second";
            }
            else if (isChanceWhenMined)
            {
                skillTreeName_text.text = "Rock = Time";

                skillTreeDesc_text.text = $"{SkillTree.chanceToAdd1SecEveryRockMined.ToString("F2")}% chance to gain +1s to the mining session when a rock is mined%";
            }
        }
        #endregion

        #region Double XP and Gold Chance
        else if (upgradeType == 21)
        {
            float nextDoubleChance = 0f;

            if (upgradeName == "DoubleXpAndMaterial1")
            {
                doubleXpAndGoldChanceIncrease = 1f;
            }
            else if (upgradeName == "DoubleXpAndMaterial2")
            {
                doubleXpAndGoldChanceIncrease = 2f;
            }
            else if (upgradeName == "DoubleXpAndMaterial3")
            {
                doubleXpAndGoldChanceIncrease = 3f;
            }
            else if (upgradeName == "DoubleXpAndMaterial4")
            {
                doubleXpAndGoldChanceIncrease = 4f;
            }
            else if (upgradeName == "DoubleXpAndMaterial5")
            {
                doubleXpAndGoldChanceIncrease = 5f;
            }

            nextDoubleChance = SkillTree.doubleXpAndGoldChance + doubleXpAndGoldChanceIncrease;

            skillTreeName_text.text = "Double The Wealth!";

            if (isPurchasedMax)
            {
                skillTreeDesc_text.text = $"Total material and XP double chance: \n{SkillTree.doubleXpAndGoldChance.ToString("F2")}%";
            }
            else
            {
                skillTreeDesc_text.text = $"Chance to double material and XP:\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}% -> {nextDoubleChance.ToString("F2")}%";
            }
        }
        #endregion

        #region Misc and FINAL
        else if (upgradeType == 22)
        {
            bool isDoubleDamageChance = false;
            bool isInstaMineChance = false;

            if (upgradeName == "DoubleDamageChance1")
            {
                isDoubleDamageChance = true;
                doubleDamageChanceIncrease = 1f;
            }

            if (upgradeName == "DoubleDamageChance2")
            {
                isDoubleDamageChance = true;
                doubleDamageChanceIncrease = 2f;
            }

            if (upgradeName == "InstaMine1")
            {
                isInstaMineChance = true;
                instaMineChanceIncrease = 1f;
            }
            if (upgradeName == "InstaMine2")
            {
                isInstaMineChance = true;
                instaMineChanceIncrease = 1f;
            }

            float nextDoubleDamage = SkillTree.doubleDamageChance + doubleDamageChanceIncrease;
            float nextInstaMine = SkillTree.instaMineChance + instaMineChanceIncrease;

            if (isDoubleDamageChance == true)
            {
                skillTreeName_text.text = "Double Pickaxe Power";

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Double pickaxe power chance:\n{SkillTree.doubleDamageChance.ToString("F0")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Double pickaxe power chance:\n{SkillTree.doubleDamageChance.ToString("F0")}% -> {nextDoubleDamage.ToString("F0")}%";
                }
            }
            else if (isInstaMineChance == true)
            {
                skillTreeName_text.text = "Insta Mine!";

                if (isPurchasedMax)
                {
                    skillTreeDesc_text.text = $"Insta mine rock chance:\n{SkillTree.instaMineChance.ToString("F0")}%";
                }
                else
                {
                    skillTreeDesc_text.text = $"Chance to instantly mine a rock:\n{SkillTree.instaMineChance.ToString("F0")}% -> {nextInstaMine.ToString("F0")}%";
                }
            }
            else if (upgradeName == "AllProjectleDoubleDamageChance")
            {
                skillTreeName_text.text = "Double Trouble";

                skillTreeDesc_text.text = $"Lightning, dynamite and plazma ball double damage chance:\n{SkillTree.allProjectileDoubleDamageIncrease.ToString("F0")}%";
            }
            else if (upgradeName == "IncreaseAllProjectileChance")
            {
                skillTreeName_text.text = "Trigger Chance";

                skillTreeDesc_text.text = $"Lightning, dynamite and plazma ball trigger chance increase:\n+{SkillTree.allProjcetileTriggerChance.ToString("F0")}% of their current trigger chance";
            }
            else if (upgradeName == "IncreaseAllRockSpawnChance")
            {
                skillTreeName_text.text = "More Material Rocks";

                skillTreeDesc_text.text = $"Increase all material rock spawn chance by:\n{SkillTree.allRockSpawnChanceIncrease.ToString("F0")}% of their current spawn chance";
            }
            else if (upgradeName == "2GoldBarsCraft")
            {
                skillTreeName_text.text = "Craft More!";

                skillTreeDesc_text.text = $"It now only takes 2 materials to craft a bar!";
            }
            else if (upgradeName == "FinalUpgrade")
            {
                if(SkillTree.finalUpgrade_purchased == true)
                {
                    skillTreeName_text.text = "New Location";

                    skillTreeDesc_text.text = $"You can now mine in a new location.";
                }
                else
                {
                    skillTreeName_text.text = "????????";

                    skillTreeDesc_text.text = $"???????????????";
                }
            }
        }
        #endregion

        currentSkillTreePrice = upgradePrice;

        skillTreePrice_text.text = $"Price: {upgradePrice.ToString("F0")}";
        skillTreePurchased_text.text = $"Purchased: {purchaseCount}/{totalPurchaseCount}";

        if (isPurchasedMax == true)
        {
            skillTreePrice_text.gameObject.SetActive(false);
            skillTreePurchased_text.gameObject.transform.localScale = new Vector2(1.2f, 1.2f);
            skillTreePurchased_text.gameObject.transform.localPosition = new Vector2(0, -64f);
        }
        else
        {
            skillTreePrice_text.gameObject.SetActive(true);
            skillTreePurchased_text.gameObject.transform.localScale = new Vector2(0.8f, 0.8f);
            skillTreePurchased_text.gameObject.transform.localPosition = new Vector2(0, -85f);
        }
    }
    #endregion

    #region Artifact texts
    public string artifactTooltipName;
    public string artifactDescName;

    public TextMeshProUGUI artifactName_text;
    public TextMeshProUGUI artifactDesc_text;

    public GameObject horn_tooltipImage;
    public GameObject ancientDevice_tooltipImage;
    public GameObject bone_tooltipImage;
    public GameObject meteorieOre_tooltipImage;
    public GameObject book_tooltipImage;
    public GameObject goldStack_tooltipImage;
    public GameObject goldRing_tooltipImage;
    public GameObject purpleRing_tooltipImage;
    public GameObject ancientDice_tooltipImage;
    public GameObject cheese_tooltipImage;
    public GameObject wolfClaw_tooltipImage;
    public GameObject axe_tooltipImage;
    public GameObject rune_tooltipImage;
    public GameObject skull_tooltipImage;

    public void ArtifactsTooltipText(int artifactNumber)
    {
        horn_tooltipImage.SetActive(false);
        ancientDevice_tooltipImage.SetActive(false);
        bone_tooltipImage.SetActive(false);
        meteorieOre_tooltipImage.SetActive(false);
        book_tooltipImage.SetActive(false);
        goldStack_tooltipImage.SetActive(false);
        goldRing_tooltipImage.SetActive(false);
        purpleRing_tooltipImage.SetActive(false);
        ancientDice_tooltipImage.SetActive(false);
        cheese_tooltipImage.SetActive(false);
        wolfClaw_tooltipImage.SetActive(false);
        axe_tooltipImage.SetActive(false);
        rune_tooltipImage.SetActive(false);
        skull_tooltipImage.SetActive(false);

        if (artifactNumber == 1)
        {
            float hornStats = Artifacts.hornRockDecrease;
            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                hornStats *= (1 + LevelMechanics.archeologistIncrease + Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { hornStats *= (1 + LevelMechanics.archeologistIncrease); }
                if (Artifacts.rune_found) { hornStats *= (1 + Artifacts.runeImproveAll); }
            }

            artifactTooltipName = "Ox Horn";
            artifactDescName = $"Reduces the durability of all rocks by {hornStats * 100}%";
            horn_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 2)
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

            artifactTooltipName = "Ancient Device";
            artifactDescName = $"Improved The Mine. It now mines {ancientDeviceStats * 100}% faster";
            ancientDevice_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 3)
        {
            float boneIncrease = Artifacts.bonePickaxeIncrease;
            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                boneIncrease *= (1 + LevelMechanics.archeologistIncrease + Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { boneIncrease *= (1 + LevelMechanics.archeologistIncrease); }
                if (Artifacts.rune_found) { boneIncrease *= (1 + Artifacts.runeImproveAll); }
            }

            artifactTooltipName = "Fossilized Bone";
            artifactDescName = $"Improves all pickaxe stats by {boneIncrease * 100}%";
            bone_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 4)
        {
            float meteoriteIncrease = Artifacts.meteoriteRockSpawnIncrease;
            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                meteoriteIncrease *= (1 + LevelMechanics.archeologistIncrease + Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { meteoriteIncrease *= (1 + LevelMechanics.archeologistIncrease); }
                if (Artifacts.rune_found) { meteoriteIncrease *= (1 + Artifacts.runeImproveAll); }
            }

            artifactTooltipName = "Meteorite Ore";
            artifactDescName = $"Increases the spawn chance of all full material rocks by {meteoriteIncrease * 100}% of their current chance";
            meteorieOre_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 5)
        {
            artifactTooltipName = "Cursed Book";
            artifactDescName = "Gives 1 extra talent point per 5 levels";
            book_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 6)
        {
            int rockToDouble = 25;

            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                rockToDouble = 22;
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { rockToDouble = 23; }
                if (Artifacts.rune_found) { rockToDouble = 24; }
            }

            artifactTooltipName = "Gold Stack";
            artifactDescName = $"Every {rockToDouble} material will be worth double";
            goldStack_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 7)
        {
            float ringChance = Artifacts.goldRingCraftChance;

            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                ringChance *= (1 + LevelMechanics.archeologistIncrease + Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { ringChance *= (1 + LevelMechanics.archeologistIncrease); }
                if (Artifacts.rune_found) { ringChance *= (1 + Artifacts.runeImproveAll); }
            }

            artifactTooltipName = "Golden Ring";
            artifactDescName = $"At the end of a mining session, each material mined has a {ringChance.ToString("F1")}% chance of only using 1 material to craft a bar";
            goldRing_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 8)
        {
            float purpleRignChance = Artifacts.purpleRingChance;

            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                purpleRignChance *= (1 + LevelMechanics.archeologistIncrease + Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { purpleRignChance *= (1 + LevelMechanics.archeologistIncrease); }
                if (Artifacts.rune_found) { purpleRignChance *= (1 + Artifacts.runeImproveAll); }
            }

            artifactTooltipName = "Royal Ring";
            artifactDescName = $"{purpleRignChance}% chance to receive double XP from mined rocks";
            purpleRing_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 9)
        {
            float diceTime = 1;

            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                diceTime *= (1 - LevelMechanics.archeologistIncrease - Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { diceTime *= (1 - LevelMechanics.archeologistIncrease); }
                if (Artifacts.rune_found) { diceTime *= (1 - Artifacts.runeImproveAll); }
            }

            artifactTooltipName = "Ancient Dice";
            artifactDescName = $"Spawn 1 rock every {diceTime} second";
            ancientDice_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 10)
        {
            float cheeseChance = Artifacts.cheeseChance;

            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                cheeseChance *= (1 + LevelMechanics.archeologistIncrease + Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { cheeseChance *= (1 + LevelMechanics.archeologistIncrease); }
                if (Artifacts.rune_found) { cheeseChance *= (1 + Artifacts.runeImproveAll); }
            }

            artifactTooltipName = "Holy Cheese";
            artifactDescName = $"Every pickaxe hit has a {cheeseChance.ToString("F2")}% chance to mine 1 material";
            cheese_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 11)
        {
            float claw = Artifacts.clawChance;

            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                claw *= (1 + LevelMechanics.archeologistIncrease + Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { claw *= (1 + LevelMechanics.archeologistIncrease); }
                if (Artifacts.rune_found) { claw *= (1 + Artifacts.runeImproveAll); }
            }
            artifactTooltipName = "Wolf Claw";
            artifactDescName = $"Increase the pickaxe power by {claw * 100}%";
            wolfClaw_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 12)
        {
            float doubleChanceIncrease = 2f * (1 + Artifacts.runeImproveAll + LevelMechanics.archeologistIncrease);
            float instaDecrese = 1 * (1 + Artifacts.runeImproveAll + LevelMechanics.archeologistIncrease);

            artifactTooltipName = "Orc Axe";
            artifactDescName = $"{doubleChanceIncrease}% chance to deal double pickaxe power and {instaDecrese}% chance to insta mine rocks";
            axe_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 13)
        {
            artifactTooltipName = "Runestone";
            artifactDescName = $"Improves the stats of all artifacts by {Artifacts.runeIncrease_forDisplay}% of their current stats";
            rune_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 14)
        {
            int rocksSpawn = 10;
            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found) { rocksSpawn = 11; }

            artifactTooltipName = "Ancient Skull";
            artifactDescName = $"{rocksSpawn} more rocks spawn";
            skull_tooltipImage.SetActive(true);
        }

        artifactName_text.text = artifactTooltipName;
        artifactDesc_text.text = artifactDescName;
    }
    #endregion

    #region potion texts
    public TextMeshProUGUI potionTooltipName, potionTooltipDesc;

    public void PotionText(string potionName)
    {
        if(potionName == "materialIncrease")
        {
            potionTooltipName.text = "Material Potion";
            potionTooltipDesc.text = $"Materials are worth {(SetRockScreen.potionMaterialWorthMore_increase * 100).ToString("F0")}% more";
        }
        if (potionName == "pickaxeIncrease")
        {
            potionTooltipName.text = "Pickaxe Potion";
            potionTooltipDesc.text = $"Pickaxe stats are increased by {(SetRockScreen.potionPickaxeStats_increase* 100).ToString("F0")}%";
        }
        if (potionName == "xpIncrease")
        {
            potionTooltipName.text = "XP Potion";
            potionTooltipDesc.text = $"Rocks give {(SetRockScreen.potionXp_increase * 100).ToString("F0")}% more xp";
        }
        if (potionName == "doubleXpAndMaterialIncrease")
        {
            potionTooltipName.text = "Double Chance Potion";
            potionTooltipDesc.text = $"{SetRockScreen.potionDoubleChance_increase}% higher chance for materials and xp to give double";
        }
    }
    #endregion

    #region Talent texts
    public string talentNameString, talentDescString;

    public TextMeshProUGUI talentName_tooltip, talentDesc_tooltip;

    public void TalentTexts(int talentNumber)
    {
        #region Potion drinker
        if (talentNumber == 1)
        {
            talentNameString = "Potion Drinker";
            talentDescString = "At the beginning of a mining session, you will drink 1 out of 4 possible potions. The potion contains a buff that lasts the entire mining session";
        }
        #endregion

        #region Potion Chugger
        if (talentNumber == 2)
        {
            talentNameString = "Potion Chugger";
            talentDescString = "At the beginning of a mining sesssion, you will drink all 4 potions!";
        }
        #endregion

        #region Chests
        if (talentNumber == 3)
        {
            talentNameString = "Rocks? no, more chests!";
            talentDescString = $"Every rock has a {LevelMechanics.rockSpawnChance}% chance to be replaced with a treasure chest that contains {LevelMechanics.totalChestMaterials} random ores.";
        }
        #endregion

        #region Golden Chests
        if (talentNumber == 4)
        {
            talentNameString = "Gilded Chests";
            talentDescString = $"At the start of each mining session, there is a 50% chance to spawn a golden treasure chest that contain {LevelMechanics.totalGoldenChestMaterials} random ores.";
        }
        #endregion

        #region Skilled Miners
        if (talentNumber == 5)
        {
            talentNameString = "Skilled miners";
            talentDescString = $"The mine has a {LevelMechanics.skilledMinersFastChance}% chance to mine twice as fast and a {LevelMechanics.skilledMinersDoubleChance}% to mine 2X more bars";
        }
        #endregion

        #region Efficient Blacksmith
        if (talentNumber == 7)
        {
            float blackSmithDecreast = 1 - LevelMechanics.blacksmithDecrease;

            talentNameString = "Efficient Blacksmith";
            talentDescString = $"Crafting a pickaxe takes {(blackSmithDecreast * 100).ToString("F0")}% less materials.";
        }
        #endregion

        #region It's a Sign!
        if (talentNumber == 6)
        {
            talentNameString = "It's a Sign!";
            talentDescString = $"A sign with a written buff will appear next to The Mine. The buff changes every 5 minutes.";
        }
        #endregion

        #region Steam Sale
        if (talentNumber == 8)
        {
            float discount = (1 - LevelMechanics.steamSaleDiscount) * 100;

            talentNameString = "Steam Sale";
            talentDescString = $"Reduces the price of all skill tree upgrades by {discount.ToString("F0")}%";
        }
        #endregion

        #region Inflation burst
        if (talentNumber == 9)
        {
            talentNameString = "Inflate Burst";
            talentDescString = $"Every second, the mining erea has a {LevelMechanics.bigMiningAreaChance}% chance of increasing in size by 30% for 3 seconds";
        }
        #endregion

        #region It's Hammer Time!
        if (talentNumber == 10)
        {
            talentNameString = "It's Hammer Time!";
            talentDescString = $"Every pickaxe has a {LevelMechanics.hammerChance}% to turn into a hammer. Rocks hit with the hammer will be insta mined and the mined ores will be worth double.";
        }
        #endregion

        #region Midas Touch
        if (talentNumber == 11)
        {
            talentNameString = "Midas Touch";
            talentDescString = $"At the start of each mining session, your cursor has a {LevelMechanics.midasTouchChance}% chance to turn gold, this will cause each pickaxe hit to have a {LevelMechanics.midasTouchSpawnChance}% chance to spawn a ore";
        }
        #endregion

        #region Zeus Wrath
        if (talentNumber == 12)
        {
            talentNameString = "Zeus Wrath";
            talentDescString = $"Every second, there is a {LevelMechanics.zeusChance}% chance to shoot {LevelMechanics.zeusLightningAmount} lighning beams that target random rocks. The lightning beams that spawn and their damage is based on what you have unlocked in the skill tree.";
        }
        #endregion

        #region Shape Shifter
        if (talentNumber == 13)
        {
            float shapeIncrease = LevelMechanics.shapeShifterSizeIncrease * 100;

            talentNameString = "Shape Shifter";
            talentDescString = $"Increase the mining area by {shapeIncrease.ToString("F0")}%. Each mining session the mining area will either be a circle, triangle, square or hexagon.";
        }
        #endregion

        #region X marks the spot
        if (talentNumber == 14)
        {
            talentNameString = "X Marks The Spot";
            talentDescString = $"Higher chance to find artifacts!";
        }
        #endregion

        #region Explorer
        if (talentNumber == 15)
        {
            talentNameString = "Explorer";
            talentDescString = "Greater chance to find artifacts!";
        }
        #endregion

        #region Archaeologist
        if (talentNumber == 16)
        {
            float increase = LevelMechanics.archeologistIncrease * 100;

            talentNameString = "Archaeologist";
            talentDescString = $"The stats from all artifacts are improved by {increase}%.";
        }
        #endregion

        #region Energy Drinker
        if (talentNumber == 17)
        {
            talentNameString = "Energy Drinker";
            talentDescString = $"Every second, you have a {LevelMechanics.energiDrinkChance}% chance to drink an energy drink, this will cause the pickaxe mining speed to be halfed for {LevelMechanics.energiDrinkTime} seconds.";
        }
        #endregion

        #region Spring Season
        if (talentNumber == 18)
        {
            float increase = LevelMechanics.flowerIncrease * 100;

            talentNameString = "Spring Season";
            talentDescString = $"At the start of a mining session, 2-17 flowers will appear. Each flower will provide a {increase.ToString("F1")}% XP increase. This XP increase is added after the skill tree XP increase.";
        }
        #endregion

        #region Camper
        if (talentNumber == 19)
        {
            talentNameString = "Camper";
            talentDescString = $"At the start of a mining session, a campfire has a 50% chance to spawn. The fire insta mines rocks.";
        }
        #endregion

        #region D100
        if (talentNumber == 20)
        {
            talentNameString = "D100";
            talentDescString = $"At the end of a crafting session, a D100 will roll and if it hits 100, then all resources will be doubled!";
        }
        #endregion

        talentName_tooltip.text = talentNameString;
        talentDesc_tooltip.text = talentDescString;
    }
    #endregion

    #region Mine upgrades
    public TextMeshProUGUI timeToMine, timeToMineUpgraded;
    public TextMeshProUGUI materialsMined, materialsMinedUpgraded;

    public void TheMineTexts(bool isMineSpeed)
    {
        float miningTime = TheMine.miningTime;
        float miningTimeUpgraded = TheMine.miningTime - TheMine.mineTimeDecrase;

        int mined = TheMine.barsMined;
        int minedUpgraded = TheMine.barsMined + TheMine.bersMinedIncrease;

        if (isMineSpeed)
        {
            timeToMine.text = $"Mining time: {miningTime.ToString("F1")} sec";
            timeToMineUpgraded.text = $"Upgraded: {miningTimeUpgraded.ToString("F1")} sec";
        }
        else
        {
            materialsMined.text = $"Bars mined: {mined}";
            materialsMinedUpgraded.text = $"Upgraded: {minedUpgraded}";
        }
    }
    #endregion

    #region Talent 2 or less left
    public string talentCardsLeftString;
    public TextMeshProUGUI talentLeft1, talentLeft2, talentLeft3;

    public void TalentCardsLeftText()
    {
        if(LevelMechanics.cardsLeft == 2)
        {
            talentCardsLeftString = "There are only 2 more talent cards remaining!";
        }
        if (LevelMechanics.cardsLeft == 1)
        {
            talentCardsLeftString = "There is only 1 more talent card remaining!";
        }
        if (LevelMechanics.cardsLeft == 0)
        {
            talentCardsLeftString = "You have chosen all the talent cards, no more remain!";
        }

        talentLeft1.text = talentCardsLeftString.ToString();
        talentLeft2.text = talentCardsLeftString.ToString();
        talentLeft3.text = talentCardsLeftString.ToString();
    }
    #endregion
}
