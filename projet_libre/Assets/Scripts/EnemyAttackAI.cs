using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackAI : MonoBehaviour
{
    //La référance a l'object a suivre
    private Transform joueur;
    //L'ennemie qui va suivre l'object
    public NavMeshAgent ennemi;
    /*Paramètre modifiable, la distance pour que l'ennemie attaque, la distance pour qui commence a chaser, la distance
     de perte de vue*/
    public float proximiterAttaque = 0.1f;
    public float distDetection = 10.0f;
    public float perdreDeVue = 50.0f;
    //Valeur aidant le code
    private float distance;
    private bool suivre;
    //On créer une nouvelle object du script followAI
    private EnemyFollowAI follow;

    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindWithTag("Player").transform;
        //on dit que notre object est l'object FollowAI deja présent sur notre ennemie
        follow = transform.GetComponent<EnemyFollowAI>();
        //Ne suis pas par default, en appelant la méthode MakeEntityMove de notre object, avec la valeur false pour ne pas suivre
        suivre = false;
        follow.MakeEntityMove(joueur, false);
    }

    // Update is called once per frame
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

        //Si on à dit de suivre l'object (et que les paramètre nécésaire ne sont pas manquant)
        if (suivre == true && joueur != null)
        {

            //Si il est dans la proximiter d'attaque
            if (distance < proximiterAttaque)
            {
                gameObject.GetComponent<EnemyAttack>().isAttacking = true;
                //il devra arrèter suivre
                suivre = false;
                follow.MakeEntityMove(joueur, false);
                gameObject.GetComponent<Animator>().SetTrigger("Attack");
            
            } 
            else
            {
                gameObject.GetComponent<EnemyAttack>().isAttacking = false;
            }
        }
        //sinon on ne doit pas suivre, on arrete le movement
        else
        {
            follow.MakeEntityMove(joueur, false);
        }
    }
}
