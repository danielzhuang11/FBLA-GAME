using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorCollide : MonoBehaviour
{

     public string loadLevel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(loadLevel);
        }
    }

}

/*
public class doorCollide : MonoBehaviour
{
    private string loadlevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))

            SceneManager.LoadScene("InsideShip2");
    }
}
*/
