using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadLanguage : MonoBehaviour
{
    public string CSVName;
    public Text[] CVSTexts;
    int Nums;
    List<MooblingData> MooblingDataList = new List<MooblingData>();
    // Start is called before the first frame update
    void Start()
    {
        Nums = 0;
        TextAsset LanguageData = Resources.Load<TextAsset>(CSVName);
        string[] Data = LanguageData.text.Split(new char[] { '\n' });
        Debug.Log(Data.Length);

        for (int i = 1; i < Data.Length - 1; i++)
        {
            string[] Row = Data[i].Split(new char[]{','});
            // ignored empty stuff
            if (i == 1)
            {
                if (Row[1] != "")
                {
                    MooblingData Md = new MooblingData();
                    // if no data here dont throw exception just leave default value
                    int.TryParse(Row[0], out Md.ID);
                    Md.Text = Row[1];
                    Md.Scene = Row[2];
                    MooblingDataList.Add(Md);
                }
            }
        }
        foreach(MooblingData Md in MooblingDataList)
        {

            CVSTexts[Nums].text = Md.Text;
            Nums++;
           // Debug.Log(Md.Text);
        }
       // LanguageData.text
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
