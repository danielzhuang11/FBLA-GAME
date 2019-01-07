using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject target;
    private BoardingParty selector;
    public static int level = 1;
    public static int[] assignment = new int[] { 0, 0, 0, 0 };
    public string goodAns;
    private Transform enemyPos;
    public static int streak =0;

    public GameObject gameOverUI;
    new public Camera camera;
    public GameObject explosion;
    public Animator animator;
    public GameObject panel;
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
   // public GameObject pauseMenuPrefab;
  //  private GameObject pausemenuInstance;
    private Canvas canvas;
   
	// Use this for initialization
    
    void Start()
    {
        AudioManager.instance.playRand();
        level = 1;
        assignment = new int[] { 0, 0, 0, 0 };

        enemyPos = GameObject.Find("EnemyBig").GetComponent<Transform>();
        for (int i = 0; i < streak +2; i++)
        {

            Instantiate(target, enemyPos.position, Quaternion.identity);
        }
        
        

        
        Dialogue dialogue = new Dialogue(new string[] { "This is the Captain. There is a large enemy ship ahead that we need you to eliminate.", "First you must stop their defending fighters", "Good luck and stay tuned for more assignments." }, "-Captain Cryane");
        FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
	}

	
	// Update is called once per frame
	void Update () {
        //starts stage 2
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        
        if (enemies.Length <= 0 && level==1)
        {
            level = 2;
            stageTwo();
        }


	}

  
    public void stageTwo()
    {
        //starts second dialogue
        panel.SetActive(true);
        Dialogue dialogue1 = new Dialogue(new string[] { "Congratulations. You have defeated the first wave", "The enemy is launching a counterattack of four enemies", "Our intel has determined that one of them is the enemy boarding party.", "The other three ships are decoys", "Deocde the intercepted intel we provided to know which ship to shoot", "Make sure to shoot the right ship because you only have 1 missile capable of breaking through their armor." }
           , "-Captain Cryane");

        FindObjectOfType<dialogueManager>().StartDialogue(dialogue1);
   
        //resets player and camera for next stage
        GameObject player = GameObject.Find("Player");
        player.transform.position = new Vector3(-30f, -40f, player.transform.position.z);

        player.transform.rotation = Quaternion.Euler(0, 0, 0);

        camera.orthographicSize = 10.0f;
        camera.transform.position = player.transform.position + new Vector3(0.5f, 8f, -2f);

        // activates the questions
        a.SetActive(true);
        b.SetActive(true);
        c.SetActive(true);
        d.SetActive(true);
     }

    
    //moves on to 3rd stage
    void stageThree()
    {

        StartCoroutine(switchScene());
        level = 3;
        //SceneManager.LoadScene("InsideShipNew");
    }
    //waits 3 seconds for player to reach enemy before switching scenes
    IEnumerator switchScene()
    {
        
        yield return new WaitForSeconds(3);
        animator.SetTrigger("fade_out");
       // SceneManager.LoadScene("InsideShipNew");
    }
    //checks if player has hit the correct ship and switches 
    public void checkAns(string name)
    {


        if (GameObject.Find("AParty") != null && System.Convert.ToChar(goodAns) != 'A')
        {
            GameObject.Find("AParty").GetComponent<BoardingParty>().flyback();
        }
        if (GameObject.Find("BParty") != null && System.Convert.ToChar(goodAns) != 'B')
        {
            GameObject.Find("BParty").GetComponent<BoardingParty>().flyback();
        }
        if (GameObject.Find("CParty") != null && System.Convert.ToChar(goodAns) != 'C')
        {
            GameObject.Find("CParty").GetComponent<BoardingParty>().flyback();
        }
        if (GameObject.Find("DParty") != null && System.Convert.ToChar(goodAns) != 'D')
        {
            GameObject.Find("DParty").GetComponent<BoardingParty>().flyback();
        }
        if (System.Convert.ToChar(name) == System.Convert.ToChar(goodAns))
        {

            stageThree();
            
        }
       
    }

    
    public void gameOver()
    {
 
        streak = 0;
        if (level == 1)
        {
            GameObject player = GameObject.FindWithTag("Player");
            explosion = Instantiate(explosion, player.transform.position, Quaternion.identity);
            Destroy(explosion, 1.0f);
            Destroy(player);

            
        }
        else
        {
            GameObject playerBig = GameObject.FindWithTag("PlayerBig");
            explosion = Instantiate(explosion, playerBig.transform.position, Quaternion.identity);
            Destroy(explosion, 1.0f);
            Destroy(playerBig);

        }

        gameOverUI.SetActive(true);
    }

    
}
