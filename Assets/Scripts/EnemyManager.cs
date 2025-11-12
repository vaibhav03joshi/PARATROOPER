using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class EnemyManager : MonoBehaviour
{
    public static EnemyManager enemyManager;
    private Score score;
    private HelicopterManager helicopterManager;
    private List<Enemy> TroopsOnRight, TroopsOnLeft;
    private bool attackStarted = false;
    private void Awake()
    {
        enemyManager = this;
        TroopsOnRight = new List<Enemy>();
        TroopsOnLeft = new List<Enemy>();
    }
    public static EnemyManager GetEnemyManager()
    {
        return enemyManager;
    }
    private void Start()
    {
        helicopterManager = HelicopterManager.GetHelicopterManager();
        score = Score.GetScoreManager();
        float timeTaken = helicopterManager.StartAttack();
        StartCoroutine(AttackEnded(timeTaken));
    }
    public void TroopLanded(int direction, Enemy Troop)
    {
        if (direction > 0)
        {
            TroopsOnRight.Add(Troop);
            if (TroopsOnRight.Count == 4 && !attackStarted)
            {
                TroopsOnRight = TroopsOnRight.OrderBy(t => t.transform.position.x).ToList();
                GroundAttack(TroopsOnRight);
            }
        }
        else
        {
            TroopsOnLeft.Add(Troop);
            if (TroopsOnLeft.Count == 4 && !attackStarted)
            {
                TroopsOnLeft = TroopsOnLeft.OrderByDescending(t => t.transform.position.x).ToList();
                GroundAttack(TroopsOnLeft);
            }
        }
    }
    private void GroundAttack(List<Enemy> enemies)
    {
        attackStarted = true;
        float attackTime = 0;
        foreach (var Troop in enemies)
        {
            StartCoroutine(Troop.StartAttack(attackTime));
            attackTime += 0.5f;
        }
    }
    IEnumerator AttackEnded(float timeTaken)
    {
        yield return new WaitForSeconds(timeTaken + 4f);
        score.GameOver();
    }
}