using UnityEngine;
using System.Collections;

public class AutoDismiss : MonoBehaviour 
{

	//dismiss the level0 and level1 tips
    
    public float dismissTime = 5;
	Animator anim;
	float timer = 0f;
	bool timerStart = false;
	
	
	void Start()
	{
		anim = GetComponent<Animator>();		
	}
	
	void Update () 
	{
		if(timerStart)
			timer += Time.deltaTime;
		if(GetComponent<CanvasGroup>().alpha == 1)
			timerStart = true;
		if(timer >= dismissTime)
			anim.SetTrigger("tipOut");
		
	}
}

