using TMPro.Examples;
using UnityEngine;

public class player_controll : MonoBehaviour
{
	[SerializeField] private Animator animator;
	[SerializeField] private Rigidbody _rigidbody;

	[SerializeField] private float _walkSpeed = 2f;
	[SerializeField] private float _runSpeed = 5f;
	

	private Vector3 _moveVector3;
	


	private bool _isRunning;
	private float cordz;
	private float cordx;

	private Vector3 _moveVector;


	[SerializeField] private Transform _shutPoint;
	private float _shutRange = 40f;


    private void OnEnable()
	{
		my_input_manger.OnMovePressed += ReadMoveInput;
		my_input_manger.OnShiftPressed += ReadShiftInput;
		my_input_manger.OnAttackPressed += ShutWepon2026;

    }
	private void OnDisable()
	{
		my_input_manger.OnMovePressed -= ReadMoveInput;
		my_input_manger.OnShiftPressed -= ReadShiftInput;
		my_input_manger.OnAttackPressed -= ShutWepon2026;
    }
	private void ReadMoveInput(Vector2 inputVector)

	{
		cordz = inputVector.y;
		cordx = inputVector.x;
	}
	private void Move()
	{
		float currentSpeed = _isRunning ? _runSpeed :_walkSpeed;
		/*if (_isRunning )
		{
			currentSpeed = _runSpeed;
		}
		else if (!_isRunning)
		{
			currentSpeed = _walkSpeed;
		}*/
		_moveVector3 = transform.right * cordx + transform.forward * cordz;
		if (_moveVector3.magnitude > 1f)
		{
			_moveVector3.Normalize();
		}
		_moveVector3 *= currentSpeed * Time.deltaTime;
		_rigidbody.MovePosition(_moveVector3 + _rigidbody.position);

		if (animator != null)
		{
			bool isMoving = cordx != 0 || cordz != 0;
			
			animator.SetBool("run", isMoving && _isRunning);
		}
	

	}
	

	private void ReadShiftInput(bool isPressed)
	{
		_isRunning = isPressed;
	}

	/*private void sprint()
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
			_isRunning = true;
			animator.SetBool("run", true);
			_moveVector3 *= _runSpeed * Time.deltaTime;
		}
		else
		{
			_isRunning = false;
			animator.SetBool("run", false);
			_moveVector3 *= _walkSpeed * Time.deltaTime;
		}
	}*/
	private void FixedUpdate()
	{
		Move();
		//sprint();
	}
	private void ShutWepon2026(bool isPressed)
	{
		if (!isPressed)
		{
			return;
        }
		#if UNITY_EDITOR
		drawRey();
#endif
		RaycastHit hit;
		if (Physics.Raycast(_shutPoint.position, transform.forward, out hit, _shutRange))
		{
			Debug.Log(hit.collider.gameObject.name);
        }
    }
#if UNITY_EDITOR
	private void drawRey()
	{
		Debug.DrawRay(_shutPoint.position, transform.forward * _shutRange, Color.red, _shutRange );
	}
}
#endif

	/*[SerializeField] private skeletAnim _anim_ctrl;
	private void Update()
	{

		if (Input.GetKeyDown(KeyCode.W))
		{
		_anim_ctrl.run(true);
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
		_anim_ctrl.run(false);
		}



	}
	private void DoMove () {	
	float currentSpeed = is;
	}*/
