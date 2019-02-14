using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeThumbnailsBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //string[] dizi = textBox1.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Title = "Youtube Links File";

                if(opf.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sw = new StreamReader(opf.FileName);

                    string ad = sw.ReadToEnd();

                    gel:;
                    if (ad.Contains("https://www.youtube.com/watch?v="))
                    {
                        int i = ad.IndexOf("https://www.youtube.com/watch?v=");

                        ad = ad.Remove(i, 32);

                        if (ad.Contains("https://www.youtube.com/watch?v=")) goto gel;
                        else
                        {
                            if(richTextBox1.Text.Length > 0)
                            {
                                richTextBox1.Clear();
                            }

                            richTextBox1.Text = ad;

                            if (richTextBox1.Text.Contains(" "))
                            {
                                richTextBox1.Text = richTextBox1.Text.Replace(" ", "");
                            }

                            if(progressBar1.Value > 0)
                            {
                                progressBar1.Value = 0;
                            }

                            deger = 1;
                        }
                    }
                    //
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog opf = new FolderBrowserDialog();
                opf.Tag = "Yol Seç";

                if (opf.ShowDialog() == DialogResult.OK)
                {
                    string[] descriptions = richTextBox1.Lines;
                    foreach (string item in descriptions)
                    {
                        string fileName = deger.ToString() + ".jpg";
                        string urlKısmi = item;
                        if(item.Contains(" "))
                        {
                            urlKısmi = urlKısmi.Replace(" ", "");
                        }
                        string url = @"https://img.youtube.com/vi/" + urlKısmi + @"/mqdefault.jpg";
                        using (WebClient client = new WebClient())
                        {
                            
                            client.DownloadFile(url, opf.SelectedPath + @"\" + fileName);

                            progressBar1.Value = progressBar1.Value + 5;
                        }
                        deger++;
                    }

                    if(progressBar1.Value != 100) { progressBar1.Value = 100; }
                    MessageBox.Show("İşleminiz Tamamlandı !");

                    progressBar1.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int deger = 1;

    }
}
