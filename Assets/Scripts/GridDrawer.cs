using UnityEngine;

public class GridDrawer : MonoBehaviour
{
    public int gridWidth = 169; // Largeur de la grille en nombre de cellules
    public int gridHeight = 69; // Hauteur de la grille en nombre de cellules
    public float cellSize = 1.0f; // Taille de chaque cellule
    public Color gridColor = Color.white; // Couleur des lignes de la grille
    public Vector3 gridOrigin = Vector3.zero; // Position de départ de la grille
    public int sortingOrder = 0; // Ordre de rendu des lignes de la grille

    private void Start()
    {
        DrawGrid();
    }

    private void DrawGrid()
    {
        // Dessine les lignes horizontales
        for (int i = 0; i <= gridHeight; i++)
        {
            Vector3 start = gridOrigin + new Vector3(0, i * cellSize, 0);
            Vector3 end = gridOrigin + new Vector3(gridWidth * cellSize, i * cellSize, 0);
            DrawLine(start, end);
        }

        // Dessine les lignes verticales
        for (int i = 0; i <= gridWidth; i++)
        {
            Vector3 start = gridOrigin + new Vector3(i * cellSize, 0, 0);
            Vector3 end = gridOrigin + new Vector3(i * cellSize, gridHeight * cellSize, 0);
            DrawLine(start, end);
        }
    }

    private void DrawLine(Vector3 start, Vector3 end)
    {
        GameObject lineObj = new GameObject("GridLine");
        LineRenderer lineRenderer = lineObj.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.startColor = gridColor;
        lineRenderer.endColor = gridColor;
        lineRenderer.useWorldSpace = true;
        lineRenderer.sortingOrder = sortingOrder;

        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
    }

    private void OnDrawGizmos()
    {
        // Dessine la grille pour visualiser la position
        Gizmos.color = gridColor;
        for (int i = 0; i <= gridHeight; i++)
        {
            Vector3 start = gridOrigin + new Vector3(0, i * cellSize, 0);
            Vector3 end = gridOrigin + new Vector3(gridWidth * cellSize, i * cellSize, 0);
            Gizmos.DrawLine(start, end);
        }

        for (int i = 0; i <= gridWidth; i++)
        {
            Vector3 start = gridOrigin + new Vector3(i * cellSize, 0, 0);
            Vector3 end = gridOrigin + new Vector3(i * cellSize, gridHeight * cellSize, 0);
            Gizmos.DrawLine(start, end);
        }
    }
}
