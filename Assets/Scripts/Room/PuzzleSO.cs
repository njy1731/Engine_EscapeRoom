using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Puzzle", menuName = "Room/Puzzles/New Puzzle")]
public class Puzzleo : ScriptableObject
{
    public List<PuzzleNumber> puzzlenum = new List<PuzzleNumber>();

    public PuzzleNumber[] randomnum(int length)
    {
        PuzzleNumber[] puzzlenumbers = new PuzzleNumber[length];
        for (int i = 0; i < length; i++)
        {
            int id = UnityEngine.Random.Range(0, 10);
            puzzlenumbers[i] = puzzlenum.Find(x => x.id == id);
        }

        return puzzlenumbers;
    }
}

//public static class passwordgenerator
//{
//    public static int[] randomnumbers(int maxcount, int n)
//    {
//        int[] defaults = new int[maxcount];
//        int[] results = new int[n];

//        for (int i = 0; i < maxcount; ++i)
//        {
//            defaults[i] = i;
//        }

//        for (int i = 0; i < n; ++i)
//        {
//            int index = UnityEngine.Random.Range(0, maxcount);

//            results[i] = defaults[index];
//            defaults[index] = defaults[maxcount - 1];

//            maxcount--;
//        }

//        return results;
//    }
//}