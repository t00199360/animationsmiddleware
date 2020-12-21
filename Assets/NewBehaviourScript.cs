using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject hand = null;
    public GameObject sword = null;
    // Start is called before the first frame update
    void Start()
    {
        hand = GameObject.Find("hand");
        sword = GameObject.Find("Sword");
    }
    
    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.name == "Sword" || collision.gameObject.name == "hand")
        //{
        //    sword.transform.parent = hand.transform;
        //}
    }
}
