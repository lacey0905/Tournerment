using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMAttack : FSMState
{

    private void OnEnable()
    {
        anim.SetBool("Attack", true);
        isAtk = false;
    }

    private void OnDisable()
    {
        combo = 0;
        anim.SetBool("Attack", false);
    }

    [SerializeField]
    bool isAtk = false;

    int combo = 0;

    private void Update()
    {
        if(!isAtk)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                combo++;
                anim.SetInteger("Combo", combo);
                isAtk = true;
            }
        }
    }

    public void ResetCheck()
    {
        isAtk = false;
    }

    public void EndCheck()
    {
        if(!isAtk)
        {
            isAtk = true;
            Manager.SetState(State.Idle);
        }
        else
        {
            isAtk = false; 
        }
    }

}
