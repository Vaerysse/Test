using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class IOSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* 
     * Charge le meilleur score enregistré à ce jour.
     * Crée un fichier de sauvegarde vierge si pas de fichier de score présent.
     * 
     * Entrée : Null
     * 
     * Sortie : List<string> listScore : contient un nom et un score
     */

    public List<string> LoadBestScore()
    {
        List<string> listScore = new List<string>();

        // On essaye d'ouvrire le fichier de score.
        try
        {
            StreamReader reader = new StreamReader(Application.dataPath + "/data/score.csv");

            bool endOfFile = false;
            while (!endOfFile)
            {
                string data_string = reader.ReadLine();
                if (data_string == null)
                {
                    endOfFile = true;
                    break;
                }
                else
                {
                    var dataline = data_string.Split(";");
                    foreach (string data in dataline)
                    {
                        listScore.Add(data);
                    }
                }
            }

            return listScore;
        }
        catch // Sinon on en crée un vierge et retourn le fichier créer
        {
            listScore.Add("Unknow");
            listScore.Add("0");

            try
            {
                StreamWriter writer = new StreamWriter(Application.dataPath + "/data/score.csv");
                writer.WriteLine("Unknow;0");
                writer.Close();
            }
            catch
            {
                Debug.Log("Probléme lors de la création du fichier score!");
            }

            return listScore;
        }

    }

    /*
     * Permet de sauvegarder le score dans un fichier.
     * 
     * Entrée : List<string> listScore : le nom et score à sauvegarder
     * 
     * Sortie : Null
     */
    public void SaveBestScore(List<string> listScore)
    {
        // On sauvegarde le score dans un fichier.
        try
        {
            StreamWriter writer = new StreamWriter(Application.dataPath + "/data/score.csv");
            string saveLine = "";
            foreach (string data in listScore)
            {
                saveLine += data;
                if(data != listScore[listScore.Count - 1])
                {
                    saveLine += ";";
                }
            }
            writer.WriteLine(saveLine);
            writer.Close();
        }
        catch
        {
            Debug.Log("Probléme lors de la sauvegarde du fichier score!");
        }

    }

}
