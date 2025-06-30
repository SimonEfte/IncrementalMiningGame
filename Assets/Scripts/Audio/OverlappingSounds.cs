using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlappingSounds : MonoBehaviour
{
    public AudioSource pickaxeHitSource;
    public AudioClip pickaxeHitSound1, pickaxeHitSound2, pickaxeHitSound3;

    public AudioSource rockBreakSource;
    public AudioClip rockBreakSound1;

    public AudioClip chestHitSound;

    public AudioSource popSource;
    public AudioClip popSound1;

    public AudioSource beamSource;
    public AudioClip beamSound1;

    public int totalSounds, soundsPlaying;

    public static float theCurrentTime, currentTimeRockBreaking, currentCollectTime;

    private void Awake()
    {
        totalSounds = 24;
    }

    public void PlaySound(int soundNumber, float currentTime)
    {
        if (theCurrentTime == currentTime)
        {
            //Debug.Log("Same time " + currentTime);
            return;
        }

        theCurrentTime = currentTime;

        if (soundsPlaying >= totalSounds)
        {
            return;
        }

        soundsPlaying += 1;

        AudioClip clipToPlay = null;

        if (soundNumber == 1)
        {
            float randomPitch = Random.Range(0.82f, 1.08f);
            float randomVolume = Random.Range(0.54f, 0.62f);

            pickaxeHitSource.pitch = randomPitch;
           // pickaxeHitSource.volume = randomVolume;

            int randomSound = Random.Range(0,3);
            if(randomSound == 0) { clipToPlay = pickaxeHitSound1; }
            if (randomSound == 1) { clipToPlay = pickaxeHitSound2; }
            if (randomSound == 2) { clipToPlay = pickaxeHitSound3; }

            pickaxeHitSource.PlayOneShot(clipToPlay);
        }

        if (soundNumber == 3)
        {
            clipToPlay = chestHitSound;

            rockBreakSource.PlayOneShot(clipToPlay);
        }

        StartCoroutine(WaitForSoundToFinish(clipToPlay.length));
    }

    public void PlaySoundRockBreaking(int soundNumber, float currentTime)
    {
        if (currentTimeRockBreaking == currentTime)
        {
            return;
        }

        currentTimeRockBreaking = currentTime;

        if (soundsPlaying >= totalSounds)
        {
            return;
        }

        soundsPlaying += 1;

        AudioClip clipToPlay = null;

        if (soundNumber == 1)
        {
            clipToPlay = rockBreakSound1;

            rockBreakSource.PlayOneShot(clipToPlay);
        }

        StartCoroutine(WaitForSoundToFinish(clipToPlay.length));
    }

    public void PlaySoundMaterialCollect(int soundNumber, float currentTime)
    {
        if (currentCollectTime == currentTime)
        {
            return;
        }

        currentCollectTime = currentTime;

        if (soundsPlaying >= totalSounds)
        {
            //return;
        }

        AudioClip clipToPlay = null;

        if (soundNumber == 1)
        {
            clipToPlay = popSound1;

            float randomPitch = Random.Range(0.9f, 1.1f);

            popSource.pitch = randomPitch;

            popSource.PlayOneShot(clipToPlay);
        }
        if (soundNumber == 2)
        {
            clipToPlay = beamSound1;

            float randomPitch = Random.Range(1.21f, 1.3f);

            if (LevelMechanics.isZeusActive == false) { beamSource.PlayOneShot(clipToPlay); }
            else
            {
                int random = Random.Range(0,100);
                if(random < 35)
                {
                    beamSource.pitch = randomPitch;
                    beamSource.PlayOneShot(clipToPlay);
                }
            }
        }

        //StartCoroutine(WaitForSoundToFinish(clipToPlay.length));
    }

    private IEnumerator WaitForSoundToFinish(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        soundsPlaying -= 1;

        if(soundsPlaying < 0) { soundsPlaying = 0; }
    }
}
