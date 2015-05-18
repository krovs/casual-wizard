using UnityEngine;
using System.Collections;

public class SpellLife : MonoBehaviour 
{
    //logic of a player spell

	//vars
	public float lifeTime;  //base lifetime of a spell
	public int damage;      //base damage of a spell	
	public bool self;
	
	//gameobjects
	GameObject player;
	public GameObject explo;
	public GameObject dead;
	EnemyHealth enemyHealth;
	
	
	void Start()
	{			
		player = GameObject.FindGameObjectWithTag("Player");	
		
		StartCoroutine("destro");
	}	
	
		
	void OnCollisionEnter (Collision collison)
	{	
		if(collison.gameObject.tag == "Enemy")
		{				
			if(collison.gameObject.GetComponent<EnemyHealth>())
				collison.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);	
			this.GetComponent<SphereCollider>().enabled = false; //the thingy won't be collected more than one time
			if(collison.gameObject.GetComponent<EnemyMovement>())
				collison.gameObject.GetComponent<EnemyMovement>().BounceBack();
			Destroy(gameObject);
						
		}
		if(collison.gameObject.tag == "EnemySpell")
		{	
			explo.SetActive(true);
			Destroy(gameObject, .1f);
		}
		if(collison.gameObject.layer == LayerMask.NameToLayer("Shootable"))
		{
			dead.SetActive(true);
			Destroy(gameObject, .1f);
		}
		
	}
	
	
	
	IEnumerator destro()
	{						
		yield return new WaitForSeconds(lifeTime); 
		if(self)		
			player.GetComponent<PlayerHealth>().TakeHeal(damage);			
		
		Destroy(gameObject); 
	}	
	
}
