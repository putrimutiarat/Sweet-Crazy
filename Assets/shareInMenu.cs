using UnityEngine;
using System.Collections;

public class shareInMenu : MonoBehaviour {
    public GameObject shareTwitter;
    Sharing share;

	// Use this for initialization
	void Start () {
        share = new Sharing();
	}
	
	// Update is called once per frame
	void Update () {
        if (shareTwitter.active && Input.GetMouseButtonDown(0))
        {
            Debug.Log(this.transform.name);
            shareTwitter.active = false;
        }
	}

    void OnMouseDown()
    {
        share.ShareTwitter("Try me my score " + PlayerPrefs.GetInt("score") + " how about you dude??", "https://play.google.com/store/apps/details?id=com.raioncomm.sweetcrazy", "@raioncommunity", "ini lang");
    }
}
