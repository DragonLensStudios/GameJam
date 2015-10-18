using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public Text DialogueText;
    public int Players_Story_Position;

    [TextArea(3, 10)] 
    public List<string> StoryText;

    public void Update()
    {
        if (DialogueText.text != StoryText[Players_Story_Position])
        {
            DialogueText.text = StoryText[Players_Story_Position];
        }
    }

    public void NextText()
    {
        if (Players_Story_Position + 1 < StoryText.Count)
        {
            Players_Story_Position++;
        }
    }

    public void PrevText()
    {
        if (Players_Story_Position - 1 >= 0)
        {
            Players_Story_Position--;
        }
    }

}
