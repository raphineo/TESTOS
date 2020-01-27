using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreaker : MonoBehaviour
{
    public Transform brokenWall;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Grabable")
        {
            BreakDeath();
        }
    }

    private void BreakDeath()
    {
        Debug.Log("BreakDeathRead");
        Vector3 rectifiedPos = new Vector3(transform.position.x, transform.position.y-2.5f, transform.position.z);
        Instantiate(brokenWall, rectifiedPos, transform.rotation);
        Destroy(gameObject);
    }

}
