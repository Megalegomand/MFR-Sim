﻿using UnityEngine;
<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> origin/master

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

<<<<<<< HEAD
    public int cp = 0;
    public bool moving = false;
    List<int> path;

    public float range = 0.1f;
    public float speed = 1f;

    float mx, my;

    bool TEMP = true;

    void Awake() {
=======

    float height;
    float width;
    Camera cam;
    void Awake(){  
>>>>>>> origin/master
        rnd = Random.Range(0, lim);
        autist = rnd <= given_autist;

        rnd = Random.Range(0, lim);
        vulnerable = rnd <= given_vulnerable && !autist;

        rnd = Random.Range(0, lim);
        sick = rnd <= given_sick && !autist && !vulnerable;

        social = Random.Range(0, 5);
<<<<<<< HEAD
    }

    // Update is called once per frame
    void Update() {
        if (!moving) {
            bool bee = true;
            while (bee) {
                int num = Random.Range(0, Background.houses.Count);
                if (num != cp) {
                    bee = false;
                    Move(Background.houses[num]);
                }
            }
        }
=======
>>>>>>> origin/master

        spriteRenderer = GetComponent<SpriteRenderer>();

        //syg_person = Resources.Load<Sprite>("sygPerson");
        //syg_svag_person = Resources.Load<Sprite>("sygSvagPerson");
        //autist_person = Resources.Load<Sprite>("Autist");
        //svag_person = Resources.Load<Sprite>("svagPerson");
        //person = Resources.Load<Sprite>("Person");

<<<<<<< HEAD

        if (sick) {
            if (vulnerable) {
                spriteRenderer.sprite = syg_svag_person;
            } else {
                spriteRenderer.sprite = syg_person;
            }
        } else if (vulnerable)
=======
        if (sick)
            spriteRenderer.sprite = syg_person;
        else if (vulnerable)
>>>>>>> origin/master
            spriteRenderer.sprite = svag_person;
        else if (autist)
            spriteRenderer.sprite = autist_person;
        else
            spriteRenderer.sprite = person;

<<<<<<< HEAD
        if (moving) {
            if (path.Count == 0) {
                moving = false;
            } else {
                if (cp == path[0] && path.Count > 1) {
                    path.RemoveAt(0);
                    mx = Background.gms[path[0]].transform.position.x;
                    my = Background.gms[path[0]].transform.position.y;
                }
                if (mx > transform.position.x - range && mx < transform.position.x + range && my > transform.position.y - range && my < transform.position.y + range) {
                    path.RemoveAt(0);
                    mx = Background.gms[path[0]].transform.position.x;
                    my = Background.gms[path[0]].transform.position.y;
                }
                if (path.Count == 0) {
                    moving = false;
                }
                if (!(mx == transform.position.x && my == transform.position.y)) {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(mx, my), speed * Time.deltaTime);
                }
            }
        }
=======
        
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        rnd = Random.Range(-width/2, width/2);
        set_x(rnd);
        rnd = Random.Range(-height/2, height/2);
        set_y(rnd);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (sick && vulnerable)
            spriteRenderer.sprite = syg_svag_person;
>>>>>>> origin/master
    }

    void Start() {

    }

    void Move(int p) {
        path = Background.gps(cp, p);
        cp = p;
        moving = true;
    }

    public void infect() {
        if (!autist) {
            sick = true;
        }

<<<<<<< HEAD
        if (sick) {
            if (vulnerable) {
                spriteRenderer.sprite = syg_svag_person;
            } else {
                spriteRenderer.sprite = syg_person;
            }
        } else if (vulnerable)
            spriteRenderer.sprite = svag_person;
        else if (autist)
            spriteRenderer.sprite = autist_person;
        else
            spriteRenderer.sprite = person;
=======
	}  

    public void set_x(float x)
    {
        float dummy = transform.position.y;
        transform.position = new Vector3(x, dummy);
    }  

    public void set_y(float y)
    {
        float dummy = transform.position.x;
        transform.position = new Vector3(dummy, y);
>>>>>>> origin/master
    }
}
