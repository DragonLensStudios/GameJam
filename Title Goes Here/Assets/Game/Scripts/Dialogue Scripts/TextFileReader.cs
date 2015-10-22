using System;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class TextFileReader : MonoBehaviour
{
    public TextAsset textFile;
    public string xmlstuff;
    public string[] textLines;
    public List<DialogueContainer> Dialogues;

    void Awake()
    {
        xmlstuff = textFile.text;
//        FetchDialogue();
    }

    public void FetchDialogue()
    {
        textLines = textFile.text.Split('\n');

        for (int i = 0; i < textLines.Length; i++)
        {
            if (textLines[i].Contains(":"))
            {
                var line = textLines[i].Split(':');
                if (Dialogues.Exists(x => x.Name == line[0]) == false)
                {
                    Dialogues.Add(new DialogueContainer(line[0].Trim(), new List<string>()));
                }

                foreach (var cont in Dialogues)
                {
                    if (cont.Name == line[0] && Dialogues.Exists(x => x.Name == line[0]))
                    {
                        cont.Dialogue.Add(line[1].Trim());
                    }
                }
            }
        }
    }

}
