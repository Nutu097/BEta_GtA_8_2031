using UnityEngine;

[CreateAssetMenu(fileName = "Bob_stats", menuName = "ScriptableObjects/Bob_stats", order = 1)]
public class Bob_stats : ScriptableObject
{
   [SerializeField] private int health = 100;
   [SerializeField] private float speed = 5.0f;
	public int Health => health;
	public float Speed => speed;
}
