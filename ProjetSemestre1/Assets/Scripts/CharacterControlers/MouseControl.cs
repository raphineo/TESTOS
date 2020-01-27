using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    private const float yAngle_Min = -10.0f;                                                                     //Valeurs pour clamp les mouvement verticaux de la caméra
    private const float yAngle_Max = 50.0f;

    public GameObject target;

    private float currentX;
    private float currentY;
    public float rotateSpeedX = 5f;      
    public float rotateSpeedY = 1.0f;

    private float horizontalMouseMove;
    private float verticalMouseMove;

    Vector3 offset;                                                                                            //Distance entre la cam et le joueur 

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;                                                              //Bloque le curseur au milieu de la fenêtre de jeu 
        offset = target.transform.position - transform.position;                                               //Recupère la distance entre la cam et le joueur 
    }


    private void Update()
    {
        horizontalMouseMove =  Input.GetAxis("Mouse X") * rotateSpeedX;
        verticalMouseMove = - Input.GetAxis("Mouse Y") * rotateSpeedY;

        currentX += horizontalMouseMove;                                                                       //Pour que la cam bouge en foncion de la souris 
        currentY += verticalMouseMove; 
        
        currentY = Mathf.Clamp(currentY, yAngle_Min, yAngle_Max);                                              //On clamp l'axe Y pour pas que la cam passe sous le sol

        target.transform.parent.Rotate(0, horizontalMouseMove, 0);                                                    //Pour que le joueur rotate dans la même direction que la cam
    }

    void LateUpdate()                                                                                          //Ds LateUpdate pr que les calculs de la cam soient fait après les mvmts du joueur
    {
        Quaternion rotation = Quaternion.Euler(currentY,currentX, 0);                                          //Cam position calculation

        transform.position = target.transform.position - (rotation * offset);                                  //Cam position update & rotation update
        transform.LookAt(target.transform);
    }

}
