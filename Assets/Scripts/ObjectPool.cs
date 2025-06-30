using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] private GameObject textPrefab;
    private Queue<GameObject> textPool = new Queue<GameObject>();
    [SerializeField] private int textPoolSize = 50;

    [SerializeField] private GameObject pickAxePrefab;
    private Queue<GameObject> pickaxePool = new Queue<GameObject>();
    [SerializeField] private int pickaxePoolSize = 50;

    [SerializeField] private GameObject rockPrefab;
    private Queue<GameObject> rockPool = new Queue<GameObject>();
    [SerializeField] private int rockPoolSize = 50;

    [SerializeField] private GameObject tilePrefab;
    private Queue<GameObject> tilePool = new Queue<GameObject>();
    [SerializeField] private int tilePoolSize = 150;

    [SerializeField] private GameObject rockParticlePrefab;
    private Queue<GameObject> rockParticlePool = new Queue<GameObject>();
    [SerializeField] private int rockParticlePoolSize = 25;

    [SerializeField] private GameObject beamOfLightPrefab;
    private Queue<GameObject> beamOfLightPool = new Queue<GameObject>();
    [SerializeField] private int beamOfLightPoolSize = 5;

    [SerializeField] private GameObject plazmaBallPrefab;
    private Queue<GameObject> plazmaBallPool = new Queue<GameObject>();
    [SerializeField] private int plazmaBallPoolSize = 10;

    [SerializeField] private GameObject mineMaterialPrefab;
    private Queue<GameObject> mineMaterialPool = new Queue<GameObject>();
    [SerializeField] private int mineMaterialPoolSize = 35;

    [SerializeField] private GameObject circleColliderPrefab;
    private Queue<GameObject> circleColliderPool = new Queue<GameObject>();
    [SerializeField] private int circleColliderPoolSize = 10;

    [SerializeField] private GameObject electricitySplashPrefab;
    private Queue<GameObject> electricityPool = new Queue<GameObject>();
    [SerializeField] private int electricityPoolSize = 35;

    [SerializeField] private GameObject dynamitePrefab;
    private Queue<GameObject> dynamitePool = new Queue<GameObject>();
    [SerializeField] private int dynamitePoolSize = 40;

    public Transform pickaxeParent, rockParent, tileParent, rockParticleParent, textParent, theMineMaterialParent, circleParent;
    public Transform projectileParent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        #region Text
        for (int i = 0; i < textPoolSize; i++)
        {
            GameObject text = Instantiate(textPrefab);
            textPool.Enqueue(text);
            text.gameObject.SetActive(false);
            text.transform.SetParent(textParent);
        }
        #endregion


        #region Pickaxe
        for (int i = 0; i < pickaxePoolSize; i++)
        {
            GameObject pickaxe = Instantiate(pickAxePrefab);
            pickaxePool.Enqueue(pickaxe);
            pickaxe.SetActive(false);
            pickaxe.transform.SetParent(pickaxeParent);
        }
        #endregion

        #region Rock
        for (int i = 0; i < rockPoolSize; i++)
        {
            GameObject rock = Instantiate(rockPrefab);
            rockPool.Enqueue(rock);
            rock.SetActive(false);
            rock.transform.SetParent(rockParent);
        }
        #endregion

        #region Rock Particle
        for (int i = 0; i < rockParticlePoolSize; i++)
        {
            GameObject rockParticle = Instantiate(rockParticlePrefab);
            rockParticlePool.Enqueue(rockParticle);
            rockParticle.SetActive(false);
            rockParticle.transform.SetParent(rockParticleParent);
        }
        #endregion

        #region Tile
        for (int i = 0; i < tilePoolSize; i++)
        {
            GameObject tile = Instantiate(tilePrefab);
            tilePool.Enqueue(tile);
            tile.SetActive(false);
            tile.transform.SetParent(tileParent);
        }
        #endregion

        #region Mine materials
        for (int i = 0; i < mineMaterialPoolSize; i++)
        {
            GameObject mine = Instantiate(mineMaterialPrefab);
            mineMaterialPool.Enqueue(mine);
            mine.SetActive(false);
            mine.transform.SetParent(theMineMaterialParent);
        }
        #endregion


        //Projectiles
        #region Beam of light
        for (int i = 0; i < beamOfLightPoolSize; i++)
        {
            GameObject beamOfLight = Instantiate(beamOfLightPrefab);
            beamOfLightPool.Enqueue(beamOfLight);
            beamOfLight.SetActive(false);
            beamOfLight.transform.SetParent(projectileParent);
            beamOfLight.transform.position = new Vector3(0,0,0);
        }
        #endregion

        #region Electricity
        for (int i = 0; i < electricityPoolSize; i++)
        {
            GameObject electricitySplash = Instantiate(electricitySplashPrefab);
            electricityPool.Enqueue(electricitySplash);
            electricitySplash.SetActive(false);
            electricitySplash.transform.SetParent(projectileParent);
            electricitySplash.transform.localScale = new Vector3(5.5f, 5.5f, 5.5f);
        }
        #endregion

        #region Dynamite
        for (int i = 0; i < dynamitePoolSize; i++)
        {
            GameObject dynamite = Instantiate(dynamitePrefab);
            dynamitePool.Enqueue(dynamite);
            dynamite.SetActive(false);
            dynamite.transform.SetParent(projectileParent);
            dynamite.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }
        #endregion

        #region Plazma Ball
        for (int i = 0; i < plazmaBallPoolSize; i++)
        {
            GameObject plazmaBall = Instantiate(plazmaBallPrefab);
            plazmaBallPool.Enqueue(plazmaBall);
            plazmaBall.SetActive(false);
            plazmaBall.transform.SetParent(projectileParent);
            plazmaBall.transform.position = new Vector3(0, 0, 0);
        }
        #endregion

        #region Circle Collider
        for (int i = 0; i < circleColliderPoolSize; i++)
        {
            GameObject circleCollider = Instantiate(circleColliderPrefab);
            circleColliderPool.Enqueue(circleCollider);
            circleCollider.SetActive(false);
            circleCollider.transform.SetParent(circleParent);
            circleCollider.transform.localScale = new Vector2(0.8f, 0.8f);
        }
        #endregion
    }


    #region Text
    public GameObject GetTextFromPool()
    {
        //Debug.Log(textPool.Count);

        if (textPool.Count > 0)
        {
            GameObject text = textPool.Dequeue();
            text.gameObject.SetActive(true);
            return text;
        }
        else
        {
            GameObject text = Instantiate(textPrefab);
            return text;
        }
    }

    public void ReturnTextFromPool(GameObject text)
    {
        textPool.Enqueue(text);
        text.gameObject.SetActive(false);
    }
    #endregion


    #region Pickaxe
    public GameObject GetPickaxeFromPool()
    {
        if (pickaxePool.Count > 0)
        {
            GameObject pickaxe = pickaxePool.Dequeue();
            pickaxe.SetActive(true);
            return pickaxe;
        }
        else
        {
            GameObject pickaxe = Instantiate(pickAxePrefab);
            return pickaxe;
        }
    }

    public void ReturnPickaxeFromPool(GameObject pickaxe)
    {
        pickaxePool.Enqueue(pickaxe);
        pickaxe.SetActive(false);
    }
    #endregion

    #region Rock
    public GameObject GetRockFromPool()
    {
        if (rockPool.Count > 0)
        {
            GameObject rock = rockPool.Dequeue();
            rock.SetActive(true);
            return rock;
        }
        else
        {
            GameObject rock = Instantiate(rockPrefab);
            return rock;
        }
    }

    public void ReturnRockFromPool(GameObject rock)
    {
        rockPool.Enqueue(rock);
        rock.SetActive(false);
    }
    #endregion

    #region Rock Particle
    public GameObject GetRockParticleFromPool()
    {
        if (rockParticlePool.Count > 0)
        {
            GameObject rockParticle = rockParticlePool.Dequeue();
            rockParticle.SetActive(true);
            return rockParticle;
        }
        else
        {
            GameObject rockParticle = Instantiate(rockParticlePrefab);
            return rockParticle;
        }
    }

    public void ReturnRockParticleToPool(GameObject rockParticle)
    {
        rockParticlePool.Enqueue(rockParticle);
        rockParticle.SetActive(false);
    }
    #endregion

    #region Tile
    public GameObject GetTileFromPool()
    {
        if (tilePool.Count > 0)
        {
            GameObject tile = tilePool.Dequeue();
            tile.SetActive(true);
            return tile;
        }
        else
        {
            GameObject tile = Instantiate(tilePrefab);
            return tile;
        }
    }

    public void ReturnTileFromPool(GameObject tile)
    {
        tilePool.Enqueue(tile);
        tile.SetActive(false);
    }
    #endregion

    #region Mine material
    public GameObject GetTheMineMaterialFromPool()
    {
        if (mineMaterialPool.Count > 0)
        {
            GameObject theMine = mineMaterialPool.Dequeue();
            theMine.SetActive(true);
            return theMine;
        }
        else
        {
            GameObject theMine = Instantiate(mineMaterialPrefab);
            return theMine;
        }
    }

    public void ReturnTheMineMaterialFromPool(GameObject theMine)
    {
        mineMaterialPool.Enqueue(theMine);
        theMine.SetActive(false);
    }
    #endregion


    //Projectiles
    #region Beam of light
    public GameObject GetBeamOfLightFromPool()
    {
        if (beamOfLightPool.Count > 0)
        {
            GameObject beamOfLight = beamOfLightPool.Dequeue();
            beamOfLight.SetActive(true);
            return beamOfLight;
        }
        else
        {
            GameObject beamOfLight = Instantiate(beamOfLightPrefab);
            return beamOfLight;
        }
    }

    public void ReturnBeamOfLight(GameObject beamOfLight)
    {
        beamOfLightPool.Enqueue(beamOfLight);
        beamOfLight.SetActive(false);
    }
    #endregion

    #region Electricity splash
    public GameObject GetElectricitySplashFromPool()
    {
        if (electricityPool.Count > 0)
        {
            GameObject electricity = electricityPool.Dequeue();
            electricity.SetActive(true);
            return electricity;
        }
        else
        {
            GameObject electricity = Instantiate(electricitySplashPrefab);
            return electricity;
        }
    }

    public void ReturnElectricitySplashFromPool(GameObject electricity)
    {
        electricityPool.Enqueue(electricity);
        electricity.SetActive(false);
    }
    #endregion

    #region Dynamite
    public GameObject GetDynamiteFromPool()
    {
        if (dynamitePool.Count > 0)
        {
            GameObject dynamite = dynamitePool.Dequeue();
            dynamite.SetActive(true);
            return dynamite;
        }
        else
        {
            GameObject dynamite = Instantiate(dynamitePrefab);
            return dynamite;
        }
    }

    public void ReturnDynamiteFromPool(GameObject dynamite)
    {
        dynamitePool.Enqueue(dynamite);
        dynamite.SetActive(false);
    }
    #endregion

    #region Plazma Ball
    public GameObject GetPlazmaBallFromPool()
    {
        if (plazmaBallPool.Count > 0)
        {
            GameObject plazmaBall = plazmaBallPool.Dequeue();
            plazmaBall.SetActive(true);
            return plazmaBall;
        }
        else
        {
            GameObject plazmaBall = Instantiate(plazmaBallPrefab);
            return plazmaBall;
        }
    }

    public void ReturnPlazmaBallToPool(GameObject plazmaBall)
    {
        plazmaBallPool.Enqueue(plazmaBall);
        plazmaBall.SetActive(false);
    }
    #endregion

    #region ColliderCircle
    public GameObject GetColliderCircleFromPool()
    {
        if (circleColliderPool.Count > 0)
        {
            GameObject circleCollider = circleColliderPool.Dequeue();
            circleCollider.SetActive(true);
            return circleCollider;
        }
        else
        {
            GameObject circleCollider = Instantiate(circleColliderPrefab);
            return circleCollider;
        }
    }

    public void ReturnCircleColliderFromPool(GameObject circleCollider)
    {
        circleColliderPool.Enqueue(circleCollider);
        circleCollider.SetActive(false);
    }
    #endregion
}
