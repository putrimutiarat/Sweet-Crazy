using UnityEngine;
using System.Collections;

public class ForSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void PlayEffectSound() {
        SoundManager.Instance.playEffectMuncul();
    }
}
