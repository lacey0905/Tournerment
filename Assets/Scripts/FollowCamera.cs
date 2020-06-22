using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public GameObject target;
    public float speed;
    public float turnSpeed;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * speed);

        Quaternion newRot = Quaternion.LookRotation(target.transform.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRot, turnSpeed * Time.deltaTime);
    }

}
