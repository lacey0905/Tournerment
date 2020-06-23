using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMAttack : FSMState
{

    private void OnEnable()
    {
        anim.SetBool("Attack", true);
        anim.SetBool("atk1", true);
        weapon.GetComponent<Sword>().OnSlash(true);
    }

    private void OnDisable()
    {
        anim.SetBool("Attack", false);
        weapon.GetComponent<Sword>().OnSlash(false);
    }


    public GameObject weapon;
 
    public void OnHit()
    {
        weapon.GetComponent<Sword>().Hit();
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

    public void CheckRun()
    {
        Vector3 dir = Manager.MoveDirection();
        if (dir.x != 0f || dir.z != 0f)
        {
            Manager.SetState(State.Run);
        }
        else
        {
            Manager.SetState(State.Idle);
        }
    }

    public void GoEvade()
    {
        Manager.SetState(State.Evade);
    }

    IEnumerator Attack1()
    {
        bool reserve = false;
        bool isLoop = true;
        float timer = 0f;
        while(isLoop)
        {
            timer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.X))
            {
                isLoop = false;
                anim.SetBool("atk1", false);
                GoEvade();
            }
            else if (Input.GetKeyDown(KeyCode.Z))
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
                CheckRun();
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
            if (Input.GetKeyDown(KeyCode.X))
            {
                isLoop = false;
                anim.SetBool("atk1", false);
                anim.SetBool("atk2", false);
                GoEvade();
            }
            else if (Input.GetKeyDown(KeyCode.Z))
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
                CheckRun();
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
            if (Input.GetKeyDown(KeyCode.X))
            {
                isLoop = false;
                anim.SetBool("atk1", false);
                anim.SetBool("atk2", false);
                anim.SetBool("atk3", false);
                GoEvade();
            }
            else if (Input.GetKeyDown(KeyCode.Z))
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
                CheckRun();
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
            if (Input.GetKeyDown(KeyCode.X))
            {
                anim.SetBool("atk1", false);
                anim.SetBool("atk2", false);
                anim.SetBool("atk3", false);
                anim.SetBool("atk4", false);
                isLoop = false;
                GoEvade();
            }
            else if (timer > 1.0f)
            {
                isLoop = false;
                anim.SetBool("atk1", false);
                anim.SetBool("atk2", false);
                anim.SetBool("atk3", false);
                anim.SetBool("atk4", false);
                CheckRun();
            }
            yield return null;
        }
    }

}
