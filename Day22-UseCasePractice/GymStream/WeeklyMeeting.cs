namespace GymStream{
    class String
    {
        static void Main()
        {
            string s = "Varshith";
            // string rev = "";

            // for(int i = s.Length - 1; i >= 0; i--){
            //     rev += s[i];
            // }
            // Console.WriteLine(rev);


            // For cuonting characters
            // for(int i = 0; i < s.Length; i++)
            // {
            //     int count = 0;
            //     for(int j = 0; j < s.Length; j++)
            //     {
            //         if(s[i] == s[j])
            //             count++;
            //     }
            //     System.Console.WriteLine(count);
            // }



            string word1 = Console.ReadLine()!;
            string word2 = Console.ReadLine()!;

            int delete = 0;
            for(int i = 0; i < word1.Length; i++)
            {
                if(!word2.Contains(word1[i]))
                {
                    delete++;
                }
            }
            System.Console.WriteLine(delete);
        }
    }
}