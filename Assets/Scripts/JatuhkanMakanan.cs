using UnityEngine;
using System.Collections;

public class JatuhkanMakanan : MonoBehaviour {
    int time;
    public GameObject makanan;

	// Use this for initialization
	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time++;
        if (time % 60 == 0)
        {
            Instantiate(makanan, new Vector3(Random.Range(-2.43f, 2.35f), 8.97f, 0), Quaternion.identity);
        }
	}
}
