using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    Animator anim;

    bool isKeyOn = false;

    [SerializeField]
    bool comboOK = false;

    bool atk1 = true;
    bool atk2 = false;
    bool atk3 = false;
    bool atk4 = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(atk1 == true)
            {
                if(isKeyOn)
                {
                    isKeyOn = false;
                    atk1 = false;
                    comboOK = true;
                }
                else
                {
                    anim.SetBool("atk1", true);
                }
            }
            else if (atk2 == true)
            {
                if(isKeyOn)
                {
                    isKeyOn = false;
                    atk2 = false;
                    comboOK = true;
                }
            }
            else if (atk3 == true)
            {
                if (isKeyOn)
                {
                    isKeyOn = false;
                    atk3 = false;
                    comboOK = true;
                }
            }
            else if (atk4 == true)
            {
                
            }
        }

    }
    
    public void StartIdle()
    {
        isKeyOn = false;
        comboOK = false;
        atk1 = true;
        atk2 = false;
        atk3 = false;
        atk4 = false;
    }

    public void StartATK1()
    {
        
        isKeyOn = true;
    }
    public void EndATK1()
    {
        if(comboOK)
        {
            anim.SetBool("atk2", true);
        }
        else
        {
            anim.SetBool("atk1", false);
        }
    }

    public void StartATK2()
    {
        isKeyOn = true;
        atk2 = true;
        comboOK = false;
    }
    public void EndATK2()
    {
        if (comboOK)
        {
            anim.SetBool("atk3", true);
        }
        else
        {
            anim.SetBool("atk1", false);
            anim.SetBool("atk2", false);
        }
    }

    public void StartATK3()
    {
        isKeyOn = true;
        atk3 = true;
        comboOK = false;
    }
    public void EndATK3()
    {
        if (comboOK)
        {
            anim.SetBool("atk4", true);
        }
        else
        {
            anim.SetBool("atk1", false);
            anim.SetBool("atk2", false);
            anim.SetBool("atk3", false);
        }
    }

    public void StartATK4()
    {

    }
    public void EndATK4()
    {
        anim.SetBool("atk1", false);
        anim.SetBool("atk2", false);
        anim.SetBool("atk3", false);
        anim.SetBool("atk4", false);
    }

}
