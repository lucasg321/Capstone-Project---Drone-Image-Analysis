using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;


namespace EmguCVTest2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Image<Bgr, byte> imgInput = new Image<Bgr, byte>("d:\\Visual Studio Projects\\droneviewoffarmland.jpg");

        Image<Gray, byte> gray_image; //for gray scale images

        Bgr[] imgBgr = new Bgr[2073600];


        Bgr compare_color_1 = new Bgr(10, 223, 220); //Brown shade 1 -- there will be over 300 here eventually to compare with
       

        private void button1_Click(object sender, EventArgs e)
        {
            imageBox1.Image = imgInput;

            //imageBox2.Image = imgInput.InRange(new Bgr(10, 0, 0),  // min filter value ( if color is greater than or equal to this)
             //                                    new Bgr(20, 255, 255)); // max filter value ( if color is less than or equal to this)
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0, j = 0;

            //gray_image = imgInput.Convert<Gray, byte>();

            byte[,,] pixeldata = imgInput.Data;      //use this inside of for loops and while loops since it is much faster in C#, rather than using imgInput.Data on its own


            //pixeldata[i, j, 0] = 0; //blue
            // pixeldata[i, j, 1] = 0; //green 
            // pixeldata[i, j, 2] = 0; //red

            imgBgr[0] = imgInput[0, 0];

            //imgBgr[0] = imgInput[0, 0]; grab pixels directly
            // Color pixel_color = Color.FromArgb(imgInput.Data[0, 0, 0], set to color variable instead
            // imgInput.Data[0, 0, 1], imgInput.Data[0, 0, 2]);

            Image<Bgr, byte> resizedimg = imgInput.Resize(1280, 720, Emgu.CV.CvEnum.Inter.Cubic); //resizing image cubicly down to 1280 x 720 pixels

            imageBox1.Image = resizedimg;

            for (i = 0; i < 550; i++) //loop by pixel size of picture, xsize 
            {
                for (j = 0; j < 1000; j++)//loop by pixel size of picture, ysize 
                { //if all three bgr values of the current pixel and the predetermined color match, then it is true
                    if ((pixeldata[i, j, 0] == compare_color_1.Blue) && (pixeldata[i, j, 1] == compare_color_1.Green) && (pixeldata[i, j, 2] == compare_color_1.Red)) 
                    {
                        imgInput[i, j] = new Bgr(0,0,255); //changes the current pixel to red if true

                    }

                }

                

            }
         imageBox1.Image = imgInput; //display the new image to output

        }
    }
}
