using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMMonsterIdle : FSMMonsterState
{
    private void OnEnable()
    {
        anim.SetBool("Idle", true);
    }

    private void OnDisable()
    {
        anim.SetBool("Idle", false);
    }

    public float coolTime = 2f;
    float curTime = 0f;

    private void Update()
    {
        
        if(curTime > coolTime)
        {
            curTime = 0f;
            monsterManager.SetState(MonsterState.Attack);
        }
        else
        {
            curTime += Time.deltaTime;
        }

       
    }

}
