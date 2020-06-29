using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class col : MonoBehaviour
{


    public Vector3 halfExtents;

    private void FixedUpdate()
    {
        //RaycastHit[] hits = Physics.BoxCastAll(transform.position, halfExtents, Vector3.up);
    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(transform.position, halfExtents * 2f);
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }

}
