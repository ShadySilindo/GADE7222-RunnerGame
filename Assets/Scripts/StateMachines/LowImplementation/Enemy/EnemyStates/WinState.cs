using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyStateMachine;

public class WinState : BaseState
{
	int damage;

	public GameObject player;

	public Animator animator;

	public StateMachine<EState> stateMachine;

	public EnemyStateMachine enemyStateMachine;
	//copy and paste this into every sub state machine because you need to referect the state machines
	public WinState(int damage) : base("Win")
	{
		this.damage = damage;
		player = GameObject.FindWithTag("Player");
	}
	// The enter state method that plays a victory animation and stops the game
	public override void EnterState()
	{
		base.EnterState();

		// Play a victory animation (assuming there is an Animator component on the enemy)
		animator.Play("Victory");

		// Stop the game (assuming there is a GameManager component in the scene)
		//GameManager.Instance.StopGame();
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
