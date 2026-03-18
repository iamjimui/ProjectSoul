using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour
{
    public HealthBar healthBar;
    public RageBar rageBar;
    public bool inRage = false;
    private GameObject fireRage;

    private float time;
    private float timeDelay;

    public GameObject playerFireball;
    public Image fireball_skill_image;
    public GameObject playerExplosion;
    public Image explosion_skill_image;

    public float fireballCooldown = 2.0f;
    public float explosionCooldown = 30.0f;
    private bool isFireballCooldown = false;
    private bool isExplosionCooldown = false;

    void Start()
    {
        fireRage = GameObject.Find("FireSwordPS");
        time = 0f;
        timeDelay = 1f;
        fireball_skill_image.fillAmount = 1;
        explosion_skill_image.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFireballCooldown)
        {
            fireball_skill_image.fillAmount += 1 / fireballCooldown * Time.deltaTime;

            if (fireball_skill_image.fillAmount >= 1)
            {
                fireball_skill_image.fillAmount = 1;
                isFireballCooldown = false;
            }
        }
        if (isExplosionCooldown)
        {
            explosion_skill_image.fillAmount += 1 / explosionCooldown * Time.deltaTime;

            if (explosion_skill_image.fillAmount >= 1)
            {
                explosion_skill_image.fillAmount = 1;
                isExplosionCooldown = false;
            }
        }
        if (PlayerStats.currentRage >= 20)
        {
            if (!isFireballCooldown && Input.GetKeyDown(KeyCode.X))
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);
                GameObject fireball = Instantiate(playerFireball, pos, Quaternion.identity);
                fireball.transform.parent = null;
                Rigidbody rb = fireball.GetComponent<Rigidbody>();
                rb.velocity = transform.forward * 10;
                PlayerStats.currentRage -= 10;
                fireball_skill_image.fillAmount = 0;
                isFireballCooldown = true;
            }
        }
        if (PlayerStats.currentRage >= 50)
        {
            if (!isExplosionCooldown && Input.GetKeyDown(KeyCode.C))
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                GameObject explosion = Instantiate(playerExplosion, pos, Quaternion.identity);
                explosion.transform.parent = null;
                PlayerStats.currentRage -= 50;
                explosion_skill_image.fillAmount = 0;
                isExplosionCooldown = true;
            }
        }
        if (PlayerStats.currentRage == gameObject.GetComponent<PlayerStats>().maxRage)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                fireRage.transform.GetChild(0).gameObject.SetActive(true);
                inRage = true;
            }
        }
        if (inRage)
        {
            gameObject.GetComponent<PlayerStats>().attaque = gameObject.GetComponent<PlayerStats>().attaque * gameObject.GetComponent<PlayerStats>().attaqueRageMultiplier;
            if (PlayerStats.currentRage <= 0)
            {
                fireRage.transform.GetChild(0).gameObject.SetActive(false);
                inRage = false;
                gameObject.GetComponent<PlayerStats>().attaque = 15;
            }
            else
            {
                time = time + 1f * Time.deltaTime;
                if (time >= timeDelay)
                {
                    time = 0f;
                    PlayerStats.currentRage -= 10;
                }
            }
        }

        if (gameObject.GetComponent<PlayerStats>().currentHealth <= 0)
        {
            SceneManager.LoadScene(6);
        }
    }
}
