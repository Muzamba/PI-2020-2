using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    //ID
    public int player;
    

    //Controls
    private KeyCode _up;
    private KeyCode _down;
    private KeyCode _left;
    private KeyCode _right;

    private KeyCode _shoot;
    
    private KeyCode _upS;
    private KeyCode _downS;
    private KeyCode _leftS;
    private KeyCode _rightS;

    //Movement
    private Rigidbody2D _rigi;
    public float speed;
    private Vector2 _direction;
    private bool _jumping;
    public bool Grounded { get; set; }
    public float forceJump;
    public float startJump;
    public float airTime;
    private float _acTime;

    //Momentum
    public float acel;
    private float _veloInst;
    public float acelTeto;
    
    //Shoot
    public GameObject shot;
    public float delta;
    public float shootForce;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigi = this.GetComponent<Rigidbody2D>();
        switch (player)
        {
            case 0:
                _up = KeyCode.W;
                _down = KeyCode.S;
                _left = KeyCode.A;
                _right = KeyCode.D;

                _shoot = KeyCode.Space;
                
                _upS = KeyCode.T;
                _downS = KeyCode.G;
                _leftS = KeyCode.F;
                _rightS = KeyCode.H;
                
                break;
            
            case 1:
                _up = KeyCode.I;
                _down = KeyCode.K;
                _left = KeyCode.J;
                _right = KeyCode.L;

                _shoot = KeyCode.RightControl;
                
                _upS = KeyCode.UpArrow;
                _downS = KeyCode.DownArrow;
                _leftS = KeyCode.LeftArrow;
                _rightS = KeyCode.RightArrow;
                
                break;
        }

        Grounded = false;

    }

    // Update is called once per frame
    void Update()
    {
        // Shoot
        if (Input.GetKeyDown(_shoot))
        {
            
        }else if (Input.GetKeyUp(_shoot))
        {
            var localShot = ArrowDirection();
            var go = GameObject.Instantiate(shot, transform.position + Vector3.right * delta, localShot);
            go.GetComponent<Rigidbody2D>().AddForce((localShot * Vector2.down) * shootForce);
            var aux = gameObject.GetComponentsInChildren<Collider2D>();
            foreach (Collider2D colisor in aux)
            {
                Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), colisor);
            }
        }
        
        //Movement
        if (Input.GetKeyDown(_left))
        {
            _direction.x--;
        }
        else if(Input.GetKeyUp(_left))
        {
            _direction.x++;
        }
        
        if (Input.GetKeyDown(_right))
        {
            _direction.x++;
        }
        else if(Input.GetKeyUp(_right))
        {
            _direction.x--;
        }
        
        if (Input.GetKeyDown(_up) && Grounded)
        {
            _jumping = true;
            _rigi.AddForce(new Vector2(0, startJump));
        }
        else if(Input.GetKeyUp(_up))
        {
            _jumping = false;
            _acTime = airTime;
        }
        
        if (Input.GetKeyDown(_down))
        {
            _direction.y--;
        }
        else if(Input.GetKeyUp(_down))
        {
            _direction.y++;
        }
        
    }
    private void FixedUpdate()
    {
        
        _rigi. velocity = new Vector2(_direction.x * speed * Time.fixedDeltaTime,_rigi.velocity.y);
        if (_jumping && (_acTime > 0) )
        {
            _rigi.velocity += new Vector2(0,forceJump * Time.fixedDeltaTime);
            _acTime -= Time.fixedDeltaTime;
        }
        GetMomentum();
        _rigi.velocity += new Vector2(_veloInst * Time.fixedDeltaTime,0);
        //Improve Momentum based in all velocity 

        
    }

    private Quaternion ArrowDirection()
    {
        
        Quaternion resultado = Quaternion.Euler(0,0,90);
        if (Input.GetKey(_upS))
        {
            if (Input.GetKey(_rightS))
            {
                resultado = Quaternion.Euler(0,0,135);
            } else if (Input.GetKey(_leftS))
            {
                resultado = Quaternion.Euler(0, 0, 225);
            }
            else
            {
                resultado = Quaternion.Euler(0, 0, 180);
            }
        }else if (Input.GetKey(_downS))
        {
            if (Input.GetKey(_rightS))
            {
                resultado = Quaternion.Euler(0,0,45);
            } else if (Input.GetKey(_leftS))
            {
                resultado = Quaternion.Euler(0, 0, 315);
            }
            else
            {
                resultado = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            if (Input.GetKey(_rightS))
            {
                resultado = Quaternion.Euler(0,0,90);
            } else if (Input.GetKey(_leftS))
            {
                resultado = Quaternion.Euler(0, 0, 270);
            }
        }


        return resultado;
    }

    private void GetMomentum()
    {
        if (_direction.x < 0)
        {
            _veloInst -= acel;
            if (Math.Abs(_veloInst) > acelTeto)
            {
                _veloInst += acel;
            }
        }
        else if(_direction.x > 0)
        {
            _veloInst += acel;
            if (Math.Abs(_veloInst) > acelTeto)
            {
                _veloInst -= acel;
            }
        }
        else
        {
            if (Math.Abs(_veloInst) < 5)
            {
                _veloInst = 0;
            }
            else if (_veloInst > 0)
            {
                _veloInst -= acel;
            }
            else
            {
                _veloInst += acel;
            }
        }
    } 
}
