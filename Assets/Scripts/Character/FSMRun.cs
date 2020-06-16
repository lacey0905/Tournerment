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

    private void Update()
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
        else if (dir.x == 0f && dir.z == 0f)
        {
            Manager.SetState(State.Idle);
        }
    }

}
