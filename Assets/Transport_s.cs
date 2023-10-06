using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport_s : MonoBehaviour
{
    public bool enterTransport = false;
    public float stayTime = 0f;
    public AudioSource audioSource;
    public GameObject terminal;
    
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
        if (collision.tag == "Player" && Vector3.Distance(this.transform.position, collision.transform.position) < 1.3f)
        {
            enterTransport = true;
            //stayTime += Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && enterTransport)
        {
            if (stayTime < 1.5f)
            {
                stayTime += Time.deltaTime;
            }
            else
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                collision.transform.position = terminal.transform.position;
                enterTransport = false;
                stayTime = 0f;
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enterTransport = false;
            stayTime = 0f;
        }
    }
}
