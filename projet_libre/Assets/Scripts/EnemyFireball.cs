using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour
{
    public GameObject projectile;
    void Start()
    {
        StartCoroutine(AttackDelay());
    }

    IEnumerator AttackDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Animator anim = GetComponent<Animator>();
            anim.SetTrigger("Attack");
            GameObject fireball = Instantiate(projectile, transform);
            fireball.transform.parent = null;
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 10;
            yield return new WaitForSeconds(3);
        }
    }
}
