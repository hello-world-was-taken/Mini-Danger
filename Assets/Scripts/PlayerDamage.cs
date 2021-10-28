using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private int _health = 10;
    private Collider2D _playerCollider;
    public GameObject bloodSplash;
    // Start is called before the first frame update
    void Start()
    {
        _playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // private void OnTriggerEnter2D(Collider2D other) {
    //    if(other.gameObject.CompareTag("Patrols")) {
    //         _health--;
    //         if(_health <= 0) {
    //             Instantiate(bloodSplash, transform.position, Quaternion.identity);
    //             Destroy(gameObject);
    //         }
            
    //     } 
    // }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Patrols")) {
            _health--;
            if(_health <= 0) {
                Instantiate(bloodSplash, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            
        }
    }
}
