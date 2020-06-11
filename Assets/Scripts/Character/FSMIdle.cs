using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMIdle : FSMState
{

    public override void BeginState()
    {
        base.BeginState();
        anim.SetBool("Idle", true);
    }

    public override void EndState()
    {
        base.EndState();
        anim.SetBool("Idle", false);
    }

    private void Update()
    {
        Vector3 dir = Manager.MoveDirection();

        // 공격키 누름
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Manager.SetState(State.Attack);
        }
        // 구르기를 누름
        else if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetBool("Roll", true);
        }
        // 방향키 누름
        else if (dir.x != 0f || dir.z != 0f)
        {
            anim.SetBool("Run", true);
            Manager.SetState(State.Run);
        }
    }

}
