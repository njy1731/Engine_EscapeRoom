using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleCtrl : MonoBehaviour
{
    [SerializeField] Puzzleo So;
    [SerializeField] private int maxCount;
    [SerializeField] private int n;
    private string password_str = "";

    void Start()
    {

    }

    private void Update()
    {
        if (password_str == "")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RandomPassword();
            }
        }

        else
        {
            password_str = "";
        }
    }

    private void RandomPassword()
    {
        int[] numbers = PasswordGenerator.RandomNumbers(maxCount, n);
        for (int i = 0; i < numbers.Length; i++)
        {
            password_str += numbers[i].ToString();
        }
        Debug.Log(password_str);
    }

    public static class PasswordGenerator
    {
        public static int[] RandomNumbers(int maxCount, int n)
        {
            int[] defaults = new int[maxCount];
            int[] results = new int[n];

            for (int i = 0; i < maxCount; ++i)
            {
                defaults[i] = i;
            }

            for (int i = 0; i < n; ++i)
            {
                int index = Random.Range(0, maxCount);

                results[i] = defaults[index];
                defaults[index] = defaults[maxCount - 1];

                maxCount--;
            }

            return results;
        }
    }
}

