using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float currentHealth;
    private GameObject player;
    public float attaque;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(currentHealth <= 0){
            player.GetComponent<PlayerStats>().nbkill += 1;
            Object.Destroy(this.gameObject);
        }
    }
}
