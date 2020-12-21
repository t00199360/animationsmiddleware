using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class IKControl : MonoBehaviour
{

    protected Animator animator;

    public bool ikActive = false;
    public Transform rightHandObj = null;
    public Transform lookObj = null;

    public GameObject hand = null;
    public GameObject sword = null;
    public GameObject hat = null;
    public GameObject head = null;

    void Start()
    {

        animator = GetComponent<Animator>();
        hand = GameObject.Find("hand");
        sword = GameObject.Find("Sword");
        head = GameObject.Find("B-head");
        hat = Instantiate(Resources.Load("PoliceCap")as GameObject,head.transform);
        hat.transform.rotation = Quaternion.Euler(0,110,0);         //basis for code is there but the rotations etc are incorrect
        hat.transform.localScale = new Vector3(0.7f,0.7f,0.7f);

    }

    //a callback for calculating IK
    void OnAnimatorIK()
    {
        if (animator)
        {

            //if the IK is active, set the position and rotation directly to the goal. 
            if (ikActive)
            {

                // Set the look target position, if one has been assigned
                if (lookObj != null)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookObj.position);
                }

                // Set the right hand target position and rotation, if one has been assigned
                if (rightHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                }

            }

            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                animator.SetLookAtWeight(0);
            }
        }
    }
    private void Update()
    {
        Debug.Log("The Distance between the objects is" + Vector3.Distance(sword.transform.position, hand.transform.position));
        if (Vector3.Distance(sword.transform.position,hand.transform.position)<1)
        {
            Debug.Log("The Distance between the objects is less than 1");           //attaches the sword to the hand, not even close to being perfect but its ok
            sword.transform.parent = hand.transform;
        }
    }
       
}