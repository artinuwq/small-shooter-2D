using TMPro;
using System.Collections.Generic;
using UnityEngine;
using static Library;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


public class mainmenu : MonoBehaviour
{
    public static mainmenu instance;
    public SaveData activeSave;
    public bool hasLoaded;
    public int saveNumber;

    public TMP_Text TimeCounter;
    private void Awake()
    {
        saveNumber = System.IO.Directory.GetFiles(Application.persistentDataPath).Length;
        activeSave.saveName = (saveNumber + 1).ToString();
        instance = this;
    }

    public void save()
    {
        string dataPath = Application.persistentDataPath;
        var fSerializer = new XmlSerializer(typeof(SaveData));
        var fStream = new FileStream(dataPath + "/" + "DONTTOUCH" + ".save", FileMode.Create);
        fSerializer.Serialize(fStream, activeSave);
        fStream.Close();
        saveNumber++;
        activeSave.saveName = saveNumber.ToString();
        Debug.Log("Save ’”… “≈ ¬ –Œ“");
        Debug.Log(Application.persistentDataPath.ToString());
    }

    public void Load() 
    {
        string dataPath = Application.persistentDataPath;
        if (File.Exists(dataPath + "/" + "DONTTOUCH" + ".save")) {
            var fSerializer = new XmlSerializer(typeof(SaveData));
            var fStream = new FileStream(dataPath + "/" + "DONTTOUCH" + ".save", FileMode.Open);
            activeSave = fSerializer.Deserialize(fStream) as SaveData;
            if (StaticHolder.MaxTime < mainmenu.instance.activeSave.MaxTime) { StaticHolder.MaxTime = mainmenu.instance.activeSave.MaxTime; }
            fStream.Close();
            hasLoaded = true;
            Debug.Log("LOAD ’”… “≈ ¬ ∆ÓÔÛ");
            Debug.Log(fStream);
        }
    }



    public void Start()
    {
        mainmenu.instance.Load();
        TimeCounter.text = "Ã‡ÍÒ. ‚ÂÏˇ:" + StaticHolder.MaxTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class SaveData
{
    public string saveName;
    public int MaxTime;

}
