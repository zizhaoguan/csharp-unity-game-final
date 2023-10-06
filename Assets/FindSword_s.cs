using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindSword_s : MonoBehaviour
{
    public Animator animator;
    
    public float count = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject hero = GameObject.Find("_Hero");

        if (hero.GetComponent<Equipment_s>().isEquipSword && !hero.GetComponent<Equipment_s>().isCheckSwordBox) {
            animator.SetBool("FindSword", true);
            hero.GetComponent<Equipment_s>().isCheckSwordBox = true;

        }

        if (hero.GetComponent<Equipment_s>().isCheckSwordBox) {
            count += Time.deltaTime;
            if (count > 1.5f) { animator.SetBool("FindSword", false); }

        }
    }
}
