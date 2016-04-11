using UnityEngine;
using System.Collections;


public class Spawner : MonoBehaviour
{

    public int wallah_hus;
    public int wallah_human;

    // Use this for initialization
    void Start()
    {
        make_bitches("Human", wallah_human);
        make_bitches("House", wallah_hus);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void make_bitches(string bitches, int wallah)
    {
        GameObject obj_dummy;

        for (int iii = 0; iii < wallah; ++iii)
        {
            obj_dummy = new GameObject(bitches + iii);
            obj_dummy.AddComponent<SpriteRenderer>();
            obj_dummy.AddComponent(System.Type.GetType(bitches));
        }
    }
}
