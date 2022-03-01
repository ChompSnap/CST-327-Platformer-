using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
    public GameObject stonePrefab;
    public GameObject waterPrefab;
    public GameObject goalPrefab;
    public Transform environmentRoot;
    public float offset;

    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");

        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }

        // Go through the rows from bottom to top
        int row = 0;
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            int column = 0;
            char[] letters = currentLine.ToCharArray();
            foreach (var letter in letters)
            {

                // Todo - Instantiate a new GameObject that matches the type specified by letter
                if (letter == 'x')
                {
                    var square = Instantiate(rockPrefab);
                    // Todo - Position the new GameObject at the appropriate location by using row and column
                    square.transform.position = new Vector3(column + 1, row + offset, 0);
                    // Todo - Parent the new GameObject under levelRoot
                    square.transform.parent = environmentRoot;
                }
                else if (letter == 'b')
                {
                    var square = Instantiate(brickPrefab);
                    // Todo - Position the new GameObject at the appropriate location by using row and column
                    square.transform.position = new Vector3(column + 1, row + offset, 0);
                    // Todo - Parent the new GameObject under levelRoot
                    square.transform.parent = environmentRoot;
                }
                else if (letter == '?')
                {
                    var square = Instantiate(questionBoxPrefab);
                    // Todo - Position the new GameObject at the appropriate location by using row and column
                    square.transform.position = new Vector3(column + 1, row + offset, 0);
                    // Todo - Parent the new GameObject under levelRoot
                    square.transform.parent = environmentRoot;
                }
                else if (letter == 's')
                {
                    var square = Instantiate(stonePrefab);
                    // Todo - Position the new GameObject at the appropriate location by using row and column
                    square.transform.position = new Vector3(column + 1, row + offset, 0);
                    // Todo - Parent the new GameObject under levelRoot
                    square.transform.parent = environmentRoot;
                }
                else if (letter == 'w')
                {
                    var square = Instantiate(waterPrefab);
                    // Todo - Position the new GameObject at the appropriate location by using row and column
                    square.transform.position = new Vector3(column + 1, row + offset, 0);
                    // Todo - Parent the new GameObject under levelRoot
                    square.transform.parent = environmentRoot;
                }
                else if (letter == 'g')
                {
                    var square = Instantiate(goalPrefab);
                    // Todo - Position the new GameObject at the appropriate location by using row and column
                    square.transform.position = new Vector3(column + 1, row + offset, 0);
                    // Todo - Parent the new GameObject under levelRoot
                    square.transform.parent = environmentRoot;
                }


                column++;
            }
            row++;
        }
    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
