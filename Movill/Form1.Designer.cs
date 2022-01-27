namespace Movill
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbl_NowDT = new System.Windows.Forms.Label();
            this.btnAuthorization = new System.Windows.Forms.Button();
            this.txtOAuth = new System.Windows.Forms.TextBox();
            this.timer_nowTime = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtInOutResponse = new System.Windows.Forms.TextBox();
            this.btn_OutCar = new System.Windows.Forms.Button();
            this.btn_InCar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_LPRNo = new System.Windows.Forms.TextBox();
            this.txt_Ho = new System.Windows.Forms.TextBox();
            this.txt_Dong = new System.Windows.Forms.TextBox();
            this.txt_Carno = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.lbl_Code = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_NowDT
            // 
            this.lbl_NowDT.AutoSize = true;
            this.lbl_NowDT.Location = new System.Drawing.Point(670, 9);
            this.lbl_NowDT.Name = "lbl_NowDT";
            this.lbl_NowDT.Size = new System.Drawing.Size(89, 12);
            this.lbl_NowDT.TabIndex = 10;
            this.lbl_NowDT.Text = "Now DateTime";
            // 
            // btnAuthorization
            // 
            this.btnAuthorization.Location = new System.Drawing.Point(642, 82);
            this.btnAuthorization.Name = "btnAuthorization";
            this.btnAuthorization.Size = new System.Drawing.Size(110, 24);
            this.btnAuthorization.TabIndex = 6;
            this.btnAuthorization.Text = "Authorization";
            this.btnAuthorization.UseVisualStyleBackColor = true;
            this.btnAuthorization.Visible = false;
            this.btnAuthorization.Click += new System.EventHandler(this.btnAuthorization_Click);
            // 
            // txtOAuth
            // 
            this.txtOAuth.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtOAuth.Enabled = false;
            this.txtOAuth.Location = new System.Drawing.Point(22, 82);
            this.txtOAuth.Multiline = true;
            this.txtOAuth.Name = "txtOAuth";
            this.txtOAuth.Size = new System.Drawing.Size(606, 24);
            this.txtOAuth.TabIndex = 3;
            this.txtOAuth.Visible = false;
            // 
            // timer_nowTime
            // 
            this.timer_nowTime.Enabled = true;
            this.timer_nowTime.Interval = 1000;
            this.timer_nowTime.Tick += new System.EventHandler(this.timer_nowTime_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtInOutResponse);
            this.panel1.Controls.Add(this.btn_OutCar);
            this.panel1.Controls.Add(this.btn_InCar);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_LPRNo);
            this.panel1.Controls.Add(this.txtOAuth);
            this.panel1.Controls.Add(this.btnAuthorization);
            this.panel1.Controls.Add(this.txt_Ho);
            this.panel1.Controls.Add(this.txt_Dong);
            this.panel1.Controls.Add(this.txt_Carno);
            this.panel1.Location = new System.Drawing.Point(12, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 88);
            this.panel1.TabIndex = 12;
            // 
            // txtInOutResponse
            // 
            this.txtInOutResponse.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtInOutResponse.Enabled = false;
            this.txtInOutResponse.Location = new System.Drawing.Point(22, 52);
            this.txtInOutResponse.Multiline = true;
            this.txtInOutResponse.Name = "txtInOutResponse";
            this.txtInOutResponse.Size = new System.Drawing.Size(490, 24);
            this.txtInOutResponse.TabIndex = 11;
            // 
            // btn_OutCar
            // 
            this.btn_OutCar.Location = new System.Drawing.Point(642, 25);
            this.btn_OutCar.Name = "btn_OutCar";
            this.btn_OutCar.Size = new System.Drawing.Size(110, 51);
            this.btn_OutCar.TabIndex = 10;
            this.btn_OutCar.Text = "출차테스트";
            this.btn_OutCar.UseVisualStyleBackColor = true;
            this.btn_OutCar.Click += new System.EventHandler(this.btn_OutCar_Click);
            // 
            // btn_InCar
            // 
            this.btn_InCar.Location = new System.Drawing.Point(518, 25);
            this.btn_InCar.Name = "btn_InCar";
            this.btn_InCar.Size = new System.Drawing.Size(110, 51);
            this.btn_InCar.TabIndex = 9;
            this.btn_InCar.Text = "입차테스트";
            this.btn_InCar.UseVisualStyleBackColor = true;
            this.btn_InCar.Click += new System.EventHandler(this.btn_InCar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "LPR.no";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "호수";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "동";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "차량번호";
            // 
            // txt_LPRNo
            // 
            this.txt_LPRNo.Location = new System.Drawing.Point(394, 25);
            this.txt_LPRNo.Name = "txt_LPRNo";
            this.txt_LPRNo.Size = new System.Drawing.Size(118, 21);
            this.txt_LPRNo.TabIndex = 0;
            this.txt_LPRNo.Text = "1";
            // 
            // txt_Ho
            // 
            this.txt_Ho.Location = new System.Drawing.Point(270, 25);
            this.txt_Ho.Name = "txt_Ho";
            this.txt_Ho.Size = new System.Drawing.Size(118, 21);
            this.txt_Ho.TabIndex = 0;
            this.txt_Ho.Text = "202";
            // 
            // txt_Dong
            // 
            this.txt_Dong.Location = new System.Drawing.Point(146, 25);
            this.txt_Dong.Name = "txt_Dong";
            this.txt_Dong.Size = new System.Drawing.Size(118, 21);
            this.txt_Dong.TabIndex = 0;
            this.txt_Dong.Text = "101";
            // 
            // txt_Carno
            // 
            this.txt_Carno.Location = new System.Drawing.Point(22, 25);
            this.txt_Carno.Name = "txt_Carno";
            this.txt_Carno.Size = new System.Drawing.Size(118, 21);
            this.txt_Carno.TabIndex = 0;
            this.txt_Carno.Text = "111가1111";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 134);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(773, 268);
            this.listBox1.TabIndex = 13;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(705, 408);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(83, 30);
            this.btn_Clear.TabIndex = 14;
            this.btn_Clear.Text = "메세지삭제";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // lbl_Code
            // 
            this.lbl_Code.AutoSize = true;
            this.lbl_Code.Location = new System.Drawing.Point(13, 9);
            this.lbl_Code.Name = "lbl_Code";
            this.lbl_Code.Size = new System.Drawing.Size(77, 12);
            this.lbl_Code.TabIndex = 15;
            this.lbl_Code.Text = "아파트코드 : ";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_Code);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lbl_NowDT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "직방(모빌) 에이젼트";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_NowDT;
        private System.Windows.Forms.Button btnAuthorization;
        private System.Windows.Forms.TextBox txtOAuth;
        private System.Windows.Forms.Timer timer_nowTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_LPRNo;
        private System.Windows.Forms.TextBox txt_Ho;
        private System.Windows.Forms.TextBox txt_Dong;
        private System.Windows.Forms.TextBox txt_Carno;
        private System.Windows.Forms.TextBox txtInOutResponse;
        private System.Windows.Forms.Button btn_OutCar;
        private System.Windows.Forms.Button btn_InCar;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Label lbl_Code;
        private System.Windows.Forms.Timer timer1;
    }
}

