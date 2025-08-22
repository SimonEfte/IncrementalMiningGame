using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isSkillTreeBtn, isTheMineBtn;

    public bool isMineTimeBtn, isMineOreBtn;

    public bool isPotion;

    public bool isTalentLevelText;

    public bool isFlower;

    public bool isLeftTalent;
    public int talentNumber;

    public bool isArtifact;
    public int artifactNumber;

    public bool isTheMineInfo;

    public GameObject skillTreeTooltip, theMineTimeTooltip, theMineOreTooltip;
    public GameObject artifactTooltip;
    public GameObject potionTooltip;
    public GameObject talentTooltp;
    public GameObject talentLevelTooltip;
    public GameObject flowerTooltip;
    public GameObject infoTooltip;
    public TextMeshProUGUI flowerBuffText;

    public static Vector2 skillTreeToolTipPos;

    public LocalizationScript locScript;

    public static string upgradeName;
    public static int upgradeType;

    public int upgradeTypeSet;

    public static int currentPurchaseCount;

    public float scale1, scale2, scale3, scale4, scale5;

    public bool goldPrice, copperPrice, ironPrice, cobaltPrice, uraniumPrice, ismiumPrice, iridiumPrice, painitePrice;

    public static bool goldPriceST, copperPriceST, ironPriceST, cobaltPriceST, uraniumPriceST, ismiumPriceST, iridiumPriceST, painitePriceST;

    public GameObject goldIcon, copperIcon, ironIcon, cobaltIcon, uraniumIcon, ismiumIcon, iridiumIcon, painiteIcon, oreDarkIcon;

    public static Vector2 currentPos;

    public bool isFinalUpgrade;
    public static bool isFinalUpgradeHover;

    public GameObject potions1, potions2, potion3, potion4;

    public static int hoveringEndless;

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoveringEndless = 0;
        upgradeType = upgradeTypeSet;

        float xPos = gameObject.transform.position.x;
        float yPos = 0;
        if (isSkillTreeBtn)
        {
            if(MobileAndTesting.isMobile == true) { SkillTree.pressedPurchaseMobile = false; }

            goldIcon.SetActive(false); copperIcon.SetActive(false); ironIcon.SetActive(false); cobaltIcon.SetActive(false);
            uraniumIcon.SetActive(false); ismiumIcon.SetActive(false); iridiumIcon.SetActive(false); painiteIcon.SetActive(false);
            oreDarkIcon.SetActive(false);

            goldPriceST = false; copperPriceST = false; ironPriceST = false; cobaltPriceST = false;
            uraniumPriceST = false; ismiumPriceST = false; iridiumPriceST = false; painitePriceST = false;

            if (goldPrice) { goldIcon.SetActive(true); goldPriceST = goldPrice; }
            if (copperPrice) { copperIcon.SetActive(true); copperPriceST = copperPrice; }
            if (ironPrice) { ironIcon.SetActive(true); ironPriceST = ironPrice; }
            if (cobaltPrice) { cobaltIcon.SetActive(true); cobaltPriceST = cobaltPrice; }
            if (uraniumPrice) { uraniumIcon.SetActive(true); uraniumPriceST = uraniumPrice; }
            if (ismiumPrice) { ismiumIcon.SetActive(true); ismiumPriceST = ismiumPrice; }
            if (iridiumPrice) { iridiumIcon.SetActive(true); iridiumPriceST = iridiumPrice; }
            if (painitePrice) { painiteIcon.SetActive(true); painitePriceST = painitePrice; }

            if(copperPriceST == true && SkillTree.spawnCopper_purchased == false) { oreDarkIcon.SetActive(true); }
            if (ironPriceST == true && SkillTree.spawnIron_purchased == false) { oreDarkIcon.SetActive(true); }
            if (cobaltPriceST == true && SkillTree.cobaltSpawn_purchased == false) { oreDarkIcon.SetActive(true); }
            if (uraniumPriceST == true && SkillTree.uraniumSpawn_purchased == false) { oreDarkIcon.SetActive(true); }
            if (ismiumPriceST == true && SkillTree.ismiumSpawn_purchased == false) { oreDarkIcon.SetActive(true); }
            if (iridiumPriceST == true && SkillTree.iridiumSpawn_purchased == false) { oreDarkIcon.SetActive(true); }
            if (painitePriceST == true && SkillTree.painiteSpawn_purchased == false) { oreDarkIcon.SetActive(true); }

            currentPos = gameObject.transform.position;

            scale1 = 1.5f;
            scale2 = 1.5f;
            scale3 = 1.7f;
            scale4 = 1.8f;
            scale5 = 2f;

            if (isFinalUpgrade)
            {
                isFinalUpgradeHover = true;
                scale1 *= 1.12f;
                scale2 *= 1.23f;
                scale3 *= 1.4f;
                scale4 *= 1.7f;
                scale5 *= 1.9f;
            }
            else
            {
                isFinalUpgradeHover = false;
            }

            if (SkillTreeDrag.scaleX < 0.75f) { yPos = gameObject.transform.position.y + scale1; }
            else if (SkillTreeDrag.scaleX < 1) { yPos = gameObject.transform.position.y + scale2; }
            else if (SkillTreeDrag.scaleX < 1.8f) { yPos = gameObject.transform.position.y + scale3; }
            else if (SkillTreeDrag.scaleX < 2.5) { yPos = gameObject.transform.position.y + scale4; }
            else if (SkillTreeDrag.scaleX < 3) { yPos = gameObject.transform.position.y + scale5; }

            if(MobileAndTesting.isMobile == false)
            {
                skillTreeTooltip.transform.position = new Vector2(xPos, yPos);
            }

            #region Spawn more rocks
            if (upgradeType == 1)
            {
                if (gameObject.name == "treeUpgrade_moreRocks_1(firstUpgrade)")
                {
                    upgradeName = "Rock1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnMoreRocks_1_price, SkillTree.spawnMoreRocks_1_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_moreRocks_2")
                {
                    upgradeName = "Rock2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnMoreRocks_2_price, SkillTree.spawnMoreRocks_2_purchaseCount, 4);
                }
                else if (gameObject.name == "treeUpgrade_moreRocks_3")
                {
                    upgradeName = "Rock3";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnMoreRocks_3_price, SkillTree.spawnMoreRocks_3_purchaseCount, 4);
                }
                else if (gameObject.name == "treeUpgrade_moreRocks_4")
                {
                    upgradeName = "Rock4";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnMoreRocks_4_price, SkillTree.spawnMoreRocks_4_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_moreRocks_5")
                {
                    upgradeName = "Rock5";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnMoreRocks_5_price, SkillTree.spawnMoreRocks_5_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_moreRocks_6")
                {
                    upgradeName = "Rock6";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnMoreRocks_6_price, SkillTree.spawnMoreRocks_6_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_moreRocks_7")
                {
                    upgradeName = "Rock7";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnMoreRocks_7_price, SkillTree.spawnMoreRocks_7_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_moreRocks_8")
                {
                    upgradeName = "Rock8";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnMoreRocks_8_price, SkillTree.spawnMoreRocks_8_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_moreRocks_9")
                {
                    upgradeName = "Rock9";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnMoreRocks_9_price, SkillTree.spawnMoreRocks_9_purchaseCount, 3);
                }
            }
            #endregion

            #region XP and talent Points
            else if (upgradeType == 2)
            {
                if (gameObject.name == "treeUpgrade_moreXP_1")
                {
                    upgradeName = "XP1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.moreXP_1_price, SkillTree.moreXP_1_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_moreXP_2")
                {
                    upgradeName = "XP2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.moreXP_2_price, SkillTree.moreXP_2_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_moreXP_3")
                {
                    upgradeName = "XP3";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.moreXP_3_price, SkillTree.moreXP_3_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_moreXP_4")
                {
                    upgradeName = "XP4";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.moreXP_4_price, SkillTree.moreXP_4_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_moreXP_5")
                {
                    upgradeName = "XP5";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.moreXP_5_price, SkillTree.moreXP_5_purchaseCount, 4);
                }
                else if (gameObject.name == "treeUpgrade_moreXP_6")
                {
                    upgradeName = "XP6";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.moreXP_6_price, SkillTree.moreXP_6_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_moreXP_7")
                {
                    upgradeName = "XP7";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.moreXP_7_price, SkillTree.moreXP_7_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_moreXP_8")
                {
                    upgradeName = "XP8";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.moreXP_8_price, SkillTree.moreXP_8_purchaseCount, 2);
                }
                else if (gameObject.name == "treeUpgrade_endlessIron")
                {
                    hoveringEndless = 3;
                    upgradeName = "EndlessXP1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.endlessIron_price, SkillTree.endlessIron_purchaseCount, 9999);
                }
                else if (gameObject.name == "treeUpgrade_endlessIsmium")
                {
                    hoveringEndless = 6;
                    upgradeName = "EndlessXP2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.endlessIsmium_price, SkillTree.endlessIsmium_purchaseCount, 9999);
                }

                //Talent
                else if (gameObject.name == "treeUpgrade_XtalentPointPerXLevel_1")
                {
                    upgradeName = "Talent1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.talentPointsPerXlevel_1_price, SkillTree.talentPointsPerXlevel_1_purchaseCount, 1);
                }
                else if (gameObject.name == "treeUpgrade_XtalentPointPerXLevel_2")
                {
                    upgradeName = "Talent2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.talentPointsPerXlevel_2_price, SkillTree.talentPointsPerXlevel_2_purchaseCount, 1);
                }
                else if (gameObject.name == "treeUpgrade_XtalentPointPerXLevel_3")
                {
                    upgradeName = "Talent3";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.talentPointsPerXlevel_3_price, SkillTree.talentPointsPerXlevel_3_purchaseCount, 1);
                }
            }
            #endregion

            #region Gold rocks spawn
            else if (upgradeType == 3)
            {
                if (gameObject.name == "treeUpgrade_moreGoldRockChance_1")
                {
                    upgradeName = "GoldChunk1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.goldChunk_1_price, SkillTree.goldChunk_1_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_moreGoldRockChance_2")
                {
                    upgradeName = "GoldChunk2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.goldChunk_2_price, SkillTree.goldChunk_2_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_moreGoldRockChance_3")
                {
                    upgradeName = "GoldChunk3";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.goldChunk_3_price, SkillTree.goldChunk_3_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_moreGoldRockChance_4")
                {
                    upgradeName = "GoldChunk4";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.goldChunk_4_price, SkillTree.goldChunk_4_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_moreGoldRockChance_5")
                {
                    upgradeName = "GoldChunk5";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.goldChunk_5__price, SkillTree.goldChunk_5_purchaseCount, 5);
                }

                else if (gameObject.name == "treeUpgrade_fullGoldChance_1")
                {
                    upgradeName = "FullGold1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.fullGold_1_price, SkillTree.fullGold_1_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_fullGoldChance_2")
                {
                    upgradeName = "FullGold2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.fullGold_2_price, SkillTree.fullGold_2_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_fullGoldChance_3")
                {
                    upgradeName = "FullGold3";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.fullGold_3_price, SkillTree.fullGold_3_purchaseCount, 3);
                }
            }
            #endregion

            #region Copper rocks spawn
            else if (upgradeType == 4)
            {
                if (gameObject.name == "treeUpgrade_copperSPAWN")
                {
                    upgradeName = "CopperSpawn";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnCopper_price, SkillTree.spawnCopper_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_copperHigherSpawnChance_1")
                {
                    upgradeName = "CopperChunk1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.copperChunk_1_price, SkillTree.copperChunk_1_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_copperHigherSpawnChance_2")
                {
                    upgradeName = "CopperChunk2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.copperChunk_2_price, SkillTree.copperChunk_2_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_copperHigherSpawnChance_3")
                {
                    upgradeName = "CopperChunk3";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.copperChunk_3_price, SkillTree.copperChunk_3_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_fullCopperSpawnChance_1")
                {
                    upgradeName = "FullCopper1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.fullCopper_1_price, SkillTree.fullCopper_1_purchaseCount, 2);
                }
                else if (gameObject.name == "treeUpgrade_fullCopperSpawnChance_2")
                {
                    upgradeName = "FullCopper2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.fullCopper_2_price, SkillTree.fullCopper_2_purchaseCount, 2);
                }
                else if (gameObject.name == "treeUpgrade_fullCopperSpawnChance_3")
                {
                    upgradeName = "FullCopper3";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.fullCopper_3_price, SkillTree.fullCopper_3_purchaseCount, 2);
                }
            }
            #endregion

            #region Iron rocks spawn
            else if (upgradeType == 5)
            {
                if (gameObject.name == "treeUpgrade_spawnIRON")
                {
                    upgradeName = "IronSpawn";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnIron_price, SkillTree.spawnIron_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_ironHigherSpawnChance_1")
                {
                    upgradeName = "IronChunk1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.ironChunk_1_price, SkillTree.ironChunk_1_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_ironHigherSpawnChance_2")
                {
                    upgradeName = "IronChunk2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.ironChunk_2_price, SkillTree.ironChunk_2_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_fullIronChance_1")
                {
                    upgradeName = "FullIron1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.fullIron_1_price, SkillTree.fullIron_1_purchaseCount, 2);
                }
                else if (gameObject.name == "treeUpgrade_fullIronChance_2")
                {
                    upgradeName = "FullIron2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.fullIron_2_price, SkillTree.fullIron_2_purchaseCount, 2);
                }
            }
            #endregion

            #region Cobalt rocks spawn
            else if (upgradeType == 6)
            {
                if (gameObject.name == "treeUpgrade_spawnCOBALT")
                {
                    upgradeName = "CobaltSpawn";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.cobaltSpawn_price, SkillTree.cobaltSpawn_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_cobaltHigherSpawnChance_1")
                {
                    upgradeName = "CobaltChunk1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.cobaltChunk_1_price, SkillTree.cobaltChunk_1_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_cobaltFullChance_1")
                {
                    upgradeName = "CobaltFull1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.fullCobalt_1_price, SkillTree.fullCobalt_1_purchaseCount, 2);
                }
            }
            #endregion

            #region Uranium rocks spawn
            else if (upgradeType == 7)
            {
                if (gameObject.name == "treeUpgrade_spawnURANIUM")
                {
                    upgradeName = "UraniumSpawn";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.uraniumSpawn_price, SkillTree.uraniumSpawn_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_uraniumHigherChance_1")
                {
                    upgradeName = "UraniumChunk1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.uraniumChunk_1_price, SkillTree.uraniumChunk_1_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_uraniumFullChance_1")
                {
                    upgradeName = "FullUranium1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.fullUranium_1_price, SkillTree.fullUranium_1_purchaseCount, 2);
                }
            }
            #endregion

            #region Ismium rocks spawn
            else if (upgradeType == 8)
            {
                if (gameObject.name == "treeUpgrade_spawnISMIUM")
                {
                    upgradeName = "IsmiumSpawn";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.ismiumSpawn_price, SkillTree.ismiumSpawn_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_ismiumHigherChance_1")
                {
                    upgradeName = "IsmiumChunk1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.ismiumChunk_1_price, SkillTree.ismiumChunk_1_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_ismiumFullChance_1")
                {
                    upgradeName = "FullIsmium1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.fullIsmium_1_price, SkillTree.fullIsmium_1_purchaseCount, 2);
                }
            }
            #endregion

            #region Iridium rocks spawn
            else if (upgradeType == 9)
            {
                if (gameObject.name == "treeUpgrade_spawnIRIDIUM")
                {
                    upgradeName = "IridiumSpawn";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.iridiumSpawn_price, SkillTree.iridiumSpawn_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_irituimHigherChance_1")
                {
                    upgradeName = "IridiumChunk1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.iridiumChunk_1_price, SkillTree.iridiumChunk_1_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_iriduimFullChance_1")
                {
                    upgradeName = "IridiumFull1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.fullIridium_1_price, SkillTree.fullIridium_1_purchaseCount, 2);
                }
            }
            #endregion

            #region Painite rocks spawn
            else if (upgradeType == 10)
            {
                if (gameObject.name == "treeUpgrade_spawnPAINITE")
                {
                    upgradeName = "PainiteSpawn";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.painiteSpawn_price, SkillTree.painiteSpawn_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_pianiteHigherChance_1")
                {
                    upgradeName = "PainiteChunk1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.painiteChunk_1_price, SkillTree.painiteChunk_1_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_pianiteFullChance_1")
                {
                    upgradeName = "FullPainite1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.fullPainite_1_price, SkillTree.fullPainite_1_purchaseCount, 2);
                }
            }
            #endregion

            #region Lightning beam
            else if (upgradeType == 11)
            {
                if (gameObject.name == "treeUpgrade_lightningChanceEverySecond_1")
                {
                    upgradeName = "LightningChanceS1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.lightningBeamChanceS_1_price, SkillTree.lightningBeamChanceS_1_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_lightningChanceEverySecond_2")
                {
                    upgradeName = "LightningChanceS2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.lightningBeamChanceS_2_price, SkillTree.lightningBeamChanceS_2_purchaseCount, 5);
                }

                else if (gameObject.name == "treeUpgrade_lightningChancePerPickaxeHit_1")
                {
                    upgradeName = "LightningChancePH1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.lightningBeamChancePH_1_price, SkillTree.lightningBeamChancePH_1_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_lightningChancePerPickaxeHit_2")
                {
                    upgradeName = "LightningChancePH2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.lightningBeamChancePH_2_price, SkillTree.lightningBeamChancePH_2_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_lightningChanceToSpawnAnotherOne")
                {
                    upgradeName = "LightningSpawnAnotherChance";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.lightningBeamSpawnAnotherOneChance_price, SkillTree.lightningBeamSpawnAnotherOneChance_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_moreLightningDamage")
                {
                    upgradeName = "LightningDamage";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.lightningBeamDamage_price, SkillTree.lightningBeamDamage_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_lightningSize_1")
                {
                    upgradeName = "LightningSize";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.lightningBeamSize_price, SkillTree.lightningBeamSize_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_lightningSplashesSpawn_1")
                {
                    upgradeName = "LightningSplash";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.lightningSplashes_price, SkillTree.lightningSplashes_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_lightningSpawnRockChance")
                {
                    upgradeName = "LightningSpawnRockChance";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.lightningBeamSpawnRock_price, SkillTree.lightningBeamSpawnRock_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_lightningChanceToSpawnExplostion")
                {
                    upgradeName = "LightningExplosionChance";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.lightningBeamExplosion_price, SkillTree.lightningBeamExplosion_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_lightningStrikeAddsTime_1")
                {
                    upgradeName = "LightningAddTimeChance";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.lightningBeamAddTime_price, SkillTree.lightningBeamAddTime_purchaseCount, 1);
                }
            }
            #endregion

            #region Dynamite
            else if (upgradeType == 12)
            {
                if (gameObject.name == "treeUpgrade_chanceToStickDynamite_1")
                {
                    upgradeName = "DynamiteStickChance1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.dynamiteChance_1_price, SkillTree.dynamiteChance_1_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_chanceToStickDynamite_2")
                {
                    upgradeName = "DynamiteStickChance2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.dynamiteChance_2_price, SkillTree.dynamiteChance_2_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_chanceToSpawn2Dynamites")
                {
                    upgradeName = "DynamiteSpawn2SmallChance";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.dynamiteSpawn2SmallChance_price, SkillTree.dynamiteSpawn2SmallChance_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_dynamiteSize_1")
                {
                    upgradeName = "DynamiteSize";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.dynamiteExplosionSize_price, SkillTree.dynamiteExplosionSize_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_dynamiteDamage_1")
                {
                    upgradeName = "DynamiteDamage";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.dynamiteDamage_price, SkillTree.dynamiteDamage_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_explosionChanceToSpawnRock_1")
                {
                    upgradeName = "DynamiteSpawnRockChance";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.dynamiteExplosionSpawnRock_price, SkillTree.dynamiteExplosionSpawnRock_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_dynamiteExplosionAddsTime_1")
                {
                    upgradeName = "DynamiteAddTimeChance";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.dynamiteExplosionAddTimeChance_price, SkillTree.dynamiteExplosionAddTimeChance_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_explostionChanceToSpawnLightning")
                {
                    upgradeName = "DynamiteSpawnLightningChance";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.dynamiteExplosionSpawnLightning_price, SkillTree.dynamiteExplosionSpawnLightning_purchaseCount, 1);
                }
            }
            #endregion

            #region Plazma ball
            else if (upgradeType == 13)
            {
                if (gameObject.name == "treeUpgrade_plazmaBallSpawnChance_1")
                {
                    upgradeName = "PlazmaBallChance1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.plazmaBallSpawn_1_price, SkillTree.plazmaBallSpawn_1_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_plazmaBallSpawnChance_2")
                {
                    upgradeName = "PlazmaBallChance2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.plazmaBallSpawn_2_price, SkillTree.plazmaBallSpawn_2_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_plazmaBallTime_1")
                {
                    upgradeName = "PlazmaBallTime";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.plazmaBallTime_price, SkillTree.plazmaBallTime_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_plazmaBallSize_1")
                {
                    upgradeName = "PlazmaBallSize";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.plazmaBallSize_price, SkillTree.plazmaBallSize_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_plazmaBallEndExplosionChance")
                {
                    upgradeName = "PlazmaBallExplosionChance";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.plazmaBallExplosionChance_price, SkillTree.plazmaBallExplosionChance_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_plazmaBallSpawnSmallChance_1")
                {
                    upgradeName = "PlazmbaBallSpawnSmallChance";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.plazmaBallSpawnSmallChance_price, SkillTree.plazmaBallSpawnSmallChance_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_plazmaBallDamage")
                {
                    upgradeName = "PlazmaBallDamage";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.plazmaBallDamage_price, SkillTree.plazmaBallDamage_purchaseCount, 5);
                }

                else if (gameObject.name == "treeUpgrade_plazmaChanceToSpawnPickaxe")
                {
                    upgradeName = "PlazmaBallChanceToSpawnPickaxe";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.plazmaBallSpawnPickaxeChance_price, SkillTree.plazmaBallSpawnPickaxeChance_purchaseCount, 1);
                }
            }
            #endregion

            #region More materials per rock
            else if (upgradeType == 14)
            {
                if (gameObject.name == "treeUpgrade_moreMaterialsFromRocks_1")
                {
                    upgradeName = "MaterialsPerRock1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.moreMeterialsFromRock_1_price, SkillTree.moreMeterialsFromRock_1_purchaseCount, 2);
                }
                else if (gameObject.name == "treeUpgrade_moreMaterialsFromRocks_2")
                {
                    upgradeName = "MaterialsPerRock2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.moreMeterialsFromRock_2_price, SkillTree.moreMeterialsFromRock_2_purchaseCount, 2);
                }
                else if (gameObject.name == "treeUpgrade_moreMaterialsFromRocks_3")
                {
                    upgradeName = "MaterialsPerRock3";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.moreMeterialsFromRock_3_price, SkillTree.moreMeterialsFromRock_3_purchaseCount, 2);
                }
                else if (gameObject.name == "treeUpgrade_moreMaterialsFromRocks_4")
                {
                    upgradeName = "MaterialsPerRock4";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.moreMeterialsFromRock_4_price, SkillTree.moreMeterialsFromRock_4_purchaseCount, 2);
                }
                else if (gameObject.name == "treeUpgrade_moreMaterialsFromRocks_5")
                {
                    upgradeName = "MaterialsPerRock5";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.moreMeterialsFromRock_5_price, SkillTree.moreMeterialsFromRock_5_purchaseCount, 2);
                }
            }
            #endregion

            #region Materials worth more
            else if (upgradeType == 15)
            {
                if (gameObject.name == "treeUpgrade_materialsWorthMore_1")
                {
                    upgradeName = "MaterialsWorthMore1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.marterialsWorthMore_1_price, SkillTree.marterialsWorthMore_1_purchaseCount, 4);
                }
                else if (gameObject.name == "treeUpgrade_materialsWorthMore_2")
                {
                    upgradeName = "MaterialsWorthMore2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.marterialsWorthMore_2_price, SkillTree.marterialsWorthMore_2_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_materialsWorthMore_3")
                {
                    upgradeName = "MaterialsWorthMore3";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.marterialsWorthMore_3_price, SkillTree.marterialsWorthMore_3_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_materialsWorthMore_4")
                {
                    upgradeName = "MaterialsWorthMore4";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.marterialsWorthMore_4_price, SkillTree.marterialsWorthMore_4_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_materialsWorthMore_5")
                {
                    upgradeName = "MaterialsWorthMore5";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.marterialsWorthMore_5_price, SkillTree.marterialsWorthMore_5_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_materialsWorthMore_6")
                {
                    upgradeName = "MaterialsWorthMore6";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.marterialsWorthMore_6_price, SkillTree.marterialsWorthMore_6_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_materialsWorthMore_7")
                {
                    upgradeName = "MaterialsWorthMore7";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.marterialsWorthMore_7_price, SkillTree.marterialsWorthMore_7_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_materialsWorthMore_8")
                {
                    upgradeName = "MaterialsWorthMore8";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.marterialsWorthMore_8_price, SkillTree.marterialsWorthMore_8_purchaseCount, 5);
                }
                if (gameObject.name == "treeUpgrade_endlessGold")
                {
                    hoveringEndless = 1;
                    upgradeName = "EndlessGold1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.endlessGold_price, SkillTree.endlessGold_purchaseCount, 9999);
                }
                if (gameObject.name == "treeUpgrade_endlessPainite")
                {
                    hoveringEndless = 8;
                    upgradeName = "EndlessGold2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.endlessPainite_price, SkillTree.endlessPainite_purchaseCount, 9999);
                }
            }
            #endregion

            #region Improved pickaxe
            else if (upgradeType == 16)
            {
                if (gameObject.name == "treeUpgrade_improvedPickaxesStats_1")
                {
                    upgradeName = "ImprovedPickaxe1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.improvedPickaxe_1_price, SkillTree.improvedPickaxe_1_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_improvedPickaxesStats_2")
                {
                    upgradeName = "ImprovedPickaxe2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.improvedPickaxe_2_price, SkillTree.improvedPickaxe_2_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_improvedPickaxesStats_3")
                {
                    upgradeName = "ImprovedPickaxe3";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.improvedPickaxe_3_price, SkillTree.improvedPickaxe_3_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_improvedPickaxesStats_4")
                {
                    upgradeName = "ImprovedPickaxe4";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.improvedPickaxe_4_price, SkillTree.improvedPickaxe_4_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_improvedPickaxesStats_5")
                {
                    upgradeName = "ImprovedPickaxe5";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.improvedPickaxe_5_price, SkillTree.improvedPickaxe_5_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_improvedPickaxesStats_6")
                {
                    upgradeName = "ImprovedPickaxe6";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.improvedPickaxe_6_price, SkillTree.improvedPickaxe_6_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_endlessCobalt")
                {
                    hoveringEndless = 4;
                    upgradeName = "EndlessPickaxe1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.endlessCobalt_price, SkillTree.endlessCobalt_purchaseCount, 9999);
                }
                else if (gameObject.name == "treeUpgrade_endlessUranium")
                {
                    hoveringEndless = 5;
                    upgradeName = "EndlessPickaxe2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.endlessUranium_price, SkillTree.endlessUranium_purchaseCount, 9999);
                }
            }
            #endregion

            #region Mining erea
            else if (upgradeType == 17)
            {
                if (gameObject.name == "treeUpgrade_biggerMiningErea_1")
                {
                    upgradeName = "BiggerMiningErea1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.biggerMiningErea_1_price, SkillTree.biggerMiningErea_1_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_biggerMiningErea_2")
                {
                    upgradeName = "BiggerMiningErea2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.biggerMiningErea_2_price, SkillTree.biggerMiningErea_2_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_biggerMiningErea_3")
                {
                    upgradeName = "BiggerMiningErea3";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.biggerMiningErea_3_price, SkillTree.biggerMiningErea_3_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_biggerMiningErea_4")
                {
                    upgradeName = "BiggerMiningErea4";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.biggerMiningErea_4_price, SkillTree.biggerMiningErea_4_purchaseCount, 5);
                }

                else if (gameObject.name == "treeUpgrade_chanceToShootCircleEverySecons_1")
                {
                    upgradeName = "ShootCircle";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.shootCircleChance_price, SkillTree.shootCircleChance_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_increaseAndDecrease_1")
                {
                    upgradeName = "IncreaseAndDecreaseCircle";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.increaseAndDecreaseMinignErea_price, SkillTree.increaseAndDecreaseMinignErea_purchaseCount, 1);
                }
            }
            #endregion

            #region Chance to spawn rock
            else if (upgradeType == 18)
            {
                if (gameObject.name == "treeUpgrade_everyXrocksMineWillSpawnRock_1")
                {
                    upgradeName = "EveryXRockSpawnRock1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnRockEveryXrock_1_price, SkillTree.spawnRockEveryXrock_1_purchaseCount, 1);
                }
                else if (gameObject.name == "treeUpgrade_everyXrocksMineWillSpawnRock_2")
                {
                    upgradeName = "EveryXRockSpawnRock2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnRockEveryXrock_2_price, SkillTree.spawnRockEveryXrock_2_purchaseCount, 1);
                }
                else if (gameObject.name == "treeUpgrade_everyXrocksMineWillSpawnRock_3")
                {
                    upgradeName = "EveryXRockSpawnRock3";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnRockEveryXrock_3_price, SkillTree.spawnRockEveryXrock_3_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_spawnRockEveryXSecond_1")
                {
                    upgradeName = "SpawnRockEveryXSecond1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnXRockEveryXSecond_1_price, SkillTree.spawnXRockEveryXSecond_1_purchaseCount, 1);
                }
                else if (gameObject.name == "treeUpgrade_spawnRockEveryXSecond_2")
                {
                    upgradeName = "SpawnRockEveryXSecond2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnXRockEveryXSecond_2_price, SkillTree.spawnXRockEveryXSecond_2_purchaseCount, 1);
                }
                else if (gameObject.name == "treeUpgrade_spawnRockEveryXSecond_3")
                {
                    upgradeName = "SpawnRockEveryXSecond3";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnXRockEveryXSecond_3_price, SkillTree.spawnXRockEveryXSecond_3_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_chanceToSpawnRockWhenMined_1")
                {
                    upgradeName = "ChanceToSpawnRockWhenMined1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.chanceToSpawnRockWhenMined_1_price, SkillTree.chanceToSpawnRockWhenMined_1_purchaseCount, 6);
                }
                else if (gameObject.name == "treeUpgrade_chanceToSpawnRockWhenMined_2")
                {
                    upgradeName = "ChanceToSpawnRockWhenMined2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.chanceToSpawnRockWhenMined_2_price, SkillTree.chanceToSpawnRockWhenMined_2_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_chanceToSpawnRockWhenMined_3")
                {
                    upgradeName = "ChanceToSpawnRockWhenMined3";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.chanceToSpawnRockWhenMined_3_price, SkillTree.chanceToSpawnRockWhenMined_3_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_chanceToSpawnRockWhenMined_4")
                {
                    upgradeName = "ChanceToSpawnRockWhenMined4";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.chanceToSpawnRockWhenMined_4_price, SkillTree.chanceToSpawnRockWhenMined_4_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_chanceToSpawnRockWhenMined_5")
                {
                    upgradeName = "ChanceToSpawnRockWhenMined5";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.chanceToSpawnRockWhenMined_5_price, SkillTree.chanceToSpawnRockWhenMined_5_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_chanceToSpawnRockWhenMined_6")
                {
                    upgradeName = "ChanceToSpawnRockWhenMined6";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.chanceToSpawnRockWhenMined_6_price, SkillTree.chanceToSpawnRockWhenMined_6_purchaseCount, 1);
                }
            }
            #endregion

            #region Chance to spawn pickaxe
            else if (upgradeType == 19)
            {
                if (gameObject.name == "treeUpgrade_chanceToMineRandomRock_1")
                {
                    upgradeName = "ChanceToMineRandomRock1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.chanceToMineRandomRock_1_price, SkillTree.chanceToMineRandomRock_1_purchaseCount, 4);
                }
                else if (gameObject.name == "treeUpgrade_chanceToMineRandomRock_2")
                {
                    upgradeName = "ChanceToMineRandomRock2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.chanceToMineRandomRock_2_price, SkillTree.chanceToMineRandomRock_2_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_chanceToMineRandomRock_3")
                {
                    upgradeName = "ChanceToMineRandomRock3";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.chanceToMineRandomRock_3_price, SkillTree.chanceToMineRandomRock_3_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_chanceToMineRandomRock_4")
                {
                    upgradeName = "ChanceToMineRandomRock4";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.chanceToMineRandomRock_4_price, SkillTree.chanceToMineRandomRock_4_purchaseCount, 3);
                }
               

                else if (gameObject.name == "treeUpgrade_spawnPickaxeEverySecond_1")
                {
                    upgradeName = "SpawnPickaxeEverySecond1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnPickaxeEverySecond_1_price, SkillTree.spawnPickaxeEverySecond_1_purchaseCount, 1);
                }
                else if (gameObject.name == "treeUpgrade_spawnPickaxeEverySecond_2")
                {
                    upgradeName = "SpawnPickaxeEverySecond2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnPickaxeEverySecond_2_price, SkillTree.spawnPickaxeEverySecond_2_purchaseCount, 1);
                }
                else if (gameObject.name == "treeUpgrade_spawnPickaxeEverySecond_3")
                {
                    upgradeName = "SpawnPickaxeEverySecond3";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.spawnPickaxeEverySecond_3_price, SkillTree.spawnPickaxeEverySecond_3_purchaseCount, 1);
                }
            }
            #endregion

            #region More time
            else if (upgradeType == 20)
            {
                if (gameObject.name == "treeUpgrade_moreTime_1")
                {
                    upgradeName = "MoreTime1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.moreTime_1_price, SkillTree.moreTime_1_purchaseCount, 5);
                }
                else if (gameObject.name == "treeUpgrade_moreTime_2")
                {
                    upgradeName = "MoreTime2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.moreTime_2_price, SkillTree.moreTime_2_purchaseCount, 4);
                }
                else if (gameObject.name == "treeUpgrade_moreTime_3")
                {
                    upgradeName = "MoreTime3";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.moreTime_3_price, SkillTree.moreTime_3_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_moreTime_4")
                {
                    upgradeName = "MoreTime4";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.moreTime_4_price, SkillTree.moreTime_4_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_chanceToAdd1SecondEverySecond")
                {
                    upgradeName = "ChanceAdd1SecondEverySecond";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.chanceToAdd1SecondEverySecond_price, SkillTree.chanceToAdd1SecondEverySecond_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_chanceAdd1SecondEveryRockMined")
                {
                    upgradeName = "ChanceAdd1SecondEveryRockMined";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.chanceAdd1SecondEveryRockMined_price, SkillTree.chanceAdd1SecondEveryRockMined_purchaseCount, 1);
                }
            }
            #endregion

            #region Double XP and material chance
            else if (upgradeType == 21)
            {
                if (gameObject.name == "treeUpgrade_chanceForDoubleXpAndGold_1")
                {
                    upgradeName = "DoubleXpAndMaterial1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.doubleXpGoldChance_1_price, SkillTree.doubleXpGoldChance_1_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_chanceForDoubleXpAndGold_2")
                {
                    upgradeName = "DoubleXpAndMaterial2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.doubleXpGoldChance_2_price, SkillTree.doubleXpGoldChance_2_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_chanceForDoubleXpAndGold_3")
                {
                    upgradeName = "DoubleXpAndMaterial3";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.doubleXpGoldChance_3_price, SkillTree.doubleXpGoldChance_3_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_chanceForDoubleXpAndGold_4")
                {
                    upgradeName = "DoubleXpAndMaterial4";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.doubleXpGoldChance_4_price, SkillTree.doubleXpGoldChance_4_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_chanceForDoubleXpAndGold_5")
                {
                    upgradeName = "DoubleXpAndMaterial5";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.doubleXpGoldChance_5_price, SkillTree.doubleXpGoldChance_5_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_endlessCopper")
                {
                    hoveringEndless = 2;
                    upgradeName = "DoubleEndless1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.endlessCopper_price, SkillTree.endlessCopper_purchaseCount, 9999);
                }
                else if (gameObject.name == "treeUpgrade_endlessIridium")
                {
                    hoveringEndless = 7;
                    upgradeName = "DoubleEndless2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.endlessIridium_price, SkillTree.endlessIridium_purchaseCount, 9999);
                }
            }
            #endregion

            #region Misc and FINAL
            else if (upgradeType == 22)
            {
                if (gameObject.name == "treeUpgrade_allProjectileDoubleDamageChance_1")
                {
                    upgradeName = "AllProjectleDoubleDamageChance";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.allProjectileDoubleDamageChance_price, SkillTree.allProjectileDoubleDamageChance_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_increaseAllProjectileChances_1")
                {
                    upgradeName = "IncreaseAllProjectileChance";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.allProjectileTriggerChance_price, SkillTree.allProjectileTriggerChance_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_doubleDamageChance_1")
                {
                    upgradeName = "DoubleDamageChance1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.pickaxeDoubleDamageChance_1_price, SkillTree.pickaxeDoubleDamageChance_1_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_doubleDamageChance_2")
                {
                    upgradeName = "DoubleDamageChance2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.pickaxeDoubleDamageChance_2_price, SkillTree.pickaxeDoubleDamageChance_2_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_intaMineChance_1")
                {
                    upgradeName = "InstaMine1";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.intaMineChance_1_price, SkillTree.intaMineChance_1_purchaseCount, 3);
                }
                else if (gameObject.name == "treeUpgrade_intaMineChance_2")
                {
                    upgradeName = "InstaMine2";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.intaMineChance_2_price, SkillTree.intaMineChance_2_purchaseCount, 3);
                }

                else if (gameObject.name == "treeUpgrade_increaseSpawnChanceALLROCKS")
                {
                    upgradeName = "IncreaseAllRockSpawnChance";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.increaseSpawnChanceAllRocks_price, SkillTree.increaseSpawnChanceAllRocks_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_2GoldBarsCraft")
                {
                    upgradeName = "2GoldBarsCraft";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.craft2Material_price, SkillTree.craft2Material_purchaseCount, 1);
                }

                else if (gameObject.name == "treeUpgrade_finalUpgrade_newMiningLocation")
                {
                    upgradeName = "FinalUpgrade";
                    locScript.SetSkillTreeTexts(upgradeName, upgradeType, SkillTree.finalUpgrade_price, SkillTree.finalUpgrade_purchaseCount, 1);
                }
            }
            #endregion

            if(MobileAndTesting.isMobile == false)
            {
                skillTreeToolTipPos = gameObject.transform.position;

                if (skillTreeTooltip != null)
                    skillTreeTooltip.SetActive(true);
            }
        }

        #region The mine tooltip
        if (isTheMineBtn == true)
        {
            yPos = gameObject.transform.position.y + 1.7f;

            if (isMineTimeBtn == true)
            {
                locScript.TheMineTexts(true);

                if (MobileAndTesting.isMobile == false)
                {
                    theMineTimeTooltip.transform.position = new Vector2(xPos, yPos);

                    if (theMineTimeTooltip != null)
                        theMineTimeTooltip.SetActive(true);
                }
            }

            if (isMineOreBtn == true)
            {
                locScript.TheMineTexts(false);

                if (MobileAndTesting.isMobile == false)
                {
                    theMineOreTooltip.transform.position = new Vector2(xPos, yPos);

                    if (theMineOreTooltip != null)
                        theMineOreTooltip.SetActive(true);
                }
            }
        }
        #endregion

        #region Artifacts tooltip
        if (isArtifact)
        {
            foreach (Transform child in transform)
            {
                if (child.name.Contains("Excl"))
                {
                    if (child.gameObject.activeSelf)
                    {
                        child.gameObject.SetActive(false);
                    }
                }
               
            }

            locScript.ArtifactsTooltipText(artifactNumber);

            if (MobileAndTesting.isMobile == false)
            {
                yPos = gameObject.transform.position.y + 1.6f;

                artifactTooltip.transform.position = new Vector2(xPos, yPos);

                artifactTooltip.SetActive(true);
            }
        }
        #endregion

        #region Potion tooltip
        if (isPotion)
        {
            xPos = gameObject.transform.position.x - 2.72f;
            yPos = gameObject.transform.position.y - 0.5f;

            potionTooltip.transform.position = new Vector2(xPos, yPos);

            potionTooltip.SetActive(true);

            potions1.SetActive(false); potions2.SetActive(false); potion3.SetActive(false); potion4.SetActive(false);

            if (gameObject.name == "Potion_GoldIncrease") { locScript.PotionText("materialIncrease"); potions1.SetActive(true); }
            if (gameObject.name == "Potion_PickaxeStats") { locScript.PotionText("pickaxeIncrease"); potions2.SetActive(true); }
            if (gameObject.name == "Potion_XPIncrease") { locScript.PotionText("xpIncrease"); potion3.SetActive(true); }
            if (gameObject.name == "Potion_DoubleXpAndGoldIncrease") { locScript.PotionText("doubleXpAndMaterialIncrease"); potion4.SetActive(true); }
        }
        #endregion

        #region Talent tooltip
        if (isLeftTalent)
        {
            yPos = gameObject.transform.position.y;

            float yPosLocal = gameObject.transform.localPosition.y;

            if(yPosLocal < -390)
            {
                yPos += 0.9f;
            }

            locScript.TalentTexts(talentNumber);

            if (MobileAndTesting.isMobile == false)
            {
                talentTooltp.transform.position = new Vector2(xPos + 2.9f, yPos);
                talentTooltp.SetActive(true);
            }
        }
        #endregion

        #region Talent level tooltip
        if (isTalentLevelText)
        {
            if (MobileAndTesting.isMobile == false)
            {
                yPos = gameObject.transform.position.y;

                talentLevelTooltip.transform.position = new Vector2(xPos, yPos - 1.1f);
                talentLevelTooltip.SetActive(true);
            }
        }
        #endregion

        #region Flower tooltip
        if (isFlower)
        {
            if (MobileAndTesting.isMobile == false)
            {
                yPos = gameObject.transform.position.y + 1.1f;
                xPos = gameObject.transform.position.x + 1.4f;

                flowerBuffText.text = $"+{SetRockScreen.flowersOnScreen * (LevelMechanics.flowerIncrease * 100)}%XP";
                flowerTooltip.transform.position = new Vector2(xPos, yPos);
                flowerTooltip.SetActive(true);
            }
        }
        #endregion

        if(isTheMineInfo == true)
        {
            if (MobileAndTesting.isMobile == false)
            {
                yPos = gameObject.transform.position.y - 0.65f;
                xPos = gameObject.transform.position.x - 3.3f;

                infoTooltip.transform.position = new Vector2(xPos, yPos);
                infoTooltip.SetActive(true);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isSkillTreeBtn)
        {
            if (MobileAndTesting.isMobile == false)
            {
                if (skillTreeTooltip != null)
                    skillTreeTooltip.SetActive(false);
            }
        }

        if (isTheMineBtn == true)
        {
            if (MobileAndTesting.isMobile == false)
            {
                theMineTimeTooltip.SetActive(false);
                theMineOreTooltip.SetActive(false);
            }
        }

        if (isArtifact)
        {
            if (MobileAndTesting.isMobile == false)
            {
                artifactTooltip.SetActive(false);
            }
        }

        if (isPotion)
        {
            potionTooltip.SetActive(false);
        }

        if (isLeftTalent)
        {
            if (MobileAndTesting.isMobile == false)
            {
                talentTooltp.SetActive(false);
            }
        }

        if (isTalentLevelText)
        {
            if (MobileAndTesting.isMobile == false)
            {
                talentLevelTooltip.SetActive(false);
            }
        }

        if (isFlower)
        {
            if (MobileAndTesting.isMobile == false)
            {
                flowerTooltip.SetActive(false);
            }
        }

        if (isTheMineInfo == true)
        {
            if (MobileAndTesting.isMobile == false)
            {
                infoTooltip.SetActive(false);
            }
        }
    }
}
