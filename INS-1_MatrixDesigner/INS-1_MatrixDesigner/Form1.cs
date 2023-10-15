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
using Newtonsoft.Json;



namespace INS_1_MatrixDesigner
{
    public partial class Form1 : Form
    {
        //const int cols = 8;
        // const int rows = 8;
        int rows;
        int cols;
        int numOfDisplays;
        int currentLineDisplayed = 0;
        uint header = 0;

        //uint[] code = new uint[rows];   //array that holds our data
        List<List<uint>> code;
        List<List<List<uint>>> allCodes = new List<List<List<uint>>>();
        //maybe try a list if we need it to be dynamiclly sized.
        public int numOfButtons = 0;
        public Form1()
        {
            InitializeComponent();

        }
        #region buttonEvents
        private void ledbtn_Click(object sender, EventArgs e)
        {
            this.outTextBox.Text = ((RoundButton)sender).Name;  //this is the button name
            toggleColor(sender);
            updateCode();
        }
        private void ledrowcolbtn_Click(object sender, EventArgs e) //buttons to affect entire rows and cols
        {
            if ((((Button)sender).Name).Split('-')[0] == "ledrow")   //rows
            {
                var controls = this.Controls.OfType<RoundButton>().Where(r => r.Top == ((Button)sender).Top);   //get all buttons that match the y pos
                foreach (RoundButton btn in controls)
                {
                    if (btn.BackColor.Equals(System.Drawing.ColorTranslator.FromHtml("#290900")))
                    {
                        btn.BackColor = Color.Orange;
                    }
                    else
                    {
                        btn.BackColor = System.Drawing.ColorTranslator.FromHtml("#290900");
                    }
                }
            }
            else  //cols
            {
                var controls = this.Controls.OfType<RoundButton>().Where(r => r.Left == ((Button)sender).Left); //get all buttons that match the x pos
                foreach (RoundButton btn in controls)
                {
                    if (btn.BackColor.Equals(System.Drawing.ColorTranslator.FromHtml("#290900")))
                    {
                        btn.BackColor = Color.Orange;
                    }
                    else
                    {
                        btn.BackColor = System.Drawing.ColorTranslator.FromHtml("#290900");
                    }
                }
            }

            updateCode();
        }
        private void nextbtn_Click(object sender, EventArgs e)  //append the code into the textbox output
        {
            updateCode();

            // Create a deep copy of the code list
            List<List<uint>> codeCopy = new List<List<uint>>();
            foreach (var display in code)
            {
                List<uint> displayCopy = new List<uint>(display);
                codeCopy.Add(displayCopy);
            }

            // Add the copied code to the allCodes list at the correct index
            allCodes.Insert(currentLineDisplayed, codeCopy);

            currLineTxtBox.Text = currentLineDisplayed.ToString();
            currentLineDisplayed++;

            updateOutputBox();
           
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            var controls = this.Controls.OfType<RoundButton>().Where(r => r.BackColor == Color.Orange);   //get all buttons that are orange
            foreach (RoundButton btn in controls)
            {
                btn.BackColor = System.Drawing.ColorTranslator.FromHtml("#290900");
            }
            updateCode();
        }
        #endregion


        public void updateCode()    //update the outTextBox with the new code
        {

            var clickedBtns = this.Controls.OfType<RoundButton>().Where(r => r.BackColor == Color.Orange);   //get all buttons that are orange
            foreach (RoundButton btn in clickedBtns)
            {
                int row = Int32.Parse((btn.Name.Split('-')[1]));
                int col = Int32.Parse((btn.Name.Split('-')[2]));
                int display = Int32.Parse((btn.Name.Split('-')[3]));
                code[display][row] = code[display][row] | (1u << col);   //or to get bit
            }

            var notClickedBtns = this.Controls.OfType<RoundButton>().Where(r => r.BackColor == System.Drawing.ColorTranslator.FromHtml("#290900"));   //get all buttons that are orange
            foreach (RoundButton btn in notClickedBtns)
            {
                int row = Int32.Parse((btn.Name.Split('-')[1]));
                int col = Int32.Parse((btn.Name.Split('-')[2]));
                int display = Int32.Parse((btn.Name.Split('-')[3]));
                code[display][row] = code[display][row] & (0xFFFFFFFF ^ (1u << col)); //xor to get rid of bit
                //we and the code with a bitmask that includes any unset bits as a 0. everthing else is 1, so we dont erase it
            }

            String ledCode = "";
            for (int j = code.Count - 1; j >= 0; j--)
            //for (int j = 0; j < code.Count; j++) //changed to swap which display is first in the array
            {
                if (packingCheckBox.Checked)
                {
                    List<uint> packedCode = PackBits(code[j], cols);
                    for (int i = 0; i < packedCode.Count; i++)
                    {
                        if (binaryRadioButton.Checked)
                        {
                            ledCode += "0b" + (Convert.ToString((packedCode[i]), 2)).PadLeft(32, '0') + ",\r\n";
                        }
                        if (hexRadioButton.Checked)
                        {
                            ledCode += "0x" + (Convert.ToString((packedCode[i]), 16)).PadLeft(8, '0') + ",\r\n";
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < code[j].Count; i++)
                    {
                        if (binaryRadioButton.Checked)
                        {
                            ledCode += "0b" + (Convert.ToString((code[j][i]), 2)).PadLeft(cols, '0') + ",\r\n";
                            //ledCode += "0b" + (Convert.ToString(ReverseBits(code[j][i]), 2)).PadLeft(cols, '0') + ",\r\n";
                        }
                        if (hexRadioButton.Checked)
                        {
                            ledCode += "0x" + (Convert.ToString((code[j][i]), 16)).PadLeft((cols / 4), '0') + ",\r\n";
                        }
                    }
                }
            }
            this.outTextBox.Text = ledCode;
        }
        private void updateOutputBox()
        {
            header = ((uint)allCodes.Count() << 16 & 0xFFFF0000 )| ((uint)frameDelayUpDown.Value & 0x0000FFFF);
            this.outLines.Text = "{0x" + (Convert.ToString(header, 16)).PadLeft(8, '0')  + ",\r\n";
            
            String textCode = "";
            foreach (List<List<uint>> codeItem in allCodes) {
                for (int j = codeItem.Count - 1; j >= 0; j--)
                //for (int j = 0; j < codeItem.Count; j++) //changed to swap which display is first in the array
                {
                    List<uint> packedCode = PackBits(codeItem[j], cols);
                    for (int i = 0; i < packedCode.Count; i++)
                    {
                        textCode += "0x" + (Convert.ToString((packedCode[i]), 16)).PadLeft(8, '0') + ",";
                    }
                }
                this.outLines.AppendText((textCode + ",\r\n").Replace(",,", ","));
                textCode = "";
            }
            string textBoxText = outLines.Text;

            // Check if there's at least one comma in the text.
            int lastCommaIndex = textBoxText.LastIndexOf(',');
            if (lastCommaIndex >= 0)
            {
                // Replace the last comma with a closing curly brace.
                textBoxText = textBoxText.Remove(lastCommaIndex, 1).Insert(lastCommaIndex, "}");

                // Update the TextBox text.
                outLines.Text = textBoxText;
            }
        }

        public uint ReverseBits(uint num)
        {
            int NO_OF_BITS = cols;
            uint reverse_num = 0;
            int i;
            for (i = 0; i < NO_OF_BITS; i++)
            {
                if ((num & (1u << i)) != 0)
                    reverse_num
                        |= 1u << ((int)(NO_OF_BITS - 1) - i);
            }

            // Return the reversed number
            return reverse_num;
        }
        private void toggleColor(object sent)
        {
            //Button clickedButton = (Button)sent;
            if (((Button)sent).BackColor.Equals(System.Drawing.Color.Orange))
            {
                ((Button)sent).BackColor = System.Drawing.ColorTranslator.FromHtml("#290900");
            }
            else
            {
                ((Button)sent).BackColor = Color.Orange;
            }
        }


        private void makeGridButton_Click(object sender, EventArgs e)
        {

            nextbtn.Enabled = true;
            clearButton.Enabled = true;
            packingCheckBox.Enabled = true;
            panel1.Visible = false;
            rows = (int)rowsUpDown.Value;
            cols = (int)colsUpDown.Value;
            numOfDisplays = (int)numOfDisplaysUpDown.Value;
            numOfButtons = addButtons(rows, cols, numOfDisplays);   //add the grid of buttons
            code = new List<List<uint>>();

            for (int i = 0; i < numOfDisplays; i++)
            {
                code.Add(new List<uint>(new uint[rows]));
            }

            //for (int i=0; i < rows; i++)
            //{
            //code.Add(0);
            //}

        }

        #region newPackBits
        //THanks chatGPT for this method
        static List<uint> PackBits(List<uint> sourceBits, int packedBitSize)
        {
            List<uint> packedList = new List<uint>();
            uint packedValue = 0;
            int bitCounter = 0;

            foreach (uint sourceValue in sourceBits)
            {
                int remainingBits = packedBitSize;
                uint value = sourceValue & ((1u << packedBitSize) - 1);

                while (remainingBits > 0)
                {
                    int bitsToCopy = Math.Min(remainingBits, 32 - bitCounter);
                    packedValue |= (uint)(value & ((1 << bitsToCopy) - 1)) << bitCounter;

                    remainingBits -= bitsToCopy;
                    bitCounter += bitsToCopy;

                    if (bitCounter == 32)
                    {
                        packedList.Add(packedValue);
                        packedValue = 0;
                        bitCounter = 0;
                    }

                    value >>= bitsToCopy;
                }
            }

            if (bitCounter > 0)
            {
                packedList.Add(packedValue);
            }

            return packedList;
        }

        #endregion


        private void downButton_Click(object sender, EventArgs e)
        {
            if (currentLineDisplayed < allCodes.Count())
            {
                if (currentLineDisplayed < allCodes.Count() - 1)
                {
                    currentLineDisplayed++;
                    currLineTxtBox.Text = currentLineDisplayed.ToString();
                    SelectButtonsFromCode(allCodes[currentLineDisplayed]);
                    updateCode();
                    HighlightSpecificLine(currentLineDisplayed + 1);
                } else
                {
                    currentLineDisplayed++;
                    currLineTxtBox.Text = currentLineDisplayed.ToString();
                }
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            if (currentLineDisplayed > 0)
            {
                currentLineDisplayed--;
                currLineTxtBox.Text = currentLineDisplayed.ToString();
                SelectButtonsFromCode(allCodes[currentLineDisplayed]);
                updateCode();
                HighlightSpecificLine(currentLineDisplayed + 1);

            }
        }



        private void SelectButtonsFromCode(List<List<uint>> codeToCheck)
        {
            Console.WriteLine("YEP");
            foreach (RoundButton btn in this.Controls.OfType<RoundButton>())
            {
                int row = int.Parse(btn.Name.Split('-')[1]);
                int col = int.Parse(btn.Name.Split('-')[2]);
                int display = int.Parse(btn.Name.Split('-')[3]);

                // Check if the corresponding bit in the code is set (1) or not (0).
                bool isButtonSelected = ((codeToCheck[display][row] >> col) & 0x01) == 1;

                if (isButtonSelected)
                {
                    // Select the button by changing its background color to orange.
                    btn.BackColor = Color.Orange;

                }
                else
                {
                    // Deselect the button by changing its background color to the original color.
                    btn.BackColor = System.Drawing.ColorTranslator.FromHtml("#290900");
                }
            }
        }
        public Tuple<List<List<List<uint>>>, int> LoadAllCodesFromJson(string filePath)
{
    try
    {
        string json = File.ReadAllText(filePath);
        var loadedData = JsonConvert.DeserializeObject<dynamic>(json);

        if (loadedData != null)
        {
            // Extract the allCodes data and the 32-bit value from the loaded data.
            List<List<List<uint>>> allCodesData = loadedData.AllCodes.ToObject<List<List<List<uint>>>>();
            int value32Bits = loadedData.Value32Bits.ToObject<int>();

            return new Tuple<List<List<List<uint>>>, int>(allCodesData, value32Bits);
        }
}
    catch (Exception ex)
    {
        Console.WriteLine("Error loading data: " + ex.Message);
    }

    return null;
}

        public void SaveAllCodesToJson(string filePath)
        {
            try
            {
                // Create a class to store both the allCodes data and the 32-bit value.
                var dataToSave = new
                {
                    AllCodes = allCodes,
                    Value32Bits = header
                };

                string json = JsonConvert.SerializeObject(dataToSave, Formatting.Indented);
                File.WriteAllText(filePath, json);
                Console.WriteLine("Data saved to " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving data: " + ex.Message);
            }
        }


        private void savebutton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set properties of the file dialog as needed.
            saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string saveFilePath = saveFileDialog.FileName;

                try
                {
                    SaveAllCodesToJson(saveFilePath);
                    Console.WriteLine("Data saved to " + saveFilePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving data: " + ex.Message);
                }
            }
        }

        private void openbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set properties of the file dialog as needed.
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;

                // Now, you can use the selected file path.
                // For example, you can call the function to load data from the file.
                var loadedData = LoadAllCodesFromJson(selectedFilePath);

                if (loadedData != null)
                {
                    allCodes = loadedData.Item1; // Assign the allCodes data.
                    header = (uint)loadedData.Item2; // Assign the 32-bit value to the NumericUpDown control.
                    frameDelayUpDown.Value = (header & 0xFFFF);
                    updateOutputBox();
                }
            }
        }
        private void HighlightSpecificLine(int lineNumber)
        {
            // Assuming textBox1 is the name of your TextBox control.
            TextBox textBox = outLines;

            // Check if the line number is within the valid range.
            if (lineNumber >= 0 && lineNumber < textBox.Lines.Length)
            {
                // Get the start index of the line.
                int startIndex = textBox.GetFirstCharIndexFromLine(lineNumber);

                // Get the length of the line.
                int length = textBox.Lines[lineNumber].Length;

                // Set the selection to highlight the line.
                textBox.Select(startIndex, length);

                // Set the focus to the TextBox to ensure the selection is visible.
                textBox.Focus();
            }
        }


        private void removeFrameBtn_Click(object sender, EventArgs e)
        {
            if (allCodes.Count() > 1 && currentLineDisplayed < allCodes.Count() )
            {
                allCodes.RemoveAt(currentLineDisplayed);
                updateOutputBox();
            }
        }
    }
}
