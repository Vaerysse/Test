using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneGameManagement : MonoBehaviour
{
    public Button resetGameButton;
    public Button quitPartyButton;
    public Text timer;
    public Text score;
    public GameObject gameManager;
    public GameObject andGame;
    public GameObject IOSGame;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");

        //Si platform android
        if (gameManager.GetComponent<GameManagement>().platformAND)
        {
            IOSGame.SetActive(false);
            gameManager.GetComponent<GameManagement>().plateau = andGame;
        }
        else //Sinon IOS
        {
            andGame.SetActive(false);
            gameManager.GetComponent<GameManagement>().plateau = IOSGame;
        }

        // Initialisation de la sc�ne de jeu
        gameManager.GetComponent<GameManagement>().InitializeGameScene();
        // Associe l'event de r�initialisation de la partie du gameManager au boutton reset
        resetGameButton.GetComponent<Button>().onClick.AddListener(gameManager.GetComponent<GameManagement>().InitializeNewGame);
        quitPartyButton.GetComponent<Button>().onClick.AddListener(gameManager.GetComponent<GameManagement>().exitScene);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Mise � jour de l'affichage du score
     * 
     * Entr�e : int score : le score � afficher
     * 
     * Sortie : Null
     */
    public void MAJOverviewScore(int currentScore)
    {
        score.text = "Score actuelle : " + currentScore;
    }

    /*
     * Mise � jour de l'affichage du minuteur
     * 
     * Entr�e : string : le temps restant � afficher
     * 
     * Sortie : Null
     */
    public void MAJOverviewTimer(string currentTime)
    {

        timer.text = currentTime;
    }
}
