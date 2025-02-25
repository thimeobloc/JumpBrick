using UnityEngine;
using UnityEngine.UI;

public class ImageFall : MonoBehaviour
{
    public float fallSpeed = 200f;

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Détruit l'image si elle sort de l'écran
        if (transform.position.y < -Screen.height / 2)
        {
            Destroy(gameObject);
        }
    }
}
