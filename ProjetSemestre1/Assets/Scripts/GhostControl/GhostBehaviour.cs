using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviour : MonoBehaviour
{
    public List<PointInTime> trajectory;
    int i = 0;
    public int ghostLifes = 3;
    public GameObject parent;


    //Allows the ghost to follow the trajectory saved in the list of PointInTime
    //Every time the ghost finishes a cycle the ghostLifes value decrease, when they reach zero the gameobject is destroyed
    void Update()
    {
        //destroys this gameobject and its parent
        if (ghostLifes <= 0)
        {
            Destroy(parent);
            Destroy(gameObject);
        }
            
        //lifes count
        if (i > trajectory.Count - 1)
        {
            i = 0;
            ghostLifes--;
        }

        //set the position to match the one in the list and then increase i by 1
        transform.position = trajectory[i].position;
        transform.rotation = trajectory[i].rotation;
        i++;

    }
}
