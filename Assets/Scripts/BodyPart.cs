using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float elapsedTime = 0;
    private Color startColor;
    private Color endColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
        endColor = new Color(startColor.r, startColor.g, startColor.b, 0);
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        spriteRenderer.color = Color.Lerp(startColor, endColor, elapsedTime / 2);

        if (spriteRenderer.color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
