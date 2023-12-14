using System; /* for Serializable */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParsingJson : MonoBehaviour
{
    [Serializable]
    public class Lotto
    {
        public int id;
        public string date;
        public int[] number;
        public int bonus;

        public void printNumbers()
        {
            string str = "numbers : ";
            for (int i = 0; i < 6; i++) str += number[i] + " ";

            Debug.Log(str);
            Debug.Log("bonus : " + bonus);
        }
    }

    public class LottoNumbers
    {
        public Lotto[] winning;
    }

    void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Json/LottoWinningNumber");

        LottoNumbers lottoList = JsonUtility.FromJson<LottoNumbers>(textAsset.text);

        foreach (Lotto lt in lottoList.winning)
        {
            lt.printNumbers();
            Debug.Log("=============");
        }

        string classToJson = JsonUtility.ToJson(lottoList);
        Debug.Log(classToJson);
    }
}