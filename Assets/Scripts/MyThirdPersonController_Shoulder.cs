using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]

public class MyThirdPersonController_Shoulder : MonoBehaviour {
	
	public float walkSpeed = 2.0f;
	public float runSpeed = 6.0f;
	public float targetSpeed = 0.0f;
	public float gravity = 20.0f;
	public float jumpSpeed = 8.0f;
	public float turnSpeed = 3.0f;	
	
	
	
	private Quaternion targetRotation;
	
	private CollisionFlags collisionFlags;
	private Vector3 movement;
	private Vector3 moveDirection = Vector3.zero; 
	private float moveSpeed = 0.0f;
	private float verticalSpeed = 0.0f; 
	private float v;
	private float h; 
	CharacterController controller;
	private float rotateSpeed = 500.0f;
	
	public Vector3 aimPoint;
	public Quaternion aimDir;
	
	
	void Start () {
		moveDirection = transform.TransformDirection(Vector3.forward);
		controller = GetComponent<CharacterController>();
	}
	
	
	
	
	// Update is called once per frame
	void Update () {
	
			
		UpdateSmoothedMovementDirection();
				
		movement = moveDirection * moveSpeed + new Vector3(0, verticalSpeed, 0);
		movement *= Time.deltaTime;
		collisionFlags = controller.Move(movement);

		controller.Move(moveDirection*Time.deltaTime);
		
		ApplyGravity();
		playerRotation();
		
		
	}
	
	
	void playerRotation() {
		
		
		Ray crosshairRay = Camera.main.ScreenPointToRay(new Vector3((Screen.width/2), (Screen.height/2), Camera.main.nearClipPlane));
			
		//Debug.DrawRay(crosshairRay.origin, crosshairRay.direction, new Color(1f, 0.922f, 0.015f, 1f));

//		RaycastHit hit;
//		if(Physics.Raycast(crosshairRay, out hit)) {
//		 	 aimPoint = hit.transform.position;	
//		}
		

		float hitdist = 100.0f;
    	// If the ray is parallel to the plane, Raycast will return false.
//    	if (playerPlane.Raycast (ray, out hitdist)) 
//		{
			
        	// Get the point along the ray that hits the calculated distance.
        	//Vector3 targetPoint = crosshairRay.GetPoint(hitdist);
 			
		//aimPoint = crosshairRay.GetPoint(hitdist);
			
        	// Determine the target rotation.  This is the rotation if the transform looks at the target point.
        	//targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
		//targetRotation = Quaternion.LookRotation(aimPoint - transform.position);
        	// Smoothly rotate towards the target point.
	//transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
			
//		}
    
	}
	
	void UpdateSmoothedMovementDirection() 
	{
		Transform cameraTransform = Camera.main.transform;
				
		Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);
		forward.y = 0;
		forward = forward.normalized;
		
		Vector3 right = new Vector3(forward.z,0,-forward.x);
				
		v = Input.GetAxisRaw("Vertical");
		h = Input.GetAxisRaw("Horizontal");
		
		Vector3 targetDirection =  h * right + v * forward;
		
		moveDirection = Vector3.RotateTowards(moveDirection, targetDirection, rotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 1000);
	//	moveDirection = targetDirection.normalized;
		
		
		


		
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift))
		{
			moveSpeed = runSpeed;
		} else {
			moveSpeed = walkSpeed;
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			verticalSpeed = jumpSpeed;
		}
	}
	
	void ApplyGravity()
	{
		if (IsGrounded())
			verticalSpeed = 0.0f;
		else
			verticalSpeed -= gravity * Time.deltaTime;
	} 
	
	bool IsGrounded () 
	{
		return (collisionFlags & CollisionFlags.CollidedBelow) != 0;
	}
}
