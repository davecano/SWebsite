using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Web.Security;
using System.Collections;
namespace Z
{
    /// <summary>
    /// 加密类
    /// </summary>
    public static class EncryptHelper
    {

        /// <summary>
        /// MD516位加密，一拓短信登陆专用
        /// </summary>
        /// <param name="ConvertString"></param>
        /// <returns></returns>
        public static string GetMd5Str(string ConvertString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8);
            t2 = t2.Replace("-", "");
            t2 = t2.ToLower();
            return t2;
        }



        #region"可逆加密"
        const string Key = "Guz(%&hj7x89H$yuBI0456FtmaT5&fvHUFCy76*h%(HilJ$lhj!y6&(*jkP87jH7";
        
        public static string ReplaceWord(string str)
        {
            return str.Replace("=", "%").Replace("+","_").Replace(" ","-");
        }
        public static string DReplaceWord(string str)
        {
            return str.Replace("-", " ").Replace("_", "+").Replace("%", "=");
        }
        /// <summary>     
        /// 获得密钥     
        /// </summary>     
        /// <returns>密钥</returns>     
        private static byte[] GetLegalKey()
        {
            string sTemp = Key;
            SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
            mobjCryptoService.GenerateKey();
            byte[] bytTemp = mobjCryptoService.Key;
            int KeyLength = bytTemp.Length;
            if (sTemp.Length > KeyLength)
                sTemp = sTemp.Substring(0, KeyLength);
            else if (sTemp.Length < KeyLength)
                sTemp = sTemp.PadRight(KeyLength, ' ');
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }
        /// <summary>     
        /// 获得初始向量IV     
        /// </summary>     
        /// <returns>初试向量IV</returns>     
        private static byte[] GetLegalIV()
        {
            string sTemp = "E4ghj*Ghg7!rNIfb&95GUY86GfghUb#er57HBh(u%g6HJ($jhWk7&!hg4ui%$hjk";
            SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
            mobjCryptoService.GenerateIV();
            byte[] bytTemp = mobjCryptoService.IV;
            int IVLength = bytTemp.Length;
            if (sTemp.Length > IVLength)
                sTemp = sTemp.Substring(0, IVLength);
            else if (sTemp.Length < IVLength)
                sTemp = sTemp.PadRight(IVLength, ' ');
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }
        /// <summary>     
        /// 加密方法     
        /// </summary>     
        /// <param name="Source">待加密的串</param>     
        /// <returns>经过加密的串</returns>     
        public static string Encode(string Source)
        {
            byte[] bytIn = UTF8Encoding.UTF8.GetBytes(Source);
            SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
            MemoryStream ms = new MemoryStream();
            mobjCryptoService.Key = GetLegalKey();
            mobjCryptoService.IV = GetLegalIV();
            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();
            ms.Close();
            byte[] bytOut = ms.ToArray();
            return ReplaceWord( Convert.ToBase64String(bytOut));
        }
        /// <summary>     
        /// 解密方法     
        /// </summary>     
        /// <param name="Source">待解密的串</param>     
        /// <returns>经过解密的串</returns>     
        public static string Decode(string Source)
        {
            Source = DReplaceWord(Source);
            byte[] bytIn = Convert.FromBase64String(Source);
            SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
            MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
            mobjCryptoService.Key = GetLegalKey();
            mobjCryptoService.IV = GetLegalIV();
            ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }

        #endregion

        /// <summary>
        /// 用于密码加密SHA1 和MD5两种方式
        /// </summary>
        /// <param name="PasswordString"></param>
        /// <param name="PasswordFormat"></param>
        /// <returns></returns>
        public static string EncryptPassword(string PasswordString, string PasswordFormat)
        {
            string encryptPassword = null;
            if (PasswordFormat == "SHA1")
            {
                encryptPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "SHA1");
            }
            else if (PasswordFormat == "MD5")
            {
                encryptPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "MD5");
            }
            return encryptPassword;
        }



    }
}
