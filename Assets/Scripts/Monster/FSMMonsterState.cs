using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMMonsterState : MonoBehaviour
{
    private FSMMonsterManager _monsterManager;
    protected FSMMonsterManager monsterManager
    {
        get
        {
            return _monsterManager;
        }
    }

    protected Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        _monsterManager = GetComponent<FSMMonsterManager>();
    }

}
