using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Collider2D _coinCollider;
    public int collectedCoin;
    // Start is called before the first frame update
    void Start()
    {
        collectedCoin = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
             collectedCoin++;
             Destroy(gameObject);
         }
    }
}
