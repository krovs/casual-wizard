using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
    //
	//vars
	float timer;
	public float coolDown;		
	public int damage;
	public bool playerInRange;
	
	//gameobjects
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;	
	GameObject player;
	
	//components	
	Animator anim;
	public AudioSource audioHit;
	
	
	void Start()
	{		
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		enemyHealth = gameObject.GetComponent<EnemyHealth>();	
		anim = gameObject.GetComponent<Animator>();		
	}
	
	
	void Update()
	{		
		timer += Time.deltaTime;
		
		if(timer >= coolDown && playerInRange && !enemyHealth.isDead && !playerHealth.isDead)
			Attack();					
	}
	
	//if the player is entering the collider, is in range
	void OnTriggerEnter(Collider co)
	{		
		if(co.gameObject == player)
			playerInRange = true;				
	}
	
    //is not  in range
	void OnTriggerExit(Collider co)
	{		
		if(co.gameObject == player)
			playerInRange = false;				
	}
	
    //initiates the attack with the animation and audio
	void Attack()
	{
		timer = 0f;
		anim.SetTrigger("isAttacking");
		audioHit.Play();
		StartCoroutine("AnimAndHit");		
	}
	
    //waits for the animation to finihs and substract life points
	IEnumerator AnimAndHit()
	{		
		yield return new WaitForSeconds(.7f);
		if(!playerHealth.isDead)
			playerHealth.TakeDamage(damage);
	}
	
}
	
	
	
	
	