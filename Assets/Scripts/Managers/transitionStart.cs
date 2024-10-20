using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transitionStart : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        animator.SetTrigger("transit");
    }

    // Update is called once per frame
    void Update()
    {
        animator.ResetTrigger("transit");
    }
}
