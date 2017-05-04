namespace ABM.Entity
{
    public class JsonResponse
    {
        public int TotalRecords { get; set; }        

        public string Message { get; set; }
        public string Url { get; set; }
        public string PagerInfo { get; set; }
        public string Pager { get; set; }

        public bool Success { get; set; }
        public bool IsOtp { get; set; }

        public object Data { get; set; }

    }
}
