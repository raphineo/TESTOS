using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPointOrientation : MonoBehaviour
{
    GameObject MyGrabPoint;
    float HorizontalAxis;
    float MaxX = 1f, MinX = -1f;

    private void Start()
    {
        MyGrabPoint = GameObject.Find("GrabPoint");
    }
    // Update is called once per frame
    private void Update()
    {
        //trouver un moyen plus simple de synchroniser le mouvement du grabpoint avec celuide la camera
        HorizontalAxis += Input.GetAxis("Mouse Y") * 0.05f;
        HorizontalAxis = Mathf.Clamp(HorizontalAxis, MinX, MaxX);

        Vector3 NewPos = new Vector3(MyGrabPoint.transform.position.x, this.transform.position.y + HorizontalAxis, MyGrabPoint.transform.position.z);

        MyGrabPoint.transform.position = NewPos;

    }
}
