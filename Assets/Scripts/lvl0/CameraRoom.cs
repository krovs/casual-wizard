using UnityEngine;
using System.Collections;

public class CameraRoom : MonoBehaviour 
{
    //camera behaviour lvl0
	
	//gameobjects
	Transform player;
	PlayerMovement playerMovement;

	//vars
	public float smoothing = 5f;	
	public float cameraLimitLeft;
	public float cameraLimitRight;
	
	
	void Awake()
	{				
		player = GameObject.FindGameObjectWithTag("Player").transform;	
		playerMovement = player.GetComponent<PlayerMovement>();						
	}
	
	
	void FixedUpdate()
	{		
		
		if(playerMovement.canMove == true)
		{					
			if(player.transform.position.x >= -.5 )
			{						 
				transform.position = new Vector3(Mathf.Lerp(transform.position.x, cameraLimitRight, smoothing*Time.deltaTime), transform.position.y, transform.position.z);
			}
			if(player.transform.position.x <= -.5 )
			{						 
				transform.position = new Vector3(Mathf.Lerp(transform.position.x, cameraLimitLeft, smoothing*Time.deltaTime), transform.position.y, transform.position.z);
			}
		}
		
		
	}	
}
