using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Web;


namespace xiamigrabber
{
    public partial class main : Form
    {
        StreamWriter fLog;
        String sLogName;

        string invalidPath = new string(Path.GetInvalidPathChars());
        string invalidFile = new string(Path.GetInvalidFileNameChars());

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //appendText(e.ProgressPercentage + Environment.NewLine);
            changeProgress(e.ProgressPercentage);
        }

        private void changeProgress( int i )
        {
            if (progressbar.GetCurrentParent().InvokeRequired)
            {
                progressbar.GetCurrentParent().Invoke(new MethodInvoker(delegate { progressbar.Value = i; }));
            }

            progressbar.Value = i;
        }
        
        public main()
        {
            InitializeComponent();
            basedir.Text = Directory.GetCurrentDirectory();
            sLogName = basedir.Text + DateTime.Now.ToString("M_d_HH_mm") + ".txt";
            fLog = new StreamWriter(sLogName, true);
        }

        public void error_handler()
        {
            fLog.Close();
            String sLog = File.ReadAllText(sLogName);
            Form er = new error(sLog);
            er.Show();

            sLogName = Directory.GetCurrentDirectory() + DateTime.Now.ToString("M_d_HH_mm") + ".txt";
            fLog = new StreamWriter(sLogName, true);
        }

        private void choosedir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                basedir.Text = fbd.SelectedPath;
            }
        }

        private String getResp(String sUrl)
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 7.1; Trident/5.0)");
            wc.Headers.Add("Referer", "http://www.xiami.com/song/play");

            Stream data = wc.OpenRead(sUrl);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            //appendText(s + Environment.NewLine);
            return s;
        }

        private String decodeUrl(String enc)
        {
            int iNum = Convert.ToInt32(enc.Substring(0,1));

            String[] s = new String[iNum];

            int iPerLine = (enc.Length - 1) / iNum;
            int iRest = (enc.Length - 1) % iNum;
            int iS = 0;

            for (int i = 1; i < enc.Length; i += iPerLine)
            {
                if (iRest != 0)
                {
                    s[iS] = enc.Substring(i, iPerLine+1);
                    iRest--;
                    i++;
                }else
                    s[iS] = enc.Substring(i, iPerLine);
                iS++;
            }

            String sRes = "";

            for (int i = 1; i < enc.Length; i++)
            {
                sRes += s[(i - 1) % iNum].ElementAt((i-1)/iNum);
            }

            sRes = System.Uri.UnescapeDataString(sRes).Replace("^", "0");

            //debugtext.AppendText(sRes);

            return sRes;
        }

        private ArrayList getUrlList(String sUrl)
        {
            //appendText(sUrl);
            String ss = getResp(sUrl);
            if (ss == "")
            {
                appendText("(ID error ?)"+Environment.NewLine);
            }

            ArrayList al = new ArrayList();

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(ss);

            XmlNamespaceManager nsmanager = new XmlNamespaceManager(xml.NameTable);
            nsmanager.AddNamespace("x", "http://xspf.org/ns/0/");
            XmlNodeList xnList = xml.SelectNodes("/x:playlist/x:trackList/x:track", nsmanager);
            
            foreach (XmlNode x in xnList)
            {
                Dictionary<String, String> d = new Dictionary<String, String>();
                d.Add("title", x["title"].InnerText);
                d.Add("location", decodeUrl(x["location"].InnerText));
                d.Add("lyric", x["lyric"].InnerText);
                d.Add("pic", x["pic"].InnerText);
                d.Add("artist", x["artist"].InnerText);
                d.Add("album", x["album_name"].InnerText);

                al.Add(d);
            }

            return al;
        }

        public void CopyTo(Stream input, Stream output)
        {
            byte[] buffer = new byte[16 * 1024]; // Fairly arbitrary size
            int bytesRead;

            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesRead);
            }
        }

        private void updateID3(String sFile, Dictionary<String, String> d, int iNum)
        {
            TagLib.File fMp3 = TagLib.File.Create(sFile);
            

            WebClient wc = new WebClient();
            wc.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 7.1; Trident/5.0)");
            wc.Headers.Add("Referer", "http://www.xiami.com/song/play");

            //Stream data = wc.OpenRead(d["pic"]);
            TagLib.Picture[] pic = new TagLib.Picture[1];

            MemoryStream dataCopy = new MemoryStream();
            using (var clientRequestStream = wc.OpenRead(d["pic"]))
            {
                CopyTo(clientRequestStream,dataCopy);
            }
            dataCopy.Position = 0;

            pic[0] = new TagLib.Picture(TagLib.ByteVector.FromStream(dataCopy));

            fMp3.Tag.Pictures = pic;
            dataCopy.Close();

            Stream data = wc.OpenRead(d["lyric"]);

            StreamReader reader = new StreamReader(data);
            string sLyric = reader.ReadToEnd();
            data.Close();
            reader.Close();
            fMp3.Tag.Lyrics = sLyric;

            String[] sa = new String[1];
            sa[0] = d["artist"];

            fMp3.Tag.Track = Convert.ToUInt32(iNum);
            fMp3.Tag.Title = d["title"];
            fMp3.Tag.Album = d["album"];
            fMp3.Tag.AlbumArtists = sa;
            fMp3.Tag.Performers = sa;

            fMp3.Save();
        }

        private delegate void atDel(string s);
        private void appendText( String s )
        {
            if (debugtext.InvokeRequired)
            {
                atDel sd = new atDel(appendText);
                debugtext.Invoke(sd, new object[] { s }); 
            }
            else
                debugtext.AppendText(s);
        }

        private int getOptions()
        {
            if (options.InvokeRequired)
            {
                return (int)options.Invoke((Func<int>)delegate
                {
                    return options.SelectedIndex;
                });
            }

            return options.SelectedIndex;
        }

        private void downloadWork(object sender, DoWorkEventArgs e)
        {
            String sUrl_id = "http://www.xiami.com/song/playlist/id/" + id.Text;
            String sBaseUrl = "";

            switch (getOptions())
            {
                case 0:
                    sBaseUrl = sUrl_id + "/type/1";
                    break;
                case 1:
                    sBaseUrl = sUrl_id + "/object_name/default/object_id/0";
                    break;
                case 2:
                    sBaseUrl = sUrl_id + "/type/3";
                    break;
                case 3:
                    statuslabel.Text = "still working on, please choose other option";
                    break;
                default:
                    break;
            }

            

            ArrayList al = getUrlList(sBaseUrl);
            String sSubDir = "";
            if (getOptions() == 0)
            {
                Object o = al[0];
                Dictionary<String, String> d = (Dictionary<String, String>)o;

                sSubDir = "\\" +d["artist"]+"-"+ d["album"];
            }
            else if (getOptions() == 2)
            {
                sSubDir = "\\" + id.Text;
            }

            String sDir = basedir.Text + sSubDir;

            foreach (char c in invalidPath)
            {
                sDir = sDir.Replace(c.ToString(), "");
            }

            if (!Directory.Exists(sDir))
            {
                Directory.CreateDirectory(sDir);
            }

            al.TrimToSize();

            appendText("Total tracks " + al.Capacity + "." + Environment.NewLine);

            int iNumofTrack = 1;

            WebClient wc = new WebClient();
            wc.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 7.1; Trident/5.0)");
            wc.Headers.Add("Referer", "http://www.xiami.com/song/play");

            foreach (Object o in al)
            {
                if (bw.CancellationPending)
                {
                    break;
                }
                Dictionary<String, String> d = (Dictionary<String, String>)o;

                
                String sFileName = d["title"] + ".mp3";

                foreach (char c in invalidFile)
                {
                    sFileName = sFileName.Replace(c.ToString(), "");
                }

                sFileName = sDir + "\\" + iNumofTrack + "_" + sFileName;

                appendText("Downloading Tracks[" + iNumofTrack + "/" + al.Capacity + "] : " + d["title"] + Environment.NewLine);

                wc.DownloadFile(d["location"], sFileName);

                appendText("Downloading Tracks[" + iNumofTrack + "/" + al.Capacity + "] : " + d["title"] + " Finished" + Environment.NewLine);

                if (id3.Checked)
                {
                    appendText("Update ID3 tag..." + Environment.NewLine);
                    try
                    {
                        updateID3(sFileName, d, iNumofTrack);
                    }catch(Exception ex){
                        appendText(ex.ToString() + Environment.NewLine);
                    }
                    appendText("Update ID3 tag...Finished" + Environment.NewLine);
                }

                bw.ReportProgress(iNumofTrack*100/al.Capacity);

                iNumofTrack++;
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            appendText("Download Finished" + Environment.NewLine);
            //appendText(e.Error+e.Cancelled.ToString() + Environment.NewLine);
            start.Text = "start";
            progressbar.Visible = false;
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (id.Text.Equals(""))
            {
                statuslabel.Text = "id should not be empty !!";
                return;
            }

            if (bw.IsBusy)
            {
                bw.CancelAsync();
                progressbar.Visible = false;
                start.Text = "start";
            }
            else
            {
                progressbar.Visible = true;
                progressbar.Value = 0;

                bw.RunWorkerAsync();
                start.Text = "cancel";
            }
        }
    }
}
