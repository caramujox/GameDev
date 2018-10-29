using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageble
{
    //Variaveis Serializadas:
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _jumpForce = 3.0f;
    //[SerializeField]
    //private bool _grounded;
    [SerializeField]
    private LayerMask _groundLayer;
    [SerializeField]
    private LayerMask _enemyLayer;
    [SerializeField]
    private float _aceler = 2.0f;
    //[SerializeField]
    //private float _reflexo = 2.0f;
    [SerializeField]
    public int _diamonds = 0;

    //Variaveis Uteis:
    public Rigidbody2D _rigidBody;
    private bool _resetJumpNeeded = false;
    private PlayerAnimation _playerAnimation;
    //private SpriteRenderer _spriteRend;
    private SpriteRenderer _swordSpriteRend;
    private GameObject _hitBox;
    private bool isDead = false;

    //Variaveis de Implementação
    public int Health { get; set; }


    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        //_spriteRend = GetComponentInChildren<SpriteRenderer>();
        // _hitBox = GetComponentInChildren<BoxCollider2D>();
        _swordSpriteRend = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Health = 4;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
        Debug.Log(isGrounded());
        
    }

    void Movement()
    { 
        if (isDead == true)
        {
            _rigidBody.velocity = new Vector2(0, 0);
            return;
        }
        else
        {
            //Definições de movimento
            //Pega o valor de input horizontal (A e D)
            //float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal"); //Input.GetAxisRaw("Horizontal")
            float horizontalInput = Input.GetAxisRaw("Horizontal");
        //_grounded = isGrounded();

            // checa se o valor é menor que zero (TRUE = faz o flip do sprite pra esquerda. FALSE = desativa o flip)
            if (horizontalInput < 0)
            {
                //_spriteRend.flipX = false;
                transform.localScale = new Vector3(1, 1, 1);
                _swordSpriteRend.flipX = false;
                _swordSpriteRend.flipY = false;
                Vector3 newPose = _swordSpriteRend.transform.localPosition;
                newPose.x = -0.11f;
                _swordSpriteRend.transform.localPosition = newPose;
            }
            else if (horizontalInput > 0)
            {
                //_spriteRend.flipX = true;
                transform.localScale = new Vector3(-1, 1, 1);
                _swordSpriteRend.flipX = true;
                _swordSpriteRend.flipY = true;
                Vector3 newPose = _swordSpriteRend.transform.localPosition;
                newPose.x = 0.42f;
                _swordSpriteRend.transform.localPosition = newPose;
            }

            //Lógica de Jump (se o metodo is Grounded retornar TRUE && o botão SPACE for apertado, faz o salto.)
            if ((isGrounded() == true && (Input.GetKeyDown(KeyCode.Space)) || (isGrounded() == true && CrossPlatformInputManager.GetButtonDown("B_Button"))))
            {
                Debug.Log("Jump!");
                _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
                StartCoroutine(ResetJumpNeededCoroutine()); //Rotina para resetar o salto (Evita doublejumps)
                _playerAnimation.Jump(true);
            }

            //Definiçoes basicas de movimento       
            _rigidBody.velocity = new Vector2(horizontalInput * _speed, _rigidBody.velocity.y);
            _playerAnimation.Walk(horizontalInput);


            if (Input.GetKey(KeyCode.LeftShift) && (horizontalInput != 0))
            {
                _rigidBody.velocity = new Vector2(horizontalInput * _speed * _aceler, _rigidBody.velocity.y);
                _playerAnimation.Run(true);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) || (horizontalInput == 0))
            {
                _rigidBody.velocity = new Vector2(horizontalInput * _speed, _rigidBody.velocity.y);
                _playerAnimation.Run(false);
            }
        }
    }

    //metodo que checa se esta em contato com o chão
    public bool isGrounded()
    {
        //faz um raycast2d para baixo para ver se encontra algum colider na Layer de Ground
        //IMPORTANTE: a parametro "_groundLayer.value" retorna o numero da layer do CHÃO, por tanto não tera colisão com inimigos
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _groundLayer.value);
        //Debug.Log(hitInfo.collider);
        //Debug.Log(_groundLayer.value);
        //Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if (hitInfo.collider != null)
        {
            if (_resetJumpNeeded == false) //caso eu esteja no chão.
            {
                _playerAnimation.Jump(false);
                return true;
            }
        }
        return false;
    }

    void Attack()
    {
        
        if (isGrounded() == true && CrossPlatformInputManager.GetButtonDown("A_Button") || isGrounded() && Input.GetMouseButtonDown(0))
        {
            // Debug.Log(isGrounded());                 
            _playerAnimation.AttackAnim();
        }          
    }
    //IEnumerator para controle de salto. Só é possivel chamar a rotina de pulo 0.1 segundo depois de ter chamado a anterior.
    IEnumerator ResetJumpNeededCoroutine()
    {
        _resetJumpNeeded = true;
        yield return new WaitForSeconds(0.1f);
        _resetJumpNeeded = false;
    }

    public void Damage()
    {
        if (isDead)
        {
            return;
        }
        else
        {
            Health--;
            UIManager.Instance.UpdateLives(Health);
            if (Health < 1)
            {
                isDead = true;
                _playerAnimation.Death();
            }
        }
    }

    public void AddGems(int amount)
    {
        _diamonds += amount;
        UIManager.Instance.UpdateGemCount(_diamonds);
    }


    //
}
