using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour {
    public GameObject shot;
    private Transform target;
    private float count;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        count = 0;
    }

    // Update is called once per frame
     void Update()
    {
        //Instantiate(shot, transform.position, Quaternion.identity);
        if (Vector2.Distance(transform.position, target.position) < 20)
        {
            count += Time.deltaTime;
            if (count > 1) { 
            Instantiate(shot, transform.position, Quaternion.identity);
                count = 0;
            }
           
        }
    
    }
        
    
}
