using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment2
{
    public partial class PieChartControl : UserControl
    {
        private List<float> numbers = new List<float>();

        public PieChartControl()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(PieChartControl_Paint);
        }

        // Public method to set the data
        public void SetData(List<float> data)
        {
            numbers = data;
            Invalidate(); // Forces the control to redraw
        }

        // Method that draws the pie chart when the control is painted
        private void PieChartControl_Paint(object sender, PaintEventArgs e)
        {
            if (numbers.Count == 0)
                return;

            Graphics g = e.Graphics;
            g.Clear(this.BackColor);

            // Calculate the angles for the pie slices
            List<float> angles = CalculateAngles(numbers);

            // Define the rectangle that bounds the pie chart
            Rectangle rect = new Rectangle(10, 10, this.Width - 20, this.Height - 20);

            // List of colors for the pie slices
            Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Orange, Color.Purple, Color.Cyan };

            // Start angle for the first pie slice
            float startAngle = 0;

            // Draw each slice and add the legend
            for (int i = 0; i < angles.Count; i++)
            {
                // Set the brush color
                Brush brush = new SolidBrush(colors[i % colors.Length]);

                // Draw the slice
                g.FillPie(brush, rect, startAngle, angles[i]);

                // Calculate the middle angle for the slice
                float midAngle = startAngle + (angles[i] / 2);

                // Convert angle to radians and calculate the label position (slightly outside the pie chart)
                float labelX = (float)(rect.X + rect.Width / 2 + Math.Cos(midAngle * Math.PI / 180) * (rect.Width / 3));
                float labelY = (float)(rect.Y + rect.Height / 2 + Math.Sin(midAngle * Math.PI / 180) * (rect.Height / 3));

                // Draw the legend text showing the value of each slice
                g.DrawString(numbers[i].ToString(), new Font("Arial", 10), Brushes.Black, new PointF(labelX, labelY));

                // Update the start angle for the next slice
                startAngle += angles[i];
            }
        }

        // Calculate the angles (in degrees) for each pie slice
        private List<float> CalculateAngles(List<float> numbers)
        {
            float total = numbers.Sum();
            return numbers.Select(n => (n / total) * 360).ToList();
        }

        private void PieChartControl_Load(object sender, EventArgs e)
        {

        }
    }
}
