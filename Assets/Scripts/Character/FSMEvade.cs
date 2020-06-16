using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMEvade : FSMState
{
    private void OnEnable()
    {
        anim.SetBool("Evade", true);
    }

    private void OnDisable()
    {

    }

    public void Eavde()
    {
        StartCoroutine(PlayEvade());
    }


    IEnumerator PlayEvade()
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("Evade", false);
        Manager.SetState(State.Idle);
    }

}
