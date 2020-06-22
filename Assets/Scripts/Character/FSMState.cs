using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMState : MonoBehaviour
{

    private FSMManager _manager;
    protected FSMManager Manager
    {
        get
        {
            return _manager;
        }
    }

    protected Animator anim;
    protected Rigidbody rigidbody;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        _manager = GetComponent<FSMManager>();
    }

    public virtual void BeginState() 
    { 

    }
    public virtual void EndState() 
    { 
    
    }

}
