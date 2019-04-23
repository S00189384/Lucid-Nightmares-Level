using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BossState
{
    Idle, //0
    Attack1, //1
    Attack2, //2
    Dead, //3
    Evade, //4
    Walk, //5
    Run //6
}

public class BossAnimation : MonoBehaviour
{
    public BossState bossState;
    Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Alpha0))
            bossState = BossState.Idle;
        if (Input.GetKey(KeyCode.Alpha1))
            bossState = BossState.Attack1;
        if (Input.GetKey(KeyCode.Alpha2))
            bossState = BossState.Attack2;
        if (Input.GetKey(KeyCode.Alpha3))
            bossState = BossState.Dead;
        if (Input.GetKey(KeyCode.Alpha4))
            bossState = BossState.Evade;
        if (Input.GetKey(KeyCode.Alpha5))
            bossState = BossState.Walk;
        if (Input.GetKey(KeyCode.Alpha6))
            bossState = BossState.Run;

        animator.SetInteger("BossState", (int)bossState);
    }
}
