using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyStateMachine;

public class ChasePlayerState : BaseState
{
	float speed;
	// The distance threshold to attack the player
	float attackRange;

	// The distance threshold to lose sight of the player
	float detectionRange;

	// The reference to the player object
	GameObject player;

	GameObject enemy;

	public StateMachine<EState> stateMachine;

	public EnemyStateMachine enemyStateMachine;
	//copy and paste this into every sub state machine because you need to referect the state machines

	// The constructor that takes the speed as a parameter
	public ChasePlayerState(float speed) : base("Chase Player")
	{
		this.speed = speed;
		attackRange = 1f;
		detectionRange = 10f;
		player = GameObject.FindWithTag("Player");
	}

	// The update method that moves the enemy towards the player and checks for the distance
	public override void UpdateState()
	{
		// Move towards the player
		Vector3 direction = (player.transform.position - enemy.transform.position).normalized;
		enemy.transform.position += direction * speed * Time.deltaTime;

		// Check if the enemy is close enough to attack the player
		if (Vector3.Distance(enemy.transform.position, player.transform.position) < attackRange)
		{
			// Transition to attack state
			stateMachine.TransitionToState(enemyStateMachine.meleeAttackState);
		}

		// Check if the enemy loses sight of the player
		if (Vector3.Distance(enemy.transform.position, player.transform.position) > detectionRange)
		{
			// Transition to follow path state
			stateMachine.TransitionToState(enemyStateMachine.followPathState);
		}
	}

	// The get next state method that returns the same state by default
	public override IState GetNextState()
	{
		return this;
	}

}
