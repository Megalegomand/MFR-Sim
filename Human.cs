﻿using UnityEngine;


public class Human : MonoBehaviour {
    float rnd = 0;
    const int lim = 100;
    public bool vulnerable;
    public bool autist;
    public bool sick;
    public int social;
    string charc_model;

    public Sprite syg_person;
    public Sprite syg_svag_person;
    public Sprite autist_person;
    public Sprite svag_person;
    public Sprite person;

    private SpriteRenderer spriteRenderer;
    int given_sick = 20;
    int given_vulnerable = 10;
    int given_autist = 20;

    void Start(){  
        rnd = Random.Range(0, lim);
        autist = rnd <= given_autist;

        rnd = Random.Range(0, lim);
        vulnerable = rnd <= given_vulnerable && !autist;

        rnd = Random.Range(0, lim);
        sick = rnd <= given_sick && !autist && !vulnerable;

        social = Random.Range(0, 5);

        spriteRenderer = GetComponent<SpriteRenderer>();

        syg_person = Resources.Load<Sprite>("sygPerson");
        syg_svag_person = Resources.Load<Sprite>("sygSvagPerson");
        autist_person = Resources.Load<Sprite>("Autist");
        svag_person = Resources.Load<Sprite>("svagPerson");
        person = Resources.Load<Sprite>("Person");

        
        if (sick)
            spriteRenderer.sprite = syg_person;
        else if (vulnerable)
            spriteRenderer.sprite = svag_person;
        else if (autist)
            spriteRenderer.sprite = autist_person;
        else
            spriteRenderer.sprite = person;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

	void Move(int p) {

	}
}
