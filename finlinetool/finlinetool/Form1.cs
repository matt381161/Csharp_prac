using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.ImageFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Cognex.VisionPro.FGGigE;

namespace findlinetool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SaveLog.Load_Log();
            SaveLog.RichTextBox_MSG = this.RichTextBox_MSG;            
            //Vision_Basic.Load_Cameras(Vision_Basic.VisionCameras.Cameras0);
            //Vision_Basic.CCD_Exposure_Function(Vision_Basic.VisionCameras.Cameras0, 300);
            mLineMaxTool.Load();
        }
        iLineMaxTool mLineMaxTool = new iLineMaxTool();

        private void button1_Click(object sender, EventArgs e)
        {
            cogRecordDisplay1.InteractiveGraphics.Clear();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            CogImageFileTool cogImgFileTool = new CogImageFileTool();

            openFileDialog1.Filter = "點陣圖檔案(*.bmp)|*.bmp"; // 對話框開啟時所預設的檔案格式
            //openFileDialog1.FileName = ""; // 對話框開啟時所預設的檔案名稱
            openFileDialog1.InitialDirectory = "C:\\Users\\shihjia\\Desktop"; // 對話框開啟時所在資料夾路徑
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName == "")
            {
                MessageBox.Show("未選取 File not selected");
            }
            else if (File.Exists(openFileDialog1.FileName) == true)
            {
                cogDisplay_CCD.StaticGraphics.Clear();
                cogDisplay_CCD.InteractiveGraphics.Clear();

                cogImgFileTool.Operator.Open(openFileDialog1.FileName, CogImageFileModeConstants.Read);
                cogImgFileTool.Run();
                

                if (cogImgFileTool.RunStatus.Result == CogToolResultConstants.Accept)
                {
                        // Show Image
                        cogDisplay_CCD.Image = cogImgFileTool.OutputImage;
                        cogRecordDisplay1.Image = cogImgFileTool.OutputImage;
                        cogDisplay_CCD.Fit();
                        mLineMaxTool.ROI_Create(cogRecordDisplay1);
                        cogRecordDisplay1.Fit();
                }
                cogImgFileTool.Operator.Close();
                cogImgFileTool.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mLineMaxTool.Run(cogRecordDisplay1);
        }

        private void Save_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Vision_Basic.Grab_Image_Function(cogRecordDisplay1,Vision_Basic.VisionCameras.Cameras0);
            
            cogRecordDisplay1.Fit();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
      
    }
}
