using UnityEngine;
using System.Collections;


public class EnemySpellLife : MonoBehaviour 
{
	//controls the life of the enemy spell

	public float lifeTime;  
	public int damage;      	
	GameObject player;
	
	
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		StartCoroutine("destro");	
	}
	
	
	void OnCollisionEnter (Collision collison)
	{		
		if(collison.gameObject == player)
		{					
			collison.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
			Destroy(gameObject);
		}
		if(collison.gameObject.tag == "Spell")
		{					
			Destroy(gameObject);
		}
		if(collison.gameObject.layer == LayerMask.NameToLayer("Shootable"))
		{
			Destroy(gameObject);
		}
				
	}
	
	
	IEnumerator destro()
	{		
		yield return new WaitForSeconds(lifeTime); 
		Destroy(gameObject); 
	}	
	
}
