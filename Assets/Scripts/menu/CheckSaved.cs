using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckSaved : MonoBehaviour 
{
    //checks if the user has some progress saved

	public Button button; //continue button
	public Text text;
	

	void Start () 
    {
		//PlayerPrefs.DeleteAll();   debug
		if(PlayerPrefs.GetInt("level") > 0)
		{
			button.enabled = true;
			text.color = new Color(165f, 255f, 79f, 1f);
		}
		else
			button.enabled = false;
	}
	
}
