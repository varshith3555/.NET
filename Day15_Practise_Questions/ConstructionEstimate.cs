namespace Day15_Practise_Questons
{
    class ConstructionEstimateException : Exception
    {
        public ConstructionEstimateException(string message) : base(message)
        {
        }
    }
    class EstimateDetails
    {
        public float ConstructionArea { get; set; }
        public float SiteArea{ get; set; }
    }

    class ConstructionMain
    {
        public static EstimateDetails ValidateConstructionEstimate(float constructionArea, float siteArea)
        {
            if(constructionArea <= siteArea)
            {
                EstimateDetails e = new EstimateDetails();
                e.ConstructionArea = constructionArea;
                e.SiteArea = siteArea;
                return e;
            }
            else
            {
                throw new ConstructionEstimateException("Sorry your Construction Estimate is not approved");
            }
        }
        static void Main()
        {
            try
            {
                float constructionArea = float.Parse(Console.ReadLine());
                float siteArea = float.Parse(Console.ReadLine());

                EstimateDetails result = ValidateConstructionEstimate(constructionArea, siteArea);
                Console.WriteLine("Construction Estimate Approved");
            }
            catch (ConstructionEstimateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}