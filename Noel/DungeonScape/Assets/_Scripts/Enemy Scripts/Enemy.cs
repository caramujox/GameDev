using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer spriteRend;
    protected bool isHit = false;
    protected Player player;
    protected bool isDead = false;

    public virtual void Initializer()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    
        anim = GetComponentInChildren<Animator>();
        spriteRend = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        Initializer();
    }

    public virtual void Update()
    {
        Movement();
    }

    public virtual void Movement()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("inCombat") == false) //Checa se esta em IDLE, se estiver, não faz nada
        {
            return;
        }
        else
        {                                                             //se não estiver, prossegue com a animacao e movimentacao
            if (isDead == false)
            {

                // variaveispara o acesso utilizadas durante o codigo: 
                Vector3 direction = player.transform.position - transform.localPosition;
                float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);

                //
                float step = speed * Time.deltaTime;

                if (currentTarget == pointA.position)
                {
                    //spriteRend.flipX = true;
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    // spriteRend.flipX = false;
                    transform.localScale = new Vector3(1,1,1);
                }

                //


                if (transform.position == pointA.position)
                {
                    currentTarget = pointB.position;
                    // _spriteRend.flipX = false;
                    anim.SetTrigger("Idle");

                }
                else if (transform.position == pointB.position)
                {
                    currentTarget = pointA.position;
                    //_spriteRend.flipX = true;
                    anim.SetTrigger("Idle");
                }

                if (isHit == false)
                {
                    transform.position = Vector3.MoveTowards(transform.position, currentTarget, step);
                }
                else if (isHit == true)
                {
                    if (direction.x < 0)
                    {
                        //face right    
                        //spriteRend.flipX = true;
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else if (direction.x > 0)
                    {
                        transform.localScale = new Vector3(1,1,1);                        
                        //spriteRend.flipX = false;
                    }
                }

                if (distance > 2.0f)
                {
                    isHit = false;
                    anim.SetBool("inCombat", false);
                }


            }
        }
    }

 //
}
