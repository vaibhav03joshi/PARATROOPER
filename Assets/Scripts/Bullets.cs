using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float TimeBeforeDisappear;
    [SerializeField] private float speed;
    private Vector3 TravelDirection;
    public void FireBullet(Vector3 direction)
    {
        gameObject.SetActive(true);
        TravelDirection = direction;
        StartCoroutine(CallAfterDelay());
    }
    private void Update() {
        transform.position += speed * Time.deltaTime * TravelDirection;
    }
    IEnumerator CallAfterDelay()
    {
        yield return new WaitForSeconds(TimeBeforeDisappear);
        ResetBullet();
    }
    private void ResetBullet()
    {
        gameObject.SetActive(false);
    }
}
