using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine<EState> : MonoBehaviour where EState : Enum
{
	public delegate void StateChangedHandler<EState>(EState newState);

	public event StateChangedHandler<EState> StateChanged;

	protected Dictionary<EState, BaseState> States = new Dictionary<EState, BaseState>();
	protected BaseState CurrentState;

	protected bool IsTransitioningState = false;

	private void Start()
	{
		CurrentState.EnterState();
	}

	private void Update()
	{
		EState nextStateKey = (EState)CurrentState.GetNextState();

		if (!IsTransitioningState && nextStateKey.Equals(CurrentState.StateKey))
		{
			CurrentState.UpdateState();
		}
		else if (!IsTransitioningState)
		{
			TransitionToState(nextStateKey);
		}
	}

	public void TransitionToState(EState stateKey)
	{
		IsTransitioningState = true;
		CurrentState.ExitState();
		CurrentState = States[stateKey];
		CurrentState.EnterState();
		IsTransitioningState = false;

		StateChanged?.Invoke(stateKey);
	}

	private void OnTriggerEnter(Collider other)
	{
		CurrentState.OnTriggerEnter(other);
	}
	private void OnTriggerStay(Collider other)
	{
		CurrentState.OnTriggerStay(other);
	}
	private void OnTriggerExit(Collider other)
	{
		CurrentState.OnTriggerExit(other);
	}

	internal void TransitionToState(object chasePlayerState)
	{
		throw new NotImplementedException();
	}
}
