using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CMDAssistant
{
    public partial class Form1 : Form
    {
        string finalResult = "";
        public Form1()
        {
            InitializeComponent();

            commandlbl.Hide();
            commandtitle.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             resultlbl.Text = ExecuteCommand("getmac");     
        }
           
        private void button5_Click(object sender, EventArgs e)
        {
            resultlbl.Text = ExecuteCommand("ipconfig"); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            resultlbl.Text = ExecuteCommand("hostname"); 
        }

        public string ExecuteCommand(object command)
        {
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                procStartInfo.WorkingDirectory = @"C:\";
                // Now we create a process, assign its ProcessStartInfo and start it
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                
                
                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
                // Display the command output.
                //Console.WriteLine(result);  
                
                /*var lineRead = Regex.Split(result, "\r\n|\r|\n");
                for(int i=0; i<lineRead.Length; i++)
                {
                    if (lineRead[i].Contains("Maximum password age"))
                    {
                        finalresultlbl.Text += "\n" + lineRead[i];
                    }

                    if (lineRead[i].Contains("Password last set"))
                    {
                        finalresultlbl.Text += "\n"+lineRead[i];
                    }
                }*/

                return result;
            }
            catch (Exception objException)
            {
                return "Exception: "+ objException;
            }
        }      

        private void button3_Click(object sender, EventArgs e)
        {
            if(commandbox.Text.Length >= 2)
            {
                commandlbl.Visible = true;
                commandtitle.Visible = true;
                commandlbl.Text = ExecuteCommand(commandbox.Text);                
            }
            else
            {
                MessageBox.Show("Please enter valid command");
            }
        }

        private void runCommand(string command)
        {
            var proc1 = new ProcessStartInfo();
            string Command;
            proc1.UseShellExecute = true;
            Command = @command;
            proc1.WorkingDirectory = @"C:\";//C:\Windows\System32
            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            // as admin = proc1.Verb = "runas";
            proc1.Arguments = "/k " + Command;
            proc1.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(proc1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (commandbox.Text.Length >= 2)
            {
                runCommand(commandbox.Text);
            }
            else
            {
                MessageBox.Show("Please enter valid command");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            resultlbl.Text = ExecuteCommand("Systeminfo");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            resultlbl.Text = ExecuteCommand("Tasklist"); 
        }

        private void button9_Click(object sender, EventArgs e)
        {
            resultlbl.Text = ExecuteCommand("Cmdkey");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            resultlbl.Text = ExecuteCommand("Driverquery");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            resultlbl.Text = ExecuteCommand("Cipher"); 
        }
    }
}
