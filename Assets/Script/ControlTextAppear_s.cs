using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTextAppear_s : MonoBehaviour
{
    public GameObject txt;
    // Start is called before the first frame update
    void Start()
    {
        txt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        txt.SetActive(true);
    }

    private void OnMouseExit()
    {
        txt.SetActive(false);
    }
}
