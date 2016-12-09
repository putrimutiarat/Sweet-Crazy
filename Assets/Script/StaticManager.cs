using UnityEngine;
using System.Collections;

public class StaticManager : MonoBehaviour {
    static StaticManager myInstance;
    public static bool soundOn=true;
    
    public static StaticManager Instance { get { return myInstance; } }
    public float speed;

    public bool enemyCanMove;
    // Use this for initialization
	void Start () {
        myInstance = this;
	}
	
         
}
