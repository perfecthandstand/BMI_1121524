using System;
using System.Drawing;
using System.Windows.Forms;

namespace BMI計算機
{
    public partial class frmBMI : Form
    {
        public frmBMI()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            [cite_start]
            bool isHeightValid = double.TryParse(txtHeight.Text, out double height);
            bool isWeightValid = double.TryParse(txtWeight.Text, out double weight);

            [cite_start]
            if (isHeightValid) {
                if (height <= 0) {
                    MessageBox.Show("身高必須大於零。", "身高值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            } else {
                MessageBox.Show("請輸入有效的身高數值。", "身高值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            [cite_start]
            if (isWeightValid) {
                if (weight <= 0) {
                    MessageBox.Show("體重必須大於零。", "體重值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            } else {
                MessageBox.Show("請輸入有效的體重數值。", "體重值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            [cite_start]
            [cite_start]
            height = height / 100;
            [cite_start]
            double bmi = weight / (height * height);

            [cite_start]
            string[] strResultList = { "體重過輕", "健康體位", "體位過重", "輕度肥胖", "中度肥胖", "重度肥胖" };
            Color[] colorList = { Color.Blue, Color.Green, Color.Orange, Color.DarkOrange, Color.Red, Color.Purple };

            [cite_start]
            string strResult = "";
            Color colorResult = Color.Black;
            int resultIndex = 0;

            if (bmi < 18.5) {
                resultIndex = 0;
            } else if (bmi < 24) {
                resultIndex = 1;
            } else if (bmi < 27) {
                resultIndex = 2;
            } else if (bmi < 30) {
                resultIndex = 3;
            } else if (bmi < 35) {
                resultIndex = 4;
            } else {
                resultIndex = 5;
            }

            [cite_start]
            strResult = strResultList[resultIndex];
            colorResult = colorList[resultIndex];
            
            [cite_start]
            lblResult.Text = $"{bmi:F2} ({strResult})";
            lblResult.BackColor = colorResult;
            
           
            lblResult.ForeColor = Color.White; 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHeight.Clear();
            txtWeight.Clear();
            lblResult.Text = "";
            lblResult.BackColor = SystemColors.Control;
            txtHeight.Focus(); 
        }
    }
}
