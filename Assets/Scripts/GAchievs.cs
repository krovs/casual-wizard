using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GAchievs : MonoBehaviour 
{

	//google play games achievements
    
    public static int enemies; 
    public static int oldpeeps;
    public static int thingys;
    

    public void CountEnemies()
    {
        enemies += 1;

        if (enemies == 10)
        {
            Social.ReportProgress("id", 100.0f, (bool success) => { });
        }
    }

    public void CountOld()
    {
        oldpeeps += 1;

        if (oldpeeps == 5)
        {
            Social.ReportProgress("id", 100.0f, (bool success) => { });
        }
    }

    public void CountThyngys()
    {
        thingys += 1;

        if (thingys == 3)
        {
            Social.ReportProgress("id", 100.0f, (bool success) => { });
        }
    }

    public void level0()
    {
        Social.ReportProgress("id", 100.0f, (bool success) => { });
    }

    public void level1()
    {
        Social.ReportProgress("id", 100.0f, (bool success) => { });
    }

    public void level2()
    {
        Social.ReportProgress("id", 100.0f, (bool success) => { });
    }

    public void level3()
    {
        Social.ReportProgress("id", 100.0f, (bool success) => { });
    }
}
