using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f; // Vitesse du déplacement
    public float zoomSpeed = 2f; // Vitesse du zoom
    public Tilemap tilemap; // Référence à la Tilemap
    private Vector3 lastMousePosition;
    private Camera cam;

    void Start()
    {
        cam = Camera.main; // Récupère la caméra principale
    }

    void Update()
    {
        // Déplacement de la caméra avec le clic droit
        if (Input.GetMouseButtonDown(1)) // Clic droit enfoncé
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(1)) // Tant que le clic droit est maintenu
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            transform.position -= new Vector3(delta.x, delta.y, 0) * moveSpeed * Time.deltaTime;
            lastMousePosition = Input.mousePosition;

            // Empêcher la caméra de sortir des limites de la Tilemap
            ConstrainCameraPosition();
        }

        // Zoom avec la molette de la souris
        float scroll = Input.GetAxis("Mouse ScrollWheel"); // Obtient la direction de la molette
        if (scroll != 0)
        {
            // Change la taille de la caméra
            cam.orthographicSize -= scroll * zoomSpeed;

            // Limite le zoom pour ne pas que la caméra soit trop proche ou trop éloignée
            float maxZoom = Mathf.Min((tilemap.localBounds.size.x / 2) / cam.aspect, tilemap.localBounds.size.y / 2);
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 5f, maxZoom);

            // Empêcher la caméra de sortir des limites de la Tilemap après un zoom
            ConstrainCameraPosition();
        }
    }

    void ConstrainCameraPosition()
    {
        // Récupère les coordonnées du coin inférieur gauche et du coin supérieur droit de la Tilemap
        Vector3 tilemapMin = tilemap.localBounds.min;
        Vector3 tilemapMax = tilemap.localBounds.max;

        // Calcule les limites de la caméra en fonction de sa taille
        float camHalfWidth = cam.orthographicSize * cam.aspect; // Largeur visible de la caméra (en fonction du ratio d'aspect)
        float camHalfHeight = cam.orthographicSize; // Hauteur visible de la caméra

        // Limite la position de la caméra sur l'axe X (gauche et droite)
        float clampedX = Mathf.Clamp(transform.position.x, tilemapMin.x + camHalfWidth, tilemapMax.x - camHalfWidth);

        // Limite la position de la caméra sur l'axe Y (haut et bas)
        float clampedY = Mathf.Clamp(transform.position.y, tilemapMin.y + camHalfHeight, tilemapMax.y - camHalfHeight);

        // Applique les nouvelles positions limitées à la caméra
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
