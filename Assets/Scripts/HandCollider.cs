using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollider : MonoBehaviour
{
    public bool isMainCollider;

    public static Vector2 rockHoverPos;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 10)
        {
            rockHoverPos = (Vector2)collision.transform.position;

            GameObject pickaxe = ObjectPool.instance.GetPickaxeFromPool();
            AllStats.pickaxesSpawned += 1;

            float rock_xPos = 0;
            float rock_yPos = 0;

            int randomSwing = Random.Range(1,3);

            if (randomSwing == 1) 
            {
                pickaxe.layer = 6;
                rock_xPos = rockHoverPos.x - Random.Range(0.22f, 0.35f);
                rock_yPos = rockHoverPos.y + Random.Range(0.2f, 0.23f);

                if (SetRockScreen.isInEnding)
                {
                    rock_xPos = rockHoverPos.x - Random.Range(1f, 2.1f);
                    rock_yPos = rockHoverPos.y + Random.Range(0.2f, 1.4f);
                }
            }
            else 
            {
                pickaxe.layer = 11;
                rock_xPos = rockHoverPos.x + Random.Range(0.22f, 0.35f);
                rock_yPos = rockHoverPos.y + Random.Range(0.2f, 0.23f);

                if (SetRockScreen.isInEnding)
                {
                    rock_xPos = rockHoverPos.x + Random.Range(1f, 2.1f);
                    rock_yPos = rockHoverPos.y + Random.Range(0.2f, 1.4f);
                }
            }

            pickaxe.transform.localScale = new Vector2(1.15f, 1.15f);

            if (SetRockScreen.isInEnding)
            {
                pickaxe.transform.localScale = new Vector2(3f, 3f);
            }

            pickaxe.transform.position = new Vector2(rock_xPos, rock_yPos);
        }
    }

    private void OnEnable()
    {
        if(isMainCollider == true)
        {
            if (SkillTree.shootCircleChance_purchased == true)
            {
                if (shootCoroutine == null) { shootCoroutine = StartCoroutine(ChanceToShootCircle()); }
                else { StopCoroutine(shootCoroutine); shootCoroutine = StartCoroutine(ChanceToShootCircle()); }
            }
        }
    }

    private Coroutine shootCoroutine;

    IEnumerator ChanceToShootCircle()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            int random = Random.Range(0,100);
            if(random < SkillTree.circleShootChance)
            {
                if(SetRockScreen.isInEnding == false)
                {
                    GameObject circle = ObjectPool.instance.GetColliderCircleFromPool();
                    circle.transform.position = gameObject.transform.position;
                    Rigidbody2D rb = circle.GetComponent<Rigidbody2D>();

                    Vector2 randomDirection = Random.insideUnitCircle.normalized;
                    float speed = 4f;
                    rb.linearVelocity = randomDirection * speed;
                }
            }
        }
    }
}
