using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    void OnParticleCollision(GameObject other)
    {
        GameObject explosion = Instantiate(deathFX, transform.position, Quaternion.identity);
        explosion.transform.parent = parent;

        Destroy(gameObject);
    }

    void AddNonTriggerBoxCollider()
    {
        Collider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }
}
