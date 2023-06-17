using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCtrl : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject kill_anim, text_anim, mainView;

    List<int> number = new List<int>();

    int count;
    
    //�ʱ�ȭ
    public void KillReset()
    {
        kill_anim.SetActive(false);

        number.Clear();

        for(int i = 0; i < spawnPoints.Length; i++)
        {
            if(spawnPoints[i].childCount !=0)
            {
                Destroy(spawnPoints[i].GetChild(0).gameObject);

            }
        }
            NPCSpawn();
    }

    // NPC����
    public void NPCSpawn()
    {
        int rand = Random.Range(0, 10);

        for(int i =0; i <5; i++)
        {
            //�ߺ��Ǿ��ٸ�
            if(number.Contains(rand))
            {
                rand = Random.Range(0, 10);
            }
            //�ߺ����� �ʾҴٸ�
            else
            {
                number.Add(rand);
                i++;
            }
        }

        //����
        for (int i = 0; i < number.Count; i++)
        {
            //�ټ����� �����ϰ� ���� ���� ���� ����Ʈ�� ��ġ ��Ų��.
            Instantiate(Resources.Load("NPC"), spawnPoints[number[i]]);
        }
    }

    //ų�ϸ� ȣ��� �Լ�
    public void kill()
    {
        count++;

        if(count == 5)
        {
            text_anim.SetActive(false);
            Invoke("Change", 1);
        }
    }

    //ȭ�� ��ȯ
    public void Change()
    {
        mainView.SetActive(true);
        gameObject.SetActive(false);

        //ĳ���� ����
        FindObjectOfType<PlayerCtrl>().DestroyPlayer();
    }
}