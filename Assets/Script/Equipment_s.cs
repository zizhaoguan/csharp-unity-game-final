using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment_s : MonoBehaviour
{
    public AudioSource audioSource;
    public bool isEquipSword = false;
    public bool isCheckSwordBox = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipSword()
    {
        
        this.GetComponent<HeroAttack_s>().attackRadius += 1.5f;
        gameObject.GetComponent<HeroAttack_s>().attackForce += 1;
        isEquipSword = true;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Sword" && Vector3.Distance(this.gameObject.transform.position, collision.transform.position)<1.5f && !isEquipSword)
        {
            audioSource.Play();
            EquipSword();
            
            //collision.gameObject.tag = "Untagged";
        }
    }
}
