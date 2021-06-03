using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Skrypt odpowiadający za losowe umieszczanie skrzynki oraz drzwi na mapie gry. Metoda chestSpawner jak nazwa wskazuje,
    odpowiada za losowe umieszczenie skrzynki. Ponieważ plac gry ma 30x30 jednostek wielkości i jest umieszczony na środku 
    mapy (0x0), w tej metodzie losuję dwie wartości z przedziału -13 i 13 i przypisuję je do zmiennych, w której jedna odpowiada 
    osi X a druga osi Z. Na sam koniec umieszczam skrzynkę z wylosowanych wartości funkcją Instantiate.
    Metoda doorSpawner odpowiada za losowe umieszczanie drzwi. Na samym początku muszę ustalić na której ścianie umieścić
    drzwi żeby je odpowiednio obrócić aby były zawsze skierowane przodem do gracza. W tym celu tworzę sobie tablicę 
    rotationArray z wartościami -90, 0, 90 oraz 180 odpowiadające rotacji drzwi. Następnie losuję liczbę z przedziału od 0 do 
    długości tablicy (pamiętając że Random.Range(x, y) zwraca liczbę z przedziału od x do y-1) aby wylosować indeks tablicy, 
    a potem do tej samej zmiennej przypisuję wartość indeksu. Dodatkowo losuję jedną wartość od -13 do 13 aby wylosować pozycję 
    na ścianie na której chcę umieścić drzwi. Następnie switchem w zależności od wylosowanej rotacji umieszczam funkcją
    Instantiate drzwi na odpowiednim miejscu o odpowiedniej rotacji. Obie metody wywołuję na starcie gry.
*/

public class Spawner : MonoBehaviour {
    [SerializeField] private GameObject chest;
    [SerializeField] private GameObject door;
    private int[] rotationArray = new int[] { -90, 0, 90, 180 };
    private int rotation;
    private float floorAxisX;
    private float floorAxisZ;
    private float wallAxis;

    private void chestSpawner() {
        floorAxisX = Random.Range(-13f, 13f);
        floorAxisZ = Random.Range(-13f, 13f);
        Instantiate(chest, new Vector3(floorAxisX, 0, floorAxisZ), transform.rotation);
    }

    private void doorSpawner() {
        rotation = Random.Range(0, rotationArray.Length);
        rotation = rotationArray[rotation];
        wallAxis = Random.Range(-13f, 13f);
            
        switch(rotation) {
            case -90: {
                Instantiate(door, new Vector3(-15, 0, wallAxis), Quaternion.Euler(0, -90, 0));
                break;
            }
            case 0: {
                Instantiate(door, new Vector3(wallAxis, 0, 15), Quaternion.Euler(0, 0, 0));
                break;
            }
            case 90: {
                Instantiate(door, new Vector3(15, 0, wallAxis), Quaternion.Euler(0, 90, 0)); 
                break;
            }
            case 180: {
                Instantiate(door, new Vector3(wallAxis, 0, -15), Quaternion.Euler(0, 180, 0));
                break;
            }
        }
    }

    void Start() {
        chestSpawner();
        doorSpawner();
    }
}
