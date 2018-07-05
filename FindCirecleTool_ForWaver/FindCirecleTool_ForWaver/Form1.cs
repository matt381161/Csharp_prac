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
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro;

namespace FindCirecleTool_ForWaver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string ModularID = System.Reflection.MethodInfo.GetCurrentMethod().ReflectedType.ToString();//進入點名稱
        private CogFindCircleTool m_FindCircleTool = new CogFindCircleTool();
        private Boolean FindCircleTool_Status = false;

        private void button1_Click(object sender, EventArgs e)
        {
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
                cogImgFileTool.Operator.Open(openFileDialog1.FileName, CogImageFileModeConstants.Read);
                cogImgFileTool.Run();


                if (cogImgFileTool.RunStatus.Result == CogToolResultConstants.Accept)
                {
                    // Show Image
                    cogRecordDisplay1.Image = cogImgFileTool.OutputImage;
                    m_FindCircleTool.InputImage = (CogImage8Grey)cogRecordDisplay1.Image;
                    cogRecordDisplay1.Fit();
                }
                cogImgFileTool.Operator.Close();
                cogImgFileTool.Dispose();
            }
        }
        
        public Boolean ROI_create(CogRecordDisplay CogRecordDisplay1, Runparams runparams)
        {
            string ProcID = System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString();

            try
            {
                //initial RunParams
                m_FindCircleTool.RunParams.ExpectedCircularArc.CenterX = runparams.mCenterX;
                m_FindCircleTool.RunParams.ExpectedCircularArc.CenterY = runparams.mCenterY;
                m_FindCircleTool.RunParams.ExpectedCircularArc.Radius = runparams.mRadius;
                m_FindCircleTool.RunParams.ExpectedCircularArc.AngleStart = runparams.mAngleStart;
                m_FindCircleTool.RunParams.ExpectedCircularArc.AngleSpan = runparams.mAngleSpan;
                m_FindCircleTool.RunParams.NumCalipers = runparams.mNumCalipers;
                m_FindCircleTool.RunParams.CaliperSearchLength = runparams.mCaliperSearchLength;
                m_FindCircleTool.RunParams.CaliperProjectionLength = runparams.mCaliperProjectionLength;
                m_FindCircleTool.RunParams.CaliperSearchDirection = runparams.mCircleSearchDirectionOption;
                m_FindCircleTool.RunParams.NumToIgnore = runparams.mNumToIgnore;
                m_FindCircleTool.RunParams.CaliperRunParams.Edge0Polarity = runparams.mCogCaliperPolarityConstants;

                m_FindCircleTool.InputImage = (CogImage8Grey)CogRecordDisplay1.Image;
                CogRecordDisplay1.Record = m_FindCircleTool.CreateCurrentRecord().SubRecords["InputImage"];
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                FindCircleTool_Status = false;
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Runparams runparams = new Runparams();
            runparams.mCenterX = 730.041;
            runparams.mCenterY = 436.627;
            runparams.mRadius = 377.985;
            runparams.mAngleStart = 78.8641;
            runparams.mAngleSpan = -277.93;            
            runparams.mCaliperSearchLength = 177.499;
            runparams.mCaliperProjectionLength = 54.2951;            
            runparams.mCircleSearchDirectionOption = CogFindCircleSearchDirectionConstants.Outward;
            try
            {
                runparams.mNumCalipers = Int32.Parse(textBox1.Text.ToString());
                runparams.mNumToIgnore = Int32.Parse(textBox2.Text.ToString());
                switch (listBox1.SelectedIndex)
                {
                    case 0:
                        runparams.mCogCaliperPolarityConstants = CogCaliperPolarityConstants.DarkToLight;
                        break;

                    case 1:
                        runparams.mCogCaliperPolarityConstants = CogCaliperPolarityConstants.LightToDark;
                        break;

                    case 2:
                        runparams.mCogCaliperPolarityConstants = CogCaliperPolarityConstants.DontCare;
                        break;

                    default:
                        runparams.mCogCaliperPolarityConstants = CogCaliperPolarityConstants.DontCare;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("輸入格式錯誤!");
            }
            ROI_create(cogRecordDisplay1, runparams);
        }

        public CogFindCircleTool Run(CogRecordDisplay CogRecordDisplay1)
        {
            string ProcID = System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString();
            FindCircleTool_Status = false;

            try
            {
                m_FindCircleTool.InputImage = (CogImage8Grey)CogRecordDisplay1.Image;

                m_FindCircleTool.Run();
                CogRecordDisplay1.Record = m_FindCircleTool.CreateLastRunRecord().SubRecords["InputImage"];
                FindCircleTool_Status = true;
                return m_FindCircleTool;
            }
            catch (Exception ex)
            {
                //SaveLog.Msg_("FindCircleTool Run Failed : " + ModularID + ":\r\n" + ProcID + ":\r\n" + ex.ToString());
                MessageBox.Show(ex.ToString());
                m_FindCircleTool = null;
                return m_FindCircleTool;
            }
        }

        public Runresults Run(Runresults runresults)
        {
            Run(cogRecordDisplay1);
            if (m_FindCircleTool.Results == null)
            {
                runresults.CenterX = 0;
                runresults.CenterY = 0;
                runresults.isSuccess = false;
                return runresults;
            }
            else
            {
                CogCircle iCircle = m_FindCircleTool.Results.GetCircle();
                if (iCircle == null)
                {
                    runresults.CenterX = 0;
                    runresults.CenterY = 0;
                    runresults.isSuccess = false;
                    return runresults;
                }
                else
                {
                    runresults.CenterX = iCircle.CenterX;
                    runresults.CenterY = iCircle.CenterY;
                    runresults.isSuccess = true;
                    return runresults;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Run(cogRecordDisplay1);
        }

        public struct Runparams
        {
            //Tool執行參數初始值
            public Double mCenterX, mCenterY, mRadius, mAngleStart,
                mAngleSpan, mCaliperSearchLength,
                    mCaliperProjectionLength;
            public CogCaliperPolarityConstants mCogCaliperPolarityConstants;
            public int mNumToIgnore;
            public int mNumCalipers;
            public CogFindCircleSearchDirectionConstants mCircleSearchDirectionOption;//inward,outward

        }

        public struct Runresults
        {
            public double CenterX, CenterY;
            public bool isSuccess;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Runresults runresults = new Runresults();
            runresults = Run(runresults);
            MessageBox.Show(runresults.CenterX.ToString() + "\n" +
                            runresults.CenterY.ToString() + "\n" +
                            runresults.isSuccess.ToString() + "\n");
        }
    }
}
