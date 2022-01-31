namespace SBC.Common
{
    public class ResultModel
    {
        public ResultModel(object value) => this.Value = value;

        public object Value { get; set; }
    }
}
