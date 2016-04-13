using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House : MonoBehaviour {

	List<GameObject> humans = new List<GameObject>();
	[Tooltip("Chance to get out")]
	public int ctgo = 500;
	public int infectChance = 100;
	public int maxPerson = 10;
	public int distWeight = 10;

    // Jacobs shit
    float rnd = 0;
    float height;
    float width;
    Camera cam;
    public Sprite hus;
    private SpriteRenderer spriteRenderer;
    // Use this for initialization
    public void Start ()
    {
		
	}
	
    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hus = Resources.Load<Sprite>("Hus#1");
        spriteRenderer.sprite = hus;

        
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        rnd = Random.Range(-width / 2, width / 2);
        set_x(rnd);
        rnd = Random.Range(-height / 2, height / 2);
        set_y(rnd);
        
    }

	// Update is called once per frame
	public void Update () {
	
	}

	void FixedUpdate() {
		if (Random.Range (0, ctgo) < 1) {
			humans[(int)(Random.Range (0,humans.Count-1))].SetActive(true);

		}
	}

	public void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.GetComponent<Human> () != null) {
			col.gameObject.SetActive (false);
			humans.Add(col.gameObject);
		}
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
    }
}
