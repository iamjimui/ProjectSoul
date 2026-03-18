using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;
    public HealthBar healthBar;

    public int nbkill = 0;

    public float maxRage = 100;
    public static float currentRage = 0;
    public RageBar rageBar;
    public bool inRage = false;
    private GameObject fireRage;

    public float attaque;
    public float attaqueAOE;
    public float attaqueRageMultiplier;

    void Start()
    {
        fireRage = GameObject.Find("FireSwordPS");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rageBar.SetMaxRage(maxRage);
        Timer.timerOn = true;
    }

    private void Update()
    {
        healthBar.SetHealth(gameObject.GetComponent<PlayerStats>().currentHealth);
        rageBar.SetRage(currentRage);
    }
}
