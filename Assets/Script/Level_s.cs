using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_s : MonoBehaviour
{
    public AudioSource audioSource;
    public int level = 0;
    public int exe = 0;
    public int requireExe;

   
    // Start is called before the first frame update
    void Start()
    {
        requireExe = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (exe >= requireExe)
        {
            requireExe = requireExe + 2;
            audioSource.Play();
            level += 1;
            exe = 0;
            if (level == 1)
            {
                this.gameObject.GetComponent<Hero_s>().MaxHP += 1;
                this.gameObject.GetComponent<Hero_s>().HP = this.gameObject.GetComponent<Hero_s>().MaxHP;
            }
            else if (level == 2)
            {
                this.gameObject.GetComponent<HeroAttack_s>().attackForce += 1;
                this.gameObject.GetComponent<Hero_s>().HP = this.gameObject.GetComponent<Hero_s>().MaxHP;
            }
            else if (level == 3)
            {
                this.gameObject.GetComponent<Hero_s>().MaxHP += 1;
                this.gameObject.GetComponent<Hero_s>().HP = this.gameObject.GetComponent<Hero_s>().MaxHP;
            }
            else if (level == 4)
            {
                this.gameObject.GetComponent<HeroAttack_s>().attackForce += 1;
                this.gameObject.GetComponent<Hero_s>().HP = this.gameObject.GetComponent<Hero_s>().MaxHP;
            }
            else if (level == 5)
            {
                this.gameObject.GetComponent<Hero_s>().MaxHP += 1;
                this.gameObject.GetComponent<Hero_s>().HP = this.gameObject.GetComponent<Hero_s>().MaxHP;
            }
            else if (level == 6)
            {
                this.gameObject.GetComponent<HeroAttack_s>().attackForce += 1;
                this.gameObject.GetComponent<Hero_s>().HP = this.gameObject.GetComponent<Hero_s>().MaxHP;
            }
            else if (level == 7)
            {
                this.gameObject.GetComponent<Hero_s>().MaxHP += 1;
                this.gameObject.GetComponent<Hero_s>().HP = this.gameObject.GetComponent<Hero_s>().MaxHP;
            }
            else if (level == 8)
            {
                this.gameObject.GetComponent<HeroAttack_s>().attackForce += 1;
                this.gameObject.GetComponent<Hero_s>().HP = this.gameObject.GetComponent<Hero_s>().MaxHP;
            }
            else if (level == 9)
            {
                this.gameObject.GetComponent<Hero_s>().MaxHP += 1;
                this.gameObject.GetComponent<Hero_s>().HP = this.gameObject.GetComponent<Hero_s>().MaxHP;
            }
            else if (level == 10)
            {
                this.gameObject.GetComponent<Hero_s>().MaxHP += 1;
                this.gameObject.GetComponent<Hero_s>().HP = this.gameObject.GetComponent<Hero_s>().MaxHP;
            }

        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin" && Vector3.Distance(this.transform.position, collision.transform.position)<1)
        {
            exe += 1;
            collision.tag = "UsedCoin";
        }
    }
}
