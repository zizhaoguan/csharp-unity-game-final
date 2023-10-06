using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelTextControl_s : MonoBehaviour
{
    private Text txt;
    public GameObject hero;
    // Start is called before the first frame update
    void Start()
    {
        txt = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        txt.text = "Lv. " + hero.GetComponent<Level_s>().level.ToString()+" (EXE:" + hero.GetComponent<Level_s>().exe.ToString()+" )"
            + "\n-> next lvl require exe:" + (hero.GetComponent<Level_s>().requireExe-hero.GetComponent<Level_s>().exe).ToString()
            + "\nHP: " + hero.GetComponent<Hero_s>().HP + " ( MaxHP: " +hero.GetComponent<Hero_s>().MaxHP+ " )"
            +  "\nDamage: " +hero.GetComponent<HeroAttack_s>().attackForce+" ( Damage Range: "+ hero.GetComponent<HeroAttack_s>().attackRadius+" )";
    }
    private void OnMouseEnter()
    {
       
    }
}
