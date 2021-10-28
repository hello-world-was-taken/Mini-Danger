using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D _myPatrol;
    private bool _isFacingRight;
    private RaycastHit2D _myRaycast;
    public Transform groundDetection;
    public float speed;
    public Collider2D platformCollider;
    void Start()
    {
        _myPatrol = GetComponent<Rigidbody2D>();
        _isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        _myRaycast = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);
        if(transform.rotation.y == 0) {
            _myPatrol.velocity = new Vector2(1, 0);
        }
        //transform.Translate(Vector2.right * Time.deltaTime);
        checkRayCollider();
    }

    void checkRayCollider() {
        if(_myRaycast.collider != platformCollider) {
            if(_isFacingRight == true) {
                transform.rotation = Quaternion.Euler(0, -180, 0);
                _isFacingRight = false;
                _myPatrol.velocity = new Vector2(-1, 0);
                //Debug.Log("It is running!");
            } else {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                _isFacingRight = true;
                _myPatrol.velocity = new Vector2(1, 0);
            }
        }else {
            if(_isFacingRight == true) {
                //transform.rotation = Quaternion.Euler(0, -180, 0);
                //_isFacingRight = false;
                _myPatrol.velocity = new Vector2((1 * speed), 0);
                //Debug.Log("It is running!");
            } else {
                //transform.rotation = Quaternion.Euler(0, 0, 0);
                //_isFacingRight = true;
                _myPatrol.velocity = new Vector2((-1 * speed), 0);
            }
        }
        
    }
}
