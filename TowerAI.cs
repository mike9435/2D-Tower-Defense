using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEngine.GraphicsBuffer;

public class TowerAI : MonoBehaviour
{
    public GameObject[] AllEnemies;
    public GameObject[] bosses;
    private float range = 3;
    float distanceFromTower;
    //float distanceFromEnd;
    public bool canFire=true;
    private GameObject instantiatedBullet;

    public GameObject bulletPrefab;
    private BulletAI bulletAIScript;

    private EnemiesAI EnemiesAIscript;
    private BossAI BossAIscript;

    public AudioClip fireSound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Tower spawned");

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = fireSound;

    }

    // Update is called once per frame
    void Update()
    {
        if (canFire)
        {
            AllEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            bosses = GameObject.FindGameObjectsWithTag("Boss");

            for (int i = 0; i < AllEnemies.Length; i++)
            {
                distanceFromTower = Vector2.Distance(transform.position, AllEnemies[i].transform.position);
                //distanceFromEnd = Vector2.Distance(new Vector2(-9, 0), AllEnemies[i].transform.position);
                Debug.Log("distanceFromTower = " + distanceFromTower);
                EnemiesAIscript = AllEnemies[i].GetComponent<EnemiesAI>();
                if (distanceFromTower <= range && EnemiesAIscript.isBeingShot == false)
                {

                    Debug.Log("Target in Range");
                    //Find the direction the enemy is in and instantiate a bullet at it.

                    StartCoroutine(Fire(AllEnemies[i]));


                    
                    break;


                }

            }
            for (int i = 0; i < bosses.Length; i++)
            {
                distanceFromTower = Vector2.Distance(transform.position, bosses[i].transform.position);
                //distanceFromEnd = Vector2.Distance(new Vector2(-9, 0), AllEnemies[i].transform.position);
                Debug.Log("distanceFromTower = " + distanceFromTower);
                BossAIscript = bosses[i].GetComponent<BossAI>();
                if (distanceFromTower <= range)
                {

                    Debug.Log("Target in Range");
                    //Find the direction the enemy is in and instantiate a bullet at it.

                    StartCoroutine(Fire(bosses[i]));



                    break;


                }

            }

        }
    }

    IEnumerator Fire(GameObject target)
    {
        canFire = false;
        Debug.Log("Fire");
        instantiatedBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bulletAIScript = instantiatedBullet.GetComponent<BulletAI>();
        bulletAIScript.SetTarget(target);
        audioSource.Play();
        EnemiesAIscript = target.GetComponent<EnemiesAI>();
        if (EnemiesAIscript != null)
        {
            EnemiesAIscript.isBeingShot = true;
        }

        yield return new WaitForSeconds(3);
        canFire = true;
    }

}
