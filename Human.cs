using UnityEngine;
using System.Collections;

public class Human : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float rnd = Random.Range(0,100);
        bool vulnerable = rnd <= 20;
        bool vaccinated = rnd > 20 && rnd >= 80;
        bool sick = rnd > 80;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
