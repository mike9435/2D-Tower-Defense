using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* What script is attached to: enemy gameobject
 * What I want script to do:
 * Move the enemy gameobject from the right end of the path to the left. When it reaches the end, decrease the health points by 1.
 * 
*/
public class EnemiesAI : MonoBehaviour
{

    private GameManager gameManagerScript;
    public float speed = 1.5f;
    public bool isBeingShot;
    
        
        // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        isBeingShot = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-1,0)*Time.deltaTime*speed);
    }

    public void EnemyHit()
    {
        gameManagerScript.UpdateGold(1);
        Destroy(gameObject);
    }
}
