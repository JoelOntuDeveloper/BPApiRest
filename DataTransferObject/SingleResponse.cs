namespace DataTransferObject {
    public class SingleResponse<T> where T : class {

        public bool Success { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
        public bool HasValidationExcepcion { get; set; }
        public List<string> ValidationExcepcion { get; set; } = new List<string>();

    }
}