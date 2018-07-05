namespace findlinetool
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cogRecordDisplay1 = new Cognex.VisionPro.CogRecordDisplay();
            this.RichTextBox_MSG = new System.Windows.Forms.RichTextBox();
            this.cogDisplay_CCD = new Cognex.VisionPro.Display.CogDisplay();
            this.Save = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_CCD)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 72);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open Image File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(52, 258);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 68);
            this.button2.TabIndex = 2;
            this.button2.Text = "Run";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cogRecordDisplay1
            // 
            this.cogRecordDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay1.DoubleTapZoomCycleLength = 2;
            this.cogRecordDisplay1.DoubleTapZoomSensitivity = 2.5D;
            this.cogRecordDisplay1.Location = new System.Drawing.Point(604, 35);
            this.cogRecordDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay1.Name = "cogRecordDisplay1";
            this.cogRecordDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay1.OcxState")));
            this.cogRecordDisplay1.Size = new System.Drawing.Size(324, 383);
            this.cogRecordDisplay1.TabIndex = 4;
            // 
            // RichTextBox_MSG
            // 
            this.RichTextBox_MSG.Location = new System.Drawing.Point(250, 35);
            this.RichTextBox_MSG.Name = "RichTextBox_MSG";
            this.RichTextBox_MSG.Size = new System.Drawing.Size(329, 371);
            this.RichTextBox_MSG.TabIndex = 5;
            this.RichTextBox_MSG.Text = "";
            // 
            // cogDisplay_CCD
            // 
            this.cogDisplay_CCD.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay_CCD.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay_CCD.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay_CCD.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay_CCD.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay_CCD.DoubleTapZoomCycleLength = 2;
            this.cogDisplay_CCD.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay_CCD.Location = new System.Drawing.Point(959, 35);
            this.cogDisplay_CCD.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay_CCD.MouseWheelSensitivity = 1D;
            this.cogDisplay_CCD.Name = "cogDisplay_CCD";
            this.cogDisplay_CCD.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay_CCD.OcxState")));
            this.cogDisplay_CCD.Size = new System.Drawing.Size(284, 383);
            this.cogDisplay_CCD.TabIndex = 6;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(52, 346);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 7;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(133, 346);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Open";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(52, 382);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "CCD Grab";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(52, 143);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 10;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(159, 143);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "OCR Teach";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 449);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.cogDisplay_CCD);
            this.Controls.Add(this.RichTextBox_MSG);
            this.Controls.Add(this.cogRecordDisplay1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_CCD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay1;
        private System.Windows.Forms.RichTextBox RichTextBox_MSG;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay_CCD;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button5;


    }
}

