using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRockCollider : MonoBehaviour
{
    private GameObject player;
    private float speed = 30.0f;
    public GameObject explosion;
    private float targetTime = 7.0f;
    private bool touched = false;
    private AudioSource audio;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        transform.LookAt(player.transform.position);
        audio = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!touched) {
            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
        transform.position += transform.forward * speed * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        touched = true;
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerStats>().currentHealth -= 40;
            StartCoroutine(Delay());
        }
    }
    public IEnumerator Delay()
    {
        GameObject child = gameObject.transform.GetChild(0).gameObject;
        child.SetActive(false);
        GameObject explosionCollider = Instantiate(explosion, transform.position, transform.rotation);
        explosionCollider.transform.GetChild(0).gameObject.SetActive(true);
        audio.PlayOneShot(audio.clip);
        yield return new WaitForSeconds(2);
        Destroy(explosionCollider);
        Destroy(gameObject);
    }
}
