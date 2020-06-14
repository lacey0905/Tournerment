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

    public void IsActive()
    {
    }

    private void Update()
    {
        // 공격키 누름
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Manager.SetState(State.Attack);
        }

        //if(isActive)
        //{
        //    Vector3 dir = Manager.MoveDirection();
        //    // 공격키 누름
        //    if (Input.GetKeyDown(KeyCode.Z))
        //    {
        //        Manager.SetState(State.Attack);
        //    }
        //    // 구르기를 누름
        //    else if (Input.GetKeyDown(KeyCode.X))
        //    {
        //        anim.SetBool("Roll", true);
        //    }
        //    // 방향키 누름
        //    else if (dir.x != 0f || dir.z != 0f)
        //    {
        //        anim.SetBool("Run", true);
        //        Manager.SetState(State.Run);
        //    }
        //}
    }

}
