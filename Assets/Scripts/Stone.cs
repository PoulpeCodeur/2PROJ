using UnityEngine;

public class Stone : MonoBehaviour
{
    public int stoneAmount = 3; 

    private void OnMouseDown()
    {
        CollectStone();
    }

    private void CollectStone()
    {
        GameManager.Instance.AddResource("Stone", stoneAmount);
        Debug.Log("Stone: Collected +" + stoneAmount + " stone");
    }
}
