using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables utilisé pour courrir et la marche en générale - Vitesse
    private float vitesse;
    public float vitesseInitial = 8.0f;
    public float facteurCourir = 2.4f;

    //Variable de gestion de la gravité
    public float gravite = 10.0f;
    public float forceSaut = 2.0f;
    private float verticalVelocity;

    //Variable du personnage(animation, caméra)
    public CharacterController caractere;
    Transform[] model_Selection;
    public new Transform camera;

    //Variable de la rotation du joueur
    float rotationVelocitee;
    public float rotationTemps = 0.1f;

    //Variable initialisé
    void Start()
    {
        vitesse = vitesseInitial;
        model_Selection = GetComponentsInChildren<Transform>();
    }

    //Boucle principale
    void Update()
    {
        Animator anim = model_Selection[1].GetComponent<Animator>();
        //Augmenter la vitesse si le boutton courrir est appuyer et que la vitesse est en dessous de la vitesse en courrant (+ une marge d'erreur)
        if (Input.GetButton("Fire3") && vitesse < (vitesseInitial * facteurCourir)){
            vitesse = vitesse + (6 * facteurCourir) * Time.deltaTime;
        }
        //Remise a la vitesse initiale au si le bouton n'est plus appuyer et que la vitesse est plus haute que la valeur initiale (un système de ralentisement avant de courrir
        else if (!Input.GetButton("Fire3") && vitesse > vitesseInitial ){
            vitesse = vitesse - (3 * facteurCourir) * Time.deltaTime;
        }
        

        //Gestion de la gravité
        //Si le joueur est au sol
        if(caractere.isGrounded){
            verticalVelocity = -gravite * Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Space)){
                verticalVelocity = forceSaut;
            }
        }
        //Si le joueur ne l'est pas
        else{
            //La vélocité dessant, fessant tomber le joueur à une vitesse constante
            verticalVelocity -= gravite * Time.deltaTime;
        }

        //Mise à jour de la position (tomber du joueur) 
        Vector3 tomber = Vector3.zero;
        tomber.y = verticalVelocity;
        caractere.Move(tomber.normalized/ 10);

        //Prise en compte des touches, multiplier par la vitesse puis le temps pour créer le déplacement normale dans les direction appuyer
        float Horizontal = Input.GetAxis("Horizontal") * vitesse * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * vitesse * Time.deltaTime;
        

        //Vecteur représentant la direction du movement sur un axis 3D (Composer de l'axe X et Y des touches)
        Vector3 DirectionXZ = new Vector3(Horizontal, 0.0f, Vertical).normalized;

        //Si une des direction n'est pas nul (Donc si une des touches directionnel à été appuyer) 
        if(DirectionXZ.magnitude >= 0.5f){
            //Direction du déplacement du joueur par rapport des touches appuyer dépendant de l'angle de la camera
            float targetAngle= Mathf.Atan2(DirectionXZ.x, DirectionXZ.z) * Mathf.Rad2Deg + camera.eulerAngles.y;

            //Rotation du model du joueur par rapport de la direction, sa vélocité de la rotation et le temps que prend la rotation avec la fonction Math "SmoothDampAngle
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationVelocitee, rotationTemps);

            //Après le calcule de la rotation, on l'applique au personnage sur l'axe Y
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            //Mise de la direction du déplacement sur un vecteur 3D, utilisé ensuite sur le caractère (fonction Move) par rapport à la vitesse et le temps)
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; 
            caractere.Move(moveDir.normalized * vitesse * Time.deltaTime);

            //Si le joueur cours
            if(vitesse > vitesseInitial) {
                //L'animation courir est mise
                anim.SetBool("isWalking",false);
                anim.SetBool("isRunning", true);
            }
            //Sinon
            else{
                //L'animation de marche est mise
                anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
            }
        }
        //Si le vecteur est nul (donc aucun movement)
        else{
            //Désactiver les animation de movement
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
    }  
}