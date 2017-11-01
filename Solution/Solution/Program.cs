﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            Day19();
        }



        // https://www.hackerrank.com/challenges/30-interfaces/problem
        static void Day19()
        {
            int n = Int32.Parse(Console.ReadLine());
            AdvancedArithmetic myCalculator = new Calculator();
            int sum = myCalculator.divisorSum(n);
            Console.WriteLine("I implemented: AdvancedArithmetic\n" + sum);

        }

        // https://www.hackerrank.com/challenges/30-queues-stacks/problem
        static void Day18()
        {
            // read the string s.
            string s = Console.ReadLine();

            // create the Solution class object p.
            Solution obj = new Solution();

            // push/enqueue all the characters of string s to stack.
            foreach (char c in s)
            {
                obj.pushCharacter(c);
                obj.enqueueCharacter(c);
            }

            bool isPalindrome = true;

            // pop the top character from stack.
            // dequeue the first character from queue.
            // compare both the characters.
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (obj.popCharacter() != obj.dequeueCharacter())
                {
                    isPalindrome = false;

                    break;
                }
            }

            // finally print whether string s is palindrome or not.
            if (isPalindrome)
            {
                Console.Write("The word, {0}, is a palindrome.", s);
            }
            else
            {
                Console.Write("The word, {0}, is not a palindrome.", s);
            }
        }
  


        static void Day17()
        {
            Calculator myCalculator = new Calculator();
            int T = Int32.Parse(Console.ReadLine());
            while (T-- > 0)
            {
                string[] num = Console.ReadLine().Split();
                int n = int.Parse(num[0]);
                int p = int.Parse(num[1]);
                try
                {
                    int ans = myCalculator.power(n, p);
                    Console.WriteLine(ans);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }

        }


        // https://www.hackerrank.com/challenges/30-exceptions-string-to-integer/problem
        static void Day16()
        {
            string S = Console.ReadLine();
            int i = 0;
            
            try
            {
                i = Convert.ToInt32(S);
                Console.WriteLine(i.ToString());
            }
            catch (Exception)
            {
                Console.WriteLine("Bad String");
                throw;
            }
        }


        static void Parse()
        {
            var ExpectedItems = new List<String>(new string[] {
                "1Received threat detection callback from ARW SDK &&& Arw.Cryptor.exe",
                "1File was successfully classified. &&& Arw.Cryptor.exe",
                "Quarantining &&& Arw.Cryptor.exe",
                "Cleaning file &&& Arw.Cryptor.exe",
                "Deleting file &&& Arw.Cryptor.exe",
                "Verifying &&& Cryptor &&& has been deleted with DDA",
                "Succeeded cleaning file &&& Arw.Cryptor.exe",
                "Succeeded quarantining File &&& Arw.Cryptor.exe",
                "Firing quarantine item added &&& Arw.Cryptor.exe",
                "Scheduling delete file &&& Arw.Cryptor.exe",
                "The detected file is NOT whitelisted &&& Arw.Cryptor.exe",
                "Sending JSON data to DSE ransomware &&&",
                "Received a results callback from ARW SDK &&& Arw.Cryptor.exe",
                "File was successfully classified &&& Arw.Cryptor.exe",
                // "Response body from Cosmos URL request &&& uploadUrl",
                "Formed ZIP filename for upload to Cosmos: C:\\PROGRAMDATA\\MALWAREBYTES\\MBAMSERVICE\\tmp\\ &&&",
                "Uploading file: C:\\PROGRAMDATA\\MALWAREBYTES\\MBAMSERVICE\\tmp\\ &&&",
                "Successfully sent the detected file and info to server. &&&",
                "Successfully sent detection data with UUID: &&&",
                "Response body from Hubble request: &&&",
            });

            string LogFile = @"C:\ProgramData\Malwarebytes\MBAMService\logs\MBAMSERVICE.LOG";
            var mylog = "C:\\Users\\Public\\LogFile.mine";
            var extension = Path.GetExtension(LogFile);
            bool passed;
            bool found = false;
            string missedStrings = "";

            char Delimiter = '\t';
            string rawData = CombineLogFiles(LogFile, extension, mylog);
            int passedCnt = 0;

            foreach (var item in ExpectedItems)
            {
                var SplitLine = Regex.Split(item, "&&&");
                found = false;

                foreach (var match in File.ReadLines(mylog)
                              .Select((text, index) => new { text })
                              .Where(x => x.text.Contains(SplitLine[0].Trim()))
                              .Where(x => x.text.Contains(SplitLine[1].Trim())))
                { 
                    passedCnt++;
                    found = true;
                    break;                   
                }

                if (!found)
                {
                    //Console.WriteLine(string.Format("Did not find: {0} : {1}", SplitLine[0], SplitLine[1]));
                    missedStrings += SplitLine[0] + " " + SplitLine[1] + "\n";
                }

                if( passedCnt == ExpectedItems.Count)
                {
                    passed = true;
                }
                
            }
            Console.WriteLine(missedStrings);
        }

        static public string CombineLogFiles(string LogFile, string Extension, string MyLog)
        {
            var allFiles = Directory.GetFiles(Path.GetDirectoryName(LogFile));
            var rawData = "";
            foreach (var f in allFiles)
            {
                if (f.Contains(Extension))
                {
                    //Debug.WriteLine("==== Copying file: {0} (size: {1})", f, new FileInfo(f).Length);
                    File.Copy(f, MyLog, true);
                    rawData += File.ReadAllText(MyLog, System.Text.Encoding.Default);
                }
            }
            return rawData;
        }

        public string CopyLogFile(string LogFile, string MyLog)
        {
            string rawData = "";
            //Debug.WriteLine("==== Copying file: {0} (size: {1})", LogFile, new FileInfo(LogFile).Length);
            File.Copy(LogFile, MyLog, true);
            rawData = File.ReadAllText(MyLog, System.Text.Encoding.Default);
            return rawData;
        }

        // https://www.hackerrank.com/challenges/30-linked-list
        public static void display(Node head)
        {
            Node start = head;
            while (start != null)
            {
                Console.Write(start.data + " ");
                start = start.next;
            }
        }
        public static Node insert(Node head, int data)
        {
            //Complete this method
            if (head == null)
                return new Node(data);
            else if (head.next == null)
            {
                head.next = new Node(data);
            }
            else
            {
                insert(head.next, data);
            }


            return head;

        }

        static void Day15()
        {

        }


        // https://www.hackerrank.com/challenges/30-arrays?h_r=email&unlock_token=c921f2f3c6df8835987b057de9f36b32e5b2e8a8&utm_campaign=30_days_of_code_continuous&utm_medium=email&utm_source=daily_reminder
        static void Day7()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            string output = "";

            for (int i = n - 1; i >= 0; i--)
            {
                output += arr[i] + " ";
            }
            Console.WriteLine(output);
        }


        // https://www.hackerrank.com/challenges/30-review-loop?h_r=email&unlock_token=74657de971407cd667005ea663437a82b640aa18&utm_campaign=30_days_of_code_continuous&utm_medium=email&utm_source=daily_reminder
        static void Day6()
        {
            int num = Convert.ToInt32(Console.ReadLine());
            string[] words = new string[num];

            for (int i = 0; i < num; i++)
            {
                words[i] = Console.ReadLine();
            }
            foreach (string item in words)
            {
                string evenLetters = "";
                string oddLetters = "";

                for (int l = 0; l < item.Length; l++)
                {
                    if (l % 2 == 0)
                    {
                        evenLetters += item[l];
                    }
                    else
                    {
                        oddLetters += item[l];
                    }
                }

                Console.WriteLine(evenLetters + " " + oddLetters);
            }

        }

        //https://www.hackerrank.com/challenges/time-conversion
        static string timeConversion(string s)
        {
            // Complete this function

            string[] timeParts = s.Split(':');
            string timeOut = "";
            int hour = Convert.ToInt32(timeParts[0]);           


            if (timeParts[2].ToUpper().Contains("PM"))
            {
                if (hour != 12)
                {
                    hour += 12;
                }
            }  
            else if (hour == 12)
            {
                hour = 0;
            }

            timeOut = string.Format("{0:00}:{1:00}:{2:00}", hour, timeParts[1], timeParts[2].Substring(0, 2));
            return timeOut;
        }


        // https://www.hackerrank.com/challenges/30-loops
        static void Loops()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= 10 ; i++)
            {
                Console.WriteLine(n + " x " + i + " = " + (n * i) ) ;
            }
        }


    }




    class Person
    {
        public int age;
        public Person(int initialAge)
        {
            // Add some more code to run some checks on initialAge
            if(initialAge < 0)
            {
                Console.WriteLine("Age is not valid, setting age to 0.");
                age = 0;
            }
            else
            {
                age = initialAge;
            }
        }
        public void amIOld()
        {
            // Do some computations in here and print out the correct statement to the console 
            if (age < 13)
            {
                Console.WriteLine("You are young."); ;
            }
            else if(age >= 13 && age < 18)
            {
                Console.WriteLine("You are a teenager.");
            }
            else
            {
                Console.WriteLine("You are old.");
            }
        }

        public void yearPasses()
        {
            // Increment the age of the person in here
            age++;
        }

    }
}
