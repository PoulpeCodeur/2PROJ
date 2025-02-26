using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireCamp : MonoBehaviour
{
    public GameObject botPrefab;
    public GameObject bot2Prefab;
    public GameObject spawnPoint;
    public float spawnInterval = 5f;
    private bool spawnBot1 = true;

    private void Start()
    {
        gameObject.SetActive(true); // S'assure que l'objet reste actif
        StartCoroutine(SpawnBots());
    }

    private IEnumerator SpawnBots()
    {
        Debug.Log("La coroutine de spawn démarre !");
        while (true)
        {
            Debug.Log("Nouvelle itération du spawn...");
            yield return new WaitForSeconds(spawnInterval);
            SpawnBot();
        }
    }

    private void SpawnBot()
    {
        if (spawnPoint == null)
        {
            Debug.LogError("Le point de spawn n'est pas assigné !");
            return;
        }

        GameObject botToSpawn = spawnBot1 ? botPrefab : bot2Prefab;
        if (botToSpawn == null)
        {
            Debug.LogError("Le prefab du bot n'est pas assigné !");
            return;
        }

        //Instanciation du bot
        GameObject bot = Instantiate(botToSpawn, spawnPoint.transform.position, Quaternion.identity);
        Debug.Log($"{bot.name} a spawné à {spawnPoint.transform.position}");

        //Trouve une target unique pour ce bot
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        if (targets.Length > 0)
        {
            GameObject randomTarget = targets[Random.Range(0, targets.Length)];
            bot.GetComponent<AIAgent>().SetTarget(randomTarget);
            Debug.Log($"{bot.name} a reçu comme target : {randomTarget.name}");
        }
        else
        {
            Debug.LogError("Aucune target trouvée dans la scène !");
        }

        spawnBot1 = !spawnBot1; // Alterne entre bot1 et bot2
    }
}