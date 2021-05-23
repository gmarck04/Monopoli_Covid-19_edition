using UnityEngine;
using System.IO;

public class Pedine_scelta : MonoBehaviour
{
    void Start()
    {
        string Pedina_file = Application.persistentDataPath + "/Pedina.txt"; //percorso file Pedina.txt

        if (!File.Exists(Pedina_file)) //creazione file se non esiste
        {
            Debug.Log("File delle pedine non trovato, ora lo creo");
            FileStream sw = File.Create(Pedina_file);
            sw.Close();
            Debug.Log("Creato il file delle pedine");
        }

    }

    public void Mascherina_pulsante() //scittura su file se scelto pulsante mascherina
    {
        string Pedina_file = Application.persistentDataPath + "/Pedina.txt";
        StreamWriter sw = new StreamWriter(Pedina_file);
        sw.WriteLine("Mascherina");
        sw.Close();
    }

    public void Siringa_pulsante() //scittura su file se scelto pulsante siringa
    {
        string Pedina_file = Application.persistentDataPath + "/Pedina.txt";
        StreamWriter sw = new StreamWriter(Pedina_file);
        sw.WriteLine("Siringa");
        sw.Close();
    }

    public void Vaccino_pulsante() //scittura su file se scelto pulsante vaccino
    {
        string Pedina_file = Application.persistentDataPath + "/Pedina.txt";
        StreamWriter sw = new StreamWriter(Pedina_file);
        sw.WriteLine("Vaccino");
        sw.Close();
    }

    public void Amuchina_pulsante() //scittura su file se scelto pulsante amucchina
    {
        string Pedina_file = Application.persistentDataPath + "/Pedina.txt";
        StreamWriter sw = new StreamWriter(Pedina_file);
        sw.WriteLine("Amuchina");
        sw.Close();
    }    
}



/*
public GameObject Mascherina;
    public GameObject Siringa;
    public GameObject Vaccino;
    public GameObject Amuchina;

    public void Mascherina_pulsante()
    {
        Mascherina.SetActive(true);
    }

    public void Siringa_pulsante()
    {
        Siringa.SetActive(true);
    }

    public void Vaccino_pulsante()
    {
        Vaccino.SetActive(true);
    }

    public void Amuchina_pulsante()
    {
        Amuchina.SetActive(true);
    }
 */
