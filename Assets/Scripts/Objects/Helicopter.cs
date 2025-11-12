using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Helicopter : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private List<int> spawnPoint;
    private Vector3 direction;
    private int spawnPosition;
    private bool troopDeployed;
    private ObjectsManager objectsManager;
    private Score score;
    private void Awake() {
        gameObject.SetActive(false);
        direction = Vector3.zero;
    }
    private void Start() {
        score = Score.GetScoreManager();
        objectsManager = ObjectsManager.GetManager();
    }
    public void DeployHelicopter(int _direction)
    {
        direction.x = _direction;
        int index = UnityEngine.Random.Range(0, spawnPoint.Count - 1);
        spawnPosition = spawnPoint[index];
        troopDeployed = false;
        gameObject.SetActive(true);
        StartCoroutine(DisableHelicopter());
    }
    IEnumerator DisableHelicopter()
    {
        yield return new WaitForSeconds(7);
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (!troopDeployed)
        {
            if (MathF.Abs(transform.position.x - spawnPosition) < 0.1f)
            {
                troopDeployed = true;
                Enemy enemy = objectsManager.GetEnemy();
                enemy.transform.position = new Vector3(spawnPosition, 4, 0);
                enemy.DeployTroop();
            }
        }
    }
    void FixedUpdate()
    {
        transform.position += direction * speed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            score.AddToScore(20);
            gameObject.SetActive(false);
        }
    }
}