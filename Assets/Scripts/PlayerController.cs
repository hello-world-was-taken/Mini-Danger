using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _myCharacter;
    private float horiMove;
    private bool facingRight;
    private RaycastHit2D _playerRaycast;
    public Transform groundCheckerPosition;
    private int _coinCounter;
    public Collider2D coinCollider;
    private AudioSource _playerAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        _myCharacter = GetComponent<Rigidbody2D>();
        facingRight = true;
        _coinCounter = 0;
        _playerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        checkIfGrounded();
        ChangeFacingDirection();
    }

    void ChangeFacingDirection() {
        if (facingRight && (horiMove < 0)) {
            facingRight = false;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        }
        else if (!facingRight && (horiMove > 0)) {
            facingRight = true;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        }
    }

    void Move() {
        horiMove = Input.GetAxis("Horizontal");
        _myCharacter.velocity = new Vector2(horiMove * 5, _myCharacter.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space)) {
            _myCharacter.velocity = new Vector2(_myCharacter.velocity.x, 5);
        }
    }

    void checkIfGrounded() {
        _playerRaycast = Physics2D.Raycast(groundCheckerPosition.position, -Vector2.up, 4f);
        if(_playerRaycast.collider == true) {
            Move();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
       if(other.gameObject.CompareTag("Coin")) {
           _playerAudioSource.Play();
           _coinCounter++;
           Debug.Log(_coinCounter);
       }
    }
}
