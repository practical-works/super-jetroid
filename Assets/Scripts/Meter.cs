using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter : MonoBehaviour {

    public float air;
    public float maxAir = 10f;
    public float airBurnRate = 0.1f;
    public Texture2D foregroundBar;
    public Texture2D backgroundBar;
    public int iconWidth = 32;
    public Vector2 barPosition = new Vector2(20f, 20f);

    private Actor actor;

    void Start()
    {
        actor = GameObject.FindObjectOfType<Actor>();
        air = maxAir;
    }

    void Update()
    {
        if (actor)
        {
            if (air > 0)
            {
                air -= airBurnRate * Time.deltaTime;
            }
            else
            {
                actor.GetComponent<Exploder>().Explode();
            }
        }
    }

    void OnGUI()
    {
        float ratio = actor ? Mathf.Clamp01(air / maxAir) : 0;
        Draw(ratio);
    }

    void Draw(float ratio)
    {
        float x = barPosition.x, y =  barPosition.y;
        float width = backgroundBar.width, height = backgroundBar.height;
        float nWidth = (ratio * (width - iconWidth)) + iconWidth;
        
        GUI.DrawTexture(new Rect(x, y, width, height), backgroundBar);

        GUI.BeginGroup(new Rect(x, y, nWidth, height));
        GUI.DrawTexture(new Rect(0, 0, width, height), foregroundBar);
        GUI.EndGroup();
    }
}
