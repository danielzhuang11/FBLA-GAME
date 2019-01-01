using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    Vector3 mousePosition;
    Vector3 direction;
    public Transform target;
   
    void Start()
    {
       // mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       // mousePosition.z = 0.0F;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        direction = (target.position - transform.position).normalized;
      
        Destroy(gameObject, 2);

    }

    void Update()
    {

       // transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.up = direction;
        transform.position += direction * speed * Time.deltaTime;
    }
    


}
