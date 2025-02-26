using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlacePrefab : MonoBehaviour
{
    private Dictionary<Button, GameObject> prefabDictionary;
    private GameObject temporaryPrefab;
    private bool isPlacing = false;
    private GameObject currentPrefab;

    public List<ButtonPrefabPair> buttonPrefabPairs;

    private void Awake()
    {
        prefabDictionary = new Dictionary<Button, GameObject>();

        foreach (var pair in buttonPrefabPairs)
        {
            if (pair.button != null && pair.prefab != null)
            {
                prefabDictionary[pair.button] = pair.prefab;
            }
        }
    }

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

    public void StartPlacing(Button button)
    {
        if (prefabDictionary.ContainsKey(button))
        {
            isPlacing = true;
            currentPrefab = prefabDictionary[button];
            temporaryPrefab = Instantiate(currentPrefab);
        }
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
            Instantiate(currentPrefab, mousePosition, Quaternion.identity);
            Destroy(temporaryPrefab);
            isPlacing = false;
        }
    }
}

[System.Serializable]
public class ButtonPrefabPair
{
    public Button button;
    public GameObject prefab;
}
