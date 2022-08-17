using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//creates a class with a name, colour, and choice option used for the default NPC dialogue pre-choice
[System.Serializable]
public class startingDialogue
{
    public string name, text;
    public Color colour;
    public bool hasChoice;
}

//creates a class with a name and colour used for the Date NPC dialogue
[System.Serializable]
public class correctChoice
{
    public string name, text;
    public Color colour;
}

//creates a class with a name and colour used for the Not Date NPC dialogue
[System.Serializable]
public class wrongChoice
{
    public string name, text;
    public Color colour;
}
