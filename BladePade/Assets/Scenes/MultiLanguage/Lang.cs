using System.Collections;
using UnityEngine;
using System.Xml;


//https://toster.ru/q/271453
public class Lang
    {
        private Hashtable Strings;
   
    public Lang(string language)
    {      
            SetLanguage(language);   
    }

    public void SetLanguage(string language)
        {
            XmlDocument xml = null;
             TextAsset textAsset = null;
            textAsset = Resources.Load("LanguageDictionary") as TextAsset;
            xml = new XmlDocument();
            xml.LoadXml(textAsset.text);

            Strings = new Hashtable();

            

        var element = xml.DocumentElement[language];
        if (element != null)
        {
            var elemEnum = element.GetEnumerator();
            while (elemEnum.MoveNext())
            {
                var xmlItem = (XmlElement)elemEnum.Current;
                
                Strings.Add(xmlItem.GetAttribute("name"), xmlItem.InnerText);
            }
        }
        else
        {
            Debug.LogError("The specified language does not exist: " + language);
        }
    }


        public string GetString(string name)
        {
            if (!Strings.ContainsKey(name))
            {
                Debug.LogError("The specified string does not exist: " + name);

                return "";
            }

            return (string)Strings[name];
        }
    }



