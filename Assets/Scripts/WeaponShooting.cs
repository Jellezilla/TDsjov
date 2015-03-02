using UnityEngine;
using System.Collections;

public class WeaponShooting : MonoBehaviour 
{
	public GUIStyle myStyle;
	public Texture2D crosshair;
	
	public GameObject PrimaryWeapon;
	public GameObject SecondaryWeapon;
	public Ray GunRay;

	private Vector3 gunDir;
	private Animation gunAnim;
	private float nextFire;
	
	MyThirdPersonController_Shoulder cs;
	WeaponStats ws;
	
	void Start () 
	{
		cs = GetComponent<MyThirdPersonController_Shoulder>();
		ws = PrimaryWeapon.GetComponent<WeaponStats>();	
		Restock ();
		Screen.lockCursor = true;

		
	}
	void FixedUpdate()
	{

	}

	void Update () 
	{

		if(Input.GetButtonDown ("Fire1")) 
		{
			if(ws.currentClip > 0 && Time.time > nextFire) 
			{
				nextFire = Time.time + ws.fireRate;
				Shoot();
				//gunAnim.animation.Play ("Shooting");
	
			}
		}
	
		if(Input.GetKeyDown(KeyCode.R))
		{
			Reload();
		}
		
		
		
		// -------- Debugging -----------// 


		cs.aimDir = Quaternion.LookRotation (cs.aimPoint - ws.gunMuzzle.transform.position);



		// This Ray is the one the projectiles should follow
		GunRay = new Ray(ws.gunMuzzle.transform.position, ws.gunMuzzle.transform.forward);
		Debug.DrawRay(GunRay.origin, GunRay.direction, new Color(1f, 0.922f, 0.515f, 1f));

		// This Ray is not to be used - maybe for aim direction, but this should originate from head. 
		//Debug.DrawRay(ws.gunMuzzle.transform.position, cs.aimPoint, new Color(1f, 0.0f, 0.0f, 1000f));



		//-------------------------------//
		RaycastHit hit;
		//Ray ray = Camera.main.ScreenPointToRay (new Vector3(Screen.height/2,Screen.width/2,0));
		//Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		//hit2 = new RaycastHit();
		//Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.forward);

		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F,0.5F,0));


		Debug.DrawRay(Camera.main.transform.position, ray.direction);
		if (Physics.Raycast(ray, out hit)) {
			Debug.Log ("Object hit!"+hit.transform.tag);
			Debug.DrawLine(Camera.main.transform.position, hit.point);
			cs.aimPoint = hit.point;

			// hit.point er stedet hvor aim skal target'e!!!
		} else {
			Physics.Raycast (ray, out hit, 100);
			//Debug.DrawRay(cs.transform.position, ray.direction);

			cs.aimPoint = ray.GetPoint(100);
		
		}


//		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)) {
//			Debug.Log (hit.transform.tag);
//			Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, new Color(0f, 1f, 0f, 1f));
//
//		}
//		//Debug.DrawRay(Camera.main.transform.position, ray.direction, new Color(1f, 0f, 1f, 1f));

	}
	
	
	void OnGUI() {
		ApplyCrosshair();
		ShowAmmo();
	}



	//void Shoot() 
	//{
		//thebullet.rigidbody.AddForce(cam.transform.forward * bulletImpulse, ForceMode.Impulse);



	//}

	void Shoot() 
	{
	//	audio.PlayOneShot(shotSound);
		ws.currentClip--;
			

		GameObject clone = Instantiate (ws.projectile, ws.gunMuzzle.transform.position, cs.aimDir) as GameObject;
		Vector3 dir = ws.gunMuzzle.transform.forward.normalized;

//		clone.rigidbody.AddForce(Vector3.forward * 1000);
		//Ray ray = Physics.Raycast
				//Debug.DrawRay(		
		//if(Physics.Raycast(ws.gunMuzzle.transform.position, ws.gunMuzzle.transform.forward, out hit))
		//{
//			Quaternion rot = Quaternion.FromToRotation(Vector3.up, hit.normal);
			for(int i = 0; i < ws.buckshot; i++)
			{
				Debug.Log ("buckshot");
				//Instantiate(projectile, 
			}
		//}
		
	}

					
					
	void Reload() 
	{	
		//if(PrimaryWeapon == shotgun) 
		if(false)
		{
		
			for (int i = ws.currentClip; i < ws.maxClip; i++) 
			{
				ws.currentAmmo--;
				ws.currentClip++;
			}
		} else // for all other weapon types 
		{
			if (ws.currentClip < ws.maxClip)  // is clip full?
			{
				ws.currentAmmo += ws.currentClip;
				//gunAnim.animation.CrossFade("ReloadGun");
	
				if(ws.currentAmmo >= ws.maxClip) // Reload full clip
				{
					StartCoroutine(ReloadWait(ws.maxClip));
									
				} else if(ws.currentAmmo < ws.maxClip) // reload not completely full clip
				{
					StartCoroutine(ReloadWait(ws.currentAmmo));	
				}
			}
		}
	}
	
	public void Restock()
	{
		ws.currentClip = ws.maxClip;
		ws.currentAmmo = ws.maxAmmo;
		//ws.maxAmmo = ws.maxClip + ws.currentAmmo;
	}

	void ApplyCrosshair() 
	{
		float middleScreenX = Screen.width / 2;
		float middleScreenY = Screen.height / 2;

		Rect aimPos = new Rect(middleScreenX-10, middleScreenY-10, 20, 20);
		GUI.DrawTexture(aimPos, crosshair);	
	}
	
	void ShowAmmo()
	{
        GUI.Label (new Rect(Screen.width-100, Screen.height -150, 100,25),ws.currentClip+" / "+ws.currentAmmo, myStyle);
	}
	
//	if(gunAnim.animation.isPlaying == false)
//	{
//		gunAnim.animation.CrossFade("Idle");
//	}

	IEnumerator ReloadWait(int adj) 
	{
		
		ws.currentClip = 0;
		yield return new WaitForSeconds(ws.reloadTime);	
		
		ws.currentClip = adj;      // put new bullets in current clip.
		ws.currentAmmo -= adj;     // subtract the bullets just put in the clip, from the total amount of bullets.
	}	

}
