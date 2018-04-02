using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace HcVip.Web.Share
{
    public partial class Checkimage : System.Web.UI.Page
    {
        public string text = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            getString();
        }

        private void getString()
        {
            Random rand = new Random();
            int len = rand.Next(4, 6);
            char[] chars = "245679ACDEFGHJKLMNPRTUVWXYZ".ToCharArray();
            StringBuilder myStr = new StringBuilder();
            for (int iCount = 0; iCount < len; iCount++)
            {
                myStr.Append(chars[rand.Next(chars.Length)]);
            }

            string text = myStr.ToString();
            //保存验证码到 session 中以便其他模块使用

            Session["checkcode"] = text;
            Size ImageSize = Size.Empty;
            //Font myFont = new Font("MS Sans Serif", 20);
            Font myFont = new Font("Britannic Bold", 20, FontStyle.Bold);
            //计算验证码图片大小

            using (Bitmap bmp = new Bitmap(10, 10))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    SizeF size = g.MeasureString(text, myFont, 10000);
                    ImageSize.Width = (int)size.Width + 8;
                    ImageSize.Height = (int)size.Height + 8;
                }
            }

            //创建验证码图片
            using (Bitmap bmp = new Bitmap(ImageSize.Width, ImageSize.Height))
            {
                //绘制验证码文本
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    using (StringFormat f = new StringFormat())
                    {
                        f.Alignment = StringAlignment.Near;
                        f.LineAlignment = StringAlignment.Center;
                        f.FormatFlags = StringFormatFlags.NoWrap;
                        g.DrawString(text, myFont, Brushes.Black,
                                     new RectangleF(0, 0, ImageSize.Width, ImageSize.Height), f);
                    }//using
                }//using

                ////制造噪声 杂点面积占图片面积的15%
                //int num = ImageSize.Width * ImageSize.Height * 10 / 100;
                //for (int iCount = 0; iCount < num; iCount++)
                //{
                //    //在随机的位置使用随机的颜色设置图片的像素
                //    int x = rand.Next(ImageSize.Width);
                //    int y = rand.Next(ImageSize.Height);
                //    int r = rand.Next(255);
                //    int g = rand.Next(255);
                //    int b = rand.Next(255);
                //    Color c = Color.FromArgb(r, g, b);
                //    bmp.SetPixel(x, y, c);
                //}//for
                //输出图片
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                Response.ContentType = "image/png";
                ms.WriteTo(Response.OutputStream);
                ms.Close();
            }//using
            myFont.Dispose();
        }


        /// <summary>
        /// 检验指定的文本是否匹配验证码
        /// </summary>
        /// <param name="text">要判断的文本</param>
        /// <returns>是否匹配</returns>
        public static bool CheckCode(string text)
        {
            string txt = HttpContext.Current.Session["checkcode"] as string;
            return text.ToLower() == txt.ToLower();
        }
    }
}
