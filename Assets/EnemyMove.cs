using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	
	private int currentWPint;
	private GameObject currentWP;
	private float distanceToWP;
	public float maxSpeed;
	public float movementSpeed;
	private LevelManager lm;
	private Vector3 direction;

	// Use this for initialization
	void Start () 
	{
		lm = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
		currentWPint = -1;
		currentWP = FindNextWaypoint(currentWPint);

	}
	// Update is called once per frame
	void Update () 
	{

	}

	void FixedUpdate()
	{
		direction = (currentWP.transform.position - transform.position).normalized * movementSpeed; 
		rigidbody.velocity = direction;



		// direction

		transform.LookAt(currentWP.transform.position);
		// move 
		//rigidbody.AddForce(Vector3.forward * movementSpeed);
		
		distanceToWP = Vector3.Distance(transform.position,currentWP.transform.position);


		if(rigidbody.velocity.magnitude > maxSpeed)
		{
			rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
		}

		if(distanceToWP < 3)
		{
			currentWP = FindNextWaypoint(currentWPint); // burde rykkes ned i et else statement.
			if(currentWP == lm.lastWP) 
			{
				Destroy (gameObject);
				Debug.Log ("life lost"); // håndtering af kald af lost life. 
			} 
		}

	}

	/// <summary>
	/// Finds the next waypoint.
	/// </summary>
	/// <returns>The next waypoint.</returns>
	/// <param name="curWP">Current W.</param>
	GameObject FindNextWaypoint(int curWP)
	{
		currentWPint += 1;
		return lm.GetNextWP(currentWPint);
	}
}




