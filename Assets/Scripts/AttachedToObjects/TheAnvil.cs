using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TheAnvil : MonoBehaviour, IDataPersistence
{
    public AudioManager audioManager;
    public GoldAndOreMechanics goldAndOreScript;

    public GameObject copperBar, ironBar, cobaltBar, uraniumBar, ismiumBar, iridiumBar, painiteBar;
    public GameObject copperQuestionmark, ironQuestionmark, cobaltQuestionmark, uraniumQuestionmark, ismiumQuestionmark, iridiumQuestionmark, painiteQuestionmark;

    public TextMeshProUGUI topPickaxeName, equippedPickaxeName;

    public TextMeshProUGUI goldPriceText, copperPriceText, ironPriceText, cobaltPriceText, uraniumPriceText, ismiumPriceText, iridiumPriceText, painitePriceText;

    public static bool isOnlyFirstPickaxe;

    public static float currentMineTime;
    public static float currentMinePower;
    public static float current2XPowerChance;
    public static float currentMiningErea;

    public static bool isTheAnvilUnlocked;

    public static bool pickaxe1_crafted, pickaxe2_crafted, pickaxe3_crafted, pickaxe4_crafted,pickaxe5_crafted, pickaxe6_crafted, pickaxe7_crafted, pickaxe8_crafted,pickaxe9_crafted, pickaxe10_crafted, pickaxe11_crafted, pickaxe12_crafted,pickaxe13_crafted, pickaxe14_crafted;

    public static bool pickaxe1_equipped, pickaxe2_equipped, pickaxe3_equipped, pickaxe4_equipped,pickaxe5_equipped, pickaxe6_equipped, pickaxe7_equipped, pickaxe8_equipped, pickaxe9_equipped, pickaxe10_equipped, pickaxe11_equipped, pickaxe12_equipped, pickaxe13_equipped, pickaxe14_equipped;

    public static float pickaxe1_mineTime, pickaxe1_minePower, pickaxe1_2XChance, pickaxe1_miningAreaSize;
    public static float pickaxe2_mineTime, pickaxe2_minePower, pickaxe2_2XChance, pickaxe2_miningAreaSize;
    public static float pickaxe3_mineTime, pickaxe3_minePower, pickaxe3_2XChance, pickaxe3_miningAreaSize;
    public static float pickaxe4_mineTime, pickaxe4_minePower, pickaxe4_2XChance, pickaxe4_miningAreaSize;
    public static float pickaxe5_mineTime, pickaxe5_minePower, pickaxe5_2XChance, pickaxe5_miningAreaSize;
    public static float pickaxe6_mineTime, pickaxe6_minePower, pickaxe6_2XChance, pickaxe6_miningAreaSize;
    public static float pickaxe7_mineTime, pickaxe7_minePower, pickaxe7_2XChance, pickaxe7_miningAreaSize;
    public static float pickaxe8_mineTime, pickaxe8_minePower, pickaxe8_2XChance, pickaxe8_miningAreaSize;
    public static float pickaxe9_mineTime, pickaxe9_minePower, pickaxe9_2XChance, pickaxe9_miningAreaSize;
    public static float pickaxe10_mineTime, pickaxe10_minePower, pickaxe10_2XChance, pickaxe10_miningAreaSize;
    public static float pickaxe11_mineTime, pickaxe11_minePower, pickaxe11_2XChance, pickaxe11_miningAreaSize;
    public static float pickaxe12_mineTime, pickaxe12_minePower, pickaxe12_2XChance, pickaxe12_miningAreaSize;
    public static float pickaxe13_mineTime, pickaxe13_minePower, pickaxe13_2XChance, pickaxe13_miningAreaSize;
    public static float pickaxe14_mineTime, pickaxe14_minePower, pickaxe14_2XChance, pickaxe14_miningAreaSize;

    public static double pickaxe2_goldPrice;
    public static double pickaxe3_goldPrice, pickaxe3_copperPrice;
    public static double pickaxe4_copperPrice, pickaxe4_ironPrice;
    public static double pickaxe5_goldPrice, pickaxe5_ironPrice;
    public static double pickaxe6_goldPrice, pickaxe6_cobaltPrice;
    public static double pickaxe7_goldPrice, pickaxe7_copperPrice, pickaxe7_ironPrice;
    public static double pickaxe8_cobaltPrice, pickaxe8_uraniumPrice;
    public static double pickaxe9_goldPrice, pickaxe9_uraniumPrice, pickaxe9_ismiumPrice;
    public static double pickaxe10_goldPrice, pickaxe10_copperPrice, pickaxe10_iridiumPrice;
    public static double pickaxe11_cobaltPrice, pickaxe11_uraniumPrice, pickaxe11_ismiumPrice;
    public static double pickaxe12_goldPrice, pickaxe12_iridiumPrice;
    public static double pickaxe13_goldPrice, pickaxe13_ironPrice, pickaxe13_painitePrice;

    public static float equippedMineTime, equippedMinePower, equipped2XChance, equippedMiningArea;

    public static float collTime;

    bool playSound;

    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);

        pickaxe2_goldPrice = 100;

        pickaxe3_goldPrice = 110;
        pickaxe3_copperPrice = 135;

        pickaxe4_copperPrice = 145;
        pickaxe4_ironPrice = 170;

        pickaxe5_goldPrice = 200;
        pickaxe5_ironPrice = 220;

        pickaxe6_goldPrice = 250;
        pickaxe6_cobaltPrice = 280;

        pickaxe7_goldPrice = 310;
        pickaxe7_copperPrice = 350;
        pickaxe7_ironPrice = 390;

        pickaxe8_cobaltPrice = 420;
        pickaxe8_uraniumPrice = 470;

        pickaxe9_goldPrice = 500;
        pickaxe9_uraniumPrice = 550;
        pickaxe9_ismiumPrice = 600;

        pickaxe10_goldPrice = 650;
        pickaxe10_copperPrice = 700;
        pickaxe10_iridiumPrice = 750;

        pickaxe11_cobaltPrice = 800;
        pickaxe11_uraniumPrice = 850;
        pickaxe11_ismiumPrice = 900;

        pickaxe12_goldPrice = 950;
        pickaxe12_iridiumPrice = 1000;

        pickaxe13_goldPrice = 1100;
        pickaxe13_ironPrice = 1200;
        pickaxe13_painitePrice = 1300;

        collTime = 0.04f;

        if (pickaxe1_crafted) { SetImageToWhite(pickaxe1_topImage); SetImageToWhite(pickaxe1_craftImage); }
        if (pickaxe2_crafted) { SetImageToWhite(pickaxe2_topImage); SetImageToWhite(pickaxe2_craftImage); }
        if (pickaxe3_crafted) { SetImageToWhite(pickaxe3_topImage); SetImageToWhite(pickaxe3_craftImage); }
        if (pickaxe4_crafted) { SetImageToWhite(pickaxe4_topImage); SetImageToWhite(pickaxe4_craftImage); }
        if (pickaxe5_crafted) { SetImageToWhite(pickaxe5_topImage); SetImageToWhite(pickaxe5_craftImage); }
        if (pickaxe6_crafted) { SetImageToWhite(pickaxe6_topImage); SetImageToWhite(pickaxe6_craftImage); }
        if (pickaxe7_crafted) { SetImageToWhite(pickaxe7_topImage); SetImageToWhite(pickaxe7_craftImage); }
        if (pickaxe8_crafted) { SetImageToWhite(pickaxe8_topImage); SetImageToWhite(pickaxe8_craftImage); }
        if (pickaxe9_crafted) { SetImageToWhite(pickaxe9_topImage); SetImageToWhite(pickaxe9_craftImage); }
        if (pickaxe10_crafted) { SetImageToWhite(pickaxe10_topImage); SetImageToWhite(pickaxe10_craftImage); }
        if (pickaxe11_crafted) { SetImageToWhite(pickaxe11_topImage); SetImageToWhite(pickaxe11_craftImage); }
        if (pickaxe12_crafted) { SetImageToWhite(pickaxe12_topImage); SetImageToWhite(pickaxe12_craftImage); }
        if (pickaxe13_crafted) { SetImageToWhite(pickaxe13_topImage); SetImageToWhite(pickaxe13_craftImage); }
        if (pickaxe14_crafted) { SetImageToWhite(pickaxe14_topImage); SetImageToWhite(pickaxe14_craftImage); }

        pickaxe1_mineTime = 0.32f; pickaxe1_minePower = 2.5f; pickaxe1_2XChance = 1.1f; pickaxe1_miningAreaSize = 1.1f;
        pickaxe2_mineTime = 0.30f; pickaxe2_minePower = 2.7f; pickaxe2_2XChance = 1.2f; pickaxe2_miningAreaSize = 1.2f;
        pickaxe3_mineTime = 0.33f; pickaxe3_minePower = 2.8f; pickaxe3_2XChance = 1.3f; pickaxe3_miningAreaSize = 1.2f;
        pickaxe4_mineTime = 0.31f; pickaxe4_minePower = 3.2f; pickaxe4_2XChance = 1.5f; pickaxe4_miningAreaSize = 1.3f;
        pickaxe5_mineTime = 0.28f; pickaxe5_minePower = 3.5f; pickaxe5_2XChance = 1.8f; pickaxe5_miningAreaSize = 1.35f;
        pickaxe6_mineTime = 0.29f; pickaxe6_minePower = 3.5f; pickaxe6_2XChance = 2.1f; pickaxe6_miningAreaSize = 1.5f;
        pickaxe7_mineTime = 0.30f; pickaxe7_minePower = 3.7f; pickaxe7_2XChance = 2.4f; pickaxe7_miningAreaSize = 1.45f;
        pickaxe8_mineTime = 0.27f; pickaxe8_minePower = 3.9f; pickaxe8_2XChance = 3f; pickaxe8_miningAreaSize = 1.6f;
        pickaxe9_mineTime = 0.26f; pickaxe9_minePower = 4.2f; pickaxe9_2XChance = 3.4f; pickaxe9_miningAreaSize = 1.7f;
        pickaxe10_mineTime = 0.28f; pickaxe10_minePower = 4.3f; pickaxe10_2XChance = 3.5f; pickaxe10_miningAreaSize = 1.75f;
        pickaxe11_mineTime = 0.25f; pickaxe11_minePower = 4.5f; pickaxe11_2XChance = 4f; pickaxe11_miningAreaSize = 1.75f;
        pickaxe12_mineTime = 0.24f; pickaxe12_minePower = 5f; pickaxe12_2XChance = 4.3f; pickaxe12_miningAreaSize = 1.8f;
        pickaxe13_mineTime = 0.23f; pickaxe13_minePower = 6f; pickaxe13_2XChance = 4.6f; pickaxe13_miningAreaSize = 1.9f;
        pickaxe14_mineTime = 0.20f; pickaxe14_minePower = 8f; pickaxe14_2XChance = 5.5f; pickaxe14_miningAreaSize = 2.1f;

        CheckPickaxes();
        if (pickaxe1_equipped) { EquipPickaxe(0); pickaxeNumber = 0; }
        if (pickaxe2_equipped) { EquipPickaxe(1); pickaxeNumber = 0; PickaxeSlection(true); }
        if (pickaxe3_equipped) { EquipPickaxe(2); pickaxeNumber = 1; PickaxeSlection(true); }
        if (pickaxe4_equipped) { EquipPickaxe(3); pickaxeNumber = 2; PickaxeSlection(true); }
        if (pickaxe5_equipped) { EquipPickaxe(4); pickaxeNumber = 3; PickaxeSlection(true); }
        if (pickaxe6_equipped) { EquipPickaxe(5); pickaxeNumber = 4; PickaxeSlection(true); }
        if (pickaxe7_equipped) { EquipPickaxe(6); pickaxeNumber = 5; PickaxeSlection(true); }
        if (pickaxe8_equipped) { EquipPickaxe(7); pickaxeNumber = 6; PickaxeSlection(true); }
        if (pickaxe9_equipped) { EquipPickaxe(8); pickaxeNumber = 7; PickaxeSlection(true); }
        if (pickaxe10_equipped) { EquipPickaxe(9); pickaxeNumber = 8; PickaxeSlection(true); }
        if (pickaxe11_equipped) { EquipPickaxe(10); pickaxeNumber = 9; PickaxeSlection(true); }
        if (pickaxe12_equipped) { EquipPickaxe(11); pickaxeNumber = 10; PickaxeSlection(true); }
        if (pickaxe13_equipped) { EquipPickaxe(12); pickaxeNumber = 11; PickaxeSlection(true); }
        if (pickaxe14_equipped) { EquipPickaxe(13); pickaxeNumber = 12; PickaxeSlection(true); }

        playSound = true;
    }

    public GameObject craftingFrame;
    public GameObject outLineCircle;
    public Image craftingCircle;
    public TextMeshProUGUI craftingText;

    #region update - Craft and equip
    private float craftingTime = 2.4f;
    private float currentTime = 0f;
    private bool isCrafting = false;
    private bool craftingCompleted = false;

    private float dotTimer = 0f;
    private int dotCount = 0;

    private void Update()
    {
        #region Prices
        if (pickaxeNumber == 1)
        {
            if (GoldAndOreMechanics.totalGoldBars >= pickaxe2_goldPrice) { goldPriceText.color = Color.green; }
            else { goldPriceText.color = Color.red; }
            goldPriceText.text = (pickaxe2_goldPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
        }
        if (pickaxeNumber == 2)
        {
            if (GoldAndOreMechanics.totalGoldBars >= pickaxe3_goldPrice) { goldPriceText.color = Color.green; }
            else { goldPriceText.color = Color.red; }
            if (GoldAndOreMechanics.totalCopperBars >= pickaxe3_copperPrice) { copperPriceText.color = Color.green; }
            else { copperPriceText.color = Color.red; }

            goldPriceText.text = (pickaxe3_goldPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
            copperPriceText.text = (pickaxe3_copperPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
        }
        if (pickaxeNumber == 3)
        {
            if (GoldAndOreMechanics.totalCopperBars >= pickaxe4_copperPrice) { copperPriceText.color = Color.green; }
            else { copperPriceText.color = Color.red; }
            if (GoldAndOreMechanics.totalIronBars >= pickaxe4_ironPrice) { ironPriceText.color = Color.green; }
            else { ironPriceText.color = Color.red; }

            copperPriceText.text = (pickaxe4_copperPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
            ironPriceText.text = (pickaxe4_ironPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
        }
        if (pickaxeNumber == 4)
        {
            if (GoldAndOreMechanics.totalGoldBars >= pickaxe5_goldPrice) { goldPriceText.color = Color.green; }
            else { goldPriceText.color = Color.red; }
            if (GoldAndOreMechanics.totalIronBars >= pickaxe5_ironPrice) { ironPriceText.color = Color.green; }
            else { ironPriceText.color = Color.red; }

            goldPriceText.text = (pickaxe5_goldPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
            ironPriceText.text = (pickaxe5_ironPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
        }
        if (pickaxeNumber == 5)
        {
            if (GoldAndOreMechanics.totalGoldBars >= pickaxe6_goldPrice) { goldPriceText.color = Color.green; }
            else { goldPriceText.color = Color.red; }
            if (GoldAndOreMechanics.totalCobaltBars >= pickaxe6_cobaltPrice) { cobaltPriceText.color = Color.green; }
            else { cobaltPriceText.color = Color.red; }

            goldPriceText.text = (pickaxe6_goldPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
            cobaltPriceText.text = (pickaxe6_cobaltPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
        }
        if (pickaxeNumber == 6)
        {
            if (GoldAndOreMechanics.totalGoldBars >= pickaxe7_goldPrice) { goldPriceText.color = Color.green; }
            else { goldPriceText.color = Color.red; }
            if (GoldAndOreMechanics.totalCopperBars >= pickaxe7_copperPrice) { copperPriceText.color = Color.green; }
            else { copperPriceText.color = Color.red; }
            if (GoldAndOreMechanics.totalIronBars >= pickaxe7_ironPrice) { ironPriceText.color = Color.green; }
            else { ironPriceText.color = Color.red; }

            goldPriceText.text = (pickaxe7_goldPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
            copperPriceText.text = (pickaxe7_copperPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
            ironPriceText.text = (pickaxe7_ironPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
        }
        if (pickaxeNumber == 7)
        {
            if (GoldAndOreMechanics.totalCobaltBars >= pickaxe8_cobaltPrice) { cobaltPriceText.color = Color.green; }
            else { cobaltPriceText.color = Color.red; }
            if (GoldAndOreMechanics.totalUraniumBars >= pickaxe8_uraniumPrice) { uraniumPriceText.color = Color.green; }
            else { uraniumPriceText.color = Color.red; }

            cobaltPriceText.text = (pickaxe8_cobaltPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
            uraniumPriceText.text = (pickaxe8_uraniumPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
        }
        if (pickaxeNumber == 8)
        {
            if (GoldAndOreMechanics.totalGoldBars >= pickaxe9_goldPrice) { goldPriceText.color = Color.green; }
            else { goldPriceText.color = Color.red; }
            if (GoldAndOreMechanics.totalUraniumBars >= pickaxe9_uraniumPrice) { uraniumPriceText.color = Color.green; }
            else { uraniumPriceText.color = Color.red; }
            if (GoldAndOreMechanics.totalIsmiumBar >= pickaxe9_ismiumPrice) { ismiumPriceText.color = Color.green; }
            else { ismiumPriceText.color = Color.red; }

            goldPriceText.text = (pickaxe9_goldPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
            uraniumPriceText.text = (pickaxe9_uraniumPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
            ismiumPriceText.text = (pickaxe9_ismiumPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
        }
        if (pickaxeNumber == 9)
        {
            if (GoldAndOreMechanics.totalGoldBars >= pickaxe10_goldPrice) { goldPriceText.color = Color.green; }
            else { goldPriceText.color = Color.red; }
            if (GoldAndOreMechanics.totalCopperBars >= pickaxe10_copperPrice) { copperPriceText.color = Color.green; }
            else { copperPriceText.color = Color.red; }
            if (GoldAndOreMechanics.totalIridiumBars >= pickaxe10_iridiumPrice) { iridiumPriceText.color = Color.green; }
            else { iridiumPriceText.color = Color.red; }

            goldPriceText.text = (pickaxe10_goldPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
            copperPriceText.text = (pickaxe10_copperPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
            iridiumPriceText.text = (pickaxe10_iridiumPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
        }
        if (pickaxeNumber == 10)
        {
            if (GoldAndOreMechanics.totalCobaltBars >= pickaxe11_cobaltPrice) { cobaltPriceText.color = Color.green; }
            else { cobaltPriceText.color = Color.red; }
            if (GoldAndOreMechanics.totalUraniumBars >= pickaxe11_uraniumPrice) { uraniumPriceText.color = Color.green; }
            else { uraniumPriceText.color = Color.red; }
            if (GoldAndOreMechanics.totalIsmiumBar >= pickaxe11_ismiumPrice) { ismiumPriceText.color = Color.green; }
            else { ismiumPriceText.color = Color.red; }

            cobaltPriceText.text = (pickaxe11_cobaltPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
            uraniumPriceText.text = (pickaxe11_uraniumPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
            ismiumPriceText.text = (pickaxe11_ismiumPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
        }
        if (pickaxeNumber == 11)
        {
            if (GoldAndOreMechanics.totalGoldBars >= pickaxe12_goldPrice) { goldPriceText.color = Color.green; }
            else { goldPriceText.color = Color.red; }
            if (GoldAndOreMechanics.totalIridiumBars >= pickaxe12_iridiumPrice) { iridiumPriceText.color = Color.green; }
            else { iridiumPriceText.color = Color.red; }

            goldPriceText.text = (pickaxe12_goldPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
            iridiumPriceText.text = (pickaxe12_iridiumPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
        }
        if (pickaxeNumber == 12)
        {
            if (GoldAndOreMechanics.totalGoldBars >= pickaxe13_goldPrice) { goldPriceText.color = Color.green; }
            else { goldPriceText.color = Color.red; }
            if (GoldAndOreMechanics.totalIronBars >= pickaxe13_ironPrice) { ironPriceText.color = Color.green; }
            else { ironPriceText.color = Color.red; }
            if (GoldAndOreMechanics.totalPainiteBars >= pickaxe13_painitePrice) { painitePriceText.color = Color.green; }
            else { painitePriceText.color = Color.red; }

            goldPriceText.text = (pickaxe13_goldPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
            ironPriceText.text = (pickaxe13_ironPrice * LevelMechanics.blacksmithDecrease).ToString("F0");
            painitePriceText.text = (pickaxe13_painitePrice * LevelMechanics.blacksmithDecrease).ToString("F0");
        }
        #endregion

        if (MainMenu.isInTheAnvil)
        {
            //Crafting
            if (Input.GetMouseButton(1))
            {
                bool canCraft = false;

                float priceDecrease = LevelMechanics.blacksmithDecrease;

                #region check if can craft
                if (pickaxeNumber == 1 && pickaxe2_crafted == false) 
                {
                    if(GoldAndOreMechanics.totalGoldBars >= pickaxe2_goldPrice * priceDecrease) { canCraft = true; }
                }
                if (pickaxeNumber == 2 && pickaxe3_crafted == false)
                {
                    if (GoldAndOreMechanics.totalGoldBars >= pickaxe3_goldPrice * priceDecrease && GoldAndOreMechanics.totalCopperBars >= pickaxe3_copperPrice * priceDecrease) { canCraft = true; }
                }
                if (pickaxeNumber == 3 && pickaxe4_crafted == false)
                {
                    if (GoldAndOreMechanics.totalCopperBars >= pickaxe4_copperPrice * priceDecrease && GoldAndOreMechanics.totalIronBars >= pickaxe4_ironPrice * priceDecrease) { canCraft = true; }
                }
                if (pickaxeNumber == 4 && pickaxe5_crafted == false)
                {
                    if (GoldAndOreMechanics.totalGoldBars >= pickaxe5_goldPrice * priceDecrease && GoldAndOreMechanics.totalIronBars >= pickaxe5_ironPrice * priceDecrease) { canCraft = true; }
                }
                if (pickaxeNumber == 5 && pickaxe6_crafted == false)
                {
                    if (GoldAndOreMechanics.totalGoldBars >= pickaxe6_goldPrice * priceDecrease && GoldAndOreMechanics.totalCobaltBars >= pickaxe6_cobaltPrice * priceDecrease) { canCraft = true; }
                }
                if (pickaxeNumber == 6 && pickaxe7_crafted == false)
                {
                    if (GoldAndOreMechanics.totalGoldBars >= pickaxe7_goldPrice * priceDecrease && GoldAndOreMechanics.totalCopperBars >= pickaxe7_copperPrice * priceDecrease && GoldAndOreMechanics.totalIronBars >= pickaxe7_ironPrice * priceDecrease) { canCraft = true; }
                }
                if (pickaxeNumber == 7 && pickaxe8_crafted == false)
                {
                    if (GoldAndOreMechanics.totalCobaltBars >= pickaxe8_cobaltPrice * priceDecrease && GoldAndOreMechanics.totalUraniumBars >= pickaxe8_uraniumPrice * priceDecrease) { canCraft = true; }
                }
                if (pickaxeNumber == 8 && pickaxe9_crafted == false)
                {
                    if (GoldAndOreMechanics.totalGoldBars >= pickaxe9_goldPrice * priceDecrease && GoldAndOreMechanics.totalUraniumBars >= pickaxe9_uraniumPrice * priceDecrease && GoldAndOreMechanics.totalIsmiumBar >= pickaxe9_ismiumPrice * priceDecrease) { canCraft = true; }
                }
                if (pickaxeNumber == 9 && pickaxe10_crafted == false)
                {
                    if (GoldAndOreMechanics.totalGoldBars >= pickaxe10_goldPrice * priceDecrease && GoldAndOreMechanics.totalCopperBars >= pickaxe10_copperPrice * priceDecrease && GoldAndOreMechanics.totalIridiumBars >= pickaxe10_iridiumPrice * priceDecrease) { canCraft = true; }
                }
                if (pickaxeNumber == 10 && pickaxe11_crafted == false)
                {
                    if (GoldAndOreMechanics.totalCobaltBars >= pickaxe11_cobaltPrice * priceDecrease && GoldAndOreMechanics.totalUraniumBars >= pickaxe11_uraniumPrice * priceDecrease && GoldAndOreMechanics.totalIsmiumBar >= pickaxe11_ismiumPrice * priceDecrease) { canCraft = true; }
                }
                if (pickaxeNumber == 11 && pickaxe12_crafted == false)
                {
                    if (GoldAndOreMechanics.totalGoldBars >= pickaxe12_goldPrice * priceDecrease && GoldAndOreMechanics.totalIridiumBars >= pickaxe12_iridiumPrice * priceDecrease) { canCraft = true; }
                }
                if (pickaxeNumber == 12 && pickaxe13_crafted == false)
                {
                    if (GoldAndOreMechanics.totalGoldBars >= pickaxe13_goldPrice * priceDecrease && GoldAndOreMechanics.totalIronBars >= pickaxe13_ironPrice * priceDecrease && GoldAndOreMechanics.totalPainiteBars >= pickaxe13_painitePrice * priceDecrease) { canCraft = true; }
                }
                #endregion

                if (canCraft == true)
                {
                    if (!isCrafting)
                    {
                        audioManager.Play("Crafting...");

                        isCrafting = true;
                        currentTime = 0f;
                        dotTimer = 0f;
                        dotCount = 0;
                        craftingCompleted = false;
                        craftingFrame.SetActive(true);
                    }

                    if (!craftingCompleted)
                    {
                        currentTime += Time.deltaTime;
                        float fill = Mathf.Clamp01(currentTime / craftingTime);
                        outLineCircle.SetActive(true);
                        craftingText.gameObject.SetActive(true);
                        craftingCircle.gameObject.SetActive(true);
                        craftingCircle.fillAmount = fill;

                        if (fill >= 1f && !craftingCompleted)
                        {
                            audioManager.Stop("Crafting...");

                            craftingCompleted = true;
                            OnCraftingComplete();
                        }

                        dotTimer += Time.deltaTime;
                        if (dotTimer >= 0.35f)
                        {
                            dotTimer = 0f;
                            dotCount = (dotCount + 1) % 4;
                            craftingText.text = "Crafting" + new string('.', dotCount);
                        }
                    }
                }
            }
            else
            {
                if (isCrafting)
                {
                    if (isInCraftingDone == false)
                    {
                        isCrafting = false;
                        craftingFrame.SetActive(false);
                        craftingCircle.fillAmount = 0f;
                    }
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (pickaxeNumber == 0 && pickaxe1_crafted == true && pickaxe1_equipped == false) { EquipPickaxe(pickaxeNumber); }
                if (pickaxeNumber == 1 && pickaxe2_crafted == true && pickaxe2_equipped == false) { EquipPickaxe(pickaxeNumber); }
                if (pickaxeNumber == 2 && pickaxe3_crafted == true && pickaxe3_equipped == false) { EquipPickaxe(pickaxeNumber); }
                if (pickaxeNumber == 3 && pickaxe4_crafted == true && pickaxe4_equipped == false) { EquipPickaxe(pickaxeNumber); }
                if (pickaxeNumber == 4 && pickaxe5_crafted == true && pickaxe5_equipped == false) { EquipPickaxe(pickaxeNumber); }
                if (pickaxeNumber == 5 && pickaxe6_crafted == true && pickaxe6_equipped == false) { EquipPickaxe(pickaxeNumber); }
                if (pickaxeNumber == 6 && pickaxe7_crafted == true && pickaxe7_equipped == false) { EquipPickaxe(pickaxeNumber); }
                if (pickaxeNumber == 7 && pickaxe8_crafted == true && pickaxe8_equipped == false) { EquipPickaxe(pickaxeNumber); }
                if (pickaxeNumber == 8 && pickaxe9_crafted == true && pickaxe9_equipped == false) { EquipPickaxe(pickaxeNumber); }
                if (pickaxeNumber == 9 && pickaxe10_crafted == true && pickaxe10_equipped == false) { EquipPickaxe(pickaxeNumber); }
                if (pickaxeNumber == 10 && pickaxe11_crafted == true && pickaxe11_equipped == false) { EquipPickaxe(pickaxeNumber); }
                if (pickaxeNumber == 11 && pickaxe12_crafted == true && pickaxe12_equipped == false) { EquipPickaxe(pickaxeNumber); }
                if (pickaxeNumber == 12 && pickaxe13_crafted == true && pickaxe13_equipped == false) { EquipPickaxe(pickaxeNumber); }
                if (pickaxeNumber == 13 && pickaxe14_crafted == true && pickaxe14_equipped == false) { EquipPickaxe(pickaxeNumber); }
            }
        }
    }

    private void OnCraftingComplete()
    {
        audioManager.Play("CraftingDone");
        audioManager.Play("FinishedCrafting");

        if(pickaxeNumber == 1) { pickaxe2_crafted = true; SetImageToWhite(pickaxe2_topImage); SetImageToWhite(pickaxe2_craftImage);  }
        if (pickaxeNumber == 2) { pickaxe3_crafted = true; SetImageToWhite(pickaxe3_topImage); SetImageToWhite(pickaxe3_craftImage); }
        if (pickaxeNumber == 3) { pickaxe4_crafted = true; SetImageToWhite(pickaxe4_topImage); SetImageToWhite(pickaxe4_craftImage); }
        if (pickaxeNumber == 4) { pickaxe5_crafted = true; SetImageToWhite(pickaxe5_topImage); SetImageToWhite(pickaxe5_craftImage); }
        if (pickaxeNumber == 5) { pickaxe6_crafted = true; SetImageToWhite(pickaxe6_topImage); SetImageToWhite(pickaxe6_craftImage); }
        if (pickaxeNumber == 6) { pickaxe7_crafted = true; SetImageToWhite(pickaxe7_topImage); SetImageToWhite(pickaxe7_craftImage); }
        if (pickaxeNumber == 7) { pickaxe8_crafted = true; SetImageToWhite(pickaxe8_topImage); SetImageToWhite(pickaxe8_craftImage); }
        if (pickaxeNumber == 8) { pickaxe9_crafted = true; SetImageToWhite(pickaxe9_topImage); SetImageToWhite(pickaxe9_craftImage); }
        if (pickaxeNumber == 9) { pickaxe10_crafted = true; SetImageToWhite(pickaxe10_topImage); SetImageToWhite(pickaxe10_craftImage); }
        if (pickaxeNumber == 10) { pickaxe11_crafted = true; SetImageToWhite(pickaxe11_topImage); SetImageToWhite(pickaxe11_craftImage); }
        if (pickaxeNumber == 11) { pickaxe12_crafted = true; SetImageToWhite(pickaxe12_topImage); SetImageToWhite(pickaxe12_craftImage); }
        if (pickaxeNumber == 12) { pickaxe13_crafted = true; SetImageToWhite(pickaxe13_topImage); SetImageToWhite(pickaxe13_craftImage); }

        #region Reduce bars
        if (pickaxeNumber == 1)
        {
            GoldAndOreMechanics.totalGoldBars -= pickaxe2_goldPrice;
        }
        if (pickaxeNumber == 2)
        {
            GoldAndOreMechanics.totalGoldBars -= pickaxe3_goldPrice;
            GoldAndOreMechanics.totalCopperBars -= pickaxe3_copperPrice;
        }
        if (pickaxeNumber == 3)
        {
            GoldAndOreMechanics.totalCopperBars -= pickaxe4_copperPrice;
            GoldAndOreMechanics.totalIronBars -= pickaxe4_ironPrice;
        }
        if (pickaxeNumber == 4)
        {
            GoldAndOreMechanics.totalGoldBars -= pickaxe5_goldPrice;
            GoldAndOreMechanics.totalIronBars -= pickaxe5_ironPrice;
        }
        if (pickaxeNumber == 5)
        {
            GoldAndOreMechanics.totalGoldBars -= pickaxe6_goldPrice;
            GoldAndOreMechanics.totalCobaltBars -= pickaxe6_cobaltPrice;
        }
        if (pickaxeNumber == 6)
        {
            GoldAndOreMechanics.totalGoldBars -= pickaxe7_goldPrice;
            GoldAndOreMechanics.totalCopperBars -= pickaxe7_copperPrice;
            GoldAndOreMechanics.totalIronBars -= pickaxe7_ironPrice;
        }
        if (pickaxeNumber == 7)
        {
            GoldAndOreMechanics.totalCobaltBars -= pickaxe8_cobaltPrice;
            GoldAndOreMechanics.totalUraniumBars -= pickaxe8_uraniumPrice;
        }
        if (pickaxeNumber == 8)
        {
            GoldAndOreMechanics.totalGoldBars -= pickaxe9_goldPrice;
            GoldAndOreMechanics.totalUraniumBars -= pickaxe9_uraniumPrice;
            GoldAndOreMechanics.totalIsmiumBar -= pickaxe9_ismiumPrice;
        }
        if (pickaxeNumber == 9)
        {
            GoldAndOreMechanics.totalGoldBars -= pickaxe10_goldPrice;
            GoldAndOreMechanics.totalCopperBars -= pickaxe10_copperPrice;
            GoldAndOreMechanics.totalIridiumBars -= pickaxe10_iridiumPrice;
        }
        if (pickaxeNumber == 10)
        {
            GoldAndOreMechanics.totalCobaltBars -= pickaxe11_cobaltPrice;
            GoldAndOreMechanics.totalUraniumBars -= pickaxe11_uraniumPrice;
            GoldAndOreMechanics.totalIsmiumBar -= pickaxe11_ismiumPrice;
        }
        if (pickaxeNumber == 11)
        {
            GoldAndOreMechanics.totalGoldBars -= pickaxe12_goldPrice;
            GoldAndOreMechanics.totalIridiumBars -= pickaxe12_iridiumPrice;
        }
        if (pickaxeNumber == 12)
        {
            GoldAndOreMechanics.totalGoldBars -= pickaxe13_goldPrice;
            GoldAndOreMechanics.totalIronBars -= pickaxe13_ironPrice;
            GoldAndOreMechanics.totalPainiteBars -= pickaxe13_painitePrice;
        }
        #endregion

        goldAndOreScript.SetTotalResourcesText();

        CheckPickaxes();

        craftingCircle.gameObject.SetActive(false);
        outLineCircle.SetActive(false);
        craftingText.gameObject.SetActive(false);
        craftingText.text = "Crafted!";
        isInCraftingDone = true;
        StartCoroutine(SetFinishedCraftingPopUp());
    }

    public static bool isInCraftingDone;

    public GameObject pickaxe1PopUp;
    public ParticleSystem craftedParticle, pickaxeParticle;

    public Sprite pickaxe2Sprite, pickaxe3Sprite, pickaxe4Sprite, pickaxe5Sprite, pickaxe6Sprite, pickaxe7Sprite, pickaxe8Sprite, pickaxe9Sprite, pickaxe10Sprite, pickaxe11Sprite, pickaxe12Sprite, pickaxe13Sprite;

    IEnumerator SetFinishedCraftingPopUp()
    {
        //var textureSheetAnimation = pickaxeParticle.textureSheetAnimation;
        //textureSheetAnimation.SetSprite(0, pickaxe2Sprite);

        if (pickaxeNumber == 1) { pickaxeParticle.textureSheetAnimation.SetSprite(0, pickaxe2Sprite); }
        if (pickaxeNumber == 2) { pickaxeParticle.textureSheetAnimation.SetSprite(0, pickaxe3Sprite); }
        if (pickaxeNumber == 3) { pickaxeParticle.textureSheetAnimation.SetSprite(0, pickaxe4Sprite); }
        if (pickaxeNumber == 4) { pickaxeParticle.textureSheetAnimation.SetSprite(0, pickaxe5Sprite); }
        if (pickaxeNumber == 5) { pickaxeParticle.textureSheetAnimation.SetSprite(0, pickaxe6Sprite); }
        if (pickaxeNumber == 6) { pickaxeParticle.textureSheetAnimation.SetSprite(0, pickaxe7Sprite); }
        if (pickaxeNumber == 7) { pickaxeParticle.textureSheetAnimation.SetSprite(0, pickaxe8Sprite); }
        if (pickaxeNumber == 8) { pickaxeParticle.textureSheetAnimation.SetSprite(0, pickaxe9Sprite); }
        if (pickaxeNumber == 9) { pickaxeParticle.textureSheetAnimation.SetSprite(0, pickaxe10Sprite); }
        if (pickaxeNumber == 10) { pickaxeParticle.textureSheetAnimation.SetSprite(0, pickaxe11Sprite); }
        if (pickaxeNumber == 11) { pickaxeParticle.textureSheetAnimation.SetSprite(0, pickaxe12Sprite); }
        if (pickaxeNumber == 12) { pickaxeParticle.textureSheetAnimation.SetSprite(0, pickaxe13Sprite); }

        craftedParticle.Play();
        yield return new WaitForSeconds(2.35f);
      
        craftingFrame.SetActive(false);
        isInCraftingDone = false;
    }
    #endregion

    #region Equip pickaxe
    public void EquipPickaxe(int pickaxeNumber)
    {
        if(playSound == true)
        {
            audioManager.Play("Equip");
        }

        pickaxe1_equipped = false; pickaxe2_equipped = false; pickaxe3_equipped = false; pickaxe4_equipped = false; pickaxe5_equipped = false; pickaxe6_equipped = false; pickaxe7_equipped = false; pickaxe8_equipped = false; pickaxe9_equipped = false; pickaxe10_equipped = false; pickaxe11_equipped = false; pickaxe12_equipped = false; pickaxe13_equipped = false; pickaxe14_equipped = false;

        pickaxe1_frameIcon.SetActive(false); pickaxe2_frameIcon.SetActive(false); pickaxe3_frameIcon.SetActive(false); pickaxe4_frameIcon.SetActive(false); pickaxe5_frameIcon.SetActive(false); pickaxe6_frameIcon.SetActive(false); pickaxe7_frameIcon.SetActive(false); pickaxe8_frameIcon.SetActive(false); pickaxe9_frameIcon.SetActive(false); pickaxe10_frameIcon.SetActive(false); pickaxe11_frameIcon.SetActive(false); pickaxe12_frameIcon.SetActive(false); pickaxe13_frameIcon.SetActive(false); pickaxe14_frameIcon.SetActive(false);

        if (pickaxeNumber == 0) { pickaxe1_equipped = true; equippedMineTime = pickaxe1_mineTime + collTime; equippedMinePower = pickaxe1_minePower; equipped2XChance = pickaxe1_2XChance; equippedMiningArea = pickaxe1_miningAreaSize; pickaxe1_frameIcon.SetActive(true); }
        if (pickaxeNumber == 1) { pickaxe2_equipped = true; equippedMineTime = pickaxe2_mineTime + collTime; equippedMinePower = pickaxe2_minePower; equipped2XChance = pickaxe2_2XChance; equippedMiningArea = pickaxe2_miningAreaSize; pickaxe2_frameIcon.SetActive(true); }
        if (pickaxeNumber == 2) { pickaxe3_equipped = true; equippedMineTime = pickaxe3_mineTime + collTime; equippedMinePower = pickaxe3_minePower; equipped2XChance = pickaxe3_2XChance; equippedMiningArea = pickaxe3_miningAreaSize; pickaxe3_frameIcon.SetActive(true); }
        if (pickaxeNumber == 3) { pickaxe4_equipped = true; equippedMineTime = pickaxe4_mineTime + collTime; equippedMinePower = pickaxe4_minePower; equipped2XChance = pickaxe4_2XChance; equippedMiningArea = pickaxe4_miningAreaSize; pickaxe4_frameIcon.SetActive(true); }
        if (pickaxeNumber == 4) { pickaxe5_equipped = true; equippedMineTime = pickaxe5_mineTime + collTime; equippedMinePower = pickaxe5_minePower; equipped2XChance = pickaxe5_2XChance; equippedMiningArea = pickaxe5_miningAreaSize; pickaxe5_frameIcon.SetActive(true); }
        if (pickaxeNumber == 5) { pickaxe6_equipped = true; equippedMineTime = pickaxe6_mineTime + collTime; equippedMinePower = pickaxe6_minePower; equipped2XChance = pickaxe6_2XChance; equippedMiningArea = pickaxe6_miningAreaSize; pickaxe6_frameIcon.SetActive(true); }
        if (pickaxeNumber == 6) { pickaxe7_equipped = true; equippedMineTime = pickaxe7_mineTime + collTime; equippedMinePower = pickaxe7_minePower; equipped2XChance = pickaxe7_2XChance; equippedMiningArea = pickaxe7_miningAreaSize; pickaxe7_frameIcon.SetActive(true); }
        if (pickaxeNumber == 7) { pickaxe8_equipped = true; equippedMineTime = pickaxe8_mineTime + collTime; equippedMinePower = pickaxe8_minePower; equipped2XChance = pickaxe8_2XChance; equippedMiningArea = pickaxe8_miningAreaSize; pickaxe8_frameIcon.SetActive(true); }
        if (pickaxeNumber == 8) { pickaxe9_equipped = true; equippedMineTime = pickaxe9_mineTime + collTime; equippedMinePower = pickaxe9_minePower; equipped2XChance = pickaxe9_2XChance; equippedMiningArea = pickaxe9_miningAreaSize; pickaxe9_frameIcon.SetActive(true); }
        if (pickaxeNumber == 9) { pickaxe10_equipped = true; equippedMineTime = pickaxe10_mineTime + collTime; equippedMinePower = pickaxe10_minePower; equipped2XChance = pickaxe10_2XChance; equippedMiningArea = pickaxe10_miningAreaSize; pickaxe10_frameIcon.SetActive(true); }
        if (pickaxeNumber == 10) { pickaxe11_equipped = true; equippedMineTime = pickaxe11_mineTime + collTime; equippedMinePower = pickaxe11_minePower; equipped2XChance = pickaxe11_2XChance; equippedMiningArea = pickaxe11_miningAreaSize; pickaxe11_frameIcon.SetActive(true); }
        if (pickaxeNumber == 11) { pickaxe12_equipped = true; equippedMineTime = pickaxe12_mineTime + collTime; equippedMinePower = pickaxe12_minePower; equipped2XChance = pickaxe12_2XChance; equippedMiningArea = pickaxe12_miningAreaSize; pickaxe12_frameIcon.SetActive(true); }
        if (pickaxeNumber == 12) { pickaxe13_equipped = true; equippedMineTime = pickaxe13_mineTime + collTime; equippedMinePower = pickaxe13_minePower; equipped2XChance = pickaxe13_2XChance; equippedMiningArea = pickaxe13_miningAreaSize; pickaxe13_frameIcon.SetActive(true); }
        if (pickaxeNumber == 13) { pickaxe14_equipped = true; equippedMineTime = pickaxe14_mineTime + collTime; equippedMinePower = pickaxe14_minePower; equipped2XChance = pickaxe14_2XChance; equippedMiningArea = pickaxe14_miningAreaSize; pickaxe14_frameIcon.SetActive(true); }

        DisplayEquippedAndSetStats(equippedMineTime, equippedMinePower, equipped2XChance, equippedMiningArea);
        CheckPickaxes();
    }
    #endregion

    #region Equipped frame and stats
    public TextMeshProUGUI currentMineTime_text;
    public TextMeshProUGUI currentMinePower_text;
    public TextMeshProUGUI current2XPowerChance_text;
    public TextMeshProUGUI currentMiningErea_text;

    public void DisplayEquippedAndSetStats(float mineTime, float minePower, float doubleChance, float miningErea)
    {
        //currentMineTime = (mineTime) * (SkillTree.reducePickaxeMineTime - SetRockScreen.potionPickaxeStats_increase);
        currentMineTime = mineTime / (1 + SkillTree.reducePickaxeMineTime + SetRockScreen.potionPickaxeStats_increase);

        float runeIncreaseClaw;
        if (Artifacts.wolfClaw_found) { runeIncreaseClaw = Artifacts.clawChance * (1 + Artifacts.runeImproveAll + LevelMechanics.archeologistIncrease); }
        else { runeIncreaseClaw = 0; }

        currentMinePower = minePower * (SkillTree.improvedPickaxeStrength + runeIncreaseClaw + SetRockScreen.potionPickaxeStats_increase);
        current2XPowerChance = doubleChance * (SkillTree.improvedPickaxeStrength + SetRockScreen.potionPickaxeStats_increase);
        currentMiningErea = miningErea * (SkillTree.improvedPickaxeStrength + SetRockScreen.potionPickaxeStats_increase + LevelMechanics.shapeShifterSizeIncrease);

        currentMineTime_text.text = (currentMineTime).ToString("F2") + "s";
        currentMinePower_text.text = currentMinePower.ToString("F1");
        current2XPowerChance_text.text = current2XPowerChance.ToString("F1") + "%";
        currentMiningErea_text.text = currentMiningErea.ToString("F1");

        SetHandColliderSize(currentMiningErea);
    }
    #endregion

    #region Set hand collider size
    public GameObject handCollider, triangleCollider, squareCollider, hexagonCollider;
    public float currentColliderSize;

    public void SetHandColliderSize(float size)
    {
        size *= SkillTree.miningAreaSize;
        handCollider.transform.localScale = new Vector2(size, size);
        triangleCollider.transform.localScale = new Vector2(size, size);
        squareCollider.transform.localScale = new Vector2(size, size);
        hexagonCollider.transform.localScale = new Vector2(size, size);
        currentColliderSize = size;

        if(SkillTree.increaseAndDecreaseMinignErea_purchased == true)
        {
            if(scaleUpAndDownCoroutine == null) { scaleUpAndDownCoroutine = StartCoroutine(ScaleHandColliderUpAndDown()); }
            else
            {
                StopCoroutine(scaleUpAndDownCoroutine);
                scaleUpAndDownCoroutine = StartCoroutine(ScaleHandColliderUpAndDown());
            }
        }
    }

    public Coroutine scaleUpAndDownCoroutine;

    IEnumerator ScaleHandColliderUpAndDown()
    {
        float maxSize = currentColliderSize * 1.2f;
        float minSize = currentColliderSize * 0.9f;
        float duration = 2f;

        while (true)
        {
            // Scale Up
            float elapsedTime = 0f;
            Vector3 startScale = Vector3.one * currentColliderSize;
            Vector3 targetScale = Vector3.one * maxSize;

            while (elapsedTime < duration)
            {
                if (LevelMechanics.isDoubleAreaSize == true)
                {
                    float scaleIncrease = 1 + LevelMechanics.inflationBurstIncrease;

                    handCollider.transform.localScale = Vector3.Lerp(startScale * scaleIncrease, targetScale * scaleIncrease, elapsedTime / duration);
                    triangleCollider.transform.localScale = Vector3.Lerp(startScale * scaleIncrease, targetScale * scaleIncrease, elapsedTime / duration);
                    squareCollider.transform.localScale = Vector3.Lerp(startScale * scaleIncrease, targetScale * scaleIncrease, elapsedTime / duration);
                    hexagonCollider.transform.localScale = Vector3.Lerp(startScale * scaleIncrease, targetScale * scaleIncrease, elapsedTime / duration);
                }
                else
                {
                    handCollider.transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
                    triangleCollider.transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
                    squareCollider.transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
                    hexagonCollider.transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
                }

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            handCollider.transform.localScale = targetScale;

            // Scale Down
            elapsedTime = 0f;
            startScale = targetScale;
            targetScale = Vector3.one * minSize;

            while (elapsedTime < duration)
            {
                float scaleIncrease = 1 + LevelMechanics.inflationBurstIncrease;

                if (LevelMechanics.isDoubleAreaSize == true)
                {
                    handCollider.transform.localScale = Vector3.Lerp(startScale * scaleIncrease, targetScale * scaleIncrease, elapsedTime / duration);
                    triangleCollider.transform.localScale = Vector3.Lerp(startScale * scaleIncrease, targetScale * scaleIncrease, elapsedTime / duration);
                    squareCollider.transform.localScale = Vector3.Lerp(startScale * scaleIncrease, targetScale * scaleIncrease, elapsedTime / duration);
                    hexagonCollider.transform.localScale = Vector3.Lerp(startScale * scaleIncrease, targetScale * scaleIncrease, elapsedTime / duration);
                }
                else
                {
                    handCollider.transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
                    triangleCollider.transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
                    squareCollider.transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
                    hexagonCollider.transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
                }
             
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            handCollider.transform.localScale = targetScale;

            currentColliderSize = minSize; 
        }
    }
    #endregion

    #region Pickaxe selection
    public GameObject[] pickaxes;
    public int pickaxeNumber;

    public Transform leftPickaxePos, middlePickaxePos, rightPickaxePos;
    public GameObject diamondPickaxeQuestionMark;

    public void PickaxeSlection(bool moveRight)
    {
        diamondPickaxeQuestionMark.SetActive(false);

        if(playSound == true) { audioManager.Play("UI_Click1"); }

        for (int i = 0; i < pickaxes.Length; i++)
        {
            pickaxes[i].SetActive(false);
        }

        if(moveRight == true) { pickaxeNumber += 1; }
        else { pickaxeNumber -= 1; }

        if(pickaxeNumber < 0) { pickaxeNumber = 0; }
        if (pickaxeNumber > 13) { pickaxeNumber = 13; }

        pickaxes[pickaxeNumber].SetActive(true);
        pickaxes[pickaxeNumber].transform.localScale = new Vector2(1.25f, 1.25f);
        pickaxes[pickaxeNumber].transform.localPosition = middlePickaxePos.transform.localPosition;

        if (pickaxeNumber < 13)
        {
            pickaxes[pickaxeNumber + 1].SetActive(true);
            pickaxes[pickaxeNumber + 1].transform.localScale = new Vector2(0.75f, 0.75f);
            pickaxes[pickaxeNumber + 1].transform.localPosition = rightPickaxePos.transform.localPosition;
        }

        if (pickaxeNumber > 0) 
        {
            pickaxes[pickaxeNumber - 1].SetActive(true);
            pickaxes[pickaxeNumber - 1].transform.localScale = new Vector2(0.75f, 0.75f);
            pickaxes[pickaxeNumber - 1].transform.localPosition = leftPickaxePos.transform.localPosition;
        }

        pickaxe1_craftImage.gameObject.SetActive(false); pickaxe2_craftImage.gameObject.SetActive(false); pickaxe3_craftImage.gameObject.SetActive(false);
        pickaxe4_craftImage.gameObject.SetActive(false); pickaxe5_craftImage.gameObject.SetActive(false); pickaxe6_craftImage.gameObject.SetActive(false);
        pickaxe7_craftImage.gameObject.SetActive(false); pickaxe8_craftImage.gameObject.SetActive(false); pickaxe9_craftImage.gameObject.SetActive(false);
        pickaxe10_craftImage.gameObject.SetActive(false); pickaxe11_craftImage.gameObject.SetActive(false); pickaxe12_craftImage.gameObject.SetActive(false);
        pickaxe13_craftImage.gameObject.SetActive(false); pickaxe14_craftImage.gameObject.SetActive(false);

        if (pickaxeNumber == 0) { pickaxe1_craftImage.gameObject.SetActive(true); }
        if (pickaxeNumber == 1) { pickaxe2_craftImage.gameObject.SetActive(true); }
        if (pickaxeNumber == 2) { pickaxe3_craftImage.gameObject.SetActive(true); }
        if (pickaxeNumber == 3) { pickaxe4_craftImage.gameObject.SetActive(true); }
        if (pickaxeNumber == 4) { pickaxe5_craftImage.gameObject.SetActive(true); }
        if (pickaxeNumber == 5) { pickaxe6_craftImage.gameObject.SetActive(true); }
        if (pickaxeNumber == 6) { pickaxe7_craftImage.gameObject.SetActive(true); }
        if (pickaxeNumber == 7) { pickaxe8_craftImage.gameObject.SetActive(true); }
        if (pickaxeNumber == 8) { pickaxe9_craftImage.gameObject.SetActive(true); }
        if (pickaxeNumber == 9) { pickaxe10_craftImage.gameObject.SetActive(true); }
        if (pickaxeNumber == 10) { pickaxe11_craftImage.gameObject.SetActive(true); }
        if (pickaxeNumber == 11) { pickaxe12_craftImage.gameObject.SetActive(true); }
        if (pickaxeNumber == 12) { pickaxe13_craftImage.gameObject.SetActive(true); }
        if (pickaxeNumber == 13)
        { 
            pickaxe14_craftImage.gameObject.SetActive(true);
            diamondPickaxeQuestionMark.SetActive(true);
            if (pickaxe14_crafted) 
            {
                SetImageToWhite(pickaxe14_topImage); SetImageToWhite(pickaxe14_craftImage);
                diamondPickaxeQuestionMark.SetActive(false); 
            }
        }

        CheckPickaxes();
    }
    #endregion

    #region Check pickaxe
    public void CheckPickaxes()
    {
        pickaxeStatsParent.SetActive(false);
        pickaxePriceParent.SetActive(false);

        bool isHoldToCraft = false;
        bool isPressToEquip = false;
        bool isUnlockedAndEquipped = false;
        bool isUnlockedButNotEquipped = false;

        #region check if unlocked and equipped
        if (pickaxeNumber == 0 && pickaxe1_equipped) { isUnlockedAndEquipped = true; equippedPickaxeName.text = LocalizationScript.pickaxe1_name; }
        if (pickaxeNumber == 1 && pickaxe2_equipped) { isUnlockedAndEquipped = true; equippedPickaxeName.text = LocalizationScript.pickaxe2_name; }
        if (pickaxeNumber == 2 && pickaxe3_equipped) { isUnlockedAndEquipped = true; equippedPickaxeName.text = LocalizationScript.pickaxe3_name; }
        if (pickaxeNumber == 3 && pickaxe4_equipped) { isUnlockedAndEquipped = true; equippedPickaxeName.text = LocalizationScript.pickaxe4_name; }
        if (pickaxeNumber == 4 && pickaxe5_equipped) { isUnlockedAndEquipped = true; equippedPickaxeName.text = LocalizationScript.pickaxe5_name; }
        if (pickaxeNumber == 5 && pickaxe6_equipped) { isUnlockedAndEquipped = true; equippedPickaxeName.text = LocalizationScript.pickaxe6_name; }
        if (pickaxeNumber == 6 && pickaxe7_equipped) { isUnlockedAndEquipped = true; equippedPickaxeName.text = LocalizationScript.pickaxe7_name; }
        if (pickaxeNumber == 7 && pickaxe8_equipped) { isUnlockedAndEquipped = true; equippedPickaxeName.text = LocalizationScript.pickaxe8_name; }
        if (pickaxeNumber == 8 && pickaxe9_equipped) { isUnlockedAndEquipped = true; equippedPickaxeName.text = LocalizationScript.pickaxe9_name; }
        if (pickaxeNumber == 9 && pickaxe10_equipped) { isUnlockedAndEquipped = true; equippedPickaxeName.text = LocalizationScript.pickaxe10_name; }
        if (pickaxeNumber == 10 && pickaxe11_equipped) { isUnlockedAndEquipped = true; equippedPickaxeName.text = LocalizationScript.pickaxe11_name; }
        if (pickaxeNumber == 11 && pickaxe12_equipped) { isUnlockedAndEquipped = true; equippedPickaxeName.text = LocalizationScript.pickaxe12_name; }
        if (pickaxeNumber == 12 && pickaxe13_equipped) { isUnlockedAndEquipped = true; equippedPickaxeName.text = LocalizationScript.pickaxe13_name; }
        if (pickaxeNumber == 13 && pickaxe14_equipped) { isUnlockedAndEquipped = true; equippedPickaxeName.text = LocalizationScript.pickaxe14_name; }
        #endregion

        #region check if unlocked and NOT equipped
        if (pickaxeNumber == 0 && pickaxe1_crafted && pickaxe1_equipped == false ) { isUnlockedButNotEquipped = true; isPressToEquip = true; }
        if (pickaxeNumber == 1 && pickaxe2_crafted && pickaxe2_equipped == false) { isUnlockedButNotEquipped = true; isPressToEquip = true; }
        if (pickaxeNumber == 2 && pickaxe3_crafted && pickaxe3_equipped == false) { isUnlockedButNotEquipped = true; isPressToEquip = true; }
        if (pickaxeNumber == 3 && pickaxe4_crafted && pickaxe4_equipped == false) { isUnlockedButNotEquipped = true; isPressToEquip = true; }
        if (pickaxeNumber == 4 && pickaxe5_crafted && pickaxe5_equipped == false) { isUnlockedButNotEquipped = true; isPressToEquip = true; }
        if (pickaxeNumber == 5 && pickaxe6_crafted && pickaxe6_equipped == false) { isUnlockedButNotEquipped = true; isPressToEquip = true; }
        if (pickaxeNumber == 6 && pickaxe7_crafted && pickaxe7_equipped == false) { isUnlockedButNotEquipped = true; isPressToEquip = true; }
        if (pickaxeNumber == 7 && pickaxe8_crafted && pickaxe8_equipped == false) { isUnlockedButNotEquipped = true; isPressToEquip = true; }
        if (pickaxeNumber == 8 && pickaxe9_crafted && pickaxe9_equipped == false) { isUnlockedButNotEquipped = true; isPressToEquip = true; }
        if (pickaxeNumber == 9 && pickaxe10_crafted && pickaxe10_equipped == false) { isUnlockedButNotEquipped = true; isPressToEquip = true; }
        if (pickaxeNumber == 10 && pickaxe11_crafted && pickaxe11_equipped == false) { isUnlockedButNotEquipped = true; isPressToEquip = true; }
        if (pickaxeNumber == 11 && pickaxe12_crafted && pickaxe12_equipped == false) { isUnlockedButNotEquipped = true; isPressToEquip = true; }
        if (pickaxeNumber == 12 && pickaxe13_crafted && pickaxe13_equipped == false) { isUnlockedButNotEquipped = true; isPressToEquip = true; }
        if (pickaxeNumber == 13 && pickaxe14_crafted && pickaxe14_equipped == false) { isUnlockedButNotEquipped = true; isPressToEquip = true; }
        #endregion

        #region check if unlocked and equipped
        if (pickaxeNumber == 1 && pickaxe2_crafted == false) { isHoldToCraft = true; topPickaxeName.text = "?????????"; }
        if (pickaxeNumber == 2 && pickaxe3_crafted == false) { isHoldToCraft = true; topPickaxeName.text = "?????????"; }
        if (pickaxeNumber == 3 && pickaxe4_crafted == false) { isHoldToCraft = true; topPickaxeName.text = "?????????"; }
        if (pickaxeNumber == 4 && pickaxe5_crafted == false) { isHoldToCraft = true; topPickaxeName.text = "?????????"; }
        if (pickaxeNumber == 5 && pickaxe6_crafted == false) { isHoldToCraft = true; topPickaxeName.text = "?????????"; }
        if (pickaxeNumber == 6 && pickaxe7_crafted == false) { isHoldToCraft = true; topPickaxeName.text = "?????????"; }
        if (pickaxeNumber == 7 && pickaxe8_crafted == false) { isHoldToCraft = true; topPickaxeName.text = "?????????"; }
        if (pickaxeNumber == 8 && pickaxe9_crafted == false) { isHoldToCraft = true; topPickaxeName.text = "?????????"; }
        if (pickaxeNumber == 9 && pickaxe10_crafted == false) { isHoldToCraft = true; topPickaxeName.text = "?????????"; }
        if (pickaxeNumber == 10 && pickaxe11_crafted == false) { isHoldToCraft = true; topPickaxeName.text = "?????????"; }
        if (pickaxeNumber == 11 && pickaxe12_crafted == false) { isHoldToCraft = true; topPickaxeName.text = "?????????"; }
        if (pickaxeNumber == 12 && pickaxe13_crafted == false) { isHoldToCraft = true; topPickaxeName.text = "?????????"; }
        if (pickaxeNumber == 13 && pickaxe14_crafted == false) { isHoldToCraft = true; topPickaxeName.text = "?????????"; }
        #endregion

        #region check if selected and crafted
        if (pickaxeNumber == 0 && pickaxe1_crafted) { topPickaxeName.text = LocalizationScript.pickaxe1_name; }
        if (pickaxeNumber == 1 && pickaxe2_crafted) { topPickaxeName.text = LocalizationScript.pickaxe2_name; }
        if (pickaxeNumber == 2 && pickaxe3_crafted) { topPickaxeName.text = LocalizationScript.pickaxe3_name; }
        if (pickaxeNumber == 3 && pickaxe4_crafted) { topPickaxeName.text = LocalizationScript.pickaxe4_name; }
        if (pickaxeNumber == 4 && pickaxe5_crafted) { topPickaxeName.text = LocalizationScript.pickaxe5_name; }
        if (pickaxeNumber == 5 && pickaxe6_crafted) { topPickaxeName.text = LocalizationScript.pickaxe6_name; }
        if (pickaxeNumber == 6 && pickaxe7_crafted) { topPickaxeName.text = LocalizationScript.pickaxe7_name; }
        if (pickaxeNumber == 7 && pickaxe8_crafted) { topPickaxeName.text = LocalizationScript.pickaxe8_name; }
        if (pickaxeNumber == 8 && pickaxe9_crafted) { topPickaxeName.text = LocalizationScript.pickaxe9_name; }
        if (pickaxeNumber == 9 && pickaxe10_crafted) { topPickaxeName.text = LocalizationScript.pickaxe10_name; }
        if (pickaxeNumber == 10 && pickaxe11_crafted) { topPickaxeName.text = LocalizationScript.pickaxe11_name; }
        if (pickaxeNumber == 11 && pickaxe12_crafted) { topPickaxeName.text = LocalizationScript.pickaxe12_name; }
        if (pickaxeNumber == 12 && pickaxe13_crafted) { topPickaxeName.text = LocalizationScript.pickaxe13_name; }
        if (pickaxeNumber == 13 && pickaxe14_crafted) { topPickaxeName.text = LocalizationScript.pickaxe14_name; }
        #endregion

        #region Compage stats
        if(pickaxeNumber == 0) { ComparePickaxeStats(0, pickaxe1_mineTime + collTime, pickaxe1_minePower, pickaxe1_2XChance, pickaxe1_miningAreaSize); }
        if (pickaxeNumber == 1) { ComparePickaxeStats(1, pickaxe2_mineTime + collTime, pickaxe2_minePower, pickaxe2_2XChance, pickaxe2_miningAreaSize); }
        if (pickaxeNumber == 2) { ComparePickaxeStats(2, pickaxe3_mineTime + collTime, pickaxe3_minePower, pickaxe3_2XChance, pickaxe3_miningAreaSize); }
        if (pickaxeNumber == 3) { ComparePickaxeStats(3, pickaxe4_mineTime + collTime, pickaxe4_minePower, pickaxe4_2XChance, pickaxe4_miningAreaSize); }
        if (pickaxeNumber == 4) { ComparePickaxeStats(4, pickaxe5_mineTime + collTime, pickaxe5_minePower, pickaxe5_2XChance, pickaxe5_miningAreaSize); }
        if (pickaxeNumber == 5) { ComparePickaxeStats(5, pickaxe6_mineTime + collTime, pickaxe6_minePower, pickaxe6_2XChance, pickaxe6_miningAreaSize); }
        if (pickaxeNumber == 6) { ComparePickaxeStats(6, pickaxe7_mineTime + collTime, pickaxe7_minePower, pickaxe7_2XChance, pickaxe7_miningAreaSize); }
        if (pickaxeNumber == 7) { ComparePickaxeStats(7, pickaxe8_mineTime + collTime, pickaxe8_minePower, pickaxe8_2XChance, pickaxe8_miningAreaSize); }
        if (pickaxeNumber == 8) { ComparePickaxeStats(8, pickaxe9_mineTime + collTime, pickaxe9_minePower, pickaxe9_2XChance, pickaxe9_miningAreaSize); }
        if (pickaxeNumber == 9) { ComparePickaxeStats(9, pickaxe10_mineTime + collTime, pickaxe10_minePower, pickaxe10_2XChance, pickaxe10_miningAreaSize); }
        if (pickaxeNumber == 10) { ComparePickaxeStats(10, pickaxe11_mineTime + collTime, pickaxe11_minePower, pickaxe11_2XChance, pickaxe11_miningAreaSize); }
        if (pickaxeNumber == 11) { ComparePickaxeStats(11, pickaxe12_mineTime + collTime, pickaxe12_minePower, pickaxe12_2XChance, pickaxe12_miningAreaSize); }
        if (pickaxeNumber == 12) { ComparePickaxeStats(12, pickaxe13_mineTime + collTime, pickaxe13_minePower, pickaxe13_2XChance, pickaxe13_miningAreaSize); }
        if (pickaxeNumber == 13) { ComparePickaxeStats(13, pickaxe14_mineTime + collTime, pickaxe14_minePower, pickaxe14_2XChance, pickaxe14_miningAreaSize); }
        #endregion

        if (isUnlockedAndEquipped == true)
        {
            darkPickaxeParent.SetActive(false);
            pickaxeStatsParent.SetActive(true);
            pickaxePriceParent.SetActive(false);
        }
        else if (isUnlockedButNotEquipped == true) //Compare stats to current equipped pickaxe
        {
            darkPickaxeParent.SetActive(true);
            pickaxeStatsParent.SetActive(true);
            pickaxePriceParent.SetActive(false);
        }

        if(isPressToEquip == true)
        {
            darkPickaxeParent.SetActive(true);
            holdToCraftText.text = "Click to equip";
            pickaxeStatsParent.SetActive(true);
            pickaxePriceParent.SetActive(false);
        }
        if (isHoldToCraft)
        {
            darkPickaxeParent.SetActive(true);
            int totalMaterialCost = 0;

            GameObject priceObject1 = null, priceObject2 = null, priceObject3 = null;

            priceObject1 = goldCraftPrice.gameObject; priceObject2 = copperCraftPrice.gameObject; priceObject3 = ironCraftPRice.gameObject;

            if (pickaxeNumber == 1) { totalMaterialCost = 1; priceObject1 = goldCraftPrice.gameObject; }
            if (pickaxeNumber == 2) { totalMaterialCost = 2; priceObject1 = goldCraftPrice.gameObject; priceObject2 = copperCraftPrice.gameObject; }
            if (pickaxeNumber == 3) { totalMaterialCost = 2; priceObject1 = copperCraftPrice.gameObject; priceObject2 = ironCraftPRice.gameObject; }
            if (pickaxeNumber == 4) { totalMaterialCost = 2; priceObject1 = goldCraftPrice.gameObject; priceObject2 = ironCraftPRice.gameObject; }
            if (pickaxeNumber == 5) { totalMaterialCost = 2; priceObject1 = goldCraftPrice.gameObject; priceObject2 = cobaltCraftPrice.gameObject; }
            if (pickaxeNumber == 6) { totalMaterialCost = 3; priceObject1 = goldCraftPrice.gameObject; priceObject2 = ironCraftPRice.gameObject; priceObject3 = copperCraftPrice.gameObject; }
            if (pickaxeNumber == 7) { totalMaterialCost = 2; priceObject1 = cobaltCraftPrice.gameObject; priceObject2 = uraniumCraftPrice.gameObject; }
            if (pickaxeNumber == 8) { totalMaterialCost = 3; priceObject1 = goldCraftPrice.gameObject; priceObject2 = uraniumCraftPrice.gameObject; priceObject3 = ismiumCraftPrice.gameObject; }
            if (pickaxeNumber == 9) { totalMaterialCost = 3; priceObject1 = goldCraftPrice.gameObject; priceObject2 = copperCraftPrice.gameObject; priceObject3 = iridiumCraftPrice.gameObject; }
            if (pickaxeNumber == 10) { totalMaterialCost = 3; priceObject1 = cobaltCraftPrice.gameObject; priceObject2 = uraniumCraftPrice.gameObject; priceObject3 = ismiumCraftPrice.gameObject; }
            if (pickaxeNumber == 11) { totalMaterialCost = 2; priceObject1 = goldCraftPrice.gameObject; priceObject2 = iridiumCraftPrice.gameObject; }
            if (pickaxeNumber == 12) { totalMaterialCost = 3; priceObject1 = goldCraftPrice.gameObject; priceObject2 = ironCraftPRice.gameObject; priceObject3 = painiteCraftPrice.gameObject; }
            if (pickaxeNumber == 13) 
            { 
                //Diamond
            }

            priceObject1.SetActive(false);
            priceObject2.SetActive(false);
            priceObject3.SetActive(false);

            goldCraftPrice.gameObject.SetActive(false); copperCraftPrice.gameObject.SetActive(false); ironCraftPRice.gameObject.SetActive(false);
            cobaltCraftPrice.gameObject.SetActive(false); uraniumCraftPrice.gameObject.SetActive(false); ismiumCraftPrice.gameObject.SetActive(false);
            iridiumCraftPrice.gameObject.SetActive(false); painiteCraftPrice.gameObject.SetActive(false);

            if (totalMaterialCost == 1)
            {
                priceObject1.SetActive(true);
                priceObject1.transform.localScale = new Vector2(1.3f, 1.3f);
                priceObject1.transform.localPosition = new Vector2(-18f, -47f);
            }
            if (totalMaterialCost == 2)
            {
                priceObject1.SetActive(true); priceObject2.SetActive(true);
                priceObject1.transform.localScale = new Vector2(0.93f, 0.93f);
                priceObject1.transform.localPosition = new Vector2(-14f, -36f);

                priceObject2.transform.localScale = new Vector2(0.93f, 0.93f);
                priceObject2.transform.localPosition = new Vector2(-14f, -82f);
            }

            if (totalMaterialCost == 3)
            {
                priceObject1.SetActive(true); priceObject2.SetActive(true); priceObject3.SetActive(true);
                priceObject1.transform.localScale = new Vector2(0.7f, 0.7f);
                priceObject1.transform.localPosition = new Vector2(-11f, -31f);

                priceObject2.transform.localScale = new Vector2(0.7f, 0.7f);
                priceObject2.transform.localPosition = new Vector2(-11f, -66f);

                priceObject3.transform.localScale = new Vector2(0.7f, 0.7f);
                priceObject3.transform.localPosition = new Vector2(-11f, -102f);
            }

            holdToCraftText.text = "Hold to craft";
            pickaxeStatsParent.SetActive(false);
            pickaxePriceParent.SetActive(true);
        }

        if (SkillTree.spawnCopper_purchased == false)
        {
            copperBar.SetActive(false);
            copperQuestionmark.SetActive(true);
        }
        else
        {
            copperBar.SetActive(true);
            copperQuestionmark.SetActive(false);
        }

        if (SkillTree.spawnIron_purchased == false)
        {
            ironBar.SetActive(false);
            ironQuestionmark.SetActive(true);
        }
        else
        {
            ironBar.SetActive(true);
            ironQuestionmark.SetActive(false);
        }

        if (SkillTree.cobaltSpawn_purchased == false)
        {
            cobaltBar.SetActive(false);
            cobaltQuestionmark.SetActive(true);
        }
        else
        {
            cobaltBar.SetActive(true);
            cobaltQuestionmark.SetActive(false);
        }

        if (SkillTree.uraniumSpawn_purchased == false)
        {
            uraniumBar.SetActive(false);
            uraniumQuestionmark.SetActive(true);
        }
        else
        {
            uraniumBar.SetActive(true);
            uraniumQuestionmark.SetActive(false);
        }

        if (SkillTree.ismiumSpawn_purchased == false)
        {
            ismiumBar.SetActive(false);
            ismiumQuestionmark.SetActive(true);
        }
        else
        {
            ismiumBar.SetActive(true);
            ismiumQuestionmark.SetActive(false);
        }

        if (SkillTree.iridiumSpawn_purchased == false)
        {
            iridiumBar.SetActive(false);
            iridiumQuestionmark.SetActive(true);
        }
        else
        {
            iridiumBar.SetActive(true);
            iridiumQuestionmark.SetActive(false);
        }

        if (SkillTree.painiteSpawn_purchased == false)
        {
            painiteBar.SetActive(false);
            painiteQuestionmark.SetActive(true);
        }
        else
        {
            painiteBar.SetActive(true);
            painiteQuestionmark.SetActive(false);
        }
    }

    public TextMeshProUGUI goldCraftPrice, copperCraftPrice, ironCraftPRice, cobaltCraftPrice, uraniumCraftPrice, ismiumCraftPrice, iridiumCraftPrice, painiteCraftPrice;

    public TextMeshProUGUI holdToCraftText;
    public GameObject darkPickaxeParent;
    public GameObject pickaxeStatsParent;
    public GameObject pickaxePriceParent;
    #endregion

    #region compage stats
    public TextMeshProUGUI mineTime_displayText, minePower_displayText, doublePowerChance_displayText, miningArea_displayText;

    public GameObject red1, green1, white1;
    public GameObject red2, green2, white2;
    public GameObject red3, green3, white3;
    public GameObject red4, green4, white4;

    public void ComparePickaxeStats(int number, float mineTime, float minePower, float doubleChance, float miningErea)
    {
        red1.SetActive(false); green1.SetActive(false); white1.SetActive(false);
        red2.SetActive(false); green2.SetActive(false); white2.SetActive(false);
        red3.SetActive(false); green3.SetActive(false); white3.SetActive(false);
        red4.SetActive(false); green4.SetActive(false); white4.SetActive(false);

        float newMineTime = 0;
        float newMinePower = 0;
        float newDoubleChance = 0;
        float newMiningArea = 0;

        newMineTime = mineTime / (1 + SkillTree.reducePickaxeMineTime);

        float runeIncreaseClaw;
        if (Artifacts.wolfClaw_found) { runeIncreaseClaw = Artifacts.clawChance * (1 + Artifacts.runeImproveAll + LevelMechanics.archeologistIncrease); }
        else { runeIncreaseClaw = 0; }

        newMinePower = minePower * (SkillTree.improvedPickaxeStrength + runeIncreaseClaw + SetRockScreen.potionPickaxeStats_increase);
        newDoubleChance = doubleChance * (SkillTree.improvedPickaxeStrength + SetRockScreen.potionPickaxeStats_increase);
        newMiningArea = miningErea * (SkillTree.improvedPickaxeStrength + SetRockScreen.potionPickaxeStats_increase + LevelMechanics.shapeShifterSizeIncrease);

        mineTime_displayText.text = newMineTime.ToString("F2") + "s";
        minePower_displayText.text = newMinePower.ToString("F1");
        doublePowerChance_displayText.text = newDoubleChance.ToString("F1") + "%";
        miningArea_displayText.text = newMiningArea.ToString("F1") + "";

        bool setWhite = false;

        if (number == 0 && pickaxe1_equipped) { setWhite = true; }
        if (number == 1 && pickaxe2_equipped) { setWhite = true; }
        if (number == 2 && pickaxe3_equipped) { setWhite = true; }
        if (number == 3 && pickaxe4_equipped) { setWhite = true; }
        if (number == 4 && pickaxe5_equipped) { setWhite = true; }
        if (number == 5 && pickaxe6_equipped) { setWhite = true; }
        if (number == 6 && pickaxe7_equipped) { setWhite = true; }
        if (number == 7 && pickaxe8_equipped) { setWhite = true; }
        if (number == 8 && pickaxe9_equipped) { setWhite = true; }
        if (number == 9 && pickaxe10_equipped) { setWhite = true; }
        if (number == 10 && pickaxe11_equipped) { setWhite = true; }
        if (number == 11 && pickaxe12_equipped) { setWhite = true; }
        if (number == 12 && pickaxe13_equipped) { setWhite = true; }
        if (number == 13 && pickaxe14_equipped) { setWhite = true; }

        if(setWhite == true)
        {
            white1.SetActive(true); white2.SetActive(true); white3.SetActive(true); white4.SetActive(true);
        }
        else
        {
            if (mineTime < equippedMineTime) { green1.SetActive(true); }
            else if (mineTime == equippedMineTime) { white1.SetActive(true); }
            else { red1.SetActive(true); }

            if (minePower > equippedMinePower) { green2.SetActive(true); }
            else if (minePower == equippedMinePower) { white2.SetActive(true); }
            else { red2.SetActive(true); }

            if (doubleChance > equipped2XChance) { green3.SetActive(true); }
            else if (doubleChance == equipped2XChance) { white3.SetActive(true); }
            else { red3.SetActive(true); }

            if (miningErea > equippedMiningArea) { green4.SetActive(true); }
            else if (miningErea == equippedMiningArea) { white4.SetActive(true); }
            else { red4.SetActive(true); }
        }
    }
    #endregion

    #region pickaxe varaibles and SetImageToWhite
    public GameObject pickaxe1_frameIcon, pickaxe2_frameIcon, pickaxe3_frameIcon, pickaxe4_frameIcon,pickaxe5_frameIcon, pickaxe6_frameIcon, pickaxe7_frameIcon, pickaxe8_frameIcon, pickaxe9_frameIcon, pickaxe10_frameIcon, pickaxe11_frameIcon, pickaxe12_frameIcon, pickaxe13_frameIcon, pickaxe14_frameIcon;

    public Image pickaxe1_topImage, pickaxe2_topImage, pickaxe3_topImage, pickaxe4_topImage, pickaxe5_topImage, pickaxe6_topImage, pickaxe7_topImage, pickaxe8_topImage, pickaxe9_topImage, pickaxe10_topImage, pickaxe11_topImage, pickaxe12_topImage, pickaxe13_topImage, pickaxe14_topImage;

    public Image pickaxe1_craftImage, pickaxe2_craftImage, pickaxe3_craftImage, pickaxe4_craftImage, pickaxe5_craftImage, pickaxe6_craftImage, pickaxe7_craftImage, pickaxe8_craftImage, pickaxe9_craftImage, pickaxe10_craftImage, pickaxe11_craftImage, pickaxe12_craftImage, pickaxe13_craftImage, pickaxe14_craftImage;

    public void SetImageToWhite(Image image)
    {
        if (image != null)
        {
            image.color = new Color32(255, 255, 255, 255); // FFFFFF and 100% alpha
        }
    }

    public void SetImageToDark(Image image)
    {
        if (image != null)
        {
            image.color = new Color32(0, 0, 0, 215); //Dark and a little transparancy
        }
    }
    #endregion


    #region Load Data
    public void LoadData(GameData data)
    {
        isTheAnvilUnlocked = data.isTheAnvilUnlocked;

        pickaxe1_crafted = data.pickaxe1_crafted;
        pickaxe2_crafted = data.pickaxe2_crafted;
        pickaxe3_crafted = data.pickaxe3_crafted;
        pickaxe4_crafted = data.pickaxe4_crafted;
        pickaxe5_crafted = data.pickaxe5_crafted;
        pickaxe6_crafted = data.pickaxe6_crafted;
        pickaxe7_crafted = data.pickaxe7_crafted;
        pickaxe8_crafted = data.pickaxe8_crafted;
        pickaxe9_crafted = data.pickaxe9_crafted;
        pickaxe10_crafted = data.pickaxe10_crafted;
        pickaxe11_crafted = data.pickaxe11_crafted;
        pickaxe12_crafted = data.pickaxe12_crafted;
        pickaxe13_crafted = data.pickaxe13_crafted;
        pickaxe14_crafted = data.pickaxe14_crafted;

        pickaxe1_equipped = data.pickaxe1_equipped;
        pickaxe2_equipped = data.pickaxe2_equipped;
        pickaxe3_equipped = data.pickaxe3_equipped;
        pickaxe4_equipped = data.pickaxe4_equipped;
        pickaxe5_equipped = data.pickaxe5_equipped;
        pickaxe6_equipped = data.pickaxe6_equipped;
        pickaxe7_equipped = data.pickaxe7_equipped;
        pickaxe8_equipped = data.pickaxe8_equipped;
        pickaxe9_equipped = data.pickaxe9_equipped;
        pickaxe10_equipped = data.pickaxe10_equipped;
        pickaxe11_equipped = data.pickaxe11_equipped;
        pickaxe12_equipped = data.pickaxe12_equipped;
        pickaxe13_equipped = data.pickaxe13_equipped;
        pickaxe14_equipped = data.pickaxe14_equipped;

    }
    #endregion

    #region Save Data
    public void SaveData(ref GameData data)
    {
        data.isTheAnvilUnlocked = isTheAnvilUnlocked;

        data.pickaxe1_crafted = pickaxe1_crafted;
        data.pickaxe2_crafted = pickaxe2_crafted;
        data.pickaxe3_crafted = pickaxe3_crafted;
        data.pickaxe4_crafted = pickaxe4_crafted;
        data.pickaxe5_crafted = pickaxe5_crafted;
        data.pickaxe6_crafted = pickaxe6_crafted;
        data.pickaxe7_crafted = pickaxe7_crafted;
        data.pickaxe8_crafted = pickaxe8_crafted;
        data.pickaxe9_crafted = pickaxe9_crafted;
        data.pickaxe10_crafted = pickaxe10_crafted;
        data.pickaxe11_crafted = pickaxe11_crafted;
        data.pickaxe12_crafted = pickaxe12_crafted;
        data.pickaxe13_crafted = pickaxe13_crafted;
        data.pickaxe14_crafted = pickaxe14_crafted;

        data.pickaxe1_equipped = pickaxe1_equipped;
        data.pickaxe2_equipped = pickaxe2_equipped;
        data.pickaxe3_equipped = pickaxe3_equipped;
        data.pickaxe4_equipped = pickaxe4_equipped;
        data.pickaxe5_equipped = pickaxe5_equipped;
        data.pickaxe6_equipped = pickaxe6_equipped;
        data.pickaxe7_equipped = pickaxe7_equipped;
        data.pickaxe8_equipped = pickaxe8_equipped;
        data.pickaxe9_equipped = pickaxe9_equipped;
        data.pickaxe10_equipped = pickaxe10_equipped;
        data.pickaxe11_equipped = pickaxe11_equipped;
        data.pickaxe12_equipped = pickaxe12_equipped;
        data.pickaxe13_equipped = pickaxe13_equipped;
        data.pickaxe14_equipped = pickaxe14_equipped;
    }
    #endregion

    public void ResetAnvil()
    {
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

        playSound = false;
        EquipPickaxe(0);

        SetImageToDark(pickaxe2_topImage); SetImageToDark(pickaxe2_craftImage);
        SetImageToDark(pickaxe3_topImage); SetImageToDark(pickaxe3_craftImage);
        SetImageToDark(pickaxe4_topImage); SetImageToDark(pickaxe4_craftImage);
        SetImageToDark(pickaxe5_topImage); SetImageToDark(pickaxe5_craftImage);
        SetImageToDark(pickaxe6_topImage); SetImageToDark(pickaxe6_craftImage);
        SetImageToDark(pickaxe7_topImage); SetImageToDark(pickaxe7_craftImage);
        SetImageToDark(pickaxe8_topImage); SetImageToDark(pickaxe8_craftImage);
        SetImageToDark(pickaxe9_topImage); SetImageToDark(pickaxe9_craftImage);
        SetImageToDark(pickaxe10_topImage); SetImageToDark(pickaxe10_craftImage);
        SetImageToDark(pickaxe11_topImage); SetImageToDark(pickaxe11_craftImage);
        SetImageToDark(pickaxe12_topImage); SetImageToDark(pickaxe12_craftImage);
        SetImageToDark(pickaxe13_topImage); SetImageToDark(pickaxe13_craftImage);

        CheckPickaxes();

        pickaxeNumber = 1;
        PickaxeSlection(false);

        playSound = true;
    }
}
