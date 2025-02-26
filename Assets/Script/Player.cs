using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{   
    
    float movement = 0f ; 
    public float movementSpeed = 10f ; 
    Rigidbody2D rb ; 
    Camera mainCamera;
    bool isFacingRight = true; // Indique si le joueur est tourné vers la droite
    private Animator animator ;
    public bool hasUsedBonus = false;  // Indique si le joueur a déjà utilisé le bonus
    public float bonusJumpForce = 20f;  // Force du saut lors de l'utilisation du bonus
    
    private bool areControlsInverted = false;  // Indique si les contrôles sont inversés
    private float inversionTimer = 0f;  // Timer pour la durée de l'inversion
    private SpriteRenderer spriteRenderer;  // Référence au SpriteRenderer

    public string horizontalInputAxis = "Horizontal"; // Input personnalisé pour chaque joueur


    // Variables pour le deuxième joueur
    public GameObject player2Prefab; // Le prefab du deuxième joueur
    private GameObject player2; // Instance du deuxième joueur
    public bool isMultiplayerActive = false;  // Indique si le mode multijoueur est activé



    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        mainCamera = Camera.main; 
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {   
        // Vérifie si la barre d'espace est pressée pour activer le mode multijoueur
        if (Input.GetKeyDown(KeyCode.Space) && !isMultiplayerActive)
        {
            Debug.Log("Touche SPACE pressée ! Activation du mode multijoueur...");
            isMultiplayerActive = true;

            // Crée le joueur 2 et positionne le à côté du joueur 1 
            if (player2Prefab != null)
            {
                player2 = Instantiate(player2Prefab, new Vector3(0, transform.position.y + 1, transform.position.z), Quaternion.identity);
                player2.SetActive(false); // Cache le joueur 2 au départ
                Debug.Log("Mode multijoueur activé et joueur 2 créé !");
            }
            else
            {
                Debug.Log("Prefab du joueur 2 non assigné !");
            }
        }

        // Si le mode multijoueur est activé et que le joueur 2 est instancié, tu peux le rendre visible
        if (isMultiplayerActive && player2 != null)
        {
            // Appuie sur la barre d'espace pour faire apparaître le joueur 2
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player2.SetActive(true); // Affiche le joueur 2
                Debug.Log("Joueur 2 affiché !");
            }

           
        }
    


        // Si les contrôles sont inversés, on décrémente le timer
        if (areControlsInverted)
        {
            inversionTimer -= Time.deltaTime;  // Soustrait le temps écoulé depuis le dernier frame
            // Change la couleur du sprite pendant l'inversion
            spriteRenderer.color = Color.red;  // Modifie la couleur en rouge pendant l'inversion


            // Si le timer est arrivé à zéro ou moins, on rétablit les contrôles
            if (inversionTimer <= 0f)
            {
                areControlsInverted = false;  // Réinitialise l'inversion des contrôles
                spriteRenderer.color = Color.white;  // Remet la couleur normale
                Debug.Log("Les contrôles sont rétablis.");
            }
        }

        // Vérifie si les contrôles sont inversés et ajuste la valeur de movement en conséquence
        float movementInput = Input.GetAxis(horizontalInputAxis); // Utilisation de l'input personnalisé
        if (areControlsInverted)  // Si les contrôles sont inversés
        {
            movementInput = -movementInput;  // Inverse le mouvement
        }

        movement = movementInput * movementSpeed;


        // Vérifie si le joueur doit être retourné
        if (movement > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (movement < 0 && isFacingRight)
        {
            Flip();
        }

        // Gère le passage d'un bord à l'autre
        WrapAroundScreen();

        if (IsOutOfScreen())
        {
            Die(); // Appelle la méthode de mort

            FindObjectOfType<ScoreManager>().SaveHighscore();
            FindObjectOfType<ScoreManager>().SaveFinalScore();
            UnityEngine.SceneManagement.SceneManager.LoadScene("game-over");
        }
    }


    public void InvertControls(float duration)
    {
        areControlsInverted = true;  // Active l'inversion des contrôles
        inversionTimer = duration;   // Définit la durée de l'inversion
        //Debug.Log("Les contrôles sont inversés pendant " + duration + " secondes.");
    }


    // Vérifie si le joueur sort de l'écran et le téléporte de l'autre côté
    void WrapAroundScreen()
    {
       // float screenLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        // float screenRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        float screenLeft = -0.5f; 
        float screenRight = 0.5f; 

        if (transform.position.x > screenRight) // Sortie à droite
        {
            transform.position = new Vector3(screenLeft, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < screenLeft) // Sortie à gauche
        {
            transform.position = new Vector3(screenRight, transform.position.y, transform.position.z);
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity ; 
        velocity.x = movement ;  
        rb.velocity = velocity; 
    }

    // Retourne le joueur horizontalement
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Inverse l'axe X
        transform.localScale = scale;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plateform"))
        {   
            //Debug.Log("Bonus utilisé ?  ... " + hasUsedBonus); 
            // Réinitialise l'utilisation du bonus lorsque le joueur atterrit sur une plateforme
            hasUsedBonus = false;
            // animator.Play("PlayerAnimation");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si l'objet en collision est un Bonus et si le joueur n'a pas encore utilisé de bonus
        if (collision.gameObject.CompareTag("Bonus") && !hasUsedBonus)
        {
            Bonus bonus = collision.gameObject.GetComponent<Bonus>();  // Récupère le script Bonus de l'objet

            if (bonus != null && bonus.isHighJumpBonus)  // Si c'est un bonus HighJump
            {   
                //Debug.Log("Bonus HighJump détecté !");
                hasUsedBonus = true;  // Le bonus a été utilisé

                // Applique un saut très haut
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 velocity = rb.velocity;
                    velocity.y = bonusJumpForce;  // Applique une grande force de saut
                    rb.velocity = velocity;
                    //Debug.Log("Force de saut appliquée : " + velocity.y);
                }

                // Détruit l'objet bonus après l'avoir récupéré
                Destroy(collision.gameObject); 
                //Debug.Log("Bonus détruit après récupération.");
            }
        }
    }


    public void OnLandingAnimationEnd()
    {
        animator.Play("Idle");
    }
    // Méthode pour vérifier si le joueur est sorti de l'écran par le bas
    bool IsOutOfScreen()
    {
        float screenBottom = mainCamera.transform.position.y - mainCamera.orthographicSize;
        return transform.position.y < screenBottom;
    }
    void Die()
    {
        Debug.Log("Le joueur est mort !");

        // Charge la scène Game Over
        SceneManager.LoadScene("game-over");
    }

}
