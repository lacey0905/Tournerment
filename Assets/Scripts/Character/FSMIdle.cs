using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMIdle : FSMState
{

    private void OnEnable()
    {
        anim.SetBool("Idle", true);
    }

    private void OnDisable()
    {
        anim.SetBool("Idle", false);
    }

    private void Update()
    {

        Vector3 dir = Manager.MoveDirection();

        if(Input.GetKeyDown(KeyCode.X))
        {
            Manager.SetState(State.Evade);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            Manager.SetState(State.Attack);
        }
        else if(dir.x != 0f || dir.z != 0f)
        {
            Manager.SetState(State.Run);
        }
    }

   

}
