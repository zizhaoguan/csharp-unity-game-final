using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBlockOneController_s : MonoBehaviour
{
    public GameObject hero;
    // Start is called before the first frame update
    void Start()
    {
        if(hero == null) { hero = GameObject.Find("_Hero"); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && hero.GetComponent<Equipment_s>().isEquipSword) {
            print("123");
            Destroy(this.gameObject);
        }
    }
}
