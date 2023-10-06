using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRock_s : MonoBehaviour
{
    public bool moved = false;
    public float timeCount = 0f;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RockDisappearEffect();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("hi1");
            float distance = Vector3.Distance(this.transform.position, collision.transform.position);
            if (distance < 3f) {
                if (Input.GetButtonDown("Fire1"))
                {
                    moved = true;
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("hi1");
            float distance = Vector3.Distance(this.transform.position, collision.transform.position);
            if (distance < 3f)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    moved = true;
                }
            }
        }
    }

    void RockDisappearEffect()
    {
        if (moved)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            
            timeCount += Time.deltaTime;
            if (timeCount < 1.5f)
            {
                float remainder = timeCount % 0.3f;
                this.GetComponent<Renderer>().enabled = (remainder > 0.15f);
            }
            else
            {
                
                this.GetComponent<Renderer>().enabled = true;
                moved = false;
                timeCount = 0;
                Destroy(gameObject);
                
            }


        }
    }
}
