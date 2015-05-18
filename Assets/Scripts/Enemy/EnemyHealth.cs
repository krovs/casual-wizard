using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour 
{
    //controls the enemy health

	//vars
	public int startingHealth = 100;            
	public int currentHealth;                   
	public bool isDead;                         	
	
	//gameobjects
	ParticleSystem deathParticles;				
	public Slider enemySlider;
	public AudioSource damageSound;
	public GameObject explosion;
	public AudioSource deadSound;
	EnemyMovement enemyMovement;
    GAchievs achiev;
	
	//components
	Animator anim;
	ParticleSystem hitParticles;
	
	
	
	void Awake()
	{	
		hitParticles = GetComponent<ParticleSystem>();
		anim = gameObject.GetComponent<Animator>();
		enemyMovement = gameObject.GetComponent<EnemyMovement>();
		currentHealth = startingHealth;
        achiev = GameObject.Find("Controller").GetComponent<GAchievs>();
	}
	
    //substracts health points
	public void TakeDamage(int amount)
	{	
		if(isDead)
			return;
		StartCoroutine("HitColor");
		damageSound.Play();
		currentHealth -= amount;
		enemySlider.value = currentHealth;
		hitParticles.Play(true);
		if(currentHealth<=0)
			Death();		
	}
	
    //enemy dead, can't move and explode
	void Death()
	{	
		isDead = true;	
		if(enemyMovement != null )	
		{
			enemyMovement.canMove = false;
			anim.SetBool("isDead", true);
		}
		StartCoroutine("ExplodeAndDie");

        achiev.CountEnemies();
	}
	
    
	IEnumerator ExplodeAndDie()
	{
		yield return new WaitForSeconds(2f);
		explosion.SetActive(true);
		deadSound.Play();
		yield return new WaitForSeconds(1f);
		Destroy(gameObject,2.1f);
	}
	
    //the enemy  material color changes when hit
	IEnumerator HitColor()
	{
		gameObject.transform.GetChild(1).GetComponent<Renderer>().material.color = Color.red;
		yield return new WaitForSeconds(.3f);
		gameObject.transform.GetChild(1).GetComponent<Renderer>().material.color = Color.white;
	}
}
