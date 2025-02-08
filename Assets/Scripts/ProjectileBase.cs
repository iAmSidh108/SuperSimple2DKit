using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    // Time in seconds before the projectile self-destructs if no collision occurs
    public float lifeTime = 5f;
    public GameObject impactEffect;

    void Start()
    {
        // Schedule destruction after 'lifeTime' seconds
        Destroy(gameObject, lifeTime);
    }

    // Called when the projectile enters a trigger collider
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Player")
    //        return;

    //    Destroy(gameObject);
    //}

    // Called when the projectile collides with something (non-trigger colliders)
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            return;

        
        Destroy(gameObject);
    }

    void PlayImpactEffect()
    {
        if (impactEffect != null)
        {
            ParticleSystem particle= Instantiate(impactEffect, transform.position, transform.rotation).GetComponent<ParticleSystem>();
            particle.Play();
        }
    }

    private void OnDestroy()
    {
        PlayImpactEffect();
    }
}
