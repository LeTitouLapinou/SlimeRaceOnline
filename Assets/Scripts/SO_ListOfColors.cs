using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_ListOfColors", menuName = "Scriptable Objects/SO_ListOfColors")]
public class SO_ListOfColors : ScriptableObject
{
    public List<Color> colors = new List<Color>();
    
}
