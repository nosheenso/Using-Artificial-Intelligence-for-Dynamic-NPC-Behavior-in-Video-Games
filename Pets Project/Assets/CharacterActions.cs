using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class CharacterActions : MonoBehaviour
{
    public string actionsFileName; // Set in the Inspector (ZagActions.txt or ZiggyActions.txt)
    private List<string> actions = new List<string>();

    void Start()
    {
        LoadActionsFromFile();
        PerformRandomAction(); // Perform an action on start
    }

    void LoadActionsFromFile()
    {
        string filePath = Path.Combine(Application.dataPath, actionsFileName);

        if (File.Exists(filePath))
        {
            actions.AddRange(File.ReadAllLines(filePath));
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }

    void PerformRandomAction()
    {
        if (actions.Count > 0)
        {
            string chosenAction = actions[Random.Range(0, actions.Count)];
            ExecuteAction(chosenAction);
        }
        else
        {
            Debug.LogWarning("No actions loaded for " + gameObject.name);
        }
    }

    void ExecuteAction(string actionString)
    {
        string[] parts = actionString.Split(':');
        string action = parts[0].Trim();
        string comment = parts.Length > 1 ? parts[1].Trim() : "";

        Debug.Log(gameObject.name + " is performing: " + action);

        // Add your logic to perform the action and trigger animations based on the action string
        // You'll need to adapt this based on your game's mechanics and animation setup.

        if (action.Contains("Sleep"))
        {
            MoveTo("couch"); // Replace with your movement logic
            Debug.Log(comment);
        }
        else if (action.Contains("Eat"))
        {
            MoveTo("bowl"); // Replace with your movement logic
            Debug.Log(comment);
        }
        else if (action.Contains("Play"))
        {
            MoveTo("ball"); // Replace with your movement logic
            Debug.Log(comment);
        }
        else if (action.Contains("Hide"))
        {
            MoveTo("hide spot"); // Replace with your movement logic
            Debug.Log(comment);
        }
        else if (action.Contains("Talk"))
        {
            Debug.Log(comment);
        }
        else if (action.Contains("Give Gift"))
        {
            MoveTo("gift spot"); // Replace with your movement logic
            Debug.Log(comment);
        }
        else
        {
            Debug.Log("Unknown action: " + action);
        }
    }

    void MoveTo(string location)
    {
        // Add your movement logic here (e.g., using NavMeshAgent or Translate)
        Debug.Log(gameObject.name + " is moving to: " + location);
    }
}