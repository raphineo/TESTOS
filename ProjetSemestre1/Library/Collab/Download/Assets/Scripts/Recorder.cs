using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    bool isRecording = false;
    bool ghostCreation = false;

    public GameObject ghostPrefab;

    public List<PointInTime> _pointsInTime = new List<PointInTime>();

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (!isRecording)
                StartRecording();
            else 
                StopRecording();
        }
        //Debug.Log("original : " + _pointsInTime.Count);

    }

    private void FixedUpdate()
    {
        if (isRecording)
            Record();
        if (ghostCreation && _pointsInTime!=null)
            CreateGhost();
    }

    public void StartRecording()
    {
        isRecording = true;
    }

    public void StopRecording()
    {
        isRecording = false;
        ghostCreation = true;
    }

    public void Record()
    {
        _pointsInTime.Add(new PointInTime(transform.position, rb.velocity, transform.rotation));
    }

    public void CreateGhost()
    {
        Vector3 spawnPosition = _pointsInTime[0].position;
        Quaternion spawnRotation = _pointsInTime[0].rotation;
        GameObject MyGhost = Instantiate(ghostPrefab, spawnPosition, spawnRotation);
        MyGhost.GetComponent<GhostBehaviour>().trajectory = _pointsInTime;
        Debug.Log("nombre de point a follow: " + _pointsInTime.Count);
        ghostCreation = false;
    }
}
