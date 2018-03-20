using System;
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
            ArrayChallenge();

        }


        //https://www.hackerrank.com/challenges/arrays-ds/problem
        static void ArrayChallenge()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(arr[i]);
            }
            
        }

        // https://www.hackerrank.com/challenges/30-bitwise-and/problem
        static void Day29()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(tokens_n[0]);
                int k = Convert.ToInt32(tokens_n[1]);

                if (((k - 1) | k) > n && k % 2 == 0)
                {
                    Console.WriteLine(k - 2);
                }
                else
                {
                    Console.WriteLine(k - 1);
                }
            }

            // BitAnd(n, k);
        }


        static void BitAnd(int t, int k)
        {

            //int maxValue = 0;

            //for (int i = 1; i < n; i++)
            //{
            //    for (int j = (i + 1); j < n; j++)
            //    {
            //        int val = i & j;
            //        if (val < k && val > maxValue)
            //        {
            //            maxValue = val;
            //        }

            //    }
        //}
            //Console.WriteLine(maxValue);
        }

        // https://www.hackerrank.com/challenges/30-regex-patterns/problem
        static void Day28()
        {
            int N = 6; //  Convert.ToInt32(Console.ReadLine());
            string[] input = new string[]
            {
                "riya riya@gmail.com",
                "julia julia@julia.me",
                "julia sjulia@gmail.com",
                "julia julia@gmail.com",
                "samantha samantha@gmail.com",
                "tanya tanya@gmail.com"
            };

            List<string> lstFirstNames = new List<string>();

            for (int a0 = 0; a0 < N; a0++)
            {
                string[] tokens_firstName = input[a0].Split(' '); //  Console.ReadLine().Split(' ');
                string firstName = tokens_firstName[0];
                string emailID = tokens_firstName[1];

                if (Regex.IsMatch(emailID, "@gmail.com"))
                {
                    lstFirstNames.Add(firstName);
                }
            }
            lstFirstNames.Sort();
            foreach (var item in lstFirstNames)
            {
                Console.WriteLine(item);
            }

            // Day28();
        }


        static void Day27()
        {
            Console.WriteLine(5);
            Console.WriteLine("4 3");
            Console.WriteLine("-1 0 4 2");
            Console.WriteLine("6 1");
            Console.WriteLine("-2 -4 -5 0 3 4");
            Console.WriteLine("5 3");
            Console.WriteLine("0 -1 5 6 7");
            Console.WriteLine("3 2");
            Console.WriteLine("-9 0 10");
            Console.WriteLine("7 6");
            Console.WriteLine("-9 -8 -7 0 9 10 11");
        }


        // https://www.hackerrank.com/challenges/30-nested-logic/problem
        static void Day26()
        {
            string rDate = Console.ReadLine();
            string dDate = Console.ReadLine();
            int fine = 0;

            // D = int[0]
            // M = int[1]
            // Y = int[2]
            int[] returnedDate = SplitDate(rDate);
            int[] dueDate = SplitDate(dDate);

            // Returned after the expected year
            if (returnedDate[2] > dueDate[2])
            {
                fine = 10000;
            }
            // Returned same year
            if (returnedDate[2] < dueDate[2])
            {
                fine = 0;
            }
            // Returned after the expected month
            else if (returnedDate[1] > dueDate[1] && returnedDate[2] <= dueDate[2])
            {
                fine = 500 * (returnedDate[1] - dueDate[1]);
            }
            // Returned in the same month
            else if (returnedDate[1] == dueDate[1] )
            {
                // Returned early
                if (returnedDate[0] <= dueDate[0] && returnedDate[1] <= dueDate[1] )
                {
                    fine = 0;
                }
                else
                {
                    fine = 15 * (returnedDate[0] - dueDate[0]);
                }
            }
            
            Console.WriteLine(fine);
        }

        static private int[] SplitDate(string input)
        {
            char[] sep = { ' ' };
            string[] temp = input.Split(sep);
            int[] output = new int[temp.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                output[i] = Int32.Parse(temp[i]);
            }

            return output;
        }

        // https://www.hackerrank.com/challenges/30-running-time-and-complexity/problem
        static void Day25()
        {
            int T = Int32.Parse(Console.ReadLine());

            while (T-- > 0)
            {
                if(isPrime(Int32.Parse(Console.ReadLine())))
                {
                    Console.WriteLine("Prime");
                }
                else
                {
                    Console.WriteLine("Not prime");
                }
            }
        }

        static bool isPrime(int n)
        {
            if (n <= 1)
            {
                return false;
            }
            if (n <= 3)
            {
                return true;
            }
            if (n % 2 == 0 || n % 3 == 0)
            {
                return false;
            }

            int root = (int)Math.Sqrt(n);
            for (int i = 5; i * 1 <= root; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }


        // https://www.hackerrank.com/challenges/30-linked-list-deletion/problem
        static void Day24()
        {
            Node head = null;
            int T = Int32.Parse(Console.ReadLine());
            while (T-- > 0)
            {
                int data = Int32.Parse(Console.ReadLine());
                head = insert(head, data);
            }
            head = removeDuplicates(head);
            display(head);
        }

        public static Node removeDuplicates(Node head)
        {
            //Write your code here

            if (head == null || head.next == null)
            {
                return head;
            }
            if (head.data == head.next.data)
            {
                head.next = head.next.next;
                removeDuplicates(head);
            }
            else
            {
                removeDuplicates(head.next);
            }
            return head;

            //Node node = new Node(head.data);
            ////Node node = new Node(head.data);

            //bool removed = false;

            //while (head != null)
            //{
            //    if (head.data == head.next.data)
            //    {

            //    }
            //}

            //do
            //{

            //    if (node.data == node.next.data)
            //    {
            //        node.next = null;

            //    }
            //    node = node.next;

            //}
            //while (removed);

            //return node;
        }

        public static Node insert(Node head, int data)
        {
            Node p = new Node(data);


            if (head == null)
                head = p;
            else if (head.next == null)
                head.next = p;
            else
            {
                Node start = head;
                while (start.next != null)
                    start = start.next;
                start.next = p;

            }
            return head;
        }
        public static void display(Node head)
        {
            Node start = head;
            while (start != null)
            {
                Console.Write(start.data + " ");
                start = start.next;
            }
        }


        //// https://www.hackerrank.com/challenges/30-binary-trees/problem
        //static void Day23()
        //{
        //    Node root = null;
        //    int T = Int32.Parse(Console.ReadLine());
        //    while (T-- > 0)
        //    {
        //        int data = Int32.Parse(Console.ReadLine());
        //        root = insert(root, data);
        //    }
        //    levelOrder(root);

        //}

        //static Node insert(Node root, int data)
        //{
        //    if (root == null)
        //    {
        //        return new Node(data);
        //    }
        //    else
        //    {
        //        Node cur;
        //        if (data <= root.data)
        //        {
        //            cur = insert(root.left, data);
        //            root.left = cur;
        //        }
        //        else
        //        {
        //            cur = insert(root.right, data);
        //            root.right = cur;
        //        }
        //        return root;
        //    }
        //}

        //static void levelOrder(Node root)
        //{
        //    //Write your code here
        //    Queue<Node> nodes = new Queue<Node>();
        //    nodes.Enqueue(root);
        //    string output = "";

        //    while (nodes.Count > 0)
        //    {
        //        Node current = nodes.Dequeue();
        //        output += current.data + " ";                

        //        if (current.left != null)
        //        {
        //            nodes.Enqueue(current.left);
        //        }
        //        if (current.right != null)
        //        {
        //            nodes.Enqueue(current.right);
        //        }
        //    }

        //    Console.WriteLine(output);
        //}


        // https://www.hackerrank.com/challenges/30-binary-search-trees/problem
        static void Day22()
        {
            //Node root = null;
            //int T = Int32.Parse(Console.ReadLine());
            //while (T-- > 0)
            //{
            //    int data = Int32.Parse(Console.ReadLine());
            //    root = insert(root, data);
            //}
            //int height = getHeight(root);
            //Console.WriteLine(height);

        }

        //static int getHeight(Node root)
        //{
        //    if (root == null)
        //    {
        //        return -1;
        //    }

        //    return Math.Max(1 + getHeight(root.left), 1 + getHeight(root.right));
        //}

        //static Node insert(Node root, int data)
        //{
        //    if (root == null)
        //    {
        //        return new Node(data);
        //    }
        //    else
        //    {
        //        Node cur;
        //        if (data <= root.data)
        //        {
        //            cur = insert(root.left, data);
        //            root.left = cur;
        //        }
        //        else
        //        {
        //            cur = insert(root.right, data);
        //            root.right = cur;
        //        }
        //        return root;
        //    }
        //}





        // https://www.hackerrank.com/challenges/30-generics/problem
        static void Day21()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] intArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                intArray[i] = Convert.ToInt32(Console.ReadLine());
            }

            n = Convert.ToInt32(Console.ReadLine());
            string[] stringArray = new string[n];
            for (int i = 0; i < n; i++)
            {
                stringArray[i] = Console.ReadLine();
            }

            PrintArray<Int32>(intArray);
            PrintArray<String>(stringArray);
        }

        static public void PrintArray<T>(T[] toPrint)
        {
            foreach (var item in toPrint)
            {
                Console.WriteLine(item);
            }            
        }


        // https://www.hackerrank.com/domains/tutorials/30-days-of-code/3
        static void Day20()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            // Write Your Code Here

            int totalSwaps = 0;

            for (int i = 0; i < n; i++)
            {
                // Track number of elements swapped during a single array traversal
                int numberOfSwaps = 0;                

                for (int j = 0; j < n - 1; j++)
                {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1])
                    {
                        // swap(a[j], a[j + 1]);
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                        numberOfSwaps++;
                        totalSwaps++;
                    }
                }

                // If no elements were swapped during a traversal, array is sorted
                if (numberOfSwaps == 0)
                {
                    break;
                }                
            }
            Console.WriteLine(string.Format("Array is sorted in {0} swaps.", totalSwaps));
            Console.WriteLine("First Element: " + a[0]);
            Console.WriteLine("Last Element: " + a[n - 1]);
        }

        static void swap(int j, int j1)
        {
            int tempVal = j;
            j = j1;
            j1 = tempVal;
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
        //public static void display(Node head)
        //{
        //    Node start = head;
        //    while (start != null)
        //    {
        //        Console.Write(start.data + " ");
        //        start = start.next;
        //    }
        //}
        //public static Node insert(Node head, int data)
        //{
        //    //Complete this method
        //    if (head == null)
        //        return new Node(data);
        //    else if (head.next == null)
        //    {
        //        head.next = new Node(data);
        //    }
        //    else
        //    {
        //        insert(head.next, data);
        //    }


        //    return head;

        //}

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
