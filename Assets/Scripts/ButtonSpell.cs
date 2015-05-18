using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ButtonSpell : MonoBehaviour 
{

    //class that controls the spells buttons
	
	//components
	Button button;
	
	public enum Bspells{LightningBolt, FireBall, Heal};
	public Bspells bspell;
	
	//gameobjects
	GameObject player;
	PlayerSpell[] pspells;
	PlayerSpell pspell;	
	
	
	void Awake()
	{
		button = GetComponent<Button>();
		player = GameObject.FindGameObjectWithTag("Player");
		pspells = player.GetComponents<PlayerSpell>();		
		
        //select the right spell
		foreach(PlayerSpell ps in pspells){
			if ((int)ps.spell == (int)bspell)
				pspell = ps;			
		}	
		
		button.interactable = true;
		button.onClick.AddListener(() => {CastSpell();});
	}
	
	
	void Update()
	{		
		if(pspell.canCast)
			button.interactable = true;
		else
			button.interactable = false;		
	}
	
	
	void CastSpell()
	{		
		if(button.interactable)
		{			
			button.interactable = false;
			pspell.Cast();			
		}
	}
}