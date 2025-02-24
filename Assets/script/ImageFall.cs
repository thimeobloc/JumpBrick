using UnityEngine;

public class ImageFall : MonoBehaviour
{
    public float fallSpeed = 100f;

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // D�truire l'image si elle d�passe l'�cran
        if (transform.position.y < -Screen.height / 2)
        {
            Destroy(gameObject);
        }
    }
}
