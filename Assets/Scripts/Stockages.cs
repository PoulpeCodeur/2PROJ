using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Stockages : MonoBehaviour
{
    private Dictionary<string, int> resources;
    public TMP_Text woodText;
    public TMP_Text stoneText;
    public TMP_Text ironText;
    public TMP_Text waterText;
    public TMP_Text woolText;
    public TMP_Text berriesText;
    public TMP_Text meatText;

    private void Awake()
    {
        resources = new Dictionary<string, int>
        {
            { "Wood", 0 },
            { "Stone", 0 },
            { "Iron", 0 },
            { "Water", 0 },
            { "Wool", 0 },
            { "Berries", 0 },
            { "Meat", 0 }
        };
    }

    public void SetResource(string resourceName, int amount)
    {
        if (resources.ContainsKey(resourceName))
        {
            resources[resourceName] = amount;
            Debug.Log("Stockages : " + resourceName + " set to " + amount);
            UpdateCanvasText(resourceName);
        }
        else
        {
            Debug.LogError("Resource name not found : " + resourceName);
        }
    }

    public int GetResource(string resourceName)
    {
        if (resources.ContainsKey(resourceName))
        {
            return resources[resourceName];
        }
        else
        {
            Debug.LogError("Resource name not found : " + resourceName);
            return 0;
        }
    }

    private void UpdateCanvasText(string resourceName)
    {
        switch (resourceName)
        {
            case "Wood":
                if (woodText != null)
                {
                    woodText.text = "Bois : " + resources[resourceName].ToString();
                    Debug.Log("CanvasText updated : " + woodText.text);
                }
                break;
            case "Stone":
                if (stoneText != null)
                {
                    stoneText.text = "Pierre : " + resources[resourceName].ToString();
                    Debug.Log("CanvasText updated : " + stoneText.text);
                }
                break;
            case "Iron":
                if (ironText != null)
                {
                    ironText.text = "Fer : " + resources[resourceName].ToString();
                    Debug.Log("CanvasText updated : " + ironText.text);
                }
                break;
            case "Water":
                if (waterText != null)
                {
                    waterText.text = "Eau : " + resources[resourceName].ToString();
                    Debug.Log("CanvasText updated : " + waterText.text);
                }
                break;
            case "Wool":
                if (woolText != null)
                {
                    woolText.text = "Laine : " + resources[resourceName].ToString();
                    Debug.Log("CanvasText updated : " + woolText.text);
                }
                break;
            case "Berries":
                if (berriesText != null)
                {
                    berriesText.text = "Baies : " + resources[resourceName].ToString();
                    Debug.Log("CanvasText updated : " + berriesText.text);
                }
                break;
            case "Meat":
                if (meatText != null)
                {
                    meatText.text = "Viande : " + resources[resourceName].ToString();
                    Debug.Log("CanvasText updated : " + meatText.text);
                }
                break;
        }
    }

    void Start()
    {
        UpdateAllCanvasTexts();
    }

    private void UpdateAllCanvasTexts()
    {
        UpdateCanvasText("Wood");
        UpdateCanvasText("Stone");
        UpdateCanvasText("Iron");
        UpdateCanvasText("Water");
        UpdateCanvasText("Wool");
        UpdateCanvasText("Berries");
        UpdateCanvasText("Meat");
    }
}
