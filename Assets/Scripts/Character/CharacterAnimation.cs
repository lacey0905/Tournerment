using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{

    Animator anim;

    bool isContunue = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangeAnimState(int state)
    {
        switch (state)
        {
            case 0:
                anim.SetBool("Idle", true);
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                anim.SetBool("Attack", true);
                anim.SetBool("Idle", false);
                break;
        }
    }

    public void AttackStart()
    {

    }

    public void AttackEnd()
    {
        if(isContunue)
        {

        }
    }

}
