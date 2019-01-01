using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {
    public float speed;
    public float stoppingDistance;

    private Transform target;
	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
    
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            if (Vector2.Distance(transform.position, target.position) < 20)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(gameObject);

        }
    }
}
