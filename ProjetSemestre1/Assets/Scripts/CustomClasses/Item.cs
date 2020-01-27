using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool IsStillDragged = false;

    public virtual void GrabAndBring(GameObject Destination)
    {
        IsStillDragged = true;
        while (IsStillDragged)
        {
            this.transform.Translate(Destination.transform.position - this.transform.position);
        }
    }

    public virtual void Drop()
    {
        IsStillDragged = false;
    }
}
