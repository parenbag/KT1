using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ReignsGame : MonoBehaviour
{
    public CardGraph graph;
    public CardNode currentNode;

    public TMP_Text descriptionText;
    public TMP_Text leftText;
    public TMP_Text rightText;

    private Stack<CardNode> history = new Stack<CardNode>();

    void Start()
    {
        currentNode = graph.nodes[0] as CardNode;
        ShowNode();
    }

    public void ChooseLeft()
    {
        history.Push(currentNode);

        var port = currentNode.GetOutputPort("left");

        if (port.Connection != null)
            currentNode = port.Connection.node as CardNode;

        ShowNode();
    }

    public void ChooseRight()
    {
        history.Push(currentNode);

        var port = currentNode.GetOutputPort("right");

        if (port.Connection != null)
            currentNode = port.Connection.node as CardNode;

        ShowNode();
    }

    public void Undo()
    {
        if (history.Count > 0)
        {
            currentNode = history.Pop();
            ShowNode();
        }
    }

    void ShowNode()
    {
        descriptionText.text = currentNode.description;
        leftText.text = currentNode.leftChoice;
        rightText.text = currentNode.rightChoice;
    }
}