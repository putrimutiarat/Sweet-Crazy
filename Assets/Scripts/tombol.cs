using UnityEngine;
using System.Collections;

public class tombol : MonoBehaviour {
    public GameObject TopUser,tombolOn,tombolOff;
    public static bool isSoundOn;
    public GameObject mySound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (TopUser.active&&Input.GetMouseButtonDown(0)) {
            TopUser.active = false;
        }
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            mySound.active = false;
            tombolOff.active = true;
            tombolOn.active = false;
        }
        else {
            tombolOff.active = false;
            tombolOn.active = true;
            mySound.active = true;
        
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            Application.Quit();
        }

	}

	public void PlayGame()
	{
		Application.LoadLevel ("GamePlays");
	}
    public void SetTopUser() {
       
        TopUser.active = true;
    }

    public void soundOn()
    {
        PlayerPrefs.SetInt("sound", 1);
        isSoundOn = true; mySound.active = true;
        print("SOund On");
    }

    public void SoundOff()
    {
        PlayerPrefs.SetInt("sound", 0);
        isSoundOn = false;
    }
}
