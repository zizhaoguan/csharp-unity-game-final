using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDialog_s : MonoBehaviour
{
    private Text txt;
    public GameObject textController;
    public GameObject gameController;
    public bool isMoreDialog = false;
    public int count = 0;
    private List<string> openningArrList;
    // Start is called before the first frame update
    void Start()
    {
        txt = textController.GetComponent<Text>();
        openningArrList = new List<string>();
        openningArrList.Add("I heard some sound in the forest. \nI must go and have a look!\nI use W,A,S,D to move.");
        openningArrList.Add("Place the pointer on me can see my status!\nWait,I should get my weapon in the house first! It's in a box!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Openning()
    {
        txt = textController.GetComponent<Text>();
        if (!isMoreDialog) {
            txt.text = "I'm a Treature Hunter. Last time the producer forgot to give me weapon...\nSo, I get trapped here!!!";
        }
        
        isMoreDialog = true;
    }

    public void AttackSlimeTutorial()
    {
        txt = textController.GetComponent<Text>();

        if (!isMoreDialog)
        {
            txt.text = "A Slime! Press space to attack it to gain EXE when it get close to you! \nPlace the pointer on it can check its status!";
        }
        
        isMoreDialog = true;
    }
    public void EndTheGame()
    {
        txt = textController.GetComponent<Text>();
        if (!isMoreDialog) {
            txt.text = "Why do I feel so familiar...Did I die already???\nAnyway, everything has been done...This is the end...";
        }
    }
    public void LostTheGame()
    {
        txt = textController.GetComponent<Text>();
        if (!isMoreDialog)
        {
            txt.text = "...Please tell me...This is dream only...I cannot be defeated...\nI am the hero...";
            isMoreDialog = true;
        }
    }

    public void ClickContinue()
    {

        if (isMoreDialog)
        {
            if (gameController.GetComponent<SceneOneControl_s>().state == (State)1)
            {
                if (openningArrList.Count > 0)
                {
                    txt.text = openningArrList[0];
                    openningArrList.RemoveAt(0);
                    if (openningArrList.Count <= 0)
                    {
                        isMoreDialog = false;
                        gameController.GetComponent<SceneOneControl_s>().state = 0;
                    }
                }
                else
                {
                    isMoreDialog = false;
                    gameController.GetComponent<SceneOneControl_s>().state = 0;
                }

            }
            else if (gameController.GetComponent<SceneOneControl_s>().state == (State)2)
            {
                gameController.GetComponent<SceneOneControl_s>().state = 0;
                txt.text = "You can also receive EXE from the coin! \nLet's level up and become more powerful!";
                isMoreDialog = false;
            }
            else if (gameController.GetComponent<SceneOneControl_s>().state == (State)3)
            {
                
                Application.Quit();
            }
            else if (gameController.GetComponent<SceneOneControl_s>().state == (State)4)
            {
                if (count < 1)
                {
                    txt.text = "You killed the hero...\nClick continue to end the game";
                }
                else
                {
                    this.gameObject.SetActive(false);
                    count = 0;
                    Application.Quit();
                }
            }
        }
        else
        {
            gameController.GetComponent<SceneOneControl_s>().state = 0;
            this.gameObject.SetActive(false);
            StartGame();
        }
        count += 1;
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
