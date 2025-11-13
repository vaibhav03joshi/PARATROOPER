using System.Collections;
using UnityEngine;

class PlaneManager : MonoBehaviour
{
    [SerializeField] private float PlaneCount = 2;
    [SerializeField] private float PlaneCountInterval = 3;
    private ObjectsManager objectsManager;
    public static PlaneManager planeManager;
    private void Awake()
    {
        planeManager = this;
    }
    public static PlaneManager GetPlaneManager()
    {
        return planeManager;
    }
    private void Start()
    {
        objectsManager = ObjectsManager.GetManager();
    }
    public float StartAttack()
    {
        float time = 0;
        for (int i = 0; i < PlaneCount; i++)
        {
            time += PlaneCountInterval;
            StartCoroutine(SpawnPlane(time));
        }
        return time;
    }
    IEnumerator SpawnPlane(float time)
    {
        yield return new WaitForSeconds(time);
        Plane plane = objectsManager.GetPlane();
        plane.transform.position = new Vector3(-10f, 4.5f, 0);
        plane.DeployPlane();
    }
}