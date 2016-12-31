namespace Tester
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonClose = new System.Windows.Forms.Button();
            this.comboBoxStates = new System.Windows.Forms.ComboBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.buttonReadEntries = new System.Windows.Forms.Button();
            this.buttonReadEntry = new System.Windows.Forms.Button();
            this.buttonWriteEntry = new System.Windows.Forms.Button();
            this.labelLogState = new System.Windows.Forms.Label();
            this.labelLogTime = new System.Windows.Forms.Label();
            this.labelCurTime = new System.Windows.Forms.Label();
            this.labelLogMessage = new System.Windows.Forms.Label();
            this.textBoxLogMessage = new System.Windows.Forms.TextBox();
            this.timeUpdater = new System.Windows.Forms.Timer(this.components);
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(535, 135);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // comboBoxStates
            // 
            this.comboBoxStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStates.FormattingEnabled = true;
            this.comboBoxStates.Location = new System.Drawing.Point(31, 71);
            this.comboBoxStates.Name = "comboBoxStates";
            this.comboBoxStates.Size = new System.Drawing.Size(121, 23);
            this.comboBoxStates.TabIndex = 1;
            this.comboBoxStates.SelectedIndexChanged += new System.EventHandler(this.comboBoxStates_SelectedIndexChanged);
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(28, 25);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(72, 15);
            this.labelFileName.TabIndex = 2;
            this.labelFileName.Text = "File: Test.log";
            // 
            // buttonReadEntries
            // 
            this.buttonReadEntries.Location = new System.Drawing.Point(436, 135);
            this.buttonReadEntries.Name = "buttonReadEntries";
            this.buttonReadEntries.Size = new System.Drawing.Size(93, 23);
            this.buttonReadEntries.TabIndex = 3;
            this.buttonReadEntries.Text = "Read Entries";
            this.buttonReadEntries.UseVisualStyleBackColor = true;
            this.buttonReadEntries.Click += new System.EventHandler(this.buttonReadEntries_Click);
            // 
            // buttonReadEntry
            // 
            this.buttonReadEntry.Location = new System.Drawing.Point(337, 135);
            this.buttonReadEntry.Name = "buttonReadEntry";
            this.buttonReadEntry.Size = new System.Drawing.Size(93, 23);
            this.buttonReadEntry.TabIndex = 4;
            this.buttonReadEntry.Text = "Read Entry";
            this.buttonReadEntry.UseVisualStyleBackColor = true;
            this.buttonReadEntry.Click += new System.EventHandler(this.buttonReadEntry_Click);
            // 
            // buttonWriteEntry
            // 
            this.buttonWriteEntry.Location = new System.Drawing.Point(238, 135);
            this.buttonWriteEntry.Name = "buttonWriteEntry";
            this.buttonWriteEntry.Size = new System.Drawing.Size(93, 23);
            this.buttonWriteEntry.TabIndex = 5;
            this.buttonWriteEntry.Text = "Write Entry";
            this.buttonWriteEntry.UseVisualStyleBackColor = true;
            this.buttonWriteEntry.Click += new System.EventHandler(this.buttonWriteEntry_Click);
            // 
            // labelLogState
            // 
            this.labelLogState.AutoSize = true;
            this.labelLogState.Location = new System.Drawing.Point(28, 53);
            this.labelLogState.Name = "labelLogState";
            this.labelLogState.Size = new System.Drawing.Size(56, 15);
            this.labelLogState.TabIndex = 6;
            this.labelLogState.Text = "LogState:";
            // 
            // labelLogTime
            // 
            this.labelLogTime.AutoSize = true;
            this.labelLogTime.Location = new System.Drawing.Point(159, 53);
            this.labelLogTime.Name = "labelLogTime";
            this.labelLogTime.Size = new System.Drawing.Size(57, 15);
            this.labelLogTime.TabIndex = 7;
            this.labelLogTime.Text = "LogTime:";
            // 
            // labelCurTime
            // 
            this.labelCurTime.AutoSize = true;
            this.labelCurTime.Location = new System.Drawing.Point(159, 74);
            this.labelCurTime.Name = "labelCurTime";
            this.labelCurTime.Size = new System.Drawing.Size(49, 15);
            this.labelCurTime.TabIndex = 8;
            this.labelCurTime.Text = "01:01:01";
            // 
            // labelLogMessage
            // 
            this.labelLogMessage.AutoSize = true;
            this.labelLogMessage.Location = new System.Drawing.Point(235, 53);
            this.labelLogMessage.Name = "labelLogMessage";
            this.labelLogMessage.Size = new System.Drawing.Size(76, 15);
            this.labelLogMessage.TabIndex = 9;
            this.labelLogMessage.Text = "LogMessage:";
            // 
            // textBoxLogMessage
            // 
            this.textBoxLogMessage.Location = new System.Drawing.Point(238, 71);
            this.textBoxLogMessage.Name = "textBoxLogMessage";
            this.textBoxLogMessage.Size = new System.Drawing.Size(372, 23);
            this.textBoxLogMessage.TabIndex = 10;
            this.textBoxLogMessage.TextChanged += new System.EventHandler(this.textBoxLogMessage_TextChanged);
            // 
            // timeUpdater
            // 
            this.timeUpdater.Enabled = true;
            this.timeUpdater.Interval = 500;
            this.timeUpdater.Tick += new System.EventHandler(this.timeUpdater_Tick);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(337, 109);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(93, 23);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.ThousandsSeparator = true;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(622, 170);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.textBoxLogMessage);
            this.Controls.Add(this.labelLogMessage);
            this.Controls.Add(this.labelCurTime);
            this.Controls.Add(this.labelLogTime);
            this.Controls.Add(this.labelLogState);
            this.Controls.Add(this.buttonWriteEntry);
            this.Controls.Add(this.buttonReadEntry);
            this.Controls.Add(this.buttonReadEntries);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.comboBoxStates);
            this.Controls.Add(this.buttonClose);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Badget.libLog - Tester";
            this.Load += new System.EventHandler(this.formMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ComboBox comboBoxStates;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Button buttonReadEntries;
        private System.Windows.Forms.Button buttonReadEntry;
        private System.Windows.Forms.Button buttonWriteEntry;
        private System.Windows.Forms.Label labelLogState;
        private System.Windows.Forms.Label labelLogTime;
        private System.Windows.Forms.Label labelCurTime;
        private System.Windows.Forms.Label labelLogMessage;
        private System.Windows.Forms.TextBox textBoxLogMessage;
        private System.Windows.Forms.Timer timeUpdater;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

