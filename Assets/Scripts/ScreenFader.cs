using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour 
{
	//a simple fader for screen transitions

	//gameobjects
	Image img;
	Animator anim;
	
	void Awake()
	{
		anim = transform.GetChild(0).GetComponent<Animator>();
		img = transform.GetChild(0).GetComponent<Image>();		
		
		FadeToClear();
	}	

    //fade the screen from black
	public void FadeToClear()
	{
		StartCoroutine("FadeIn");		
	}
	//enable a black image and starts the animation, then disable the image
	IEnumerator FadeIn()
	{
		img.enabled = true;
		anim.SetTrigger("fadeIn");
		yield return new WaitForSeconds(2f);
		img.enabled = false;
	}
	
    //fade the screen to black
	public void FadeToBlack()
	{
		StartCoroutine("FadeOut");		
	}
	
	IEnumerator FadeOut()
	{
		img.enabled = true;
		anim.SetTrigger("fadeOut");
		yield return new WaitForSeconds(2f);
		
	}	
	
}
