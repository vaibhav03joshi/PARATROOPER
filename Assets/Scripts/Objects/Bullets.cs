using System.Collections;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float timeBeforeDisappear = 3;
    [SerializeField] private float speed = 5;
    private Vector3 TravelDirection;
    public void FireBullet(Vector3 direction)
    {
        gameObject.SetActive(true);
        TravelDirection = direction;
        StartCoroutine(ResetBullet());
    }
    private void Update() {
        transform.position += speed * Time.deltaTime * TravelDirection;
    }
    IEnumerator ResetBullet()
    {
        yield return new WaitForSeconds(timeBeforeDisappear);
        gameObject.SetActive(false);
    }
}
