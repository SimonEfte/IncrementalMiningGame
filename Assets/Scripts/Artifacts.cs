using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Artifacts : MonoBehaviour, IDataPersistence
{
    public AudioManager audioManager;
    public Tutorial tutorialScript;

    public GameObject horn_StageIcon, ancientDevice_stageIcon, bone_stageIcon, meteorieOre_stageIcon, book_stageIcon, goldStack_stageIcon, goldRing_stageIcon, purpleRing_stageIcon, ancientDice_stageIcon, cheese_stageIcon, wolfClaw_stageIcon, axe_stageIcon, rune_stageIcon, skullStageIcon;

    public GameObject horn_frameIcon, ancientDevice_frameIcon, bone_frameIcon, meteorieOre_frameIcon, book_frameIcon, goldStack_frameIcon, goldRing_frameIcon, purpleRing_frameIcon, ancientDice_frameIcon, cheese_frameIcon, wolfClaw_frameIcon, axe_frameIcon, rune_frameIcon, skull_frameIcon;

    public GameObject horn_shadow, ancientDevice_shadow, bone_shadow, meteorieOre_shadow, book_shadow, goldStack_shadow, goldRing_shadow, purpleRing_shadow, ancientDice_shadow, cheese_shadow, wolfClaw_shadow, axe_shadow, rune_shadow, skull_shadow;

    public GameObject horn_Excl, ancientDevice_Excl, bone_Excl, meteorieOre_Excl, book_Excl, goldStack_Excl, goldRing_Excl, purpleRing_Excl, ancientDice_Excl, cheese_Excl, wolfClaw_Excl, axe_Excl, rune_Excl, skull_Excl;

    public static int artifactsFound;
    public static bool horn_found, ancientDevice_found, bone_found, meteorieOre_found, book_found, goldStack_found, goldRing_found, purpleRing_found, ancientDice_found, cheese_found, wolfClaw_found, axe_found, rune_found, skull_found;

    public static bool horn_spawned, ancientDevice_spawned, bone_spawned, meteorieOre_spawned, book_spawned, goldStack_spawned, goldRing_spawned, purpleRing_spawned, ancientDice_spawned, cheese_spawned, wolfClaw_spawned, axe_spawned, rune_spawned, skull_spawned;

    public static bool oneArtifactSpawned, oneArtifactMined;

    public SpawnProjectiles spawnProjectilesScript;

    public static float horn_spawnChance;
    public static float ancientDevice_spawnChance;
    public static float bone_spawnChance;
    public static float meteorieOre_spawnChance;
    public static float book_spawnChance;
    public static float goldStack_spawnChance;
    public static float goldRing_spawnChance;
    public static float purpleRing_spawnChance;
    public static float ancientDice_spawnChance;
    public static float cheese_spawnChance;
    public static float wolfClaw_spawnChance;
    public static float axe_spawnChance;
    public static float rune_spawnChance;
    public static float skull_spawnChance;

    public static bool minedRockWithArtifact;

    public static float wolfClawPickaxePowerIncrease;

    public static float runeImproveAll;
    public static float goldRingCraftChance;
    public static float hornRockDecrease;
    public static float ancientDeviceTimeReduction;
    public static float bonePickaxeIncrease;
    public static float meteoriteRockSpawnIncrease;
    public static float purpleRingChance;
    public static float cheeseChance;
    public static float clawChance;
    public static float runeIncrease_forDisplay;

    private void Start()
    {
        SetArtifactChances();

        runeImproveAll = 0f;
        wolfClawPickaxePowerIncrease = 0;

        goldRingCraftChance = 1.2f;

        hornRockDecrease = 0.03f;
        ancientDeviceTimeReduction = 0.05f;
        bonePickaxeIncrease = 0.02f;
        meteoriteRockSpawnIncrease = 0.03f;
        purpleRingChance = 4f;
        cheeseChance = 0.2f;
        clawChance = 0.06f;
        runeIncrease_forDisplay = 5f;

        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        if (horn_found == true) { horn_StageIcon.SetActive(true); horn_shadow.SetActive(true);  }
        if (ancientDevice_found == true) { ancientDevice_stageIcon.SetActive(true); ancientDevice_shadow.SetActive(true); }
        if (bone_found == true) { bone_stageIcon.SetActive(true);  bone_shadow.SetActive(true); }
        if (meteorieOre_found == true) { meteorieOre_stageIcon.SetActive(true); meteorieOre_shadow.SetActive(true); }
        if (book_found == true) { book_stageIcon.SetActive(true); book_shadow.SetActive(true); }
        if (goldStack_found == true) { goldStack_stageIcon.SetActive(true); goldStack_shadow.SetActive(true);  }
        if (goldRing_found == true) { goldRing_stageIcon.SetActive(true); goldRing_shadow.SetActive(true); }
        if (purpleRing_found == true) { purpleRing_stageIcon.SetActive(true); purpleRing_shadow.SetActive(true); }
        if (ancientDice_found == true) { ancientDice_stageIcon.SetActive(true);  ancientDice_shadow.SetActive(true); }
        if (cheese_found == true) { cheese_stageIcon.SetActive(true); cheese_shadow.SetActive(true); }
        if (wolfClaw_found == true) { wolfClaw_stageIcon.SetActive(true); wolfClaw_shadow.SetActive(true); }
        if (axe_found == true) { axe_stageIcon.SetActive(true); axe_shadow.SetActive(true); }
        if (rune_found == true) { rune_stageIcon.SetActive(true); rune_shadow.SetActive(true); }
        if (skull_found == true) { skullStageIcon.SetActive(true); skull_shadow.SetActive(true); }
    }

    public void SetArtifactChances()
    {
        //Ranked based on how good they are
        skull_spawnChance = 0.026f;
        bone_spawnChance = 0.012f;
        goldStack_spawnChance = 0.007f;
        book_spawnChance = 0.0015f;
        ancientDice_spawnChance = 0.0008f;
        purpleRing_spawnChance = 0.00027f;
        axe_spawnChance = 0.00003f;
        wolfClaw_spawnChance = 0.0000076f;
        ancientDevice_spawnChance = 0.0000043f;
        horn_spawnChance = 0.000004f;
        meteorieOre_spawnChance = 0.0000008f;
        goldRing_spawnChance = 0.00000016f;
        cheese_spawnChance = 0.00000016f;
        rune_spawnChance = 0.00000016f;

        #region x marks the spot increase
        if (LevelMechanics.xMarksTheSpor_chosen)
        {
            horn_spawnChance *= 1.02f;
            ancientDevice_spawnChance *= 1.02f;
            bone_spawnChance *= 1.02f;
            meteorieOre_spawnChance *= 1.02f;
            book_spawnChance *= 1.02f;
            goldStack_spawnChance *= 1.02f;
            goldRing_spawnChance *= 1.02f; ;
            purpleRing_spawnChance *= 1.02f;
            ancientDice_spawnChance *= 1.02f;
            cheese_spawnChance *= 1.02f;
            wolfClaw_spawnChance *= 1.02f;
            axe_spawnChance *= 1.02f;
            rune_spawnChance *= 1.02f;
            skull_spawnChance *= 1.02f;
        }
        #endregion

        #region explorer increaser
        if (LevelMechanics.explorer_chosen)
        {
            horn_spawnChance *= 1.02f;
            ancientDevice_spawnChance *= 1.02f;
            bone_spawnChance *= 1.02f;
            meteorieOre_spawnChance *= 1.02f;
            book_spawnChance *= 1.02f;
            goldStack_spawnChance *= 1.02f;
            goldRing_spawnChance *= 1.02f; ;
            purpleRing_spawnChance *= 1.02f;
            ancientDice_spawnChance *= 1.02f;
            cheese_spawnChance *= 1.02f;
            wolfClaw_spawnChance *= 1.02f;
            axe_spawnChance *= 1.02f;
            rune_spawnChance *= 1.02f;
            skull_spawnChance *= 1.02f;
        }
        #endregion
    }

    public void ArtifactDropChances()
    {
        #region Horn spawn chance
        if (horn_found == false && oneArtifactSpawned == false)
        {
            float randomHornChance = Random.Range(0f, 100f);
            if (randomHornChance < horn_spawnChance)
            {
                Debug.Log("Horn");
                oneArtifactSpawned = true;
                horn_spawned = true;
            }
        }
        #endregion

        #region Ancient Device spawn chance
        if (ancientDevice_found == false && oneArtifactSpawned == false)
        {
            float randomChance = Random.Range(0f, 100f);
            if (randomChance < ancientDevice_spawnChance)
            {
                Debug.Log("Ancient Device");
                oneArtifactSpawned = true;
                ancientDevice_spawned = true;
            }
        }
        #endregion

        #region Bone spawn chance
        if (bone_found == false && oneArtifactSpawned == false)
        {
            float randomChance = Random.Range(0f, 100f);
            if (randomChance < bone_spawnChance)
            {
                Debug.Log("Bone");
                oneArtifactSpawned = true;
                bone_spawned = true;
            }
        }
        #endregion

        #region Meteorite Ore spawn chance
        if (meteorieOre_found == false && oneArtifactSpawned == false)
        {
            float randomChance = Random.Range(0f, 100f);
            if (randomChance < meteorieOre_spawnChance)
            {
                Debug.Log("Meteorite Ore");
                oneArtifactSpawned = true;
                meteorieOre_spawned = true;
            }
        }
        #endregion

        #region Book spawn chance
        if (book_found == false && oneArtifactSpawned == false)
        {
            float randomChance = Random.Range(0f, 100f);
            if (randomChance < book_spawnChance)
            {
                Debug.Log("Book");
                oneArtifactSpawned = true;
                book_spawned = true;
            }
        }
        #endregion

        #region Gold Stack spawn chance
        if (goldStack_found == false && oneArtifactSpawned == false)
        {
            float randomChance = Random.Range(0f, 100f);
            if (randomChance < goldStack_spawnChance)
            {
                Debug.Log("Gold Stack");
                oneArtifactSpawned = true;
                goldStack_spawned = true;
            }
        }
        #endregion

        #region Gold Ring spawn chance
        if (goldRing_found == false && oneArtifactSpawned == false)
        {
            float randomChance = Random.Range(0f, 100f);
            if (randomChance < goldRing_spawnChance)
            {
                Debug.Log("Gold Ring");
                oneArtifactSpawned = true;
                goldRing_spawned = true;
            }
        }
        #endregion

        #region Purple Ring spawn chance
        if (purpleRing_found == false && oneArtifactSpawned == false)
        {
            float randomChance = Random.Range(0f, 100f);
            if (randomChance < purpleRing_spawnChance)
            {
                Debug.Log("Purple Ring");
                oneArtifactSpawned = true;
                purpleRing_spawned = true;
            }
        }
        #endregion

        #region Ancient Dice spawn chance
        if (ancientDice_found == false && oneArtifactSpawned == false)
        {
            float randomChance = Random.Range(0f, 100f);
            if (randomChance < ancientDice_spawnChance)
            {
                Debug.Log("Ancient Dice");
                oneArtifactSpawned = true;
                ancientDice_spawned = true;
            }
        }
        #endregion

        #region Cheese spawn chance
        if (cheese_found == false && oneArtifactSpawned == false)
        {
            float randomChance = Random.Range(0f, 100f);
            if (randomChance < cheese_spawnChance)
            {
                Debug.Log("Cheese");
                oneArtifactSpawned = true;
                cheese_spawned = true;
            }
        }
        #endregion

        #region Wolf Claw spawn chance
        if (wolfClaw_found == false && oneArtifactSpawned == false)
        {
            float randomChance = Random.Range(0f, 100f);
            if (randomChance < wolfClaw_spawnChance)
            {
                Debug.Log("Wolf Claw");
                oneArtifactSpawned = true;
                wolfClaw_spawned = true;
            }
        }
        #endregion

        #region Axe spawn chance
        if (axe_found == false && oneArtifactSpawned == false)
        {
            float randomChance = Random.Range(0f, 100f);
            if (randomChance < axe_spawnChance)
            {
                Debug.Log("Axe");
                oneArtifactSpawned = true;
                axe_spawned = true;
            }
        }
        #endregion

        #region Rune spawn chance
        if (rune_found == false && oneArtifactSpawned == false)
        {
            float randomChance = Random.Range(0f, 100f);
            if (randomChance < rune_spawnChance)
            {
                Debug.Log("Rune");
                oneArtifactSpawned = true;
                rune_spawned = true;
            }
        }
        #endregion

        #region Skull spawn chance
        if (skull_found == false && oneArtifactSpawned == false)
        {
            float randomChance = Random.Range(0f, 100f);
            if (randomChance < skull_spawnChance)
            {
                Debug.Log("Skull");
                oneArtifactSpawned = true;
                skull_spawned = true;
            }
        }
        #endregion

        if(oneArtifactSpawned == true)
        {
            spawnProjectilesScript.SelectRandomActiveRock(7);
        }
    }

    public void CheckFoundArtifacts()
    {
        if (horn_found) { horn_StageIcon.SetActive(true); }
        if (ancientDevice_found) { ancientDevice_stageIcon.SetActive(true); }
        if (bone_found) { bone_stageIcon.SetActive(true); }
        if (meteorieOre_found) { meteorieOre_stageIcon.SetActive(true); }
        if (book_found) { book_stageIcon.SetActive(true); }
        if (goldStack_found) { goldStack_stageIcon.SetActive(true); }
        if (goldRing_found) { goldRing_stageIcon.SetActive(true); }
        if (purpleRing_found) { purpleRing_stageIcon.SetActive(true); }
        if (ancientDice_found) { ancientDice_stageIcon.SetActive(true); }
        if (cheese_found) { cheese_stageIcon.SetActive(true); }
        if (wolfClaw_found) { wolfClaw_stageIcon.SetActive(true); wolfClawPickaxePowerIncrease = 0.06f; }
        if (axe_found) { axe_stageIcon.SetActive(true); }
        if (rune_found) { rune_stageIcon.SetActive(true); }
        if (skull_found) { skullStageIcon.SetActive(true); }
    }

    public GameObject artifactFoundFrame;
    public GameObject artifactOkBtn;
    public ParticleSystem artifactParticle;

    public string artifactFound, artifactName;

    public TextMeshProUGUI artifactFoundText;

    public GameObject artifactBtnExcl;

    public void SetArtifactFrame(int artifactNumber)
    {
        if(Tutorial.pressedOkArtifact == false) { tutorialScript.SetTutorial(5); }

        artifactBtnExcl.SetActive(true);

        horn_frameIcon.SetActive(false);
        ancientDevice_frameIcon.SetActive(false);
        bone_frameIcon.SetActive(false);
        meteorieOre_frameIcon.SetActive(false);
        book_frameIcon.SetActive(false);
        goldStack_frameIcon.SetActive(false);
        goldRing_frameIcon.SetActive(false);
        purpleRing_frameIcon.SetActive(false);
        ancientDice_frameIcon.SetActive(false);
        cheese_frameIcon.SetActive(false);
        wolfClaw_frameIcon.SetActive(false);
        axe_frameIcon.SetActive(false);
        rune_frameIcon.SetActive(false);
        skull_frameIcon.SetActive(false);

        artifactFound = "Artifact found!\n";

        //StartCoroutine(ArtiFactOkButton());
        artifactOkBtn.SetActive(true);
        artifactFoundFrame.SetActive(true);

        artifactParticle.Play();

        if (artifactNumber == 1) { horn_frameIcon.SetActive(true); artifactName = "Ox Horn"; horn_shadow.SetActive(true); horn_Excl.SetActive(true); }
        if (artifactNumber == 2) { ancientDevice_frameIcon.SetActive(true); artifactName = "Ancient Device"; ancientDevice_shadow.SetActive(true); ancientDevice_Excl.SetActive(true); }
        if (artifactNumber == 3) { bone_frameIcon.SetActive(true); artifactName = "Fossilized Bone"; bone_shadow.SetActive(true); bone_Excl.SetActive(true); }
        if (artifactNumber == 4) { meteorieOre_frameIcon.SetActive(true); artifactName = "Meteorite Ore"; meteorieOre_shadow.SetActive(true); meteorieOre_Excl.SetActive(true); }
        if (artifactNumber == 5) { book_frameIcon.SetActive(true); artifactName = "Magic Book"; book_shadow.SetActive(true); book_Excl.SetActive(true); }
        if (artifactNumber == 6) { goldStack_frameIcon.SetActive(true); artifactName = "Sack of Gold"; goldStack_shadow.SetActive(true); goldStack_Excl.SetActive(true); }
        if (artifactNumber == 7) { goldRing_frameIcon.SetActive(true); artifactName = "Gold Ring"; goldRing_shadow.SetActive(true); goldRing_Excl.SetActive(true); }
        if (artifactNumber == 8) { purpleRing_frameIcon.SetActive(true); artifactName = "Royal Ring"; purpleRing_shadow.SetActive(true); purpleRing_Excl.SetActive(true); }
        if (artifactNumber == 9) { ancientDice_frameIcon.SetActive(true); artifactName = "Ancient Dice"; ancientDice_shadow.SetActive(true); ancientDice_Excl.SetActive(true); }
        if (artifactNumber == 10) { cheese_frameIcon.SetActive(true); artifactName = "Cheese"; cheese_shadow.SetActive(true); cheese_Excl.SetActive(true); }
        if (artifactNumber == 11) { wolfClaw_frameIcon.SetActive(true); artifactName = "Wolf Claw"; wolfClaw_shadow.SetActive(true); wolfClaw_Excl.SetActive(true); }
        if (artifactNumber == 12) { axe_frameIcon.SetActive(true); artifactName = "Warrior's Axe"; axe_shadow.SetActive(true); axe_Excl.SetActive(true); }
        if (artifactNumber == 13) { rune_frameIcon.SetActive(true); artifactName = "Runestone"; rune_shadow.SetActive(true); rune_Excl.SetActive(true); }
        if (artifactNumber == 14) { skull_frameIcon.SetActive(true); artifactName = "Warrior's Skull"; skull_shadow.SetActive(true); skull_Excl.SetActive(true); }

        artifactFoundText.text = artifactFound + artifactName;
    }

    IEnumerator ArtiFactOkButton()
    {
        yield return new WaitForSeconds(0.5f);
        artifactOkBtn.SetActive(true);
    }

    public void PressOkArtifact()
    {
        audioManager.Play("UI_Click1");

        artifactOkBtn.SetActive(false);
        artifactFoundFrame.SetActive(false);
    }

    #region Load Data
    public void LoadData(GameData data)
    {
        artifactsFound = data.artifactsFound;

        horn_found = data.horn_found;
        ancientDevice_found = data.ancientDevice_found;
        bone_found = data.bone_found;
        meteorieOre_found = data.meteorieOre_found;
        book_found = data.book_found;
        goldStack_found = data.goldStack_found;
        goldRing_found = data.goldRing_found;
        purpleRing_found = data.purpleRing_found;
        ancientDice_found = data.ancientDice_found;
        cheese_found = data.cheese_found;
        wolfClaw_found = data.wolfClaw_found;
        axe_found = data.axe_found;
        rune_found = data.rune_found;
        skull_found = data.skull_found;
    }
    #endregion

    #region Save Data
    public void SaveData(ref GameData data)
    {
        data.artifactsFound = artifactsFound;

        data.horn_found = horn_found;
        data.ancientDevice_found = ancientDevice_found;
        data.bone_found = bone_found;
        data.meteorieOre_found = meteorieOre_found;
        data.book_found = book_found;
        data.goldStack_found = goldStack_found;
        data.goldRing_found = goldRing_found;
        data.purpleRing_found = purpleRing_found;
        data.ancientDice_found = ancientDice_found;
        data.cheese_found = cheese_found;
        data.wolfClaw_found = wolfClaw_found;
        data.axe_found = axe_found;
        data.rune_found = rune_found;
        data.skull_found = skull_found;
    }
    #endregion

    public void ResetArtifacts()
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

        horn_StageIcon.SetActive(false); horn_shadow.SetActive(false);
        ancientDevice_stageIcon.SetActive(false); ancientDevice_shadow.SetActive(false);
        bone_stageIcon.SetActive(false); bone_shadow.SetActive(false);
        meteorieOre_stageIcon.SetActive(false); meteorieOre_shadow.SetActive(false);
        book_stageIcon.SetActive(false); book_shadow.SetActive(false);
        goldStack_stageIcon.SetActive(false); goldStack_shadow.SetActive(false);
        goldRing_stageIcon.SetActive(false); goldRing_shadow.SetActive(false);
        purpleRing_stageIcon.SetActive(false); purpleRing_shadow.SetActive(false);
        ancientDice_stageIcon.SetActive(false); ancientDice_shadow.SetActive(false);
        cheese_stageIcon.SetActive(false); cheese_shadow.SetActive(false);
        wolfClaw_stageIcon.SetActive(false); wolfClaw_shadow.SetActive(false);
        axe_stageIcon.SetActive(false); axe_shadow.SetActive(false);
        rune_stageIcon.SetActive(false); rune_shadow.SetActive(false);
        skullStageIcon.SetActive(false); skull_shadow.SetActive(false);
    } 
}
