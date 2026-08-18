using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class my_input_manger : MonoBehaviour
{
	public static event Action OnSpacePressed;

	public static event Action<Vector2> OnMovePressed;

	public static event Action<bool> OnShiftPressed;

    public static event Action<bool> OnAttackPressed;

    public void OnSacePresde(CallbackContext input)
	{
		if (input.performed)
		{
			OnSpacePressed?.Invoke();
		}
	}
	public void OnMoveCallback(CallbackContext input)
	{

		Vector2 move = input.ReadValue<Vector2>();
		OnMovePressed?.Invoke(move);


	}
	public void OnAttackCallback(CallbackContext input)
	{
		if (input.performed)
		{
			OnAttackPressed?.Invoke(true);
			//Debug.Log("Attack button pressed");
		}
		else if (input.canceled)
		{
			OnAttackPressed?.Invoke(false);
		}
	}
	
	public void OnLook(CallbackContext input)
	{
		
	}
	public void OnNext(CallbackContext input)
	{

	}
	public void OnInteract(CallbackContext input)
	{

	}
	public void OnCrouch(CallbackContext input)
	{

	}
	public void OnPrevious(CallbackContext input)
	{

	}

	public void OnShiftPrse(CallbackContext input)
	{
		if (input.started)
			
		{
			OnShiftPressed?.Invoke(true);
			Debug.Log("Shift key pressed");
		}
	
		else if (input.canceled)
			
		{
			OnShiftPressed?.Invoke(false);
			Debug.Log("Shift key released"); 
		}
	}


}
