using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    //Variaveis Serializadas

    // Variaveis Uteis:
    private Animator _animator; //player animator
    //private Animator _swordAnimator;
	// Use this for initialization
	void Start () {
        _animator = GetComponentInChildren<Animator>();
        //_swordAnimator = transform.GetChild(1).GetComponent<Animator>();
	}

    public void Walk(float move)
    {
        _animator.SetFloat("Move", Mathf.Abs(move));
    }

    public void Run(bool running)
    {
        _animator.SetBool("Running", running);
        
    }

    public void Jump(bool jumping)
    {
        _animator.SetBool("Jumping", jumping);
    }

    public void AttackAnim()
    {
        _animator.SetTrigger("Attack");
       // _swordAnimator.SetTrigger("swordAnimation");
    }
   
    public void Death()
    {
        _animator.SetTrigger("Death");
    }
}
