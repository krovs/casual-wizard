using UnityEngine;
using System.Collections;

public class Thingy : MonoBehaviour 
{
	//controls a thingy
    
    //gameobjects
	Thingys thingys;
    GameObject player;
    GAchievs achiev;

    //components
	AudioSource pickUp;
	

	void Start()
	{
		thingys = GameObject.Find("Controller").GetComponent<Thingys>();
        pickUp = GetComponent<AudioSource>();
		player = GameObject.FindGameObjectWithTag("Player");

        achiev = GameObject.Find("Controller").GetComponent<GAchievs>();
	}

	//a thingy disappears when the player collides it, a global thingy counter adds one and  a  global achiev counter adds another
    void OnTriggerEnter(Collider co)
	{		
		if(co.gameObject == player)
		{
			thingys.Add();
            pickUp.Play();
			GetComponent<BoxCollider>().enabled = false;

            achiev.CountThyngys();

			Destroy(gameObject,.2f);            
		}
	}
}
