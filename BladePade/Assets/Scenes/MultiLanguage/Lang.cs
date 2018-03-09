using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
//https://toster.ru/q/271453
public class Lang
    {
        private Hashtable Strings;
   
    public Lang(string path, string language)
    {      
            SetLanguage(path, language);   
    }

    public void SetLanguage(string path, string language)
        {
            
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
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



