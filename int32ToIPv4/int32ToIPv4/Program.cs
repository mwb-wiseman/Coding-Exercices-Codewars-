using System;
using System.Collections.Generic;

namespace int32ToIPv4
{
    internal class Program
    {
        /// <summary>
        /* Take the following IPv4 address: 128.32.10.1
        This address has 4 octets where each octet is a single byte (or 8 bits).
        1st octet 128 has the binary representation: 10000000
        2nd octet 32 has the binary representation: 00100000
        3rd octet 10 has the binary representation: 00001010
        4th octet 1 has the binary representation: 00000001
        So 128.32.10.1 == 10000000.00100000.00001010.00000001

        Because the above IP address has 32 bits, we can represent it as the unsigned 32 bit number: 2149583361

        Complete the function that takes an unsigned 32 bit number and returns a string representation of its IPv4 address.*/
        /// </summary>
    
        static void Main(string[] args)
        {
            uint test = 1342564865;

            Console.WriteLine(UInt32ToIP(test));

            Console.Read();
        }

        public static string UInt32ToIP(uint ip)
        {
            string octet1 = "";
            string octet2 = "";
            string octet3 = "";
            string octet4 = "";
            string ipBinaryString = Convert.ToString(ip, 2).PadLeft(32,'0');
            string result;

            // Console.WriteLine("User input IP: " + ip);
            // Console.WriteLine("ipBinaryString: " + ipBinaryString);

            if(ip == 0)
            {
                result = "0.0.0.0";
            }
            else
            {
                for (int i = 0; i < ipBinaryString.Length; i++)
                {
                    if (i <= 7)
                    {
                        octet1 += ipBinaryString[i];
                    }
                    else if (i <= 15)
                    {
                        octet2 += ipBinaryString[i];
                    }
                    else if (i <= 23)
                    {
                        octet3 += ipBinaryString[i];
                    }
                    else
                    {
                        octet4 += ipBinaryString[i];
                    }
                }

                // Console.WriteLine("ip32BitString split into 4 octets: " + octet1 + "." + octet2 + "." + octet3 + "." + octet4);

                result = Convert.ToInt32(octet1, 2).ToString() + "." + Convert.ToInt32(octet2, 2).ToString() + "." + Convert.ToInt32(octet3, 2).ToString() + "." + Convert.ToInt32(octet4, 2).ToString();
            }

            return result;
        }
    }
}
