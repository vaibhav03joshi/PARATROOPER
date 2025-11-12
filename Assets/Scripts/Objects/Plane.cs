using System;
using System.Collections;
using UnityEngine;

class Plane : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;
    private bool missileDeployed;
    private ObjectsManager objectsManager;
    private Score score;
    private Vector3 direction;
    private void Awake() {
        gameObject.SetActive(false);
        direction = new Vector3(1, 0, 0);
    }
    private void Start() {
        score = Score.GetScoreManager();
        objectsManager = ObjectsManager.GetManager();
    }
    public void DeployPlane()
    {
        missileDeployed = false;
        gameObject.SetActive(true);
        StartCoroutine(DisablePlane());
    }
    IEnumerator DisablePlane()
    {
        yield return new WaitForSeconds(7);
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (!missileDeployed)
        {
            // if (MathF.Abs(transform.position.x - spawnPosition) < 0.1f)
            // {
            //     missileDeployed = true;
            // }
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
            score.AddToScore(30);
            gameObject.SetActive(false);
        }
    }
}