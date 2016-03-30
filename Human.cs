using UnityEngine;
using System.Collections;

public class Human : MonoBehaviour {
    float rnd = 0;
    const int lim = 100;
    public bool vulnerable;
    public bool vaccinated;
    public bool sick;

    public Human(){
        rnd = Random.Range(0, lim);
        vulnerable = rnd <= (lim - 1 / 5 * lim);
        vaccinated = rnd > (lim - 1 / 5 * lim) && rnd >= (lim - 4 / 5 * lim);
        sick = rnd > (lim - 4 / 5 * lim);
    }
    // Use this for initialization
    void Start() {
        Debug.Log("Vulnerable = ");
        Debug.Log(vulnerable);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
