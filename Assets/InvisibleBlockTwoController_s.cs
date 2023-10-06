using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBlockTwoController_s : MonoBehaviour
{
    public GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameController.GetComponent<SceneOneControl_s>().state = (State)2;
            Destroy(this.gameObject);
        }
    }
}
