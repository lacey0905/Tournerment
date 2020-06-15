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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Manager.SetState(State.Attack);
        }
    }

   

}
