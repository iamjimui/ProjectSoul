using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ragingNameSpace
{
    public class RageGift : MonoBehaviour
    {
        private GameObject rageEffect;
        private GameObject player;
        void Start()
        {
            rageEffect = GameObject.FindWithTag("Rage");
            player = GameObject.FindWithTag("Player");
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!player.GetComponent<PlayerStats>().inRage)
            {
                if (other.tag == "Player")
                {
                    StartCoroutine(delay());
                    if (PlayerStats.currentRage + 10 >= 100)
                    {
                        PlayerStats.currentRage = 100;
                    }
                    else
                    {
                        PlayerStats.currentRage += 10;
                    }
                    
                }
            }
        }
        IEnumerator delay()
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("PS_Raging").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("PS_Raging").transform.GetChild(1).gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            GameObject.Find("PS_Raging").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("PS_Raging").transform.GetChild(1).gameObject.SetActive(false);
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
        }
    }
}

