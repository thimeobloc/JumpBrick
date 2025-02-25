using UnityEngine;

public class ImagePulse : MonoBehaviour
{
    public float minScale = 0.8f; // Taille minimale
    public float maxScale = 1.2f; // Taille maximale
    public float speed = 2f; // Vitesse de l'animation

    private Vector3 originalScale;
    private float time;

    void Start()
    {
        originalScale = transform.localScale; // Stocke l'échelle d'origine
    }

    void Update()
    {
        time += Time.deltaTime * speed;
        float scale = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(time) + 1) / 2); // Oscillation
        transform.localScale = originalScale * scale;
    }
}
