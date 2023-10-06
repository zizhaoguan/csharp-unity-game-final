using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GetCoinSound_S : MonoBehaviour
{
    public AudioSource audioSource;
    public bool playSound = false;
    public float playSoundTime = 0.7f;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (playSound) { StartCoroutine(AudioPlayFinished(playSoundTime)); }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Vector3.Distance(this.transform.position, collision.transform.position) < 1)
        {
            audioSource.Play();
            playSound = true;
        }
    }

    private IEnumerator AudioPlayFinished(float time)
    {
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
    }
}
