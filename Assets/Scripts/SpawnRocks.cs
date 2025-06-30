using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocks : MonoBehaviour
{
    public SetRockScreen setRockScreeScript;

    //Upgrades done
    //Spawn more rocks = 9
    //All material rocks spawn = 35
    //Spawn rocks X sec/time = 12
    //More time = 6
    //More materials from rock = 5
    //Xp and talent ponts = 11
    //Materials worth more = 8
    //Improved pickaxe = 6
    //Bigger minig area = 6
    //Spawn pickaxe = 7
    //Lightning beam 11 
    //Dynamite = 8
    //Plazma balls = 8
    //Misc = 8

    //total 145
    //Max = 146

    public void SpawnRockXSecond()
    {
        if(spawnRockCoroutine != null) { StopCoroutine(spawnRockCoroutine); spawnRockCoroutine = StartCoroutine(SpawnRockWait()); }
        else
        {
            spawnRockCoroutine = StartCoroutine(SpawnRockWait());
        }
    }

    public static Coroutine spawnRockCoroutine;

    IEnumerator SpawnRockWait()
    {
        float waitTime = SkillTree.spawnXRockEveryXSecond;

        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            if (SetRockScreen.isInMiningSession == true)
            {
                int randomTile = Random.Range(0, 13);
                SetRockScreen.tileWaveNumber = randomTile;

                setRockScreeScript.SpawnRockCount(1);
            }
        }
    }

    public void SpawnRockDice()
    {
        if (Artifacts.ancientDice_found)
        {
            if (ancientDiceRockSpawn != null) { StopCoroutine(ancientDiceRockSpawn); ancientDiceRockSpawn = StartCoroutine(SpawnRock_Dice()); }
            else
            {
                ancientDiceRockSpawn = StartCoroutine(SpawnRock_Dice());
            }
        }
    }

    public static Coroutine ancientDiceRockSpawn;

    IEnumerator SpawnRock_Dice()
    {
        float waitTime = 1;

        while (true)
        {
            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                waitTime = 1 - (LevelMechanics.archeologistIncrease + Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { waitTime = (1 - LevelMechanics.archeologistIncrease); }
                if (Artifacts.rune_found) { waitTime = (1 - Artifacts.runeImproveAll); }
            }

            yield return new WaitForSeconds(waitTime);

            if (SetRockScreen.isInMiningSession == true)
            {
                int randomTile = Random.Range(0, 14);
                SetRockScreen.tileWaveNumber = randomTile;

                setRockScreeScript.SpawnRockCount(1);
            }
        }
    }
}
