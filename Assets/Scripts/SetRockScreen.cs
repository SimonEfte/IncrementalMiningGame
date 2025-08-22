using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetRockScreen : MonoBehaviour
{
    public GoldAndOreMechanics goldAndOreScript;
    public MainMenu mainMenuScript;
    public SpawnRocks spawnRocksScript;
    public SpawnProjectiles spawnProjectilesScript;
    public Artifacts artifactsScript;
    public TheAnvil anvilScript;
    public AudioManager audioManager;
    public Tutorial tutorialScript;
    public TheEnding endingScript;
    public Achievements achScript;

    public GameObject dustParticleParent;
    public GameObject goldenHand, normalCursorHand;
    public static bool isGoldenHand;

    public static float mineTotalTime;

    public static float startTileZPos;

    public GameObject[] tileRow;

    public Vector2 startPos;
    public int timesSpawned, totalTimesSpawned, parentFilled;
    public float tileZPos;

    public static int tileWaveNumber;

    public GameObject handCollider, handCollider_actualCollider, hexagonCollider_actualCollider, squareCollider_actualCollider;

    public static float rockZPos;

    public static bool isInMiningSession;

    public GameObject allArtifactsParent;
    public GameObject potion_materialsWorthMore, potion_pickaxeStats, potion_xp, potion_doubleMaterialAndXPChance;

    public static bool isPotionMaterialWorthMore, isPotionPickaxeStats, isPotionXp, isPotionDoubleMaterialAndXPChance;
    public static float potionMaterialWorthMore_increase, potionPickaxeStats_increase, potionXp_increase, potionDoubleChance_increase;

    public static bool spawnedGoldenChest, doSpawnGoldenChest;

    public GameObject circleColl, squareColl, hexagonColl;
    public Camera mainCamera;

    public static int totalRocksOnScreen;
    public static int grassLayer;

    public static bool oresPopedUp;


    private void Awake()
    {
        circleObject.transform.localScale = new Vector2(24, 24);
        circleObject.SetActive(true);

        grassLayer = -346;

        mainCamera = Camera.main;

        rockZPos = 100;

        tileZPos = 0;
        startPos = new Vector2(1160, 330);

        StartCoroutine(SetAllTiles());
    }

    private void Start()
    {
        handCollider.SetActive(false);
        StartCoroutine(Wait1Sec());
    }

    private void Update()
    {
        if(MobileAndTesting.isMobile == true)
        {
            normalCursorHand.SetActive(false);
                
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log(SpawnProjectiles.totalDynamitesOnScreen);
        }

        Vector3 worldPosition = Vector3.zero;

        if (MobileAndTesting.isMobile == false)
        {
            Vector3 mouseScreenPosition = Input.mousePosition;

            // Convert the screen position to world position
            worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(
               mouseScreenPosition.x,
               mouseScreenPosition.y,
               mainCamera.nearClipPlane // Or a fixed distance from the camera
           ));
        }
        else
        {
            // Mobile input using touch
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchScreenPosition = touch.position;
                worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(
                    touchScreenPosition.x,
                    touchScreenPosition.y,
                    mainCamera.nearClipPlane + 10f
                ));
            }
            else
            {
                return; // No touch input detected
            }
        }

        float scaleIncrease = 1 + LevelMechanics.inflationBurstIncrease;

        handCollider.transform.position = worldPosition;

        if(LevelMechanics.isDoubleAreaSize == true && SkillTree.increaseAndDecreaseMinignErea_purchased == false)
        {
            handCollider_actualCollider.transform.localScale = new Vector2(TheAnvil.currentColliderSize * scaleIncrease, TheAnvil.currentColliderSize * scaleIncrease);
            hexagonCollider_actualCollider.transform.localScale = new Vector2(TheAnvil.currentColliderSize * scaleIncrease, TheAnvil.currentColliderSize * scaleIncrease);
            squareCollider_actualCollider.transform.localScale = new Vector2(TheAnvil.currentColliderSize * scaleIncrease, TheAnvil.currentColliderSize * scaleIncrease);
        }
        else if(LevelMechanics.isDoubleAreaSize == false && SkillTree.increaseAndDecreaseMinignErea_purchased == false)
        {
            handCollider_actualCollider.transform.localScale = new Vector2(TheAnvil.currentColliderSize, TheAnvil.currentColliderSize);
            hexagonCollider_actualCollider.transform.localScale = new Vector2(TheAnvil.currentColliderSize, TheAnvil.currentColliderSize);
            squareCollider_actualCollider.transform.localScale = new Vector2(TheAnvil.currentColliderSize, TheAnvil.currentColliderSize);
        }
        else if(LevelMechanics.isDoubleAreaSize == false && SkillTree.increaseAndDecreaseMinignErea_purchased == true)
        {
            handCollider_actualCollider.transform.localScale = new Vector2(TheAnvil.currentColliderSize, TheAnvil.currentColliderSize);
            hexagonCollider_actualCollider.transform.localScale = new Vector2(TheAnvil.currentColliderSize, TheAnvil.currentColliderSize);
            squareCollider_actualCollider.transform.localScale = new Vector2(TheAnvil.currentColliderSize, TheAnvil.currentColliderSize);
        }
        else
        {
            //Do nothing
        }
    }

    #region SetAllTiles
    IEnumerator SetAllTiles()
    {
        int rowNumber = 13;

        float firstXPos = 600;
        float firstYPos = -293;

        for (int i = 0; i < 14; i++)
        {
            tileRow[rowNumber].transform.localScale = new Vector2(0.45562f, 0.45562f);

            Vector2 firstPos = new Vector2(firstXPos, firstYPos);
            tileRow[rowNumber].transform.localPosition = firstPos;
            rowNumber -= 1;

            firstXPos -= 70;
            firstYPos += 34.6f; 
        }

        yield return new WaitForSeconds(0.25f);

        while (totalTimesSpawned < 196)
        {
            GameObject tile = ObjectPool.instance.GetTileFromPool();

            tile.transform.SetParent(tileRow[parentFilled].transform);
            tile.transform.localScale = new Vector2(61.5f,61.5f);

            tileZPos -= 0.1f;
            Vector3 spawnPos = new Vector3(startPos.x, startPos.y, tileZPos);
            tile.transform.localPosition = spawnPos;

            float newXPos = startPos.x - 153.5f;
            float newYPos = startPos.y - 76.4f;

            startPos = new Vector2(newXPos, newYPos);

            totalTimesSpawned += 1;
            timesSpawned += 1;

            if(timesSpawned == 14)
            {
                timesSpawned = 0;
                parentFilled += 1;
                startPos = new Vector2(1160, 330);
            }

            //yield return null;
        }

        yield return new WaitForSeconds(0.1f);

       // Debug.Log("All tiles spawned");
       
        StartCoroutine(ScaleCircleCoroutine(false));

        if(MobileAndTesting.isTesting == true) { StartCoroutine(TileWaveAnim()); }
    }
    #endregion

    #region TileWaveAnim
    public void StartWaveTutorialBtn()
    {
        StartCoroutine(TileWaveAnim());
    }

    bool isTimeStarted;

    IEnumerator TileWaveAnim()
    {
        oresPopedUp = false;
        SpawnProjectiles.totalDynamitesOnScreen = 0;
        SpawnProjectiles.totalBeamsOnScreen = 0;
        totalRocksOnScreen = 0;
        LevelMechanics.xpThisRound = 0;

        spawnedGoldenChest = false;
        doSpawnGoldenChest = false;

        if (LevelMechanics.goldenChests_chosen)
        {
            int random = Random.Range(0,2);
            if(random == 0) { doSpawnGoldenChest = true;  }
        }

        Artifacts.horn_spawned = false; Artifacts.ancientDevice_spawned = false; Artifacts.bone_spawned = false; Artifacts.meteorieOre_spawned = false; Artifacts.book_spawned = false; Artifacts.goldStack_spawned = false; Artifacts.goldRing_spawned = false; Artifacts.purpleRing_spawned = false; Artifacts.ancientDice_spawned = false; Artifacts.cheese_spawned = false; Artifacts.wolfClaw_spawned = false; Artifacts.axe_spawned = false; Artifacts.rune_spawned = false; Artifacts.skull_spawned = false;

        Artifacts.oneArtifactSpawned = false;
        Artifacts.minedRockWithArtifact = false;
        Artifacts.oneArtifactMined = false;

        if(SkillTree.mineSessionTime >= 10) { timerText.text = "" + SkillTree.mineSessionTime.ToString("F0") + ":00"; }
        else { timerText.text = "0" + SkillTree.mineSessionTime.ToString("F0") + ":00"; }
       
        timerText.color = Color.white;
        isTimeStarted = false;
        rocksLeftAdded = 0;

        timeLeft = SkillTree.mineSessionTime;

        for (int i = 0; i < tileRow.Length; i++)
        {
            StartCoroutine(TileUpAndDown(tileRow[i].transform));
            yield return new WaitForSeconds(0.065f);
        }

        //StartCoroutine(SpawnRocks());
    }

    int rocksLeftAdded;

    IEnumerator TileUpAndDown(Transform tileTransform)
    {
        float rockDividedByTiles = (float)SkillTree.totalRocksToSpawn / 14;

        float decimalPart = rockDividedByTiles - Mathf.Floor(rockDividedByTiles);

        int rocksLeft = SkillTree.totalRocksToSpawn % 14;

        //Debug.Log(rocksLeft);
        //Debug.Log(decimalPart);
        //Debug.Log((int)rockDividedByTiles);

        SpawnRockCount((int)rockDividedByTiles);

        float random = Random.Range(0f, 1f);
        if(random <= decimalPart) 
        {
            if (rocksLeftAdded < rocksLeft) 
            {
                SpawnRockCount(1);
            }
            rocksLeftAdded += 1;
        }

        if (tileWaveNumber == 13)
        {
            if (rocksLeftAdded < rocksLeft)
            {
                SpawnRockCount(rocksLeft - rocksLeftAdded);
            }
        }

        tileWaveNumber += 1;

        Vector3 startPos = tileTransform.localPosition;
        Vector3 upPos = startPos + new Vector3(0, 63f, 0);
        float duration = 0.21f;
        float halfDuration = duration / 2f;
        float t = 0;

        audioManager.Play("Wave");

        // Move up
        while (t < halfDuration)
        {
            t += Time.deltaTime;
            float normalizedTime = t / halfDuration;
            tileTransform.localPosition = Vector3.Lerp(startPos, upPos, normalizedTime);
            yield return null;
        }

        // Move down
        t = 0;
        while (t < halfDuration)
        {
            t += Time.deltaTime;
            float normalizedTime = t / halfDuration;
            tileTransform.localPosition = Vector3.Lerp(upPos, startPos, normalizedTime);
            yield return null;
        }

        tileTransform.localPosition = startPos;

        if(tileWaveNumber == 14 && isTimeStarted == false)
        {
            isTimeStarted = true;
            StartCoroutine(StartTimer());
        }
    }
    #endregion

    #region SpawnRocks
    public static bool noLongerCheckCollision;
    public Transform[] rockParent;

    public void SpawnRockCount(int count)
    {
        if(isInEnding == true) { return; }
        if(totalRocksOnScreen > 450) { return; }

        for (int i = 0; i < count; i++)
        {
            AllStats.totalRocksSpawned += 1;

            GameObject rock = ObjectPool.instance.GetRockFromPool();

            //Debug.Log(rockParent[tileWaveNumber].name);

            rock.transform.SetParent(rockParent[tileWaveNumber]);
            Vector2 pos = new Vector2(Random.Range(77, -77), Random.Range(-1.5f, 1.5f));
            rock.transform.localPosition = pos;
            rock.transform.SetParent(originalRockParent);

            float posX = rock.transform.localPosition.x;
            float posY = rock.transform.localPosition.y;

            rock.transform.localPosition = new Vector3(posX, posY, posY);

            int randomYRotation = Random.Range(1,3);
            if(randomYRotation == 1) { rock.transform.rotation = Quaternion.Euler(0, 180f, 0); }
            else if (randomYRotation == 2) { rock.transform.rotation = Quaternion.Euler(0, 0, 0); }

            totalRocksSpawned += 1;

            if(Artifacts.oneArtifactSpawned == false)
            {
                artifactsScript.ArtifactDropChances();
            }
            //Debug.Log(totalRocksSpawned);
        }
    }

    int totalRocksSpawned = 0;
    #endregion

    #region Start timer
    public Image timerLine;
    public TextMeshProUGUI timerText;

    public static float timeLeft;
    public static float currentTime;

    IEnumerator StartTimer()
    {
        if (LevelMechanics.potionDrinker_chosen)
        {
            if (LevelMechanics.potionChugger_chosen == false) { AllStats.potionsDrank += 1; }
        }
        if (LevelMechanics.potionChugger_chosen)
        {
            AllStats.potionsDrank += 4;
        }

        AllStats.miningSessions += 1;

        LevelMechanics.didLevelUp = false;
        LevelMechanics.didLevelUpTotalTalentPoints = 0;

        StartCoroutine(SpawnMineOrTimesUpText(true));

        yield return new WaitForSeconds(1f);
        //This is when the mining session actually starts!
      
        isInMiningSession = true;
        Cursor.visible = false;

        handCollider.SetActive(true);

        if (MobileAndTesting.isMobile == true)
        {
            handCollider.transform.localPosition = new Vector2(-1439, 900);
        }

        if (SkillTree.lightningBeamChanceS_1_purchased || SkillTree.lightningBeamChanceS_2_purchased)
        {
            spawnProjectilesScript.SpawnLightningS();
        }

        if (SkillTree.spawnPickaxeEverySecond_1_purchased || SkillTree.spawnPickaxeEverySecond_2_purchased || SkillTree.spawnPickaxeEverySecond_3_purchased)
        {
            spawnProjectilesScript.SpawnPickaxe();
        }

        if (SkillTree.spawnXRockEveryXSecond_1_purchased || SkillTree.spawnXRockEveryXSecond_2_purchased || SkillTree.spawnXRockEveryXSecond_3_purchased)
        {
            SpawnRocks.spawnRockCoroutine = null;
            spawnRocksScript.SpawnRockXSecond();
        }

        if (SkillTree.plazmaBallSpawn_1_purchased || SkillTree.plazmaBallSpawn_2_purchased)
        {
            spawnProjectilesScript.SpawnPlazmaBalls();
        }

        if (Artifacts.ancientDice_found) 
        {
            SpawnRocks.ancientDiceRockSpawn = null;
            spawnRocksScript.SpawnRockDice(); 
        }

        currentTime = 0;
        float reachTime = SkillTree.mineSessionTime;

        float oneSecondTimer = 0f;

        while (currentTime < reachTime)
        {
            float remainingTime = reachTime - currentTime;

            if (remainingTime < 3f)
                timerText.color = Color.red;
            else
                timerText.color = Color.white;

            currentTime += Time.deltaTime;

            remainingTime = Mathf.Max(0f, reachTime - currentTime);
            timeLeft = remainingTime;

            int wholeSeconds = (int)remainingTime;
            int fraction = (int)((remainingTime - wholeSeconds) * 100);

            timerText.text = string.Format("{0:00}:{1:00}", wholeSeconds, fraction);

            oneSecondTimer += Time.deltaTime;

            if (oneSecondTimer >= 1f)
            {
                AllStats.timeSpentMining += 1;
                oneSecondTimer = 0f;
            }

            yield return null;
        }

        AllStats.timeSpentMining += 1;

        Cursor.visible = true;

        timerText.text = "00:00";
        ResetTimeISUpStuff();

        StartCoroutine(SpawnMineOrTimesUpText(false));
        isInMiningSession = false;

        if (SkillTree.spawnXRockEveryXSecond_1_purchased || SkillTree.spawnXRockEveryXSecond_2_purchased || SkillTree.spawnXRockEveryXSecond_3_purchased)
        {
            if(SpawnRocks.spawnRockCoroutine != null) { spawnRocksScript.StopCoroutine(SpawnRocks.spawnRockCoroutine); }
        }

        if (Artifacts.ancientDice_found)
        {
            if(SpawnRocks.ancientDiceRockSpawn != null)
            {
                spawnRocksScript.StopCoroutine(SpawnRocks.ancientDiceRockSpawn);
                SpawnRocks.ancientDiceRockSpawn = null;
            }
        }
    }

    IEnumerator Wait1Sec()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if(isInMiningSession == true)
            {
                if (SkillTree.chanceToAdd1SecondEverySecond_purchased)
                {
                    float random = Random.Range(0, 100);
                    if (random < SkillTree.chanceToAdd1SecEverySec)
                    {
                        currentTime -= 1;
                    }
                }
            }
        }
    }
    #endregion

    #region Spawn mine and times up text
    public Animation textFrameAnim;
    public TextMeshProUGUI textFrameText;

    IEnumerator SpawnMineOrTimesUpText(bool miningStarted)
    {
        if (miningStarted == true)
        { 
            textFrameText.text = $"<bounce>{LocalizationScript.startMining}</bounce>";
            audioManager.Play("StartMining");

            if (SkillTree.lightningBeamChanceS_1_purchased || SkillTree.lightningBeamChanceS_2_purchased)
            {
                if(isInEnding == true)
                {
                    spawnProjectilesScript.SpawnLightningS();
                }
            }
        }
        else 
        { 
            textFrameText.text = $"<wave>{LocalizationScript.outOfTime}</wave>"; handCollider.SetActive(false);
            audioManager.Play("OutOfTime");
        }

        textFrameAnim.gameObject.SetActive(true);
        textFrameText.gameObject.SetActive(true);
        textFrameAnim.Play("TextFrameAnim");
        yield return new WaitForSeconds(0.3f);

        yield return new WaitForSeconds(0.45f);

        if(miningStarted == true)
        {
            textFrameAnim.Play("TextFrameAnimDown");
        }

        if (miningStarted == true) { yield return new WaitForSeconds(0.25f); }
        else { yield return new WaitForSeconds(0.37f); }

        textFrameAnim.gameObject.SetActive(false);
        textFrameText.gameObject.SetActive(false);

        if(pressEnding == true) 
        { 
            handCollider.SetActive(true); 
            isInMiningSession = true; 
            Cursor.visible = false;
        }

        if (miningStarted == true) {}
        else { StartCoroutine(OpenTimeIsOutFrame()); }
    }
    #endregion

    #region Back to main menu or keep mining
    public GameObject mainMenu;

    public void BackToUpgradesOrKeepMining(bool backToUpgrade)
    {
        tileWaveNumber = 0;
        circleObject.SetActive(false);
        StartCoroutine(ScaleCircleCoroutine(true));
        pressEnding = false;
        StartCoroutine(ScaleCircleDownAgain(backToUpgrade));
        if(backToUpgrade == true)
        {
            mainMenuScript.SetSkillTree();

            MainMenu.pressedKeepOnMining = false;
            MainMenu.currentScreen = 0;
            mainMenuScript.SelectScreen("Upgrades");
        }
    }

    IEnumerator ScaleCircleDownAgain(bool backToUpgrade)
    {
        yield return new WaitForSeconds(0.85f);

        StartCoroutine(ScaleCircleCoroutine(false));

        if (backToUpgrade == true) 
        { 
            mainMenu.SetActive(true);
            backgroundDark.SetActive(true);
            SetStuffBackToObjectPool();
        }
        else
        {
            dustParticleParent.SetActive(false);

            backgroundDark.SetActive(false);
            mainMenu.SetActive(false);
            timeIsUpFrame.SetActive(false);
            SetStuffBackToObjectPool();

            if (LevelMechanics.springSeason_chosen) { SetFlowers(); }
            if (LevelMechanics.camper_chosen)
            {
                SetCampfire();
            }
            else
            {
                campfire.SetActive(false);
            }

            if (LevelMechanics.goldenTouch_chosen)
            {
                circleNormal.SetActive(true);
                circleGold.SetActive(false);
                hexagonNormal.SetActive(true);
                hexagonGold.SetActive(false);
                squareNormal.SetActive(true);
                squareGold.SetActive(false);

                float random = Random.Range(0f,100f);
                if(random < LevelMechanics.midasTouchChance)
                {
                    AllStats.midasTouchSessions += 1;

                    if (MobileAndTesting.isMobile == true)
                    {
                        normalCursorHand.SetActive(false);
                    }
                    else
                    {
                        normalCursorHand.SetActive(true);
                    }

                    isGoldenHand = true;

                    if (MobileAndTesting.isMobile == true)
                    {
                        circleNormal.SetActive(false);
                        circleGold.SetActive(true);
                        hexagonNormal.SetActive(false);
                        hexagonGold.SetActive(true);
                        squareNormal.SetActive(false);
                        squareGold.SetActive(true);
                        goldenHand.SetActive(false);
                    }
                    else
                    {
                        goldenHand.SetActive(true);
                    }
                }
                else
                {
                    if(MobileAndTesting.isMobile == true)
                    {
                        normalCursorHand.SetActive(false);
                    }
                    else
                    {
                        normalCursorHand.SetActive(true);
                    }

                    if (MobileAndTesting.isMobile == true)
                    {
                        goldenHand.SetActive(false);
                    }
                    else
                    {
                        goldenHand.SetActive(true);
                    }

                    isGoldenHand = false;
                }
            }
            else 
            {
                if (MobileAndTesting.isMobile == true)
                {
                    goldenHand.SetActive(false);
                }
                else
                {
                    goldenHand.SetActive(true);
                }

                isGoldenHand = false; 
            }

            tileWaveNumber = 0;

            yield return new WaitForSeconds(0.6f);

            if(pressEnding == false) 
            { 
                StartCoroutine(TileWaveAnim()); 
            }
            else
            {
                StartCoroutine(SpawnMineOrTimesUpText(true));
            }
        }
    }
    #endregion

    public GameObject copperOreFrame, ironOreFrame, cobaltOreFrame, uraniumOre_frame, ismiumOre_frame, iridiumOre_frame, painiteOre_frame;

    #region Scale circle
    public GameObject circleObject;
    public GameObject backgroundDark;
    public GameObject transitionBlock;

    private IEnumerator ScaleCircleCoroutine(bool scaleUp)
    {
        MainMenu.isInTransition = true;
        //if(scaleUp == true) { SetRandomHexColor(circleObject.GetComponent<Image>()); }

        circleObject.SetActive(true);
        transitionBlock.SetActive(true);

        audioManager.Play("Transition");

        float scaleDuration = 0.4f;

        float startScale = scaleUp ? 0f : 26f;
        float endScale = scaleUp ? 26f : 0f;
        float elapsed = 0f;

        Vector3 initialScale = new Vector3(startScale, startScale, startScale);
        Vector3 targetScale = new Vector3(endScale, endScale, endScale);

        circleObject.transform.localScale = initialScale;

        while (elapsed < scaleDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / scaleDuration);
            circleObject.transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            yield return null;
        }

        if(isInEnding == false)
        {
            if (scaleUp == false)
            {
                endingScript.SoundVolumeSet("MainMenuMusic", true, TheEnding.gameMusicFullVolume - 0.3f, TheEnding.gameMusicFullVolume, 0.1f, false);
            }
            else
            {
                endingScript.SoundVolumeSet("MainMenuMusic", true, TheEnding.gameMusicFullVolume, TheEnding.gameMusicFullVolume - 0.3f, 0.1f, false);
            }
        }

        if(pressEnding == true)
        {
            audioManager.Play("CreditsMusic");
            endingScript.SoundVolumeSet("CreditsMusic", false, 0, 0, 0.1f, false);
        }

        if (scaleUp) 
        {
            ResetBetweenTransitions();

            copperOreFrame.SetActive(false);
            ironOreFrame.SetActive(false);
            cobaltOreFrame.SetActive(false);
            uraniumOre_frame.SetActive(false);
            ismiumOre_frame.SetActive(false);
            iridiumOre_frame.SetActive(false);
            painiteOre_frame.SetActive(false);

            if (SkillTree.spawnCopper_purchased == true) { copperOreFrame.SetActive(true); }
            if (SkillTree.spawnIron_purchased == true) { ironOreFrame.SetActive(true); }
            if (SkillTree.cobaltSpawn_purchased == true) { cobaltOreFrame.SetActive(true); }
            if (SkillTree.uraniumSpawn_purchased == true) { uraniumOre_frame.SetActive(true); }
            if (SkillTree.ismiumSpawn_purchased == true) { ismiumOre_frame.SetActive(true); }
            if (SkillTree.iridiumSpawn_purchased == true) { iridiumOre_frame.SetActive(true); }
            if (SkillTree.painiteSpawn_purchased == true) { painiteOre_frame.SetActive(true); }

            copperOreFrame.transform.localPosition = new Vector2(-108, -76);
            ironOreFrame.transform.localPosition = new Vector2(108.7f, -76);
            cobaltOreFrame.transform.localPosition = new Vector2(-108, -129);
            uraniumOre_frame.transform.localPosition = new Vector2(108, -129);
            ismiumOre_frame.transform.localPosition = new Vector2(-108, -182);
            iridiumOre_frame.transform.localPosition = new Vector2(108, -182);
            painiteOre_frame.transform.localPosition = new Vector2(-108, -235);
        }

        circleObject.transform.localScale = targetScale;

        if (scaleUp == false)
        {
            transitionBlock.SetActive(false);
            circleObject.SetActive(false);
            MainMenu.isInTransition = false;
        }
        else
        {
         
        }
    }
    #endregion

    #region Open times up frame
    public void SetAllMaterialTextsInactive()
    {
        // Gold
        chunks_mined.gameObject.SetActive(false);
        goldBar_crafted.gameObject.SetActive(false);
        totalGoldBars.gameObject.SetActive(false);

        // Copper
        chunksMined_Copper.gameObject.SetActive(false);
        goldBarsCrafted_Copper.gameObject.SetActive(false);
        totalGoldBars_Copper.gameObject.SetActive(false);

        // Silver
        chunksMined_Silver.gameObject.SetActive(false);
        goldBarsCrafted_Silver.gameObject.SetActive(false);
        totalGoldBars_Silver.gameObject.SetActive(false);

        // Cobalt
        chunksMined_Cobalt.gameObject.SetActive(false);
        goldBarsCrafted_Cobalt.gameObject.SetActive(false);
        totalGoldBars_Cobalt.gameObject.SetActive(false);

        // Uranium
        chunksMined_Uranium.gameObject.SetActive(false);
        goldBarsCrafted_Uranium.gameObject.SetActive(false);
        totalGoldBars_Uranium.gameObject.SetActive(false);

        // Ismium
        chunksMined_Ismium.gameObject.SetActive(false);
        goldBarsCrafted_Ismium.gameObject.SetActive(false);
        totalGoldBars_Ismium.gameObject.SetActive(false);

        // Iridium
        chunksMined_Iridium.gameObject.SetActive(false);
        goldBarsCrafted_Iridium.gameObject.SetActive(false);
        totalGoldBars_Iridium.gameObject.SetActive(false);

        // Painite
        chunksMined_Painite.gameObject.SetActive(false);
        goldBarsCrafted_Painite.gameObject.SetActive(false);
        totalGoldBars_Painite.gameObject.SetActive(false);

        resourcesGatheredText.SetActive(false);
        resourcesCraftedText.SetActive(false);
        totalResourcesText.SetActive(false);
        xpParent.SetActive(false);
        xpGathereredText.SetActive(false);

        miningSessionDoneText.SetActive(false);

        levelUpText.SetActive(false);
        didLevelUpTalentPointsParent.gameObject.SetActive(false);
    }

    public GameObject timeIsUpFrame;
    public Animation timeIsUpAnimFrame;

    public GameObject upgradeButton, keepMiningButton;

    public static bool didCollectOtherResources, didCollectArtifact;

    public GameObject resourcesGatheredText, resourcesCraftedText, totalResourcesText, resourcesGathered_parent, resourcesCrafted_parent, totalResources_parent;

    public GameObject xpParent, xpGathereredText;

    public TextMeshProUGUI chunks_mined, goldBar_crafted, totalGoldBars;

    public GameObject miningSessionDoneText;

    // Copper
    public TextMeshProUGUI chunksMined_Copper, goldBarsCrafted_Copper, totalGoldBars_Copper;

    // Silver
    public TextMeshProUGUI chunksMined_Silver, goldBarsCrafted_Silver, totalGoldBars_Silver;

    // Cobalt
    public TextMeshProUGUI chunksMined_Cobalt, goldBarsCrafted_Cobalt, totalGoldBars_Cobalt;

    // Uranium
    public TextMeshProUGUI chunksMined_Uranium, goldBarsCrafted_Uranium, totalGoldBars_Uranium;

    // Ismium
    public TextMeshProUGUI chunksMined_Ismium, goldBarsCrafted_Ismium, totalGoldBars_Ismium;

    // Iridium
    public TextMeshProUGUI chunksMined_Iridium, goldBarsCrafted_Iridium, totalGoldBars_Iridium;

    // Painite
    public TextMeshProUGUI chunksMined_Painite, goldBarsCrafted_Painite, totalGoldBars_Painite;

    public TextMeshProUGUI xpGainedThisRound_text;

    public GameObject D100;
    public TextMeshProUGUI D100text;

    public GameObject didLevelUpTalentPointsParent;
    public GameObject levelUpText;
    public TextMeshProUGUI levelUpTalentPoints;

    IEnumerator OpenTimeIsOutFrame()
    {
        miningSessionDoneText.transform.localPosition = new Vector2(0,285);
        miningSessionDoneText.transform.localScale = new Vector2(1.55f, 1.55f);

        if (Artifacts.oneArtifactMined == true)
        {
            audioManager.Play("FoundArtifact");

            if (Artifacts.horn_spawned) { artifactsScript.SetArtifactFrame(1); Artifacts.artifactsFound += 1; }
            if (Artifacts.ancientDevice_spawned) { artifactsScript.SetArtifactFrame(2); Artifacts.artifactsFound += 1; }
            if (Artifacts.bone_spawned) { artifactsScript.SetArtifactFrame(3); Artifacts.artifactsFound += 1; }
            if (Artifacts.meteorieOre_spawned) { artifactsScript.SetArtifactFrame(4); Artifacts.artifactsFound += 1; }
            if (Artifacts.book_spawned) { artifactsScript.SetArtifactFrame(5); Artifacts.artifactsFound += 1; }
            if (Artifacts.goldStack_spawned) { artifactsScript.SetArtifactFrame(6); Artifacts.artifactsFound += 1; }
            if (Artifacts.goldRing_spawned) { artifactsScript.SetArtifactFrame(7); Artifacts.artifactsFound += 1; }
            if (Artifacts.purpleRing_spawned) { artifactsScript.SetArtifactFrame(8); Artifacts.artifactsFound += 1; }
            if (Artifacts.ancientDice_spawned) { artifactsScript.SetArtifactFrame(9); Artifacts.artifactsFound += 1; }
            if (Artifacts.cheese_spawned) { artifactsScript.SetArtifactFrame(10); Artifacts.artifactsFound += 1; }
            if (Artifacts.wolfClaw_spawned) { artifactsScript.SetArtifactFrame(11); Artifacts.artifactsFound += 1; }
            if (Artifacts.axe_spawned) { artifactsScript.SetArtifactFrame(12); Artifacts.artifactsFound += 1; }
            if (Artifacts.rune_spawned) { artifactsScript.SetArtifactFrame(13); Artifacts.artifactsFound += 1; }
            if (Artifacts.skull_spawned) { artifactsScript.SetArtifactFrame(14); Artifacts.artifactsFound += 1; }
        }

        bool doubleResources = false;

        if (LevelMechanics.d100_chosen)
        {
            D100.SetActive(true);
            int random = Random.Range(1,101);

            if(random == 100 || random == 1 || random == 10)
            {
                AllStats.d100Rolls += 1;

                D100text.text = $"{LocalizationScript.rolled} {random}\n{LocalizationScript.oresTripled}";
                doubleResources = true;
            }
            else
            {
                D100text.text = $"{LocalizationScript.rolled} {random}";
            }
        }
        else
        {
            D100.SetActive(false);
        }

        SetAllMaterialTextsInactive();

        resourcesGatheredText.transform.localScale = new Vector2(1.3f, 1.3f);
        resourcesCraftedText.transform.localScale = new Vector2(1.3f, 1.3f);
        totalResourcesText.transform.localScale = new Vector2(1.3f, 1.3f);

        float xpTextsXpos = 0;
        float levelUpXPos = 183;
        if(LevelMechanics.didLevelUp == true) 
        {
            levelUpTalentPoints.text = $"+{LevelMechanics.didLevelUpTotalTalentPoints}";
            xpTextsXpos = -183;
        }

        #region totalMaterialRocksSpawning = 1
        if (SkillTree.totalMaterialRocksSpawning == 1)
        {
            resourcesGatheredText.transform.localPosition = new Vector2(-370, 156);
            resourcesCraftedText.transform.localPosition = new Vector2(0, 156);
            totalResourcesText.transform.localPosition = new Vector2(370, 156);

            resourcesGathered_parent.transform.localPosition = new Vector2(-397, 79);
            resourcesGathered_parent.transform.localScale = new Vector2(10f, 10);

            resourcesCrafted_parent.transform.localPosition = new Vector2(0, 79);
            resourcesCrafted_parent.transform.localScale = new Vector2(10f, 10f);

            totalResources_parent.transform.localPosition = new Vector2(330, 79);
            totalResources_parent.transform.localScale = new Vector2(10f, 10f);

            xpGathereredText.transform.localPosition = new Vector2(xpTextsXpos, -51);
            xpGathereredText.transform.localScale = new Vector2(1.2f, 1.2f);

            xpParent.transform.localPosition = new Vector2(xpTextsXpos, -121);
            xpParent.transform.localScale = new Vector2(13f, 13f);

            //Level up
            levelUpText.transform.localPosition = new Vector2(levelUpXPos, -51);
            levelUpText.transform.localScale = new Vector2(1.2f, 1.2f);

            didLevelUpTalentPointsParent.transform.localPosition = new Vector2(levelUpXPos, -121);
            didLevelUpTalentPointsParent.transform.localScale = new Vector2(13f, 13f);
        }
        #endregion

        #region totalMaterialRocksSpawning = 2
        if (SkillTree.totalMaterialRocksSpawning == 2) 
        {
            resourcesGatheredText.transform.localPosition = new Vector2(-370, 173);
            resourcesCraftedText.transform.localPosition = new Vector2(0, 173);
            totalResourcesText.transform.localPosition = new Vector2(370, 173);

            resourcesGathered_parent.transform.localPosition = new Vector2(-398, 96);
            resourcesGathered_parent.transform.localScale = new Vector2(10f, 10);

            resourcesCrafted_parent.transform.localPosition = new Vector2(0, 96);
            resourcesCrafted_parent.transform.localScale = new Vector2(10f, 10f);

            totalResources_parent.transform.localPosition = new Vector2(326, 96);
            totalResources_parent.transform.localScale = new Vector2(10f, 10f);

            xpGathereredText.transform.localPosition = new Vector2(xpTextsXpos, -73);
            xpGathereredText.transform.localScale = new Vector2(1.12f, 1.12f);

            xpParent.transform.localPosition = new Vector2(xpTextsXpos, -143);
            xpParent.transform.localScale = new Vector2(12.3f, 12.3f);

            //Level up
            levelUpText.transform.localPosition = new Vector2(levelUpXPos, -73);
            levelUpText.transform.localScale = new Vector2(1.12f, 1.12f);

            didLevelUpTalentPointsParent.transform.localPosition = new Vector2(levelUpXPos, -143);
            didLevelUpTalentPointsParent.transform.localScale = new Vector2(12.3f, 12.3f);
        }
        #endregion

        #region totalMaterialRocksSpawning = 3
        if (SkillTree.totalMaterialRocksSpawning == 3)
        {
            resourcesGatheredText.transform.localPosition = new Vector2(-370, 173);
            resourcesCraftedText.transform.localPosition = new Vector2(0, 173);
            totalResourcesText.transform.localPosition = new Vector2(370, 173);

            resourcesGathered_parent.transform.localPosition = new Vector2(-396, 109);
            resourcesGathered_parent.transform.localScale = new Vector2(8.7f, 8.7f);

            resourcesCrafted_parent.transform.localPosition = new Vector2(0, 109);
            resourcesCrafted_parent.transform.localScale = new Vector2(8.7f, 8.7f);

            totalResources_parent.transform.localPosition = new Vector2(337, 109);
            totalResources_parent.transform.localScale = new Vector2(8.7f, 8.7f);

            xpGathereredText.transform.localPosition = new Vector2(xpTextsXpos, -92);
            xpGathereredText.transform.localScale = new Vector2(1f, 1f);

            xpParent.transform.localPosition = new Vector2(xpTextsXpos, -159);
            xpParent.transform.localScale = new Vector2(10.6f, 10.6f);

            //Level up
            levelUpText.transform.localPosition = new Vector2(levelUpXPos, -92);
            levelUpText.transform.localScale = new Vector2(1f, 1f);

            didLevelUpTalentPointsParent.transform.localPosition = new Vector2(levelUpXPos, -159);
            didLevelUpTalentPointsParent.transform.localScale = new Vector2(10.6f, 10.6f);
        }
        #endregion

        #region totalMaterialRocksSpawning = 4
        if (SkillTree.totalMaterialRocksSpawning == 4)
        {
            resourcesGatheredText.transform.localPosition = new Vector2(-370, 197);
            resourcesCraftedText.transform.localPosition = new Vector2(0, 197);
            totalResourcesText.transform.localPosition = new Vector2(370, 197);

            resourcesGathered_parent.transform.localPosition = new Vector2(-392, 133);
            resourcesGathered_parent.transform.localScale = new Vector2(7.9f, 7.9f);

            resourcesCrafted_parent.transform.localPosition = new Vector2(0, 133);
            resourcesCrafted_parent.transform.localScale = new Vector2(7.9f, 7.9f);

            totalResources_parent.transform.localPosition = new Vector2(337, 133);
            totalResources_parent.transform.localScale = new Vector2(7.9f, 7.9f);

            xpGathereredText.transform.localPosition = new Vector2(xpTextsXpos, -97);
            xpGathereredText.transform.localScale = new Vector2(0.98f, 0.98f);

            xpParent.transform.localPosition = new Vector2(xpTextsXpos, -164);
            xpParent.transform.localScale = new Vector2(10.6f, 10.6f);

            //Level up
            levelUpText.transform.localPosition = new Vector2(levelUpXPos, -97);
            levelUpText.transform.localScale = new Vector2(0.98f, 0.98f);

            didLevelUpTalentPointsParent.transform.localPosition = new Vector2(levelUpXPos, -164);
            didLevelUpTalentPointsParent.transform.localScale = new Vector2(10.6f, 10.6f);
        }
        #endregion

        #region totalMaterialRocksSpawning = 5
        if (SkillTree.totalMaterialRocksSpawning == 5)
        {
            resourcesGatheredText.transform.localPosition = new Vector2(-370, 203);
            resourcesCraftedText.transform.localPosition = new Vector2(0, 203);
            totalResourcesText.transform.localPosition = new Vector2(370, 203);

            resourcesGathered_parent.transform.localPosition = new Vector2(-391, 144);
            resourcesGathered_parent.transform.localScale = new Vector2(7f, 7f);

            resourcesCrafted_parent.transform.localPosition = new Vector2(0, 144);
            resourcesCrafted_parent.transform.localScale = new Vector2(7f, 7f);

            totalResources_parent.transform.localPosition = new Vector2(342, 144);
            totalResources_parent.transform.localScale = new Vector2(7f, 7f);

            xpGathereredText.transform.localPosition = new Vector2(xpTextsXpos, -108);
            xpGathereredText.transform.localScale = new Vector2(0.98f, 0.98f);

            xpParent.transform.localPosition = new Vector2(xpTextsXpos, -175);
            xpParent.transform.localScale = new Vector2(10.6f, 10.6f);

            //Level up
            levelUpText.transform.localPosition = new Vector2(levelUpXPos, -108);
            levelUpText.transform.localScale = new Vector2(0.98f, 0.98f);

            didLevelUpTalentPointsParent.transform.localPosition = new Vector2(levelUpXPos, -175);
            didLevelUpTalentPointsParent.transform.localScale = new Vector2(10.6f, 10.6f);
        }
        #endregion

        #region totalMaterialRocksSpawning = 6
        if (SkillTree.totalMaterialRocksSpawning == 6)
        {
            resourcesGatheredText.transform.localPosition = new Vector2(-370, 208);
            resourcesCraftedText.transform.localPosition = new Vector2(0, 208);
            totalResourcesText.transform.localPosition = new Vector2(370, 208);

            resourcesGathered_parent.transform.localPosition = new Vector2(-389, 152);
            resourcesGathered_parent.transform.localScale = new Vector2(6.5f, 6.5f);

            resourcesCrafted_parent.transform.localPosition = new Vector2(0, 152);
            resourcesCrafted_parent.transform.localScale = new Vector2(6.5f, 6.5f);

            totalResources_parent.transform.localPosition = new Vector2(343, 152);
            totalResources_parent.transform.localScale = new Vector2(6.5f, 6.5f);

            xpGathereredText.transform.localPosition = new Vector2(xpTextsXpos, -124);
            xpGathereredText.transform.localScale = new Vector2(0.88f, 0.88f);

            xpParent.transform.localPosition = new Vector2(xpTextsXpos, -183);
            xpParent.transform.localScale = new Vector2(9.54f, 9.54f);

            //Level up
            levelUpText.transform.localPosition = new Vector2(levelUpXPos, -124);
            levelUpText.transform.localScale = new Vector2(0.88f, 0.88f);

            didLevelUpTalentPointsParent.transform.localPosition = new Vector2(levelUpXPos, -183);
            didLevelUpTalentPointsParent.transform.localScale = new Vector2(9.54f, 9.54f);
        }
        #endregion

        #region totalMaterialRocksSpawning = 7
        if (SkillTree.totalMaterialRocksSpawning == 7)
        {
            resourcesGatheredText.transform.localPosition = new Vector2(-370, 208);
            resourcesCraftedText.transform.localPosition = new Vector2(0, 208);
            totalResourcesText.transform.localPosition = new Vector2(370, 208);

            resourcesGathered_parent.transform.localPosition = new Vector2(-387, 150);
            resourcesGathered_parent.transform.localScale = new Vector2(6.04f, 6.04f);

            resourcesCrafted_parent.transform.localPosition = new Vector2(0, 150);
            resourcesCrafted_parent.transform.localScale = new Vector2(6.04f, 6.04f);

            totalResources_parent.transform.localPosition = new Vector2(345, 150);
            totalResources_parent.transform.localScale = new Vector2(6.04f, 6.04f);

            xpGathereredText.transform.localPosition = new Vector2(xpTextsXpos, -136);
            xpGathereredText.transform.localScale = new Vector2(0.8f, 0.8f);

            xpParent.transform.localPosition = new Vector2(xpTextsXpos, -189);
            xpParent.transform.localScale = new Vector2(8.7f, 8.7f);

            //Level up
            levelUpText.transform.localPosition = new Vector2(levelUpXPos, -136);
            levelUpText.transform.localScale = new Vector2(0.8f, 0.8f);

            didLevelUpTalentPointsParent.transform.localPosition = new Vector2(levelUpXPos, -189);
            didLevelUpTalentPointsParent.transform.localScale = new Vector2(8.7f, 8.7f);
        }
        #endregion

        #region totalMaterialRocksSpawning = 8
        if (SkillTree.totalMaterialRocksSpawning == 8)
        {
            resourcesGatheredText.transform.localPosition = new Vector2(-370, 203);
            resourcesCraftedText.transform.localPosition = new Vector2(0, 203);
            totalResourcesText.transform.localPosition = new Vector2(370, 203);

            resourcesGathered_parent.transform.localPosition = new Vector2(-386, 156);
            resourcesGathered_parent.transform.localScale = new Vector2(5.3f, 5.3f);

            resourcesCrafted_parent.transform.localPosition = new Vector2(0, 156);
            resourcesCrafted_parent.transform.localScale = new Vector2(5.3f, 5.3f);

            totalResources_parent.transform.localPosition = new Vector2(347, 156);
            totalResources_parent.transform.localScale = new Vector2(5.3f, 5.3f);

            xpGathereredText.transform.localPosition = new Vector2(xpTextsXpos, -148);
            xpGathereredText.transform.localScale = new Vector2(0.74f, 0.74f);

            xpParent.transform.localPosition = new Vector2(xpTextsXpos, -191);
            xpParent.transform.localScale = new Vector2(8, 8);

            //Level up
            levelUpText.transform.localPosition = new Vector2(levelUpXPos, -148);
            levelUpText.transform.localScale = new Vector2(0.74f, 0.74f);

            didLevelUpTalentPointsParent.transform.localPosition = new Vector2(levelUpXPos, -191);
            didLevelUpTalentPointsParent.transform.localScale = new Vector2(8, 8);
        }
        #endregion

        if (doubleResources == true)
        {
            GoldAndOreMechanics.totalGoldore *= 5;
            GoldAndOreMechanics.totalCopperOre *= 5;
            GoldAndOreMechanics.totalIronOre *= 5;
            GoldAndOreMechanics.totalCobaltOre *= 5;
            GoldAndOreMechanics.totalUraniumOre *= 5;
            GoldAndOreMechanics.totalIsmiumOre *= 5;
            GoldAndOreMechanics.totalIridiumOre *= 5;
            GoldAndOreMechanics.totalPainiteOre *= 5;
        }

        oresPopedUp = true;

        chunks_mined.text = FormatNumbers.FormatPoints(GoldAndOreMechanics.totalGoldore);
        chunksMined_Copper.text = FormatNumbers.FormatPoints(GoldAndOreMechanics.totalCopperOre);
        chunksMined_Silver.text = FormatNumbers.FormatPoints(GoldAndOreMechanics.totalIronOre);
        chunksMined_Cobalt.text = FormatNumbers.FormatPoints(GoldAndOreMechanics.totalCobaltOre);
        chunksMined_Uranium.text = FormatNumbers.FormatPoints(GoldAndOreMechanics.totalUraniumOre);
        chunksMined_Ismium.text = FormatNumbers.FormatPoints(GoldAndOreMechanics.totalIsmiumOre);
        chunksMined_Iridium.text = FormatNumbers.FormatPoints(GoldAndOreMechanics.totalIridiumOre);
        chunksMined_Painite.text = FormatNumbers.FormatPoints(GoldAndOreMechanics.totalPainiteOre);

        CraftOres(GoldAndOreMechanics.totalGoldore, goldBar_crafted, 1);
        if (SkillTree.spawnCopper_purchased) { CraftOres(GoldAndOreMechanics.totalCopperOre, goldBarsCrafted_Copper, 2); }
        if (SkillTree.spawnIron_purchased) { CraftOres(GoldAndOreMechanics.totalIronOre, goldBarsCrafted_Silver, 3); }
        if (SkillTree.cobaltSpawn_purchased) { CraftOres(GoldAndOreMechanics.totalCobaltOre, goldBarsCrafted_Cobalt, 4); }
        if (SkillTree.uraniumSpawn_purchased) { CraftOres(GoldAndOreMechanics.totalUraniumOre, goldBarsCrafted_Uranium, 5); }
        if (SkillTree.ismiumSpawn_purchased) { CraftOres(GoldAndOreMechanics.totalIsmiumOre, goldBarsCrafted_Ismium, 6); }
        if (SkillTree.iridiumSpawn_purchased) { CraftOres(GoldAndOreMechanics.totalIridiumOre, goldBarsCrafted_Iridium, 7); }
        if (SkillTree.painiteSpawn_purchased) { CraftOres(GoldAndOreMechanics.totalPainiteOre, goldBarsCrafted_Painite, 8); }

        totalGoldBars.text = FormatNumbers.FormatPoints(GoldAndOreMechanics.totalGoldBars);
        totalGoldBars_Copper.text = FormatNumbers.FormatPoints(GoldAndOreMechanics.totalCopperBars);
        totalGoldBars_Silver.text = FormatNumbers.FormatPoints(GoldAndOreMechanics.totalIronBars);
        totalGoldBars_Cobalt.text = FormatNumbers.FormatPoints(GoldAndOreMechanics.totalCobaltBars);
        totalGoldBars_Uranium.text = FormatNumbers.FormatPoints(GoldAndOreMechanics.totalUraniumBars);
        totalGoldBars_Ismium.text = FormatNumbers.FormatPoints(GoldAndOreMechanics.totalIsmiumBar);
        totalGoldBars_Iridium.text = FormatNumbers.FormatPoints(GoldAndOreMechanics.totalIridiumBars);
        totalGoldBars_Painite.text = FormatNumbers.FormatPoints(GoldAndOreMechanics.totalPainiteBars);

        goldAndOreScript.SetTotalResourcesText();

        float waitTime = 0.15f;
      
        if(SkillTree.totalMaterialRocksSpawning == 2) { waitTime = 0.15f; }
        if (SkillTree.totalMaterialRocksSpawning == 3) { waitTime = 0.14f; }
        if (SkillTree.totalMaterialRocksSpawning == 4) { waitTime = 0.13f; }
        if (SkillTree.totalMaterialRocksSpawning == 5) { waitTime = 0.125f; }
        if (SkillTree.totalMaterialRocksSpawning == 6) { waitTime = 0.12f; }
        if (SkillTree.totalMaterialRocksSpawning == 7) { waitTime = 0.11f; }
        if (SkillTree.totalMaterialRocksSpawning == 8) { waitTime = 0.10f; }

        upgradeButton.SetActive(false); keepMiningButton.SetActive(false);

        timeIsUpFrame.SetActive(true);
        timeIsUpAnimFrame.Play();
        yield return new WaitForSeconds(waitTime);

        miningSessionDoneText.SetActive(true);

        audioManager.Play("Pop");
        yield return new WaitForSeconds(waitTime);

        resourcesGatheredText.SetActive(true);
        resourcesCraftedText.SetActive(true);
        totalResourcesText.SetActive(true);

        audioManager.Play("Pop");

        yield return new WaitForSeconds(waitTime);

        chunks_mined.gameObject.SetActive(true); goldBar_crafted.gameObject.SetActive(true); totalGoldBars.gameObject.SetActive(true);

        audioManager.Play("Pop");

        if (SkillTree.spawnCopper_purchased)
        { 
            yield return new WaitForSeconds(waitTime);
            chunksMined_Copper.gameObject.SetActive(true); goldBarsCrafted_Copper.gameObject.SetActive(true); totalGoldBars_Copper.gameObject.SetActive(true);
            audioManager.Play("Pop");
        }

        if (SkillTree.spawnIron_purchased)
        {
            yield return new WaitForSeconds(waitTime);
            chunksMined_Silver.gameObject.SetActive(true); goldBarsCrafted_Silver.gameObject.SetActive(true); totalGoldBars_Silver.gameObject.SetActive(true);
            audioManager.Play("Pop");
        }

        if (SkillTree.cobaltSpawn_purchased)
        {
            yield return new WaitForSeconds(waitTime);
            chunksMined_Cobalt.gameObject.SetActive(true); goldBarsCrafted_Cobalt.gameObject.SetActive(true); totalGoldBars_Cobalt.gameObject.SetActive(true);
            audioManager.Play("Pop");
        }

        if (SkillTree.uraniumSpawn_purchased)
        {
            yield return new WaitForSeconds(waitTime);
            chunksMined_Uranium.gameObject.SetActive(true); goldBarsCrafted_Uranium.gameObject.SetActive(true); totalGoldBars_Uranium.gameObject.SetActive(true);
            audioManager.Play("Pop");
        }

        if (SkillTree.ismiumSpawn_purchased)
        {
            yield return new WaitForSeconds(waitTime);
            chunksMined_Ismium.gameObject.SetActive(true); goldBarsCrafted_Ismium.gameObject.SetActive(true); totalGoldBars_Ismium.gameObject.SetActive(true);
            audioManager.Play("Pop");
        }

        if (SkillTree.iridiumSpawn_purchased)
        {
            yield return new WaitForSeconds(waitTime);
            chunksMined_Iridium.gameObject.SetActive(true); goldBarsCrafted_Iridium.gameObject.SetActive(true); totalGoldBars_Iridium.gameObject.SetActive(true);
            audioManager.Play("Pop");
        }

        if (SkillTree.painiteSpawn_purchased)
        {
            yield return new WaitForSeconds(waitTime);
            chunksMined_Painite.gameObject.SetActive(true); goldBarsCrafted_Painite.gameObject.SetActive(true); totalGoldBars_Painite.gameObject.SetActive(true);
            audioManager.Play("Pop");
        }

        yield return new WaitForSeconds(waitTime);

        xpGainedThisRound_text.text = "+0XP";
        
        xpGainedThisRound_text.text = "+" + FormatNumbers.FormatPoints(LevelMechanics.xpThisRound * 100) + "XP";

        xpGathereredText.SetActive(true);

        if (LevelMechanics.didLevelUp == true) { levelUpText.SetActive(true); }
        else { levelUpText.SetActive(false); }

        audioManager.Play("Pop");
        yield return new WaitForSeconds(waitTime);

        xpParent.SetActive(true);

        if (LevelMechanics.didLevelUp == true) { didLevelUpTalentPointsParent.gameObject.SetActive(true); }
        else { didLevelUpTalentPointsParent.gameObject.SetActive(false); }

        audioManager.Play("Pop");
        yield return new WaitForSeconds(waitTime);

        audioManager.Play("Pop");

        if(Tutorial.pressedOkCraftingTurotialFrame == false)
        {
            tutorialScript.SetTutorial(1);
        }

        upgradeButton.SetActive(true); keepMiningButton.SetActive(true);

        achScript.CheckAch();
    }
    #endregion

    #region Craft bars
    public void CraftOres(double totalOre, TextMeshProUGUI craftedText, int materialToAdd)
    {
        int oresPerBar = 3;
        if (SkillTree.craft2Material_purchased == true) { oresPerBar = 2; }

        double totalBarsCrafted = totalOre / oresPerBar;
        double oreRemainder = totalOre % oresPerBar;

        if (oreRemainder > 0)
        {
            totalBarsCrafted += 1;
        }

        if (Artifacts.goldRing_found)
        {
            float random = Random.Range(1.025f, 1.035f);

            if (SkillTree.craft2Material_purchased == true)
            {
                random = Random.Range(1.018f, 1.023f);
            }

            totalBarsCrafted *= random;
        }

        if (totalBarsCrafted % 1 != 0)
        {
            totalBarsCrafted -= totalBarsCrafted % 1;
        }

        //check if totalBarsCrafted (it is a double variable) has any decimal points, if it has, remove them. Example, if the totalBarsCrafted is equal o 650.533, it should just be 650

        craftedText.text = FormatNumbers.FormatPoints(totalBarsCrafted);

        if (materialToAdd == 1) { GoldAndOreMechanics.totalGoldBars += totalBarsCrafted; }
        if (materialToAdd == 2)
        {
            GoldAndOreMechanics.totalCopperBars += totalBarsCrafted;
        }
        if (materialToAdd == 3) { GoldAndOreMechanics.totalIronBars += totalBarsCrafted; }
        if (materialToAdd == 4) { GoldAndOreMechanics.totalCobaltBars += totalBarsCrafted; }
        if (materialToAdd == 5) { GoldAndOreMechanics.totalUraniumBars += totalBarsCrafted; }
        if (materialToAdd == 6) { GoldAndOreMechanics.totalIsmiumBar += totalBarsCrafted; }
        if (materialToAdd == 7) { GoldAndOreMechanics.totalIridiumBars += totalBarsCrafted; }
        if (materialToAdd == 8) { GoldAndOreMechanics.totalPainiteBars += totalBarsCrafted; }

        AllStats.barsCrafted += totalBarsCrafted;
    }
    #endregion

    #region Craft text animation
    IEnumerator CraftTheResource(int craftType, int totalCrafted, TextMeshProUGUI textToCraft)
    {
        //craftType 1 = gold bar.

        textToCraft.text = "0";

        float timeToCraft = 0.17f;
        float currentTime = 0;

        while (currentTime < timeToCraft)
        {
            currentTime += Time.deltaTime;

            float progress = Mathf.Clamp01(currentTime / timeToCraft);
            int currentValue = Mathf.RoundToInt(Mathf.Lerp(0, totalCrafted, progress));
            textToCraft.text = currentValue.ToString();

            yield return null;
        }

        if(craftType == 1) { textToCraft.text = totalCrafted.ToString(); }
   
    }
    #endregion

    #region Check stuff on screen
    public Transform originalRockParent;

    public void SetStuffBackToObjectPool()
    {
        allArtifactsParent.SetActive(false);

        GameObject[] Rock = GameObject.FindGameObjectsWithTag("Rock");
        foreach (GameObject rock in Rock)
        {
            if (rock.activeSelf)
            {
                //Debug.Log("rock remove");
                rock.transform.SetParent(originalRockParent);
                ObjectPool.instance.ReturnRockFromPool(rock);
            }
        }

        if (LevelMechanics.springSeason_chosen)
        {
            GameObject[] Flower = GameObject.FindGameObjectsWithTag("Flower");
            foreach (GameObject flower in Flower)
            {
                if (flower.activeSelf)
                {
                    flower.transform.SetParent(originalFLowerParent);
                    flower.gameObject.SetActive(false);
                }
            }
        }

        if (LevelMechanics.camper_chosen)
        {
            campfire.SetActive(false);
        }
    }
    #endregion

    #region Check stuff on screen - Reset when time is up

    public void ResetTimeISUpStuff()
    {
        GameObject[] Circle = GameObject.FindGameObjectsWithTag("CircleShoot");
        foreach (GameObject circle in Circle)
        {
            if (circle.activeSelf)
            {
                ObjectPool.instance.ReturnCircleColliderFromPool(circle);
            }
        }
    }
    #endregion

    public GameObject circleNormal, circleGold, hexagonNormal, hexagonGold, squareNormal, squareGold;

    #region Reset between transitions
    public void ResetBetweenTransitions()
    {
        if (LevelMechanics.shapeShifter_chosen)
        {
            circleColl.SetActive(false); squareColl.SetActive(false); hexagonColl.SetActive(false);

            int randomShape = Random.Range(1,4);
            if(randomShape == 1) 
            { 
                circleColl.SetActive(true);
            }
            if (randomShape == 2) 
            { 
                squareColl.SetActive(true); 
            }
            if (randomShape == 3) 
            { 
                hexagonColl.SetActive(true); 
            }
        }
        else
        {
            circleColl.SetActive(true);
        }

        #region Potion drinker and chugger
        potion_materialsWorthMore.SetActive(false); isPotionMaterialWorthMore = false;
        potion_xp.SetActive(false); isPotionXp = false;
        potion_pickaxeStats.SetActive(false); isPotionPickaxeStats = false;
        potion_doubleMaterialAndXPChance.SetActive(false); isPotionDoubleMaterialAndXPChance = false;

        potionDoubleChance_increase = 0;
        potionXp_increase = 0;
        potionMaterialWorthMore_increase = 0;
        potionPickaxeStats_increase = 0;

        if (LevelMechanics.potionDrinker_chosen)
        {
            int random = Random.Range(1, 5);
            if (random == 1) { potion_materialsWorthMore.SetActive(true); isPotionMaterialWorthMore = true; }
            if (random == 2) { potion_xp.SetActive(true); isPotionXp = true; }
            if (random == 3) { potion_pickaxeStats.SetActive(true); isPotionPickaxeStats = true; }
            if (random == 4) { potion_doubleMaterialAndXPChance.SetActive(true); isPotionDoubleMaterialAndXPChance = true; }
        }
        if (LevelMechanics.potionChugger_chosen)
        {
            potion_materialsWorthMore.SetActive(true); isPotionMaterialWorthMore = true;
            potion_xp.SetActive(true); isPotionXp = true;
            potion_pickaxeStats.SetActive(true); isPotionPickaxeStats = true;
            potion_doubleMaterialAndXPChance.SetActive(true); isPotionDoubleMaterialAndXPChance = true;
        }

        if (isPotionMaterialWorthMore)
        {
            if (SkillTree.materialsTotalWorth < 7) { potionMaterialWorthMore_increase = 1; }
            else if (SkillTree.materialsTotalWorth < 12) { potionMaterialWorthMore_increase = 2; }
            else if (SkillTree.materialsTotalWorth < 20) { potionMaterialWorthMore_increase = 3; }
            else if (SkillTree.materialsTotalWorth < 30) { potionMaterialWorthMore_increase = 4; }
            else if (SkillTree.materialsTotalWorth < 50) { potionMaterialWorthMore_increase = 5; }
            else if (SkillTree.materialsTotalWorth < 70) { potionMaterialWorthMore_increase = 6; }
            else if (SkillTree.materialsTotalWorth < 100) { potionMaterialWorthMore_increase = 7; }
            else { potionMaterialWorthMore_increase = 8; }
        }
        else { potionMaterialWorthMore_increase = 0; }

        if (isPotionXp)
        {
            float random = Random.Range(0.13f, 0.21f);
            potionXp_increase = random;
        }
        else { potionXp_increase = 0; }

        if (isPotionPickaxeStats)
        {
            if (SkillTree.improvedPickaxeStrength < 1.06f) { potionPickaxeStats_increase = 0.02f; }
            else if (SkillTree.improvedPickaxeStrength < 1.13f) { potionPickaxeStats_increase = 0.03f; }
            else if (SkillTree.improvedPickaxeStrength < 1.3f) { potionPickaxeStats_increase = 0.04f; }
            else if (SkillTree.improvedPickaxeStrength < 1.4f) { potionPickaxeStats_increase = 0.05f; }
            else if (SkillTree.improvedPickaxeStrength < 1.6f) { potionPickaxeStats_increase = 0.08f; }
            else { potionPickaxeStats_increase = 0.1f; }
        }
        else { potionPickaxeStats_increase = 0; }

        if (isPotionDoubleMaterialAndXPChance)
        {
            if (SkillTree.doubleXpAndGoldChance < 6) { potionDoubleChance_increase = 2; }
            else if (SkillTree.doubleXpAndGoldChance < 11) { potionDoubleChance_increase = 2; }
            else if (SkillTree.doubleXpAndGoldChance < 20) { potionDoubleChance_increase = 3; }
            else if (SkillTree.doubleXpAndGoldChance < 50) { potionDoubleChance_increase = 4f; }
            else { potionDoubleChance_increase = 5; }
        }
        else { potionDoubleChance_increase = 0; }
        #endregion

        anvilScript.DisplayEquippedAndSetStats(TheAnvil.equippedMineTime, TheAnvil.equippedMinePower, TheAnvil.equipped2XChance, TheAnvil.equippedMiningArea);

        SetNewBackground();
        goldAndOreScript.ResetStuff();
    }
    #endregion

    #region Set backgrounds
    public int backgroundIncrement;
    public int currentBackground;

    public GameObject background1, background2, background3, background4, background5;

    public void SetNewBackground()
    {
        return;
        if(currentBackground == 0) { currentBackground = 5; }

        bool changeBAckground = false;

        backgroundIncrement += 1;
        if(backgroundIncrement > 3 && backgroundIncrement < 6)
        {
            int random = Random.Range(1,3);
            if(random == 1) { return; }
            else
            {
                changeBAckground = true;
            }
        }
        if (backgroundIncrement == 6 || changeBAckground == true)
        {
            background1.SetActive(false);
            background2.SetActive(false);
            background3.SetActive(false);
            background4.SetActive(false);
            background5.SetActive(false);

            backgroundIncrement = 0;

            int randomBackground;

            do
            {
              randomBackground = Random.Range(1, 6);
            } while (currentBackground == randomBackground);

            currentBackground = randomBackground;

            if(randomBackground == 1) { background1.SetActive(true); }
            if (randomBackground == 2) { background2.SetActive(true); }
            if (randomBackground == 3) { background3.SetActive(true); }
            if (randomBackground == 4) { background4.SetActive(true); }
            if (randomBackground == 5) { background5.SetActive(true); }
        }
    }
    #endregion

    #region set flowers
    public GameObject[] flowers;

    public static int flowersOnScreen;

    public Transform originalFLowerParent;
    public TextMeshProUGUI totalFlowersText;
    public GameObject totalFlowersObject;

    public void SetFlowers()
    {
        int random = Random.Range(2,18);

        flowersOnScreen = random;

        for (int i = 0; i < random; i++)
        {
            AllStats.flowersSpawned += 1;

            flowers[i].SetActive(true);
            tileWaveNumber = Random.Range(0,14);
            flowers[i].transform.SetParent(rockParent[tileWaveNumber]);

            Vector2 pos = new Vector2(Random.Range(77, -77), Random.Range(-1.5f, 1.5f));
            flowers[i].transform.localPosition = pos;
            flowers[i].transform.localScale = new Vector2(0.075f, 0.075f);
        }

        totalFlowersObject.gameObject.SetActive(true);

        totalFlowersText.text = "X" + flowersOnScreen.ToString("F0");
    }
    #endregion

    #region Set campfire
    public GameObject campfire;

    public void SetCampfire()
    {
        AllStats.campfiresSpawned += 1;

        campfire.SetActive(true);

        tileWaveNumber = Random.Range(0, 14);
        campfire.transform.SetParent(rockParent[tileWaveNumber]);

        Vector2 pos = new Vector2(Random.Range(77, -77), Random.Range(-1.5f, 1.5f));
        campfire.transform.localPosition = pos;
    }
    #endregion

    #region End session
    public void EndSession()
    {
        currentTime = 100;
    }
    #endregion

    #region Keep on mining, MAIN MENU
    public void KeepOnMining_MainMenu()
    {
        StartCoroutine(ScaleCircleCoroutine(true));
        pressEnding = false;
        StartCoroutine(ScaleCircleDownAgain(false));
    }
    #endregion

    #region Press endingBtn
    public GameObject tiles, xpFrame, timeFrame, materialFrame, potionsFrame, endSessionBtn;
    public GameObject bigRock, bigRockTiles;
    public static bool pressEnding, isInEnding;

    public void PressEndingBtn()
    {
        MainMenu.isInTheMine = false;
        MainMenu.isInArtifacts = false;
        MainMenu.isInTalents = false;
        MainMenu.isInTheAnvil = false;

        endingScript.SoundVolumeSet("MainMenuMusic", true, TheEnding.gameMusicFullVolume, 0f, 1f, true);

        bigRock.SetActive(true);
        bigRockTiles.SetActive(true);

        tiles.SetActive(false);
        xpFrame.SetActive(false);
        timeFrame.SetActive(false);
        materialFrame.SetActive(false);
        potionsFrame.SetActive(false);
        endSessionBtn.SetActive(false);

        pressEnding = true;
        isInEnding = true;

        StartCoroutine(ScaleCircleCoroutine(true));
        StartCoroutine(ScaleCircleDownAgain(false));

        SetStuffBackToObjectPool();
        ResetBetweenTransitions();
    }
    #endregion

    public void SetUiStuff()
    {
        oresPopedUp = false;

        bigRock.SetActive(false);
        bigRockTiles.SetActive(false);

        tiles.SetActive(true);
        xpFrame.SetActive(true);
        timeFrame.SetActive(true);
        materialFrame.SetActive(true);
        potionsFrame.SetActive(true);
        endSessionBtn.SetActive(true);
    }

    public void SetRandomHexColor(Image image)
    {
        string hex = GenerateRandomHexColor();
        Debug.Log("Random HEX: #" + hex);

        Color color;
        if (ColorUtility.TryParseHtmlString("#" + hex, out color))
        {
            image.color = color;
        }
        else
        {
            Debug.LogError("Failed to parse hex: #" + hex);
        }
    }

    private string GenerateRandomHexColor()
    {
        const string hexChars = "0123456789ABCDEF";
        string hex = "";

        for (int i = 0; i < 6; i++)
        {
            hex += hexChars[Random.Range(0, hexChars.Length)];
        }

        return hex;
    }

  
}
