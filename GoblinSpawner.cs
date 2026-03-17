using UnityEngine;
using System.Collections;

public class GoblinSpawner : MonoBehaviour
{
    public GameObject goblinPrefab;
    public float respawnTime = 10f;

    private GameObject currentGoblin;
    private bool respawning = false;

    void Start()
    {
        SpawnGoblin();
    }

    void Update()
    {
        if (currentGoblin == null && !respawning)
        {
            StartCoroutine(RespawnGoblin());
        }
    }

    void SpawnGoblin()
    {
        currentGoblin = Instantiate(goblinPrefab, transform.position, Quaternion.identity);
    }

    IEnumerator RespawnGoblin()
    {
        respawning = true;

        yield return new WaitForSeconds(respawnTime);

        SpawnGoblin();

        respawning = false;
    }
}