using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMRun : FSMState
{
    private void OnEnable()
    {
        anim.SetBool("Run", true);
    }

    private void OnDisable()
    {
        anim.SetBool("Run", false);
    }

    public float moveSpeed;
    public float turnSpeed;

    private void FixedUpdate()
    {
        Vector3 dir = Manager.MoveDirection();

        if (Input.GetKeyDown(KeyCode.X))
        {
            Manager.SetState(State.Evade);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            Manager.SetState(State.Attack);
        }
        else if(dir.x != 0f || dir.z != 0f)
        {
            Vector3 movement = dir.normalized * moveSpeed * Time.deltaTime;
            Move(movement);
            Turn(movement);
        }
        else if (dir.x == 0f && dir.z == 0f)
        {
            Manager.SetState(State.Idle);
        }
    }

    private void Move(Vector3 movement)
    {
        rigidbody.MovePosition(transform.position + movement);
    }

    private void Turn(Vector3 movement) 
    {
        Quaternion newRot = Quaternion.LookRotation(movement);
        rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, newRot, turnSpeed * Time.deltaTime);
    }

}
