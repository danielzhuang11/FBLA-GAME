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
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0.0F;


        direction = (mousePosition - transform.position).normalized;
      
        Destroy(gameObject, 2);

    }

    void Update()
    {


        transform.up = direction;
        transform.position += direction * speed * Time.deltaTime;
    }
    


}
