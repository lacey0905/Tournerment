using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterState
{
    Idle = 0,
    Run,
    Attack
}

public class FSMMonsterManager : MonoBehaviour
{
    public MonsterState currentState;

    public List<FSMMonsterState> stateList = new List<FSMMonsterState>();
    Dictionary<int, FSMMonsterState> stateDic = new Dictionary<int, FSMMonsterState>();

    private void Awake()
    {
        for (int i = 0; i < stateList.Count; i++)
        {
            stateDic.Add(i, stateList[i]);
        }
        SetState(MonsterState.Idle);
    }

    public void SetState(MonsterState newState)
    {
        stateDic[(int)currentState].enabled = false;
        stateDic[(int)newState].enabled = true;
        currentState = newState;
    }

  
}
