using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeMechanics : MonoBehaviour
{
    public Animation swingAnim;

    public Transform rightCollider, leftCollider;
    public SpriteRenderer pickAxeIconSprite;

    public Transform pickaxe1, pickaxe2, pickaxe3, pickaxe4, pickaxe5, pickaxe6, pickaxe7, pickaxe8, pickaxe9, pickaxe10, pickaxe11, pickaxe12, pickaxe13, pickaxe14;
    public Transform hammer;

    public Transform equippedPickaxe;

    private void Awake()
    {
        pickaxe1 = transform.Find("pickaxe_MrRusty");
        pickaxe2 = transform.Find("pickaxe2");
        pickaxe3 = transform.Find("pickaxe3");
        pickaxe4 = transform.Find("pickaxe4");
        pickaxe5 = transform.Find("pickaxe5");
        pickaxe6 = transform.Find("pickaxe6");
        pickaxe7 = transform.Find("pickaxe7");
        pickaxe8 = transform.Find("pickaxe8");
        pickaxe9 = transform.Find("pickaxe9");
        pickaxe10 = transform.Find("pickaxe10");
        pickaxe11 = transform.Find("pickaxe11");
        pickaxe12 = transform.Find("pickaxe12");
        pickaxe13 = transform.Find("pickaxe13");
        pickaxe14 = transform.Find("pickaxe14");

        hammer = transform.Find("hammer");

        rightCollider = transform.Find("right");
        leftCollider = transform.Find("left");

        pickAxeIconSprite = pickaxe1.GetComponent<SpriteRenderer>();

        swingAnim = gameObject.GetComponent<Animation>();
    }

    private void OnEnable()
    {
        if(equippedPickaxe != null) { equippedPickaxe.gameObject.SetActive(false); }

        if (TheAnvil.pickaxe1_equipped) { equippedPickaxe = pickaxe1; }
        if (TheAnvil.pickaxe2_equipped) { equippedPickaxe = pickaxe2; }
        if (TheAnvil.pickaxe3_equipped) { equippedPickaxe = pickaxe3; }
        if (TheAnvil.pickaxe4_equipped) { equippedPickaxe = pickaxe4; }
        if (TheAnvil.pickaxe5_equipped) { equippedPickaxe = pickaxe5; }
        if (TheAnvil.pickaxe6_equipped) { equippedPickaxe = pickaxe6; }
        if (TheAnvil.pickaxe7_equipped) { equippedPickaxe = pickaxe7; }
        if (TheAnvil.pickaxe8_equipped) { equippedPickaxe = pickaxe8; }
        if (TheAnvil.pickaxe9_equipped) { equippedPickaxe = pickaxe9; }
        if (TheAnvil.pickaxe10_equipped) { equippedPickaxe = pickaxe10; }
        if (TheAnvil.pickaxe11_equipped) { equippedPickaxe = pickaxe11; }
        if (TheAnvil.pickaxe12_equipped) { equippedPickaxe = pickaxe12; }
        if (TheAnvil.pickaxe13_equipped) { equippedPickaxe = pickaxe13; }
        if (TheAnvil.pickaxe14_equipped) { equippedPickaxe = pickaxe14; }

        equippedPickaxe.gameObject.SetActive(true);

        Color c = pickAxeIconSprite.color;
        c.a = 1f;
        pickAxeIconSprite.color = c;

        rightCollider.gameObject.SetActive(false);
        leftCollider.gameObject.SetActive(false);

        StartCoroutine(SpawnAndSwing());

        if (LevelMechanics.itsHammerTime_chosen)
        {
            float random = Random.Range(0,100);
            if(random < LevelMechanics.hammerChance)
            {
                AllStats.hammersSpawned += 1;

                equippedPickaxe.gameObject.SetActive(false);
                hammer.gameObject.SetActive(true);

                rightCollider.gameObject.layer = 7;
                leftCollider.gameObject.layer = 7;
            }
            else
            {
                CheckPickaxe();
            }
        }
        else
        {
            CheckPickaxe();
        }
    }

    public void CheckPickaxe()
    {
        rightCollider.gameObject.layer = 6;
        leftCollider.gameObject.layer = 6;

        hammer.gameObject.SetActive(false);

        equippedPickaxe.gameObject.SetActive(true);
    }

    IEnumerator SpawnAndSwing()
    {
        yield return new WaitForSeconds(0.02f);

        bool isRight = false;

        if (gameObject.layer == 6)
        {
            isRight = true;
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 8);
            swingAnim.Play("Swing");
        }
        else 
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, -8);
            swingAnim.Play("SwingLeft");
        }

        yield return new WaitForSeconds(0.25f);
        
        if(isRight == true) { rightCollider.gameObject.SetActive(true); }
        else { leftCollider.gameObject.SetActive(true); }

        yield return new WaitForSeconds(0.03f);

        SetIconAlpha(0f);

        gameObject.SetActive(false);
    }

    private void SetIconAlpha(float a)
    {
        Color c = pickAxeIconSprite.color;
        c.a = a;
        pickAxeIconSprite.color = c;
    }

    private void OnDisable()
    {
        ObjectPool.instance.ReturnPickaxeFromPool(gameObject);
    }
}
