namespace SBC.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ResultModel
    {
        public ResultModel(object value) => this.Value = value;

        public object Value { get; set; }
    }
}
