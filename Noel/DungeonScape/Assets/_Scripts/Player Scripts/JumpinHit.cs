using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpinHit : MonoBehaviour {
    [SerializeField]
    private LayerMask _enemyLayer;
    private bool _canDamage = true;
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 12);
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
        Player player = this.GetComponent<Player>();
        if (hitInfo.collider != null && player.isGrounded() == false)
        {
            Debug.Log(hitInfo.collider);
            IDamageble hitTarget = hitInfo.collider.GetComponent<IDamageble>();
            if (hitTarget != null)
            {
                Debug.Log(hitTarget);
                if (_canDamage == true)
                {
                    hitTarget.Damage();
                    _canDamage = false;
                    player._rigidBody.velocity = new Vector2(5.0f, 5.0f);
                    StartCoroutine(ResetCanDamage());
                    ;
                }

            }
        }
    }

    IEnumerator ResetCanDamage()
    {
        yield return new WaitForSeconds(2.0f);
        _canDamage = true;       

    }
   

    //
}
