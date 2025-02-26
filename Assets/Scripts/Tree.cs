using UnityEngine;

public class Tree : MonoBehaviour
{
    public int woodAmount = 3;
    public int maxBerries = 5;

    private void OnMouseDown()
    {
        CollectWood();
    }

    private void CollectWood()
    {
        GameManager.Instance.AddResource("Wood", woodAmount);
        Debug.Log("Tree: Collected +" + woodAmount + " wood");

        int berriesAmount = Random.Range(0, maxBerries + 1);
        if (berriesAmount > 0)
        {
            GameManager.Instance.AddResource("Berries", berriesAmount);
            Debug.Log("Tree: Collected +" + berriesAmount + " berries");
        }
    }
}
