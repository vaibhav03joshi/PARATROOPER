using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class HelicopterManager : MonoBehaviour
{
    [SerializeField] private float helicopterCount = 10;
    [SerializeField] private float minSpawnTime = 3;
    [SerializeField] private float maxSpawnTime = 5;
    private ObjectsManager objectsManager;
    private void Start()
    {
        objectsManager = ObjectsManager.GetManager();
        StartAttack();

    }
    private void StartAttack()
    {
        float time = 0;
        for (int i = 0; i < helicopterCount; i++)
        {
            time += Random.Range(minSpawnTime, maxSpawnTime);
            StartCoroutine(SpawnHelicopters(time));
        }
    }
    IEnumerator SpawnHelicopters(float time)
    {
        yield return new WaitForSeconds(time);
        Helicopter helicopter = objectsManager.GetHelicopter();
        int direction = Random.Range(0, 2) == 0 ? -1 : 1;
        helicopter.transform.position = new Vector3(-direction * 10, 4.5f, 0);
        helicopter.DeployHelicopter(direction);
    }
}