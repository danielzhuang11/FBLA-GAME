using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    public Text healthDisplay;
    public float speed;
   
    private Vector2 moveVelocity;
    public int health;
    public Image healthbar;
    public GameObject shot;
    private Transform playerpos;
    public ParticleSystem fireAnim;
   
	
	void Start () {

        playerpos = GetComponent<Transform>();
	}
	
	
	void Update () {
        GameController controller = GameObject.Find("Game Controller").GetComponent<GameController>();
        if (health <= 0)
        {
            
            controller.gameOver();
          
        }
        if (!PauseMenu.GameIsPaused && !dialogueManager.dialogueActive && health > 0 && GameController.level != 2)
        {

            if (GameController.level == 3)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(-30, -25, 0), 10 * Time.deltaTime);
            }
            else
            {
                var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
                transform.rotation = rot;

                // fireAnim.


                transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

                mousePosition.z = transform.position.z;
                transform.position = Vector3.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
                healthDisplay.text = "HEALTH: " + health;




                if (Vector2.Distance(transform.position, mousePosition) > 0.2f)
                {

                    if (Input.GetMouseButtonDown(0))
                    {
                        fireAnim.Emit(1);
                        Instantiate(shot, playerpos.position, Quaternion.identity);
                    }
                }

            }

            
        }
	}

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
             health--;
             healthbar.fillAmount -= 0.33f;
             Destroy(other.gameObject);
        }
    }
   
    
   
}
