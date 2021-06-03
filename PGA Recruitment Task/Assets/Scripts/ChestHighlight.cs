using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Skrypt odpowiadający za podświetlenie skrzynki. Pobieram oryginalne kolory skrzynki i kolor podświetlenia 
    oraz odpowiednie renderery i podczas najechania kursorem zmieniam kolor na podświetlony, a w momencie 
    odjechania kursora przywracam poprzednie kolory. Warto zaznaczyć, że skrzynka posiada dwa kolory 
    (brązowy oraz szary), dlatego żeby je zmieniać muszę się posłużyć tablicą. Do tego prywatna zmienna logiczna 
    czy skrzynka jest podświetlona oraz getter do niej, który wykorzystuję w skrypcie ChestOpening.
*/

public class ChestHighlight : MonoBehaviour {
    [SerializeField] private Material brown;
    [SerializeField] private Material gray;
    [SerializeField] private Material yellow;
    [SerializeField] private Renderer box;
    [SerializeField] private Renderer cylinder;
    [SerializeField] private Renderer lock_;
    private bool isHighlighted = false;

    public bool getIsHighlighted() { return isHighlighted; }

    private void OnMouseEnter() {
        Material[] yellowArray = new Material[] { yellow, yellow };
        box.materials = yellowArray;
        cylinder.material = yellow;
        lock_.material = yellow;
        isHighlighted = true;
    }

    private void OnMouseExit() {
        Material[] originalArray = new Material[] { brown, gray };
        box.materials = originalArray;
        cylinder.material = brown;
        lock_.material = gray;
        isHighlighted = false;
    }
}
