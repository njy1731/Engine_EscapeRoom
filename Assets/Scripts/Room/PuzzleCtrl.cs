using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleCtrl : MonoBehaviour
{
    [SerializeField] private int maxCount;
    [SerializeField] private int n;
    private string password_str = "";
    private bool isTake = false;
    private int length_ = 10;

    [Header("UI Info")]
    [SerializeField] private Image PasswordImage;
    [SerializeField] private Text RandomPasswordText;
    [SerializeField] private GameObject randomPasswordObj;

    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomPassword();
        }

        RandomPuzzle();
    }

    private void RandomPuzzle()
    {
        RandomPasswordText.text = password_str;
    }

    private void RandomPassword()
    {
        int[] numbers = PasswordGenerator.RandomNumbers(maxCount, n);
        List<int> randomSign = new List<int>(numbers);
        for (int i = 0; i < numbers.Length; i++)
        {
            password_str += numbers[i].ToString();
            //Debug.Log(numbers[i]);
            Debug.Log(randomSign[i]);
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

    //public void RandomSign()
    //{
    //    for (int i = 0; i < num; i++)
    //    {
    //        int rand = Random.Range(0, SignList.Count);
    //        print(SignList[rand]);
    //        SignList.RemoveAt(rand);
    //    }
    //}
}

