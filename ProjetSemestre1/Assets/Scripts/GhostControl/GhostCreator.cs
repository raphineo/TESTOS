using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCreator : MonoBehaviour
{
    public GameObject ghostRecorder;
    public bool isRecording = false;

    void Start()
    {
        
    }

    //Creates an empty gameObject (child of the player) that only has the GhostRecorder script attached, it will be called everytime the player wants to create a ghost
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isRecording)
            {
                GameObject myGhost;
                myGhost = Instantiate(ghostRecorder, transform.position, transform.rotation);
                myGhost.transform.parent = gameObject.transform;
                isRecording = true;
            }
            else
                isRecording = false;
        }
    }
    
}
