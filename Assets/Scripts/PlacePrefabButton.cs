using UnityEngine;
using UnityEngine.UI;

public class PlacePrefabButton : MonoBehaviour
{
    public PlacePrefab placePrefabScript;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => OnButtonClick(button));
    }

    private void OnButtonClick(Button button)
    {
        placePrefabScript.StartPlacing(button);
    }
}
