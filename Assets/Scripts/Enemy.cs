using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isLanded = false;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isLanded = true;
        }
        if (collision.collider.CompareTag("Bullet"))
        {
            //Dead
        }
    }
}
