using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.base64
{
    /*
     * http://zh.wikipedia.org/wiki/Base64 学习base64编码
    */
    public static class MyBase64
    {
        private static string base64EncodeChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";//编码后的字符集,Base64索引表
        private static int[] base64DecodeChars = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                                                             -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                                                             -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                                                             -1, -1, -1, -1, -1, -1, -1, 62, -1, -1, -1, 63,
                                                             52, 53, 54, 55, 56, 57, 58, 59, 60, 61, -1, -1,
                                                             -1, -1, -1, -1, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8,
                                                             9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                                                             21, 22, 23, 24, 25, -1, -1, -1, -1, -1, -1, 26,
                                                             27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38,
                                                             39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50,
                                                             51, -1, -1, -1, -1, -1 };//对应ASICC字符的位置

        //加密
        public static string Base64Encode(string str)
        {
            string Out = "";
            int i = 0, len = str.Length;
            char c1, c2, c3;//记录需要进行编码的3个字符
            while (i < len)
            {
                c1 = Convert.ToChar(str[i++] & 0xFF);
                if (i == len)
                {
                    Out += base64EncodeChars[c1 >> 2];//将c1右移2位，对前6位进行编码
                    Out += base64EncodeChars[(c1 & 0x3) << 4];//将前6位置空，然后左移4位凑足6位，对其编码
                    Out += "==";//用2个“=”补足位数
                    break;
                }
                c2 = str[i++];
                if (i == len)
                {
                    Out += base64EncodeChars[c1 >> 2];
                    Out += base64EncodeChars[((c1 & 0x3) << 4) | ((c2 & 0xF0) >> 4)];
                    Out += base64EncodeChars[(c2 & 0xF) << 2];
                    Out += "=";//用1个“=”补足位数
                    break;
                }
                c3 = str[i++];
                Out += base64EncodeChars[c1 >> 2];
                Out += base64EncodeChars[((c1 & 0x3) << 4) | ((c2 & 0xF0) >> 4)];
                Out += base64EncodeChars[((c2 & 0xF) << 2) | ((c3 & 0xC0) >> 6)];
                Out += base64EncodeChars[c3 & 0x3F];
            }
            return Out;
        }

        // 解密
        public static string Base64Decode(string str)
        {
            int i = 0, len = str.Length;
            string Out = "";
            while (i < len)
            {
                int c1, c2, c3, c4;//记录需要进行解码的4个字符
                do
                {
                    c1 = base64DecodeChars[str[i++] & 0xFF];
                } while (i < len && c1 == -1);
                if (c1 == -1) break;
                do
                {
                    c2 = base64DecodeChars[str[i++] & 0xFF];
                } while (i < len && c2 == -1);
                if (c2 == -1) break;
                Out += (char)((c1 << 2) | ((c2 & 0x30) >> 4));
                do
                {
                    c3 = str[i++] & 0xFF;
                    if (c3 == 61) return Out;
                    c3 = base64DecodeChars[c3];
                } while (i < len && c3 == -1);
                if (c3 == -1) break;
                Out += (char)(((c2 & 0xF) << 4) | ((c3 & 0x3C) >> 2));
                do
                {
                    c4 = str[i++] & 0xFF;
                    if (c4 == 61) return Out;
                    c4 = base64DecodeChars[c4];
                } while (i < len && c4 == -1);
                if (c4 == -1) break;
                Out += (char)(((c3 & 0x03) << 6) | c4);
            }
            return Out;
        }

        public static string utf16to8(string str)//将汉字转换为utf8编码格式
        {
            string Out = "";
            for (int i = 0, len = str.Length; i < len; i++) //根据字符的不同范围分别转化
            {
                char c = str[i];////char为16位Unicode字符,范围0~0xffff,感谢vczh提醒
                if ((c >= 0x0001) && (c <= 0x007F))
                {
                    Out += str[i];
                }
                else if (c > 0x07FF)
                {
                    Out += (char)(0xE0 | ((c >> 12) & 0x0F));
                    Out += (char)(0x80 | ((c >> 6) & 0x3F));
                    Out += (char)(0x80 | ((c >> 0) & 0x3F));
                }
                else
                {
                    Out += (char)(0xC0 | ((c >> 6) & 0x1F));
                    Out += (char)(0x80 | ((c >> 0) & 0x3F));
                }
            }
            return Out;
        }

        public static string utf8to16(string str)
        {
            string Out = "";
            int i = 0, len = str.Length;
            char c, char2, char3;
            while (i < len)
            {
                c = str[i++];
                switch (c >> 4)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        {
                            Out += str[i - 1];
                            break;
                        }
                    case 12:
                    case 13:
                        {
                            char2 = str[i++];
                            Out += (char)(((c & 0x1F) << 6) | (char2 & 0x3F));
                            break;
                        }
                    case 14:
                        {
                            char2 = str[i++];
                            char3 = str[i++];
                            Out += (char)(((c & 0x0F) << 12) | ((char2 & 0x3F) << 6) | ((char3 & 0x3F) << 0));
                            break;
                        }
                }
            }
            return Out;
        }

        public static void base64Test()
        {
            string str = "Man is distinguished, not only by his reason, but by this singular passion from other animals, which is a lust of the mind, that by a perseverance of delight in the continued and indefatigable generation of knowledge, exceeds the short vehemence of any carnal pleasure.";
            Console.WriteLine("test base64encode = {0}", Base64Encode(str));
            Console.WriteLine("test base64decode = {0}", Base64Decode(Base64Encode(str)));

            string str1 = "张应龙";
            Console.WriteLine("test base64encode = {0}", Base64Encode(utf16to8(str1)));
            Console.WriteLine("test base64decode = {0}", utf8to16(Base64Decode(Base64Encode(utf16to8(str1)))));

            Console.WriteLine("{0}", base64DecodeChars.Length);
        }
    }
}
