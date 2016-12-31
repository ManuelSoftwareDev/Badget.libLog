using System;
using System.Text;
using System.Windows.Forms;

namespace Tester
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        public Badget.libLog.LogFile logFile = null;
        private void formMain_Load(object sender, EventArgs e)
        {
            var enumTypes = Enum.GetValues(typeof(Badget.libLog.LogStates));
            foreach (var type in enumTypes)
                comboBoxStates.Items.Add(type);
            if (comboBoxStates.Items.Count > 0)
                comboBoxStates.SelectedIndex = 0;

            logFile = new Badget.libLog.LogFile("test.log");
            timeUpdater_Tick(this, e);
        }

        private void timeUpdater_Tick(object sender, EventArgs e)
        {
            labelCurTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void buttonWriteEntry_Click(object sender, EventArgs e)
        {
            Badget.libLog.LogFileWriter.WriteEntry(logFile, new Badget.libLog.LogFileEntry(textBoxLogMessage.Text, (Badget.libLog.LogStates)comboBoxStates.SelectedItem, DateTime.Now));   
        }

        private void buttonReadEntry_Click(object sender, EventArgs e)
        {
            try
            {
                var entry = Badget.libLog.LogFileWriter.ReadEntry(logFile, (int)numericUpDown1.Value);
                comboBoxStates.SelectedItem = entry.State;
                if (entry.Time != DateTime.MinValue)
                    labelCurTime.Text = entry.Time.ToLongTimeString();
                else
                    labelCurTime.Text = "null";
                textBoxLogMessage.Text = entry.EventName;
                timeUpdater.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().Name + ": " + ex.Message, "Badget.libLog - Tester", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxLogMessage_TextChanged(object sender, EventArgs e)
        {
            timeUpdater.Enabled = true;
        }

        private void comboBoxStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            timeUpdater.Enabled = true;
        }

        private void buttonReadEntries_Click(object sender, EventArgs e)
        {
            var entries = Badget.libLog.LogFileWriter.ReadEntries(logFile);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Entries of Test.log");
            foreach(var entry in entries)
            {
                sb.AppendLine(entry.State.ToString() + " -> " + entry.Time.ToLongTimeString() +  " -> " + entry.EventName);
            }
            MessageBox.Show(sb.ToString(), "Badget.libLog - Tester", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
