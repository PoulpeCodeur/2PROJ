using UnityEngine;

public class SnapDuringMove : MonoBehaviour
{
    private Grid grid;
    
    void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }

    void Update()
    {
        if (grid != null)
        {
            Snap();
        }
    }

    void Snap()
    {
        Vector3Int cellPosition = grid.WorldToCell(transform.position);
        transform.position = grid.GetCellCenterWorld(cellPosition);
    }
}