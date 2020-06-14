using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    Animator anim;

    List<float> time = new List<float>();
    bool isATK = false;
    float timer = 0f;
    int step = 0;
    [SerializeField]
    bool isCon = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        time.Add(1.0f);
        time.Add(2.0f);
    }

    private void Update()
    {

        // 공격 버튼 클릭
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(!isATK)
            {
                isATK = true;
                anim.SetTrigger("con");
            }
            else
            {
                if (timer >= time[step])
                {

                }
                else
                {
                    if (step >= time.Count - 1)
                    {

                    }
                    else
                    {
                        if (!isCon)
                        {
                            anim.SetTrigger("con");
                            isCon = true;
                        }
                    }
                }
            }
        }

        // 공격 상태일때는 타이머 작동
        if (isATK)
        {
            timer += Time.deltaTime;
            if (timer >= time[step])
            {
                if (step >= time.Count-1)
                {
                    anim.SetTrigger("GoIdle");
                    timer = 0f;
                    step = 0;
                    isATK = false;
                }
                else
                {
                    if(isCon)
                    {
                        step++;
                        isCon = false;
                    }
                    else
                    {
                        anim.SetTrigger("GoIdle");
                        timer = 0f;
                        step = 0;
                        isATK = false;
                    }
                }
            }
        }

    }


}
