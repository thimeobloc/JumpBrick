using UnityEngine;

public class MalusEffect : MonoBehaviour
{
    public float effectDuration = 5f;  // Durée pendant laquelle les contrôles seront inversés

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si l'objet en collision est le joueur
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("Malus activé, inversion des contrôles !");
            player.InvertControls(effectDuration);  // Inverse les contrôles du joueur
            Destroy(gameObject);  // Détruit l'objet malus après qu'il ait été récupéré
        }
    }
}
