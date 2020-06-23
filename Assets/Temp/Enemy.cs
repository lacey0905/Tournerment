using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject hitEft;

    
    public void Damage(Vector3 hitPos)
    {
        Vector3 newPos = transform.position + (Vector3.up * 1.5f);
        GameObject hit = Instantiate(hitEft, newPos, Quaternion.identity) as GameObject;

        //Vector3 dir = transform.position - hitPos;
        //Quaternion newRot = Quaternion.LookRotation(dir.normalized);
        //hit.transform.rotation = newRot;
    }



}
