using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Prosty skrypt odpowiadający za możliwość poruszania i obracania gracza. Do poruszania się wykorzystuję
    funkcję transform.Translate, do obracania funkcję transform.Rotate. Kierunek ruchu i obrotu mnożę o odpowiednią
    zmienną prędkości oraz przez Time.deltaTime.
*/

public class PlayerController : MonoBehaviour {
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 150f;

    void PlayerMovement() {
        if(Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Q)) {
            transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.E)) {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
    }
    
    void Update() {
        PlayerMovement();
    }
}
