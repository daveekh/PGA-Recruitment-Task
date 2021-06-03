using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/*
    Skrypt odpowiadający za wszelkie UI, wynik oraz ponowne ładowanie gry. Bardzo dużo metod od przycisków w menu które
    aktywują i dezaktywują odpowiednie okienka. Z innych rzeczy - z racji tego że najlepszym wynikiem ma być jak najkrótszy 
    czas, na samym starcie do zmiennej bestScore przypisuję float.MaxValue i tą zmienną potem porównuję z każdym nowym wynikiem
    sprawdzając czy wynik jest mniejszy od najlepszego. Jako że na samym starcie gry wyświetlam największy wynik oraz 
    przycisk 'Start', w pierwszej iteracji gry w okienku 'Best' wyświetlałoby mi się właśnie float.MaxValue, co byłoby mało
    eleganckie. Problem ten obszedłem zliczając w statycznej zmiennej liczbę iteracji gry - i gdy gra jest odpalana po raz 
    pierwszy (gameLoops == 0), zwyczajnie ukrywam element UI odpowiadający za wyświetlanie najlepszego wyniku. Sama zmienna 
    bestScore również jest statyczna, aby była zachowywana w kolejnych iteracjach gry. Sprawę klucza załatwiłem zwykłą zmienną 
    logiczną (playerHasKey) - gracz posiada klucz, bądź nie. Ponieważ mowa jest o jednym elemencie, uznałem to rozwiązanie za
    przystępniejsze zamiast bawić się w tablicę zawartości skrzynki i tablicę ekwipunku gracza. Zmienną logiczną isChestOpening 
    i jej getter wykorzystuję w skrypcie ChestOpening do animacji. Dodatkowo dorzuciłem wyjście z gry klawiszem Escape. 
*/

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject chestMenu;
    [SerializeField] private GameObject chestInventory;
    [SerializeField] private GameObject keyMenu;
    [SerializeField] private GameObject doorMenu;
    [SerializeField] private GameObject youNeedAKeyMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject keyInChest;
    [SerializeField] private GameObject timerGUI;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI yourScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreStartText;
    [SerializeField] private TextMeshProUGUI bestScoreGameOverText;
    [SerializeField] private GameObject bestScoreStartTextGO;
    private bool playerHasKey = false;
    private float score = 0f;
    private static float bestScore = float.MaxValue;
    private static int gameLoops = 0;
    private bool isChestOpening = false;

    public bool getIsChestOpening() { return isChestOpening; }

    //buttons
    public void StartGameButton() {
        startMenu.SetActive(false);
        timerGUI.SetActive(true);
        spawner.SetActive(true);
        Time.timeScale = 1;
    }

    public void ChestMenuYesButton() {
        chestMenu.SetActive(false);
        chestInventory.SetActive(true);
        isChestOpening = true;
    }

    public void ChestMenuNoButton() {
        chestMenu.SetActive(false);
        isChestOpening = false;
    }

    public void ChestInventoryKeyButton() {
        keyMenu.SetActive(true);
        chestInventory.SetActive(false);
    }

    public void ChestInventoryExitButton() {
        chestInventory.SetActive(false);
        isChestOpening = false;
    }

    public void KeyMenuYesButton() {
        playerHasKey = true;
        keyInChest.SetActive(false);
        keyMenu.SetActive(false);
        chestInventory.SetActive(false);
        isChestOpening = false;
    }

    public void KeyMenuNoButton() {
        keyMenu.SetActive(false);
        chestInventory.SetActive(true);
    }

    public void YouNeedAKeyMenuButtonOK() {
        youNeedAKeyMenu.SetActive(false);
    }

    public void DoorMenuYesButton() {

        if(bestScore > score) {
            bestScore = score;
        }

        doorMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void DoorMenuNoButton() {
        doorMenu.SetActive(false);
    }

    public void TryAgainButton() {
        gameLoops++;
        SceneManager.LoadScene(0);
    }

    //UI logic
    public void ChestOpeningUI() {
        if(!chestInventory.activeSelf && !keyMenu.activeSelf) {
            chestMenu.SetActive(true);
        }
    }

    public void DoorOpeningUI() {
        if(playerHasKey) {
            doorMenu.SetActive(true);
        }
        else {
            youNeedAKeyMenu.SetActive(true);
        }
    }

    void Start() {
        Time.timeScale = 0;
        startMenu.SetActive(true);
    }

    void Update() {
        score += Time.deltaTime;
        timerText.text = score.ToString("F2");
        yourScoreText.text = timerText.text;
        bestScoreStartText.text = bestScore.ToString("F2");
        bestScoreGameOverText.text = bestScore.ToString("F2");

        if(gameLoops == 0) {
            bestScoreStartTextGO.SetActive(false);
        }
        else {
            bestScoreStartTextGO.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
