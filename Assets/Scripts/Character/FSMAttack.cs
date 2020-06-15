using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMAttack : FSMState
{

    private void OnEnable()
    {
        anim.SetBool("Attack", true);
        anim.SetBool("atk1", true);
    }

    private void OnDisable()
    {
        anim.SetBool("Attack", false);
    }

    public void ATK1()
    {
        StartCoroutine(Attack1());
    }

    public void ATK2()
    {
        StartCoroutine(Attack2());
    }

    public void ATK3()
    {
        StartCoroutine(Attack3());
    }

    public void ATK4()
    {
        StartCoroutine(Attack4());
    }

    IEnumerator Attack1()
    {
        bool reserve = false;
        bool isLoop = true;
        float timer = 0f;
        while(isLoop)
        {
            timer += Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Z))
            {
                reserve = true;
            }
            else if(reserve && timer > 0.5f)
            {
                isLoop = false;
                reserve = false;
                anim.SetBool("atk2", true);
            }
            else if(timer > 1.0f)
            {
                isLoop = false;
                anim.SetBool("atk1", false);
                Manager.SetState(State.Idle);
            }
            yield return null;
        }
    }

    IEnumerator Attack2()
    {
        bool reserve = false;
        bool isLoop = true;
        float timer = 0f;
        while (isLoop)
        {
            timer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Z))
            {
                reserve = true;
            }
            else if (reserve && timer > 0.5f)
            {
                isLoop = false;
                reserve = false;
                anim.SetBool("atk3", true);
            }
            else if (timer > 1.0f)
            {
                isLoop = false;
                anim.SetBool("atk1", false);
                anim.SetBool("atk2", false);
                Manager.SetState(State.Idle);
            }
            yield return null;
        }
    }

    IEnumerator Attack3()
    {
        bool reserve = false;
        bool isLoop = true;
        float timer = 0f;
        while (isLoop)
        {
            timer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Z))
            {
                reserve = true;
            }
            else if (reserve && timer > 0.5f)
            {
                isLoop = false;
                reserve = false;
                anim.SetBool("atk4", true);
            }
            else if (timer > 1.0f)
            {
                isLoop = false;
                anim.SetBool("atk1", false);
                anim.SetBool("atk2", false);
                anim.SetBool("atk3", false);
                Manager.SetState(State.Idle);
            }
            yield return null;
        }
    }

    IEnumerator Attack4()
    {
        bool isLoop = true;
        float timer = 0f;
        while (isLoop)
        {
            timer += Time.deltaTime;
            if (timer > 1.0f)
            {
                isLoop = false;
                anim.SetBool("atk1", false);
                anim.SetBool("atk2", false);
                anim.SetBool("atk3", false);
                anim.SetBool("atk4", false);
                Manager.SetState(State.Idle);
            }
            yield return null;
        }
    }

}
