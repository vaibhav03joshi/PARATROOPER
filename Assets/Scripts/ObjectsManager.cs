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
    [SerializeField] private Bullets bullet;
    [SerializeField] private GameObject bulletParent;
    public List<Bullets> bullets;
    public Bullets GetBullet()
    {
        foreach (Bullets b in bullets)
        {
            if (!b.gameObject.activeInHierarchy)
            {
                return b;
            }
        }
        Bullets newBullet = Instantiate(bullet, bulletParent.transform);
        bullets.Add(newBullet);
        return newBullet;
    }
    public static ObjectsManager GetManager()
    {
        return objectsManager;
    }
    //************************Enemy***********************************
    [SerializeField] private Enemy enemy;
    [SerializeField] private GameObject enemyParent;
    public List<Enemy> enemies;
    public Enemy GetEnemy()
    {
        foreach (Enemy e in enemies)
        {
            if (!e.gameObject.activeInHierarchy)
            {
                return e;
            }
        }
        Enemy newEnemy = Instantiate(enemy, enemyParent.transform);
        enemies.Add(newEnemy);
        return newEnemy;
    }
    //************************Helicopter***********************************
    [SerializeField] private Helicopter helicopter;
    [SerializeField] private GameObject helicopterParent;
    public List<Helicopter> helicopters;
    public Helicopter GetHelicopter()
    {
        foreach (Helicopter h in helicopters)
        {
            if (!h.gameObject.activeInHierarchy)
            {
                return h;
            }
        }
        Helicopter newHelicopter = Instantiate(helicopter, helicopterParent.transform);
        helicopters.Add(newHelicopter);
        return newHelicopter;
    }
    
    //************************Plane***********************************
    [SerializeField] private Plane plane;
    [SerializeField] private GameObject planeParent;
    public List<Plane> planes;
    public Plane GetPlane()
    {
        foreach (Plane p in planes)
        {
            if (!p.gameObject.activeInHierarchy)
            {
                return p;
            }
        }
        Plane plane = Instantiate(this.plane, planeParent.transform);
        planes.Add(plane);
        return plane;
    }
    
    //************************Missiles***********************************
    [SerializeField] private Missile missile;
    [SerializeField] private GameObject MissileParent;
    public List<Missile> Missiles;
    public Missile GetMissile()
    {
        foreach (Missile m in Missiles)
        {
            if (!m.gameObject.activeInHierarchy)
            {
                return m;
            }
        }
        Missile newMissile = Instantiate(missile, MissileParent.transform);
        Missiles.Add(newMissile);
        return newMissile;
    }
}