using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMAttack : FSMState
{
    public override void BeginState()
    {
        base.BeginState();
        anim.SetBool("Attack", true);
        continueCount = 0;
        isContinue = false;
        Debug.Log("공격");
    }

    public override void EndState()
    {
        base.EndState();
        anim.SetBool("Attack", false);
        Debug.Log("공격 종료");
    }

    private void Update()
    {
        if(continueCount < 2)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                isContinue = true;
            }
        }
    }

    [SerializeField]
    int continueCount = 0;
    [SerializeField]
    bool isContinue = false;

    public void BeginAnimation()
    {
        isContinue = false;
        continueCount++;
    }

    public void EndAnimation()
    {

        if(!isContinue)
        {
            // 방향키 입력 감지
            Vector3 dir = Manager.MoveDirection();
            // 방향키 안 누름
            if (dir.x == 0f && dir.z == 0f)
            {
                Manager.SetState(State.Idle);
            }
            // 방향키 누름
            else
            {
                Manager.SetState(State.Run);
            }
        }

        anim.SetBool("AttackContinue", isContinue);
    }

}
