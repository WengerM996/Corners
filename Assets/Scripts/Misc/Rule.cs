using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rule", menuName = "Preferences/Rule")]
public class Rule : ScriptableObject
{
    [SerializeField] private List<Direction.Path> _paths;

    public List<Direction.Path> Paths => _paths;
}
