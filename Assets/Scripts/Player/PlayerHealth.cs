using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{
	//controls the player heatlh
    
    //vars
	public int startingHealth = 100;            // enemy starting health
	public int currentHealth;                   // the current health at any point	
	public bool isDead;                         // enemy dead or not	
	
	//components
	ParticleSystem hitParticles;              // particles on geting damage	
	Animator anim;
	public AudioSource damageSound;
	public AudioSource deadSound;
	
	//gameobjects
	public Slider healthSlider;	
	Controller controller;
	
	void Awake()
	{		
		hitParticles = GetComponent<ParticleSystem>();		
		currentHealth = startingHealth;	
		anim = GetComponent<Animator>();
		controller = GameObject.Find("Controller").GetComponent<Controller>();
	}
	
	
	//subtracts the given points to the player heatlh
	public void TakeDamage(int amount)
	{		
		if(isDead)
			return;
		StartCoroutine("HitColor");
		hitParticles.Play(true);
		currentHealth -= amount;
		damageSound.Play();
		healthSlider.value = currentHealth;
		if(currentHealth <= 0)
			Death();		
	}
	
    //adds the given points to the player health
	public void TakeHeal(int amount)
	{
		if(isDead)
			return;		
		currentHealth += amount;		
		if(currentHealth > 100)
			currentHealth = 100;	
		healthSlider.value = currentHealth;	
	}
	
    //player has no health left
	void Death()
	{		
		isDead = true;	
		deadSound.Play();
		gameObject.GetComponent<PlayerMovement>().canMove = false;
		anim.SetBool("isDead", true);		
		controller.RestartLevel();
	}
	
    //the  player material  changes to red  when hit
	IEnumerator HitColor()
	{
		gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
		yield return new WaitForSeconds(.3f);
		gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.white;
	}
}
