using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManagement : MonoBehaviour
{
    public int tempMax; // en seconde
    public bool platformAND;
    public GameObject plateau;

    GameObject SceneController;
    float delta;
    bool runGame;
    List<GameObject> pieces = new List<GameObject>();
    int voidPieceIndex;

    // Start is called before the first frame update
    void Start()
    {
        runGame = false;
        DontDestroyOnLoad(gameObject);
        InitializeBestScore();

    }

    // Update is called once per frame
    void Update()
    {
        // Si une partie est lancer, actualise le timer à chaque update
        if (runGame)
        {
            SceneController.GetComponent<SceneGameManagement>().MAJOverviewTimer(timerGame());

            //ICI LA GESTION DU TACTILE
            //EndTurn();
        }

    }

    /*
     * Charge le meilleur score enregistré dans le systéme lors de l'ouverture de l'application
     * 
     * Entrée : Null
     * 
     * Sortie : Null
     */
    public void InitializeBestScore()
    {
        // Charge le meilleur score
        int bestScoreTemp = GetComponentInParent<IOSystem>().LoadBestScore();
        GetComponentInParent<GestionScore>().MAJBestScore(bestScoreTemp);
        GameObject.Find("SceneController").GetComponent<DisplayTitleMenu>().MAJOverviewBestScore();
    }

    /*
     * Initialise la scéne de jeu
     * Inisialise une nouvelle partie,
     * Initialise l'affichage de l'IHM
     * 
     * Entrée : Null
     * 
     * Sortie : Null
     */
    public void InitializeGameScene()
    {
        // On commence par recuperer le controller de l'affichage de la scene
        SceneController = GameObject.Find("SceneGameController");

        foreach(Transform child in plateau.transform)
        {
            if(child.gameObject.name != "Background")
            {
                pieces.Add(child.gameObject);
            }    
        }
        voidPieceIndex = 4;
        Debug.Log(taquinOK());

        InitializeNewGame();

        Debug.Log("Test init scene");
    }

    /*
     * Met fin au run et suprime le lien avec sceneController
     * On supprime l'objet car un nouveau gameManager sera créer sur la scéne Home
     * 
     * Entrée : Null
     * 
     * Sortie : Null
     */
    public void exitScene()
    {
        runGame = false;
        SceneController = null;
        Destroy(gameObject);

    }

    /*
     * Inisialise une nouvelle partie,
     * Met le score à 0, mélange le taquin, initialise le chronométre à 3min 
     * 
     * Entrée : Null
     * 
     * Sortie : Null
     */
    public void InitializeNewGame()
    {
        // On initialise le score à 0
        GetComponentInParent<GestionScore>().currentScore = 0;
        SceneController.GetComponent<SceneGameManagement>().MAJOverviewScore(0);
        // On initialise le timer selon le temps voulue
        delta = 0.0f;
        SceneController.GetComponent<SceneGameManagement>().MAJOverviewTimer(timerGame());
        //On tire une solution soluble du Taquin

        //TODO

        // On declanche la mise à jour de l'affichage du timer à chaque update
        runGame = true;

        Debug.Log("Test init game");
    }

    /*
     * Initialize la position des piéces sur le taquin
     * La solution doit être soluble
     * 
     * Entrée : Null
     * 
     * Sortie : Null
     */
    void InitializeTaquin()
    {
        // TODO
    }

    /*
     * Calcule le temp restant et l'envoie à l'affichage
     * Si le temps restant à atteind 0, alors déclanche la fin de la partie
     * 
     * Entrée : Null
     * 
     * Sortie : string time : le temps restant à afficher pour la partie
     */
    string timerGame()
    {
        delta += Time.deltaTime;
        float  timeRes = tempMax - delta;
        if(timeRes <= 0.0f)
        {
            EndGame(false);
            return "00min 00,0sec";
        }
        else
        {
            int m = 0;
            float res = timeRes / 60;
            for(; m < res; m++) { }
            return "" + (m - 1) + "min " + ((res - (m - 1)) * 60) + "sec";
        }
    }

    /*
     * En fin de partie
     * Determine si le score et devenue le meilleur score.
     * Si oui, déclanche le pop up pour enregistrer le nom et sauvegarde le tous
     * Bloque aussi la possibilité de bouger les piéces
     * 
     * Entrée : bool victoire : détermine si la fin de la partie et une victoire ou non
     * 
     * Sortie : Null
     */
    void EndGame(bool victoire)
    {
        runGame = false;

        //Si c'est une victoire on regarde si c'est un nouveau meilleur score
        if (victoire)
        {
            //Si nouveau meilleur score
            if (GetComponentInParent<GestionScore>().TcheckIfBestNewBest())
            {
                // TODO : afficher pop up enregistrement new score
                GetComponentInParent<IOSystem>().SaveBestScore(GetComponentInParent<GestionScore>().bestScore);
            }
            else
            {
                // TODO : afficher pop up victoire
            }
        }
        else
        {
            // TODO : afficher pop up défaite
        }

        Debug.Log("End game");
    }

    /*
     * A chaque coup du joueur, incrémente le nombre de coup
     * vérifie si le taquin est terminé
     * Si oui, déclanche le fin du jeu
     * Sinon, met à jour les piéces amovibles
     * 
     * Entrée : Null
     * 
     * Sortie : Null
     */
    void EndTurn()
    {
        // on incremente le score
        GetComponentInParent<GestionScore>().currentScore++;
        SceneController.GetComponent<SceneGameManagement>().MAJOverviewScore(GetComponentInParent<GestionScore>().currentScore);

        // vérifie si la solution est faite
        if (taquinOK())
        {
            EndGame(true);
        }

        Debug.Log("End turn");

    }

    /*
     * Vérifie que toutes les pieces du taquin sont à la bonne place ou non
     * 
     * Entrée : Null
     * 
     * Sortie : bool rep : Valide ou non la bonne plce des pieces du taquin
     */
    bool taquinOK()
    {
        for(int i = 0; i < pieces.Count; i++)
        {
            if(pieces[i].name != "" + (i + 1))
            {
                return false;
            }
        }
        return true;
    }
}
