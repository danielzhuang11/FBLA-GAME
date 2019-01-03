using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    
    public GameObject shot;

    Vector3 direction;
    public Transform playerPos;
    private Transform enemypos;
    private float nextActionTime = 0.0f;
    private float period = 0.0f;
    public float speed;
    private Vector3 thing;
    public GameObject explosion;
 

    void Start()
    {
        period = Random.Range(1.0f, 2.0f);
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemypos = GetComponent<Transform>();
    }
    
    
    void Update()
    {
        if (!PauseMenu.GameIsPaused && !dialogueManager.dialogueActive)
        {
            direction = (playerPos.position - transform.position).normalized;
            transform.up = direction;
            transform.position = Vector2.MoveTowards(transform.position, thing, speed * Time.deltaTime);
            if (Time.timeSinceLevelLoad > nextActionTime)
            {
                nextActionTime += period;
                Instantiate(shot, enemypos.position, Quaternion.identity);
                thing = playerPos.position + new Vector3(Random.Range(-5f, 5.0f), Random.Range(-5f, 5.0f), Random.Range(-5f, 5.0f));
            }

        }   
            
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile") )
        {

            Instantiate(explosion, gameObject.transform.position , Quaternion.identity);
           
            Destroy(gameObject);

     
        }
    }
     
     
}
