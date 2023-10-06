using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Top_Texture : MonoBehaviour
{
    private string level;
    public int MaxHP;
    public int HP;
    float heroHeight;
    public Texture2D blood_red;
    public Texture2D blood_black;
    // Start is called before the first frame update
    void Start()
    {
        float size_y = this.GetComponent<Collider2D>().bounds.size.y;
        float scale_y = transform.localScale.y;
        heroHeight = size_y * scale_y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y + heroHeight);

        Vector2 bloodSize = GUI.skin.label.CalcSize(new GUIContent(blood_red));

        int blood_width = blood_red.width * (gameObject.GetComponent<Hero_s>().HP/ gameObject.GetComponent<Hero_s>().MaxHP);

        GUI.DrawTexture(new Rect(pos.x - (bloodSize.x / 2), pos.y-bloodSize.y, bloodSize.x, bloodSize.y), blood_black);
        GUI.DrawTexture(new Rect(pos.x - (bloodSize.x / 2), pos.y - bloodSize.y, bloodSize.x, bloodSize.y), blood_red);

        GUI.color = Color.yellow;
    }
}
