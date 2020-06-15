using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Idle = 0,
    Attack,
}

public class FSMManager : MonoBehaviour
{

    public State currentState;

    public List<FSMState> stateList = new List<FSMState>();
    Dictionary<int, FSMState> stateDic = new Dictionary<int, FSMState>();

    private void Awake()
    {
        for(int i=0; i < stateList.Count; i++)
        {
            stateDic.Add(i, stateList[i]);
        }
        SetState(State.Idle);
    }

    private void Update()
    {

    }

    public void SetState(State newState)
    {
        stateDic[(int)currentState].enabled = false;
        stateDic[(int)newState].enabled = true;
        currentState = newState;
    }

}
