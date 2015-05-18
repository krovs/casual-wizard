using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerMovement : MonoBehaviour 
{
    //controls the player movement, with a virtual joystick or a keyboard, for debugging

	//vars
	public float maxSpeed = 6f;             // The speed that the player will move at.	
	Vector3 movement;                       // The vector to store the direction of the player's movement.
	public float turnSmoothing = 15f;       // A smoothing value for turning the player.
	float camRayLength = 100f;              // The length of the ray from the camera into the scene.
	public bool canMove;
	
	//componenets
	Animator anim;                      
	int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
	
	//gameobjects
	Rigidbody playerRigidbody;          
	
	
		
	public enum ControlMode {Joystick, Mouse}; //debug
	public ControlMode controlMode;	//debug
	
	
	void Awake ()
	{
		floorMask = LayerMask.GetMask("Floor");				
		playerRigidbody = GetComponent<Rigidbody>();			
		anim = GetComponent<Animator>();
	}
	
	
	void FixedUpdate()
	{		
		float h,v;
		if(canMove)
		{
			if(controlMode == ControlMode.Joystick)
			{			
				//stores the input joystick axes
				h = CrossPlatformInputManager.GetAxis("Horizontal");
				v = CrossPlatformInputManager.GetAxis("Vertical");
				
				
				//moves the player around the scene
				Move (h, v);
					
				if(h!=0 || v!=0)		
					Turning (h, v);		
					
				Animate(h, v);		
			}
			
			if(controlMode == ControlMode.Mouse)
			{			
				//stores the input axes.(keyboard)
				h = Input.GetAxis("Horizontal");
				v = Input.GetAxis("Vertical");
				
				//moves the player around the scene
				Move (h, v);
				
				TurningMouse();	
				Animate(h, v);		
			}
		}	
	}
	
	void Move (float h, float v)
	{
		if(h != 0 || v != 0)
		{
			//sets the movement vector based on the axis input.
			movement.Set(h, 0f, v);		
			//normalise the movement vector and make it proportional to the speed per second.
			movement = movement.normalized * maxSpeed * Time.deltaTime;		
			//moves the player to it's current position plus the movement.
			if(movement != Vector3.zero)
				playerRigidbody.MovePosition(transform.position + movement);		
			
		}	
	}
	
	
	void Turning(float h, float v)
	{		
		Quaternion targetRotation = Quaternion.LookRotation(new Vector3(h,0,v));
		Quaternion newRotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation,targetRotation,turnSmoothing*Time.deltaTime);
		playerRigidbody.MoveRotation (newRotation);
	}
	
	
	void TurningMouse()
	{
		// Create a ray from the mouse cursor on screen in the direction of the camera.
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);		
		// Create a RaycastHit variable to store information about what was hit by the ray.
		RaycastHit floorHit;		
		// Perform the raycast and if it hits something on the floor layer...
		if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
		{
			// Create a vector from the player to the point on the floor the raycast from the mouse hit.
			Vector3 playerToMouse = floorHit.point - transform.position;			
			// Ensure the vector is entirely along the floor plane.
			playerToMouse.y = 0f;			
			// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
			Quaternion targetRotation = Quaternion.LookRotation (playerToMouse);			
			// Create a rotation that is an increment closer to the target rotation from the player's rotation.
			Quaternion newRotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation, targetRotation, turnSmoothing * Time.deltaTime);			
			// Set the player's rotation to this new rotation.
			playerRigidbody.MoveRotation (newRotation);			
		}
	}
	
	void Animate(float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		
		anim.SetBool("Walking" ,walking);			
	}	
}
