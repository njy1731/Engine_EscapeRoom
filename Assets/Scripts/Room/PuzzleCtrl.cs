using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleCtrl : MonoBehaviour
{

    //[SerializeField] PuzzleSO SO;
    [SerializeField] private int maxCount;
    [SerializeField] private int n;
    private string password_str = "";
    private int[] randomSign;
    private bool isTake = false;

    private int length_ = 10;

    [Header("UI Info")]
    [SerializeField] private Image PasswordImage;
    [SerializeField] private Text RandomPasswordText;
    [SerializeField] private GameObject randomPasswordObj;

    void Start()
    {
        //SO = GetComponent<PuzzleSO>();
        Debug.Log(StringUtils.GeneratePassword(4));

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

        //if (!isTake)
        //{
        //    randomPasswordObj.gameObject.SetActive(true);
        //}

        //else randomPasswordObj.gameObject.SetActive(false);

        //password_str = "";
    }

    private void RandomPassword()
    {
        int[] numbers = PasswordGenerator.RandomNumbers(maxCount, n);
        for (int i = 0; i < numbers.Length; i++)
        {
            password_str += numbers[i].ToString();
            //randomSign[i] += numbers[i];
        }
        Debug.Log(password_str);
        //StringUtils.GeneratePassword(4);
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

    public static class StringUtils
    {
        private const string PASSWORD_CHARS = "@#$*";

        public static string GeneratePassword(int length)
        {
            var sb = new System.Text.StringBuilder(length);
            var r = new System.Random();

            for (int i = 0; i < length; i++)
            {
                int pos = r.Next(PASSWORD_CHARS.Length);
                char c = PASSWORD_CHARS[pos];
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}

