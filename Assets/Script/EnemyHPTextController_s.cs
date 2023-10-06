using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPTextController_s : MonoBehaviour
{
    public Text txt;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        txt = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = enemy.GetComponent<Slime_s>().enemyName+"\nHP:" + enemy.GetComponent<BeingAttacked>().HP.ToString();
    }
}
