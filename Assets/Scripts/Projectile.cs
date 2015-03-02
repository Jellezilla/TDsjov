using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	private GameObject player;
	private WeaponShooting ws;
	// Use this for initialization
	void Start () {
		Destroy (gameObject,5);
		player = GameObject.FindGameObjectWithTag("Player");

		ws = player.GetComponent<WeaponShooting>();
		rigidbody.AddForce(ws.GunRay.direction * 10000 * Time.deltaTime);

	}
	
	// Update is called once per frame
	void Update () {

	}
}
