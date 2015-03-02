using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {


	public int health;
	LevelManager lm;

	// Use this for initialization
	void Start () 
	{
		GameObject go = GameObject.Find("LevelManager");
		lm = go.gameObject.GetComponent<LevelManager>();
		health = 100 * lm.currentLevel;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void FixedUpdate() 
	{
		if(health < 1)
		{
			Destroy(gameObject);
			// handle score based on enemy value

		}
	}
	public void Decrease(int adj) 
	{ 
		health -= adj;
		Debug.Log ("hp: "+health);
	}
}
