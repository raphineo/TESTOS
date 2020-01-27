using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviour : MonoBehaviour
{
    public List<PointInTime> trajectory;
    int i = 0;
    public int ghostLifes = 3;

    void Start()
    {
        //Debug.Log("final : " + trajectory.Count);
    }

    void Update()
    {
        if (ghostLifes <= 0)
            Destroy(gameObject);
        if (trajectory != null)
        {
            if (i > trajectory.Count - 1)
            {
                i = 0;
                ghostLifes--;
            }

            transform.position = trajectory[i].position;
            transform.rotation = trajectory[i].rotation;
            i++;
        }
        else
            Debug.Log("ntm");

    }
}
