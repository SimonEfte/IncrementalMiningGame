using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactIconsMechanics : MonoBehaviour
{
    bool startMoving;

    public Transform moveToHere;

    public GameObject horn_icon, ancientDevice_icon, bone_icon, meteorieOre_icon, book_icon, goldStack_icon, goldRing_icon, purpleRing_icon, ancientDice_icon, cheese_icon, wolfClaw_icon, axe_icon, rune_icon, skull_icon;

    public GameObject horn_stuck;
    public GameObject ancientDevice_stuck;
    public GameObject bone_stuck;
    public GameObject meteorieOre_stuck;
    public GameObject book_stuck;
    public GameObject goldStack_stuck;
    public GameObject goldRing_stuck;
    public GameObject purpleRing_stuck;
    public GameObject ancientDice_stuck;
    public GameObject cheese_stuck;
    public GameObject wolfClaw_stuck;
    public GameObject axe_stuck;
    public GameObject rune_stuck;
    public GameObject skull_stuck;

    private void OnEnable()
    {
        horn_icon.SetActive(false);
        ancientDevice_icon.SetActive(false);
        bone_icon.SetActive(false);
        meteorieOre_icon.SetActive(false);
        book_icon.SetActive(false);
        goldStack_icon.SetActive(false);
        goldRing_icon.SetActive(false);
        purpleRing_icon.SetActive(false);
        ancientDice_icon.SetActive(false);
        cheese_icon.SetActive(false);
        wolfClaw_icon.SetActive(false);
        axe_icon.SetActive(false);
        rune_icon.SetActive(false);
        skull_icon.SetActive(false);

        startMoving = false;
    }

    void Update()
    {
        if (Artifacts.minedRockWithArtifact == true && startMoving == false)
        {
            startMoving = true;

            // Deactivate all stuck versions
            horn_stuck.SetActive(false);
            ancientDevice_stuck.SetActive(false);
            bone_stuck.SetActive(false);
            meteorieOre_stuck.SetActive(false);
            book_stuck.SetActive(false);
            goldStack_stuck.SetActive(false);
            goldRing_stuck.SetActive(false);
            purpleRing_stuck.SetActive(false);
            ancientDice_stuck.SetActive(false);
            cheese_stuck.SetActive(false);
            wolfClaw_stuck.SetActive(false);
            axe_stuck.SetActive(false);
            rune_stuck.SetActive(false);
            skull_stuck.SetActive(false);

            // Activate icons based on spawn flags
            if (Artifacts.horn_spawned) horn_icon.SetActive(true);
            if (Artifacts.ancientDevice_spawned) ancientDevice_icon.SetActive(true);
            if (Artifacts.bone_spawned) bone_icon.SetActive(true);
            if (Artifacts.meteorieOre_spawned) meteorieOre_icon.SetActive(true);
            if (Artifacts.book_spawned) book_icon.SetActive(true);
            if (Artifacts.goldStack_spawned) goldStack_icon.SetActive(true);
            if (Artifacts.goldRing_spawned) goldRing_icon.SetActive(true);
            if (Artifacts.purpleRing_spawned) purpleRing_icon.SetActive(true);
            if (Artifacts.ancientDice_spawned) ancientDice_icon.SetActive(true);
            if (Artifacts.cheese_spawned) cheese_icon.SetActive(true);
            if (Artifacts.wolfClaw_spawned) wolfClaw_icon.SetActive(true);
            if (Artifacts.axe_spawned) axe_icon.SetActive(true);
            if (Artifacts.rune_spawned) rune_icon.SetActive(true);
            if (Artifacts.skull_spawned) skull_icon.SetActive(true);

            StartCoroutine(MoveArtifact());
        }   
    }

    IEnumerator MoveArtifact()
    {
        yield return new WaitForSeconds(0.5f);

        float moveStartTime = Time.time;
        float moveDuration = 0.5f;

        if(SetRockScreen.timeLeft < 3)
        {
            moveDuration = 0.2f;
        }

        Vector3 startPos = transform.position;
        Vector3 endPos = moveToHere.transform.position;

        while (Time.time < moveStartTime + moveDuration)
        {
            float t = (Time.time - moveStartTime) / moveDuration;
            transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        transform.position = endPos;

        // Start scale animation
        yield return StartCoroutine(ScaleArtifact(transform));
    }

    IEnumerator ScaleArtifact(Transform target)
    {
        Vector3 originalScale = target.localScale;
        Vector3 scaleUp = Vector3.one * 0.7f;
        Vector3 scaleDown = Vector3.one * 0.6f;

        // Scale up to 0.7 in 0.2s
        float t = 0f;
        while (t < 0.2f)
        {
            target.localScale = Vector3.Lerp(originalScale, scaleUp, t / 0.2f);
            t += Time.deltaTime;
            yield return null;
        }
        target.localScale = scaleUp;

        // Scale down to 0.6 in 0.1s
        t = 0f;
        while (t < 0.1f)
        {
            target.localScale = Vector3.Lerp(scaleUp, scaleDown, t / 0.1f);
            t += Time.deltaTime;
            yield return null;
        }
        target.localScale = scaleDown;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

}
