using UnityEngine;


public class Human : MonoBehaviour {
    float rnd = 0;
    const int lim = 100;
    public bool vulnerable;
    public bool autist;
    public bool sick;
    public int social;
    string charc_model;

    public Sprite syg_person = Resources.Load<Sprite>("sygPerson");
    public Sprite syg_svag_person = Resources.Load<Sprite>("sygSvagPerson");
    public Sprite autist_person = Resources.Load<Sprite>("Autist");
    public Sprite svag_person = Resources.Load<Sprite>("svagPerson");
    public Sprite person = Resources.Load<Sprite>("Person");

    private SpriteRenderer spriteRenderer;
    int given_sick = 20;
    int given_vulnerable = 10;
    int given_autist = 80;

    void Awake(){  
        rnd = Random.Range(0, lim);
        autist = rnd <= given_autist;

        rnd = Random.Range(0, lim);
        vulnerable = rnd <= given_vulnerable && !autist;

        rnd = Random.Range(0, lim);
        sick = rnd <= given_sick && !autist;

        social = Random.Range(0, 5);

<<<<<<< HEAD
	}
	
	// Update is called once per frame
	void Update () {

	}
=======
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (sick && vulnerable)
            spriteRenderer.sprite = syg_svag_person;
        else if (sick)
            spriteRenderer.sprite = syg_person;
        else if (vulnerable)
            spriteRenderer.sprite = svag_person;
        else if (autist)
            spriteRenderer.sprite = autist_person;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
>>>>>>> origin/master

	void Move(int p) {

	}
}
