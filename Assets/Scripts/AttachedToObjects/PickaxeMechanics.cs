using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeMechanics : MonoBehaviour
{
    public Animation swingAnim;

    public Transform rightCollider, leftCollider;
    public SpriteRenderer pickAxeIconSprite;

    public Transform pickaxe1, pickaxe2, pickaxe3, pickaxe4, pickaxe5, pickaxe6, pickaxe7, pickaxe8, pickaxe9, pickaxe10, pickaxe11, pickaxe12, pickaxe13, pickaxe14;
    public Transform pickaxe1_Skin1, pickaxe2_Skin1, pickaxe3_Skin1, pickaxe4_Skin1, pickaxe5_Skin1, pickaxe6_Skin1, pickaxe7_Skin1, pickaxe8_Skin1, pickaxe9_Skin1, pickaxe10_Skin1, pickaxe11_Skin1, pickaxe12_Skin1, pickaxe13_Skin1;
    public Transform pickaxe1_Skin2, pickaxe2_Skin2, pickaxe3_Skin2, pickaxe4_Skin2, pickaxe5_Skin2, pickaxe6_Skin2, pickaxe7_Skin2, pickaxe8_Skin2, pickaxe9_Skin2, pickaxe10_Skin2, pickaxe11_Skin2, pickaxe12_Skin2, pickaxe13_Skin2;

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

        if(TheAnvil.isDLC == true)
        {
            pickaxe1_Skin1 = transform.Find("pickaxe_MrRusty_Skin1");
            pickaxe2_Skin1 = transform.Find("pickaxe2_Skin1");
            pickaxe3_Skin1 = transform.Find("pickaxe3_Skin1");
            pickaxe4_Skin1 = transform.Find("pickaxe4_Skin1");
            pickaxe5_Skin1 = transform.Find("pickaxe5_Skin1");
            pickaxe6_Skin1 = transform.Find("pickaxe6_Skin1");
            pickaxe7_Skin1 = transform.Find("pickaxe7_Skin1");
            pickaxe8_Skin1 = transform.Find("pickaxe8_Skin1");
            pickaxe9_Skin1 = transform.Find("pickaxe9_Skin1");
            pickaxe10_Skin1 = transform.Find("pickaxe10_Skin1");
            pickaxe11_Skin1 = transform.Find("pickaxe11_Skin1");
            pickaxe12_Skin1 = transform.Find("pickaxe12_Skin1");
            pickaxe13_Skin1 = transform.Find("pickaxe13_Skin1");

            pickaxe1_Skin2 = transform.Find("pickaxe_MrRusty_Skin2");
            pickaxe2_Skin2 = transform.Find("pickaxe2_Skin2");
            pickaxe3_Skin2 = transform.Find("pickaxe3_Skin2");
            pickaxe4_Skin2 = transform.Find("pickaxe4_Skin2");
            pickaxe5_Skin2 = transform.Find("pickaxe5_Skin2");
            pickaxe6_Skin2 = transform.Find("pickaxe6_Skin2");
            pickaxe7_Skin2 = transform.Find("pickaxe7_Skin2");
            pickaxe8_Skin2 = transform.Find("pickaxe8_Skin2");
            pickaxe9_Skin2 = transform.Find("pickaxe9_Skin2");
            pickaxe10_Skin2 = transform.Find("pickaxe10_Skin2");
            pickaxe11_Skin2 = transform.Find("pickaxe11_Skin2");
            pickaxe12_Skin2 = transform.Find("pickaxe12_Skin2");
            pickaxe13_Skin2 = transform.Find("pickaxe13_Skin2");
        }

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

        if(TheAnvil.isDLC == true)
        {
            if (TheAnvil.pickaxe1_equipped)
            {
                if (TheAnvil.pickaxe1_skinsChosen == 0) { equippedPickaxe = pickaxe1; }
                if (TheAnvil.pickaxe1_skinsChosen == 1) { equippedPickaxe = pickaxe1_Skin1; }
                if (TheAnvil.pickaxe1_skinsChosen == 2) { equippedPickaxe = pickaxe1_Skin2; }
            }

            if (TheAnvil.pickaxe2_equipped)
            {
                if (TheAnvil.pickaxe2_skinsChosen == 0) { equippedPickaxe = pickaxe2; }
                if (TheAnvil.pickaxe2_skinsChosen == 1) { equippedPickaxe = pickaxe2_Skin1; }
                if (TheAnvil.pickaxe2_skinsChosen == 2) { equippedPickaxe = pickaxe2_Skin2; }
            }

            if (TheAnvil.pickaxe3_equipped)
            {
                if (TheAnvil.pickaxe3_skinsChosen == 0) { equippedPickaxe = pickaxe3; }
                if (TheAnvil.pickaxe3_skinsChosen == 1) { equippedPickaxe = pickaxe3_Skin1; }
                if (TheAnvil.pickaxe3_skinsChosen == 2) { equippedPickaxe = pickaxe3_Skin2; }
            }

            if (TheAnvil.pickaxe4_equipped)
            {
                if (TheAnvil.pickaxe4_skinsChosen == 0) { equippedPickaxe = pickaxe4; }
                if (TheAnvil.pickaxe4_skinsChosen == 1) { equippedPickaxe = pickaxe4_Skin1; }
                if (TheAnvil.pickaxe4_skinsChosen == 2) { equippedPickaxe = pickaxe4_Skin2; }
            }

            if (TheAnvil.pickaxe5_equipped)
            {
                if (TheAnvil.pickaxe5_skinsChosen == 0) { equippedPickaxe = pickaxe5; }
                if (TheAnvil.pickaxe5_skinsChosen == 1) { equippedPickaxe = pickaxe5_Skin1; }
                if (TheAnvil.pickaxe5_skinsChosen == 2) { equippedPickaxe = pickaxe5_Skin2; }
            }

            if (TheAnvil.pickaxe6_equipped)
            {
                if (TheAnvil.pickaxe6_skinsChosen == 0) { equippedPickaxe = pickaxe6; }
                if (TheAnvil.pickaxe6_skinsChosen == 1) { equippedPickaxe = pickaxe6_Skin1; }
                if (TheAnvil.pickaxe6_skinsChosen == 2) { equippedPickaxe = pickaxe6_Skin2; }
            }

            if (TheAnvil.pickaxe7_equipped)
            {
                if (TheAnvil.pickaxe7_skinsChosen == 0) { equippedPickaxe = pickaxe7; }
                if (TheAnvil.pickaxe7_skinsChosen == 1) { equippedPickaxe = pickaxe7_Skin1; }
                if (TheAnvil.pickaxe7_skinsChosen == 2) { equippedPickaxe = pickaxe7_Skin2; }
            }

            if (TheAnvil.pickaxe8_equipped)
            {
                if (TheAnvil.pickaxe8_skinsChosen == 0) { equippedPickaxe = pickaxe8; }
                if (TheAnvil.pickaxe8_skinsChosen == 1) { equippedPickaxe = pickaxe8_Skin1; }
                if (TheAnvil.pickaxe8_skinsChosen == 2) { equippedPickaxe = pickaxe8_Skin2; }
            }

            if (TheAnvil.pickaxe9_equipped)
            {
                if (TheAnvil.pickaxe9_skinsChosen == 0) { equippedPickaxe = pickaxe9; }
                if (TheAnvil.pickaxe9_skinsChosen == 1) { equippedPickaxe = pickaxe9_Skin1; }
                if (TheAnvil.pickaxe9_skinsChosen == 2) { equippedPickaxe = pickaxe9_Skin2; }
            }

            if (TheAnvil.pickaxe10_equipped)
            {
                if (TheAnvil.pickaxe10_skinsChosen == 0) { equippedPickaxe = pickaxe10; }
                if (TheAnvil.pickaxe10_skinsChosen == 1) { equippedPickaxe = pickaxe10_Skin1; }
                if (TheAnvil.pickaxe10_skinsChosen == 2) { equippedPickaxe = pickaxe10_Skin2; }
            }

            if (TheAnvil.pickaxe11_equipped)
            {
                if (TheAnvil.pickaxe11_skinsChosen == 0) { equippedPickaxe = pickaxe11; }
                if (TheAnvil.pickaxe11_skinsChosen == 1) { equippedPickaxe = pickaxe11_Skin1; }
                if (TheAnvil.pickaxe11_skinsChosen == 2) { equippedPickaxe = pickaxe11_Skin2; }
            }

            if (TheAnvil.pickaxe12_equipped)
            {
                if (TheAnvil.pickaxe12_skinsChosen == 0) { equippedPickaxe = pickaxe12; }
                if (TheAnvil.pickaxe12_skinsChosen == 1) { equippedPickaxe = pickaxe12_Skin1; }
                if (TheAnvil.pickaxe12_skinsChosen == 2) { equippedPickaxe = pickaxe12_Skin2; }
            }

            if (TheAnvil.pickaxe13_equipped)
            {
                if (TheAnvil.pickaxe13_skinsChosen == 0) { equippedPickaxe = pickaxe13; }
                if (TheAnvil.pickaxe13_skinsChosen == 1) { equippedPickaxe = pickaxe13_Skin1; }
                if (TheAnvil.pickaxe13_skinsChosen == 2) { equippedPickaxe = pickaxe13_Skin2; }
            }
        }

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
