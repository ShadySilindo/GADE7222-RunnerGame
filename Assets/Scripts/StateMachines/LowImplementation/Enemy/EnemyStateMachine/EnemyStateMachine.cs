using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyStateMachine;
using UnityEngine.Rendering;

public class EnemyStateMachine : StateMachine<EState>
{
	// The enum that defines the possible states for the enemy
	public enum EState
	{
		FollowPath,
		ChasePlayer,
		MeleeAttack,
		Death,
		Win
	}

	// The state scripts that implement the logic for each state
	public FollowPathState followPathState;
	public ChasePlayerState chasePlayerState;
	public MeleeAttackState meleeAttackState;
	public DeathState deathState;
	public WinState winState;

	private void Awake()
	{
		// Add the state scripts to the dictionary of states
		States.Add(EState.FollowPath, followPathState);
		States.Add(EState.ChasePlayer, chasePlayerState);
		States.Add(EState.MeleeAttack, meleeAttackState);
		States.Add(EState.Death, deathState);
		States.Add(EState.Win, winState);

		// Set the initial state to follow path
		CurrentState = followPathState;
	}
}