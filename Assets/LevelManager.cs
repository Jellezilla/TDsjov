using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public int currentLevel = 1;

	public int CreepAmount;
	private GameObject[] WPs;
	public GameObject currentWP;
	public GameObject lastWP;
	private bool lastWPfound = false;

	private GameObject creep;


	// Use this for initialization
	void Start () {
		WPs = GameObject.FindGameObjectsWithTag("Waypoint");
		currentWP = GetNextWP(0);
		SpawnCreeps(currentLevel);
		lastWP = currentWP;
	}


	// Update is called once per frame
	void Update () {
	
	}

	public GameObject GetNextWP(int curWP) 
	{
		foreach (GameObject go in WPs) 
		{

			if(go.transform.GetComponent<Waypoint>().No == curWP) 
			{
				currentWP = go;
				break;
			}
			if(!lastWPfound) {
				if(go.transform.GetComponent<Waypoint>().No == WPs.Length-1) 
				{
					lastWP = go;
					lastWPfound = true;
				}
			}
		}
		return currentWP;
	}
	private void SpawnCreeps(int lvl)
	{
		for (int i = 0; i < CreepAmount; i++) 
		{

			GameObject enemy = (GameObject)Instantiate(Resources.Load ("Enemy"), GetRandStartPos(), Quaternion.identity);
		}
	}

	private Vector3 GetRandStartPos() 
	{
		float rangeX, rangeZ;
			Vector3 spawnPos;
			rangeX = Random.Range(-5,5);
			rangeZ = Random.Range(-5,5);
			spawnPos = new Vector3 (currentWP.transform.position.x+rangeX,0.5f,currentWP.transform.position.z+rangeZ);

			return spawnPos;
	}
}
