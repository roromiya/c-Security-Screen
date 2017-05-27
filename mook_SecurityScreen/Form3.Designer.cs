namespace mook_SecurityScreen
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblRePwd = new System.Windows.Forms.Label();
            this.lblResurt = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtRePwd = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(12, 17);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(53, 12);
            this.lblPwd.TabIndex = 0;
            this.lblPwd.Text = "비밀번호";
            // 
            // lblRePwd
            // 
            this.lblRePwd.AutoSize = true;
            this.lblRePwd.Location = new System.Drawing.Point(12, 51);
            this.lblRePwd.Name = "lblRePwd";
            this.lblRePwd.Size = new System.Drawing.Size(53, 12);
            this.lblRePwd.TabIndex = 1;
            this.lblRePwd.Text = "확      인";
            // 
            // lblResurt
            // 
            this.lblResurt.AutoSize = true;
            this.lblResurt.ForeColor = System.Drawing.Color.Red;
            this.lblResurt.Location = new System.Drawing.Point(22, 102);
            this.lblResurt.Name = "lblResurt";
            this.lblResurt.Size = new System.Drawing.Size(29, 12);
            this.lblResurt.TabIndex = 2;
            this.lblResurt.Text = "결과";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(94, 17);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(149, 21);
            this.txtPwd.TabIndex = 3;
            // 
            // txtRePwd
            // 
            this.txtRePwd.Location = new System.Drawing.Point(94, 51);
            this.txtRePwd.Name = "txtRePwd";
            this.txtRePwd.PasswordChar = '*';
            this.txtRePwd.Size = new System.Drawing.Size(149, 21);
            this.txtRePwd.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(260, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 55);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 133);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRePwd);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.lblResurt);
            this.Controls.Add(this.lblRePwd);
            this.Controls.Add(this.lblPwd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "비밀번호 생성";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblRePwd;
        private System.Windows.Forms.Label lblResurt;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtRePwd;
        private System.Windows.Forms.Button btnSave;
    }
}