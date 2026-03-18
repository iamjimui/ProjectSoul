using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.PostProcessing.HistogramMonitor;

public class PlayerColliderEnemy : MonoBehaviour
{
    public float tempsEntreDegat;
    public GameObject Ame;
    public GameObject Cadeaux;
    private int chance;
    private PlayerAttack pa;

    public void Start()
    {
        pa = GameObject.FindWithTag("Player").GetComponent<PlayerAttack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && pa.isAttacking)
        {
            other.GetComponent<Animator>().SetTrigger("GetHit");
            other.GetComponent<EnemyStats>().currentHealth -= transform.GetComponentInParent<PlayerStats>().attaque;
            new WaitForSeconds(tempsEntreDegat);

            chance = Random.Range(1, 21);
            if (chance == 1)
            {
                Vector3 pos = new Vector3(other.transform.position.x, other.transform.position.y + 0.1f, other.transform.position.z);
                Instantiate(Ame, pos, Quaternion.identity);
            }
            if (chance == 2)
            {
                Vector3 pos = new Vector3(other.transform.position.x, other.transform.position.y + 0.1f, other.transform.position.z);
                Instantiate(Cadeaux, pos, Quaternion.identity);
            }

        }
    }
}
