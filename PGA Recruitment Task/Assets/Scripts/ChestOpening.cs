using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Skrypt odpowiadający za otwieranie skrzynki. Na samym początku pobieram GameObject Gracza, Game Managera oraz 
    znajduję skrypt przypisany do obiektu Game Managera. Do tego pobieram referencję do skryptu odpowiadającego za
    podświetlenie skrzynki, gdyż potrzebuję znać stan zmiennej logicznej isHighlighted sprawdzającą czy gracz
    najechał myszką na skrzynkę. Obiekt Gracza jest mi potrzebny do pobrania jego pozycji a Obiekt Game Managera do
    pobrania skryptu w którym wywołuję metodę odpowiadającą za UI skrzynki, jej menu. Skrypt działa na zasadzie 
    sprawdzania odległości pomiędzy skrzynką a graczem. Jeśli dystans jest mniejszy niż określony w skrypcie jako 
    sphereRadius i ustawiony na 6 jednostek oraz zmienna isHighlighted zwraca prawdę i został naciśnięty LPM, skrzynia 
    zostaje otwarta i wywołuję metodę odpowiadającą za jej UI. Na sam koniec dorzucam prostą animację otwierania 
    i zamykania.
*/

public class ChestOpening : MonoBehaviour {
    [SerializeField] private ChestHighlight chestHighlight;
    [SerializeField] private Animator chestAnimator;
    private GameObject gameManagerGO;
    private GameManager gameManagerScript;
    private GameObject player;
    private float sphereRadius = 6f;
    private float distanceBetween = 0f;

    private bool canOpenChest() {
        if(distanceBetween < sphereRadius) return true;
        else return false;
    }

    void Start() {
        player = GameObject.Find("Player");
        gameManagerGO = GameObject.Find("Game Manager");
        gameManagerScript = gameManagerGO.GetComponent<GameManager>();
    }

    void Update() {
        distanceBetween = Vector3.Distance(player.transform.position, transform.position);
        if(canOpenChest() && chestHighlight.getIsHighlighted() && Input.GetMouseButtonDown(0)) {
            gameManagerScript.ChestOpeningUI();
        }

        if(gameManagerScript.getIsChestOpening()) {
            chestAnimator.SetBool("chestOpening", true);
        }

        if(!gameManagerScript.getIsChestOpening()) {
            chestAnimator.SetBool("chestOpening", false);
        }
    }
}
