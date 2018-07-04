using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class VariablesSingleton {

    public static VariablesSingleton _instance = new VariablesSingleton(); // instancia de singleton


   

    
    
    
    List<Sprite> _imagesCorrectes= new List<Sprite>(); // lista de imatges Correctes utilitzada per l'scene de score i les seves pertinents funcions.

    public void setImagesCorrectes(Sprite image)
    {
        _imagesCorrectes.Add(image);
    }

    public List<Sprite> getImageCorrectes()
    {
        return _imagesCorrectes;
    }




    List<Sprite> _imagesIncorrectes = new List<Sprite>(); // Llista de imatges Incorrectes utilitzada per l'scene de score i les seves pertinents funcions.

    public void setImagesIncorrectes(Sprite image)
    {
        _imagesIncorrectes.Add(image);
    }

    public List<Sprite> getImagesIncorrectes()
    {
        return _imagesIncorrectes;
    }


    public void CleanList(List<Sprite> lista) // netejar una llista (correctes/incorrectes o altra)
    {
        lista.Clear();
    }




    ///////////////////////////////////////




    int totalGirsAFer = 4; // Girs Totals que haurà de fer per nivell-escenari //////

    int girsCorrectesMinims; // total de girs a fer per passar al següent nivell.

    public void CalculDeGirs()
    {
        string Dificultat = VariablesSingleton._instance.GetDificultat();
        int GirsPerDificultat = 0;

        switch (Dificultat)
        {
            case "Facil":

                GirsPerDificultat = 0;
                break;


            case "Mig":

                GirsPerDificultat = Random.Range(2, 5);
                break;


            case "Dificil":

                GirsPerDificultat = Random.Range(4, 7);
                break;
        }

        totalGirsAFer = 4 + GirsPerDificultat;

    }

    public int getGirsAfer()
    {
        return totalGirsAFer;
    }


    public void setGirsMinimsAfer()
    {
        girsCorrectesMinims = totalGirsAFer / 2;
    }

    public int getGirsMinimsAfer()
    {
        return girsCorrectesMinims;
    }
   


    /////// CONTROL DE JUEGO Y CONTROLES

    bool _controlesActivos;

    public void SetControlesActivos(bool estado)
    {
        _controlesActivos = estado;
    }

    public bool GetControlesActivos()
    {
        return _controlesActivos;
    }

   


    bool _enablePausa= true;// si la pausa es pot clicar o  no.

    public void SetEnablePausa(bool estado)
    {
        _enablePausa = estado;
    }

    public bool GetEnablePausa()
    {
        return _enablePausa;
    }

    bool _stopGame = false;

    public void SetPausaGame(bool estado)
    {
        _stopGame = estado;
    }

    public bool GetPausaGame()
    {
        return _stopGame;
    }





    //bool _activaTempsDecisio = false; // activar-desactivar el temps (cronòmetre) de cada gir

    //public void activacioDeTemps (bool estado)
    //{
    //    _activaTempsDecisio = estado;
    //}






    //float _tempsReaccio = 0; // és la variable genèrica del temps dels girs
    //List<string> _llitsaTempsDecisions = new List<string>(); // llista a on guardem els cadascun dels temps de cada gir

    //public void tempsDeReaccio(int temps)
    //{
    //    _tempsReaccio = temps;
    //    _llitsaTempsDecisions.Add(temps.ToString());
    //}


   
    //////////////////// COSAS PARA CARGAR IMAGEN SEGUN LVL


    string _tematicaDeNivell= "NivellCiutat"; // La Farem servir per saber a quina tematica ens trobem i poguem saber quines imatges carregar.

    public void SetTematicaNivell(string tematica)
    {
        _tematicaDeNivell = tematica;
    }

    public string GetTematicaNivell()
    {
        return _tematicaDeNivell;
    }

    
   
    
    string _dificultat = "Facil";

    public void SetDificultat(string difficulty)
    {
        _dificultat = difficulty;
    }

    public string GetDificultat()
    {
        return _dificultat;
    }

    ////////////


    int _nivellActual = 0; // ens indica quin nivell de la saga esta el personatge
    
    public void SetNivellActual(int lvl)
    {
        _nivellActual = lvl;
    }
    public int GetNivellActual()
    {
        return _nivellActual;
    }



    int _nivellMaximAconseguit = 1; // ens indica fins quin nivell-escenari podem jugar ja que hem superat els anteriors (hem desbloquejat fins el nivell-escenari tal)
    public int getNivellMaximAconseguit()
    {
        return _nivellMaximAconseguit;
    }
    public void setNivellMaximAconseguit(int lvl)
    {
        _nivellMaximAconseguit = lvl;
    }


    //int intentsNivell = 1; // intents que hem jugat cada nivell-escenari


    public int _puntuacioMaxima = 0; // ens indica la puntuació màxima aconseguida per cada nivell-escenari

    public int GetPuntutacioMax()
    {
        return _puntuacioMaxima;
    }

    public void SetPuntuacioMax(int punts)
    {
        _puntuacioMaxima = punts;
    }



    // MONEDES DE JOC

    public int _nutCoin = 0; // Monedes totals (per la botiga)

    public void setNutCoins(int monedes)
    {
        _nutCoin += monedes;
    }

    public int getNutCoins()
    {
        return _nutCoin;
    }


    //// Dades Usuari
    //string userID = "usuariViodStudio";
    //string password = "testtest";
    //string userName = "Carles";
    //string email = "viod@gmail.com";
}
