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

    public float moveSpeed;

    public void Eavde()
    {
        Vector3 dir = Manager.MoveDirection();
        Vector3 movement = dir.normalized * moveSpeed * Time.deltaTime;
        Turn(movement);
        StartCoroutine(PlayEvade());
    }

    IEnumerator PlayEvade()
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("Evade", false);
        Manager.SetState(State.Idle);
    }

    private void Turn(Vector3 movement)
    {
        Quaternion newRot = Quaternion.LookRotation(movement);
        transform.rotation = newRot;
    }
}
