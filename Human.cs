using UnityEngine;

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


    float height;
    float width;
    Camera cam;
    void Awake(){  
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

        
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        rnd = Random.Range(0, width);
        set_x(rnd);
        rnd = Random.Range(0, height);
        set_y(rnd);
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    
    void Start()
    {

    }

	void Move(int p) {

	}
    
    float get_x()
    {
        return transform.position.x;
    }

    public void set_x(float x)
    {
        float dummy = transform.position.y;
        transform.position = new Vector3(x, dummy);
    }

    float get_y()
    {
        return transform.position.y;
    }

    public void set_y(float y)
    {
        float dummy = transform.position.x;
        transform.position = new Vector3(dummy, y);
    }
}
