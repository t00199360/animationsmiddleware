using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    public Animator animator;
    public float InputX;
    public float InputY;

    // Start is called before the first frame update
    void Start()
    {
        //Get animator
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputY = Input.GetAxis("Vertical");
        animator.SetFloat("InputY", InputY);
    }
}
