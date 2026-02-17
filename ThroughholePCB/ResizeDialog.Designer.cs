namespace ThroughholePCB
{
    partial class ResizeDialog
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
            heightTxt = new TextBox();
            widthTxt = new TextBox();
            label2 = new Label();
            label1 = new Label();
            resizeBtn = new Button();
            cancelBtn = new Button();
            SuspendLayout();
            // 
            // heightTxt
            // 
            heightTxt.Location = new Point(91, 41);
            heightTxt.Name = "heightTxt";
            heightTxt.Size = new Size(111, 23);
            heightTxt.TabIndex = 7;
            heightTxt.Text = "50.0";
            heightTxt.TextAlign = HorizontalAlignment.Right;
            // 
            // widthTxt
            // 
            widthTxt.Location = new Point(91, 12);
            widthTxt.Name = "widthTxt";
            widthTxt.Size = new Size(111, 23);
            widthTxt.TabIndex = 6;
            widthTxt.Text = "50.0";
            widthTxt.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 44);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 5;
            label2.Text = "Height (mm)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 15);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 4;
            label1.Text = "Width (mm)";
            // 
            // resizeBtn
            // 
            resizeBtn.Location = new Point(12, 79);
            resizeBtn.Name = "resizeBtn";
            resizeBtn.Size = new Size(75, 23);
            resizeBtn.TabIndex = 8;
            resizeBtn.Text = "Resize";
            resizeBtn.UseVisualStyleBackColor = true;
            resizeBtn.Click += resizeBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(93, 79);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 9;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // ResizeDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(211, 113);
            ControlBox = false;
            Controls.Add(cancelBtn);
            Controls.Add(resizeBtn);
            Controls.Add(heightTxt);
            Controls.Add(widthTxt);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ResizeDialog";
            Text = "ResizeDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox heightTxt;
        private TextBox widthTxt;
        private Label label2;
        private Label label1;
        private Button resizeBtn;
        private Button cancelBtn;
    }
}