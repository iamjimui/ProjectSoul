using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EnemyColliderPlayer : MonoBehaviour
{
    public EnemyAttack ec;
    public float tempsEntreDegat;
    public AudioSource audio;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && ec.hitting)
        {
            audio.PlayOneShot(audio.clip);

            Animator playerAnimator = other.gameObject.transform.GetChild(0).GetComponent<Animator>();
            playerAnimator.SetTrigger("GetHitScreenEffect");

            other.GetComponent<PlayerStats>().currentHealth -= transform.GetComponentInParent<EnemyStats>().attaque;

            new WaitForSeconds(tempsEntreDegat);
        }
    }
}