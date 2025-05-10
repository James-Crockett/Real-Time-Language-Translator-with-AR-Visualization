using UnityEngine;
using System.Collections.Generic;
using TamilUI;

//This Scrpit Help You to Tamil Text Scrpiting And Tamil Charater and text asset with tamil words
namespace SampleTamilTextScrpiting
{
    public class ExampleTextScript : MonoBehaviour
    {
        [SerializeField] TamilText tamilTextScript; //Getting Tamil Text Class
        [SerializeField] TamilTextMeshPro tamilTextProScript; //Getting Tamil Mesh Pro Text Class

        [Header("Text Asset")] //Unity Editor 
        [SerializeField] TextAsset tamilTextFile; // This Text Asset contains textfile with tamil unicodes

        List<string> tamilText;


        //***MAIN***// SCRPITING

        int i = 0; // For Text Rotation
        public void UpdateText() //Add To Button onclick
        {
            if (i == tamilText.Count) //rotation Reset
                i = 0;

            //tamilTextScrpit is object which reference on inspector and Text is properties which update tamil text in runtime
            tamilTextScript.Text = tamilText[i];  //**MAIN**// This is how you change tamil text
            i++; //Increment
        }

        //This is for TextMesh Pro

        int i2 = 0; // For Text Rotation
        public void UpdateTextMeshPro() //Add To Button2 onclick
        {
            if (i2 == tamilText.Count)
                i2 = 0;

            tamilTextProScript.Text = tamilText[i2]; //Same as tamil text scrpit but this is for text mesh pro
            i2++;
        }





        //FOR TEXT ASSEST//

        private void Awake() //Unity Message : It is called when the scrpit instance is loaded
        {
            tamilText = GetStrings(tamilTextFile); //Get the string data
        }

        //Our Simple Code to read the tamil text file from text asset
        //break every line of text file and return List<string>

        List<string> GetStrings(TextAsset asset)
        {
            List<string> list = new List<string>(); //empty list
            string rawData = string.Empty; //empty string

            foreach (char value in asset.text) //read all string for text file and get the individual charater
            {
                if (value == '\n') //if charater is a enter(\n) then...
                {
                    list.Add(rawData); //...add old string in list
                    rawData = string.Empty; //...empty the string
                    continue; //...skip the loop for once
                }
                rawData += value; //else add charater in string
            }

            return list; //after loop exit return list
        }
		
		//Appication exit
		void Update()
		{
			  if (Input.GetKey("escape"))
              {
				Application.Quit();
				Debug.Log("exiting");
			  }
		}
    }
}