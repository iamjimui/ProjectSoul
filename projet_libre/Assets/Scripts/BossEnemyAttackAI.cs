using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossEnemyAttackAI : MonoBehaviour
{
    //La position du joueur a référencer
    private Transform joueur;
    //Un agent sur une NavMesh, donc notre enemie(NavMesh est un endroit ou un agent peut marcher)
    public NavMeshAgent ennemi;
    public float proximiterAttaque = 0.1f;
    public float distDetection = 10.0f;
    public float perdreDeVue = 50.0f;
    //Valeur aidant le code
    private float distance;
    private bool suivre;
    public bool isCharging = false;
    public bool isUsingRock = false;
    public bool isUsingInvocation = false;
    public GameObject projectile;
    public GameObject minion;
    private float targetTime = 6.0f;

    // Update is called once per frame
    private Animator animator;
    void Start()
    {
        joueur = GameObject.FindWithTag("Player").transform;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        /*Stock la distance entre l'object et l'ennemie, avec la fonction distance de vector3(c'est une ligne quoi) 
        qui prend la position des deux objets*/
        distance = Vector3.Distance(joueur.position, transform.position);

        /*Vérifie si la distance entre l'object et l'ennemmie est dans la zone de detection, si oui, 
        on dit que il doit suivre le joueur*/
        if (distance < distDetection)
        {
            suivre = true;
        }
        /*Vérifie si la distance entre l'object et l'ennemmie est plus grande que la distance max, si oui, 
        on dit que l'object à été perdu de vue, et que l'ennemie peut arrêter de suivre*/
        if (distance > perdreDeVue)
        {
            suivre = false;
        }
        if (suivre == true && joueur != null)
        {

            //Si il est dans la proximiter d'attaque
            if (distance < proximiterAttaque)
            {

                targetTime -= Time.deltaTime;
                gameObject.GetComponent<EnemyAttack>().isAttacking = true;
                //il devra arrèter suivre
                suivre = false;
                MakeEntityMove(joueur, false);
                if (isUsingRock == false && isUsingInvocation == false)
                {
                    isUsingRock = true;
                }
                if (isUsingRock)
                {
                    if (targetTime <= 1.0f && isCharging == false)
                    {
                        gameObject.GetComponent<Animator>().SetTrigger("Attack");
                        isCharging = true;
                    }
                    if (targetTime <= 0.0f)
                    {
                        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
                        Instantiate(projectile, pos, Quaternion.identity);
                        targetTime = 7.5f;
                        isUsingRock = false;
                        isUsingInvocation = true;
                        isCharging = false;
                    }
                }
                if (isUsingInvocation)
                {
                    if (targetTime <= 3.0f && isCharging == false)
                    {
                        gameObject.transform.GetChild(1).gameObject.SetActive(true);
                        isCharging = true;
                    }
                    if (targetTime <= 0.0f)
                    {
                        Vector3 pos = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
                        for (int i = 0; i < 10; i++)
                        {
                            Instantiate(minion, pos, Quaternion.identity);
                        }
                        gameObject.transform.GetChild(1).gameObject.SetActive(false);
                        targetTime = 6.0f;
                        isUsingRock = true;
                        isUsingInvocation = false;
                        isCharging = false;
                    }
                }

            }
            else
            {
                MakeEntityMove(joueur, true);
                gameObject.GetComponent<EnemyAttack>().isAttacking = false;
            }
        }
        //sinon on ne doit pas suivre, on arrete le movement
        else
        {
            MakeEntityMove(joueur, false);
        }
    }

    //Méthode qui prend un NavMeshAgent(qui va suivre), un Transform de l'object (qui va etre suivi), et si il doit suivre ou pas
    public void MakeEntityMove(Transform refJoueur, bool etat)
    {
        //Si en paramètre l'état était true
        if (etat == true)
        {
            animator.SetBool("isWalking", true);
            ennemi.isStopped = false;
            //Agent suis une destination, et cette destination est la position du joueur
            ennemi.SetDestination(refJoueur.position);
        }
        //Sinon c'est égale a false
        else
        {
            animator.SetBool("isWalking", false);
            //Agent reste en place
            ennemi.isStopped = true;
        }
    }

}
