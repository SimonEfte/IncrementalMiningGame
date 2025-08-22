using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MineMaterialMechanics : MonoBehaviour
{
    public GoldAndOreMechanics goldScript;

    public bool isMinePopUp, isRocksMaterialPopUp;

    private Transform goldBar,copperBar, ironBar, cobaltBar, uraniumBar, ismiumBar, iridiumBar, painiteBar;

    public Transform goldOre, copperOre, ironOre, cobaltOre, uraniumOre, ismiumOre, iridiumOre, painiteOre;

    //Mining session
    public GameObject goldOreFrame, copperOreFrame, ironOreFrame, cobaltOreFrame, uraniumOreFrame, ismiumOreFrame, iridiumOreFrame, painiteOreFrame;

    //The Mine
    public GameObject totalGoldFrame, totalCopperFrame, totalIronFrame, totalCobaltFrame, totalUraniumFrame, totalIsmiumFrame, totalIridiumFrame, totalPainiteFrame;

    public static int totalTextsOnScreen;

    bool isReturned;

    bool isGoldOre, isCopperOre, isIronOre, isCobaltOre, isUraniumOre, isIsmiumOre, isIridumOre, isPainiteOre;
    bool isGoldBar, isCopperBar, isIronBar, isCobaltBar, isUraniumBar, isIsmiumBar, isIridumBar, isPainiteBar;

    public OverlappingSounds overlappingScript;

    private void Awake()
    {
        GameObject overlappingObject = GameObject.Find("OverlappingSounds");
        overlappingScript = overlappingObject.GetComponent<OverlappingSounds>();

        if (isMinePopUp == true)
        {
            goldBar = transform.Find("goldBar");
            copperBar = transform.Find("copperBar");
            ironBar = transform.Find("ironBar");
            cobaltBar = transform.Find("cobaltBar");
            uraniumBar = transform.Find("uraniumBar");
            ismiumBar = transform.Find("ismiumBar");
            iridiumBar = transform.Find("iridiumBar");
            painiteBar = transform.Find("painiteBar");
        }
        else
        {

            goldOre = transform.Find("GoldOre");
            copperOre = transform.Find("CopperOre");
            ironOre = transform.Find("IronOre");
            cobaltOre = transform.Find("CobaltOre");
            uraniumOre = transform.Find("UraniumOre");
            ismiumOre = transform.Find("IsmiumOre");
            iridiumOre = transform.Find("IridiumOre");
            painiteOre = transform.Find("PainiteOre");

            goldOreFrame = GameObject.Find("GoldIcon_frame");
        }

        GameObject goldObject = GameObject.Find("GoldAndOreMechanics");
        goldScript = goldObject.GetComponent<GoldAndOreMechanics>();

        totalGoldFrame = GameObject.Find("TotalGoldFrame");
    }

    public void SetOff()
    {
        if (isRocksMaterialPopUp == true)
        {
            goldOre.gameObject.SetActive(false);
            copperOre.gameObject.SetActive(false);
            ironOre.gameObject.SetActive(false);
            cobaltOre.gameObject.SetActive(false);
            uraniumOre.gameObject.SetActive(false);
            ismiumOre.gameObject.SetActive(false);
            iridiumOre.gameObject.SetActive(false);
            painiteOre.gameObject.SetActive(false);

            isGoldOre = false; isCopperOre = false; isIronOre = false; isCobaltOre = false;
            isUraniumOre = false; isIsmiumOre = false; isIridumOre = false; isPainiteOre = false;
        }

        if (isMinePopUp == true)
        {
            goldBar.gameObject.SetActive(false);
            copperBar.gameObject.SetActive(false);
            ironBar.gameObject.SetActive(false);
            cobaltBar.gameObject.SetActive(false);
            uraniumBar.gameObject.SetActive(false);
            ismiumBar.gameObject.SetActive(false);
            iridiumBar.gameObject.SetActive(false);
            painiteBar.gameObject.SetActive(false);

            isGoldBar = false; isCopperBar = false; isIronBar = false; isCobaltBar = false; isUraniumBar = false; isIsmiumBar = false; isIridumBar = false; isPainiteBar = false;
        }
    }

    bool foundCopperOreFrame, foundIronOreFrame, foundCobaltOreFrame, foundUraniumOreFrame, foundIsmiumOreFrame, foundIridiumOreFrame, foundPainiteOreFrame;

    bool foundCopper, foundIron, foundCobalt, foundUranium, foundIsmium, foundIridium, foundPainite;

    private void OnEnable()
    {
        if (SkillTree.spawnCopper_purchased && foundCopper == false) { totalCopperFrame = GameObject.Find("TotalCopperFrame"); foundCopper = true; }
        if (SkillTree.spawnIron_purchased && foundIron == false) { totalIronFrame = GameObject.Find("TotalIronFrame"); foundIron = true; }
        if (SkillTree.cobaltSpawn_purchased && foundCobalt == false) { totalCobaltFrame = GameObject.Find("TotalCobaltFrame"); foundCobalt = true; }
        if (SkillTree.uraniumSpawn_purchased && foundUranium == false) { totalUraniumFrame = GameObject.Find("TotalUraniumFrame"); foundUranium = true; }
        if (SkillTree.ismiumSpawn_purchased && foundIsmium == false) { totalIsmiumFrame = GameObject.Find("TotalIsmiumFrame"); foundIsmium = true; }
        if (SkillTree.iridiumSpawn_purchased && foundIridium == false) { totalIridiumFrame = GameObject.Find("TotalIriduimFrame"); foundIridium = true; }
        if (SkillTree.painiteSpawn_purchased && foundPainite == false) { totalPainiteFrame = GameObject.Find("TotalPianiteFrame"); foundPainite = true; }

        isReturned = false;
        isDisabled = false;

        if (isRocksMaterialPopUp == true)
        {
            totalTextsOnScreen += 1;

            if (SkillTree.spawnCopper_purchased == true && foundCopperOreFrame == false) { copperOreFrame = GameObject.Find("CopperIcon_frame"); foundCopperOreFrame = true; }
            if (SkillTree.spawnIron_purchased == true && foundIronOreFrame == false) { ironOreFrame = GameObject.Find("IronIcon_frame"); foundIronOreFrame = true; }
            if (SkillTree.cobaltSpawn_purchased == true && foundCobaltOreFrame == false) { cobaltOreFrame = GameObject.Find("CobaltIcon_frame"); foundCobaltOreFrame = true; }
            if (SkillTree.uraniumSpawn_purchased == true && foundUraniumOreFrame == false) { uraniumOreFrame = GameObject.Find("UraniumIcon_frame"); foundUraniumOreFrame = true; }
            if (SkillTree.ismiumSpawn_purchased == true && foundIsmiumOreFrame == false) { ismiumOreFrame = GameObject.Find("IsmiumIcon_frame"); foundIsmiumOreFrame = true; }
            if (SkillTree.iridiumSpawn_purchased == true && foundIridiumOreFrame == false) { iridiumOreFrame = GameObject.Find("IridiumIcon_frame"); foundIridiumOreFrame = true; }
            if (SkillTree.painiteSpawn_purchased == true && foundPainiteOreFrame == false) { painiteOreFrame = GameObject.Find("PainiteIcon_frame"); foundPainiteOreFrame = true; }
        }
        else if (isMinePopUp)
        {
            gameObject.transform.localScale = new Vector2(0, 0);
        }

        SetOff();
        StartCoroutine(PopUpText());
    }

    IEnumerator PopUpText()
    {
        float randomWait1 = Random.Range(0.03f, 0.04f);

        yield return new WaitForSeconds(randomWait1);

        if(isRocksMaterialPopUp == true)
        {
            if (gameObject.transform.localScale.x > 0.9f) { painiteOre.gameObject.SetActive(true); isPainiteOre = true; }
            else if (gameObject.transform.localScale.x > 0.8f) { iridiumOre.gameObject.SetActive(true); isIridumOre = true; }
            else if (gameObject.transform.localScale.x > 0.7f) { ismiumOre.gameObject.SetActive(true); isIsmiumOre = true; }
            else if (gameObject.transform.localScale.x > 0.6f) { uraniumOre.gameObject.SetActive(true); isUraniumOre = true; }
            else if (gameObject.transform.localScale.x > 0.5f) { cobaltOre.gameObject.SetActive(true); isCobaltOre = true; }
            else if (gameObject.transform.localScale.x > 0.4f) { ironOre.gameObject.SetActive(true); isIronOre = true; }
            else if (gameObject.transform.localScale.x > 0.3f) { copperOre.gameObject.SetActive(true); isCopperOre = true; }
            else if (gameObject.transform.localScale.x > 0.2f) { goldOre.gameObject.SetActive(true); isGoldOre = true; }
        }
        if (isMinePopUp == true)
        {
            if (gameObject.transform.localScale.x > 0.9f) { painiteBar.gameObject.SetActive(true); isPainiteBar = true; }
            else if (gameObject.transform.localScale.x > 0.8f) { iridiumBar.gameObject.SetActive(true); isIridumBar = true; }
            else if (gameObject.transform.localScale.x > 0.7f) { ismiumBar.gameObject.SetActive(true); isIsmiumBar = true; }
            else if (gameObject.transform.localScale.x > 0.6f) { uraniumBar.gameObject.SetActive(true); isUraniumBar = true; }
            else if (gameObject.transform.localScale.x > 0.5f) { cobaltBar.gameObject.SetActive(true); isCobaltBar = true; }
            else if (gameObject.transform.localScale.x > 0.4f) { ironBar.gameObject.SetActive(true); isIronBar = true; }
            else if (gameObject.transform.localScale.x > 0.3f) { copperBar.gameObject.SetActive(true); isCopperBar = true; }
            else if (gameObject.transform.localScale.x > 0.2f) { goldBar.gameObject.SetActive(true); isGoldBar = true; }

            //Debug.Log(gameObject.transform.localScale.x);
        }

        float scaleStartTime = Time.time;
        float scaleEndTime = scaleStartTime + 0.25f;

        float randomTexTSize = 0;

        if (isRocksMaterialPopUp == true)
        {
            randomTexTSize = Random.Range(0.14f, 0.225f);
        }

        if (isMinePopUp == true)
        {
            scaleEndTime = scaleStartTime + 0.4f;
            randomTexTSize = Random.Range(0.55f, 0.8f);
        }

        //Scale from 0 to randomTexTSize
        while (Time.time < scaleEndTime)
        {
            if (SetRockScreen.isInMiningSession == false && isRocksMaterialPopUp == true)
            {
                if (SetRockScreen.timeLeft < 5) { scaleEndTime = 0.02f; }
            }

            float t = (Time.time - scaleStartTime) / (scaleEndTime - scaleStartTime);
            gameObject.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(randomTexTSize, randomTexTSize, randomTexTSize), t);
            yield return null;
        }

        float randomWait2 = 0;

        if (SetRockScreen.isInMiningSession == false && isRocksMaterialPopUp == true)
        {
            randomWait2 = Random.Range(0.005f, 0.007f);
        }
        else if (SetRockScreen.timeLeft < 1f && isRocksMaterialPopUp == true) 
        {
            randomWait2 = Random.Range(0.01f, 0.02f);
        }
        else if (SetRockScreen.timeLeft < 2f && isRocksMaterialPopUp == true)
        {
            randomWait2 = Random.Range(0.09f, 0.15f);
        }
        else if (SetRockScreen.timeLeft < 3f && isRocksMaterialPopUp == true)
        {
            randomWait2 = Random.Range(0.1f, 0.45f);
        }
        else
        {
            randomWait2 = Random.Range(0.1f, 0.52f);
        }
      
        yield return new WaitForSeconds(randomWait2);

        // Move towards goldCountFrame
        float moveDuration = Random.Range(0.25f, 0.4f);
        if (SetRockScreen.timeLeft < 1 && isRocksMaterialPopUp == true) { moveDuration = Random.Range(0.02f, 0.03f); }
        else if (SetRockScreen.timeLeft < 2 && isRocksMaterialPopUp == true) { moveDuration = Random.Range(0.1f, 0.16f); }
        else if (SetRockScreen.timeLeft < 3 && isRocksMaterialPopUp == true) { moveDuration = Random.Range(0.14f, 0.2f); }

        if (SetRockScreen.isInMiningSession == false)
        {
            moveDuration = 0.006f;

            if (isMinePopUp == true) { moveDuration = Random.Range(0.25f, 0.4f); }
        }

        Vector3 startPosition = gameObject.transform.position;
        Vector3 endPosition = new Vector3(0,0,0);

        if(isMinePopUp == true)
        {
            if (isGoldBar) endPosition = totalGoldFrame.transform.position;
            else if (isCopperBar) endPosition = totalCopperFrame.transform.position;
            else if (isIronBar) endPosition = totalIronFrame.transform.position;
            else if (isCobaltBar) endPosition = totalCobaltFrame.transform.position;
            else if (isUraniumBar) endPosition = totalUraniumFrame.transform.position;
            else if (isIsmiumBar) endPosition = totalIsmiumFrame.transform.position;
            else if (isIridumBar) endPosition = totalIridiumFrame.transform.position;
            else if (isPainiteBar) endPosition = totalPainiteFrame.transform.position;
        }
        if(isRocksMaterialPopUp == true) 
        { 
            if(isGoldOre == true) { endPosition = goldOreFrame.transform.position; }
            else if (isCopperOre == true) { endPosition = copperOreFrame.transform.position; }
            else if (isIronOre == true) { endPosition = ironOreFrame.transform.position; }
            else if (isCobaltOre == true) { endPosition = cobaltOreFrame.transform.position; }
            else if (isUraniumOre == true) { endPosition = uraniumOreFrame.transform.position; }
            else if (isIsmiumOre == true) { endPosition = ismiumOreFrame.transform.position; }
            else if (isIridumOre == true) { endPosition = iridiumOreFrame.transform.position; }
            else if (isPainiteOre == true) { endPosition = painiteOreFrame.transform.position; }
        }

        float moveStartTime = Time.time;

        while (Time.time < moveStartTime + moveDuration)
        {
            if(SetRockScreen.isInMiningSession == false && isMinePopUp == false)
            {
                if (SetRockScreen.timeLeft > 5) { moveDuration = Random.Range(0.25f, 0.4f); }
                else { moveDuration = 0.015f; }
            }

            float t = (Time.time - moveStartTime) / moveDuration;
            gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        if(isReturned == false)
        {
            isReturned = true;

            float currentTime = Time.time;

            overlappingScript.PlaySoundMaterialCollect(1, currentTime);

            gameObject.transform.position = endPosition;

            if (isRocksMaterialPopUp == true)
            {
                if(SetRockScreen.oresPopedUp == false)
                {
                    if (isGoldOre == true) { goldScript.GiveMaterialOre(1, 1); goldScript.ScaleGoldAnim(1); }
                    else if (isCopperOre == true) { goldScript.GiveMaterialOre(2, 1); goldScript.ScaleGoldAnim(2); }
                    else if (isIronOre == true) { goldScript.GiveMaterialOre(3, 1); goldScript.ScaleGoldAnim(3); }
                    else if (isCobaltOre == true) { goldScript.GiveMaterialOre(4, 1); goldScript.ScaleGoldAnim(4); }
                    else if (isUraniumOre == true) { goldScript.GiveMaterialOre(5, 1); goldScript.ScaleGoldAnim(5); }
                    else if (isIsmiumOre == true) { goldScript.GiveMaterialOre(6, 1); goldScript.ScaleGoldAnim(6); }
                    else if (isIridumOre == true) { goldScript.GiveMaterialOre(7, 1); goldScript.ScaleGoldAnim(7); }
                    else if (isPainiteOre == true) { goldScript.GiveMaterialOre(8, 1); goldScript.ScaleGoldAnim(8); }
                }

                totalTextsOnScreen -= 1;

                ObjectPool.instance.ReturnTextFromPool(gameObject);
            }
            if (isMinePopUp == true)
            {
                if (isGoldBar == true) { goldScript.GiveGoldBar(1, 1); }
                else if (isCopperBar == true) { goldScript.GiveGoldBar(1, 2); }
                else if (isIronBar == true) { goldScript.GiveGoldBar(1, 3); }
                else if (isCobaltBar == true) { goldScript.GiveGoldBar(1, 4); }
                else if (isUraniumBar == true) { goldScript.GiveGoldBar(1, 5); }
                else if (isIsmiumBar == true) { goldScript.GiveGoldBar(1, 6); }
                else if (isIridumBar == true) { goldScript.GiveGoldBar(1, 7); }
                else if (isPainiteBar == true) { goldScript.GiveGoldBar(1, 8); }

                ObjectPool.instance.ReturnTheMineMaterialFromPool(gameObject);
            }
        }
    }

    bool isDisabled;

    private void OnDisable()
    {
        if (isMinePopUp)
        {
            if(MainMenu.isInTheMine == false)
            {
                if (isGoldBar == true) { goldScript.GiveGoldBar(1, 1); }
                else if (isCopperBar == true) { goldScript.GiveGoldBar(1, 2); }
                else if (isIronBar == true) { goldScript.GiveGoldBar(1, 3); }
                else if (isCobaltBar == true) { goldScript.GiveGoldBar(1, 4); }
                else if (isUraniumBar == true) { goldScript.GiveGoldBar(1, 5); }
                else if (isIsmiumBar == true) { goldScript.GiveGoldBar(1, 6); }
                else if (isIridumBar == true) { goldScript.GiveGoldBar(1, 7); }
                else if (isPainiteBar == true) { goldScript.GiveGoldBar(1, 8); }
            }
        }

        if(isDisabled == false)
        {
            isDisabled = true;
            //gameObject.transform.localScale = new Vector2(0, 0);
            StopAllCoroutines();
        }
    }
}
