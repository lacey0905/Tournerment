using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    CharacterMovement movement;
    CharacterAnimation animator;
    
    public enum State
    {
        Idle,
        Run,
        Roll,
        Attack
    }

    [SerializeField]
    State state;

    float h, v;

    private void Awake()
    {
        animator = GetComponent<CharacterAnimation>(); 
        movement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        // 방향키 입력이 있는가
        bool isControl = h != 0 || v != 0;
        // 공격 버튼을 눌렀는가
        bool isAtk = Input.GetKeyDown(KeyCode.Z);
        // 회피 버튼을 눌렀는가
        bool isRoll = Input.GetKeyDown(KeyCode.X);


        // 회피 버튼을 누르면 무조건
        if(isRoll)
        {
            state = State.Roll;
        }
        // 회피 버튼 안 누르고 공격이 눌렸으면
        else if(!isRoll && isAtk)
        {
            state = State.Attack;
        }
        // 회피도 없고 공격도 없는데 방향키는 눌렀으면
        else if(!isRoll && !isAtk && isControl)
        {
            state = State.Run;
        }
        // 걍 이도 저도 아닐 때
        else
        {
            state = State.Idle;
        }


    }

    private void FixedUpdate()
    {
        
    }

    private Vector3 GetDirection(float h, float v)
    {
        return new Vector3(h, 0f, v);
    }

}
