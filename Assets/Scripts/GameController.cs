using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject target;
    private BoardingParty selector;
    public static int level = 1;
    public static int[] assignment = new int[] { 0, 0, 0, 0 };
    public string goodAns;
    private Transform enemyPos;


    public GameObject pauseMenuPrefab;
    private GameObject pausemenuInstance;
    private Canvas canvas;
    
	// Use this for initialization
    
    void Start()
    {
        level = 1;
        assignment = new int[] { 0, 0, 0, 0 };

        enemyPos = GameObject.Find("EnemyBig").GetComponent<Transform>();
        for (int i = 0; i < 3; i++)
        {

            Instantiate(target, enemyPos.position, Quaternion.identity);
        }
        
        

        
        Dialogue dialogue = new Dialogue(new string[] { "This is the Admiral. There is a large enemy ship ahead that we need you to destroy", "Good Luck" }, "Admiral Cryane");
        FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
	}
   
    
	
	// Update is called once per frame
	void Update () {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        
        if (enemies.Length <= 0 && level==1)
        {
            level = 2;
            stageTwo();
        }


        

        


	}

     


   
    public void stageTwo()
    {

        Dialogue dialogue1 = new Dialogue(new string[] { "Congradulations. You have defeated the first wave", "For your next task, there are 4 incoming enemies.", "One of them is the enemy boarding party.", "The other three contain a bomb that will decimate all life.", "Deocde the intel we provided to know which ship to shoot" }
           , "Admiral Cryane");

        FindObjectOfType<dialogueManager>().StartDialogue(dialogue1);

        
       
        
        int rand = (Random.Range(1,4));

        
        for (int i = 0; i < assignment.Length; i++)
        {
            while(assignment[i] == 0)
            {
                rand = (char)(Random.Range(65, 69));
                bool taken = false;
                for (int k = 0; k < assignment.Length; k++)
                {
                    if (assignment[k] == rand) { taken = true; }
                    
                }
                if (!taken)
                {
                    assignment[i] = rand;
                    
                }
            }
        }


        GameObject.Find("one").GetComponent<BoardingParty>().active = true;
        GameObject.Find("two").GetComponent<BoardingParty>().active = true;
        GameObject.Find("three").GetComponent<BoardingParty>().active = true;
        GameObject.Find("four").GetComponent<BoardingParty>().active = true;

        
     }

    void stageThree()
    {

        SceneManager.LoadScene("InsideShip");
        level = 3;



    }
    public void Awake()
    {
        canvas = GetComponent<Canvas>();

    }


    public void CreatePauseMenu()
    {

        if (pausemenuInstance == null)
        {
            Instantiate(pauseMenuPrefab, canvas.transform);


        }
        else
        {

            pausemenuInstance.SetActive(true);

        }
    }

    public void checkAns(string name)
    {
        if (System.Convert.ToChar(assignment[(int.Parse(name)) - 1]) == System.Convert.ToChar(goodAns))
        {
            DontDestroyOnLoad(transform.gameObject);
            stageThree();
            
        }
        else
        {

            gameOver();

        }
    }

    
    public void gameOver()
    {
        
        SceneManager.LoadScene("GameOver");
    }

    public  string newQuestion()
    {
        

        string path = "Assets/Resources/test.txt";
        string[] lines = System.IO.File.ReadAllLines(path);

        int random=1;
        while (random % 2 != 0)
        {
            random = Random.Range(0, lines.Length);
        }

        Text question = GameObject.Find("question").GetComponent<Text>();
         
        question.text = lines[random];


        Debug.Log(lines[random + 1]);
         return (lines[random + 1]);
       
    }
}
