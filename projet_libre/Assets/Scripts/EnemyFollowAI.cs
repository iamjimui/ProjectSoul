using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowAI : MonoBehaviour
{
    //La position du joueur a référencer
    private Transform joueur;
    //Un agent sur une NavMesh, donc notre enemie(NavMesh est un endroit ou un agent peut marcher)
    public NavMeshAgent ennemi;
    public bool suivre;
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
        MakeEntityMove(joueur, suivre);
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
