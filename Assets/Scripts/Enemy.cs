using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float minRange = 0, maxRange = 1;
    [SerializeField] private float downwardSpeed = -2;
    [SerializeField] private Rigidbody2D _rigidbody;
    private float parashootRange;
    private bool parashootDeployed = false;
    void Update()
    {
        if (!parashootDeployed && transform.position.y < parashootRange)
        {
            DeployParashoot();
            parashootDeployed = true;
        }
    }
    public void DeployTroop()
    {
        gameObject.SetActive(true);
        _rigidbody.gravityScale = 0f;
        parashootDeployed = false;
        _rigidbody.linearVelocityY = downwardSpeed;
        parashootRange = Random.Range(minRange, maxRange);
    }
    private void DeployParashoot()
    {
        _rigidbody.linearVelocityY /= 2;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _rigidbody.gravityScale = 1f;
            // isLanded = true;
            // transform.position = new Vector3(2, 5, 0);
            // gameObject.SetActive(false);
            // DeployTroop();
        }
        if (collision.collider.CompareTag("Bullet"))
        {
            //Dead
            gameObject.SetActive(false);
        }
    }
}