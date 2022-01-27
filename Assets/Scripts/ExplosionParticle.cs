using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticle : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Color _startColor;
    private Color _endColor;
    private float _elapsedTime = 0;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startColor = _spriteRenderer.color;
        _endColor = new Color(_startColor.r, _startColor.g, _startColor.b, 0); // Full transparent
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime;
        _spriteRenderer.color = Color.Lerp(_startColor, _endColor, _elapsedTime / 2f);

        if (_spriteRenderer.color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
