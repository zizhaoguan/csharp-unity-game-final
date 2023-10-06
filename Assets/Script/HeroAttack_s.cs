using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HeroAttack_s : MonoBehaviour
{

    public bool inAttackRange = false;
    public GameObject target;

    [Range(0,180)]
    public float attackAngle1;
    [Range(0,180)]
    public float attackAngle2;
    public float attackRadius = 0f;
    Rigidbody2D rb2d;
    public int attackForce = 0;
    public AudioSource audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            inAttackRange = CheckIfInAttackRange();
        }

        if (inAttackRange && (target != null))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                print("attack!!!!");
                audioSource.Play();
                target.GetComponent<BeingAttacked>().attacked = true;
            }
        }
    }

    bool CheckIfInAttackRange()
    {

        if (target != null) {
            float distance = Vector3.Distance(this.transform.position, target.transform.position);
            Vector3 enemyToHeroVector = target.transform.position - this.transform.position;
            float angle = Vector3.Angle(enemyToHeroVector, this.transform.up);
            //print("target to hero: " + enemyToHeroVector);
            //print("hero direction: " + heroMovingDirection);
            //print("angle = " + angle);

            if (angle >= attackAngle1 && angle <= attackAngle2 && distance <= attackRadius) { return true; }
            else
            {
                target = null;
                return false;
            }
        }
        return false;
        
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Slime")
        {
            target = collision.gameObject;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Slime")
        {
            target = collision.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Slime")
        {
            target = null;
            inAttackRange = false;
        }
    }
}
