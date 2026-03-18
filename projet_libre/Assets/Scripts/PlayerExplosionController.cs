using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosionController : MonoBehaviour
{
    private float targetTime = 9.0f;
    private AudioSource audio;
    private bool exploded = false;

    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            Destroy(gameObject);
        }
        else if (targetTime <= 2f && !exploded)
        {
            exploded = true;
            Explode();
        }
    }

    void Explode()
    {
        Vector3 explosionPos = transform.position;

        Collider[] colliders = Physics.OverlapSphere(explosionPos, 6);

        foreach (var hitCollider in colliders)
        {
            if (hitCollider.tag == "Enemy")
            {
                hitCollider.GetComponent<EnemyStats>().currentHealth -= 60;
            }
        }
    }
}
