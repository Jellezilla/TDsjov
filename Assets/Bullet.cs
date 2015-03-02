using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {


	public float speed = 10;
	public Transform target; 
	public int damage = 15;  // range!!
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() 
	{
		if(target) {
			Vector3 dir = target.position - transform.position;
			rigidbody.velocity = dir.normalized * speed;
		} else {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider co) 
	{
		//Health health = co.GetComponentInChildren<Health>();
		EnemyStats es = co.GetComponent<EnemyStats>();
		Debug.Log ("Collided with: "+co.name);
		if (es.health  > 0) {

			es.Decrease(damage);
		}

	}
}