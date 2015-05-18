using UnityEngine;
using System.Collections;

public class EnemyMovementCollider : MonoBehaviour 
{
    //collider that detects the player in the distance

	//gameobjects
	GameObject player;	
	EnemyMovement enemyMovement;
	
	//vars
	public bool triggered;
	
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		enemyMovement = gameObject.transform.parent.GetComponent<EnemyMovement>();
	}	
	
	void OnTriggerEnter(Collider co)
	{	
		if(co.gameObject == player)
		{
			enemyMovement.playerInRange = true;
		    triggered = true;
		}
	}
}
