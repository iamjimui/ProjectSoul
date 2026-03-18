using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public bool hitting = false;
    public BoxCollider bc;
    public bool isAttacking = false;


    void Update()
    {
        if (isAttacking == true)
        {
            if (CanAttack)
            {
                Attack();
            }
        } 
    }

    public void Attack()
    {
        hitting = true;
        CanAttack = false;
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        if (bc != null)
        {
            yield return new WaitForSeconds(AttackCooldown / 2);
            bc.enabled = true;
            yield return new WaitForSeconds(AttackCooldown / 2);
            bc.enabled = false;
            hitting = false;
            CanAttack = true;
        } 
        else
        {
            yield return new WaitForSeconds(AttackCooldown / 2);
            yield return new WaitForSeconds(AttackCooldown / 2);
            hitting = false;
            CanAttack = true;
        }
    }
}
