using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
    Animator anim;
    static Menu myins;
    public static Menu Instance { get { return myins; } }
    public GameObject leaderboard;
    // Use this for initialization
	void Start () {
        myins = this;
        anim = GetComponent<Animator>();
	}
    public void setLeaderboard() {
        leaderboard.active = true;
    }
    // Update is called once per frame
    float Times = 0;
    void Update () {
        Times +=1;
        if (Input.GetMouseButtonDown(0)&&leaderboard.active) {
            leaderboard.active = false;
        }
        if (Times == 10) {
            SoundManager.Instance.PlaySoundBgMenu();
        }
	}
    public void Setting() {
        anim.SetInteger("screen", 1);
    }
    public void Back() {
        
        if (anim.GetInteger("screen") > 0) {
            anim.SetInteger("screen", anim.GetInteger("screen") - 1);
        }
        
    }
    public void credit()
    {
        anim.SetInteger("screen", 2);
    }
  
}
