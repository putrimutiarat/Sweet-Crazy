using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {
    public Font myFont,BestScore;
    int score=0,time=0;
    public GameObject SharingScene;
    
    public int waktushare;
    CHFacebook share;
    static GameOverManager myins;
    public static GameOverManager Instance { get { return myins; } }
    // Use this for initialization
	void Start () {
        myins = this;
        share = new CHFacebook();
        waktushare = 0;
        SoundManager.Instance.PlaySoundLose();
    }
    void SiapSharing() {
        if (SharingScene.active && Input.GetMouseButtonDown(0) || SharingScene.active && Input.GetKeyDown(KeyCode.Escape) )
        {
            Debug.Log(this.transform.name);
            waktushare = 0;
        }

        if (waktushare == 1 && !SharingScene.active) {
            
            SharingScene.active = true;
        }
        if (waktushare == 0 )
        {
            
            SharingScene.active = false;
        }
    }
	// Update is called once per frame
	void Update () {
        SiapSharing();
        time++;
        if (time > 160 && score <Manager.Instance.MyScore&&time%5==0) {
            score++;
            SoundManager.Instance.PlaySoundCoin();
            myFont.SetString(" : " + score +"");
        }
        BestScore.SetString(" : " + PlayerPrefs.GetInt("score") + "");

    }
}
