using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMRun : FSMState
{
    public override void BeginState()
    {
        base.BeginState();
        anim.SetBool("Run", true);
    }

    public override void EndState()
    {
        base.EndState();
        anim.SetBool("Run", false);
    }

    private void Update()
    {
        Vector3 dir = Manager.MoveDirection();
        // 방향키 안 누름
        if (dir.x == 0f && dir.z == 0f)
        {
            EndState();
            Manager.SetState(State.Idle);
        }
    }

}
