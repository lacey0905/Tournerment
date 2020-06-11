using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Idle = 0,
    Run,
    Attack,
    Roll
}

public class FSMManager : MonoBehaviour
{

    public State currentState;

    Dictionary<int, FSMState> StateDic = new Dictionary<int, FSMState>();

    private void Awake()
    {
        StateDic.Add(0, GetComponent<FSMIdle>());
        StateDic.Add(1, GetComponent<FSMRun>());
        StateDic.Add(2, GetComponent<FSMAttack>());
    }

    private void Start()
    {
        SetState(State.Idle);
    }

    private void Update()
    {
       
    }

    public void SetState(State newState)
    {
        StateDic[(int)currentState].EndState();
        StateDic[(int)currentState].enabled = false;
        StateDic[(int)newState].enabled = true;
        StateDic[(int)newState].BeginState();
        currentState = newState;
    }

    public Vector3 MoveDirection()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        return new Vector3(h, 0f, v);
    }


}
