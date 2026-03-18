using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public bool isAttacking = false;
    public BoxCollider bc;
    public AudioSource audio;
    private Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                SwordAttack();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (CanAttack)
            {
                SwordAttackAOE();
            }
        }
    }

    public void SwordAttack()
    {
        isAttacking = true;
        CanAttack = false;
        anim.SetTrigger("Attack");
        audio.PlayOneShot(audio.clip);
        StartCoroutine(ResetAttackCooldown());
    }

    public void SwordAttackAOE()
    {
        isAttacking = true;
        CanAttack = false;
        anim.SetTrigger("AttackAOE");
        audio.PlayOneShot(audio.clip);
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown / 2);
        isAttacking = false;
        CanAttack = true;
    }
}
