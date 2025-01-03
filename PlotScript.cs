using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlotScript : MonoBehaviour
{
    private GameObject canvasObject;
    public Canvas canvas;
    public Button button;
    public GameObject menu;
    public GameObject tower;

    private GameObject camObject;
    private Camera cam;
    private Button instantiatedButton;
    private GameObject instantiatedTower;
    //private GameObject instantiatedMenu;
    private Vector2 buttonLocation;

    private bool isButtonInstantiated=false;
    public bool isNewPlot;
    //private bool isMenuInstantiated=false;  

    private GameManager gameManagerScript;



    // Start is called before the first frame update
    void Start()
    {

        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        camObject = GameObject.Find("Main Camera");
        cam = camObject.GetComponent<Camera>();

        canvasObject = GameObject.Find("Canvas");
        canvas = canvasObject.GetComponent<Canvas>();

        isNewPlot = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isNewPlot==false)
        {
            Debug.Log("isNewPlot is now false");
        }
        
    }
    private void OnMouseOver()
    {
        if (isButtonInstantiated == false && isNewPlot == true)
        {
            isButtonInstantiated = true;

            instantiatedButton = Instantiate(button, canvas.transform);
            buttonLocation = cam.WorldToScreenPoint(transform.position);
            instantiatedButton.transform.position = buttonLocation;
            instantiatedButton.onClick.AddListener(ButtonPressed);
        }
    }
    private void OnMouseExit() 
    {
        
        isButtonInstantiated = false;
        Destroy(instantiatedButton.gameObject);
    }

    public void ButtonPressed()
    {
        if (gameManagerScript.gold >= 10)
        {
            instantiatedTower = Instantiate(tower);
            instantiatedTower.transform.position = transform.position;
            Destroy(gameObject);
            Destroy(instantiatedButton.gameObject);

            gameManagerScript.UpdateGold(-10);

            //Debug.Log("Button Pressed");
            isNewPlot = false;
            /*isMenuInstantiated = true;
            camObject = GameObject.Find("Main Camera");
            cam = camObject.GetComponent<Camera>();
            canvasObject = GameObject.Find("Canvas");
            canvas = canvasObject.GetComponent<Canvas>();

            Debug.Log("Button Pressed");
            instantiatedMenu = Instantiate(menu,canvas.transform);
            buttonLocation = cam.WorldToScreenPoint(transform.position);
            instantiatedMenu.transform.position=buttonLocation;
            */
        }
    }
}
