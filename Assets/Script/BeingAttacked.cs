using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeingAttacked : MonoBehaviour
{
    public bool attacked = false;
    public Animator animator;
    public GameObject hero;
    public float freezingTime =0f ;
    public bool backwardMove = false;
    Vector3 targetPos;
    public bool faceHero = false;

    public int MaxHP = 3;
    public int HP;
    public float timeInvincible = 0;
    public bool damaged = false;
    public bool isBoss = false;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        hero = GameObject.Find("_Hero");
        slider.value = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = ((float)HP) / ((float)MaxHP);
        if (HP <= 0 && !isBoss)
        {
            HP = 0;
            Destroy(this.gameObject);
            hero.GetComponent<Level_s>().exe += 1;
        }
        else if (HP <= 0 && isBoss)
        {
            HP = 0;
        }

        if (attacked)
        {
            this.GetComponent<Slime_s>().audioSource.Stop();
            //check if the enemy move back due to attack
            if (!backwardMove)
            {
                this.gameObject.tag = "Untagged";
                damaged = true;
                targetPos = transform.position;
                animator.SetBool("Attacked", attacked);
                float gap = this.transform.position.x - hero.transform.position.x;

                if (GetComponent<Slime_s>().movingDirection.x < 0 && gap <= 0)
                {
                    //slime is moving toward left and not facing to hero
                    
                    animator.SetBool("MoveRight", true);
                    animator.SetBool("MoveLeft", false);
                    targetPos.x -= 3f;
                }
                else if (GetComponent<Slime_s>().movingDirection.x < 0 && gap > 0)
                {
                    //slime is moving toward left and facing to hero
                    
                    animator.SetBool("MoveRight", false);
                    animator.SetBool("MoveLeft", true);
                    
                    targetPos.x += 3f;
                }
                else if (GetComponent<Slime_s>().movingDirection.x > 0 && gap >= 0)
                {
                    //slime is moving toward right and not facing to hero
                    
                    animator.SetBool("MoveRight", false);
                    animator.SetBool("MoveLeft", true);

                    targetPos.x += 3f;
                }
                else if (GetComponent<Slime_s>().movingDirection.x > 0 && gap < 0)
                {
                    //slime is moving toward right and facing to hero
                   
                    animator.SetBool("MoveRight", true);
                    animator.SetBool("MoveLeft", false);

                    targetPos.x -= 3f;
                }
                this.transform.position = Vector3.Lerp(this.transform.position, targetPos, 0.2f);
                GetComponent<Slime_s>().movingSpeed = 0f;
                backwardMove = true;
            }

            freezingTime += Time.deltaTime;
            if (freezingTime > 1.5) {
                this.gameObject.tag = "Slime";
                GetComponent<Slime_s>().movingSpeed = 2f;
                HP -= hero.GetComponent<HeroAttack_s>().attackForce ;
                attacked = false;
                animator.SetBool("Attacked", false);
                backwardMove = false;
                freezingTime = 0f;
            }
        }
        EnemyDamageEffect();
    }


    void EnemyDamageEffect()
    {
        if (damaged)
        {
            timeInvincible += Time.deltaTime;
            if (timeInvincible < 1.5f)
            {
                float remainder = timeInvincible % 0.3f;
                this.GetComponent<Renderer>().enabled = (remainder > 0.15f);
            }
            else
            {
                this.GetComponent<Renderer>().enabled = true;
                damaged = false;
                timeInvincible = 0;
            }


        }
    }
}
