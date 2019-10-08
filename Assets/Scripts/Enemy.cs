using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject deathFX;

    void Start()
    {
        addNonTriggerBoxCollider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }
}
