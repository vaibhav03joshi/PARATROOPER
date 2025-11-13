using UnityEngine;

class Missile : MonoBehaviour
{
    public Rigidbody2D _rigidbody;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Gun"))
        {
            collision.collider.gameObject.SetActive(false);
        }
        if (collision.collider.CompareTag("Bullet"))
        {
            collision.collider.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}