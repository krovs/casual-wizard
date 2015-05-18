using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	
	//gameobjects
	Transform player;
	//vars
	public float smoothing = 5f;	
	Vector3 offset;
	
	void Awake()
	{		
		//center the camera on the player
		player = GameObject.FindGameObjectWithTag("Player").transform;
		transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);		
		offset = transform.position - player.position;		
	}
	
	
	void FixedUpdate()
	{		
		Vector3 playerCamPos = player.position + offset;
		transform.position = Vector3.Lerp(transform.position, playerCamPos, smoothing*Time.deltaTime);
	}	
}
