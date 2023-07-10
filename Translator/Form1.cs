﻿using Google;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Translator
{
    public partial class Form1 : Form
    {
        YandexTranslator yt;

        public string ResponseBody { get; private set; }

        public Form1()
        {
            InitializeComponent();

            yt = new YandexTranslator();
        }

        private void translateButton_Click(object sender, EventArgs e)
        {
            string lang;

            if (ruEnRadioButton.Checked == true)
            {
                lang = "ru-en";
            }
            else if (radioButton1.Checked == true)
            {
                lang = "kk-ru";
            }
            else if (radioButton2.Checked == true)
            {
                lang = "kk-en";
            }
            else if (radioButton3.Checked == true)
            {
                lang = "en-kk";
            }
            else if (radioButton4.Checked == true)
            {
                lang = "ru-kk";
            }
            else
            {
                lang = "en-ru";
            }
            
            outputTextBox.Text = yt.Translate(inputTextBox.Text, lang);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                string lang;
                if (radioButton3.Checked == true)
                {
                    lang = "ru-kk";
                    var endpoint = new Uri("https://fish-text.ru/get?format=html&number=1");
                    var result = client.GetAsync(endpoint).Result;
                    var json = result.Content.ReadAsStringAsync().Result;
                    inputTextBox.AppendText(json);
                    outputTextBox.Text = yt.Translate(outputTextBox.Text, lang = "ru-kk");
                    outputTextBox.Text = yt.Translate(outputTextBox.Text, lang = "kk-en");
                    inputTextBox.Text = yt.Translate(inputTextBox.Text, lang);
                    outputTextBox.Text = yt.Translate(inputTextBox.Text, lang = "en-kk");
                }
                // osygan karap isteu
                else if (radioButton2.Checked == true)
                {
                    lang = "ru-kk";
                    var endpoint = new Uri("https://fish-text.ru/get?format=html&number=1");
                    var result = client.GetAsync(endpoint).Result;
                    var json = result.Content.ReadAsStringAsync().Result;
                    var translatedText = json.ToString().Replace("<p>", "").Replace("</p>", "");
                    inputTextBox.Text = yt.Translate(translatedText, lang);
                    outputTextBox.Text = yt.Translate(inputTextBox.Text, "kk-en");
                }

                else if (ruEnRadioButton.Checked == true)
                {
                    lang = "ru-en";
                    var endpoint = new Uri("https://fish-text.ru/get?format=html&number=1");
                    var result = client.GetAsync(endpoint).Result;
                    var json = result.Content.ReadAsStringAsync().Result;
                    inputTextBox.AppendText(json);
                    outputTextBox.Text = yt.Translate(outputTextBox.Text, lang = "en-ru");
                    inputTextBox.Text = yt.Translate(inputTextBox.Text, lang);
                    outputTextBox.Text = yt.Translate(inputTextBox.Text, lang = "ru-en");
                }
                else if (enRuRadioButton.Checked == true)
                {
                    lang = "ru-en";
                    var endpoint = new Uri("https://fish-text.ru/get?format=html&number=1");
                    var result = client.GetAsync(endpoint).Result;
                    var json = result.Content.ReadAsStringAsync().Result;
                    inputTextBox.AppendText(json);
                    outputTextBox.Text = yt.Translate(outputTextBox.Text, lang = "ru-en");
                    inputTextBox.Text = yt.Translate(inputTextBox.Text, lang);
                    outputTextBox.Text = yt.Translate(inputTextBox.Text, lang = "en-ru");
                }
                else if (radioButton1.Checked == true)
                {
                    lang = "ru-en";
                    var endpoint = new Uri("https://fish-text.ru/get?format=html&number=1");
                    var result = client.GetAsync(endpoint).Result;
                    var json = result.Content.ReadAsStringAsync().Result;
                    inputTextBox.AppendText(json);
                    outputTextBox.Text = yt.Translate(outputTextBox.Text, lang = "ru-kk");
                    inputTextBox.Text = yt.Translate(inputTextBox.Text, lang);
                    outputTextBox.Text = yt.Translate(inputTextBox.Text, lang = "kk-ru");
                }
                else if (radioButton4.Checked == true)
                {
                    lang = "ru-en";
                    var endpoint = new Uri("https://fish-text.ru/get?format=html&number=1");
                    var result = client.GetAsync(endpoint).Result;
                    var json = result.Content.ReadAsStringAsync().Result;
                    inputTextBox.AppendText(json);
                    outputTextBox.Text = yt.Translate(outputTextBox.Text, lang = "kk-ru");
                    inputTextBox.Text = yt.Translate(inputTextBox.Text, lang);
                    outputTextBox.Text = yt.Translate(inputTextBox.Text, lang = "ru-kk");
                }
            }
        }

        //private async Task button2_ClickAsync(object sender, EventArgs e)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        string lang;
        //        if (radioButton5.Checked == true)
        //        {
        //            lang = "ru-kk";
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            var response = await client.GetAsync("http://free-generator.ru/generator.php?action=word&type=3");
        //            var responseBody = await response.Content.ReadAsStringAsync();
        //            JObject json = JObject.Parse(responseBody);
        //            string word = json["word"]["word"].ToString();
        //            inputTextBox.AppendText(word);
        //            outputTextBox.Text = yt.Translate(outputTextBox.Text, lang = "ru-kk");
        //            outputTextBox.Text = yt.Translate(outputTextBox.Text, lang = "kk-en");
        //            inputTextBox.Text = yt.Translate(inputTextBox.Text, lang);
        //            outputTextBox.Text = yt.Translate(inputTextBox.Text, lang = "en-kk");
        //        }
        //        else
        //        {
        //            lang = "ru-kk";
        //            var endpoint = new Uri("https://fish-text.ru/get?format=html&number=1");
        //            var result = client.GetAsync(endpoint).Result;
        //            var json = result.Content.ReadAsStringAsync().Result;
        //            inputTextBox.AppendText(json);
        //            outputTextBox.Text = yt.Translate(outputTextBox.Text, lang = "ru-kk");
        //            outputTextBox.Text = yt.Translate(outputTextBox.Text, lang = "kk-en");
        //            inputTextBox.Text = yt.Translate(inputTextBox.Text, lang);
        //            outputTextBox.Text = yt.Translate(inputTextBox.Text, lang = "en-kk");
        //        }
        //    }
        //    }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                string lang;
                if (radioButton5.Checked == true)
                {
                    lang = "ru-kk";
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var endpoint = new Uri("http://free-generator.ru/generator.php?action=word&type=3");
                    var result = client.GetAsync(endpoint).Result;
                    var json = result.Content.ReadAsStringAsync().Result;
                    JObject asd = JObject.Parse(json);
                    string word = asd["word"]["word"].ToString();
                    inputTextBox.Text = yt.Translate(word, lang = "ru-kk");
                    outputTextBox.Text = yt.Translate(inputTextBox.Text, lang = "kk-en");
                }
                else
                {
                    lang = "ru-kk";
                    var endpoint = new Uri("https://fish-text.ru/get?format=html&number=1");
                    var result = client.GetAsync(endpoint).Result;
                    var json = result.Content.ReadAsStringAsync().Result;
                    inputTextBox.AppendText(json);
                    outputTextBox.Text = yt.Translate(outputTextBox.Text, lang = "ru-kk");
                    outputTextBox.Text = yt.Translate(outputTextBox.Text, lang = "kk-en");
                    inputTextBox.Text = yt.Translate(inputTextBox.Text, lang);
                    outputTextBox.Text = yt.Translate(inputTextBox.Text, lang = "en-kk");
                }
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}