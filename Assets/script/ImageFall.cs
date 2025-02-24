using UnityEngine;

public class ImageFall : MonoBehaviour
{
    public float fallSpeed = 100f;

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Détruire l'image si elle dépasse l'écran
        if (transform.position.y < -Screen.height / 2)
        {
            Destroy(gameObject);
        }
    }
}
