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
    Run, //6
    Attack3, //7
    WakingUp, //8
    PlayingDead //9
}

public class BossAnimationController : MonoBehaviour
{
    public BossState bossState;
    public BossState previousBossState;

    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("BossState", (int)bossState);
    }

    public void SetState(BossState newState)
    {
        if (newState != bossState)
        {
            previousBossState = bossState;
            bossState = newState;
        }
    }
}
