using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RandomNumberIndex : MonoBehaviour {
    public int adjFileSize = 4945;
    public string adjFileName = "Assets/TextFiles/names.txt";
    

    public string generateRandomName()
    {
        FileInfo adjFile = new FileInfo(adjFileName);
        StreamReader adjReader = adjFile.OpenText();
        int adjIndex = Random.Range(0, adjFileSize-2);
        //var lines = File.ReadAllLines(adjFileName);
        string name;
        for ( int i = 0; i <= adjIndex; i++ )
        {
            adjReader.ReadLine();
        }
        name = adjReader.ReadLine();

        string adj = adjReader.ReadLine();
        adjReader.Close();

        return name;
    }

    

    //26 elements (starting from 1)
    
}
