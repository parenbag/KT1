using XNode;
using UnityEngine;

[CreateNodeMenu("Reigns/Card")]
public class CardNode : Node
{
    [Input] public CardNode input; 

    [TextArea]
    public string description;

    public string leftChoice;
    public string rightChoice;

    [Output] public CardNode left;
    [Output] public CardNode right;
}