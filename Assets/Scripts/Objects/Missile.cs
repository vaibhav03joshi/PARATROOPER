using UnityEngine;

class Missile : MonoBehaviour
{
    public Rigidbody2D _rigidbody;
    private Score score;
    void Start()
    {
        score = Score.GetScoreManager();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Gun"))
        {
            collision.collider.gameObject.SetActive(false);
            score.GameOver();

        }
        if (collision.collider.CompareTag("Bullet"))
        {
            collision.collider.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}