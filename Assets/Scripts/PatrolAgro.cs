using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAgro : MonoBehaviour
{
    public Collider2D playerCollider;
    public Transform playerCheckerRight;
    public Transform playerCheckerLeft;
    public Transform patrolTransfrom;
    public float patrolSpeed;
    private RaycastHit2D _patrolRaycastRight;
    private RaycastHit2D _patrolRaycastLeft;
    private Rigidbody2D _myPatrol;
    // Start is called before the first frame update
    void Start()
    {
        _myPatrol = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CastTheRays();        
    }

    void CastTheRays() {
        _patrolRaycastRight = Physics2D.Raycast(playerCheckerRight.position, Vector2.right, 3f);
        _patrolRaycastLeft = Physics2D.Raycast(playerCheckerLeft.position, Vector2.left, 3f);
        if(_patrolRaycastRight.collider == playerCollider) {
            //patrolTransfrom.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            GetComponent<SpriteRenderer>().flipX = false;
            _myPatrol.velocity = new Vector2(patrolSpeed, 0);
        }else if(_patrolRaycastLeft.collider == playerCollider) {
            //patrolTransfrom.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
            GetComponent<SpriteRenderer>().flipX = true;
            _myPatrol.velocity = new Vector2(-patrolSpeed, 0);
        }else {
            _myPatrol.velocity = new Vector2(0, 0);
        }
    }
}
