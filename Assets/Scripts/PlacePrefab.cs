using UnityEngine;

public class PlacePrefab : MonoBehaviour
{
    public GameObject prefabToPlace;
    private GameObject temporaryPrefab;
    private bool isPlacing = false;

    private void Update()
    {
        if (isPlacing)
        {
            FollowMouse();

            if (Input.GetMouseButtonDown(0))
            {
                PlacePrefabAtMousePosition();
            }
        }
    }

    public void StartPlacing()
    {
        isPlacing = true;
        temporaryPrefab = Instantiate(prefabToPlace);
    }

    private void FollowMouse()
    {
        if (temporaryPrefab != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            temporaryPrefab.transform.position = mousePosition;
        }
    }

    private void PlacePrefabAtMousePosition()
    {
        if (temporaryPrefab != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Instantiate(prefabToPlace, mousePosition, Quaternion.identity);
            Destroy(temporaryPrefab);
            isPlacing = false;
        }
    }
}
