using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hw6
{
    public partial class Form1 : Form
    {
        private Shape3D[] shapeArr=new Shape3D[100];
        private static double[] densityArr = { 2.7, 7.87, 11.3 };
        public Form1()
        {
            InitializeComponent();
            cbox_ShapeSelect.SelectedIndex = 0;
            cbox_MaterialSelect.SelectedIndex = 0;
        }

        private void cbox_ShapeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbox_ShapeSelect.SelectedIndex)
            {
                case 0:
                    lbl_Para1.Text = "半徑";
                    lbl_Para2.Visible = false;
                    txt_Para2.Visible = false;
                    break;
                case 1:
                    lbl_Para1.Text = "邊長";
                    lbl_Para2.Visible = false;
                    txt_Para2.Visible = false;
                    break;
                case 2:
                    lbl_Para1.Text = "半徑";
                    lbl_Para2.Text = "高";
                    lbl_Para2.Visible = true;
                    txt_Para2.Visible = true;
                    break;
                case 3:
                    lbl_Para1.Text = "邊長";
                    lbl_Para2.Text = "高";
                    lbl_Para2.Visible = true;
                    txt_Para2.Visible = true;
                    break;
                default:
                    break;

            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            int amount = Shape3D.Amount;

            double density = densityArr[cbox_MaterialSelect.SelectedIndex];

            switch (cbox_ShapeSelect.SelectedIndex)
            {
                case 0:
                    shapeArr[amount] = new Ball(double.Parse(txt_Para1.Text), density);
                    break;
                case 1:
                    shapeArr[amount] = new Cube(double.Parse(txt_Para1.Text), density);
                    break;
                case 2:
                    shapeArr[amount] = new Cylinder(double.Parse(txt_Para1.Text), double.Parse(txt_Para2.Text),density);
                    break;
                case 3:
                    shapeArr[amount] = new Pyramid(double.Parse(txt_Para1.Text), double.Parse(txt_Para2.Text), density);
                    break;
                default:
                    break;
            }
            txt_Message.AppendText(shapeArr[amount].ShapeProperty()+Environment.NewLine);
            txt_AmountOfShape.Text = Shape3D.Amount.ToString();
        }

        private void btn_Calculate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Shape3D.Amount;i++ )
            {
                string str = (shapeArr[i].ShowVolumeWeight() + Environment.NewLine);
                txt_Display.AppendText(str);
            }
        }
    }
}
