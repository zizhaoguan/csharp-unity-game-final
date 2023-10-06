using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivideSlime_s : MonoBehaviour
{
    public int previousHP;
    public int currentHP;
    public GameObject dividableSlimePrefab;
    
   
    // Start is called before the first frame update
    void Start()
    {
        previousHP = this.GetComponent<BeingAttacked>().HP;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (this.GetComponent<BeingAttacked>().HP > 0 && this.GetComponent<BeingAttacked>().damaged) {
            Invoke("Divide", 2f);
        }
    }

    public void Divide()
    {
        currentHP = this.GetComponent<BeingAttacked>().HP;
        if (currentHP < previousHP) {
            previousHP = currentHP;
            GameObject slime = Instantiate<GameObject>(dividableSlimePrefab);
            slime.GetComponent<DivideSlime_s>().dividableSlimePrefab = this.dividableSlimePrefab;
            slime.transform.position = this.transform.position;
            slime.GetComponent<BeingAttacked>().HP = currentHP;

        }
    }
}
