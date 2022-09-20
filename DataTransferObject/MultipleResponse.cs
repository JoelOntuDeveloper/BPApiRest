namespace DataTransferObject {
    public class MultipleResponse<T> where T : class {

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<T> MultipleResult { get; set; }
    }
}
