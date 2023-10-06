using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouse_s : MonoBehaviour
{
    public bool enter = false;
    public float stayTime = 0f;
    public GameObject hero;
    public GameObject gameController;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enter)
        {
            if (stayTime > 1.5f)
            {
                stayTime = 0f;
                Global.instance.SaveHeroInfo(hero);
                Global.instance.SetGameState(gameController.GetComponent<SceneOneControl_s>().state);
                SceneManager.LoadSceneAsync("Home Scene", LoadSceneMode.Single);
            }
            stayTime += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Vector3.Distance(this.transform.position, collision.transform.position) < 1)
            {
                audioSource.Play();
                enter = true;
            }  
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Vector3.Distance(this.transform.position, collision.transform.position) < 1)
            {
                if (!audioSource.isPlaying) { audioSource.Play(); }
                enter = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Vector3.Distance(this.transform.position, collision.transform.position) >1f   )
            {
                enter = false;
                stayTime = 0f;
            }
            
        }
    }
}
