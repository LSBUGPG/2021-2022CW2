using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    [SerializeField] MeshRenderer[] meshesToColour;
    [SerializeField] Color[] colours = new Color[] {Color.green, Color.blue};
    public Color[] GetColours => colours;
    [SerializeField] int colourIndexAtStart = 0;
    private void Start()
    {
        SwitchColour(colourIndexAtStart);
    }
    public void SwitchColour(int _colourIndex)
    {
        SetColour(colours[_colourIndex]);
    }
    public void SetColour(Color _color)
    {
        foreach (MeshRenderer mR in meshesToColour)
        {
            mR.material.color = _color;
        }
    }
}
