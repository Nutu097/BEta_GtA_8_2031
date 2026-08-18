using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class Bob_Contro : MonoBehaviour
{
private int health = 100;
private float speed = 5.0f;
	public BobStete bob_stete { get; private set; } = BobStete.Idle;
	[SerializeField] private NavMeshAgent _agent;

	public void initialize(Bob_stats bobStats)
	{
		health = bobStats.Health;
		speed = bobStats.Speed;
		_agent.speed = speed;
	}
	private void Update()
	{
		
		switch(bob_stete)
		{
			case BobStete.Idle:
				Move();
				break;
		}
		

		// Move the character based on input
		//float horizontal = Input.GetAxis("Horizontal");
		//float vertical = Input.GetAxis("Vertical");
		//Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
		//transform.Translate(movement);
	}

	private void Move()
	{
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

}
public enum BobStete
{
	None=0,
	Idle=1,
	Bobino=2,
	Chase=3,
	Attact=4,
	bobStan=333,

}

