using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    public AudioClip Sfx_muncul, Sfx_Starting, Sfx_lose, Sfx_coin, Sfx_click;
    public AudioClip BgSoundMenu,BgSoundGamePlay;
    static SoundManager myins;
    public static SoundManager Instance { get { return myins; } }
	// Use this for initialization
	void Start () {
        myins = this;
        if (PlayerPrefs.GetInt ("sound") == 0) {
			StaticManager.soundOn = false;
		} else {
			StaticManager.soundOn = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    public void PlaySoundClick()
    {
        print("Click");
        if (StaticManager.soundOn)
        {
            AudioSource.PlayClipAtPoint(Sfx_click, transform.position);
        }
    }
    public void PlaySoundCoin()
    {
        if (StaticManager.soundOn)
        {
            AudioSource.PlayClipAtPoint(Sfx_coin, transform.position);
        }
    }
    public void PlaySoundStarting()
    {
        if (StaticManager.soundOn)
        {
            AudioSource.PlayClipAtPoint(Sfx_Starting, transform.position);
        }
    }
    public void PlaySoundLose()
    {
        if (StaticManager.soundOn)
        {
            AudioSource.PlayClipAtPoint(Sfx_lose, transform.position);
        }
    }
    public void PlaySoundBgMenu()
    {
        if (StaticManager.soundOn)
        {
            AudioSource.PlayClipAtPoint(BgSoundMenu, transform.position);
        }
    }
    public void PlaySoundBgGamePlay() {
        if (StaticManager.soundOn)
        {
            AudioSource.PlayClipAtPoint(BgSoundGamePlay, transform.position);
        }
    }
    public void playEffectMuncul(){
        if (StaticManager.soundOn) {
            AudioSource.PlayClipAtPoint(Sfx_muncul, transform.position);
        }
    }
}
