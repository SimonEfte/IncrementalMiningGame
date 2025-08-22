using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RockMechanics : MonoBehaviour
{
    public ScreenShake screenShakeScript;
    public LevelMechanics levelScript;
    public SpawnProjectiles spawnProjectileScript;
    public SetRockScreen setRockScreenScript;
    public Artifacts artifactsScript;
    public OverlappingSounds overlappingScript;
    public GoldAndOreMechanics goldScript;

    public Transform rock1;
    public SpriteRenderer rock1Sprite;

    public bool isRockSpawnedIn;

    #region Broken variables
    //Rock
    public Transform rock1Broken;
    public SpriteRenderer rock1BrokenSprite;

    // Gold
    public Transform rockGoldBroken;
    public SpriteRenderer rockGoldBrokenSprite;

    // Copper
    public Transform rockCopperBroken;
    public SpriteRenderer rockCopperBrokenSprite;

    // Silver
    public Transform rockSilverBroken;
    public SpriteRenderer rockSilverBrokenSprite;

    // Cobalt
    public Transform rockCobaltBroken;
    public SpriteRenderer rockCobaltBrokenSprite;

    // Uranium
    public Transform rockUraniumBroken;
    public SpriteRenderer rockUraniumBrokenSprite;

    // Ismium
    public Transform rockIsmiumBroken;
    public SpriteRenderer rockIsmiumBrokenSprite;

    // Iridium
    public Transform rockIridiumBroken;
    public SpriteRenderer rockIridiumBrokenSprite;

    // Painite
    public Transform rockPainiteBroken;
    public SpriteRenderer rockPainiteBrokenSprite;
    #endregion

    #region Material varialbes
    //Gold
    public Transform chunkOfGold;
    public SpriteRenderer chunkOfGoldSprite;

    public Transform fullGold;
    public SpriteRenderer fullGoldSprite;

    // Copper
    public Transform chunkOfCopper;
    public SpriteRenderer chunkOfCopperSprite;

    public Transform fullCopper;
    public SpriteRenderer fullCopperSprite;

    // Silver
    public Transform chunkOfSilver;
    public SpriteRenderer chunkOfSilverSprite;

    public Transform fullSilver;
    public SpriteRenderer fullSilverSprite;

    // Cobalt
    public Transform chunkOfCobalt;
    public SpriteRenderer chunkOfCobaltSprite;

    public Transform fullCobalt;
    public SpriteRenderer fullCobaltSprite;

    // Uranium
    public Transform chunkOfUranium;
    public SpriteRenderer chunkOfUraniumSprite;

    public Transform fullUranium;
    public SpriteRenderer fullUraniumSprite;

    // Ismium
    public Transform chunkOfIsmium;
    public SpriteRenderer chunkOfIsmiumSprite;

    public Transform fullIsmium;
    public SpriteRenderer fullIsmiumSprite;

    // Iridium
    public Transform chunkOfIridium;
    public SpriteRenderer chunkOfIridiumSprite;

    public Transform fullIridium;
    public SpriteRenderer fullIridiumSprite;

    // Painite
    public Transform chunkOfPainite;
    public SpriteRenderer chunkOfPainiteSprite;

    public Transform fullPainite;
    public SpriteRenderer fullPainiteSprite;

    #endregion

    public GameObject currentActiveRock, currentBrokenRock;
    public SpriteRenderer currentRockSprite, currentBrokenSprite, currentChunkSprite;

    bool isGoldChunk, isFullGold;
    bool isCopperChunk, isFullCopper;
    bool isSilverChunk, isFullSilver;
    bool isCobaltChunk, isFullCobalt;
    bool isUraniumChunk, isFullUranium;
    bool isIsmiumChunk, isFullIsmium;
    bool isIridiumChunk, isFullIridium;
    bool isPainiteChunk, isFullPainite;

    public float rockHp;

    private Collider2D rockCollider;

    bool isMinedWithHammer;

    public GameObject originalArtifactParent;

    private Transform chest, chestOpen, goldenChest, goldenChestOpen;
    private SpriteRenderer chestSprite, chestOpenSprite, goldenChestSprite, goldenChestOpenSprite;

    public Rigidbody2D rockRigidbody;

    public bool isBigRock;
    public GameObject bigRockFull, bigRockBroken1, bigRockBroken2;

    #region Awake
    private void Awake()
    {
        if(isBigRock == false)
        {
            rockRigidbody = gameObject.GetComponent<Rigidbody2D>();

            chest = transform.Find("Chest");
            chestSprite = chest.gameObject.GetComponent<SpriteRenderer>();

            chestOpen = transform.Find("Chest_open");
            chestOpenSprite = chestOpen.gameObject.GetComponent<SpriteRenderer>();

            goldenChest = transform.Find("GoldenChest");
            goldenChestSprite = goldenChest.gameObject.GetComponent<SpriteRenderer>();

            goldenChestOpen = transform.Find("GoldenChest_open");
            goldenChestOpenSprite = goldenChestOpen.gameObject.GetComponent<SpriteRenderer>();

            originalArtifactParent = GameObject.Find("OriginalArtifactParent");

            rockCollider = gameObject.GetComponent<Collider2D>();
            _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
            SetMaterials();

         
            //gameObject.name = "TargetObject" + targetNumber;

            rock1 = transform.Find("RockFull");
            rock1Sprite = rock1.gameObject.GetComponent<SpriteRenderer>();

            rock1Broken = transform.Find("Rock1Broken");
            rock1BrokenSprite = rock1Broken.gameObject.GetComponent<SpriteRenderer>();

            //Gold
            chunkOfGold = transform.Find("ChunkOfGold");
            chunkOfGoldSprite = chunkOfGold.gameObject.GetComponent<SpriteRenderer>();

            fullGold = transform.Find("Rock_fullGold");
            fullGoldSprite = fullGold.gameObject.GetComponent<SpriteRenderer>();

            rockGoldBroken = transform.Find("GoldBroken");
            rockGoldBrokenSprite = rockGoldBroken.GetComponent<SpriteRenderer>();

            // --- Copper ---
            chunkOfCopper = transform.Find("CopperChunk");
            chunkOfCopperSprite = chunkOfCopper.GetComponent<SpriteRenderer>();

            fullCopper = transform.Find("CopperFull");
            fullCopperSprite = fullCopper.GetComponent<SpriteRenderer>();

            rockCopperBroken = transform.Find("CopperBroken");
            rockCopperBrokenSprite = rockCopperBroken.GetComponent<SpriteRenderer>();

            // --- Silver ---
            chunkOfSilver = transform.Find("SilverChunk");
            chunkOfSilverSprite = chunkOfSilver.GetComponent<SpriteRenderer>();

            fullSilver = transform.Find("SilverFull");
            fullSilverSprite = fullSilver.GetComponent<SpriteRenderer>();

            rockSilverBroken = transform.Find("SilverBroken");
            rockSilverBrokenSprite = rockSilverBroken.GetComponent<SpriteRenderer>();

            // --- Cobalt ---
            chunkOfCobalt = transform.Find("CobaltChunk");
            chunkOfCobaltSprite = chunkOfCobalt.GetComponent<SpriteRenderer>();

            fullCobalt = transform.Find("CobaltFull");
            fullCobaltSprite = fullCobalt.GetComponent<SpriteRenderer>();

            rockCobaltBroken = transform.Find("CobaltBroken");
            rockCobaltBrokenSprite = rockCobaltBroken.GetComponent<SpriteRenderer>();

            // --- Uranium ---
            chunkOfUranium = transform.Find("UraniumChunk");
            chunkOfUraniumSprite = chunkOfUranium.GetComponent<SpriteRenderer>();

            fullUranium = transform.Find("UraniumFull");
            fullUraniumSprite = fullUranium.GetComponent<SpriteRenderer>();

            rockUraniumBroken = transform.Find("UraniumBroken");
            rockUraniumBrokenSprite = rockUraniumBroken.GetComponent<SpriteRenderer>();

            // --- Ismium ---
            chunkOfIsmium = transform.Find("IsmiumChunk");
            chunkOfIsmiumSprite = chunkOfIsmium.GetComponent<SpriteRenderer>();

            fullIsmium = transform.Find("IsmiumFull");
            fullIsmiumSprite = fullIsmium.GetComponent<SpriteRenderer>();

            rockIsmiumBroken = transform.Find("IsmiumBroken");
            rockIsmiumBrokenSprite = rockIsmiumBroken.GetComponent<SpriteRenderer>();

            // --- Iridium ---
            chunkOfIridium = transform.Find("IridiumChunk");
            chunkOfIridiumSprite = chunkOfIridium.GetComponent<SpriteRenderer>();

            fullIridium = transform.Find("IridiumFull");
            fullIridiumSprite = fullIridium.GetComponent<SpriteRenderer>();

            rockIridiumBroken = transform.Find("IridiumBroken");
            rockIridiumBrokenSprite = rockIridiumBroken.GetComponent<SpriteRenderer>();

            // --- Painite ---
            chunkOfPainite = transform.Find("PainiteChunk");
            chunkOfPainiteSprite = chunkOfPainite.GetComponent<SpriteRenderer>();

            fullPainite = transform.Find("PainiteFull");
            fullPainiteSprite = fullPainite.GetComponent<SpriteRenderer>();

            rockPainiteBroken = transform.Find("PainiteBroken");
            rockPainiteBrokenSprite = rockPainiteBroken.GetComponent<SpriteRenderer>();

            //Finding Scripts
            GameObject screenShakeObject = GameObject.Find("ScreenShake");
            screenShakeScript = screenShakeObject.GetComponent<ScreenShake>();

            GameObject levelObject = GameObject.Find("LevelMechanics");
            levelScript = levelObject.GetComponent<LevelMechanics>();

            GameObject artiFactObject = GameObject.Find("Artifacts");
            artifactsScript = artiFactObject.GetComponent<Artifacts>();

            GameObject setRockScreenObject = GameObject.Find("SetRockScreen");
            setRockScreenScript = setRockScreenObject.GetComponent<SetRockScreen>();

            GameObject oreScript = GameObject.Find("GoldAndOreMechanics");
            goldScript = oreScript.GetComponent<GoldAndOreMechanics>();
        }

        SpawnProjectiles.AddRock(gameObject);

        GameObject overlappingObject = GameObject.Find("OverlappingSounds");
        overlappingScript = overlappingObject.GetComponent<OverlappingSounds>();

        GameObject spawnProjectileObject = GameObject.Find("SpawnProjectiles");
        spawnProjectileScript = spawnProjectileObject.GetComponent<SpawnProjectiles>();
    }
    #endregion

    #region Set all off
    public void SetAllOff()
    {
        chest.gameObject.SetActive(false);
        chestOpen.gameObject.SetActive(false);
        goldenChest.gameObject.SetActive(false);
        goldenChestOpen.gameObject.SetActive(false);

        // Rock placeholders
        rock1.gameObject.SetActive(false);
        rock1Broken.gameObject.SetActive(false);

        // Gold
        fullGold.gameObject.SetActive(false);
        chunkOfGold.gameObject.SetActive(false);
        rockGoldBroken.gameObject.SetActive(false);

        // Copper
        fullCopper.gameObject.SetActive(false);
        chunkOfCopper.gameObject.SetActive(false);
        rockCopperBroken.gameObject.SetActive(false);

        // Silver
        fullSilver.gameObject.SetActive(false);
        chunkOfSilver.gameObject.SetActive(false);
        rockSilverBroken.gameObject.SetActive(false);

        // Cobalt
        fullCobalt.gameObject.SetActive(false);
        chunkOfCobalt.gameObject.SetActive(false);
        rockCobaltBroken.gameObject.SetActive(false);

        // Uranium
        fullUranium.gameObject.SetActive(false);
        chunkOfUranium.gameObject.SetActive(false);
        rockUraniumBroken.gameObject.SetActive(false);

        // Ismium
        fullIsmium.gameObject.SetActive(false);
        chunkOfIsmium.gameObject.SetActive(false);
        rockIsmiumBroken.gameObject.SetActive(false);

        // Iridium
        fullIridium.gameObject.SetActive(false);
        chunkOfIridium.gameObject.SetActive(false);
        rockIridiumBroken.gameObject.SetActive(false);

        // Painite
        fullPainite.gameObject.SetActive(false);
        chunkOfPainite.gameObject.SetActive(false);
        rockPainiteBroken.gameObject.SetActive(false);
    }
    #endregion

    #region OnEnable
    bool spawnChest, spawnGoldenChest;
    float halfRockHp;
    float bigRock2ThirdHP, bigRock3ThirdHP;

    private void OnEnable()
    {
        SetRockScreen.totalRocksOnScreen += 1;

        if (isBigRock == true)
        {
            bigRockFull.SetActive(true);
            bigRockBroken1.SetActive(false);
            bigRockBroken2.SetActive(false);
        }

        rockRigidbody.constraints = RigidbodyConstraints2D.None;

        spawnChest = false;
        spawnGoldenChest = false;

        isMinedWithHammer = false;
        isRockSpawnedIn = false;

        isRockBroken = false;

        if (isBigRock == false)
        {
            gameObject.transform.localScale = new Vector2(2.6f, 2.6f);
        }

        //rockCollider.enabled = true;
        //rockCollider.isTrigger = false;

        if (isBigRock == false)
        {
            SetAllOff();
        }

        if(LevelMechanics.talentLevel == 1) { rockHp = 10; }
        else
        {
            int talenIncrease = LevelMechanics.talentLevel * LevelMechanics.talentLevelHpIncrease;

            talenIncrease -= LevelMechanics.talentLevelHpIncrease;

            rockHp = 10 + talenIncrease;

            //Debug.Log(10 + talenIncrease);
        }

        if (Artifacts.horn_found)
        { 
            float hornStats = Artifacts.hornRockDecrease;
            if(LevelMechanics.archaeologist_chosen && Artifacts.rune_found) 
            {
                hornStats *= (1 + LevelMechanics.archeologistIncrease + Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { hornStats *= (1 + LevelMechanics.archeologistIncrease); }
                if (Artifacts.rune_found) { hornStats *= (1 + Artifacts.runeImproveAll); }
            }

            float totalStats = 1 - hornStats;

            rockHp *= totalStats;
        }

        halfRockHp = rockHp / 2;

        if (isBigRock == true)
        {
            rockRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            isRockSpawnedIn = true;

            originalScale = transform.localScale;

            xScaleTo = originalScale.x / 1.06f;
            yScaleTo = originalScale.y / 0.99f;

            rockHp = 3500;
            //rockHp = 150;

            bigRock2ThirdHP = rockHp / 3;
            bigRock2ThirdHP *= 2;

            bigRock3ThirdHP = bigRock2ThirdHP / 2;
        }
        else
        {
            StartCoroutine(WaitBeforeSpawningRocks());
        }
    }
    #endregion

    #region WaitBeforeSpawnRocks
    IEnumerator WaitBeforeSpawningRocks()
    {
        yield return new WaitForSeconds(0.22f);

        SetRandomRocks();
        //rockCollider.isTrigger = true;

        rockRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

        float randomSize = Random.Range(2.1f, 2.7f);

        StartCoroutine(ScaleRock(randomSize));
    }
    #endregion

    #region Set random rocks, chunks and full material rock

    bool isChunk = false;
    bool isFull = false;

    public void SetRandomRocks()
    {
        hitByFire = false;
        isChunk = false;
        isFull = false;

        isGoldChunk = false; isFullGold = false;
        isCopperChunk = false; isFullCopper = false;
        isSilverChunk = false; isFullSilver = false;
        isCobaltChunk = false; isFullCobalt = false;
        isUraniumChunk = false; isFullUranium = false;
        isIsmiumChunk = false; isFullIsmium = false;
        isIridiumChunk = false; isFullIridium = false;
        isPainiteChunk = false; isFullPainite = false;

        bool chosenRock = false;

        float totalRandom = 100f;
        float randomRockChance = Random.Range(0f, totalRandom);

        if(SkillTree.painiteSpawn_purchased == true)
        {
            if(randomRockChance < SkillTree.painiteRockChance && chosenRock == false)
            {
                AllStats.painiteChunkMined += 1;
                isChunk = true; chosenRock = true; isPainiteChunk = true;
                chunkOfPainite.gameObject.SetActive(true);
                currentChunkSprite = chunkOfPainiteSprite;
            }

            totalRandom -= SkillTree.painiteRockChance;
            randomRockChance = Random.Range(0f, totalRandom);

            if (randomRockChance < SkillTree.fullPainiteRockChance && chosenRock == false)
            {
                AllStats.fullPainiteMined += 1;
                isChunk = false; chosenRock = true; isFullPainite = true; isFull = true;
                currentActiveRock = fullPainite.gameObject; currentRockSprite = fullPainiteSprite;
                currentBrokenRock = rockPainiteBroken.gameObject; currentBrokenSprite = rockPainiteBrokenSprite;
            }

            totalRandom -= SkillTree.fullPainiteRockChance;
        }
        if (SkillTree.iridiumSpawn_purchased == true)
        {
            randomRockChance = Random.Range(0f, totalRandom);

            if (randomRockChance < SkillTree.iridiumRockChance && chosenRock == false)
            {
                AllStats.iridiumChunkMined += 1;
                isChunk = true; chosenRock = true; isIridiumChunk = true;
                chunkOfIridium.gameObject.SetActive(true);
                currentChunkSprite = chunkOfIridiumSprite;
            }

            totalRandom -= SkillTree.iridiumRockChance;
            randomRockChance = Random.Range(0f, totalRandom);

            if (randomRockChance < SkillTree.fullIridiumRockChance && chosenRock == false)
            {
                AllStats.fullIridiumMined += 1;
                isChunk = false; chosenRock = true; isFullIridium = true; isFull = true;
                currentActiveRock = fullIridium.gameObject; currentRockSprite = fullIridiumSprite;
                currentBrokenRock = rockIridiumBroken.gameObject; currentBrokenSprite = rockIridiumBrokenSprite;
            }

            totalRandom -= SkillTree.fullIridiumRockChance;
        }
        if (SkillTree.ismiumSpawn_purchased == true)
        {
            randomRockChance = Random.Range(0f, totalRandom);

            if (randomRockChance < SkillTree.ismiumRockChance && chosenRock == false)
            {
                AllStats.ismiumChunkMined += 1;
                isChunk = true; chosenRock = true; isIsmiumChunk = true;
                chunkOfIsmium.gameObject.SetActive(true);
                currentChunkSprite = chunkOfIsmiumSprite;
            }

            totalRandom -= SkillTree.ismiumRockChance;
            randomRockChance = Random.Range(0f, totalRandom);

            if (randomRockChance < SkillTree.fullIsmiumRockChance && chosenRock == false)
            {
                AllStats.fullIsmiumMined += 1;
                isChunk = false; chosenRock = true; isFullIsmium = true; isFull = true;
                currentActiveRock = fullIsmium.gameObject; currentRockSprite = fullIsmiumSprite;
                currentBrokenRock = rockIsmiumBroken.gameObject; currentBrokenSprite = rockIsmiumBrokenSprite;
            }

            totalRandom -= SkillTree.fullIsmiumRockChance;
        }
        if (SkillTree.uraniumSpawn_purchased == true)
        {
            randomRockChance = Random.Range(0f, totalRandom);

            if (randomRockChance < SkillTree.uraniumRockChance && chosenRock == false)
            {
                AllStats.uraniumChunkMined += 1;
                isChunk = true; chosenRock = true; isUraniumChunk = true;
                chunkOfUranium.gameObject.SetActive(true);
                currentChunkSprite = chunkOfUraniumSprite;
            }

            totalRandom -= SkillTree.uraniumRockChance;
            randomRockChance = Random.Range(0f, totalRandom);

            if (randomRockChance < SkillTree.fullUraniumRockChance && chosenRock == false)
            {
                AllStats.fullUraniumMined += 1;
                isChunk = false; chosenRock = true; isFullUranium = true; isFull = true;
                currentActiveRock = fullUranium.gameObject; currentRockSprite = fullUraniumSprite;
                currentBrokenRock = rockUraniumBroken.gameObject; currentBrokenSprite = rockUraniumBrokenSprite;
            }

            totalRandom -= SkillTree.fullUraniumRockChance;
        }
        if (SkillTree.cobaltSpawn_purchased == true)
        {
            randomRockChance = Random.Range(0f, totalRandom);

            if (randomRockChance < SkillTree.cobaltRockChance && chosenRock == false)
            {
                AllStats.cobaltChunkMined += 1;
                isChunk = true; chosenRock = true; isCobaltChunk = true;
                chunkOfCobalt.gameObject.SetActive(true);
                currentChunkSprite = chunkOfCobaltSprite;
            }

            totalRandom -= SkillTree.cobaltRockChance;
            randomRockChance = Random.Range(0f, totalRandom);

            if (randomRockChance < SkillTree.fullCobaltRockChance && chosenRock == false)
            {
                AllStats.fullCobaltMined += 1;
                isChunk = false; chosenRock = true; isFullCobalt = true; isFull = true;
                currentActiveRock = fullCobalt.gameObject; currentRockSprite = fullCobaltSprite;
                currentBrokenRock = rockCobaltBroken.gameObject; currentBrokenSprite = rockCobaltBrokenSprite;
            }

            totalRandom -= SkillTree.fullCobaltRockChance;
        }
        if (SkillTree.spawnIron_purchased == true)
        {
            randomRockChance = Random.Range(0f, totalRandom);

            if (randomRockChance < SkillTree.ironRockChance && chosenRock == false)
            {
                AllStats.ironChunkMined += 1;
                isChunk = true; chosenRock = true; isSilverChunk = true;
                chunkOfSilver.gameObject.SetActive(true);
                currentChunkSprite = chunkOfSilverSprite;
            }

            totalRandom -= SkillTree.ironRockChance;
            randomRockChance = Random.Range(0f, totalRandom);

            if (randomRockChance < SkillTree.fullIronRockChance && chosenRock == false)
            {
                AllStats.fullIronMined += 1;
                isChunk = false; chosenRock = true; isFullSilver = true; isFull = true;
                currentActiveRock = fullSilver.gameObject; currentRockSprite = fullSilverSprite;
                currentBrokenRock = rockSilverBroken.gameObject; currentBrokenSprite = rockSilverBrokenSprite;
            }

            totalRandom -= SkillTree.fullIronRockChance;
        }
        if (SkillTree.spawnCopper_purchased == true)
        {
            randomRockChance = Random.Range(0f, totalRandom);

            if (randomRockChance < SkillTree.copperRockChance && chosenRock == false)
            {
                AllStats.copperChunkMined += 1;
                isChunk = true; chosenRock = true; isCopperChunk = true;
                chunkOfCopper.gameObject.SetActive(true);
                currentChunkSprite = chunkOfCopperSprite;
            }

            totalRandom -= SkillTree.copperRockChance;
            randomRockChance = Random.Range(0, totalRandom);

            if (randomRockChance < SkillTree.fullCopperRockChance && chosenRock == false)
            {
                AllStats.fullCopperMined += 1;
                isChunk = false; chosenRock = true; isFullCopper = true; isFull = true;
                currentActiveRock = fullCopper.gameObject; currentRockSprite = fullCopperSprite;
                currentBrokenRock = rockCopperBroken.gameObject; currentBrokenSprite = rockCopperBrokenSprite;
            }

            totalRandom -= SkillTree.fullCopperRockChance;
        }
    
        if(chosenRock == false)
        {
            randomRockChance = Random.Range(0f, totalRandom);

            if (randomRockChance < SkillTree.goldRockChance && chosenRock == false)
            {
                AllStats.goldChunkMined += 1;
                isChunk = true; chosenRock = true; isGoldChunk = true;
                chunkOfGold.gameObject.SetActive(true);
                currentChunkSprite = chunkOfGoldSprite;
            }

            totalRandom -= SkillTree.goldRockChance;
            randomRockChance = Random.Range(0f, totalRandom);

            if (randomRockChance < SkillTree.fullGoldRockChance && chosenRock == false)
            {
                AllStats.fullGoldMined += 1;
                isChunk = false; chosenRock = true; isFullGold = true; isFull = true;
                currentActiveRock = fullGold.gameObject; currentRockSprite = fullGoldSprite;
                currentBrokenRock = rockGoldBroken.gameObject; currentBrokenSprite = rockGoldBrokenSprite;
            }
        }
      
        if(chosenRock == false || isChunk == true)
        {
            currentActiveRock = rock1.gameObject; currentRockSprite = rock1Sprite;
            currentBrokenRock = rock1Broken.gameObject; currentBrokenSprite = rock1BrokenSprite;
        }

        if (LevelMechanics.chests_chosen && spawnChest == false)
        {
            float randomChest = Random.Range(0f, 100f);
            if(randomChest < LevelMechanics.rockSpawnChance)
            {
                SetAllOff();
                spawnChest = true;
            }
        }
        if (LevelMechanics.goldenChests_chosen && spawnGoldenChest == false && SetRockScreen.spawnedGoldenChest == false && SetRockScreen.doSpawnGoldenChest == true)
        {
            int rockCount = SkillTree.totalRocksToSpawn / 2;
            float totalChance = 100f / rockCount;

            float randomChest = Random.Range(0f, 95f);
            if (randomChest < totalChance)
            {
                SetAllOff();
                spawnGoldenChest = true;
                SetRockScreen.spawnedGoldenChest = true;
            }
        }

        if (spawnChest == false && spawnGoldenChest == false)
        {
            if (isChunk) { StartCoroutine(SetZPos(currentChunkSprite, true)); }

            currentActiveRock.SetActive(true);
            StartCoroutine(SetZPos(currentRockSprite, false));
            currentBrokenRock.SetActive(false);
            StartCoroutine(SetZPos(currentBrokenSprite, false));
        }
        else if(spawnChest == true)
        {
            chest.gameObject.SetActive(true);
            StartCoroutine(SetZPos(chestSprite, false));
            StartCoroutine(SetZPos(chestOpenSprite, false));
        }
        else if (spawnGoldenChest == true)
        {
            goldenChest.gameObject.SetActive(true);
            StartCoroutine(SetZPos(goldenChestSprite, false));
            StartCoroutine(SetZPos(goldenChestOpenSprite, false));
        }
    }
    #endregion

    #region Set Z pos
    IEnumerator SetZPos(SpriteRenderer rendererObject, bool isChunks)
    {
        yield return new WaitForSeconds(0.04f);

        float posZ = gameObject.transform.localPosition.y;
        float posX = gameObject.transform.localPosition.x;

        if (isChunks)
        {
           // Vector3 chunkPos = rendererObject.gameObject.transform.localPosition;
           // rendererObject.sortingOrder = -(int)posZ;

           // rendererObject.gameObject.transform.localPosition = new Vector3(chunkPos.x, chunkPos.y, gameObject.transform.localPosition.z + 1000);
            rendererObject.sortingOrder = -(int)posZ + 1;
        }
        else
        {
            rendererObject.sortingOrder = -(int)posZ;
        }
    }
    #endregion

    #region Scale rock size
    IEnumerator ScaleRock(float scaleToSize)
    {
        float duration = 0.18f;
        float elapsedTime = 0f;

        Vector3 startScale = Vector3.zero;
        Vector3 endScale = Vector3.one * scaleToSize;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isRockSpawnedIn = true;

        transform.localScale = endScale;

        originalScale = transform.localScale;

        xScaleTo = originalScale.x / 1.15f;
        yScaleTo = originalScale.y / 0.85f;
    }
    #endregion

    #region OnTriggerEnter2D
    public static Vector2 beamHitPos, dynamiteHitPos;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        bool isDouble = false;
       
        if (SkillTree.allProjectileDoubleDamageChance_purchased)
        {
            isDouble = true;
        }

        float chanceIncrease = 1;
        bool isIncreaseChance = false;
        if (SkillTree.allProjectileTriggerChance_purchased)
        {
            isIncreaseChance = true;
        }
        if(isIncreaseChance == true) { chanceIncrease = 1 + (SkillTree.allProjcetileTriggerChance / 100); }

        if(collision.gameObject.layer == 6 || collision.gameObject.layer == 11) //Pickaxe
        {
            AllStats.pickaxeHits += 1;

            float currentTime = Time.time;

            if (spawnChest || spawnGoldenChest) { overlappingScript.PlaySound(3, currentTime); }
            else { overlappingScript.PlaySound(1, currentTime); }

            #region Chance to mine random rock
            if (SkillTree.chanceToMineRandomRock_1_purchased || SkillTree.chanceToMineRandomRock_2_purchased || SkillTree.chanceToMineRandomRock_3_purchased || SkillTree.chanceToMineRandomRock_4_purchased)
            {
                float randomSpawnPickaxe = Random.Range(0, 100);
                if (randomSpawnPickaxe < SkillTree.chanceToMineRandomRock)
                {
                    spawnProjectileScript.SelectRandomActiveRock(3);
                }
            }
            #endregion

            #region Lightning beam chance PH
            if (SkillTree.lightningBeamChancePH_1_purchased || SkillTree.lightningBeamChancePH_2_purchased)
            {
                int randomBeamChance = Random.Range(0, 100);
                if (randomBeamChance < (SkillTree.lightningTriggerChancePH * chanceIncrease))
                {
                    if(SpawnProjectiles.totalBeamsOnScreen < 17)
                    {
                        beamHitPos = collision.transform.position;
                        spawnProjectileScript.SelectRandomActiveRock(4);
                    }
                }
            }
            #endregion

            #region Dynamite chance
            if (SkillTree.dynamiteChance_1_purchased || SkillTree.dynamiteChance_2_purchased)
            {
                int randomDynamite = Random.Range(0, 100);
                if (randomDynamite < (SkillTree.dynamiteStickChance * chanceIncrease))
                {
                    if (SpawnProjectiles.totalDynamitesOnScreen < 20)
                    {
                        dynamiteHitPos = collision.transform.position;
                        spawnProjectileScript.SelectRandomActiveRock(5);
                    }
                }
            }
            #endregion

            if (Artifacts.cheese_found)
            {
                float random = Random.Range(0f, 100f);

                float increase = 1 + (LevelMechanics.archeologistIncrease + Artifacts.runeImproveAll);

                if (random < Artifacts.cheeseChance * increase) 
                {
                    if (SetRockScreen.isInMiningSession == true)
                    {
                        if (isBigRock == false) { SpawnMaterialPopUp(1); }
                    }
                }
            }

            if (LevelMechanics.goldenTouch_chosen)
            {
                if (SetRockScreen.isGoldenHand)
                {
                    int random = Random.Range(0,100);
                    if(random < LevelMechanics.midasTouchSpawnChance)
                    {
                        if(isBigRock == false) { if (SetRockScreen.isInMiningSession == true) { SpawnMaterialPopUp(1); } }
                    }
                }
            }

            float random2X = Random.Range(0, 100);

            float instaMineChance = 100 - SkillTree.instaMineChance;

            if (random2X < TheAnvil.current2XPowerChance + SkillTree.doubleDamageChance)
            {
                AllStats.doublePickaxePowerHits += 1;
                DamageRock(TheAnvil.currentMinePower * 2); 
            }
            else if (random2X > instaMineChance)
            {
                if (isBigRock == false)
                {
                    DamageRock(TheAnvil.currentMinePower * 10000); AllStats.instaMinePickaxeHits += 1;
                }
            }
            else
            {
                if (Artifacts.axe_found)
                {
                    float randomAxe = Random.Range(0f, 100f);

                    float doubleChanceIncrease = 1f + (Artifacts.runeImproveAll + LevelMechanics.archeologistIncrease);
                    float instaDecrese = 99f - (Artifacts.runeImproveAll + LevelMechanics.archeologistIncrease);

                    if (randomAxe < 2 * doubleChanceIncrease) { DamageRock(TheAnvil.currentMinePower * 2); AllStats.doublePickaxePowerHits += 1; }
                    else if (randomAxe > instaDecrese)
                    {
                        if(isBigRock == false)
                        {
                            DamageRock(TheAnvil.currentMinePower * 10000); AllStats.instaMinePickaxeHits += 1;
                        }
                    }
                    else { DamageRock(TheAnvil.currentMinePower); }
                }
                else
                {
                    DamageRock(TheAnvil.currentMinePower);
                }
            }
        }
        else if (collision.gameObject.layer == 7) //Hammer
        {
            if(isMinedWithHammer == false)
            {
                LevelMechanics.rocksMinedByHammer += 1;
                if(isBigRock == false) { DamageRock(TheAnvil.currentMinePower * 100000); }
                isMinedWithHammer = true;
            }
        }
        else
        {
            if (collision.gameObject.tag == "Beam_PH")
            {
                float totalDamage = (TheAnvil.currentMinePower * 2f) * SkillTree.lightningDamage;

                float doubleDamageChance = Random.Range(0, 100);
                if (isDouble) { if (doubleDamageChance < SkillTree.allProjectileDoubleDamageIncrease) { totalDamage *= 2; } }

                DamageRock(totalDamage);
            }
            else if (collision.gameObject.tag == "Beam_S")
            {
                float totalDamage = (TheAnvil.currentMinePower * 3) * SkillTree.lightningDamage;

                float doubleDamageChance = Random.Range(0, 100);
                if (isDouble) { if (doubleDamageChance < SkillTree.allProjectileDoubleDamageIncrease) { totalDamage *= 2; } }

                DamageRock(totalDamage);
            }
            else if (collision.gameObject.tag == "LightningSplash")
            {
                float totalDamage = (TheAnvil.currentMinePower * 2) * SkillTree.lightningDamage;

                totalDamage *= 0.15f;
                DamageRock(totalDamage);
            }
            else if (collision.gameObject.tag == "PlazmaBallCollider")
            {
                float totalDamage = (TheAnvil.currentMinePower * 0.75f) * SkillTree.plazmaBallTotalDamage;

                float doubleDamageChance = Random.Range(0, 100);
                if (isDouble) { if (doubleDamageChance < SkillTree.allProjectileDoubleDamageIncrease) { totalDamage *= 2; } }

                DamageRock(totalDamage);

                if (SkillTree.plazmaBallSpawnPickaxeChance_purchased)
                {
                    float randomPickaxe = Random.Range(0, 100);
                    if (randomPickaxe < SkillTree.plazmaBallChanceToSpawnPickaxe)
                    {
                        spawnProjectileScript.SelectRandomActiveRock(3);
                    }
                }
            }
            else if (collision.gameObject.tag == "Dynamite")
            {
                float totalDamage = (TheAnvil.currentMinePower * 1.2f) * SkillTree.explosionDamagage;

                float doubleDamageChance = Random.Range(0, 100);
                if (isDouble) { if (doubleDamageChance < SkillTree.allProjectileDoubleDamageIncrease) { totalDamage *= 2; } }

                DamageRock(totalDamage);
            }
            else if (collision.gameObject.tag == "Fire")
            {
                hitByFire = true;
                if(isBigRock == false) { DamageRock(TheAnvil.currentMinePower * 10000); }
            }
        }
    }
    #endregion

    bool hitByFire;

    #region DamageRock
    bool isRockBroken;

    public void DamageRock(float damage)
    {
        if(isRockSpawnedIn == false) { return; }

        //Debug.Log(damage);

        rockHp -= damage;

        if (isBigRock == false)
        {
            if (rockHp <= halfRockHp)
            {
                currentActiveRock.gameObject.SetActive(false);
                if (spawnChest == false && spawnGoldenChest == false) { currentBrokenRock.gameObject.SetActive(true); }
            }
        }
        else
        {
            if (rockHp <= bigRock3ThirdHP)
            {
                bigRockFull.SetActive(false);
                bigRockBroken1.SetActive(false);
                bigRockBroken2.SetActive(true);
            }
            else if (rockHp <= bigRock2ThirdHP)
            {
                bigRockFull.SetActive(false);
                bigRockBroken1.SetActive(true);
            }
        }

        if (rockHp <= 0)
        {
            if(isRockBroken == false)
            {
                Achievements.checkAch = true;

                isRockBroken = true;
                
                AllStats.totalRockMined += 1;
                SetRockScreen.totalRocksOnScreen -= 1;

                float currentTime = Time.time;
                overlappingScript.PlaySoundRockBreaking(1, currentTime);

                if (Artifacts.oneArtifactSpawned == true)
                {
                    Transform artifactChild = transform.Find("AllArtifacts");
                    if (artifactChild != null)
                    {
                        artifactChild.SetParent(originalArtifactParent.transform);
                        Artifacts.minedRockWithArtifact = true;
                        Artifacts.oneArtifactMined = true;

                        if (Artifacts.horn_spawned) { Artifacts.horn_found = true; }
                        if (Artifacts.ancientDevice_spawned) { Artifacts.ancientDevice_found = true; }
                        if (Artifacts.bone_spawned) 
                        { 
                            Artifacts.bone_found = true;
                            SkillTree.improvedPickaxeStrength += Artifacts.bonePickaxeIncrease;
                            SkillTree.reducePickaxeMineTime -= Artifacts.bonePickaxeIncrease;
                        }
                        if (Artifacts.meteorieOre_spawned) 
                        { 
                            Artifacts.meteorieOre_found = true;

                            float rockIncrease = 1 + Artifacts.meteoriteRockSpawnIncrease;

                            SkillTree.fullGoldRockChance = SkillTree.fullGoldRockChance * rockIncrease;
                            SkillTree.fullCopperRockChance = SkillTree.fullCopperRockChance * rockIncrease;
                            SkillTree.fullIronRockChance = SkillTree.fullIronRockChance * rockIncrease;
                            SkillTree.fullCobaltRockChance = SkillTree.fullCobaltRockChance * rockIncrease;
                            SkillTree.fullUraniumRockChance = SkillTree.fullUraniumRockChance * rockIncrease;
                            SkillTree.fullIsmiumRockChance = SkillTree.fullIsmiumRockChance * rockIncrease;
                            SkillTree.fullIridiumRockChance = SkillTree.fullIridiumRockChance * rockIncrease;
                            SkillTree.fullPainiteRockChance = SkillTree.fullPainiteRockChance * rockIncrease;
                        }
                        if (Artifacts.book_spawned) { Artifacts.book_found = true; }
                        if (Artifacts.goldStack_spawned) { Artifacts.goldStack_found = true; }
                        if (Artifacts.goldRing_spawned) { Artifacts.goldRing_found = true; }
                        if (Artifacts.purpleRing_spawned) { Artifacts.purpleRing_found = true; }
                        if (Artifacts.ancientDice_spawned) { Artifacts.ancientDice_found = true; }
                        if (Artifacts.cheese_spawned) { Artifacts.cheese_found = true; }
                        if (Artifacts.wolfClaw_spawned) { Artifacts.wolfClaw_found = true; }
                        if (Artifacts.axe_spawned) { Artifacts.axe_found = true; }
                        if (Artifacts.rune_spawned)
                        {
                            Artifacts.rune_found = true; 
                            Artifacts.runeImproveAll = 0.05f;

                            SkillTree.improvedPickaxeStrength += 0.02f * Artifacts.runeImproveAll;
                            SkillTree.reducePickaxeMineTime -= 0.02f * Artifacts.runeImproveAll;

                            float spawnChanceIncrease = (1 + (0.03f * Artifacts.runeImproveAll));

                            SkillTree.fullGoldRockChance = SkillTree.fullGoldRockChance * spawnChanceIncrease;
                            SkillTree.fullCopperRockChance = SkillTree.fullCopperRockChance * spawnChanceIncrease;
                            SkillTree.fullIronRockChance = SkillTree.fullIronRockChance * spawnChanceIncrease;
                            SkillTree.fullCobaltRockChance = SkillTree.fullCobaltRockChance * spawnChanceIncrease;
                            SkillTree.fullUraniumRockChance = SkillTree.fullUraniumRockChance * spawnChanceIncrease;
                            SkillTree.fullIsmiumRockChance = SkillTree.fullIsmiumRockChance * spawnChanceIncrease;
                            SkillTree.fullIridiumRockChance = SkillTree.fullIridiumRockChance * spawnChanceIncrease;
                            SkillTree.fullPainiteRockChance = SkillTree.fullPainiteRockChance * spawnChanceIncrease;
                        }
                        if (Artifacts.skull_spawned) 
                        { 
                            Artifacts.skull_found = true;
                            SkillTree.totalRocksToSpawn += 10;
                        }

                        artifactsScript.CheckFoundArtifacts();
                    }
                }

                if(isBigRock == false)
                {
                    if (SkillTree.chanceAdd1SecondEveryRockMined_purchased)
                    {
                        float random = Random.Range(0f, 100f);
                        if (random < SkillTree.chanceToAdd1SecEveryRockMined)
                        {
                            SetRockScreen.currentTime -= 1;
                            //Debug.Log("Rock mined +1 sec");
                        }
                    }

                    if (SkillTree.spawnRockEveryXrock_1_purchased || SkillTree.spawnRockEveryXrock_2_purchased || SkillTree.spawnRockEveryXrock_3_purchased)
                    {
                        SkillTree.rocksMinedBeforeSpawn += 1;
                        if (SkillTree.rocksMinedBeforeSpawn >= SkillTree.spawnRockEveryXRock)
                        {
                            SkillTree.rocksMinedBeforeSpawn = 0;
                            SpawnRock();
                        }
                    }

                    float randomSpawnRock = Random.Range(0, 100);
                    if (randomSpawnRock < SkillTree.chanceToSpawnRockWhenMined)
                    {
                        SpawnRock();
                    }

                }

                rockRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

                if (spawnChest == false && spawnGoldenChest == false)
                {
                    RockBreakParticle();

                    if(isBigRock == false)
                    {
                        levelScript.GiveXP();
                        screenShakeScript.ShakeTheScreen();

                        if (isChunk == true)
                        {
                            if (SetRockScreen.isInMiningSession == true || hitByFire == true) { SpawnMaterialPopUp(SkillTree.materialsFromChunkRocks); }
                        }
                        else if (isFull == true)
                        {
                            if (SetRockScreen.isInMiningSession == true || hitByFire == true) { SpawnMaterialPopUp(SkillTree.materialsFromFullRocks); }
                        }
                        else
                        {
                            if (SetRockScreen.isInMiningSession == true || hitByFire == true) { SpawnMaterialPopUp(1); }
                        }
                    }

                    if(isBigRock == false)
                    {
                        ObjectPool.instance.ReturnRockFromPool(gameObject);
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                }
                else 
                {
                    OpenChestAndSpawnLoot();
                }
            }
        }
        else
        {
            if (gameObject.activeInHierarchy == true)
            {
                if(isBigRock == false)
                {
                    if (rockScaleCoroutine != null) { StopCoroutine(rockScaleCoroutine); rockScaleCoroutine = StartCoroutine(ScaleXY()); }
                    else { rockScaleCoroutine = StartCoroutine(ScaleXY()); }
                }
                else
                {
                    if (rockScaleCoroutineBIG != null) { StopCoroutine(rockScaleCoroutineBIG); rockScaleCoroutineBIG = StartCoroutine(ScaleXYBIGROCK()); }
                    else { rockScaleCoroutineBIG = StartCoroutine(ScaleXYBIGROCK()); }
                }
            }
        }
    }

    public void SpawnRock()
    {
        if(SetRockScreen.isInMiningSession == true)
        {
            int randomWaveNumber = Random.Range(0, 14);
            SetRockScreen.tileWaveNumber = randomWaveNumber;
            setRockScreenScript.SpawnRockCount(1);
        }
    }
    #endregion

    #region Open chest and spanw loot
    public void OpenChestAndSpawnLoot()
    {
        RockBreakParticle();
        int totalMaterials = 0;
        if(spawnChest == true) { totalMaterials = LevelMechanics.totalChestMaterials; AllStats.chestsOpened += 1; }
        if(spawnGoldenChest == true) { totalMaterials = LevelMechanics.totalGoldenChestMaterials; AllStats.goldenChestsOpened += 1; }

        //Debug.Log(totalMaterials);

        for (int i = 0; i < totalMaterials; i++)
        {
            GameObject text = ObjectPool.instance.GetTextFromPool();

            int totalSpawning = SkillTree.totalMaterialRocksSpawning;

            int random = Random.Range(1, (totalSpawning + 1));
            if(random == 1) { text.gameObject.transform.localScale = new Vector2(0.25f, 0.25f); }
            if (random == 2) { text.gameObject.transform.localScale = new Vector2(0.35f, 0.35f); }
            if (random == 3) { text.gameObject.transform.localScale = new Vector2(0.45f, 0.45f); }
            if (random == 4) { text.gameObject.transform.localScale = new Vector2(0.55f, 0.55f); }
            if (random == 5) { text.gameObject.transform.localScale = new Vector2(0.65f, 0.65f); }
            if (random == 6) { text.gameObject.transform.localScale = new Vector2(0.75f, 0.75f); }
            if (random == 7) { text.gameObject.transform.localScale = new Vector2(0.85f, 0.85f); }
            if (random == 8) { text.gameObject.transform.localScale = new Vector2(0.95f, 0.95f); }

            float randomOffSet = Random.Range(-0.5f, 0.5f);
            float randomYOffset = Random.Range(0.4f, 0.6f);

            text.gameObject.transform.position = new Vector2(gameObject.transform.position.x + randomOffSet, gameObject.transform.position.y + randomYOffset);
        }

        if (isBigRock == false)
        {
            ObjectPool.instance.ReturnRockFromPool(gameObject);
        }
    }
    #endregion

    #region Spawn materials pop up
    public void SpawnMaterialPopUp(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (MineMaterialMechanics.totalTextsOnScreen < 430)
            {
                GameObject text = ObjectPool.instance.GetTextFromPool();

                if (isGoldChunk || isFullGold == true) { text.gameObject.transform.localScale = new Vector2(0.25f, 0.25f); }
                else if (isCopperChunk || isFullCopper == true) { text.gameObject.transform.localScale = new Vector2(0.35f, 0.35f); }
                else if (isSilverChunk || isFullSilver == true) { text.gameObject.transform.localScale = new Vector2(0.45f, 0.45f); }
                else if (isCobaltChunk || isFullCobalt == true) { text.gameObject.transform.localScale = new Vector2(0.55f, 0.55f); }
                else if (isUraniumChunk || isFullUranium == true) { text.gameObject.transform.localScale = new Vector2(0.65f, 0.65f); }
                else if (isIsmiumChunk || isFullIsmium == true) { text.gameObject.transform.localScale = new Vector2(0.75f, 0.75f); }
                else if (isIridiumChunk || isFullIridium == true) { text.gameObject.transform.localScale = new Vector2(0.85f, 0.85f); }
                else if (isPainiteChunk || isFullPainite == true) { text.gameObject.transform.localScale = new Vector2(0.95f, 0.95f); }
                else
                {
                    text.gameObject.transform.localScale = new Vector2(0.25f, 0.25f);
                }

                float randomOffSet = Random.Range(-0.5f, 0.5f);
                float randomYOffset = Random.Range(0.4f, 0.6f);

                text.gameObject.transform.position = new Vector2(gameObject.transform.position.x + randomOffSet, gameObject.transform.position.y + randomYOffset);
            }
            else
            {
                if (isGoldChunk || isFullGold == true) { goldScript.GiveMaterialOre(1, 1); }
                else if (isCopperChunk || isFullCopper == true) { goldScript.GiveMaterialOre(2, 1); }
                else if (isSilverChunk || isFullSilver == true) { goldScript.GiveMaterialOre(3, 1); }
                else if (isCobaltChunk || isFullCobalt == true) { goldScript.GiveMaterialOre(4, 1); }
                else if (isUraniumChunk || isFullUranium == true) { goldScript.GiveMaterialOre(5, 1); }
                else if (isIsmiumChunk || isFullIsmium == true) { goldScript.GiveMaterialOre(6, 1); }
                else if (isIridiumChunk || isFullIridium == true) { goldScript.GiveMaterialOre(7, 1); }
                else if (isPainiteChunk || isFullPainite == true) { goldScript.GiveMaterialOre(8, 1); }
                else
                {
                    goldScript.GiveMaterialOre(1, 1);
                }
            }
        }
    }
    #endregion

    #region Spawn rock break particle
    public void RockBreakParticle()
    {
        GameObject rockParticle = ObjectPool.instance.GetRockParticleFromPool();
        rockParticle.transform.position = gameObject.transform.position;

        if(isBigRock == true) { rockParticle.transform.localScale = new Vector2(10f, 10f); TheEnding.bigRockBroken = true; }
        else { rockParticle.transform.localScale = new Vector2(2.6f, 2.6f); }
    }
    #endregion

    #region Rock Damage scale
    private Vector3 originalScale;
    private float duration = 0.2f;
    public float xScaleTo, yScaleTo;
    public Coroutine rockScaleCoroutine;

    private IEnumerator ScaleXY()
    {
        float halfDuration = duration / 2f;
        float elapsed = 0f;

        Vector3 targetScale = new Vector3(xScaleTo, yScaleTo, originalScale.z);

        // First half: scale to target
        while (elapsed < halfDuration)
        {
            float t = elapsed / halfDuration;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        // Second half: scale back to original
        elapsed = 0f;
        while (elapsed < halfDuration)
        {
            float t = elapsed / halfDuration;
            transform.localScale = Vector3.Lerp(targetScale, originalScale, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale;

        rockScaleCoroutine = null;
    }
    #endregion

    #region Rock Damage scale
    public Coroutine rockScaleCoroutineBIG;

    private IEnumerator ScaleXYBIGROCK()
    {
        float halfDuration = duration / 1.4f;
        float elapsed = 0f;

        Vector3 targetScale = new Vector3(xScaleTo, yScaleTo, originalScale.z);

        // First half: scale to target
        while (elapsed < halfDuration)
        {
            float t = elapsed / halfDuration;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        // Second half: scale back to original
        elapsed = 0f;
        while (elapsed < halfDuration)
        {
            float t = elapsed / halfDuration;
            transform.localScale = Vector3.Lerp(targetScale, originalScale, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale;

        rockScaleCoroutine = null;
    }
    #endregion

    #region Trigger flash damage
    [SerializeField] private Color _flashColor = Color.white;
    [SerializeField] private float _flashTime = 0.2f;

    public SpriteRenderer[] _spriteRenderers;
    public Material[] _materials;

    private void SetMaterials()
    {
        _materials = new Material[_spriteRenderers.Length];

        for (int i = 0; i < _spriteRenderers.Length; i++)
        {
            _materials[i] = _spriteRenderers[i].material;
        }
    }

    private Coroutine flashCoroutine;

    public void ApplyFlash()
    {
        return;
        if(gameObject.activeInHierarchy == true)
        {
            if (flashCoroutine == null) { flashCoroutine = StartCoroutine(TriggerWhiteFlash()); }
        }
    }

    IEnumerator TriggerWhiteFlash()
    {
        SetFlahsColor();

        float currentFlashAmount = 0;
        float elaspedTime = 0;

        while (elaspedTime < _flashTime)
        {
            elaspedTime += Time.deltaTime;

            currentFlashAmount = Mathf.Lerp(1, 0f, (elaspedTime / _flashTime));
            SetFlashAmount(currentFlashAmount);

            yield return null;
        }

        flashCoroutine = null;
    }

    private void SetFlahsColor()
    {
        for (int i = 0; i < _materials.Length; i++)
        {
            _materials[i].SetColor("_FlashColor", _flashColor);
        }   
    }

    private void SetFlashAmount(float amount)
    {
        for (int i = 0; i < _materials.Length; i++)
        {
            _materials[i].SetFloat("_FlashAmount", amount);
        }
    }
    #endregion

   
}
