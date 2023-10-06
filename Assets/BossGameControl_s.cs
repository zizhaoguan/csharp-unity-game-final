using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGameControl_s : MonoBehaviour
{
    public GameObject bossDialogBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<BeingAttacked>().HP > 0)
        {
            bossDialogBox.SetActive(false);
            
        }
        else if (gameObject.GetComponent<BeingAttacked>().HP <= 0) {
            bossDialogBox.SetActive(true);
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
