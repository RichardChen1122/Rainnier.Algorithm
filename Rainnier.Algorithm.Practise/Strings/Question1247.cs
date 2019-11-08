using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.Practise.Strings
{

    /// <summary>
    /// weiwancheng
    /// </summary>
    // 有两个长度相同的字符串 s1 和 s2，且它们其中 只含有 字符 "x" 和 "y"，你需要通过「交换字符」的方式使这两个字符串相同。

    //每次「交换字符」的时候，你都可以在两个字符串中各选一个字符进行交换。

    //交换只能发生在两个不同的字符串之间，绝对不能发生在同一个字符串内部。也就是说，我们可以交换 s1[i] 和 s2[j]，但不能交换 s1[i] 和 s1[j]。

    //最后，请你返回使 s1 和 s2 相同的最小交换次数，如果没有方法能够使得这两个字符串相同，则返回 -1 。

    //示例 1：

    //输入：s1 = "xx", s2 = "yy"
    //输出：1
    //解释：
    //交换 s1[0] 和 s2[1]，得到 s1 = "yx"，s2 = "yx"。
    //示例 2：

    //输入：s1 = "xy", s2 = "yx"
    //输出：2
    //解释：
    //交换 s1[0] 和 s2[0]，得到 s1 = "yy"，s2 = "xx" 。
    //交换 s1[0] 和 s2[1]，得到 s1 = "xy"，s2 = "xy" 。
    //注意，你不能交换 s1[0] 和 s1[1] 使得 s1 变成 "yx"，因为我们只能交换属于两个不同字符串的字符。
    //示例 3：

    //输入：s1 = "xx", s2 = "xy"
    //输出：-1
    //示例 4：

    //输入：s1 = "xxyyxyxyxx", s2 = "xyyxyxxxyx"
    //输出：4


    //提示：
    //1 <= s1.length, s2.length <= 1000
    //s1, s2 只包含'x' 或 'y'。

    public class Question1247
    {
        //我自己的实现
        public int MinimumSwap(string s1, string s2)
        {
            int switchCount = 0;
            if (s1.Length != s2.Length)
            {
                return -1;
            }

            char[] charlist1 = s1.ToCharArray();
            var charlist2 = s2.ToCharArray();

            int xcount = 0;
            int ycount = 0;

            for (int i = 0; i < charlist1.Length; i++)
            {
                if (charlist1[i] == 'x')
                {
                    xcount++;
                }

                if (charlist1[i] == 'y')
                {
                    ycount++;
                }

            }
            for (int i = 0; i < charlist2.Length; i++)
            {
                if (charlist2[i] == 'x')
                {
                    xcount++;
                }
                if (charlist2[i] == 'y')
                {
                    ycount++;
                }

            }

            if (xcount % 2 == 0 && ycount % 2 == 0)
            {
                int p = 0;
                char temp;
                while (p < charlist1.Length)
                {
                    if (charlist1[p] != charlist2[p])
                    {
                        int finder = p + 1;
                        while (finder < charlist1.Length)
                        {
                            //寻找最佳替换点
                            if (charlist1[finder] == charlist1[p] && charlist2[finder] == charlist2[p])
                            {
                                temp = charlist1[finder];
                                charlist1[finder] = charlist2[p];
                                charlist2[p] = temp;
                                switchCount++;
                                break;
                            }
                            finder++;
                        }
                        //说明没有找到，需要寻找次佳点进行替换
                        if (finder == charlist1.Length)
                        {
                            finder = p + 1;
                            while (finder < charlist1.Length)
                            {
                                if(charlist1[finder] == charlist1[p])
                                {
                                    temp = charlist1[finder];
                                    charlist1[finder] = charlist2[p];
                                    charlist2[p] = temp;
                                    switchCount++;
                                    break;
                                }
                                finder++;
                            }
                            
                            if (finder == charlist1.Length)
                            {
                                finder = p + 1;
                                while (finder < charlist2.Length)
                                {
                                    if (charlist2[finder] == charlist1[p])
                                    {
                                        //交换，但这次交换并不能导致p 进位， 故p--
                                        temp = charlist2[finder];
                                        charlist2[finder] = charlist1[p + 1];
                                        charlist1[p + 1] = temp;
                                        switchCount++;

                                        p--;
                                        break;
                                    }
                                    finder++;
                                }
                            }
                        }
                    }
                    p++;
                }

                return switchCount;
            }
            return -1;
        }

        //大神的实现
        public int minimumSwap(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return -1;
            int cnt1 = 0, cnt2 = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (s1[i] == 'x')
                        cnt1++;
                    else
                        cnt2++;
                }
            }
            if ((cnt1 + cnt2) % 2 == 1)
                return -1;
            cnt1 = (cnt1 % 2 == 0) ? cnt1 / 2 : cnt1 / 2 + 1;
            cnt2 = (cnt2 % 2 == 0) ? cnt2 / 2 : cnt2 / 2 + 1;
            return cnt1 + cnt2;

        }
    }
}
