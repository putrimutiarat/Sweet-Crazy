using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {
   public float time;//Set waktu
    public Animator anim;//Mengontrol animator object
    public Sprite[] mySprite;
    public bool ReadyToKlik=false;
    int ran;
   public int myNumber;
    void Awake() {
        myNumber = Random.Range(0, mySprite.Length);
        
    }

    // Use this for initialization
	void Start () {
     
        time = 0;
        anim = GetComponent<Animator>();
        if (Manager.Instance.MyScore > 10&& Manager.Instance.MyScore%10==0) {
            anim.speed += 2;
        }  
        GetComponent<SpriteRenderer>().sprite = mySprite[myNumber];
        this.name = mySprite[myNumber].name;
	}
    public void SetAngka(int angka) {
        myNumber = angka;
        GetComponent<SpriteRenderer>().sprite = mySprite[myNumber];
    }
	// Update is called once per frame
	void Update () {
        if (Manager.Instance.ReadyPlay) {
            time += Time.deltaTime;
        }
        if (time > Manager.Instance.Time||Manager.Instance.Pencet) {
            Pindah();
        }
	}
    public void siap() {
        ReadyToKlik = true;
    }
    public void Pindah() {

        anim.SetInteger("tahap", 1);
        
    }

    public void Destroying() {
        Destroy(this.gameObject);
    }
}
