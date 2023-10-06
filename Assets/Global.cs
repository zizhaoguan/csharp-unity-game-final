using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State { Defualt = 0, Openning = 1, SeeSlime = 2, End = 3, Death = 4};

public class Global : MonoBehaviour
{
    public static Global instance;
    public static bool isSceneChanged = false;
    public static int MaxHP;
    public static int HP;
    public static int level;
    public static int exe;
    public static int requireExe;
    public static int attackForce;
    public static float attackRadius;
    public static bool isEquipSword;
    public static State state;
    public static bool isCheckSwordBox;

    static Global()
    {
        GameObject go = new GameObject("Global");
        DontDestroyOnLoad(go);
        instance = go.AddComponent<Global>();
        

    }

    public void SaveHeroInfo(GameObject hero)
    {
        MaxHP = hero.GetComponent<Hero_s>().MaxHP;
        HP = hero.GetComponent<Hero_s>().HP;
        level = hero.GetComponent<Level_s>().level;
        exe = hero.GetComponent<Level_s>().exe;
        requireExe = hero.GetComponent<Level_s>().requireExe;
        attackForce = hero.GetComponent<HeroAttack_s>().attackForce;
        attackRadius = hero.GetComponent<HeroAttack_s>().attackRadius;
        isEquipSword = hero.GetComponent<Equipment_s>().isEquipSword;
        isSceneChanged = true;
        isCheckSwordBox = hero.GetComponent<Equipment_s>().isCheckSwordBox;

    }

    public void GetHeroInfo(GameObject hero)
    {
        hero.GetComponent<Hero_s>().MaxHP = MaxHP;
        hero.GetComponent<Hero_s>().HP = HP;
        hero.GetComponent<Level_s>().level = level;
        hero.GetComponent<Level_s>().exe = exe;
        hero.GetComponent<Level_s>().requireExe = requireExe;
        hero.GetComponent<HeroAttack_s>().attackForce = attackForce;
        hero.GetComponent<HeroAttack_s>().attackRadius = attackRadius;
        hero.GetComponent<Equipment_s>().isEquipSword = isEquipSword;
        isSceneChanged = false;
        hero.GetComponent<Equipment_s>().isCheckSwordBox = isCheckSwordBox;
    }

    public void SetGameState(State state)
    {
        Global.state = state;
    }
    
    public State GetState()
    {
        return Global.state;
    }
   
}
