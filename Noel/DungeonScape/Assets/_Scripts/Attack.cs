using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    private bool _canDamage = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Hitou o " + other.name);
        
        IDamageble hitTarget = other.GetComponent<IDamageble>();
        if (hitTarget != null)
        {
            if (_canDamage == true)
            {
                hitTarget.Damage();
                _canDamage = false;
                StartCoroutine(ResetCanDamage());
            }
            
        }
    }

    IEnumerator ResetCanDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;       

    }

//
}
