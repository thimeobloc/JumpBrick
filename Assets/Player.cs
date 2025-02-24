using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{   
    
    float movement = 0f ; 
    public float movementSpeed = 10f ; 
    Rigidbody2D rb ; 
    Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        mainCamera = Camera.main; 
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed; 

        if (IsOutOfScreen())
        {
            Die(); // Appelle la méthode de mort
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity ; 
        velocity.x = movement ;  
        rb.velocity = velocity; 
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
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Arrête le mode Play dans l'éditeur
        #else
        Application.Quit(); // Ferme le jeu dans une build
        #endif
        //SceneManager.LoadScene("GameOverScene");
        
    }
}
