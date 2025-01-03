using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* What script is attached to: enemy gameobject
 * What I want script to do:
 * Move the enemy gameobject from the right end of the path to the left. When it reaches the end, decrease the health points by 1.
 * 
*/
public class BossAI : MonoBehaviour
{

    private GameManager gameManagerScript;
    public float speed = 0.5f;
    public float bossHealth;
    public bool isBeingShot;

    public Slider slider;
    private GameObject canvasObject;
    public Canvas canvas;
    private Slider instantiatedSlider;
    private GameObject camObject;
    private Camera cam;
    private Vector3 sliderLocation;


    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        bossHealth = 10;
        isBeingShot = false;

        camObject = GameObject.Find("Main Camera");
        cam = camObject.GetComponent<Camera>();
        canvasObject = GameObject.Find("Canvas");
        canvas = canvasObject.GetComponent<Canvas>();
        instantiatedSlider = Instantiate(slider, canvas.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-1,0)*Time.deltaTime*speed);

        sliderLocation = cam.WorldToScreenPoint(transform.position);
        instantiatedSlider.transform.position = sliderLocation;
        instantiatedSlider.value = bossHealth;
    }

    public void EnemyHit()
    {
        bossHealth--;
        if (bossHealth <= 0)
        {
            gameManagerScript.UpdateGold(100);
            Destroy(instantiatedSlider);
            Destroy(gameObject);
        }
        
    }
}
