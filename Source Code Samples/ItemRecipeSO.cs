using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Recipe", menuName ="Recipe/Create New Recipe")]
public class ItemRecipeSO : ScriptableObject
{
    public int id;
    public string recipeName;
    public Sprite icon;
    public Type type;

    public enum Type
    {
        Umbrella, Suitcase
    }
}
