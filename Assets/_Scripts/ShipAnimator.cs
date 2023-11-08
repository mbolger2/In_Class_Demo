using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnimator : MonoBehaviour
{
    public Animator animator;

    public string spinParameterName;

    public void Spin()
    {
        animator.SetTrigger(spinParameterName);
    }
}
