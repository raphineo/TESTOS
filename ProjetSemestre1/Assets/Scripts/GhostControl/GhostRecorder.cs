using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRecorder : MonoBehaviour
{
    bool isRecording = true;
    bool ghostCreation = false;

    public GameObject ghostPrefab;

    List<PointInTime> _pointsInTime = new List<PointInTime>();

    Rigidbody rb;

    //Allows the ghostRecorder to access the player rigidbody (velocity) ;
    void Start()
    {
        rb = gameObject.GetComponentInParent<Rigidbody>();
    }

    //Stops recording if 'E' is pressed, calls StopRecording() to set isRecording to false && ghostCreation to true ;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isRecording)
                StopRecording();
        }
    }

    //Tests isRecording to save current position (by calling Record() ) and then tests ghostCreation to create the ghost gameObject (by calling CreateGhost() ) ;
    private void FixedUpdate()
    {
        if (isRecording)
            Record();
        if (ghostCreation)
            CreateGhost();
    }

    //Sets isRecording to false && ghostCreation to true ;
    public void StopRecording()
    {
        isRecording = false;
        ghostCreation = true;
    }

    //Adds current PointInTime to the list (current position, current parent velocity, current rotation) ;            //since this script is attached to a child of the player they have the same transform ; 
    public void Record()
    {
        _pointsInTime.Add(new PointInTime(transform.position, rb.velocity, transform.rotation));
    }

    //Instantiates a ghost at the first PointInTime of the list ;
    //Sets its list of PointInTime to let it know its trajectory ;
    //Sets ghostCreation to false as a ghost has already been created ;
    public void CreateGhost()
    {
        Vector3 spawnPosition = _pointsInTime[0].position;
        Quaternion spawnRotation = _pointsInTime[0].rotation;
        GameObject MyGhost = Instantiate(ghostPrefab, spawnPosition, spawnRotation);

        //Saves the gameObject this script is attached to, to allow the ghost to destroy it once it has used all its lifes
        MyGhost.GetComponent<GhostBehaviour>().trajectory = _pointsInTime;
        MyGhost.GetComponent<GhostBehaviour>().parent = gameObject;

        ghostCreation = false;
    }

}
