using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTest : MonoBehaviour
{

    public GameObject hitEft;
    public float distance;

    public void Hit(Vector3 dir)
    {
        Quaternion newRot = Quaternion.LookRotation(dir);
        Instantiate(hitEft, transform.position + dir * distance, newRot);
    }

}
