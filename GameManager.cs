using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*What script is attached to: Game Manager gameobject
 * What I want script to do:
 * This will handle all of the Health and wave tracking
 * Health:
 * Once an enemy reaches the end of the path, the total health will decrease by 1 and destroy the enemy.
 * If the health is 0 the game stops and a game over screen appears with a retry button
 * Waves:
 * For simplicity, the waves will begin automatically. Each wave starts when the previous wave's enemies are all destroyed, either from reaching the end
 * or being killed. Each wave will have a specific amount of enemies.
 * 
 * 
*/
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public float health;
    public TextMeshProUGUI goldText;
    public float gold;
    public GameObject gameOverText;
    public GameObject youWinText;
    public TextMeshProUGUI waveText;
    public float wave;
    public float timerSpeed = 1;

    public GameObject enemy;
    public GameObject boss;
    public int enemiesAlive = 0;
    public int bossAlive = 0;
    public int enemyCountInWave;
    public int totalEnemiesSpawnedThisWave=0;
    public float timer = 0;

    public bool wave1Start;
    public bool wave2Start = false;
    public bool wave3Start = false;
    public bool wave4Start = false;
    public bool wave5Start = false;
    public bool waveFinalStart = false;

    public AudioClip enemyDeathSound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

        
        health = 20;
        healthText.text = "Health: " + health;

        gold = 20;
        goldText.text = "Gold: " + gold;

        StartCoroutine(SpawnEnemies(5,4));
        wave = 1;
        waveText.text = "Wave: " + wave;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = enemyDeathSound;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime*timerSpeed;
        

        GameObject[] enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemyArray)
        {
            if (enemy.transform.position.x < -9)
            {
                Destroy(enemy);
                health -= 1;
                healthText.text = "Health: " + health;
            }
        }
        GameObject[] bossArray = GameObject.FindGameObjectsWithTag("Boss");
        foreach (GameObject boss in bossArray)
        {
            if (boss.transform.position.x < -9)
            {
                Destroy(boss);
                health -= 20;
                healthText.text = "Health: " + health;
            }
        }

        //might add || enemiesAlive == 0 to if statements
        if (timer >= 25 && wave2Start == false)
        {
            StartCoroutine(SpawnEnemies(8,3));
            wave = 2;
            waveText.text = "Wave: " + wave;
            wave2Start = true;
        }
        if (timer >= 60 && wave3Start == false)
        {
            StartCoroutine(SpawnEnemies(12, 2.5f));
            wave = 3;
            waveText.text = "Wave: " + wave;
            wave3Start = true;
        }
        if (timer >= 95 && wave4Start == false)
        {
            StartCoroutine(SpawnEnemies(20, 2));
            wave = 4;
            waveText.text = "Wave: " + wave;
            wave4Start = true;
        }
        if (timer >= 130 && wave5Start == false)
        {
            StartCoroutine(SpawnEnemies(30, 1));
            wave = 5;
            waveText.text = "Wave: " + wave;
            wave5Start = true;
        }
        if (timer >= 160 && waveFinalStart == false)
        {
            Instantiate(boss);
            //wave = 5;
            waveText.text = "Wave: BOSS!!!";
            waveFinalStart = true;
        }

        enemiesAlive = enemyArray.Length;
        bossAlive = bossArray.Length;
        if (health == 0)
        {
            Time.timeScale = 0;
            gameOverText.SetActive(true);
        }
        if (timer >= 161 && bossAlive == 0)
        {
            Time.timeScale = 0;
            youWinText.SetActive(true);
        }

        //I need to add a type of timer or delay so the enemies dont all spawn at once

        
        /*
        if (enemiesAlive < enemyCountinWave)
        {
            
            for (int i = 0; i < enemyCountinWave; i++) 
            {
                Instantiate(enemy);
            }
            
            
        }
        */
        
        
        
    }

    public void UpdateGold(int newGold)
    {
        gold += newGold;
        goldText.text = "Gold: " + gold;
        
    }

    IEnumerator SpawnEnemies(int enemyCountinWave, float delay) 
    {
        totalEnemiesSpawnedThisWave = 0;
        while (totalEnemiesSpawnedThisWave < enemyCountinWave)
        {
            
            Instantiate(enemy);
            totalEnemiesSpawnedThisWave++;
            yield return new WaitForSeconds(delay);
            
        }
        
    }

    public void PlayEnemyDeathSound()
    {
        audioSource.Play();
    }
}
