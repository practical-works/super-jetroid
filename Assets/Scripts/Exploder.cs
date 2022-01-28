using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exploder : MonoBehaviour
{
    public ExplosionParticle particle;
    public int particlesCount = 5;
    public AudioClip explosionSound;

    public void Explode()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);

        for (int i = 0; i < particlesCount; i++)
        {
            ExplosionParticle newParticle = Instantiate(particle, transform.position, Quaternion.identity);
            Rigidbody2D rigidbody = newParticle.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(new Vector2(Random.Range(-50, 50), Random.Range(100, 400)));
        }

        if (tag == "Player")
        {
            new GameObject("GameOver", components: typeof(GameOver));
        }
    }
}
