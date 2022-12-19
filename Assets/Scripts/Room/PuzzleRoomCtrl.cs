using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleRoomCtrl : MonoBehaviour
{
    [Header("Puzzle Info")]
    [SerializeField] private Text[] TextPrefab;
    [SerializeField] private int maxCount;
    [SerializeField] private int n;

    [HideInInspector] public static string password_str = "";

    void Awake()
    {
        RandomPassword();
    }

    /// <summary>
    /// �������� ������ ��й�ȣ�� ToString() => ���ڿ��� ��ȯ�Ͽ� Text�� �����ִ� �Լ�
    /// </summary>
    private void RandomPassword()
    {
        int[] numbers = PasswordGenerator.RandomNumbers(maxCount, n);
        List<int> randomSign = new List<int>(numbers);
        for (int i = 0; i < numbers.Length; i++)
        {
            password_str += numbers[i].ToString();
            TextPrefab[i].text += randomSign[i].ToString();
            Debug.Log(password_str);
        }
    }

    /// <summary>
    /// ���� ��й�ȣ�� �����ϴ� Ŭ����, �Լ�
    /// </summary>
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
                defaults[index] = defaults[maxCount - 1];

                maxCount--;
            }

            return results;
        }
    }
}
