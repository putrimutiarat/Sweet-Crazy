using UnityEngine;
using System.Collections;

public class HandleInput : MonoBehaviour
{
    Collider2D coll;
    Sharing share;
    public Manager myManager;
    Vector3 mySize, pushSize;
  
    // Use this for initialization
    void Start()
    {
     
        
        coll = GetComponent<Collider2D>();
        mySize = this.transform.localScale;
        pushSize = new Vector3(mySize.x - 0.1f, mySize.y - 0.1f);
        share = new Sharing();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = mySize;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if (coll && coll.OverlapPoint(pos))
            {
                this.transform.localScale = pushSize;
                InputLogic();
            }
        }
    }
    void InputLogic() {
        SoundManager.Instance.PlaySoundClick();
        switch (this.name) {
            case "Yes":
                myManager.Benar();
                break;
            case "No":
                myManager.Salah();
                break;
            case "TombolPlay":
                Application.LoadLevel("GamePlays");
                break;
            case "Reload":
                if (GameOverManager.Instance.waktushare == 0)
                {
                    Application.LoadLevel("GamePlays");
                }
                break;
            case "Home":
                if (GameOverManager.Instance.waktushare == 0) {

                
                Application.LoadLevel("menu");
                }
                break;
            case "PalingTinggi":
                if (GameOverManager.Instance.waktushare == 0)
                {
                    GameOverManager.Instance.waktushare = 1;
                }
                break;
            case "fb":
                GameOverManager.Instance.waktushare = 0;
                share.ShareFacebook("http://pixelclothe.com/Redirect", "http://pixelclothe.com/Redirect/Monster.png", "Try me on Windows Phone!! XD", "My Best Score is " + PlayerPrefs.GetInt("score")+" how about you dude??", " SAo ", "https://facebook.com/");
                break;
            case "twitter":
                GameOverManager.Instance.waktushare = 0;
                share.ShareTwitter("Try me my score " + PlayerPrefs.GetInt("score") + " how about you dude??", "https://play.google.com/store/apps/details?id=com.raioncomm.sweetcrazy", "@raioncommunity", "ini lang");
                break;
            case "Pengaturan":
                Menu.Instance.Setting();
                break;
            case "back":
                Menu.Instance.Back();
                break;
            case "About":
                Menu.Instance.credit();
                break;
            case "go":
                AwalMenu.Instance.SaveName();
                break;
            case "ScoreTerbaik":
                Menu.Instance.setLeaderboard();
                break;

        }
    }

}
