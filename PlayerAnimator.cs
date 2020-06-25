using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;

    private const float smoothTimer = .1f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed; 
        animator.SetFloat("speedPercent", speedPercent, smoothTimer, Time.deltaTime);
    }
}
