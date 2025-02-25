using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageRain : MonoBehaviour
{
    public GameObject imagePrefab; // Un prefab avec un UI Image
    public Sprite[] imageSprites; // Les sprites pour la pluie
    public RectTransform canvasTransform; // Le canvas pour spawn les images
    public Transform fallingImagesContainer; // Conteneur pour les images qui tombent
    public float spawnRate = 0.1f; // Temps entre chaque spawn
    public Vector2 imageSizeRange = new Vector2(50, 150); // Taille al�atoire des images
    public float fallSpeed = 200f; // Vitesse de chute des images

    void Start()
    {
        StartCoroutine(SpawnImages());
    }

    IEnumerator SpawnImages()
    {
        while (true)
        {
            SpawnImage();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    void SpawnImage()
    {
        GameObject newImage = Instantiate(imagePrefab, fallingImagesContainer);
        Image imgComponent = newImage.GetComponent<Image>();

        // Choisir une image al�atoire
        imgComponent.sprite = imageSprites[Random.Range(0, imageSprites.Length)];

        // Taille al�atoire
        float size = Random.Range(imageSizeRange.x, imageSizeRange.y);
        newImage.GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);

        // Position al�atoire sur la largeur et align�e tout en haut du Canvas
        float xPos = Random.Range(0, canvasTransform.rect.width);
        newImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, canvasTransform.rect.height / 2);

        // Ajouter le mouvement vers le bas
        newImage.AddComponent<ImageFall>().fallSpeed = fallSpeed;
    }
}
