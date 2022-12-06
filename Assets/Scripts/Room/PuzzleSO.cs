using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Puzzle", menuName ="Room/Puzzles/New Puzzle")]
public class PuzzleSO : ScriptableObject
{
    public List<PuzzleNumber> puzzleNum = new List<PuzzleNumber>();

    public PuzzleNumber[] RandomNum(int length)
    {
        PuzzleNumber[] puzzleNumbers = new PuzzleNumber[length];
        for (int i = 0; i < length; i++)
        {
            int id = UnityEngine.Random.Range(0, 10);
            puzzleNumbers[i] = puzzleNum.Find(x => x.id == id);
        }
        return puzzleNumbers;
    }

    string RandomPasswordGenerator(int length)
    {
        string password = "0123456789";
        string password_string = "";

        for (int i = 0; i < length; i++)
            password_string += password[UnityEngine.Random.Range(0, length)];

        return password_string;
    }
}
