using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace healingNameSpace
{
    public class HealGift : MonoBehaviour
    {
        private GameObject healEffect;
        private GameObject player;
        void Start()
        {
            healEffect = GameObject.FindWithTag("Heal");
            player = GameObject.FindWithTag("Player");
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(delay());
                if (player.GetComponent<PlayerStats>().currentHealth + 20 >= 100)
                {
                    player.GetComponent<PlayerStats>().currentHealth = 100;
                }
                else
                {
                    player.GetComponent<PlayerStats>().currentHealth += 20;
                }
            }
        }
        IEnumerator delay()
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("PS_Healing").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("PS_Healing").transform.GetChild(1).gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            GameObject.Find("PS_Healing").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("PS_Healing").transform.GetChild(1).gameObject.SetActive(false);
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
        }
    }
}

