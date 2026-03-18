using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireballController : MonoBehaviour
{
    public GameObject explosion;
    private float targetTime = 7.0f;
    private bool touched = false;
    private AudioSource audio;

    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!touched)
        {
            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            touched = true;
            other.GetComponent<PlayerStats>().currentHealth -= 30;
            StartCoroutine(DestroyExplosion());
        }   
    }

    IEnumerator DestroyExplosion()
    {
        GameObject child = gameObject.transform.GetChild(0).gameObject;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 0;
        child.SetActive(false);

        GameObject explosionCollider = Instantiate(explosion, transform.position, transform.rotation);
        explosionCollider.transform.GetChild(0).gameObject.SetActive(true);
        audio.PlayOneShot(audio.clip);
        yield return new WaitForSeconds(2);
        //GameObject child2 = explosion.transform.GetChild(0).gameObject;
        //child2.SetActive(false);
        explosionCollider.transform.GetChild(0).gameObject.SetActive(false);
        Destroy(explosionCollider);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
