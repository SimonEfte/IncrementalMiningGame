using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TheEnding : MonoBehaviour, IDataPersistence
{
    public GameObject EndSessionBtn, xpFrame, timeFrame, materialFrame, potionsFrame;
    public SetRockScreen rockScreenScript;
    public MainMenu mainMenuScripT;
    public Achievements achScript;
    public TheAnvil anvilScript;

    //THE ENDING
    //1. Once the rock is fully mined, 3 diamonds will pop up. They should each start at the rock position, then 1 should move to the left, then one to the middle then one to the right.
    //2. The diamond icons will float while the a CRAFT PICKASE button will appear.
    //3. While the pickaxe is being crafted, the screen should turn dark, the crafting pickaxe... text should appear.
    //4. Once the pickaxe is fully crafted, a text that says "You crafted the Diamond Pickaxe" should appear.
    //5. Roll credits!
    //6. A HOLD TO SKIP should appear bottom right.
    //7. Once skipped, or viewed the credits, the transition will appear and you will be taken back to the main menu. 
    //8. Now the diamond pickaxe can be equiped.
    //9. Maybe the player can go to the big rock again? 

    public static bool bigRockBroken;
    public static bool broken;

    public Animation diamond1, diamond2, diamond3;

    public Animation craftButton;

    public GameObject blockScreen;

    public GameObject cursorCollider;
    public GameObject endingStuff;

    public float craftingTime;

    public static bool isEndingCompleted;

    public static float gameMusicFullVolume, endingMusicFillVolume;

    public GameObject mainMenuSettingsBtn, flags;

    public GameObject endingButton;

    private void Awake()
    {
        gameMusicFullVolume = 0.565f;
        endingMusicFillVolume = 0.8f;

        craftingTime = 3;

        creditsBlackFrame.SetActive(false);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.8f);
        if(isEndingCompleted == true)
        {
            endingButton.SetActive(false);
        }
    }

    private void Update()
    {
        if(broken == false && bigRockBroken == true)
        {
            diamondCount = 0;
            Cursor.visible = true;
            broken = true;

            StartCoroutine(DiamondAnims());
        }
    }

    #region Diamond and craft btn animations
    IEnumerator DiamondAnims()
    {
        yield return new WaitForSeconds(0.45f);
        endingStuff.SetActive(true);

        cursorCollider.SetActive(false);
        Cursor.visible = true;

        blockScreen.SetActive(true);
        diamond1.gameObject.SetActive(true);
        diamond1.Play();
        StartCoroutine(FloatGameObject(diamond1.gameObject));
        yield return new WaitForSeconds(1.1f);
        diamond3.gameObject.SetActive(true);
        diamond3.Play();
        StartCoroutine(FloatGameObject(diamond3.gameObject));
        yield return new WaitForSeconds(1.1f);
        diamond2.gameObject.SetActive(true);
        diamond2.Play();
        StartCoroutine(FloatGameObject(diamond2.gameObject));

        yield return new WaitForSeconds(0.9f);

        craftButton.gameObject.SetActive(true);
        craftButton.Play();

        yield return new WaitForSeconds(0.233f);
        audioManager.Play("CardPop");
        blockScreen.SetActive(false);

    }
    #endregion

    #region Float diamonds

    int diamondCount;

    public IEnumerator FloatGameObject(GameObject objectToFloat)
    {
        audioManager.Play("EndingWoosh");

        yield return new WaitForSeconds(0.417f);

        diamondCount += 1;
        if(diamondCount == 1) { audioManager.Play("DiamodSound1"); }
        if (diamondCount == 2) { audioManager.Play("DiamodSound2"); }
        if (diamondCount == 3) { audioManager.Play("DiamodSound3"); }

        Vector3 initialScale = objectToFloat.transform.localScale;
        Vector3 initialPosition = objectToFloat.transform.localPosition;
        float initialZRotation = objectToFloat.transform.localEulerAngles.z;

        // Random phase offsets for smooth variation
        float scaleOffset = Random.Range(0f, Mathf.PI * 2);
        float posOffset = Random.Range(0f, Mathf.PI * 2);
        float rotOffset = Random.Range(0f, Mathf.PI * 2);

        while (!isCraftingStarted)
        {
            float time = Time.time;

            // Scale oscillates subtly between 1.8 and 2.1
            float scale = Mathf.Lerp(1.85f, 2.05f, (Mathf.Sin(time + scaleOffset) + 1f) / 2f);
            objectToFloat.transform.localScale = new Vector3(scale, scale, scale);

            // Position X/Y oscillates within ±20 units
            float offsetX = Mathf.Sin(time + posOffset) * 13f;
            float offsetY = Mathf.Cos(time + posOffset) * 13f;
            objectToFloat.transform.localPosition = new Vector3(
                initialPosition.x + offsetX,
                initialPosition.y + offsetY,
                initialPosition.z
            );

            // Z rotation oscillates within ±6 degrees
            float zRotation = initialZRotation + Mathf.Sin(time + rotOffset) * 5f;
            Vector3 currentEuler = objectToFloat.transform.localEulerAngles;
            objectToFloat.transform.localEulerAngles = new Vector3(
                currentEuler.x,
                currentEuler.y,
                zRotation
            );

            yield return null; // wait for next frame
        }

        // Optionally: Reset to original values once crafting starts
        objectToFloat.transform.localScale = initialScale;
        objectToFloat.transform.localPosition = initialPosition;
        objectToFloat.transform.localEulerAngles = new Vector3(
            objectToFloat.transform.localEulerAngles.x,
            objectToFloat.transform.localEulerAngles.y,
            initialZRotation
        );
    }
    #endregion

    public static bool craftingDone;

    public AudioManager audioManager;
    public GameObject craftingFrame;
    public GameObject outLineCircle;
    public Image craftingCircle;
    public TextMeshProUGUI craftingText;

    private bool craftingCompleted = false;
    public bool isCraftingStarted;

    private Coroutine craftingCoroutine;

    #region Crafting
    public void PressCraftPickaxe()
    {
        //audioManager.Play("Crafting...");
        audioManager.Play("Merge");

        Cursor.visible = true;
        SetRockScreen.isInMiningSession = false;
        TheAnvil.pickaxe14_crafted = true;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        isCraftingStarted = true;

        craftButton.gameObject.SetActive(false);

        craftingCoroutine = StartCoroutine(CraftingCoroutine());
        StartCoroutine(FadeInImage(craftingFrame.GetComponent<Image>()));

        StartCoroutine(MoveLocalPosXToZero(diamond1.gameObject));
        StartCoroutine(MoveLocalPosXToZero(diamond2.gameObject));
    }

    private IEnumerator CraftingCoroutine()
    {
        craftingCompleted = false;

        //audioManager.Play("Crafting...");

        craftingFrame.SetActive(true);
        outLineCircle.SetActive(true);
        craftingText.text = LocalizationScript.crafting;
        craftingText.gameObject.SetActive(true);
        craftingCircle.gameObject.SetActive(true);

        float currentTime = 0f;
        float dotTimer = 0f;
        int dotCount = 0;

        while (currentTime < craftingTime)
        {
            currentTime += Time.deltaTime;

            // Update fill amount
            float fill = Mathf.Clamp01(currentTime / craftingTime);
            craftingCircle.fillAmount = fill;

            // Update dots every 0.35s
            dotTimer += Time.deltaTime;
            if (dotTimer >= 0.35f)
            {
                dotTimer = 0f;
                dotCount = (dotCount + 1) % 4;
                craftingText.text = LocalizationScript.crafting + new string('.', dotCount);
            }

            yield return null;
        }

        audioManager.Stop("Crafting...");

        craftingCompleted = true;

        OnCraftingComplete();
    }

    public ParticleSystem craftedParticle;

    private void OnCraftingComplete()
    {
        audioManager.Play("CraftingDone");
        audioManager.Play("FinishedCrafting");

        StartCoroutine(RollCredits());
        craftedParticle.gameObject.SetActive(true);
        craftedParticle.Play();

        diamond1.gameObject.SetActive(false);
        diamond2.gameObject.SetActive(false);
        diamond3.gameObject.SetActive(false);

        outLineCircle.SetActive(false);
        craftingText.gameObject.SetActive(false);
        craftingCircle.gameObject.SetActive(false);
    }
    #endregion

    #region Fade in image
    public IEnumerator FadeInImage(Image image)
    {
        // Ensure the image starts fully transparent
        Color color = image.color;
        color.a = 0f;
        image.color = color;

        float duration = craftingTime;
        float currentTime = 0f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(currentTime / duration);

            color.a = alpha;
            image.color = color;

            yield return null;
        }

        // Make sure it's fully opaque at the end
        color.a = 1f;
        image.color = color;
    }
    #endregion

    #region Move diamonds to middle
    public IEnumerator MoveLocalPosXToZero(GameObject obj)
    {
        Vector3 startPos = obj.transform.localPosition;
        Vector3 endPos = new Vector3(0f, startPos.y, startPos.z);

        float currentTime = 0f;

        while (currentTime < craftingTime)
        {
            currentTime += Time.deltaTime;
            float t = Mathf.Clamp01(currentTime / craftingTime);

            // Smoothly interpolate X towards zero
            Vector3 newPos = Vector3.Lerp(startPos, endPos, t);
            obj.transform.localPosition = newPos;

            yield return null;
        }

        // Ensure it's exactly at zero at the end
        obj.transform.localPosition = endPos;
    }
    #endregion

    #region Roll credits
    public GameObject creditsBlackFrame;
    public GameObject youCraftedText, diamondPickaxeIcon, thankYouForPlayingText;

    IEnumerator RollCredits()
    {
        endingButton.SetActive(false);
        flags.transform.localPosition = new Vector2(-426, -431);
        mainMenuSettingsBtn.SetActive(false);

        youCraftedText.SetActive(false); diamondPickaxeIcon.SetActive(false); thankYouForPlayingText.SetActive(false);

        creditsBlackFrame.transform.localPosition = new Vector2(0, -2248.18f);

        yield return new WaitForSeconds(1f);

        audioManager.Stop("CreditsMusic");
        audioManager.Play("CreditsMusic");
        StartCoroutine(SongVolume("CreditsMusic", false, 0.7f, 0, 0.45f, false));

        yield return new WaitForSeconds(0.67f);

        creditsBlackFrame.SetActive(true);
        audioManager.Play("CardPop");
        youCraftedText.SetActive(true);

        yield return new WaitForSeconds(1.311f);

        diamondPickaxeIcon.SetActive(true);
        audioManager.Play("CardPop");

        yield return new WaitForSeconds(1.311f);
        thankYouForPlayingText.SetActive(true);
        audioManager.Play("CardPop");

        yield return new WaitForSeconds(2f);

        //5.25 secons before credits roll.

        StartCoroutine(CreditsToll(creditsBlackFrame, 37f));
        //StartCoroutine(CreditsToll(creditsBlackFrame, 10f));
    }

    public IEnumerator CreditsToll(GameObject obj, float duration)
    {
        isEndingCompleted = true;
        anvilScript.SetDiamondPickaxeWhite();

        achScript.CheckAch();

        Vector3 startPos = obj.transform.localPosition;
        Vector3 endPos = new Vector3(startPos.x, 387f, startPos.z);

        float currentTime = 0f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float t = Mathf.Clamp01(currentTime / duration);

            // Interpolate Y towards zero
            Vector3 newPos = Vector3.Lerp(startPos, endPos, t);
            obj.transform.localPosition = newPos;

            yield return null;
        }

        // Snap to final value to be safe
        obj.transform.localPosition = endPos;
    }
    #endregion

    #region Scale circle and go back to start screen
    public void GoToMainMenu()
    {
        audioManager.Play("MainMenuMusic");

        audioManager.Stop("CreditsMusic");
        //SoundVolumeSet("CreditsMusic", true, 0f, 0.75f, 1, true);

        SoundVolumeSet("MainMenuMusic", false, 0f, gameMusicFullVolume, 0.65f, false);

        Cursor.visible = true;
        SetRockScreen.isInEnding = false;
        broken = false;
        bigRockBroken = false;

        isCraftingStarted = false;
        craftingCompleted = false;
        StopAllCoroutines();

        StartCoroutine(ScaleCircleCoroutine(true));
    }

    public GameObject circleObject;
    public GameObject transitionBlock;

    public GameObject startScreen, startScreenbackground;

    IEnumerator ScaleCircleCoroutine(bool scaleUp)
    {
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

        if (scaleUp == true)
        {
            rockScreenScript.SetUiStuff();
            SetOff();
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(ScaleCircleCoroutine(false));
        }

        circleObject.transform.localScale = targetScale;

        if (scaleUp == false)
        {
            circleObject.SetActive(false);
            transitionBlock.SetActive(false);
        }
    }
    #endregion

    #region Stop or turn up/down music.
    IEnumerator SongVolume(string name, bool turnDown, float startVolume, float endVolume, float fadeTime, bool stopMusic)
    {
        float start = turnDown ? startVolume : endVolume;
        float end = turnDown ? endVolume : startVolume;

        float time = 0;
        float fadeTotalTime = fadeTime;

        while (time < fadeTotalTime)
        {
            time += Time.unscaledDeltaTime;
            float newVolume = Mathf.Lerp(start, end, time / fadeTotalTime);
            audioManager.ChangeVolume(name, newVolume);

            yield return null;
        }

        audioManager.ChangeVolume(name, end);

        if (stopMusic == true)
        {
            audioManager.Stop(name);
        }
    }

    public void SoundVolumeSet(string name, bool turnDown, float startVolume, float endVolume, float fadeTime, bool stopMusic)
    {
        StartCoroutine(SongVolume(name, turnDown, startVolume, endVolume, fadeTime, stopMusic));
    }
    #endregion

    public void SetOff()
    {
        Color color = craftingFrame.GetComponent<Image>().color;
        color.a = 0f;
        craftingFrame.GetComponent<Image>().color = color;

        craftingFrame.SetActive(false);
        outLineCircle.SetActive(false);
        craftingText.gameObject.SetActive(false);
        craftingCircle.gameObject.SetActive(false);

        youCraftedText.SetActive(false); 
        diamondPickaxeIcon.SetActive(false); 
        thankYouForPlayingText.SetActive(false);
        creditsBlackFrame.SetActive(false);
        endingStuff.SetActive(false);

        startScreen.SetActive(true);
        startScreenbackground.SetActive(true);
    }

    #region Load Data
    public void LoadData(GameData data)
    {
        isEndingCompleted = data.isEndingCompleted;
    }
    #endregion

    #region Save Data
    public void SaveData(ref GameData data)
    {
        data.isEndingCompleted = isEndingCompleted;
    }
    #endregion

    public void CopyThis()
    {
        //if (spawnCopper_purchased) { }
        //else { }

        // if (spawnIron_purchased) { }
        // else {  }

        // if (cobaltSpawn_purchased) { }
        // else { }

        // if (uraniumSpawn_purchased) { }
        // else { }

        // if (iridiumSpawn_purchased) { }
        // else { }

        // if (ismiumSpawn_purchased) { }
        //  else { }

        //  if (painiteSpawn_purchased) { }
        //  else { }
    }
}
