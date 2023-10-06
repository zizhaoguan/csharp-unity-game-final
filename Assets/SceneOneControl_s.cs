using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneControl_s : MonoBehaviour
{
    public GameObject hero;
    public GameObject playerDialog;
    public State state;
    public GameObject lastMonster;
    
    
    // Start is called before the first frame update
    void Start()
    {
        state =(State) 1;

        playerDialog.SetActive(false);

        if (Global.isSceneChanged) {
            Global.instance.GetHeroInfo(hero);
            state = Global.instance.GetState();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (hero.GetComponent<Hero_s>().HP <= 0) { state = (State)4; }
        if (state == (State)1)
        {
            playerDialog.SetActive(true);
            playerDialog.GetComponent<PlayerDialog_s>().Openning();
            PauseGame();
        }
        else if (state == (State)2)
        {
            playerDialog.SetActive(true);
            playerDialog.GetComponent<PlayerDialog_s>().AttackSlimeTutorial();
            PauseGame();
        }
        else if (state == (State)3)
        {
            playerDialog.SetActive(true);
            playerDialog.GetComponent<PlayerDialog_s>().EndTheGame();
            PauseGame();
        }
        else if (state == (State)4)
        {
            playerDialog.SetActive(true);
            playerDialog.GetComponent<PlayerDialog_s>().LostTheGame();
            PauseGame();
        }
  
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }
    private void StartGame()
    {
        Time.timeScale = 1;
    }
}
