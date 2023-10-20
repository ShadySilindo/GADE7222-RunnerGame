using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static EnemyStateMachine;

public class FollowPathState : BaseState
{
	List<Vector3> path;
	// The index of the current path point
	int currentPoint;

	// The speed of the enemy
	float speed;

	// The distance threshold to reach a path point
	float threshold;

	// The distance threshold to detect the player
	float detectionRange;

	// The reference to the player object
	GameObject player;

	GameObject enemy;
	//I had to get the transform for the enemy here becasue Im not inherting from Monobehaviour?


	public StateMachine<EState> stateMachine;

	public EnemyStateMachine enemyStateMachine;
	//copy and paste this into every sub state machine because you need to referect the state machines


	// The constructor that takes the path points and the speed as parameters
	public FollowPathState(List<Vector3> path, float speed) : base("Follow Path")
	{
		this.path = path;
		this.speed = speed;
		currentPoint = 0;
		threshold = 0.1f;
		detectionRange = 10f;
		player = GameObject.FindWithTag("Player");
		enemy = GameObject.FindWithTag("Enemy");
}

	// The update method that moves the enemy along the path and checks for the player
	public override void UpdateState()
	{
		// Move towards the current path point
		Vector3 direction = (path[currentPoint] - enemy.transform.position).normalized;
		enemy.transform.position += direction * speed * Time.deltaTime;

		// Check if the enemy reached the current path point
		if (Vector3.Distance(enemy.transform.position, path[currentPoint]) < threshold)
		{
			// Increment the current point index and wrap around if needed
			currentPoint = (currentPoint + 1) % path.Count;
		}

		// Check if the enemy sees the player
		if (Vector3.Distance(enemy.transform.position, player.transform.position) < detectionRange)
		{
			// Transition to chase state
			//	StateMachine.TransitionToState(ChasePlayerState); // <-- use GetComponent to access the StateMachine component
			stateMachine.TransitionToState(enemyStateMachine.chasePlayerState);
			//fixed it by refencing the necessary statemachines
		}
	}

	// The get next state method that returns the same state by default
	public override IState GetNextState()
	{
		return this;
	}
}
