using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {
	
	public int weaponDamage = 7;
	public float timer = 3.0f;
	
	//public GameObject fireEffect;
	//float burnTimer = 3.0f;
	// Use this for initialization
	void Start () {
		Destroy(gameObject,5);
	}
	
	// Update is called once per frame
	void Update () {
		
	timer -= Time.deltaTime;
		
		if(timer <= 0) {
			Explode();
		}
		
	}
	
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "target") {
			print("target hit!");
//			collision.gameObject.tag = "Untagged";
//			Instantiate(fireEffect, collision.transform.position, Quaternion.identity);
//			Explode ();
			
		}
		if(collision.gameObject.tag == "Enemy") {
			//EnemyHealth eh = (EnemyHealth)target.GetComponent("EnemyHealth");
			//eh.AdjustCurrentHealth(-meleedmg);//if(collision.gameObject.CompareTag("EvilCube"))
				print ("enemy hit");	
			//AdjustCurrentHealth(-weaponDamage);
		}
	}
	
	
	
	void Explode()  {
		//Instantiate (fireEffect, gameObject.transform.position, Quaternion.identity);
		Destroy(gameObject);	
	}
}
