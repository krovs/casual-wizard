using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GPlayServices : MonoBehaviour 
{

    //game controller image for logged in and logged out states
    public Sprite logged;
    public Sprite notlogged;

    //vars
    bool singedin;

    Image buttonImage;

	void Start () 
    {
        PlayGamesPlatform.Activate();

        buttonImage = GameObject.Find("GoogleGameServices").GetComponent<Image>();

        //if success, change the icon
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                buttonImage.sprite = logged;
                singedin = true;
            }
        });
	}
    //toggle sign in and sign out
    public void SingInGplay()
    {

        if (!singedin)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    buttonImage.sprite = logged;
                    singedin = true;
                }
            });
        }
        else
        {
            PlayGamesPlatform.Instance.SignOut();
            buttonImage.sprite = notlogged;
            singedin = false;
        }
    }

    //shows the achievement window
    public void ShowAchievs()
    {
        Social.ShowAchievementsUI();
    }
}
