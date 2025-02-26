using UnityEngine;

public class DebugTarget : MonoBehaviour
{
    private AIAgent aiAgent;

    void Start()
    {
        aiAgent = GetComponent<AIAgent>();

        if (aiAgent == null)
        {
            Debug.LogError($"{gameObject.name} n'a pas de script AiAgentTest !");
            return;
        }

        Debug.Log($"{gameObject.name} suit la target : {aiAgent.GetTargetName()}");
    }
}