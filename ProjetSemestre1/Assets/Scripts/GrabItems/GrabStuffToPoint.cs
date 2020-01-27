using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrabStuffToPoint : MonoBehaviour
{
    [SerializeField] GameObject MyGrabPoint;
    [SerializeField][Range(1.5f, 10f)] float GrabMaxRange = 1.5f;
    [SerializeField] Material InteractingPlayerColor, StandartPlayerColor;
    MeshRenderer PlayerRenderer;
    GameObject GrabedItem;
    public int throwForce = 15;


    private void Start()
    {
        //MyGrabPoint = GameObject.Find("GrabPoint");
        PlayerRenderer = this.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (GrabedItem != null)
        {
            GrabedItem.transform.position = MyGrabPoint.transform.position;

        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (GrabedItem == null)
            {
                Vector3 _Dir = MyGrabPoint.transform.position - this.transform.position;
                Debug.DrawRay(this.transform.position, _Dir * GrabMaxRange, Color.red);

                RaycastHit MyHit;
                if (Physics.Raycast(this.transform.position, _Dir, out MyHit, GrabMaxRange) && MyHit.transform.tag == "Grabable") //eventuellement rajouter un layer mask
                {
                    //Si le Raycast générer entre en contact avec un objet qui peu etre grab
                    GrabedItem = MyHit.transform.gameObject;
                }


                //l'avatar du J devient translucide
                Material[] MyMats = PlayerRenderer.materials;
                MyMats[0] = InteractingPlayerColor;
                PlayerRenderer.materials = MyMats;
            }
            else
            {
                GrabedItem = null;
            }
            
            
            
        }
        if (Input.GetButtonUp("Fire2"))
        {
            //l'avatar du J devient Opaque
            Material[] MyMats = PlayerRenderer.materials;
            MyMats[0] = StandartPlayerColor;
            PlayerRenderer.materials = MyMats;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (GrabedItem != null)
            {
                Rigidbody GrabedItemRb = GrabedItem.GetComponent<Rigidbody>();
                GrabedItemRb.AddForce((transform.forward+transform.up/2) * throwForce, ForceMode.VelocityChange);
                GrabedItem = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("wat");
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(MyGrabPoint.transform.position , 0.25f);
    }
}
