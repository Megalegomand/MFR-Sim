using UnityEngine;
using System.Collections;

public class Human : MonoBehaviour {
    float rnd = 0;
    const int lim = 100;
    public bool vulnerable;
    public bool vaccinated;
    public bool sick;
    public int social;

    public Human(int given_sick, int given_vulnerable, int given_vaccinated){
        rnd = Random.Range(0, lim);
        vulnerable = rnd <= given_vulnerable;
        rnd = Random.Range(0, lim);
        vaccinated = rnd <= given_vaccinated;
        rnd = Random.Range(0, lim);
        sick = rnd <= given_sick;

        social = Random.Range(0, 5);
        
    }
    // Use this for initialization
    void Start() {

	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
