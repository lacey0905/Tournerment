using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMAttack : FSMState
{
    public override void BeginState()
    {
        base.BeginState();
        isAttack = true;
    }

    public override void EndState()
    {
        base.EndState();
        anim.SetBool("Attack", false);
    }

    [SerializeField]
    bool isAttack = true;

    [SerializeField]
    bool isContinue = false;

    private void Update()
    {
        if (isAttack)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                isContinue = true;
            }
        }
        else
        {
            Vector3 dir = Manager.MoveDirection();
            // 방향키 안 누름
            if (dir.x == 0f && dir.z == 0f)
            {
                EndState();
                Manager.SetState(State.Idle);
            }
            // 방향키 누름
            else
            {
                EndState();
                Manager.SetState(State.Run);
            }
        }
    }

    public void AttackStart()
    {
        isContinue = false;
    }
    
    public void AttackEnd()
    {
        if(!isContinue)
        {
            isAttack = false;
        }
    }

    public void AttackLast()
    {
        isAttack = false;
    }

}
