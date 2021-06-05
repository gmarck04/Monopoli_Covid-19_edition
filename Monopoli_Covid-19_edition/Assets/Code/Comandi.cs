using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Comandi : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.F4))
        {
            string Time_file = Application.persistentDataPath + "/Time.txt"; //percorso file Time.txt
            string Money_file = Application.persistentDataPath + "/Money.txt"; //percorso file Money.txt

            if (File.Exists(Money_file)) //distruzione file se esistono
                File.Delete(Money_file);

            if (File.Exists(Time_file))
                File.Delete(Time_file);

            Debug.Log("Eliminato file leftalt+f4");
        }
        else if (Input.GetKeyDown(KeyCode.RightAlt) && Input.GetKeyDown(KeyCode.F4))
        {
            string Time_file = Application.persistentDataPath + "/Time.txt"; //percorso file Time.txt
            string Money_file = Application.persistentDataPath + "/Money.txt"; //percorso file Money.txt

            if (File.Exists(Money_file)) //distruzione file se esistono
                File.Delete(Money_file);

            if (File.Exists(Time_file))
                File.Delete(Time_file);

            Debug.Log("Eliminato file rightalt+f4");
        }
    }
}
