using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Skrypt odpowiadający za otwieranie drzwi. Na samym początku pobieram GameObject Gracza, Game Managera oraz 
    znajduję skrypt przypisany do obiektu Game Managera. Do tego pobieram referencję do skryptu odpowiadającego za
    podświetlenie drzwi, gdyż potrzebuję znać stan zmiennej logicznej isHighlighted sprawdzającą czy gracz
    najechał myszką na drzwi. Obiekt Gracza jest mi potrzebny do pobrania jego pozycji a Obiekt Game Managera do
    pobrania skryptu w którym wywołuję metodę odpowiadającą za UI drzwi, jego menu. Skrypt działa na zasadzie 
    sprawdzania odległości pomiędzy drzwiami a graczem. Jeśli dystans jest mniejszy niż określony w skrypcie jako 
    sphereRadius i ustawiony na 4 jednostki oraz zmienna isHighlighted zwraca prawdę i został naciśnięty LPM, drzwi 
    zostają otwarte i wywołuję metodę odpowiadającą za jego UI.
*/

public class DoorOpening : MonoBehaviour {
    [SerializeField] private DoorHighlight doorHighlight;
    private GameObject gameManagerGO;
    private GameManager gameManagerScript;
    private GameObject player;
    private float sphereRadius = 4f;
    private float distanceBetween = 0f;

    private bool canOpenDoor() {
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
        if(canOpenDoor() && doorHighlight.getIsHighlighted() && Input.GetMouseButtonDown(0)) {
            gameManagerScript.DoorOpeningUI();
        }
    }
}
