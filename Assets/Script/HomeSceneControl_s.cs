using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSceneControl_s : MonoBehaviour
{
    public GameObject hero;
    public State state;
    // Start is called before the first frame update
    void Start()
    {
        if (Global.isSceneChanged) {
            Global.instance.GetHeroInfo(hero);
            state = Global.instance.GetState();
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
