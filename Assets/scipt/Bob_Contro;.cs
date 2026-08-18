using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class Bob_Contro : MonoBehaviour
{
	private int health = 100;
	private float _sershRange = 10f;
	private float _serchTimer = 0f;
	private float _serchKd = 1f;
	private player_controll _target;
	private Transform _Randompoint;
	[SerializeField] private LayerMask _serchLayer;
	private float speed = 5.0f;
	private float _attackRange = 2f;
	private float _AttactTimer = 0f;
	private float _AttactKd = 1f;
	private int _damage = 10;
    public bool isAlive => health > 0;
	public BobStete bob_stete { get; private set; } = BobStete.Idle;
	[SerializeField] private NavMeshAgent _agent;

	public void initialize(Bob_stats bobStats)
	{

		health = bobStats.Health;
		speed = bobStats.Speed;
		_agent.speed = speed;	
    }
	private void ScanforPlayer()
	{
		
        Collider[] kids = Physics.OverlapSphere(transform.position, _sershRange, _serchLayer);
		if (kids.Length == 0)
		{
			_target = null;
			bob_stete = BobStete.Idle;
			return;
		}

		if (kids[0].gameObject.TryGetComponent<player_controll>(out player_controll player))
		{
			_target = player;
			bob_stete = BobStete.Chase;
		}
		else
		{
			_target = null;
			bob_stete = BobStete.Idle;
		}
	}
	private void Update()
	{
		_serchTimer += Time.deltaTime;
		if (_serchTimer >= _serchKd)
		{
			ScanforPlayer();	
			_serchTimer = 0f;
		}
		switch (bob_stete)
		{
			case BobStete.Idle:
			
				break;
			case BobStete.Attact:
				Attack();

                break;
			case BobStete.Chase:
				Goto();
                break;
			default:
				return;
		}


		// Move the character based on input
		//float horizontal = Input.GetAxis("Horizontal");
		//float vertical = Input.GetAxis("Vertical");
		//Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
		//transform.Translate(movement);
	}
	private void Goto()
		{
		if (_target == null) return;
        _agent.SetDestination(_target.transform.position);
		float distance = Vector3.Distance(transform.position, _target.transform.position);
		if (distance <= _attackRange)
		{
            bob_stete = BobStete.Attact;
        }
    }

	private void Move()
	{
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
	private void Attack()
	{
		_AttactTimer += Time.deltaTime;
		if (_AttactTimer >= _AttactKd) return;
		_AttactTimer = 0;
		if (_target != null) return;
		_target.TakeDamage(_damage);

    }



    public void TakeDamage(int damage)
	{
		if (isAlive) return;

		health -= damage;
		if (health <= 0) return;

		DeathProces();


	}
	private void DeathProces()
	{
		this.gameObject.SetActive(false);
	}
}
	public enum BobStete
	{
		None = 0,
		Idle = 1,
		Bobino = 2,
		Chase = 3,
		Attact = 4,
		bobStan = 333,

	}


