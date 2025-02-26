using UnityEngine;
using Pathfinding;

public class AIAgent : MonoBehaviour
{
    private AIPath path;
    [SerializeField] private float moveSpeed;
    private GameObject target;

    private void Start()
    {
        path = GetComponent<AIPath>();
        path.maxSpeed = moveSpeed;

        if (target != null)
        {
            Debug.Log($"{gameObject.name} suit la target : {target.name}");
            path.destination = target.transform.position;
        }
        else
        {
            Debug.LogError($"{gameObject.name} n'a pas de target assignée !");
        }
    }

    private void Update()
    {
        if (target != null)
        {
            path.destination = target.transform.position;
        }
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
        if (path != null)
        {
            path.destination = target.transform.position;
            Debug.Log($"{gameObject.name} change sa cible vers {target.name}");
        }
    }

    public string GetTargetName()
    {
        return target != null ? target.name : "Aucune cible";
    }
}