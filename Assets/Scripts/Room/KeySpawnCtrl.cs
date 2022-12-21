using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawnCtrl : MonoBehaviour
{
    [SerializeField] private Transform[] spawnpoint; //������ ��������Ʈ���� �޴� ����
    [SerializeField] GameObject keyPrefab = null; //���� ��ų ���� ������
    private bool isItemSpawned = false; //�������� �����Ǿ��°� �ƴѰ� Ȯ���ϴ� bool ����

    /// <summary>
    /// spawnpoint ������ ����ִ� n������ ��������Ʈ�� ���������� �̾� �װ��� ���踦 ������Ű�� �Լ�
    /// </summary>
    void SpawnItem()
    {
        if (!isItemSpawned)
        {
            int point = Random.Range(0, spawnpoint.Length);
            GameObject key = Instantiate(keyPrefab);
            key.transform.SetParent(spawnpoint[point].transform);
            key.transform.localPosition = new Vector3(0, 0, 0);
            // keyPrefab.transform.position = spawnpoint[point].transform.position;
            isItemSpawned = true;
        }
    }

    void Update()
    {
        SpawnItem();
    }
}
