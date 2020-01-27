using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabStuffToPoint : MonoBehaviour
{
    GameObject MyGrabPoint;
    [SerializeField][Range(1.5f, 10f)] float GrabMaxRange = 1.5f;
    [SerializeField] Material InteractingPlayerColor, StandartPlayerColor;
    MeshRenderer PlayerRenderer;


    private void Start()
    {
        MyGrabPoint = GameObject.Find("GrabPoint");
        PlayerRenderer = this.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            Vector3 _Dir = MyGrabPoint.transform.position - this.transform.position;
            Debug.DrawRay(this.transform.position, _Dir * GrabMaxRange, Color.red);

            RaycastHit MyHit;
            if (Physics.Raycast(this.transform.position, _Dir, out MyHit, GrabMaxRange) && MyHit.transform.tag == "Grabable") //eventuellement rajouter un layer mask
            {
                //Si le Raycast générer entre en contact avec un objet qui peu etre grab
                GameObject GrabedItem = MyHit.transform.gameObject;

            }


            //l'avatar du J devient translucide
            Material[] MyMats = PlayerRenderer.materials;
            MyMats[0] = InteractingPlayerColor;
            PlayerRenderer.materials = MyMats;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            //l'avatar du J devient Opaque
            Material[] MyMats = PlayerRenderer.materials;
            MyMats[0] = StandartPlayerColor;
            PlayerRenderer.materials = MyMats;
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(MyGrabPoint.transform.position , 0.25f);
    }
}
