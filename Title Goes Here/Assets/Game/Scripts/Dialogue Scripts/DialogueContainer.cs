using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class DialogueContainer
{
    public string Name;
    public List<string> Dialogue = new List<string>();
   // public Dictionary<string, List<string>> DialogueDictionary;

    public DialogueContainer(string _Name, List<string> _Dialogue)
    {
        Name = _Name;
        Dialogue = _Dialogue;
        //DialogueDictionary = new Dictionary<string, List<string>>();
       // DialogueDictionary.Add(Name, Dialogue);
      //  Debug.Log(DialogueDictionary.Keys.Count);
    }
}
