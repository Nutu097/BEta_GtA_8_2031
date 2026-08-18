using System.Collections.Generic;
using UnityEngine;

public class bob_spawner : MonoBehaviour
{
  [SerializeField] private Bob_stats bobStats; 
  [SerializeField] private Bob_stats bobStatsPrefab;
  [SerializeField] private Bob_Contro bobControllerPrefab;
  [SerializeField] private List<Transform> spawnPoint;
	[SerializeField] private int maxbob ;
	[SerializeField] private Transform Spawn_Conteiner;

	private List<int> fab = new();
	private void Start()
	{
		SpawnBob();
	   
	}
	private void SpawnBob()
	{
		fab.Clear();
		for (int i = 0; i < maxbob; i++)
		{
			int randomIndex = getslotforbob();
            Transform selectedSpawn = spawnPoint[randomIndex];
			Bob_Contro bobController = Instantiate(bobControllerPrefab, selectedSpawn.position, selectedSpawn.rotation);
			bobController.initialize(bobStats);

		}
	}
	
	private int getslotforbob()
	{
		int slot = 0;
		
		for (int j = 0; j < spawnPoint.Count; j++)
		{
            int randomIndex = Random.Range(0, spawnPoint.Count);
			if (!fab.Contains(randomIndex))
			{
				slot = randomIndex;
				fab.Add(randomIndex);
				return slot;
			}
        }

		return slot ;
	}
	public void OnDrawGizmos()
    {
        if (spawnPoint == null)
            return;
        Gizmos.color = Color.green;
        foreach (Transform spawn in spawnPoint)
        {
            if (spawn != null)
            {
                Gizmos.DrawSphere(spawn.position, 0.5f);
            }
        }
    }
	public void FindSpawnPoints()
    {
        spawnPoint.Clear();
        foreach (Transform child in Spawn_Conteiner)
        {
            spawnPoint.Add(child);
        }
    }	
}
//🐓🐧🦃🦆🦉🦅🦚🐣🦜🐤🐥🦢🐦‍🔥🦤🐦‍⬛🦩🐦🪽🕊️🪿
/*🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓
 * 🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓
 * 🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓
 * 🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓
 * 🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓🐓*/