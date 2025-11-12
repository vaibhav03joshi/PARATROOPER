using System.Collections.Generic;
using UnityEngine;

class ObjectsManager : MonoBehaviour
{
    private static ObjectsManager objectsManager;
    private void Awake() 
    {
        objectsManager = this;
    }
    //************************Bullets***********************************
    [SerializeField] private Bullets Bullet;
    [SerializeField] private GameObject BulletParent;
    public List<Bullets> Bullets;
    public Bullets GetBullet()
    {
        foreach (Bullets shot in Bullets)
        {
            if (!shot.gameObject.activeInHierarchy)
            {
                return shot;
            }
        }
        Bullets bullet = Instantiate(Bullet, BulletParent.transform);
        Bullets.Add(bullet);
        return bullet;
    }
    public static ObjectsManager GetManager()
    {
        return objectsManager;
    }
    //************************Enemy***********************************
    [SerializeField] private Enemy Enemy;
    [SerializeField] private GameObject EnemyParent;
    public List<Enemy> Enemies;
    public Enemy GetEnemy()
    {
        foreach (Enemy e in Enemies)
        {
            if (!e.gameObject.activeInHierarchy)
            {
                return e;
            }
        }
        Enemy enemy = Instantiate(Enemy, EnemyParent.transform);
        Enemies.Add(enemy);
        return enemy;
    }
    //************************Helicopter***********************************
    [SerializeField] private Helicopter Helicopter;
    [SerializeField] private GameObject HelicopterParent;
    public List<Helicopter> Helicopters;
    public Helicopter GetHelicopter()
    {
        foreach (Helicopter h in Helicopters)
        {
            if (!h.gameObject.activeInHierarchy)
            {
                return h;
            }
        }
        Helicopter helicopter = Instantiate(Helicopter, HelicopterParent.transform);
        Helicopters.Add(helicopter);
        return helicopter;
    }
}