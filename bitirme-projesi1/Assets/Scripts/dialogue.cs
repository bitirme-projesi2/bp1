using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class dialogue
{
    public string name;
    public string path;
    [TextArea(2,5)]
    public string[] sentences;

    public void createDialogue()
    {
    
        try
        {
           
            using (var sr = new StreamReader(path))
            {
                string dialogue =sr.ReadToEnd();
                sentences = dialogue.Split(';');
            }
        }
        catch (IOException e)
        {
            Debug.Log("The file could not be read:");
            Debug.LogError(e.Message);
        }
    }

}
