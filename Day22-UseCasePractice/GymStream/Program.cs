namespace GymStream{
    class Program
    {
        static void Main()
        {
            string s = "Varshith";
            // string rev = "";

            // for(int i = s.Length - 1; i >= 0; i--){
            //     rev += s[i];
            // }
            // Console.WriteLine(rev);


            for(int i = 0; i < s.Length; i++)
            {
                int count = 0;
                for(int j = 0; j < s.Length; j++)
                {
                    if(s[i] == s[j])
                        count++;
                }
                System.Console.WriteLine(count);
            }
        }
    }
}