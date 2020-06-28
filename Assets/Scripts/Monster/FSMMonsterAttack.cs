using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMMonsterAttack : FSMMonsterState
{
    private void OnEnable()
    {
        anim.SetBool("Attack", true);
        targetPoint = target.position;
    }

    private void OnDisable()
    {
        anim.SetBool("Attack", false);
    }

    public Transform target;
    private Vector3 targetPoint;
    public float speed;
    public GameObject eft;
    public Transform eftPos;

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, targetPoint);
        Vector3 dir = targetPoint - transform.position;
        dir = dir.normalized;

        if(dist > 2f)
        {
            Quaternion newRot = Quaternion.LookRotation(dir);
            transform.rotation = newRot;
            transform.position += dir * speed * Time.deltaTime;
        }
        else
        {
            monsterManager.SetState(MonsterState.Idle);
        }
    }

    public void Hit()
    {
        GameObject t = Instantiate(eft, eftPos.position, Quaternion.identity) as GameObject;
    }

}
