using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class text : MonoBehaviour {


 public GameObject target;

    void Update () 
    {
        if (target != null)
        {
            if (GameController.level > 1)
            {
                transform.position = (target.transform.position);
            }
        }
        else
        {
           Destroy(gameObject);
        }
      
    }
 }

