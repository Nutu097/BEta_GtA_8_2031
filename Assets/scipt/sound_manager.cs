using UnityEngine;

public class sound_manager : MonoBehaviour
{
	[SerializeField] private AudioSource _audioSource67;
	[SerializeField] private AudioSource _soundSource68;

	private void playJumpSound()
	{
		if (!_audioSource67.isPlaying  )
		{
			Debug.Log("play");
			_audioSource67.Play();
			return;
		}

		//_audioSource67.Stop();
		//_audioSource67.PlayOneShot(_audioSource67.clip);
		if (_audioSource67.isPlaying )
		{
			Debug.Log("stop");
			_audioSource67.Stop();
			return;
		}

	}
	private void OnEnable()
	{
		my_input_manger.OnSpacePressed += playJumpSound;
		my_input_manger.OnMovePressed += checkForMovement;
	}
	private void OnDisable()
	{
		my_input_manger.OnSpacePressed -= playJumpSound;
		my_input_manger.OnMovePressed -= checkForMovement;
	}
	private void checkForMovement(Vector2 input)
	{
	bool toplay = input.sqrMagnitude >= 0.2F;
	playWolkSound(toplay);
	}
	private void playWolkSound(bool isPlaying)
	{
		if (!_soundSource68.isPlaying && isPlaying)
		{
			Debug.Log("play");
			_soundSource68.Play();
			return;
		}

		//_audioSource67.Stop();
		//_audioSource67.PlayOneShot(_audioSource67.clip);
		if (_soundSource68.isPlaying && !isPlaying)
		{
			Debug.Log("stop");
			_soundSource68.Stop();
			return;
		}

	}
}