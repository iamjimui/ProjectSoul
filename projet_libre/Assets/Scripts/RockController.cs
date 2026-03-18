using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public GameObject projectile;
    void Update()
    {
        StartCoroutine(AttackDelay());
    }

    IEnumerator AttackDelay()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
            Instantiate(projectile, pos, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
}
