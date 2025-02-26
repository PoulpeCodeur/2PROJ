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
        Bounds tilemapBounds = tilemap.localBounds;

        if (tilemapBounds.size == Vector3.zero) 
        {
            tilemap.CompressBounds(); // Mise à jour des limites si elles sont mal définies
            tilemapBounds = tilemap.localBounds;
        }

        float camHalfWidth = cam.orthographicSize * cam.aspect;
        float camHalfHeight = cam.orthographicSize;

        float clampedX = Mathf.Clamp(transform.position.x, tilemapBounds.min.x + camHalfWidth, tilemapBounds.max.x - camHalfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, tilemapBounds.min.y + camHalfHeight, tilemapBounds.max.y - camHalfHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

}
