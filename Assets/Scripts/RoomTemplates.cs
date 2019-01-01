using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject closedRoom;
    public List<GameObject> rooms;
    public float waitTime;
    private bool spawnedDoors;
    public GameObject doors;

    void Update()
    {
       if(waitTime <= 0 && spawnedDoors == false)
        {
            for(int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    Instantiate(doors, rooms[i].transform.position, Quaternion.identity);
                    spawnedDoors = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
