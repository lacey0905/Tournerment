using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewComboController : MonoBehaviour
{

    Animator anim;

    [SerializeField]
    int atkCount = 0;

    [SerializeField]
    bool isAtk = false;

    Vector3 movement;
    Rigidbody rigidbody;

    public float speed;
    public float turnSpeed;

    public float distance;
    public float radius;

    bool isRoll = false;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.SetBool("Idle", true);
    }

    private void Update()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        movement.Set(h, 0f, v);
        movement = movement.normalized;

        if (Input.GetMouseButtonDown(0))
        {
            atkCount++;

            if (!isAtk)
            {
                isAtk = true;
                anim.SetBool("Idle", false);
                anim.SetBool("Atk", true);
            }
        }

    }

    public float range;
    public Vector3 boxSize;

    private void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(1))
        {
            if (!isRoll)
            {
                isRoll = true;
                anim.SetBool("Idle", false);
                anim.SetBool("Atk", false);
                anim.SetBool("Combo", false);
                Quaternion newRot = Quaternion.LookRotation(movement);
                rigidbody.MoveRotation(newRot);
                anim.SetBool("Roll", true);
            }
        }

        if (!isRoll)
        {

            if (movement.x != 0f || movement.z != 0f)
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }

            if (!isAtk)
            {

                rigidbody.MovePosition(transform.position + movement * speed * Time.deltaTime);

                if (movement.x == 0 && movement.z == 0)
                {

                }
                else
                {
                    Quaternion newRot = Quaternion.LookRotation(movement);
                    rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, newRot, turnSpeed * Time.deltaTime);
                }
            }
        }

    }

    int comboCount = 0;

    public void AtkStart()
    {
        comboCount++;

        anim.SetBool("Combo", false);
        atkCount = 0;

        isRoll = false;
        anim.SetBool("Roll", false);
    }

    public void AtkEnd()
    {
        if(atkCount > 0)
        {
            anim.SetBool("Combo", true);
        }
        else
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Atk", false);
            anim.SetBool("Combo", false);
        }
    }

    public void Last()
    {
        comboCount = 0;
        anim.SetBool("Idle", true);
        anim.SetBool("Atk", false);
        anim.SetBool("Combo", false);
    }

    public void Idle()
    {

        comboCount = 0;

        isAtk = false;
        atkCount = 0;

        isRoll = false;
        anim.SetBool("Roll", false);
    }

    public float pushPower;

    public void hit()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position + transform.up * 1f + transform.forward * range, boxSize);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if(hitColliders[i].gameObject.tag == "Test")
            {
                hitColliders[i].GetComponent<HitTest>().Hit(transform.forward);
                //if(comboCount >= 3)
                //{
                //    Rigidbody push = hitColliders[i].GetComponent<Rigidbody>();
                //    push.AddForce(transform.forward * pushPower, ForceMode.Impulse);
                //}
            }
            i++;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + transform.up * 1f + transform.forward * range, boxSize * 2f);
    }

}
