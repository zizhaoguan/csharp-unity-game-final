using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTheHouse_s : MonoBehaviour
{
    public bool exit = false;
    public float stayTime = 0f;
    public GameObject hero;
    public AudioSource audioSource;
    public GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (exit)
        {
            if (stayTime > 1.5f)
            {
                stayTime = 0f;
                Global.instance.SaveHeroInfo(hero);
                Global.instance.SetGameState(gameController.GetComponent<HomeSceneControl_s>().state);
                SceneManager.LoadSceneAsync("Scene1", LoadSceneMode.Single);
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
                exit = true;
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
                exit = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Vector3.Distance(this.transform.position, collision.transform.position) > 1f)
            {
                exit = false;
                stayTime = 0f;
            }

        }
    }



}
