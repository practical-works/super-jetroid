using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRandomizer : MonoBehaviour
{
    public string resourceName;
    public Sprite[] sprites = new Sprite[0];
    public int currentSpriteIndex = -1;

    void Start()
    {
        sprites = Resources.LoadAll<Sprite>(resourceName);

        if (sprites != null && sprites.Length != 0)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                if (currentSpriteIndex < 0)
                {
                    currentSpriteIndex = Random.Range(0, sprites.Length);
                }
                else if (currentSpriteIndex >= sprites.Length)
                {
                    currentSpriteIndex = sprites.Length - 1;
                }

                spriteRenderer.sprite = sprites[currentSpriteIndex];
            }
        }
    }
}
