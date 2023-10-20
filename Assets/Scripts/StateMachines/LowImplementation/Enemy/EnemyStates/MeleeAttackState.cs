using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyStateMachine;

public class MeleeAttackState : BaseState
{
	int damage;
	// The reference to the player object
	GameObject player;

	Animator animator;
	private IState chasePlayerState;

	public StateMachine<EState> stateMachine;

	public EnemyStateMachine enemyStateMachine;
	//copy and paste this into every sub state machine because you need to referect the state machines

	// The constructor that takes the damage as a parameter
	public MeleeAttackState(int damage) : base("Melee Attack")
	{
		this.damage = damage;
		player = GameObject.FindWithTag("Player");
	}

	// The enter state method that plays an attack animation and deals damage to the player
	public override void EnterState()
	{
		base.EnterState();

		// Play an attack animation (assuming there is an Animator component on the enemy)
		animator.Play("Attack");

		// Deal damage to the player (assuming there is a Health component on the player)
		//player.GetComponent<Health>().TakeDamage(damage);
	}

	// The update method that does nothing
	public override void UpdateState()
	{
		// Do nothing
	}

	// The get next state method that returns the chase state
	public override IState GetNextState()
	{
		return chasePlayerState; // <-- use the field, not the class name
	}

}
