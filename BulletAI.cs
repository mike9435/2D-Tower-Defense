using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAI : MonoBehaviour
{
    public GameObject target;
    private float speed = 4;

    private EnemiesAI enemiesAI;
    private BossAI bossAI;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemiesAI = collision.gameObject.GetComponent<EnemiesAI>();
            enemiesAI.EnemyHit();
            gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            gameManager.PlayEnemyDeathSound();  
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Boss")
        {
            bossAI = collision.gameObject.GetComponent<BossAI>();
            bossAI.EnemyHit();
            Destroy(gameObject);
        }
    }
}
