using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDialog_s : MonoBehaviour
{
    private Text txt;
    public GameObject textController;
    public GameObject gameController;
    public GameObject boss;
    public bool isMoreDialog = false;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt = textController.GetComponent<Text>();
        if (!isMoreDialog) {
            txt.text = "...I remember who I was...";
            isMoreDialog = true;
        }
    }

    public void ClickContinue()
    {
        if (isMoreDialog)
        {
            if (count == 0)
            {
                txt.text = "Yes...I am a treasure hunter before...";
                count += 1;
            }
            else if (count == 1)
            {
                txt.text = "But after I got trapped in this forest and cannot get out from here";
                count += 1;
            }
            else if (count == 2)
            {
                txt.text = "Then...I died and became a evil slime...Thank you for letting me go...";
                count += 1;
            }
            else if (count == 3)
            {
                isMoreDialog = false;
                gameController.GetComponent<SceneOneControl_s>().state = (State)3;
                StartGame();
                Destroy(boss);
            }
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
