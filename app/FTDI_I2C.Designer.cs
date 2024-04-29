using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace app;
using System;


partial class FTDI_I2C
{
    public const int WindowWidth = 800;
    public const int WindowHeight = 450;

    public const int ButtonWidth = 100;
    public const int ButtonHeight = 30;

    public const int ButtonTopOffsetX = 10;
    public const int ButtonTopOffsetY = 10;

    public const int DistanceBetweenButtons = 5;

    private Button aboutButton;
    private Button scanButton;
    private ListBox bitListBox;
    private ListBox freqyencyListBox;
    private TextBox inputTextBox;
    private TextBox outputTextBox;
    public ComboBox DeviceBox;

    public string[] SnOfdevices = new string [10];
    static uint numOfDevices=0;
    

    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    public void InitializeComponent()
    {
        
        int ListBoxWidth = 100;
        int ListBoxHeight = 50;

        // 
        // MainForm
        // 
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(WindowWidth, WindowHeight);
        this.MaximizeBox = false;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Name = "FTDI_I2C";
        this.Text = "FTDI_I2C";
        // 
        // aboutButton
        // 
        this.aboutButton = new System.Windows.Forms.Button();
        this.aboutButton.Location = new System.Drawing.Point(WindowWidth-ButtonTopOffsetX-ButtonWidth, ButtonTopOffsetY);
        this.aboutButton.Name = "aboutButton";
        this.aboutButton.Size = new System.Drawing.Size(ButtonWidth, ButtonHeight);
        this.aboutButton.Text = "About";
        this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
        this.Controls.Add(this.aboutButton);
        // Initialize bitListBox
        this.bitListBox = new ListBox();
        this.bitListBox.Location = new System.Drawing.Point(ButtonTopOffsetX+30, ButtonTopOffsetY);
        this.bitListBox.Size = new System.Drawing.Size(ListBoxWidth, ListBoxHeight);
        this.bitListBox.Items.AddRange(new object[] { "8bit", "16bit" });
        this.bitListBox.SelectedIndex = 0; // Set the default selected item to "8bit"
        this.Controls.Add(this.bitListBox);
        
        // Create and configure a label for the TextBox title
        Label bitLabel = new Label();
        bitLabel.Text = "Bit:";
        bitLabel.Location = new Point(ButtonTopOffsetX, ButtonTopOffsetY );
        this.Controls.Add(bitLabel);

        // Input text box
        this.inputTextBox = new TextBox();
        this.inputTextBox.Location = new System.Drawing.Point(ButtonTopOffsetY , (ButtonTopOffsetY*4) + 60 );
        this.inputTextBox.Size = new System.Drawing.Size(WindowWidth - 20, (WindowHeight/2) -80);
        this.inputTextBox.TextChanged += new System.EventHandler(this.inputTextBox_TextChanged);
        this.inputTextBox.Multiline = true; 
        this.inputTextBox.KeyPress += new KeyPressEventHandler(this.inputTextBox_KeyPress);
        //this.inputTextBox.Text = "Write your inout data here"; // Set placeholder text
        this.Controls.Add(this.inputTextBox);

        // Create and configure a label for the TextBox title
        Label inputLabel = new Label();
        inputLabel.Text = "Input:";
        inputLabel.Location = new Point(ButtonTopOffsetX, (ButtonTopOffsetY*4) + 40 );
        this.Controls.Add(inputLabel);

        // Initialize outputTextBox
        this.outputTextBox = new TextBox();
        this.outputTextBox.Location = new System.Drawing.Point(ButtonTopOffsetY  , (WindowHeight/2)+60);
        this.outputTextBox.Size = new System.Drawing.Size(WindowWidth - 20, (WindowHeight/2) -80);
        this.outputTextBox.ReadOnly = true; // Make outputTextBox read-only
        this.outputTextBox.Multiline = true; 
        this.outputTextBox.AllowDrop = false; // Disable dropping text into outputTextBox
        this.outputTextBox.KeyDown += new KeyEventHandler(this.outputTextBox_KeyDown);
        //this.outputTextBox.Text = "Output will be displayed here"; // Set placeholder text
        this.Controls.Add(this.outputTextBox);
   
        // Create and configure a label for the TextBox title
        Label outputLabel = new Label();
        outputLabel.Text = "Output:";
        outputLabel.Location = new Point(ButtonTopOffsetX, (WindowHeight/2)+40 );
        this.Controls.Add(outputLabel);
        
        // Create and configure the ComboBox
       /* ComboBox comboBox = new ComboBox();
        comboBox.Items.AddRange(new object[] {"100K", "400K"});
        comboBox.SelectedIndex = 0; // Set the default selected item
        comboBox.Location = new Point(ButtonTopOffsetX+230, ButtonTopOffsetY);
        // Load the last selected value from application settings
        this.Controls.Add(comboBox);*/

        // Initialize freqyencyListBox
        this.freqyencyListBox = new ListBox();
        this.freqyencyListBox.Location = new System.Drawing.Point(ButtonTopOffsetX+240, ButtonTopOffsetY);
        this.freqyencyListBox.Size = new System.Drawing.Size(ListBoxWidth, ListBoxHeight);
        this.freqyencyListBox.Items.AddRange(new object[] { "100K", "400K"});
        this.freqyencyListBox.SelectedIndex = 0; // Set the default selected item to "8bit"
        this.Controls.Add(this.freqyencyListBox);
           
        // Create and configure a label for the TextBox title
        Label frequencyLabel = new Label();
        frequencyLabel.Text = "Freqyency:";
        frequencyLabel.Location = new Point(ButtonTopOffsetX+160, ButtonTopOffsetY);
        this.Controls.Add(frequencyLabel);

        // 
        // scanButton
        // 
        this.scanButton = new System.Windows.Forms.Button();
        this.scanButton.Location = new System.Drawing.Point(WindowWidth-ButtonTopOffsetX-ButtonWidth - ButtonWidth - DistanceBetweenButtons, ButtonTopOffsetY );
        this.scanButton.Name = "scanButton";
        this.scanButton.Size = new System.Drawing.Size(ButtonWidth, ButtonHeight);
        this.scanButton.Text = "Scan";
        this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
        this.Controls.Add(this.scanButton);

        
        // Create and configure the ComboBox
        this.DeviceBox = new ComboBox();
        this.DeviceBox.Location = new Point(ButtonTopOffsetX+450, ButtonTopOffsetY);
        // Load the last selected value from application settings
        this.Controls.Add(DeviceBox);


           
        // Create and configure a label for the TextBox title
        Label DeviceLabel = new Label();
        DeviceLabel.Text = "Device:";
        DeviceLabel.Location = new Point(ButtonTopOffsetX+390, ButtonTopOffsetY+4);
        this.Controls.Add(DeviceLabel);


        this.ResumeLayout(false);
    }
    private void aboutButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("FTDI_I2C Application\nVersion 1.0\nDeveloped by YourName", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void scanButton_Click(object sender, EventArgs e)
    {
        
        string[] device=new string[10];
        device =null;
        bool result;
        result = getFtdiScan();
                
    }

    private bool getFtdiScan()
    {
        bool success = true;
        DeviceBox.Items.Clear(); // Clear existing items
        string[] device=new string[10];
    try
        {
            // Define the timeout duration
            TimeSpan timeout = TimeSpan.FromSeconds(5);
            // Execute the function with a timeout
            success = ExecuteFunctionWithTimeout(() => {
                ftdiScan();
            }, timeout);
        }
        catch (TimeoutException)
        {
            MessageBox.Show("Function execution timed out.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            // Handle the timeout situation
            return false;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // Handle other types of exceptions
            return false;
        }

        
        for (int i = 0; i < numOfDevices; i++)
            {
            // Add new items
            DeviceBox.Items.Add(SnOfdevices [i]);
            //MessageBox.Show(SnOfdevices[i], "Device Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        
        if(SnOfdevices [0] != null)
            DeviceBox.SelectedIndex = 0; // Set the default selected item to "8bit"
    


    return true;
    }

    private void ftdiScan()
    {
        string [] device = new string[10];
        numOfDevices = 0;
        // Import the necessary functions from ftd2xx.dll
        [DllImport("ftd2xx.dll")]
        static extern UInt32 FT_Rescan(UInt32 dwFlags);

        [DllImport("ftd2xx.dll")]
        static extern UInt32 FT_CreateDeviceInfoList(ref UInt32 lpdwNumDevices);

        [DllImport("ftd2xx.dll")]
        static extern UInt32 FT_GetDeviceInfoDetail(UInt32 dwIndex, ref UInt32 lpdwFlags, ref UInt32 lpdwType, ref UInt32 lpdwID,
                                                    ref UInt32 lpdwLocId, StringBuilder lpSerialNumber, StringBuilder lpDescription, IntPtr pHandle);

        
        // Call FT_Rescan to refresh the device list
        UInt32 result = FT_Rescan(0);

        if (result == 0)
        {
            // Get the number of connected devices
            result = FT_CreateDeviceInfoList(ref numOfDevices);

            if (result == 0)
            {
                // Loop through each device and retrieve its details
                for (int i = 0; i < numOfDevices; i++)
                {
                    UInt32 flags = 0, type = 0, id = 0, locId = 0;
                    StringBuilder serialNumber = new StringBuilder(256);
                    StringBuilder description = new StringBuilder(256);

                    result = FT_GetDeviceInfoDetail((UInt32)i, ref flags, ref type, ref id, ref locId, serialNumber, description, IntPtr.Zero);

                    if (result == 0)
                    {
                        // Display details about the device
                        string deviceInfo = $"Device {i + 1}: Type={type}, ID={id}, LocId={locId}, SerialNumber={serialNumber}, Description={description}";
                        //MessageBox.Show(deviceInfo, "Device Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SnOfdevices[i] ="";
                        SnOfdevices [i] = serialNumber.ToString();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to get device info for device {i + 1}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (result == 0)
                    {
                        //DeviceBox.Items.Clear(); // Clear existing items
                        for (int i = 0; i < numOfDevices; i++)
                            {
                            // Add new items
                            //DeviceBox.Items.Add(SnOfdevices [i]);
                            }
                        //DeviceBox.SelectedIndex = 0; 
                    }
            }
            else
            {
                MessageBox.Show("Failed to get the number of devices.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show("FT_Rescan failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void inputTextBox_TextChanged(object sender, EventArgs e)
    {
        // Input textbox text changed event handler
        // You can add your logic here if needed
    }

    private void inputTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        // Input textbox key press event handler
        // Allow only hexadecimal characters (0-9, A-F, a-f) and backspace
        if (!char.IsControl(e.KeyChar) && !((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'F') || (e.KeyChar >= 'a' && e.KeyChar <= 'f')))
        {
            e.Handled = true; // Ignore the key press
        }
    }

    private void outputTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        // Output textbox key down event handler
        // Disable pasting in the output textbox
        if (e.Control && e.KeyCode == Keys.V)
        {
            e.SuppressKeyPress = true; // Suppress the key press
        }
    }

    private bool ExecuteFunctionWithTimeout(Action function, TimeSpan timeout)
    {
        // Use a CancellationTokenSource to enforce the timeout
        using (var cancellationTokenSource = new CancellationTokenSource(timeout))
        {
            try
            {
                // Start a new thread to execute the function
                var thread = new Thread(() =>
                {
                function();
                });
                thread.Start();

                // Wait for the function to complete or timeout
                if (!thread.Join(timeout))
                {
                    // If the function did not complete within the timeout, throw a TimeoutException
                    cancellationTokenSource.Cancel();
                    MessageBox.Show("TimeOut", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            // Function completed within the timeout
            return true;
            }
            catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // Handle other types of exceptions
                cancellationTokenSource.Cancel();
                throw;
            }
        }
    }

    #endregion
}

