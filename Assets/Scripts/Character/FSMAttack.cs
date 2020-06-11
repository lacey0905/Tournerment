using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMAttack : FSMState
{
    public override void BeginState()
    {
        base.BeginState();
        anim.SetBool("Attack", true);
    }

    public override void EndState()
    {
        base.EndState();
        anim.SetBool("Attack", false);
        anim.SetBool("AttackContinue", false);
        currentTimer = 0f;
        isContinue = false;
    }

    private float continueTimer = 1.0f;
    private float currentTimer = 0f;

    private bool isContinue = false;

    private void Update()
    {

        if(currentTimer < continueTimer)
        {
            currentTimer += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Z))
            {
                isContinue = true;
                anim.SetBool("AttackContinue", true);
            }
        }
        else
        {
            if (!isContinue)
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
        }
    }

}
