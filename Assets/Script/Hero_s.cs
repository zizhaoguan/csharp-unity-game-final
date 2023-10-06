using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero_s : MonoBehaviour
{
    public float speed = 1f;
    public int HP;
    public int MaxHP = 3;
    public Slider slider;
    public AudioSource audioSource;

    public float timeInvincible = 0;
    public bool damaged = false;

    public Animator animator;
    bool faceLeft = false;
    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
        slider.value = 1f;
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value =(float) ((float)HP) / ((float)MaxHP);
    }

    private void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        Vector2 pos = transform.position;
        if (xAxis < 0)
        {
            animator.SetBool("WalkLeft", true);
            animator.SetBool("WalkRight", false);
            animator.SetBool("FaceLeft", true);
            faceLeft = true;
            pos.x += xAxis * speed * Time.deltaTime;
            transform.position = pos;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else if (xAxis > 0)
        {
            animator.SetBool("WalkLeft", false);
            animator.SetBool("WalkRight", true);
            animator.SetBool("FaceLeft", false);
            pos.x += xAxis * speed * Time.deltaTime;
            transform.position = pos;
            faceLeft = false;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            animator.SetBool("WalkLeft", false);
            animator.SetBool("WalkRight", false);
        }

        if (yAxis < 0)
        {
            if (faceLeft)
            {
                animator.SetBool("WalkLeft", true);
                animator.SetBool("WalkRight", false);
            }
            else if (!faceLeft)
            {
                animator.SetBool("WalkLeft", false);
                animator.SetBool("WalkRight", true);
            }
            
            pos.y += yAxis * speed * Time.deltaTime;
            transform.position = pos;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else if (yAxis > 0)
        {
            if (faceLeft)
            {
                animator.SetBool("WalkLeft", true);
                animator.SetBool("WalkRight", false);
            }
            else if (!faceLeft)
            {
                animator.SetBool("WalkLeft", false);
                animator.SetBool("WalkRight", true);
            }
            pos.y += yAxis * speed * Time.deltaTime;
            transform.position = pos;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            //animator.SetBool("WalkLeft", false);
            //animator.SetBool("WalkRight", false);
        }

        HeroDamageEffect();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Slime" && timeInvincible == 0)
        {
            if (Vector3.Distance(this.transform.position, collision.transform.position) < 0.65)
            {
                print("Attacked");
                damaged = true;
                HP--;
            }
          
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Slime" && timeInvincible == 0)
        {
            if (Vector3.Distance(this.transform.position, collision.transform.position) < 0.65)
            {
                print("Attacked");
                damaged = true;
                HP--;
            }

        }
    }

    void HeroDamageEffect()
    {
        if (damaged)
        {
            timeInvincible += Time.deltaTime;
            if (timeInvincible < 3f)
            {
                float remainder = timeInvincible % 0.3f;
                this.GetComponent<Renderer>().enabled = (remainder > 0.15f);
            }
            else
            {
                this.GetComponent<Renderer>().enabled = true;
                damaged = false;
                timeInvincible = 0;
            }
           
           
        }
    }


    
}
