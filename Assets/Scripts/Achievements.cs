using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    public static bool ach_minedRock;
    public static bool ach_mine200Krocks;
    public static bool ach_copper;
    public static bool ach_allMaterials;
    public static bool ach_beamDynamiteBalls;
    public static bool ach_allSkillTree;
    public static bool ach_1talent;
    public static bool ach_10talent;
    public static bool ach_pickaxe;
    public static bool ach_allPickaxe;
    public static bool ach_artifact;
    public static bool ach_7artifact;
    public static bool ach_allArtifact;
    public static bool ach_100Bars;
    public static bool ach_100Mbars;
    public static bool ach_1000Ores;
    public static bool ach_500Mores;
    public static bool ach_LevelUp;
    public static bool ach_level80;
    public static bool ach_beatGame;
    public static bool ach_equipDiamondPickaxe;
    public static bool ach_TheMine;

    private void Awake()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        CheckAch();

        //ClearAchievements();
    }

    public void ClearAchievements()
    {
        AchClear("mine_rock");
        AchClear("mineRock200K");
        AchClear("copper");
        AchClear("allMaterial");
        AchClear("beamDynamitePlazma");
        AchClear("allSkillTree");
        AchClear("talentCard");
        AchClear("talentCard10");
        AchClear("pickaxe");
        AchClear("pickaxeALL");
        AchClear("artifact");
        AchClear("artifact7");
        AchClear("artifactALL");
        AchClear("bars100");
        AchClear("bars100M");
        AchClear("ores1000");
        AchClear("ores500M");
        AchClear("levelUp");
        AchClear("levelUp80");
        AchClear("beatGame");
        AchClear("equipDiamondPickaxe");
        AchClear("theMine");
    }

    public static bool checkAch;

    private void Update()
    {
        if (MobileAndTesting.isMobile == true)
        {
            if (checkAch)
            {
                checkAch = false;
                CheckAch();
            }
        }
    }

    public void CheckAch()
    {
        if(MobileAndTesting.isMobile == true)
        {
            return;
        }

        #region 1 rock mined
        if (ach_minedRock == false)
        {
            if(AllStats.totalRockMined > 0)
            {
                ach_minedRock = true;
                TriggerACH("mine_rock");
            }
        }
        #endregion

        #region 200K rock mined
        if (ach_mine200Krocks == false)
        {
            if (AllStats.totalRockMined >= 200000)
            {
                ach_mine200Krocks = true;
                TriggerACH("mineRock200K");
            }
        }
        #endregion

        #region copper
        if (ach_copper == false)
        {
            if (SkillTree.spawnCopper_purchased == true)
            {
                ach_copper = true;
                TriggerACH("copper");
            }
        }
        #endregion

        #region all materials
        if (ach_allMaterials == false)
        {
            if (SkillTree.totalMaterialRocksSpawning >= 8)
            {
                ach_allMaterials = true;
                TriggerACH("allMaterial");
            }
        }
        #endregion

        #region beam dynamite and balls
        if (ach_beamDynamiteBalls == false)
        {
            if (SkillTree.dynamiteChance_1_purchased && SkillTree.plazmaBallSpawn_1_purchased && SkillTree.lightningBeamChancePH_1_purchased && SkillTree.lightningBeamChanceS_1_purchased)
            {
                ach_beamDynamiteBalls = true;
                TriggerACH("beamDynamitePlazma");
            }
        }
        #endregion

        #region all skill tree
        if (ach_allSkillTree == false)
        {
            if (SkillTree.totalSkillTreeUpgradesPurchased >= 399)
            {
                ach_allSkillTree = true;
                TriggerACH("allSkillTree");
            }
        }
        #endregion

        #region 1 talent
        if (ach_1talent == false)
        {
            if (LevelMechanics.cardsLeft <= 19)
            {
                ach_1talent = true;
                TriggerACH("talentCard");
            }
        }
        #endregion

        #region 10 talent
        if (ach_10talent == false)
        {
            if (LevelMechanics.cardsLeft <= 10)
            {
                ach_10talent = true;
                TriggerACH("talentCard10");
            }
        }
        #endregion

        #region craft 1 pickaxe
        if (ach_pickaxe == false)
        {
            if (TheAnvil.totalPickaxesCrafted >= 1)
            {
                ach_pickaxe = true;
                TriggerACH("pickaxe");
            }
        }
        #endregion

        #region craft all pickaxes
        if (ach_allPickaxe == false)
        {
            if (TheAnvil.totalPickaxesCrafted >= 12)
            {
                ach_allPickaxe = true;
                TriggerACH("pickaxeALL");
            }
        }
        #endregion

        #region artifact
        if (ach_artifact == false)
        {
            if (Artifacts.artifactsFound >= 1)
            {
                ach_artifact = true;
                TriggerACH("artifact");
            }
        }
        #endregion

        #region artifact 7
        if (ach_7artifact == false)
        {
            if (Artifacts.artifactsFound >= 7)
            {
                ach_7artifact = true;
                TriggerACH("artifact7");
            }
        }
        #endregion

        #region artifact aLL
        if (ach_allArtifact == false)
        {
            if (Artifacts.artifactsFound >= 14)
            {
                ach_allArtifact = true;
                TriggerACH("artifactALL");
            }
        }
        #endregion

        #region 100 bars
        if (ach_100Bars == false)
        {
            if ((AllStats.barsCrafted + AllStats.bardMinedTHEMINE) >= 100)
            {
                ach_100Bars = true;
                TriggerACH("bars100");
            }
        }
        #endregion

        #region 100M bars
        if (ach_100Mbars == false)
        {
            if ((AllStats.barsCrafted + AllStats.bardMinedTHEMINE) >= 100000000)
            {
                ach_100Mbars = true;
                TriggerACH("bars100M");
            }
        }
        #endregion

        #region 1000 ores
        if (ach_1000Ores == false)
        {
            if (AllStats.oresMined >= 1000)
            {
                ach_1000Ores = true;
                TriggerACH("ores1000");
            }
        }
        #endregion

        #region 500000000 ores
        if (ach_500Mores == false)
        {
            if (AllStats.oresMined >= 500000000)
            {
                ach_500Mores = true;
                TriggerACH("ores500M");
            }
        }
        #endregion

        #region level up
        if (ach_LevelUp == false)
        {
            if (LevelMechanics.level >= 2)
            {
                ach_LevelUp = true;
                TriggerACH("levelUp");
            }
        }
        #endregion

        #region level 80
        if (ach_level80 == false)
        {
            if (LevelMechanics.level >= 80)
            {
                ach_level80 = true;
                TriggerACH("levelUp80");
            }
        }
        #endregion

        #region beat the game
        if (ach_beatGame == false)
        {
            if (TheEnding.isEndingCompleted)
            {
                ach_beatGame = true;
                TriggerACH("beatGame");
            }
        }
        #endregion

        #region equip diamond pickaxe
        if (ach_equipDiamondPickaxe == false)
        {
            if (TheAnvil.pickaxe14_equipped == true)
            {
                ach_equipDiamondPickaxe = true;
                TriggerACH("equipDiamondPickaxe");
            }
        }
        #endregion

        #region ach_TheMine
        if (ach_TheMine == false)
        {
            if (TheMine.isTheMineUnlocked == true)
            {
                ach_TheMine = true;
                TriggerACH("theMine");
            }
        }
        #endregion
    }

    #region Trigger ach
    public void TriggerACH(string achNAME)
    {
        if (MobileAndTesting.isMobile == true) { return; }
        //if (SteamIntgr.noSteamInt == true) { return; }

        //var ach = new Steamworks.Data.Achievement(achNAME);
        //if (ach.State == false)
        //{
        //ach.Trigger();
        // }
    }
    #endregion

    public void AchClear(string achNAME)
    {
        //var ach = new Steamworks.Data.Achievement(achNAME);
        //ach.Clear();
    }
}
