using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public ExplosionParticle particle;
    public int particlesCount = 5;

    public void Explode()
    {
        if (particle == null)
        {
            Error.MissingPropertyValue(this, "particle");
            return;
        }

        Destroy(gameObject);

        for (int i = 0; i < particlesCount; i++)
        {
            ExplosionParticle newParticle = Instantiate(particle, transform.position, Quaternion.identity);
            Rigidbody2D rigidbody = newParticle.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(new Vector2(Random.Range(-50, 50), Random.Range(100, 400)));
        }
    }
}
