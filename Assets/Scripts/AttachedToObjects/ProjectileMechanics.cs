using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMechanics : MonoBehaviour
{
    public SpawnProjectiles spawnProjectileScript;
    public SetRockScreen setRockScreenScript;

    bool isBeam_s, isBeam_ph;

    public bool isBeamOfLight;
    public bool isElectricity;
    public bool isPlazmaBall;
    public bool isDynamite;

    public ParticleSystem beam_s, beam_ph, electricityParticle, dynamiteParticle;
    public Transform beamParticle_s, beamParticle_ph, electricityChild, colliderChild, dynamiteIcon, dynamiteParticleChild;

    public ParticleSystem plazmaParticle;
    public Transform plazmaObject;

    private Rigidbody2D rb;
    private Collider2D collider2d;

    private Transform smallExplosion1Child, smallExplosion2Child;
    public ParticleSystem smallExplosion1, smallExplosion2;

    public AudioManager audioManager;

    private void Awake()
    {
        GameObject managerObject = GameObject.Find("AudioManager");
        audioManager = managerObject.GetComponent<AudioManager>();

        GameObject spawnProjectileObject = GameObject.Find("SpawnProjectiles");
        spawnProjectileScript = spawnProjectileObject.GetComponent<SpawnProjectiles>();

        GameObject setRockScreenOBject = GameObject.Find("SetRockScreen");
        setRockScreenScript = setRockScreenOBject.GetComponent<SetRockScreen>();

        if (isBeamOfLight)
        {
            beamParticle_s = transform.Find("Lazer_blue");
            beamParticle_ph = transform.Find("Lazer_red");
            beam_s = beamParticle_s.GetComponent<ParticleSystem>();
            beam_ph = beamParticle_ph.GetComponent<ParticleSystem>();
            collider2d = gameObject.GetComponent<Collider2D>();
        }

        if(isElectricity) //ElectricitySplash
        {
            electricityChild = transform.Find("Electricity_Splash_5");
            colliderChild = transform.Find("ColliderSplash");
            electricityParticle = electricityChild.GetComponent<ParticleSystem>();
        }

        if (isPlazmaBall)
        {
            plazmaObject = transform.Find("PlazmaBallParticle");
            plazmaParticle = plazmaObject.GetComponent<ParticleSystem>();
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

        if (isDynamite)
        {
            collider2d = gameObject.GetComponent<Collider2D>();
            dynamiteIcon = transform.Find("DynamiteIcon");
            dynamiteParticleChild = transform.Find("DynamiteParticle");
            dynamiteParticle = dynamiteParticleChild.GetComponent<ParticleSystem>();

            smallExplosion1Child = transform.Find("smallExplosion1");
            smallExplosion1 = smallExplosion1Child.GetComponent<ParticleSystem>();
            smallExplosion2Child = transform.Find("smallExplosion2");
            smallExplosion2 = smallExplosion2Child.GetComponent<ParticleSystem>();
        }
    }

    bool isPlazmaOn;

    public void Update()
    {
        if (isPlazmaBall)
        {
            if(SetRockScreen.isInMiningSession == false && isPlazmaOn == true)
            {
                StartCoroutine(ScaleObject(gameObject));
                isPlazmaOn = false;
            }
        }
    }

    private void OnEnable()
    {
        isBeam_ph = false;

        if (isBeamOfLight)
        {
            beamParticle_s.gameObject.SetActive(false);
            beamParticle_ph.gameObject.SetActive(false);
            collider2d.enabled = false;
        }
        else if (isPlazmaBall)
        {
            isPlazmaOn = true;

            plazmaObject.gameObject.SetActive(true);
            plazmaParticle.Play();

            StartCoroutine(MoveParticle());
          
        }
        else if (isElectricity)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0, -360));
            electricityParticle.Play();
        }
        else if (isDynamite)
        {
            smallExplosion1Child.gameObject.SetActive(false);
            smallExplosion2Child.gameObject.SetActive(false);
            dynamiteIcon.gameObject.SetActive(true);

            float size = 23 * SkillTree.explosionSize;
            dynamiteParticleChild.transform.localScale = new Vector3(size, size, size);

            dynamiteParticleChild.gameObject.SetActive(false);
        }

        StartCoroutine(SetBack());
    }

    IEnumerator SpawnSmallBall()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            float random = Random.Range(0,100);
            if(random < SkillTree.plazmaBallSpawnSmallBallChance)
            {
                GameObject smallBall = ObjectPool.instance.GetPlazmaBallFromPool();
                smallBall.transform.localScale = new Vector3(gameObject.transform.localScale.x / 2, gameObject.transform.localScale.y / 2, gameObject.transform.localScale.z / 2);
                smallBall.transform.position = gameObject.transform.position;
            }
        }
    }

    IEnumerator MoveParticle()
    {
        yield return new WaitForSeconds(0.2f);

        if (SkillTree.plazmaBallSpawnSmallChance_purchased)
        {
            if(gameObject.transform.localScale.x > 0.79f) { StartCoroutine(SpawnSmallBall()); }
        }

        if (gameObject.transform.localScale.x > 0.79f)
        {
            Vector2 targetPosition = new Vector2(Random.Range(-0.55f, 0.55f), Random.Range(-0.55f, 0.55f));
            Vector2 currentPosition = transform.position;

            Vector2 direction = (targetPosition - currentPosition).normalized;
            rb.velocity = direction * 0.6f;
        }
        else
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            rb.velocity = randomDirection * 0.35f;
        }
    }

    IEnumerator SetBack()
    {
        if(isBeamOfLight == true)
        {
            yield return new WaitForSeconds(0.05f);
            if(gameObject.tag == "Beam_S") { beamParticle_s.gameObject.SetActive(true); beam_s.Play(); isBeam_s = true; }
            else { beamParticle_ph.gameObject.SetActive(true); beam_ph.Play(); isBeam_ph = true; }
        }

        float time = 1;
        if (isBeamOfLight) 
        {
            yield return new WaitForSeconds(0.1f);
            collider2d.enabled = true;

            if (SkillTree.lightningBeamExplosion_purchased)
            {
                float random = Random.Range(0, 100);
                if (random < SkillTree.lightningSpawnExplosionChance)
                {
                    GameObject dynamite = ObjectPool.instance.GetDynamiteFromPool();
                    dynamite.tag = "OnlyExplosion";
                    dynamite.transform.position = gameObject.transform.position;
                }
            }

            if (SkillTree.lightningBeamSpawnAnotherOneChance_purchased)
            {
                float random = Random.Range(0, 100);
                if (random < SkillTree.triggerAnotherLighntingChance)
                {
                    if (isBeam_s == true) { spawnProjectileScript.SelectRandomActiveRock(2); }
                    if (isBeam_ph == true) { spawnProjectileScript.SelectRandomActiveRock(4); }
                }
            }

            if (SkillTree.lightningBeamAddTime_purchased)
            {
                float random = Random.Range(0,100);
                if(random < SkillTree.lightningAddTimeChance)
                {
                    SetRockScreen.currentTime -= 1;
                }
            }

            if (SkillTree.lightningBeamSpawnRock_purchased)
            { 
                float random = Random.Range(0, 100);
                if (random < SkillTree.lightningSpawnRockChance)
                {
                    SetRockScreen.tileWaveNumber = Random.Range(0,14);
                    setRockScreenScript.SpawnRockCount(1);
                }
            }

            if (SkillTree.lightningSplashes_purchased)
            {
                float random = Random.Range(0, 100);
                if (random < SkillTree.lightningSplashChance)
                {
                    for (int i = 0; i < Random.Range(3,6); i++)
                    {
                        GameObject splash = ObjectPool.instance.GetElectricitySplashFromPool();
                        splash.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1);
                    }
                }
            }

            time = 1.5f; 
        }
        else if (isPlazmaBall) { time = SkillTree.plazmaBallTimer; }
        else if (isElectricity) { time = 1f; }
        else if (isDynamite)
        {
            yield return new WaitForSeconds(0.05f);

            if(gameObject.tag == "Dynamite")
            {
                dynamiteIcon.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.35f);
            }
            else
            {
                dynamiteIcon.gameObject.SetActive(false);
            }
           
            dynamiteIcon.gameObject.SetActive(false);
            dynamiteParticleChild.gameObject.SetActive(true);
            dynamiteParticle.Play();

            audioManager.Play("Dynamite");

            time = 1f;

            if (SkillTree.dynamiteExplosionSpawnRock_purchased)
            {
                float randomRock = Random.Range(0,100);
                if(randomRock < SkillTree.chanceToSpawnRockFromExplosion)
                {
                    SetRockScreen.tileWaveNumber = Random.Range(0,14);
                    setRockScreenScript.SpawnRockCount(1);
                }
            }

            if (SkillTree.dynamiteExplosionAddTimeChance_purchased)
            {
                float randomRock = Random.Range(0, 100);
                if (randomRock < SkillTree.explosionAdd1SecondChance)
                {
                    SetRockScreen.currentTime -= 1;
                }
            }

            if (SkillTree.dynamiteExplosionSpawnLightning_purchased)
            {
                float randomSpawnBeam = Random.Range(0, 100);
                if (randomSpawnBeam < SkillTree.explosionChanceToSpawnLightning)
                {
                    int randomBeam = Random.Range(1,3);
                    if(randomBeam == 1) { spawnProjectileScript.SelectRandomActiveRock(2); }
                    if(randomBeam == 2) { spawnProjectileScript.SelectRandomActiveRock(4); }
                }
            }

            if (SkillTree.dynamiteChance_2_purchased)
            {
                float random = Random.Range(0,100);
                if(random < SkillTree.spawn2DynamiteChance)
                {
                    yield return new WaitForSeconds(0.3f);

                    smallExplosion1Child.gameObject.SetActive(true);
                    smallExplosion2Child.gameObject.SetActive(true);

                    smallExplosion1.Play();
                    smallExplosion2.Play();

                    audioManager.Play("Dynamite");
                }
            }
        }

        yield return new WaitForSeconds(time);

        if (isBeamOfLight)
        { 
            ObjectPool.instance.ReturnBeamOfLight(gameObject);
        }
        else if (isPlazmaBall)
        {
            StartCoroutine(ScaleObject(gameObject));
        }
        else if (isElectricity)
        {
            ObjectPool.instance.ReturnElectricitySplashFromPool(gameObject);
        }
        else if (isDynamite)
        {
            ObjectPool.instance.ReturnDynamiteFromPool(gameObject);
        }
    }

    #region Scale down
    IEnumerator ScaleObject(GameObject objectToScale)
    {
        float duration = 0.2f;
        float elapsedTime = 0f;

        Vector3 startScale = objectToScale.transform.localScale;
        Vector3 endScale = Vector3.zero;

        while (elapsedTime < duration)
        {
            objectToScale.transform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectToScale.transform.localScale = endScale;

        if (isPlazmaBall)
        {
            if (SkillTree.plazmaBallExplosionChance_purchased)
            {
                float random = Random.Range(0, 100);
                if (random < SkillTree.plazmaballExplosionChance)
                {
                    GameObject dynamite = ObjectPool.instance.GetDynamiteFromPool();
                    dynamite.tag = "OnlyExplosion";
                    dynamite.transform.position = gameObject.transform.position;
                }
            }

            ObjectPool.instance.ReturnPlazmaBallToPool(objectToScale);
        }
    }
    #endregion

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
