﻿namespace WinLogin
{
    partial class Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtUUID = new System.Windows.Forms.TextBox();
            this.txtUserInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "这是一个二维码：";
            // 
            // txtUUID
            // 
            this.txtUUID.Location = new System.Drawing.Point(26, 40);
            this.txtUUID.Multiline = true;
            this.txtUUID.Name = "txtUUID";
            this.txtUUID.ReadOnly = true;
            this.txtUUID.Size = new System.Drawing.Size(229, 49);
            this.txtUUID.TabIndex = 1;
            // 
            // txtUserInfo
            // 
            this.txtUserInfo.Location = new System.Drawing.Point(26, 129);
            this.txtUserInfo.Multiline = true;
            this.txtUserInfo.Name = "txtUserInfo";
            this.txtUserInfo.ReadOnly = true;
            this.txtUserInfo.Size = new System.Drawing.Size(229, 49);
            this.txtUserInfo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "这里是登录结果：";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtUserInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUUID);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "QRLogin";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUUID;
        private System.Windows.Forms.TextBox txtUserInfo;
        private System.Windows.Forms.Label label2;
    }
}

