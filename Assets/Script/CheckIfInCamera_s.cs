using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfInCamera_s : MonoBehaviour
{
    public bool isRendering;
    public float curtTime = 0f;
    public float lastTime = 0f;
    // Start is called before the first frame update
    
    void Update()
    {
        if (isInView(this.transform.position))
        {
            Debug.Log("I am in camera");
            
            this.GetComponent<Slime_s>().enabled = true;
            this.GetComponent<BeingAttacked>().enabled = true;
            this.GetComponent<ControlTextAppear_s>().enabled = true;
        }
        else
        {
            Debug.Log("I am not in camera");

            this.GetComponent<Slime_s>().enabled = false;
            this.GetComponent<BeingAttacked>().enabled = false;
            this.GetComponent<ControlTextAppear_s>().enabled = false;
        }
    }

   

    public bool isInView(Vector3 worldPos)
    {
        Transform camTransform = Camera.main.transform;
        Vector2 enemyPos = Camera.main.WorldToViewportPoint(worldPos);
        Vector3 dist = (worldPos - camTransform.position).normalized;

        float dot = Vector3.Dot(camTransform.forward, dist);

        if (dot > 0 && enemyPos.x >= 0 && enemyPos.x <= 1 && enemyPos.y >= 0 && enemyPos.y <= 1)
        {
            return true;
        }
        else { return false; }
    }

    
}
