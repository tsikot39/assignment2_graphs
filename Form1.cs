using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace assignment2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            // Get input from the TextBox
            string input = txtInput.Text;

            // Parse the input and validate
            List<float> numbers = ParseInput(input);

            // If the input is valid, draw the pie chart
            if (numbers.Count > 0)
            {
                pieChartControl1.SetData(numbers);
            }
        }

        // Parse the input from the TextBox and convert it to a list of numbers
        private List<float> ParseInput(string input)
        {
            try
            {
                var numbers = input.Split(',')
                                   .Select(n => float.Parse(n.Trim()))
                                   .ToList();
                return numbers;
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input. Please enter comma-separated numbers.");
                return new List<float>();
            }
        }

        private void pieChartControl1_Load(object sender, EventArgs e)
        {

        }
    }

}

