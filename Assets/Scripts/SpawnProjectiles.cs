using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour
{
    public static List<GameObject> rockArray = new List<GameObject>();

    public GameObject allArtifactsParent, originalAritfactParent;

    public GameObject horn_icon, ancientDevice_icon, bone_icon, meteorieOre_icon, book_icon, goldStack_icon, goldRing_icon, purpleRing_icon, ancientDice_icon, cheese_icon, wolfClaw_icon, axe_icon, rune_icon, skull_icon;

    public static Vector2 artifactPos;

    public OverlappingSounds overlappingScript;

    public static int totalDynamitesOnScreen, totalBeamsOnScreen;

    #region add rock array
    public static void AddRock(GameObject rock)
    {
        if (!rockArray.Contains(rock))
        {
            rockArray.Add(rock);
        }
    }
    #endregion

    #region Check random rock
    public static int totalRocksActive;

    public void SelectRandomActiveRock(int projectileType)
    {
        var activeRocks = new List<GameObject>();
        foreach (var rock in rockArray)
        {
            if (rock != null && rock.activeSelf)
            {
                activeRocks.Add(rock);
            }
        }

        totalRocksActive = activeRocks.Count;

        if (activeRocks.Count > 0)
        {
            int randomIndex = Random.Range(0, activeRocks.Count);
            GameObject selectedRock = activeRocks[randomIndex];

            if(projectileType == 1 && SetRockScreen.isInMiningSession == true)
            {
                if(SetRockScreen.isInEnding == false)
                {
                    plazmaStartPos = selectedRock.transform.position;
                    GameObject plazmaBall = ObjectPool.instance.GetPlazmaBallFromPool();

                    float randomSize = Random.Range(0.8f * SkillTree.plazmaBallTotalSize, 0.9f * SkillTree.plazmaBallTotalSize);
                    plazmaBall.transform.localScale = new Vector3(randomSize, randomSize, randomSize);

                    plazmaBall.transform.position = plazmaStartPos;
                    StartCoroutine(ScaleObject(plazmaBall, randomSize));

                    AllStats.plazmaBallsSpawned += 1;
                }
            }
            else if (projectileType == 2 && SetRockScreen.isInMiningSession == true)
            {
                GameObject beam = ObjectPool.instance.GetBeamOfLightFromPool();

                float currentTime = Time.time;
                overlappingScript.PlaySoundMaterialCollect(2, currentTime);

                float originalSize = 7.2f;
                float size = originalSize * SkillTree.lightningSize;

                beam.transform.localScale = new Vector3(size, size, size);
                beam.tag = "Beam_S";
                beam.transform.position = selectedRock.transform.position;

                AllStats.lightningStrikes += 1;
                totalBeamsOnScreen += 1;
            }
            else if(projectileType == 3 && SetRockScreen.isInMiningSession == true)
            {
                GameObject pickaxe = ObjectPool.instance.GetPickaxeFromPool();
                Vector2 pos = selectedRock.transform.position;
                //pickaxe.transform.position = pos;

                float rock_xPos = 0;
                float rock_yPos = 0;

                int randomSwing = Random.Range(1, 3);

                if (randomSwing == 1)
                {
                    pickaxe.layer = 6;
                    rock_xPos = pos.x - 0.22f;
                    rock_yPos = pos.y + 0.22f;
                }
                else
                {
                    pickaxe.layer = 11;
                    rock_xPos = pos.x + 0.22f;
                    rock_yPos = pos.y + 0.22f;
                }

                pickaxe.transform.localScale = new Vector2(1, 1);
                pickaxe.transform.position = new Vector2(rock_xPos, rock_yPos);
            }
            else if(projectileType == 4 && SetRockScreen.isInMiningSession == true)
            {
                float currentTime = Time.time;
                overlappingScript.PlaySoundMaterialCollect(2, currentTime);

                GameObject beam = ObjectPool.instance.GetBeamOfLightFromPool();

                float originalSize = 6f;
                float size = originalSize * SkillTree.lightningSize;

                beam.transform.localScale = new Vector3(size, size, size);
                beam.tag = "Beam_PH";
                beam.transform.position = RockMechanics.beamHitPos;

                totalBeamsOnScreen += 1;
                AllStats.lightningStrikes += 1;
            }
            else if(projectileType == 5 && SetRockScreen.isInMiningSession == true)
            {
                GameObject dynamite = ObjectPool.instance.GetDynamiteFromPool();
                dynamite.tag = "Dynamite";
                dynamite.transform.position = RockMechanics.dynamiteHitPos;

                AllStats.dynamiteExplosions += 1;
                totalDynamitesOnScreen += 1;
            }
            else if (projectileType == 6 && SetRockScreen.isInMiningSession == true)
            {
                float currentTime = Time.time;
                overlappingScript.PlaySoundMaterialCollect(2, currentTime);

                GameObject beam = ObjectPool.instance.GetBeamOfLightFromPool();

                float originalSize = 6f;
                float size = originalSize * SkillTree.lightningSize;

                beam.transform.localScale = new Vector3(size, size, size);
                beam.tag = "Beam_PH";
                beam.transform.position = selectedRock.transform.position;

                AllStats.lightningStrikes += 1;
                totalBeamsOnScreen += 1;
            }
            else if (projectileType == 7)
            {
                //Debug.Log(activeRocks.Count);
                //allArtifactsParent.transform.SetParent(originalAritfactParent.transform);

                horn_icon.SetActive(false); ancientDevice_icon.SetActive(false); bone_icon.SetActive(false); meteorieOre_icon.SetActive(false);
                book_icon.SetActive(false); goldStack_icon.SetActive(false); goldRing_icon.SetActive(false); purpleRing_icon.SetActive(false);
                ancientDice_icon.SetActive(false); cheese_icon.SetActive(false); wolfClaw_icon.SetActive(false); axe_icon.SetActive(false);
                rune_icon.SetActive(false); skull_icon.SetActive(false);

                //Set artifact as a child to a rock
                allArtifactsParent.transform.SetParent(selectedRock.transform);
                artifactPos = selectedRock.transform.position;
                allArtifactsParent.transform.localScale = new Vector2(0.02f, 0.02f);
                allArtifactsParent.transform.localPosition = new Vector2(0f,0f);
                allArtifactsParent.SetActive(true);

                StartCoroutine(CheckRockScale(selectedRock));
            }
        }
        else
        {
            //Debug.Log("No active rocks found.");
        }
    }
    IEnumerator CheckRockScale(GameObject rock)
    {
        while (rock.gameObject.transform.localScale.x > 0.15f && SetRockScreen.isInMiningSession == false)
        {
            yield return null;
        }

        if (Artifacts.horn_spawned) horn_icon.SetActive(true);
        else if (Artifacts.ancientDevice_spawned) ancientDevice_icon.SetActive(true);
        else if (Artifacts.bone_spawned) bone_icon.SetActive(true);
        else if (Artifacts.meteorieOre_spawned) meteorieOre_icon.SetActive(true);
        else if (Artifacts.book_spawned) book_icon.SetActive(true);
        else if (Artifacts.goldStack_spawned) goldStack_icon.SetActive(true);
        else if (Artifacts.goldRing_spawned) goldRing_icon.SetActive(true);
        else if (Artifacts.purpleRing_spawned) purpleRing_icon.SetActive(true);
        else if (Artifacts.ancientDice_spawned) ancientDice_icon.SetActive(true);
        else if (Artifacts.cheese_spawned) cheese_icon.SetActive(true);
        else if (Artifacts.wolfClaw_spawned) wolfClaw_icon.SetActive(true);
        else if (Artifacts.axe_spawned) axe_icon.SetActive(true);
        else if (Artifacts.rune_spawned) rune_icon.SetActive(true);
        else if (Artifacts.skull_spawned) skull_icon.SetActive(true);
    }

    public int GetRockIndex(GameObject rock)
    {
        if (rock == null)
        {
            Debug.LogError("Rock is null. Cannot find index.");
            return -1;
        }

        int index = rockArray.IndexOf(rock);
        if (index == -1)
        {
            Debug.LogWarning("The provided rock is not in the list.");
        }
        return index;
    }
    #endregion

    public Vector2 plazmaStartPos;
    public Coroutine plazmaBallTimerCorutine;

    public void SpawnPlazmaBalls()
    {
        if(plazmaBallTimerCorutine == null) { plazmaBallTimerCorutine = StartCoroutine(PlazmaBallTimer()); }
        else { StopCoroutine(plazmaBallTimerCorutine); plazmaBallTimerCorutine = StartCoroutine(PlazmaBallTimer()); }
    }

    IEnumerator PlazmaBallTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            float chanceIncrease = 1;
            bool isIncreaseChance = false;
            if (SkillTree.allProjectileTriggerChance_purchased)
            {
                isIncreaseChance = true;
            }
            if (isIncreaseChance == true) { chanceIncrease = 1 + (SkillTree.allProjcetileTriggerChance / 100); }

            if (SetRockScreen.isInMiningSession)
            {
                int random = Random.Range(0, 100);
                if (random < (SkillTree.plazmaBallChance * chanceIncrease)) { SelectRandomActiveRock(1); }
            }
        }
    }

    #region Spawn pickaxe every X second
    public void SpawnPickaxe()
    {
        if(spawnPickaxeCorotuine == null) { spawnPickaxeCorotuine = StartCoroutine(PickaxeTimer()); }
        else { StopCoroutine(spawnPickaxeCorotuine); spawnPickaxeCorotuine = StartCoroutine(PickaxeTimer()); }
    }

    public Coroutine spawnPickaxeCorotuine;

    IEnumerator PickaxeTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(SkillTree.spawnPickaxeEverySecond);

            if (SetRockScreen.isInMiningSession == true)
            {
                SelectRandomActiveRock(3);
            }
        }
    }
    #endregion

    #region Spawn beam of lightning per S
    public void SpawnLightningS()
    {
        if (spawnLightningCoroutine == null) { spawnLightningCoroutine = StartCoroutine(LightningBeamTimer()); }
        else { StopCoroutine(spawnLightningCoroutine); spawnLightningCoroutine = StartCoroutine(LightningBeamTimer()); }
    }

    public Coroutine spawnLightningCoroutine;

    IEnumerator LightningBeamTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            float random = Random.Range(0,100);

            float chanceIncrease = 1;
            bool isIncreaseChance = false;
            if (SkillTree.allProjectileTriggerChance_purchased)
            {
                isIncreaseChance = true;
            }
            if (isIncreaseChance == true) { chanceIncrease = 1 + (SkillTree.allProjcetileTriggerChance / 100); }

            if (random < (SkillTree.lightningTriggerChanceS * chanceIncrease))
            {
                if (SetRockScreen.isInMiningSession == true || SetRockScreen.isInEnding)
                {
                    SelectRandomActiveRock(2);
                }
            }
        }
    }
    #endregion

    #region Scale up
    IEnumerator ScaleObject(GameObject objectToScale, float scaleToSize)
    {
        float duration = 0.2f;
        float elapsedTime = 0f;

        Vector3 startScale = Vector3.zero;
        Vector3 endScale = Vector3.one * scaleToSize;

        while (elapsedTime < duration)
        {
            objectToScale.transform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectToScale.transform.localScale = endScale;
    }
    #endregion

    public void ResetSpanwProjeciles()
    {
        StopAllCoroutines();
    }
}
