using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
	string Name { get; }
	void EnterState();
	void ExitState();
	void UpdateState();
	IState GetNextState();
	void OnTriggerEnter(Collider other);
	void OnTriggerStay(Collider other);
	void OnTriggerExit(Collider other);
}

public abstract class BaseState : IState
{
	public string Name { get; protected set; }
	public object StateKey { get; internal set; }

	public BaseState(string name)
	{
		Name = name;
	}
	public virtual void EnterState()
	{
		Debug.Log("Entering state: " + Name);
	}
	public virtual void ExitState()
	{
		Debug.Log("Exiting state: " + Name);
	}
	public abstract void UpdateState();

	public abstract IState GetNextState();

	public virtual void OnTriggerEnter(Collider other)
	{
		Debug.Log("Collided with: " + other.name);
	}
	public virtual void OnTriggerStay(Collider other)
	{
		Debug.Log("Staying in contact with: " + other.name);
	}

	public virtual void OnTriggerExit(Collider other)
	{
		Debug.Log("Stopped colliding with: " + other.name);
	}
}
