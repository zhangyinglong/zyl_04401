using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApplicationTest.utility
{
    abstract class PhoneManager
    {
        /*
            中国电信行业发布中国3G号码段:
            中国移动188,187，157
            中国联通185,186
            中国电信189,180
            中国移动号码段：139、138、137、136、135、134、159、158、157（3G）、152、151、150、188（3G）、187（3G）;14个号段，但2G号段可以转3G资费套餐
            中国联通号码段：130、131、132、155、156（3G）、186（3G）、185（3G）;6个号段，但2G号段可以转3G资费套餐
            中国电信号段：133、153、189（3G）、180（3G）
            中国移动手机号段:
            2G号段(GSM网络)：139,138,137,136,135,134(0-8),159,158,152,151,150
            3G号段(TD-SCDMA网络)：157,188,187
            另外，147是移动TD上网卡专用号段.
            中国联通号段:
                 2G号段(GSM网络)：130,131,132,155,156    但2G号段可以转3G资费套餐
                 3G号段(WCDMA网络)：186,185
            电信:
                 2G号段(CDMA网络)：133,153
                 3G号段(CDMA网络)：189,180
         */
        public static bool IsMobilePhone(string phoneNum)
        {
            return Regex.IsMatch(phoneNum, @"^((13[4-9]{1})|(15[0-2]{1})|(15([7-9]){1})|(18[7-8]{1}))+\d{8}$");
        }

        public static bool IsValidEmail(string strIn)
        {
            return Regex.IsMatch(strIn, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))"+
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }
    }
}
