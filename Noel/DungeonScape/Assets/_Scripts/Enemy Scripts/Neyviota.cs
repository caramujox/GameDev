using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neyviota : Enemy, IDamageble {
    //Variaveis
    public int Health { get; set; }
    [SerializeField]
    private GameObject _diamondPreFab;
    [SerializeField]
    private GameObject _projectilePreFab;
    private bool _canAttack = true;
    //Metodos
    public override void Initializer()
    {
        base.Initializer();
        base.health = 2;
        base.gems = 3;
        base.speed = 2;
        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();
    }

    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }
        Health--;
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = (GameObject)Instantiate(_diamondPreFab, (transform.position + new Vector3(-0.5f, 0.07f, 0)), Quaternion.identity);
            diamond.GetComponent<Diamonds>().gems = base.gems;
            Destroy(this.gameObject, 4.0f);
        }
    }

    public override void Update()
    {
        Attack();
        Movement();
    }

    public void Attack()
    {
        if (_canAttack == true)
        {
            Instantiate(_projectilePreFab, (transform.position + new Vector3(0.5f, -0.2f, 0)), Quaternion.identity);
            _canAttack = false;
            StartCoroutine(ResetCanAttack());
        }
        
    }

    IEnumerator ResetCanAttack()
    {
        yield return new WaitForSeconds(1.5f);
        _canAttack = true;
    }
}
