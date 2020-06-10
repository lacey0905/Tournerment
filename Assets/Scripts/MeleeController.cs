using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{

    Animator anim;

    public float coolTime;
    float curCoolTime = 0f;
    bool isAtkCool = false;

    bool atkMode = false;
    bool isComboMode = false;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(!isAtkCool)
            {
                if(atkMode)
                {
                    if(!isComboMode)
                    {
                        anim.SetBool("Combo", true);
                        isComboMode = true;
                    }
                }
                else
                {
                    atkMode = true;
                    anim.SetTrigger("Atk");
                }
            }
        }

        if (isAtkCool)
        {
            curCoolTime += Time.deltaTime;
            if (curCoolTime >= coolTime)
            {
                isAtkCool = false;
                curCoolTime = 0f;
            }
        }

    }
    
    public void ComboStart()
    {
        isComboMode = false;
        anim.SetBool("Combo", false);
    }

    public void ComboEnd()
    {
        if (!isComboMode)
        {
            isAtkCool = true;
            atkMode = false;
            anim.SetBool("Combo", false);
        }
    }

    public void LastAtk()
    {
        isAtkCool = true;
        atkMode = false;
        anim.SetBool("Combo", false);
    }

}
