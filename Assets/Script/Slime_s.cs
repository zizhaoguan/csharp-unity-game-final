using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Slime_s : MonoBehaviour
{
    public string enemyName;
    public float leftSpace = -10f;
    public float rightSpace = 10f;
    public float topSpace = 10f;
    public float downSpace = -10f;
    public Vector3 pos;
    public Vector3 tempPos;
    public Vector3 movingDirection;

    public Transform[] points;
    public int pointIndex;
    public float movingSpeed =2f;

    public bool viewHero = false;
    public bool viewBlock = false;
    public GameObject target;

    private Animator animator;
    public AudioSource audioSource;

    void Start()
    {
        if (!this.GetComponent<BeingAttacked>().isBoss)
        {
            enemyName = "Poor Slime"; 
        }
        else if (this.GetComponent<BeingAttacked>().isBoss)
        {
            enemyName = "Chromalite";
        }
        
        InitializePos();
        animator = GetComponent<Animator>();

        if (target == null) {
            target = GameObject.Find("_Hero");
        }

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, target.transform.position);

        if (transform.position.x > points[0].transform.position.x && transform.position.y > points[0].transform.position.y
            && transform.position.x < points[2].transform.position.x && transform.position.y < points[2].transform.position.y)
        {
            if (distance < 1.5) { viewHero = true; }
            else if (distance >= 2)
            {
                viewHero = false;
            }
        }
        else { viewHero = false; }

        if (!viewHero)
        {
            MoveSelf();
            
        }
        else if (viewHero && !viewBlock)
        {
            followTarget();
        }
    }

    void FixedUpdate()
    {
        
    }

    void MoveSelf()
    {
        Vector3 nextPosition = points[pointIndex].position;
        movingDirection = new Vector3(nextPosition.x - transform.position.x, nextPosition.y - transform.position.y, 0);
        if (movingDirection.x < 0)
        {
            //print("moving " + movingDirection+"\n"+(nextPosition.x - transform.position.x));
            animator.SetBool("MoveLeft", true);
            animator.SetBool("MoveRight", false);
            if (!audioSource.isPlaying) { audioSource.Play(); }

        }
        else if (movingDirection.x > 0)
        {
            //print("moving " + movingDirection + "\n" + (nextPosition.x - transform.position.x));
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveRight", true);
            if (!audioSource.isPlaying) { audioSource.Play(); }
        }
        else
        {
            //print("moving " + movingDirection + "\n" + (nextPosition.x - transform.position.x));
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveRight", false);
            if (!audioSource.isPlaying) { audioSource.Play(); }
        }

        this.transform.Translate(movingSpeed* (movingDirection).normalized* Time.deltaTime, Space.Self);

        if (Vector3.Distance(this.transform.position, nextPosition) <0.1 || viewBlock)
        {
            pointIndex = Random.Range(0, 4);
        }
    }

    void followTarget()
    {
        Vector3 targetPos = target.transform.position;
        movingDirection = new Vector3(targetPos.x - transform.position.x, targetPos.y - transform.position.y, 0);

        if (movingDirection.x < 0)
        {
            //print("moving " + movingDirection+"\n" + (targetPos.x - transform.position.x));
            animator.SetBool("MoveLeft", true);
            animator.SetBool("MoveRight", false);
            if (!audioSource.isPlaying) { audioSource.Play(); }
        }
        else if (movingDirection.x > 0)
        {
           // print("moving " + movingDirection + "\n" + (targetPos.x - transform.position.x));
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveRight", true);
            if (!audioSource.isPlaying) { audioSource.Play(); }
        }
        else
        {
            //print("moving " + movingDirection + "\n" + (targetPos.x - transform.position.x));
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveRight", false);
            if (!audioSource.isPlaying) { audioSource.Play(); }
        }

        this.transform.Translate(movingSpeed * (movingDirection).normalized * Time.deltaTime, Space.Self);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Tree" || collision.tag == "Block")
        {
            tempPos = this.transform.position;
            viewBlock = true;
            viewHero = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Tree" || collision.tag == "Block")
        {
            this.transform.position = tempPos;
            viewBlock = true;
            viewHero = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Tree" || collision.tag == "Block")
        {
            viewBlock = false   ;
        }
    }

 

    void InitializePos()
    {
        GameObject go1 = new GameObject();
        pos = transform.position;
        go1.transform.position = new Vector3(pos.x- leftSpace, pos.y - downSpace, 0);
        go1.transform.rotation = new Quaternion(0, 0, 0, 0);
        go1.transform.localScale = new Vector3(1, 1, 1);
        points[0] = go1.transform;

        GameObject go2 = new GameObject();
        go2.transform.position = new Vector3(pos.x - leftSpace, pos.y + topSpace, 0);
        go2.transform.rotation = new Quaternion(0, 0, 0, 0);
        go2.transform.localScale = new Vector3(1, 1, 1);
        points[1] = go2.transform;

        GameObject go3 = new GameObject();
        go3.transform.position = new Vector3(pos.x + rightSpace, pos.y + topSpace, 0);
        go3.transform.rotation = new Quaternion(0, 0, 0, 0);
        go3.transform.localScale = new Vector3(1, 1, 1);
        points[2] = go3.transform;

        GameObject go4 = new GameObject();
        go4.transform.position = new Vector3(pos.x + rightSpace, pos.y - downSpace, 0);
        go4.transform.rotation = new Quaternion(0, 0, 0, 0);
        go4.transform.localScale = new Vector3(1, 1, 1);
        points[3] = go4.transform;
    }

    
}
