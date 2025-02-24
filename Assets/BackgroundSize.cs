using UnityEngine;

public class BackgroundSize : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            float levelWidth = sr.bounds.size.x;
            Debug.Log("Level Width: " + levelWidth);
        }
        else
        {
            Debug.LogError("Aucun SpriteRenderer trouvé sur cet objet !");
        }
    }
}
