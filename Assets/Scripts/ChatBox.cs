using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChatBox : MonoBehaviour 
{

    //chatbox used by npcs

	Animator anim;
	Text npcName;
	Text npcDialog;
	Button dismissButton;
	AudioSource types;
	
	void Awake()
	{
		anim = GetComponent<Animator>();
		npcName = transform.GetChild(0).GetComponent<Text>();
		npcDialog = transform.GetChild(1).GetComponent<Text>();
		dismissButton = transform.GetChild(2).GetComponent<Button>();
		types = GetComponent<AudioSource>();
	}
	
	//show chat with name and text given
    public void ShowChat(string npc_Name, string npc_Dialog, bool isStatic)
	{
		anim.SetBool("Talking", true);
		npcName.text = npc_Name;
        StartCoroutine("TypeDialog", npc_Dialog);
	}
	
    //hide chat
	public void HideChat()
	{
		anim.SetBool("Talking", false);
        ClearChat();	
	}
	
    //write into an existent chat
	public void WriteChat(string npc_Dialog)
	{
		StopCoroutine("TypeDialog");
		StartCoroutine("TypeDialog", npc_Dialog);
	}
	
    //clear an existent chat
	public void ClearChat()
	{
		StopCoroutine("TypeDialog");
		npcDialog.text = " ";
	}
	
    //hide the dismiss button on a chat
	public void NoDismiss(bool o)
	{
		if(o)
			dismissButton.enabled = false;
		else
			dismissButton.enabled = true;
	}
	
    //type a dialog into a chat with a typewriter style
	IEnumerator TypeDialog(string npc_Dialog)
	{
		for(int i = 0; i <= npc_Dialog.Length - 1; i++)
		{
			npcDialog.text += npc_Dialog[i];
			types.Play();
			yield return new WaitForSeconds(.07f);			
		}	
	}
	
	
}

