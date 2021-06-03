using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Skrypt odpowiadający za podświetlenie drzwi. Pobieram oryginalne kolory drzwi i kolor podświetlenia 
    oraz odpowiednie renderery i podczas najechania kursorem zmieniam kolor na podświetlony, a w momencie 
    odjechania kursora przywracam poprzednie kolory. Do tego prywatna zmienna logiczna czy drzwi są podświetlone
    oraz getter do niej, który wykorzystuję w skrypcie DoorOpening.
*/

public class DoorHighlight : MonoBehaviour {
    [SerializeField] private Material brown;
    [SerializeField] private Material gray;
    [SerializeField] private Material yellow;
    [SerializeField] private Renderer door;
    [SerializeField] private Renderer handle;
    private bool isHighlighted = false;

    public bool getIsHighlighted() { return isHighlighted; }

    private void OnMouseEnter() {
        door.material = yellow;
        handle.material = yellow;
        isHighlighted = true;
    }

    private void OnMouseExit() {
        door.material = brown;
        handle.material = gray;
        isHighlighted = false;
    }
}
