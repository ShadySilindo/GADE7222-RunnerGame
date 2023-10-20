using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyStateMachine;

public class DeathState : BaseState
{
	public Animator animator;

	public StateMachine<EState> stateMachine;

	public EnemyStateMachine enemyStateMachine;
	//copy and paste this into every sub state machine because you need to referect the state machines
	public DeathState(float speed) : base("Chase Player")
	{

	}
	// The enter state method that plays a death animation and destroys the enemy object
	public override void EnterState()
	{
		base.EnterState();

		// Play a death animation (assuming there is an Animator component on the enemy)
		animator.Play("Death");

		// Destroy the enemy object after some delay (assuming there is a Destroyer component on the enemy)
	//	GetComponent<Destroyer>().DestroyAfterDelay(5f);
	}

	// The update method that does nothing
	public override void UpdateState()
	{
		// Do nothing
	}

	// The get next state method that returns the same state by default
	public override IState GetNextState()
	{
		return this;
	}
}
