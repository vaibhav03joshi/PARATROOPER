using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float minRange = 0, maxRange = 1;
    [SerializeField] private float downwardSpeed = -2;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float attackingSpeed;
    private EnemyManager enemyManager;
    private float parashootRange;
    private bool parashootDeployed = false;
    private Score score;
    //*************Attack*********************
    private bool isLanded = false;
    private bool isAttacking = false;
    private Vector3 directionToMove = new Vector3();
    private static int TroopsOnPosition = 0;
    void Start()
    {
        score = Score.GetScoreManager();
        enemyManager = EnemyManager.GetEnemyManager();
    }
    void Update()
    {
        if (!parashootDeployed && transform.position.y < parashootRange)
        {
            DeployParashoot();
            parashootDeployed = true;
        }        
        if (isAttacking)
        {
            transform.position += directionToMove * attackingSpeed;
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
    public IEnumerator StartAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        isAttacking = true;
        directionToMove.x = transform.position.x > 0 ? -1 : 1;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") && !isLanded)
        {
            isLanded = true;
            transform.tag = "Ground";
            _rigidbody.gravityScale = 1f;
            if (transform.position.x > 0)
            {
                enemyManager.TroopLanded(1, this);
            }
            else
            {
                enemyManager.TroopLanded(-1, this);
            }
        }
        if (collision.collider.CompareTag("Bullet"))
        {
            score.AddToScore(5);
            gameObject.SetActive(false);
        }
        if (collision.collider.CompareTag("Gun") && isAttacking)
        {
            transform.tag = "Enemy";
            isAttacking = false;
            TroopsOnPosition++;
        }
        if (collision.collider.CompareTag("Enemy") && isAttacking)
        {
            transform.tag = "Enemy";
            isAttacking = false;
            TroopsOnPosition++;
            switch (TroopsOnPosition)
            {
                case 2:
                    transform.position = collision.collider.transform.position + new Vector3(0, 0.33f, 0);
                    break;
                case 3:
                    break;
                case 4:
                    StartCoroutine(FinalTroop(collision.collider.transform));
                    break;
            }
        }
    }
    IEnumerator FinalTroop(Transform thirdTroop)
    {
        transform.position = thirdTroop.position + new Vector3(0, 0.33f, 0);
        yield return new WaitForSeconds(0.5f);
        transform.position += new Vector3(0.2f * directionToMove.x, 0.33f, 0);
        yield return new WaitForSeconds(0.5f);
        transform.position += new Vector3(0.2f * directionToMove.x, 0.33f, 0);

        Debug.Log("GameOver");
    }
}